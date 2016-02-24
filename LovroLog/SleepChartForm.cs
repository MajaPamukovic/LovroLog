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

        public SleepChartForm()
        {
            InitializeComponent();
        }

        public SleepChartForm(string connectionString, bool useXMLDatabase)
            : this()
        {
            this.connectionString = connectionString;
            this.useXMLDatabase = useXMLDatabase;
            this.SelectedDate = null;
        }
        
        //TODO: set date property on canvas click!!!
        public DateTime? SelectedDate { get; set; }

        private void SleepChartForm_Load(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            if (string.IsNullOrEmpty(connectionString))
                return;

            using (var dataAccess = new DataAccessWrapper(connectionString, useXMLDatabase))
            {
                List<LovroBaseEvent> eventsList = dataAccess.GetBaseEvents()
                    .Where(item => item.Type == LovroEventType.FellAsleep || item.Type == LovroEventType.WokeUp)
                    .OrderByDescending(item => item.Time)
                    .Take(100)
                    .OrderBy(item => item.Time)
                    .ToList();

                List<DateTime> napStartTimes = new List<DateTime>();
                List<DateTime> napEndTimes = new List<DateTime>();

                // uz pretpostavku da su dobro posloženi, tj. nema više "Zaspao sam" ili "Probudio sam se" zaredom
                int startIndex = eventsList.FindIndex(item => item.Type == LovroEventType.FellAsleep);
                int endIndex = eventsList.FindLastIndex(item => item.Type == LovroEventType.WokeUp);

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

                for (int i = 0; i < daysElapsed; i++)
                {
                    DrawDay(i, daysElapsed, startDate.AddDays(i), napStartTimes, napEndTimes);
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

                    //draw time grid
                    Rectangle timeGridRectangle = new Rectangle(100, 5, dayWidth, 1);
                    Pen timeGridPen = new Pen(Color.Black, 1);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100, 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((2.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((4.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((6.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((8.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((10.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((12.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((14.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((16.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((18.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((20.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + (int)((22.0 / 24) * dayWidth), 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    timeGridRectangle = new Rectangle(100 + dayWidth, 2, 1, this.Size.Height);
                    graphics.DrawRectangle(timeGridPen, timeGridRectangle);
                    graphics.DrawString("00", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100, 5));
                    graphics.DrawString("02", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (2.0 / 24)), 5));
                    graphics.DrawString("04", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (4.0 / 24)), 5));
                    graphics.DrawString("06", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (6.0 / 24)), 5));
                    graphics.DrawString("08", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (8.0 / 24)), 5));
                    graphics.DrawString("10", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (10.0 / 24)), 5));
                    graphics.DrawString("12", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (12.0 / 24)), 5));
                    graphics.DrawString("14", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (14.0 / 24)), 5));
                    graphics.DrawString("16", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (16.0 / 24)), 5));
                    graphics.DrawString("18", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (18.0 / 24)), 5));
                    graphics.DrawString("20", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (20.0 / 24)), 5));
                    graphics.DrawString("22", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + (int)(dayWidth * (22.0 / 24)), 5));
                    graphics.DrawString("24", new Font(FontFamily.GenericMonospace, 8), Brushes.Black, new PointF(100 + dayWidth, 5));

                    // draw basic/day rectangle w/date label
                    graphics.DrawString(date.ToShortDateString(), new Font(FontFamily.GenericMonospace, 10), Brushes.Black, new PointF(5, i * 30 + 5 + 10));
                    Rectangle rectangle = new Rectangle(100, i * 30 + 10 + 10, dayWidth, 5); // !!!
                    Pen basicPen = new Pen(Color.DarkGray, 5);
                    graphics.DrawRectangle(basicPen, rectangle);

                    // TODO draw naps
                    List<DateTime> napStartsOnDate = napStartTimes.Where(item => item.Date == date).ToList();
                    List<DateTime> napEndsOnDate = napEndTimes.Where(item => item.Date == date).ToList();

                    if (napStartsOnDate.FirstOrDefault() > napEndsOnDate.FirstOrDefault())
                    {
                        napStartsOnDate.Add(new DateTime(date.Year, date.Month, date.Day));
                        napStartsOnDate.Sort();
                    }

                    if (napEndsOnDate.LastOrDefault() < napStartsOnDate.LastOrDefault())
                    {
                        napEndsOnDate.Add(new DateTime(date.Year, date.Month, date.Day + 1));
                        napEndsOnDate.Sort();
                    }
                    
                    if (napStartsOnDate.Count != napEndsOnDate.Count)
                        throw new InvalidOperationException("Wtf man!");

                    for (int j = 0; j < napStartsOnDate.Count; j++)
                    {
                        double ratioOfNapInDay = (napEndsOnDate[j] - napStartsOnDate[j]).TotalHours / 24;
                        double ratioOfDayElapsedBeforeNap = (napStartsOnDate[j] - date).TotalHours / 24;

                        Rectangle napRect = new Rectangle(Convert.ToInt32(dayWidth * ratioOfDayElapsedBeforeNap) + 100, i * 30 + 20, Convert.ToInt32(dayWidth * ratioOfNapInDay), 5); // !!!
                        Pen napPen = new Pen(Color.Green, 5);
                        graphics.DrawRectangle(napPen, napRect);
                    }
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
    }   
}
