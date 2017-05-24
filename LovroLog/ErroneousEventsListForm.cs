using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LovroLog
{
    public partial class ErroneousEventsListForm : Form
    {
        private Dictionary<int, DateTime> erroneousEvents;
        public int? SelectedItemID { get; set; }
        public DateTime? SelectedDate { get; set; }

        public ErroneousEventsListForm()
        {
            InitializeComponent();

            SelectedItemID = null;
            SelectedDate = null;

            erroneousEventsListView.View = View.Details;
            erroneousEventsListView.GridLines = false;
            erroneousEventsListView.Scrollable = true;

            erroneousEventsListView.FullRowSelect = true;
            erroneousEventsListView.MultiSelect = false;
            erroneousEventsListView.Columns.Add("Datum");
        }

        public ErroneousEventsListForm(Dictionary<int, DateTime> erroneousEvents)
            : this()
        {
            this.erroneousEvents = erroneousEvents;
        }

        private void ErroneousEventsListForm_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            foreach (KeyValuePair<int, DateTime> item in erroneousEvents)
            {
                //erroneousEventsListView.Items.Add(item.Key.ToString(), item.Value.ToString(), 0);

                ListViewItem viewItem = new ListViewItem(item.Value.ToString());
                viewItem.Tag = item.Key;

                erroneousEventsListView.Items.Add(viewItem);
            }

            erroneousEventsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //Refresh();
        }

        private void erroneousEventsListView_DoubleClick(object sender, EventArgs e)
        {
            //TODO!!! ugasi formu i selektiraj taj datum u glavnoj formi
            //Console.WriteLine(erroneousEventsListView.SelectedItems[0].Tag);

            if (erroneousEventsListView.SelectedItems.Count > 0 && erroneousEventsListView.SelectedItems[0] != null)
            {
                SelectedItemID = (int)erroneousEventsListView.SelectedItems[0].Tag;
                SelectedDate = DateTime.Parse(erroneousEventsListView.SelectedItems[0].Text);
            }
            else
            {
                SelectedItemID = null;
                SelectedDate = null;
            }

            this.Close();
        }
    }
}
