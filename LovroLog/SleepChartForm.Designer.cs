namespace LovroLog
{
    partial class SleepChartForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatePickerLabel = new System.Windows.Forms.Label();
            this.goBackwardButton = new System.Windows.Forms.Button();
            this.goForwardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(81, 9);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(130, 20);
            this.StartDatePicker.TabIndex = 0;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // StartDatePickerLabel
            // 
            this.StartDatePickerLabel.AutoSize = true;
            this.StartDatePickerLabel.Location = new System.Drawing.Point(13, 12);
            this.StartDatePickerLabel.Name = "StartDatePickerLabel";
            this.StartDatePickerLabel.Size = new System.Drawing.Size(62, 13);
            this.StartDatePickerLabel.TabIndex = 1;
            this.StartDatePickerLabel.Text = "Od datuma:";
            // 
            // goBackwardButton
            // 
            this.goBackwardButton.Location = new System.Drawing.Point(228, 7);
            this.goBackwardButton.Name = "goBackwardButton";
            this.goBackwardButton.Size = new System.Drawing.Size(44, 23);
            this.goBackwardButton.TabIndex = 2;
            this.goBackwardButton.Text = "< 7";
            this.goBackwardButton.UseVisualStyleBackColor = true;
            this.goBackwardButton.Click += new System.EventHandler(this.goBackwardButton_Click);
            // 
            // goForwardButton
            // 
            this.goForwardButton.Location = new System.Drawing.Point(278, 7);
            this.goForwardButton.Name = "goForwardButton";
            this.goForwardButton.Size = new System.Drawing.Size(44, 23);
            this.goForwardButton.TabIndex = 3;
            this.goForwardButton.Text = "7 >";
            this.goForwardButton.UseVisualStyleBackColor = true;
            this.goForwardButton.Click += new System.EventHandler(this.goForwardButton_Click);
            // 
            // SleepChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 262);
            this.Controls.Add(this.goForwardButton);
            this.Controls.Add(this.goBackwardButton);
            this.Controls.Add(this.StartDatePickerLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Name = "SleepChartForm";
            this.Text = "Grafički prikaz spavanja";
            this.Load += new System.EventHandler(this.SleepChartForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SleepChartForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label StartDatePickerLabel;
        private System.Windows.Forms.Button goBackwardButton;
        private System.Windows.Forms.Button goForwardButton;
    }
}