using System;
using System.Windows.Forms;

namespace LovroLog
{
    public partial class ShowWarningForm : Form
    {
        public ShowWarningForm()
        {
            InitializeComponent();
        }

        private void dismissWarningButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
