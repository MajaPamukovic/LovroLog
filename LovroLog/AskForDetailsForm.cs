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
    public partial class AskForDetailsForm : Form
    {
        public AskForDetailsForm()
        {
            InitializeComponent();
        }

        public DateTime EnteredTime { get; set; }

        public string EnteredNote { get; set; }

        private void OkNoteBtn_Click(object sender, EventArgs e)
        {
            this.EnteredNote = this.noteTextBox.Text;
            this.EnteredTime = this.eventTimePicker.Value;
            this.Close();
        }

        private void CancelNoteBtn_Click(object sender, EventArgs e)
        {
            this.EnteredNote = "";
            this.EnteredTime = DateTime.Now;
            this.Close();
        }

        private void AskForDetailsForm_Load(object sender, EventArgs e)
        {
            EnteredTime = DateTime.Now;
        }
    }
}
