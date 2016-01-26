namespace LovroLog
{
    partial class ShowWarningForm
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
            this.dismissWarningButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dismissWarningButton
            // 
            this.dismissWarningButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.dismissWarningButton.Location = new System.Drawing.Point(111, 45);
            this.dismissWarningButton.Name = "dismissWarningButton";
            this.dismissWarningButton.Size = new System.Drawing.Size(75, 23);
            this.dismissWarningButton.TabIndex = 0;
            this.dismissWarningButton.Text = "Zanemari";
            this.dismissWarningButton.UseVisualStyleBackColor = true;
            this.dismissWarningButton.Click += new System.EventHandler(this.dismissWarningButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.warningLabel.Location = new System.Drawing.Point(12, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(301, 15);
            this.warningLabel.TabIndex = 1;
            this.warningLabel.Text = "Premašen dozvoljeni rok za promjenu pelene!";
            // 
            // ShowWarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 79);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.dismissWarningButton);
            this.Name = "ShowWarningForm";
            this.Text = "Upozorenje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dismissWarningButton;
        private System.Windows.Forms.Label warningLabel;
    }
}