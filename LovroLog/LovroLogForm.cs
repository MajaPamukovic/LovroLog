﻿using LovroLog.Enums;
using LovroLog.LovroEvents;
using LovroLog.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
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

        #region Default settings values
        private const int defaultWarnDiaperUnchangedAfterHrs = 3;
        private const int defaultWarnHasNotBathedAfterDays = 4;
        #endregion

        private int warnDiaperUnchangedAfterHrs;
        private int warnHasNotBathedAfterDays;
        private string connectionString = "";
        private bool logDisplayed;
        private DateTime lastDataUpdate;
        private DateTime lastRedraw;
        private System.Media.SoundPlayer player;
        private bool warningDisplayed = false;
        private bool ignoreWarnings = false;
        private DateTime warningLastSet, warningLastIgnored;

        #region Timers
        private System.Threading.Timer refreshLogViewTimer;
        private System.Threading.Timer soundWarningTimer;
        private System.Threading.Timer stopwatchTimer;
        #endregion

        #endregion

        public LovroLogForm()
        {
            InitializeComponent();

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("AllowedHrsWithoutDiaperChange"), out warnDiaperUnchangedAfterHrs))
                warnDiaperUnchangedAfterHrs = defaultWarnDiaperUnchangedAfterHrs;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("AllowedHrsWithoutDiaperChange"), out warnHasNotBathedAfterDays))
                warnHasNotBathedAfterDays = defaultWarnHasNotBathedAfterDays;

            connectionString = ConfigurationManager.AppSettings.Get("DatabaseConnectionString");

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
            warningLastSet = DateTime.MinValue;
            warningLastIgnored = DateTime.MinValue;

            refreshLogViewTimer = new System.Threading.Timer(this.RefreshLines, null, 0, 300);
            soundWarningTimer = new System.Threading.Timer(this.CheckSoundWarning, null, 1000, 1000);
            stopwatchTimer = new System.Threading.Timer(this.RefreshStopwatch, null, 1500, 1000);
        }

        private int GetDiaperChangeWarningLimitInMinutes()
        {
            return warnDiaperUnchangedAfterHrs * 60;
        }

        private int GetBathWarningLimitInMinutes()
        {
            return warnHasNotBathedAfterDays * 24 * 60;
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

            using (var context = new LovroContext(connectionString))
            {
                //context.AddBaseEvent(lovroEvent);

                context.BaseEvents.Add(lovroEvent);
                context.SaveChanges();
            }
        }

        private bool AskForDetails(LovroBaseEvent lovroEvent)
        {
            if (askForDetailsCheckBox.Checked || Control.ModifierKeys == Keys.Control || lovroEvent.Type == LovroEventType.Other)
            {
                using (var form = new AskForDetailsForm())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        lovroEvent.Note = form.EnteredNote;
                        lovroEvent.Time = form.EnteredTime;
                    }
                    else
                        return false;
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

        private ListViewItem CreateViewItem(LovroBaseEvent lovroEvent, LovroContext context)
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
                LovroBaseEvent diaperLastChanged = context.BaseEvents.Where(item => item.Type == LovroEventType.DiaperChanged && item.ID != lovroEvent.ID && item.Time < lovroEvent.Time).OrderByDescending(item => item.Time).FirstOrDefault();
                viewItem.SubItems.Add(diaperLastChanged == null ? "" : (lovroEvent.Time - diaperLastChanged.Time).ToString(@"hh\:mm"));
            }
            else if (lovroEvent.Type == LovroEventType.WokeUp)
            {
                LovroBaseEvent lastFellAsleepEvent = context.BaseEvents.Where(item => item.Type == LovroEventType.FellAsleep && item.Time < lovroEvent.Time).OrderByDescending(item => item.Time).FirstOrDefault();
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
            using (var context = new LovroContext(connectionString))
            {
                DatabaseSummary summary = context.Summaries.FirstOrDefault();

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

                    using (var context = new LovroContext(connectionString))
                    {
                        LovroEventType typeFilter = LovroEventType.Default;
                        if (!Enum.TryParse(((KeyValuePair<string, string>)filterByTypeComboBox.SelectedItem).Key, out typeFilter))
                            typeFilter = LovroEventType.Default;

                        DateTime dateFilter = displayedDatePicker.Value.Date;

                        #region Displaying individual items
                        
                        foreach (LovroBaseEvent lovroEvent in context.BaseEvents.OrderBy(item => item.Time))
                        {
                            if (filterByTypeCheckBox.Checked && typeFilter != LovroEventType.Default && typeFilter != lovroEvent.Type)
                                continue;

                            if (filterByDateCheckBox.Checked && dateFilter != lovroEvent.Time.Date)
                                continue;

                            ListViewItem viewItem = CreateViewItem(lovroEvent, context);
                            logListView.Items.Add(viewItem);

                            if (viewItem.Index % 2 == 0)
                                viewItem.BackColor = Color.Beige;

                            logListView.TopItem = viewItem;
                            logListView.EnsureVisible(logListView.Items.Count - 1);
                        }
                        
                        logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
                        IEnumerable<LovroBaseEvent> wakeUpEvents = context.BaseEvents.Where(item => item.Time >= today && item.Time < tomorrow && item.Type == LovroEventType.WokeUp);
                        IEnumerable<LovroBaseEvent> correspondingFellAsleepEvents = wakeUpEvents.Select(wakeUpEvent => context.BaseEvents.OrderByDescending(item => item.Time).FirstOrDefault(item => item.Type == LovroEventType.FellAsleep && wakeUpEvent.Time > item.Time));

                        wakeUpCount = wakeUpEvents.Count();
                        if (wakeUpCount != correspondingFellAsleepEvents.Count())
                            throw new InvalidOperationException("Nešto ne štima u bazi. Najebo si, useru moj!");

                        for (int i = 0; i < wakeUpCount; i++)
                        {
                            DateTime sleepStartTime = correspondingFellAsleepEvents.ElementAt(i).Time;
                            if (sleepStartTime.Date < today)
                                sleepStartTime = today; // at midnight

                            totalNapTime += (wakeUpEvents.ElementAt(i).Time - sleepStartTime);
                        }

                        // TODO--nema smisla ako se ovo polje ne updatea svake sekunde/redovito
                        //DateTime lastWokeUp = context.BaseEvents.Where(item => item.Type == LovroEventType.WokeUp).OrderByDescending(item => item.Time).FirstOrDefault().Time;
                        //DateTime lastFellAsleep = context.BaseEvents.Where(item => item.Type == LovroEventType.FellAsleep).OrderByDescending(item => item.Time).FirstOrDefault().Time;

                        //if (lastWokeUp < lastFellAsleep) //if sleeping atm
                        //    totalNapTime += (DateTime.Now - lastFellAsleep);

                        #endregion

                        diapersChangedCount = context.DiaperChangedEvents.Count(item => item.Time >= today && item.Time < tomorrow);
                        feedingTimesCount = context.BaseEvents.Count(item => item.Type == LovroEventType.AteFood && item.Time >= today && item.Time < tomorrow);

                        summaryLabel.Text = string.Concat("Tokom dana ukupno spavao: ", totalNapTime.ToString(@"hh\:mm"), " sati, jeo ", feedingTimesCount, " puta, promijenjeno ", diapersChangedCount, " pelena");

                        #endregion

                        lastRedraw = DateTime.Now;
                    }
                }
            }
        }

        private void RefreshStopwatch(object state)
        {
            if (logListView.InvokeRequired)
            {
                RefreshControlCallback callback = new RefreshControlCallback(RefreshStopwatch);
                if (!this.Disposing)
                    this.Invoke(callback, new object[] { null });
            }
            else
            {
                using (var context = new LovroContext(connectionString))
                {
                    TimeSpan timeExpired;

                    LovroDiaperChangedEvent diaperChangedEvent = context.DiaperChangedEvents.OrderByDescending(item => item.Time).FirstOrDefault();
                    if (diaperChangedEvent != null)
                    {
                        timeExpired = DateTime.Now - context.DiaperChangedEvents.OrderByDescending(item => item.Time).FirstOrDefault().Time;
                        stopwatchDiaperLabel.Text = timeExpired.ToString(@"hh\:mm\:ss");
                        if (timeExpired.TotalMinutes > GetDiaperChangeWarningLimitInMinutes())
                            stopwatchDiaperLabel.ForeColor = Color.Red;
                        else
                            stopwatchDiaperLabel.ForeColor = Color.Black;
                    }

                    DateTime lastWokeUp = context.BaseEvents.Where(item => item.Type == LovroEventType.WokeUp).OrderByDescending(item => item.Time).FirstOrDefault().Time;
                    DateTime lastFellAsleep = context.BaseEvents.Where(item => item.Type == LovroEventType.FellAsleep).OrderByDescending(item => item.Time).FirstOrDefault().Time;

                    if (lastWokeUp > lastFellAsleep) //if not sleeping atm
                    {
                        timeExpired = DateTime.Now - lastWokeUp;
                        stopwatchSleepLabel.Text = timeExpired.ToString(@"hh\:mm\:ss");                        
                    }
                    else
                        stopwatchSleepLabel.Text = "00:00:00";

                    timeExpired = DateTime.Now - context.BaseEvents.Where(item => item.Type == LovroEventType.AteFood).OrderByDescending(item => item.Time).FirstOrDefault().Time;
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
            using (var context = new LovroContext(connectionString))
            {
                LovroDiaperChangedEvent lastDiaperChangedEvent = context.DiaperChangedEvents.OrderByDescending(item => item.Time).FirstOrDefault();

                //if (!ignoreWarnings && lastDiaperChangedEvent != null && DateTime.Now > lastDiaperChangedEvent.Time.AddMinutes(GetDiaperChangeWarningLimitInMinutes()))
                if (lastDiaperChangedEvent != null && DateTime.Now > lastDiaperChangedEvent.Time.AddMinutes(GetDiaperChangeWarningLimitInMinutes()))
                {
                    if (!ignoreWarnings || warningLastSet > warningLastIgnored) // ??? WTF? TODO
                    {
                        player = new System.Media.SoundPlayer(@"c:\windows\media\Windows Battery Critical.wav");
                        player.PlayLooping();

                        if (!warningDisplayed)
                        {
                            warningLastSet = DateTime.Now;
                            using (var form = new ShowWarningForm())
                            {
                                warningDisplayed = true;
                                var result = form.ShowDialog();
                                if (result == DialogResult.OK && player != null)
                                {
                                    player.Stop();
                                    player.Dispose();
                                    ignoreWarnings = true;
                                    warningLastIgnored = DateTime.Now;
                                    warningLastSet = DateTime.MinValue;
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
                return;

            if (MessageBox.Show(string.Concat("Sigurno želiš obrisati odabrane unose? (", logListView.SelectedItems.Count, " komad(a))"), "Upozorenje", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            using (var context = new LovroContext(connectionString))
            {
                var toBeDeletedIDs = logListView.SelectedItems.Cast<ListViewItem>().Select(item => (int)item.Tag);
                var toBeDeletedItems = context.BaseEvents.Where(item => toBeDeletedIDs.Contains(item.ID));

                foreach (LovroBaseEvent lovroEvent in toBeDeletedItems)
                    context.BaseEvents.Remove(lovroEvent);

                context.SaveChanges();
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
            using (var context = new LovroContext(connectionString))
            {
                LovroBaseEvent eventInEditing = context.BaseEvents.FirstOrDefault(item => item.ID == eventID);

                if (eventInEditing == null)
                    throw new InvalidOperationException("Nepostojeći unos!");

                using (var editForm = new LovroEventEditForm())
                {
                    editForm.EventInEditing = eventInEditing;
                    if (editForm.ShowDialog() == DialogResult.OK) // eventInEditing properties will be changed in the dialog
                        context.SaveChanges();
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
    }
}