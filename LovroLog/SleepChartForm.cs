using LovroLog.Database;
using LovroLog.Enums;
using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LovroLog
{
    public partial class SleepChartForm : Form
    {
        private string connectionString;
        private bool useXMLDatabase;
        private const int numberOfDays = 7; // jednostavnosti radi; TODO konfigurabilnost!!!
        private const int yOffset = 40;

        public SleepChartForm()
        {
            InitializeComponent();
        }

        public SleepChartForm(string connectionString, bool useXMLDatabase)
            : this()
        {
            this.connectionString = connectionString;
            this.useXMLDatabase = useXMLDatabase;
            this.GoToDate = null;
        }

        public DateTime StartDateSelected { get { return StartDatePicker.Value.Date; } }
        
        //TODO: set date property on canvas click!!!
        public DateTime? GoToDate { get; set; }

        private void SleepChartForm_Load(object sender, EventArgs e)
        {
            StartDatePicker.Value = DateTime.Now.Date.AddDays(-1 * numberOfDays);
        }

        private void DrawChart()
        {
            if (string.IsNullOrEmpty(connectionString))
                return;

            using (var dataAccess = new DataAccessWrapper(connectionString, useXMLDatabase))
            {
                using (var graphics = this.CreateGraphics())
                {
                    graphics.Clear(Color.White);
                }

                List<LovroBaseEvent> eventsList = dataAccess.GetBaseEvents()
                    .Where(item => 
                        (item.Type == LovroEventType.FellAsleep || item.Type == LovroEventType.WokeUp) &&
                        (item.Time.Date >= StartDateSelected && item.Time.Date <= StartDateSelected.AddDays(numberOfDays)))
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

                DateTime startDate = napStartTimes.FirstOrDefault().Date;
                DateTime endDate = napEndTimes.LastOrDefault().Date;
                int daysElapsed = (int)(endDate - startDate).TotalDays;

                DrawBase(daysElapsed, startDate, napStartTimes, napEndTimes);
                for (int i = 0; i < daysElapsed; i++)
                {
                    DrawDay(i, daysElapsed, startDate.AddDays(i), napStartTimes, napEndTimes);
                }
            }
        }

        private void DrawBase(int totalDays, DateTime date, List<DateTime> napStartTimes, List<DateTime> napEndTimes)
        {
            using (var graphics = this.CreateGraphics())
            {
                for (int i = 0; i < totalDays; i++)
                {
                    try
                    {
                        int dayWidth = this.Size.Width - 150;
                        int dayHeight = (this.Size.Height / totalDays) / 2;

                        #region Drawing time grid

                        Pen timeGridPen = new Pen(Color.Black, 1);
                        Rectangle timeGridRectangle;

                        for (double j = 0; j <= 24; j += 2)
                        {
                            timeGridRectangle = new Rectangle(100 + (int)((j / 24) * dayWidth), yOffset, 1, this.Size.Height);
                            graphics.DrawLine(timeGridPen, timeGridRectangle.Location, new Point(timeGridRectangle.X, timeGridRectangle.Y + timeGridRectangle.Height)); //timeGridRectangle.Location.Offset(timeGridRectangle.Width, 0));
                        }

                        #endregion

                        Font hourFont = new Font(FontFamily.GenericMonospace, 8);
                        for (int j = 0; j <= 24; j += 2)
                        {
                            graphics.DrawString(j.ToString().PadLeft(2, '0'), hourFont, Brushes.Black, new PointF(100 + (int)(dayWidth * ((j + 0.0) / 24)), yOffset + 5));
                        }

                        #region Drawing basic/day rectangle w/date label

                        graphics.DrawString(date.AddDays(i).ToShortDateString(), new Font(FontFamily.GenericMonospace, 10), Brushes.Black, new PointF(5, i * 30 + 5 + 10 + yOffset));
                        Rectangle rectangle = new Rectangle(100, i * 30 + 10 + 10 + yOffset, dayWidth, 5); // !!!
                        Pen basicPen = new Pen(Color.DarkGray, 5);
                        graphics.DrawRectangle(basicPen, rectangle);

                        #endregion

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Samo da vidim");
                    }
                }
            }
        }

        private void DrawDay(int i, int totalDays, DateTime date, List<DateTime> napStartTimes, List<DateTime> napEndTimes)
        {
            using (var graphics = this.CreateGraphics())
            {
                try
                {
                    int dayWidth = this.Size.Width - 150;
                    int dayHeight = (this.Size.Height / totalDays) / 2;

                    #region Drawing naps
                    List<DateTime> napStartsOnDate = napStartTimes.Where(item => item.Date == date).ToList();
                    List<DateTime> napEndsOnDate = napEndTimes.Where(item => item.Date == date).ToList();

                    if (napStartsOnDate.FirstOrDefault() > napEndsOnDate.FirstOrDefault())
                    {
                        napStartsOnDate.Add(new DateTime(date.Year, date.Month, date.Day));
                        napStartsOnDate.Sort();
                    }

                    if (napEndsOnDate.LastOrDefault() < napStartsOnDate.LastOrDefault())
                    {
                        napEndsOnDate.Add(date.AddDays(1));
                        napEndsOnDate.Sort();
                    }
                    
                    if (napStartsOnDate.Count != napEndsOnDate.Count)
                        throw new InvalidOperationException("Wtf man!");

                    for (int j = 0; j < napStartsOnDate.Count; j++)
                    {
                        double ratioOfNapInDay = (napEndsOnDate[j] - napStartsOnDate[j]).TotalHours / 24;
                        double ratioOfDayElapsedBeforeNap = (napStartsOnDate[j] - date).TotalHours / 24;

                        Rectangle napRect = new Rectangle(Convert.ToInt32(dayWidth * ratioOfDayElapsedBeforeNap) + 100, i * 30 + 20 + yOffset, Convert.ToInt32(dayWidth * ratioOfNapInDay), 5); // !!!
                        Pen napPen = new Pen(Color.Green, 5);
                        graphics.DrawRectangle(napPen, napRect);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Samo da vidim");
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
            StartDatePicker.Value = StartDateSelected.AddDays(-1 * numberOfDays);
        }

        private void goForwardButton_Click(object sender, EventArgs e)
        {
            StartDatePicker.Value = StartDateSelected.AddDays(numberOfDays);
        }
    }   
}
