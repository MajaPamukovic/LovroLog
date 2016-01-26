namespace LovroLog
{
    partial class LovroBaseEventControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noteLabel = new System.Windows.Forms.Label();
            this.eventTimeLabel = new System.Windows.Forms.Label();
            this.eventTimePicker = new System.Windows.Forms.DateTimePicker();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(1, 61);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(75, 13);
            this.noteLabel.TabIndex = 9;
            this.noteLabel.Text = "Unesi bilješku:";
            // 
            // eventTimeLabel
            // 
            this.eventTimeLabel.AutoSize = true;
            this.eventTimeLabel.Location = new System.Drawing.Point(3, 0);
            this.eventTimeLabel.Name = "eventTimeLabel";
            this.eventTimeLabel.Size = new System.Drawing.Size(131, 13);
            this.eventTimeLabel.TabIndex = 8;
            this.eventTimeLabel.Text = "Odaberi vrijeme događaja:";
            // 
            // eventTimePicker
            // 
            this.eventTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.eventTimePicker.Location = new System.Drawing.Point(3, 19);
            this.eventTimePicker.Name = "eventTimePicker";
            this.eventTimePicker.Size = new System.Drawing.Size(200, 20);
            this.eventTimePicker.TabIndex = 7;
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(1, 82);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(259, 237);
            this.noteTextBox.TabIndex = 6;
            // 
            // LovroBaseEventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.eventTimeLabel);
            this.Controls.Add(this.eventTimePicker);
            this.Controls.Add(this.noteTextBox);
            this.Name = "LovroBaseEventControl";
            this.Size = new System.Drawing.Size(262, 321);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Label eventTimeLabel;
        private System.Windows.Forms.DateTimePicker eventTimePicker;
        private System.Windows.Forms.TextBox noteTextBox;

    }
}
