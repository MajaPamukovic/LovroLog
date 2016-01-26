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
    public partial class LovroEventEditForm : Form
    {
        public LovroEventEditForm()
        {
            InitializeComponent();
        }

        public LovroBaseEvent EventInEditing { get; set; }

        private void LovroEventEditForm_Load(object sender, EventArgs e)
        {
            lovroBaseEventControl1.EnteredNote = this.EventInEditing.Note;
            lovroBaseEventControl1.SelectedDateTime = this.EventInEditing.Time;

            if (EventInEditing.Type == LovroEventType.DiaperChanged)
            {
                diaperStatusCheckBox.Visible = true;
                diaperStatusCheckBox.Checked = ((this.EventInEditing as LovroDiaperChangedEvent).Status == LovroDiaperStatus.Soiled);
            }
            else
                diaperStatusCheckBox.Visible = false;
        }

        private void OkNoteBtn_Click(object sender, EventArgs e)
        {
            this.EventInEditing.Note = lovroBaseEventControl1.EnteredNote;
            this.EventInEditing.Time = lovroBaseEventControl1.SelectedDateTime;

            if (EventInEditing.Type == LovroEventType.DiaperChanged)
                (this.EventInEditing as LovroDiaperChangedEvent).Status = diaperStatusCheckBox.Checked ? LovroDiaperStatus.Soiled : LovroDiaperStatus.Pissed;

            this.Close();
        }

        
    }
}
