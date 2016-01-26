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
