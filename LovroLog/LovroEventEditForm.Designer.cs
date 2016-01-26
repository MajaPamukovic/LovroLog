namespace LovroLog
{
    partial class LovroEventEditForm
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
            this.lovroBaseEventControl1 = new LovroLog.LovroBaseEventControl();
            this.diaperStatusCheckBox = new System.Windows.Forms.CheckBox();
            this.CancelNoteBtn = new System.Windows.Forms.Button();
            this.OkNoteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lovroBaseEventControl1
            // 
            this.lovroBaseEventControl1.Location = new System.Drawing.Point(12, 12);
            this.lovroBaseEventControl1.Name = "lovroBaseEventControl1";
            this.lovroBaseEventControl1.Size = new System.Drawing.Size(264, 323);
            this.lovroBaseEventControl1.TabIndex = 0;
            // 
            // diaperStatusCheckBox
            // 
            this.diaperStatusCheckBox.AutoSize = true;
            this.diaperStatusCheckBox.Location = new System.Drawing.Point(12, 341);
            this.diaperStatusCheckBox.Name = "diaperStatusCheckBox";
            this.diaperStatusCheckBox.Size = new System.Drawing.Size(140, 17);
            this.diaperStatusCheckBox.TabIndex = 1;
            this.diaperStatusCheckBox.Text = "Pelena je bila pokakana";
            this.diaperStatusCheckBox.UseVisualStyleBackColor = true;
            this.diaperStatusCheckBox.Visible = false;
            // 
            // CancelNoteBtn
            // 
            this.CancelNoteBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelNoteBtn.Location = new System.Drawing.Point(153, 373);
            this.CancelNoteBtn.Name = "CancelNoteBtn";
            this.CancelNoteBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelNoteBtn.TabIndex = 4;
            this.CancelNoteBtn.Text = "Cancel";
            this.CancelNoteBtn.UseVisualStyleBackColor = true;
            // 
            // OkNoteBtn
            // 
            this.OkNoteBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkNoteBtn.Location = new System.Drawing.Point(47, 373);
            this.OkNoteBtn.Name = "OkNoteBtn";
            this.OkNoteBtn.Size = new System.Drawing.Size(75, 23);
            this.OkNoteBtn.TabIndex = 3;
            this.OkNoteBtn.Text = "OK";
            this.OkNoteBtn.UseVisualStyleBackColor = true;
            this.OkNoteBtn.Click += new System.EventHandler(this.OkNoteBtn_Click);
            // 
            // LovroEventEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 418);
            this.Controls.Add(this.CancelNoteBtn);
            this.Controls.Add(this.OkNoteBtn);
            this.Controls.Add(this.diaperStatusCheckBox);
            this.Controls.Add(this.lovroBaseEventControl1);
            this.Name = "LovroEventEditForm";
            this.Text = "Uređivanje unosa";
            this.Load += new System.EventHandler(this.LovroEventEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LovroBaseEventControl lovroBaseEventControl1;
        private System.Windows.Forms.CheckBox diaperStatusCheckBox;
        private System.Windows.Forms.Button CancelNoteBtn;
        private System.Windows.Forms.Button OkNoteBtn;
    }
}