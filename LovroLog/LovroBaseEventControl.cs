using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LovroLog
{
    public partial class LovroBaseEventControl : UserControl
    {
        public LovroBaseEventControl()
        {
            InitializeComponent();
        }

        public string EnteredNote 
        { 
            get 
            {
                return this.noteTextBox.Text;    
            }
            set
            {
                this.noteTextBox.Text = value;
            }
        }

        public DateTime SelectedDateTime
        {
            get
            {
                return this.eventTimePicker.Value;
            }
            set
            {
                this.eventTimePicker.Value = value;
            }
        }
    }
}
