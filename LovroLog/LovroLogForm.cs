using LovroLog.Database;
using LovroLog.Enums;
using LovroLog.LovroEvents;
using LovroLog.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LovroLog
{
    public partial class LovroLogForm : Form
    {
        #region Private fields

        private bool logDisplayed;
        private DateTime lastDataUpdate;
        private DateTime lastRedraw;
        private System.Media.SoundPlayer player;
        private bool warningDisplayed = false;
        private DateTime lastWarningConditionSetRelatedToDiaperChangeAt;
        private Dictionary<int, DateTime> erroneousEvents;
        private int? errorSelectedItemID;
        
        #region Timers
        private System.Threading.Timer refreshLogViewTimer;
        private System.Threading.Timer soundWarningTimer;
        private System.Threading.Timer stopwatchTimer;
        #endregion

        #endregion

        public LovroLogForm()
        {
            InitializeComponent();

            logListView.View = View.Details;
            logListView.GridLines = false;
            logListView.Scrollable = true;

            logListView.FullRowSelect = true;
            logListView.Columns.Add("Vrijeme");
            logListView.Columns.Add("Tip");
            logListView.Columns.Add("Detalji");
            logListView.Columns.Add("Trajanje");
            logListView.Columns.Add("Bilješka");
            logListView.SmallImageList = imageList1;

            logDisplayed = false;
            lastDataUpdate = DateTime.MinValue;
            lastRedraw = DateTime.MinValue;
            lastWarningConditionSetRelatedToDiaperChangeAt = DateTime.MinValue;

            refreshLogViewTimer = new System.Threading.Timer(this.RefreshLines, null, 0, 300);
            soundWarningTimer = new System.Threading.Timer(this.CheckSoundWarning, null, 1000, 1000);
            stopwatchTimer = new System.Threading.Timer(this.RefreshStopwatch, null, 1500, 1000);
        }

        private double GetDiaperChangeWarningLimitInMinutes()
        {
            return LovroAppSettings.AllowedHrsWithoutDiaperChange * 60;
        }

        private int GetBathWarningLimitInMinutes()
        {
            return LovroAppSettings.AllowedDaysWithoutBath * 24 * 60;
        }

        private void ShitButton_Click(object sender, EventArgs e)
        {
            AddEvent(LovroEventType.Pooped);
        }

        private void FoodButton_Click(object sender, EventArgs e)
        {
            AddEvent(LovroEventType.AteFood);
        }

        private void FellAsleep_Click(object sender, EventArgs e)
        {
            AddEvent(LovroEventType.FellAsleep);
        }

        private void WokeUpButton_Click(object sender, EventArgs e)
        {
            AddEvent(LovroEventType.WokeUp);
        }

        private void BathedButton_Click(object sender, EventArgs e)
        {
            AddEvent(LovroEventType.Bathed);
        }

        private void WetDiaperChangedButton_Click(object sender, EventArgs e)
        {
            AddDiaperChangedEvent(LovroDiaperStatus.Pissed);
        }

        private void PoopyDiaperChangedButton_Click(object sender, EventArgs e)
        {
            AddDiaperChangedEvent(LovroDiaperStatus.Soiled);
        }

        private void AddDiaperChangedEvent(LovroDiaperStatus diaperStatus)
        {
            AddEvent(new LovroDiaperChangedEvent(diaperStatus));
        }

        private void AddEvent(LovroEventType eventType)
        {
            AddEvent(new LovroBaseEvent(eventType));
        }

        private void AddEvent(LovroBaseEvent lovroEvent)
        {
            if (!AskForDetails(lovroEvent))
            {
                return;
            }

            using (var dataAccess = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                dataAccess.AddBaseEvent(lovroEvent);
            }
        }

        private bool AskForDetails(LovroBaseEvent lovroEvent)
        {
            if (askForDetailsCheckBox.Checked || Control.ModifierKeys == Keys.Control || lovroEvent.Type == LovroEventType.Other)
            {
                using (var form = new LovroEventEditForm())
                {
                    form.EventInEditing = lovroEvent;
                    return form.ShowDialog() == DialogResult.OK;
                }
            }

            return true;
        }

        private void LovroLogForm_Load(object sender, EventArgs e)
        {
            filterByTypeComboBox.Items.Clear();

            Dictionary<string, string> typeValuesList = new Dictionary<string, string>();
            foreach (LovroEventType type in Enum.GetValues(typeof(LovroEventType)).Cast<LovroEventType>())
                if (type != LovroEventType.Default)
                    //typeValuesList.Add(type.ToString(), GetEnumDescription(typeof(LovroEventType), type.ToString()));
                    typeValuesList.Add(type.ToString(), GetEventTypeDescription(type));

            filterByTypeComboBox.DataSource = new BindingSource(typeValuesList, null);
            filterByTypeComboBox.DisplayMember = "Value";
            filterByTypeComboBox.ValueMember = "Key";

            SetSoundAlarmControls(LovroAppSettings.SilentAlarmAlways);
        }

        private void SetSoundAlarmControls(bool setToSilent)
        {
            SilentModeCheckBox.Checked = setToSilent;
            SetSoundAlarmSymbols(setToSilent);
        }
        
        private void SetSoundAlarmSymbols(bool setToSilent)
        {
            Image setToImage = setToSilent ? Resources.ResourceManager.GetObject("sound-20") as Image : Resources.ResourceManager.GetObject("sound-off2-20") as Image;
            if (setToImage == null)
                return;

            ToggleSoundButton.Image = setToImage;
            ToolStripMenuItem menuItem = (contextMenuStrip1.Items.Find("ToggleSoundOnOffMenuItem", false).FirstOrDefault() as ToolStripMenuItem);
            menuItem.Image = setToImage;
            menuItem.Text = setToSilent ? "Uključi zvuk" : "Isključi zvuk";

            menuItem = (menuStrip1.Items.Find("ToggleSoundToolStripMenuItem", true).FirstOrDefault() as ToolStripMenuItem);
            menuItem.Image = setToImage;
            menuItem.Text = setToSilent ? "Uključi zvuk" : "Isključi zvuk";
        }

        private void ToggleLogButton_Click(object sender, EventArgs e)
        {
            ToggleLog(sender);
        }

        //TODO REFACTOR
        private string GetEventTypeDescription(LovroEventType type)
        {
            FieldInfo fi = type.GetType().GetField(type.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.FirstOrDefault() != null ? attributes.FirstOrDefault().Description : "UNKNOWN";
        }

        private string GetStatusDescription(LovroDiaperStatus status)
        {
            FieldInfo fi = status.GetType().GetField(status.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.FirstOrDefault() != null ? attributes.FirstOrDefault().Description : "UNKNOWN";
        }

        //šteka
        //private string GetEnumDescription(Type type, string value)
        //{
        //    FieldInfo fi = type.GetField(value);
        //    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        //    return attributes.FirstOrDefault() != null ? attributes.FirstOrDefault().Description : "UNKNOWN";
        //}

        private int GetImageIndexForEventType(LovroBaseEvent lovroEvent)
        {
            int result = -1;

            switch (lovroEvent.Type)
            {
                case LovroEventType.AteFood:
                    return 3;

                case LovroEventType.Bathed:
                    return 0;

                case LovroEventType.DiaperChanged:
                    switch ((lovroEvent as LovroDiaperChangedEvent).Status)
                    {
                        case LovroDiaperStatus.Pissed:
                            result = 2;
                            break;
                        case LovroDiaperStatus.Soiled:
                            result = 1;
                            break;
                        default:
                            break;
                    }
                    return result;

                case LovroEventType.FellAsleep:
                    return 5;

                case LovroEventType.Pooped:
                    return 4;

                case LovroEventType.WokeUp:
                    return 6;

                case LovroEventType.Other:
                    return 7;

                case LovroEventType.WeighIn:
                    return 8;

                case LovroEventType.Default:
                    return -1;

                default:
                    return -1;
            }
        }

        private void SetImageIndex(LovroBaseEvent lovroEvent, ListViewItem viewItem)
        {
            int imageIndex = GetImageIndexForEventType(lovroEvent);
            if (imageIndex != -1)
                viewItem.ImageIndex = imageIndex;
        }

        private ListViewItem CreateViewItem(LovroBaseEvent lovroEvent, DataAccessWrapper dataAccess)
        {
            ListViewItem viewItem = new ListViewItem(lovroEvent.Time.ToString());
            viewItem.Tag = lovroEvent.ID;
            //viewItem.SubItems.Add(GetEnumDescription(typeof(LovroDiaperStatus), lovroEvent.Type.ToString()));
            viewItem.SubItems.Add(GetEventTypeDescription(lovroEvent.Type));

            SetImageIndex(lovroEvent, viewItem);

            if (lovroEvent.Type == LovroEventType.DiaperChanged)
            {
                //viewItem.SubItems.Add(GetEnumDescription(typeof(LovroDiaperChangedEvent), (lovroEvent as LovroDiaperChangedEvent).Status.ToString()));
                viewItem.SubItems.Add(GetStatusDescription((lovroEvent as LovroDiaperChangedEvent).Status));
            }
            else
                viewItem.SubItems.Add("");

            if (lovroEvent.Type == LovroEventType.DiaperChanged)
            {
                LovroBaseEvent diaperLastChanged = dataAccess.GetBaseEvents().Where(item => item.Type == LovroEventType.DiaperChanged && item.ID != lovroEvent.ID && item.Time < lovroEvent.Time).OrderByDescending(item => item.Time).FirstOrDefault();
                viewItem.SubItems.Add(diaperLastChanged == null ? "" : (lovroEvent.Time - diaperLastChanged.Time).ToString(@"hh\:mm"));
            }
            else if (lovroEvent.Type == LovroEventType.WokeUp)
            {
                LovroBaseEvent lastFellAsleepEvent = dataAccess.GetBaseEvents().Where(item => item.Type == LovroEventType.FellAsleep && item.Time < lovroEvent.Time).OrderByDescending(item => item.Time).FirstOrDefault();
                if (lastFellAsleepEvent != null)
                    viewItem.SubItems.Add((lovroEvent.Time - lastFellAsleepEvent.Time).ToString(@"hh\:mm"));
            }
            else
                viewItem.SubItems.Add("");

            viewItem.SubItems.Add(lovroEvent.Note);
            
            return viewItem;
        }

        delegate void RefreshControlCallback(object state);

        private void RefreshLines(object state)
        {
            using (var dataAccess = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                DatabaseSummary summary = dataAccess.GetSummary();
                if (summary != null)
                    lastDataUpdate = summary.LastModified;
                else
                    lastDataUpdate = DateTime.MinValue.AddSeconds(1);
            }
            
            if (lastDataUpdate > lastRedraw)
            {
                if (logListView.InvokeRequired)
                {
                    RefreshControlCallback callback = new RefreshControlCallback(RefreshLines);
                    this.Invoke(callback, new object[] { null });
                }
                else
                {
                    logListView.Items.Clear();

                    using (var dataAccess = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
                    {
                        LovroEventType typeFilter = LovroEventType.Default;
                        if (!Enum.TryParse(((KeyValuePair<string, string>)filterByTypeComboBox.SelectedItem).Key, out typeFilter))
                            typeFilter = LovroEventType.Default;

                        DateTime dateFilter = displayedDatePicker.Value.Date;

                        #region Displaying individual items

                        foreach (LovroBaseEvent lovroEvent in dataAccess.GetBaseEvents().OrderBy(item => item.Time))
                        {
                            if (filterByTypeCheckBox.Checked && typeFilter != LovroEventType.Default && typeFilter != lovroEvent.Type)
                                continue;

                            if (filterByDateCheckBox.Checked && dateFilter != lovroEvent.Time.Date)
                                continue;

                            ListViewItem viewItem = CreateViewItem(lovroEvent, dataAccess);
                            logListView.Items.Add(viewItem);

                            if (viewItem.Index % 2 == 0)
                                viewItem.BackColor = Color.Beige;

                            logListView.TopItem = viewItem;
                            logListView.EnsureVisible(logListView.Items.Count - 1);
                        }

                        logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        PointToErroneousEvent();
                        Refresh();

                        #endregion

                        #region Displaying summary info

                        int diapersChangedCount = 0;
                        int feedingTimesCount = 0;
                        int wakeUpCount = 0;

                        DateTime today = filterByDateCheckBox.Checked ? displayedDatePicker.Value.Date : DateTime.Now.Date;
                        DateTime tomorrow = today.AddDays(1);

                        #region Calculating total nap time

                        TimeSpan totalNapTime = TimeSpan.Zero;

                        IEnumerable<LovroBaseEvent> wakeUpEvents = dataAccess.GetBaseEvents().Where(item => item != null && (item.Time >= today && item.Time < tomorrow && item.Type == LovroEventType.WokeUp));
                        IEnumerable<LovroBaseEvent> correspondingFellAsleepEvents = wakeUpEvents.Select(wakeUpEvent => dataAccess.GetBaseEvents().OrderByDescending(item => item.Time).FirstOrDefault(item => item.Type == LovroEventType.FellAsleep && wakeUpEvent.Time > item.Time));
                        wakeUpEvents = wakeUpEvents.Where(wakeUpEvent => wakeUpEvent != null);
                        correspondingFellAsleepEvents = correspondingFellAsleepEvents.Where(item => item != null);

                        wakeUpCount = wakeUpEvents.Count();
                        if (wakeUpCount > correspondingFellAsleepEvents.Count())
                        {
                            //throw new InvalidOperationException("Nešto ne štima u bazi. Najebo si, useru moj!");
                            // just log the error and skip the section for now
                            Console.WriteLine("Error: Data mismatch");
                        }
                        else
                        {
                            for (int i = 0; i < wakeUpCount; i++)
                            {
                                DateTime sleepStartTime = correspondingFellAsleepEvents.ElementAt(i).Time;
                                if (sleepStartTime.Date < today)
                                    sleepStartTime = today; // at midnight

                                totalNapTime += (wakeUpEvents.ElementAt(i).Time - sleepStartTime);
                            }
                        }

                        #endregion

                        diapersChangedCount = dataAccess.GetDiaperChangedEvents().Count(item => item.Time >= today && item.Time < tomorrow);
                        feedingTimesCount = dataAccess.GetBaseEvents().Count(item => item.Type == LovroEventType.AteFood && item.Time >= today && item.Time < tomorrow);

                        summaryLabel.Text = string.Concat("Tokom dana ukupno spavao: ", totalNapTime.ToString(@"hh\:mm"), " sati, jeo ", feedingTimesCount, " puta, promijenjeno ", diapersChangedCount, " pelena");

                        #endregion

                        lastRedraw = DateTime.Now;
                    }
                }
            }
        }

        private void RefreshStopwatch(object state)
        {
            if (logListView.InvokeRequired){
                RefreshControlCallback callback = new RefreshControlCallback(RefreshStopwatch);
                if (!this.Disposing)
                    this.Invoke(callback, new object[] { null });
            }
            else
            {
                using (var dataAccessWrapper = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
                {
                    TimeSpan timeExpired;

                    LovroDiaperChangedEvent diaperChangedEvent = dataAccessWrapper.GetDiaperChangedEvents().OrderByDescending(item => item.Time).FirstOrDefault();
                    if (diaperChangedEvent != null)
                    {
                        timeExpired = DateTime.Now - dataAccessWrapper.GetDiaperChangedEvents().OrderByDescending(item => item.Time).FirstOrDefault().Time;
                        stopwatchDiaperLabel.Text = timeExpired.ToString(@"hh\:mm\:ss");
                        if (timeExpired.TotalMinutes > GetDiaperChangeWarningLimitInMinutes())
                            stopwatchDiaperLabel.ForeColor = Color.Red;
                        else
                            stopwatchDiaperLabel.ForeColor = Color.Black;
                    }

                    LovroBaseEvent lastWokeUpEvent = dataAccessWrapper.GetBaseEvents().Where(item => item.Type == LovroEventType.WokeUp).OrderByDescending(item => item.Time).FirstOrDefault();
                    DateTime lastWokeUp = lastWokeUpEvent != null ? lastWokeUpEvent.Time : DateTime.MinValue;

                    LovroBaseEvent lastFellAsleepEvent = dataAccessWrapper.GetBaseEvents().Where(item => item.Type == LovroEventType.FellAsleep).OrderByDescending(item => item.Time).FirstOrDefault();
                    DateTime lastFellAsleep = lastFellAsleepEvent != null ? lastFellAsleepEvent.Time : DateTime.MinValue;

                    if (lastWokeUp > lastFellAsleep) //if not sleeping atm
                    {
                        timeExpired = DateTime.Now - lastWokeUp;
                        stopwatchSleepLabel.Text = timeExpired.ToString(@"hh\:mm\:ss");                        
                    }
                    else
                        stopwatchSleepLabel.Text = "00:00:00";

                    LovroBaseEvent lastAteFoodEvent = dataAccessWrapper.GetBaseEvents().Where(item => item.Type == LovroEventType.AteFood).OrderByDescending(item => item.Time).FirstOrDefault();
                    timeExpired = lastAteFoodEvent != null ? (DateTime.Now - lastAteFoodEvent.Time) : new TimeSpan(0);
                    stopwatchFoodLabel.Text = timeExpired.ToString(@"hh\:mm\:ss");
                }
            }
        }

        private void RefreshLogViewButton_Click(object sender, EventArgs e)
        {
            RefreshLines(null);
        }

        private void CheckSoundWarning(object state)
        {
            using (var dataAccessWrapper = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                LovroDiaperChangedEvent lastDiaperChangedEvent = dataAccessWrapper.GetDiaperChangedEvents().OrderByDescending(item => item.Time).FirstOrDefault();
                DateTime now = DateTime.Now;

                if (lastDiaperChangedEvent != null && now > lastDiaperChangedEvent.Time.AddMinutes(GetDiaperChangeWarningLimitInMinutes()))
                {
                    if (lastWarningConditionSetRelatedToDiaperChangeAt < lastDiaperChangedEvent.Time)
                    {
                        player = new System.Media.SoundPlayer(@"c:\windows\media\Windows Battery Critical.wav");

                        if (!SilentModeCheckBox.Checked && now.Hour > LovroAppSettings.SilentAlarmBefore && now.Hour < LovroAppSettings.SilentAlarmAfter)
                            player.PlayLooping();
                        
                        lastWarningConditionSetRelatedToDiaperChangeAt = lastDiaperChangedEvent.Time;

                        if (!warningDisplayed)
                        {
                            lastWarningConditionSetRelatedToDiaperChangeAt = lastDiaperChangedEvent.Time;
                            using (var form = new ShowWarningForm())
                            {
                                warningDisplayed = true;
                                var result = form.ShowDialog();
                                if (result == DialogResult.OK && player != null)
                                {
                                    warningDisplayed = false;
                                    player.Stop();
                                    player.Dispose();
                                }
                            }
                        }
                    }
                }
                else if (player != null)
                    player.Stop();
            }
        }

        private void filterByDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (filterByDateCheckBox.Checked)
                dateGroupBox.Enabled = true;
            else
                dateGroupBox.Enabled = false;

            ForceRefresh();
        }

        private void filterByTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (filterByTypeCheckBox.Checked)
                filterByTypeGroupBox.Enabled = true;
            else
                filterByTypeGroupBox.Enabled = false;

            ForceRefresh();
        }

        private void goBackTimeButton_Click(object sender, EventArgs e)
        {
            displayedDatePicker.Value = displayedDatePicker.Value.AddDays(-1);
        }

        private void goForwardTimeButton_Click(object sender, EventArgs e)
        {
            displayedDatePicker.Value = displayedDatePicker.Value.AddDays(1);
        }

        private void displayedDatePicker_ValueChanged(object sender, EventArgs e)
        {
            ForceRefresh();
        }

        private void filterByTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ForceRefresh();
        }

        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            DeleteEvents();
        }

        private void editEventButton_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void logListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditEvent();
        }

        private void DeleteEvents()
        {
            if (logListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Nijedan unos nije odabran.");
                return;
            }

            if (MessageBox.Show(string.Concat("Sigurno želiš obrisati odabrane unose? (", logListView.SelectedItems.Count, " komad(a))"), "Upozorenje", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            using (var dataAccessWrapper = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                var toBeDeletedIDs = logListView.SelectedItems.Cast<ListViewItem>().Select(item => (int)item.Tag);
                var toBeDeletedItems = dataAccessWrapper.GetBaseEvents().Where(item => toBeDeletedIDs.Contains(item.ID));

                foreach (LovroBaseEvent lovroEvent in toBeDeletedItems)
                    dataAccessWrapper.DeleteBaseEvent(lovroEvent.ID);
            }
        }

        private void EditEvent()
        {
            if (logListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("Nijedan unos nije odabran.");
                return;
            }

            ListViewItem viewItem = logListView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            int eventID = (int)viewItem.Tag;

            EditEvent(eventID);
        }

        private void EditEvent(int eventID)
        {
            using (var dataAccessWrapper = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                LovroBaseEvent eventInEditing = dataAccessWrapper.GetBaseEvents().FirstOrDefault(item => item.ID == eventID);

                if (eventInEditing == null)
                    throw new InvalidOperationException("Nepostojeći unos!");

                using (var editForm = new LovroEventEditForm())
                {
                    editForm.EventInEditing = eventInEditing;
                    if (editForm.ShowDialog() == DialogResult.OK) // eventInEditing properties will be changed in the dialog
                        dataAccessWrapper.EditBaseEvent(eventInEditing);
                }
            }
        }

        private void toggleLogPBoxBtn_Click(object sender, EventArgs e)
        {
            ToggleLog(sender);
        }

        // TODO: riješiti ovaj exception kod gašenja/dispozanja!!!
        //public override void Dispose()
        //{
        //    stopwatchTimer.Dispose();
        //    base.Dispose();
        //}

        private void ToggleLog(object sender)
        {
            if (logDisplayed)
            {
                //(sender as Button).Text = ">>>";
                logDisplayed = false;
                logListView.Visible = false;
                this.Width = 555;

                if (sender is PictureBox)
                    (sender as PictureBox).Image = Resources.ResourceManager.GetObject("plus3d-35px") as Image;
            }
            else
            {
                //(sender as Button).Text = "<<<";
                logDisplayed = true;
                logListView.Visible = true;
                this.Width = 1257;

                if (sender is PictureBox)
                    (sender as PictureBox).Image = Resources.ResourceManager.GetObject("minus3d-35px") as Image;
            }
        }

        private void toggleLogPBoxBtn_MouseEnter(object sender, EventArgs e)
        {
            if (logDisplayed)
            {
                (sender as PictureBox).Image = Resources.ResourceManager.GetObject("minus3d-gray-35px") as Image;
            }
            else
            {
                (sender as PictureBox).Image = Resources.ResourceManager.GetObject("plus3d-gray-35px") as Image;
            }
        }

        private void toggleLogPBoxBtn_MouseLeave(object sender, EventArgs e)
        {
            if (logDisplayed)
            {
                (sender as PictureBox).Image = Resources.ResourceManager.GetObject("minus3d-35px") as Image;
            }
            else
            {
                (sender as PictureBox).Image = Resources.ResourceManager.GetObject("plus3d-35px") as Image;
            }
        }

        private void otherEventButton_Click(object sender, EventArgs e)
        {
            AddEvent(LovroEventType.Other);
        }

        private void ForceRefresh()
        {
            lastRedraw = DateTime.MinValue;
        }

        private void logListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.HasFlag(Keys.Delete))
                DeleteEvents();

            if (e.KeyCode.HasFlag(Keys.F2))
                EditEvent();
        }

        private void DoViewSleepChart()
        {
            using (var form = new SleepChartForm(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase, displayedDatePicker.Value.Date))
            {
                var result = form.ShowDialog();
                if (form.GoToDate.HasValue)
                    displayedDatePicker.Value = form.GoToDate.Value;
            }
        }

        private void viewSleepChartButton_Click(object sender, EventArgs e)
        {
            DoViewSleepChart();
        }

        private void DoDisplayErrors()
        {
            erroneousEvents = new Dictionary<int, DateTime>();

            using (var dataAccessWrapper = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                List<LovroBaseEvent> napEvents = dataAccessWrapper.GetBaseEvents().Where(item => item.Type == LovroEventType.FellAsleep || item.Type == LovroEventType.WokeUp).OrderBy(item => item.Time).ToList();

                bool typeChanged = true, firstGo = true;
                LovroEventType lastType = LovroEventType.FellAsleep; // svejedno
                foreach (LovroBaseEvent lovroEvent in napEvents)
                {
                    typeChanged = false;

                    if (firstGo || lastType != lovroEvent.Type)
                        typeChanged = true;

                    if (!typeChanged)
                        erroneousEvents.Add(lovroEvent.ID, lovroEvent.Time);

                    firstGo = false;
                    lastType = lovroEvent.Type;
                }
            }

            using (var errorsDisplayForm = new ErroneousEventsListForm(erroneousEvents))
            {
                errorSelectedItemID = null;
                errorsDisplayForm.ShowDialog();
                if (errorsDisplayForm.SelectedDate.HasValue)
                {
                    errorSelectedItemID = errorsDisplayForm.SelectedItemID;
                    displayedDatePicker.Value = errorsDisplayForm.SelectedDate.Value;
                }
            }
        }

        private void DisplayErrorsButton_Click(object sender, EventArgs e)
        {
            DoDisplayErrors();
        }

        private void PointToErroneousEvent()
        {
            logListView.Select();
            logListView.SelectedItems.Clear();

            if (errorSelectedItemID.HasValue)
                foreach (ListViewItem item in logListView.Items)
                {
                    if ((int)item.Tag == errorSelectedItemID.Value)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            errorSelectedItemID = null;
        }

        private void LovroLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SilentAlarmAlways"].Value = SilentModeCheckBox.Checked.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void ToggleSoundButton_Click(object sender, EventArgs e)
        {
            SetSoundAlarmControls(!SilentModeCheckBox.Checked);
        }

        private void goToTodayButton_Click(object sender, EventArgs e)
        {
            displayedDatePicker.Value = DateTime.Now;
        }
        
        private void LovroLogForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this.Location.X + e.X, this.Location.Y + e.Y);
            }
        }

        private void ViewReportMenuItem_Click(object sender, EventArgs e)
        {
            DoViewSleepChart();
        }

        private void ViewErrorsMenuItem_Click(object sender, EventArgs e)
        {
            DoDisplayErrors();
        }

        private void ToggleSoundOnOffMenuItem_Click(object sender, EventArgs e)
        {
            SetSoundAlarmControls(!SilentModeCheckBox.Checked);
        }

        private void EditDetailsMenuItem_Click(object sender, EventArgs e)
        {
            askForDetailsCheckBox.Checked = !askForDetailsCheckBox.Checked;

            if (askForDetailsCheckBox.Checked)
                (sender as ToolStripMenuItem).Image = Resources.check_20 as Image;
            else
                (sender as ToolStripMenuItem).Image = null;
        }

        private void AteFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoodButton_Click(sender, e);
        }

        private void FellAsleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FellAsleep_Click(sender, e);
        }

        private void WokeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WokeUpButton_Click(sender, e);
        }

        private void PoopyDiaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PoopyDiaperChangedButton_Click(sender, e);
        }

        private void WetDiaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WetDiaperChangedButton_Click(sender, e);
        }

        private void OtherEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otherEventButton_Click(sender, e);
        }

        private void ToggleSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSoundAlarmControls(!SilentModeCheckBox.Checked);
        }

        private void EditDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDetailsMenuItem_Click(sender, e);
        }

        private void SleepChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoViewSleepChart();
        }

        private void ViewErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoDisplayErrors();
        }

        private void EditEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditEvent();
        }

        private void DeleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEvents();
        }

        private void ImportFromXMLMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog() { Multiselect = false })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImportFromXML(fileDialog.FileName);
                }
            }
        }

        private void ExportToXMLMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog() { Multiselect = false })
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToXML(fileDialog.FileName);
                }
            }
        }

        private void ImportFromXML(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The source XML file could not be found.");

            if (MessageBox.Show("Jeste li sigurni da želite uvesti podatke iz odabrane datoteke?", "Upozorenje", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            using (var dataAccess = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                using (var dataToImport = new DataAccessXML(filePath))
                {
                    // no merging of events based on ID! IDs from the import file will be ignored and all items found in file will be added to the database as new entries
                    dataToImport.GetBaseEvents().ToList().ForEach(lovroEvent => dataAccess.AddBaseEvent(lovroEvent));
                }
            }
        }

        private void ExportToXML(string filePath)
        {
            if (File.Exists(filePath))
                if (MessageBox.Show("Odredišna datoteka već postoji. Nastaviti?", "Upozorenje", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

            using (var dataAccess = new DataAccessWrapper(LovroAppSettings.DataAccessDetails, LovroAppSettings.UseXMLDatabase))
            {
                using (var dataToExport = new DataAccessXML(filePath))
                {
                    dataToExport.LoadBaseEvents(dataAccess.GetBaseEvents().ToList());
                }
            }
        }
    }
}
