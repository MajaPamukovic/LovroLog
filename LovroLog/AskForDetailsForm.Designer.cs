namespace LovroLog
{
    partial class AskForDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AskForDetailsForm));
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.OkNoteBtn = new System.Windows.Forms.Button();
            this.CancelNoteBtn = new System.Windows.Forms.Button();
            this.eventTimePicker = new System.Windows.Forms.DateTimePicker();
            this.eventTimeLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(11, 90);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(259, 237);
            this.noteTextBox.TabIndex = 0;
            // 
            // OkNoteBtn
            // 
            this.OkNoteBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkNoteBtn.Location = new System.Drawing.Point(35, 348);
            this.OkNoteBtn.Name = "OkNoteBtn";
            this.OkNoteBtn.Size = new System.Drawing.Size(75, 23);
            this.OkNoteBtn.TabIndex = 1;
            this.OkNoteBtn.Text = "OK";
            this.OkNoteBtn.UseVisualStyleBackColor = true;
            this.OkNoteBtn.Click += new System.EventHandler(this.OkNoteBtn_Click);
            // 
            // CancelNoteBtn
            // 
            this.CancelNoteBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelNoteBtn.Location = new System.Drawing.Point(141, 348);
            this.CancelNoteBtn.Name = "CancelNoteBtn";
            this.CancelNoteBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelNoteBtn.TabIndex = 2;
            this.CancelNoteBtn.Text = "Cancel";
            this.CancelNoteBtn.UseVisualStyleBackColor = true;
            this.CancelNoteBtn.Click += new System.EventHandler(this.CancelNoteBtn_Click);
            // 
            // eventTimePicker
            // 
            this.eventTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.eventTimePicker.Location = new System.Drawing.Point(13, 27);
            this.eventTimePicker.Name = "eventTimePicker";
            this.eventTimePicker.Size = new System.Drawing.Size(200, 20);
            this.eventTimePicker.TabIndex = 3;
            // 
            // eventTimeLabel
            // 
            this.eventTimeLabel.AutoSize = true;
            this.eventTimeLabel.Location = new System.Drawing.Point(13, 8);
            this.eventTimeLabel.Name = "eventTimeLabel";
            this.eventTimeLabel.Size = new System.Drawing.Size(131, 13);
            this.eventTimeLabel.TabIndex = 4;
            this.eventTimeLabel.Text = "Odaberi vrijeme događaja:";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(11, 69);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(75, 13);
            this.noteLabel.TabIndex = 5;
            this.noteLabel.Text = "Unesi bilješku:";
            // 
            // AskForDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 387);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.eventTimeLabel);
            this.Controls.Add(this.eventTimePicker);
            this.Controls.Add(this.CancelNoteBtn);
            this.Controls.Add(this.OkNoteBtn);
            this.Controls.Add(this.noteTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AskForDetailsForm";
            this.Text = "Uredi detalje";
            this.Load += new System.EventHandler(this.AskForDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Button OkNoteBtn;
        private System.Windows.Forms.Button CancelNoteBtn;
        private System.Windows.Forms.DateTimePicker eventTimePicker;
        private System.Windows.Forms.Label eventTimeLabel;
        private System.Windows.Forms.Label noteLabel;

    }
}