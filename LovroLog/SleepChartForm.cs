using LovroLog.Core.Enums;
using LovroLog.Core.LovroEvents;
using LovroLog.LovroLogServiceReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LovroLog
{
    public partial class SleepChartForm : Form
    {
        private const int _defaultNumberOfDays = 7;
        private const int _yOffset = 40;
        private const int _yBottomPadding = 70;
        private const int _xBigOffset = 100;
        private const int _xOffset = 150;
        private const int _rowHeight = 30;
        private const int _hoursInDay = 24;
        private const int _hourLabelFontSize = 8;
        private const int _dateLabelFontSize = 10;
        
        private LovroLogServiceClient serviceClient;
        private DateTime originalStartDate;

        public SleepChartForm()
        {
            InitializeComponent();
        }
        
        public SleepChartForm(LovroLogServiceClient serviceClient, DateTime originalStartDate)
            : this()
        {
            this.serviceClient = serviceClient;
            this.originalStartDate = originalStartDate;
            this.GoToDate = null;
        }

        public DateTime StartDateSelected { get { return StartDatePicker.Value.Date; } }
        
        public DateTime? GoToDate { get; set; }

        private int NumberOfDays 
        { 
            get 
            {
                try
                {
                    return (int)numberOfDaysSpinButton.Value;
                }
                catch
                {
                    numberOfDaysSpinButton.Value = _defaultNumberOfDays;
                    return _defaultNumberOfDays;
                }
            } 
        }

        private void SleepChartForm_Load(object sender, EventArgs e)
        {
            StartDatePicker.Value = originalStartDate.AddDays(-1 * NumberOfDays + 1);
        }

        private void DrawChart()
        {
            if (serviceClient == null)
                return;

            using (var graphics = this.CreateGraphics())
            {
                graphics.Clear(this.BackColor);
            }

            List<LovroBaseEvent> eventsList = serviceClient.GetBaseEvents()
                .Where(item =>
                    (item.Type == LovroEventType.FellAsleep || item.Type == LovroEventType.WokeUp) &&
                    (item.Time.Date >= StartDateSelected && item.Time.Date <= StartDateSelected.AddDays(NumberOfDays)))
                .OrderByDescending(item => item.Time)
                .OrderBy(item => item.Time)
                .ToList();

            List<DateTime> napStartTimes = new List<DateTime>();
            List<DateTime> napEndTimes = new List<DateTime>();

            // uz pretpostavku da su dobro posloženi, tj. nema više "Zaspao sam" ili "Probudio sam se" zaredom
            int startIndex = eventsList.FindIndex(item => item.Type == LovroEventType.FellAsleep);
            int endIndex = eventsList.FindLastIndex(item => item.Type == LovroEventType.WokeUp);

            if (startIndex < 0 || endIndex < 0)
                return;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (((i - startIndex) % 2) == 0) // fell asleep
                    napStartTimes.Add(eventsList[i].Time);
                else
                    napEndTimes.Add(eventsList[i].Time);
            }

            DrawBase(NumberOfDays, StartDateSelected, napStartTimes, napEndTimes);
            for (int i = 0; i < NumberOfDays; i++)
            {
                DrawDay(i, NumberOfDays, StartDateSelected.AddDays(i), napStartTimes, napEndTimes);
            }
        }

        private void DrawBase(int totalDays, DateTime date, List<DateTime> napStartTimes, List<DateTime> napEndTimes)
        {
            using (var graphics = this.CreateGraphics())
            {
                int totalHeight = 0;

                Rectangle dayBackgroundRectangle;
                Pen dayBackgroundPen = new Pen(Color.LightGray, 5); 

                for (int i = 0; i < totalDays; i++)
                {
                    try
                    {
                        int dayWidth = this.Size.Width - _xOffset;
                        int dayHeight = (this.Size.Height / totalDays) / 2;

                        #region Drawing time grid

                        Pen timeGridPen = new Pen(Color.Black, 1);
                        Rectangle timeGridRectangle;

                        for (double j = 0; j <= _hoursInDay; j += 2)
                        {
                            timeGridRectangle = new Rectangle(_xBigOffset + (int)((j / _hoursInDay) * dayWidth), _yOffset, 1, _rowHeight * totalDays);
                            graphics.DrawLine(timeGridPen, timeGridRectangle.Location, new Point(timeGridRectangle.X, timeGridRectangle.Y + timeGridRectangle.Height));
                        }

                        #endregion

                        #region Drawing hour labels

                        Font hourFont = new Font(FontFamily.GenericMonospace, _hourLabelFontSize);
                        for (int j = 0; j <= _hoursInDay; j += 2)
                        {
                            graphics.DrawString(j.ToString().PadLeft(2, '0'), hourFont, Brushes.Black, new PointF(_xBigOffset + (int)(dayWidth * (((double)j) / _hoursInDay)), _yOffset + 5));
                        }

                        #endregion

                        #region Drawing day "gray" rectangles w/date labels

                        graphics.DrawString(date.AddDays(i).ToShortDateString(), new Font(FontFamily.GenericMonospace, _dateLabelFontSize), Brushes.Black, new PointF(5, i * _rowHeight + 5 + 10 + _yOffset));
                        dayBackgroundRectangle = new Rectangle(_xBigOffset, i * _rowHeight + 10 + 10 + _yOffset, dayWidth, 5); // !!!
                        graphics.DrawRectangle(dayBackgroundPen, dayBackgroundRectangle);

                        #endregion

                        totalHeight = dayBackgroundRectangle.Y + dayBackgroundRectangle.Height;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Samo da vidim: {0}", ex.Message);
                    }
                }

                totalHeight += _yBottomPadding;
                this.Height = totalHeight;
                this.MinimumSize = new Size(this.MinimumSize.Width, totalHeight);
                this.MaximumSize = new Size(int.MaxValue, totalHeight);
            }
        }

        private void DrawDay(int i, int totalDays, DateTime date, List<DateTime> napStartTimes, List<DateTime> napEndTimes)
        {
            using (var graphics = this.CreateGraphics())
            {
                try
                {
                    int dayWidth = this.Size.Width - _xOffset;
                    int dayHeight = (this.Size.Height / totalDays) / 2;

                    #region Drawing naps
                    List<DateTime> napStartsOnDate = napStartTimes.Where(item => item.Date == date).ToList();
                    List<DateTime> napEndsOnDate = napEndTimes.Where(item => item.Date == date).ToList();

                    if (napStartsOnDate.FirstOrDefault() > napEndsOnDate.FirstOrDefault())
                    {
                        napStartsOnDate.Add(date.Date); // midnight of current day
                        napStartsOnDate.Sort();
                    }

                    if (napEndsOnDate.LastOrDefault() < napStartsOnDate.LastOrDefault())
                    {
                        napEndsOnDate.Add(date.Date.AddDays(1)); // midnight of next day
                        napEndsOnDate.Sort();
                    }
                    
                    if (napStartsOnDate.Count != napEndsOnDate.Count)
                        throw new InvalidOperationException("Wtf man!");

                    Rectangle napRect;
                    Pen napPen = new Pen(Color.CornflowerBlue, 5);
                        
                    for (int j = 0; j < napStartsOnDate.Count; j++)
                    {
                        double ratioOfNapInDay = (napEndsOnDate[j] - napStartsOnDate[j]).TotalHours / _hoursInDay;
                        double ratioOfDayElapsedBeforeNap = (napStartsOnDate[j] - date).TotalHours / _hoursInDay;

                        napRect = new Rectangle(Convert.ToInt32(dayWidth * ratioOfDayElapsedBeforeNap) + _xBigOffset, i * _rowHeight + 20 + _yOffset, Convert.ToInt32(dayWidth * ratioOfNapInDay), 5); // !!!
                        graphics.DrawRectangle(napPen, napRect);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Samo da vidim: {0}", ex.Message);
                }
            }
        }

        private void SleepChartForm_Paint(object sender, PaintEventArgs e)
        {
            DrawChart();
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            //DrawChart(); // ???
        }

        private void goBackwardButton_Click(object sender, EventArgs e)
        {
            StartDatePicker.Value = StartDateSelected.AddDays(-1 * NumberOfDays);
        }

        private void goForwardButton_Click(object sender, EventArgs e)
        {
            StartDatePicker.Value = StartDateSelected.AddDays(NumberOfDays);
        }

        private void numberOfDaysSpinButton_ValueChanged(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void SleepChartForm_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GoToDate = StartDateSelected.AddDays((int)(((e as MouseEventArgs).Y - _yOffset) / _rowHeight));
            }
            catch
            {
                GoToDate = null;
            }
            finally
            {
                Close();
            }
        }
    }   
}
