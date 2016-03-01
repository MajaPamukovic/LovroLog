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
            this.numberOfDaysSpinButton = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfDaysSpinButton)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(66, 9);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(94, 20);
            this.StartDatePicker.TabIndex = 0;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // StartDatePickerLabel
            // 
            this.StartDatePickerLabel.AutoSize = true;
            this.StartDatePickerLabel.Location = new System.Drawing.Point(2, 12);
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
            this.goBackwardButton.Text = "<";
            this.goBackwardButton.UseVisualStyleBackColor = true;
            this.goBackwardButton.Click += new System.EventHandler(this.goBackwardButton_Click);
            // 
            // goForwardButton
            // 
            this.goForwardButton.Location = new System.Drawing.Point(278, 7);
            this.goForwardButton.Name = "goForwardButton";
            this.goForwardButton.Size = new System.Drawing.Size(44, 23);
            this.goForwardButton.TabIndex = 3;
            this.goForwardButton.Text = ">";
            this.goForwardButton.UseVisualStyleBackColor = true;
            this.goForwardButton.Click += new System.EventHandler(this.goForwardButton_Click);
            // 
            // numberOfDaysSpinButton
            // 
            this.numberOfDaysSpinButton.Location = new System.Drawing.Point(167, 9);
            this.numberOfDaysSpinButton.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfDaysSpinButton.Name = "numberOfDaysSpinButton";
            this.numberOfDaysSpinButton.Size = new System.Drawing.Size(44, 20);
            this.numberOfDaysSpinButton.TabIndex = 4;
            this.numberOfDaysSpinButton.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numberOfDaysSpinButton.ValueChanged += new System.EventHandler(this.numberOfDaysSpinButton_ValueChanged);
            // 
            // SleepChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 262);
            this.Controls.Add(this.numberOfDaysSpinButton);
            this.Controls.Add(this.goForwardButton);
            this.Controls.Add(this.goBackwardButton);
            this.Controls.Add(this.StartDatePickerLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Name = "SleepChartForm";
            this.Text = "Grafički prikaz spavanja";
            this.Load += new System.EventHandler(this.SleepChartForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SleepChartForm_Paint);
            this.DoubleClick += new System.EventHandler(this.SleepChartForm_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.numberOfDaysSpinButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label StartDatePickerLabel;
        private System.Windows.Forms.Button goBackwardButton;
        private System.Windows.Forms.Button goForwardButton;
        private System.Windows.Forms.NumericUpDown numberOfDaysSpinButton;
    }
}