namespace LovroLog
{
    partial class ErroneousEventsListForm
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
            this.erroneousEventsListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // erroneousEventsListView
            // 
            this.erroneousEventsListView.Location = new System.Drawing.Point(13, 13);
            this.erroneousEventsListView.Name = "erroneousEventsListView";
            this.erroneousEventsListView.Size = new System.Drawing.Size(259, 237);
            this.erroneousEventsListView.TabIndex = 0;
            this.erroneousEventsListView.UseCompatibleStateImageBehavior = false;
            this.erroneousEventsListView.DoubleClick += new System.EventHandler(this.erroneousEventsListView_DoubleClick);
            // 
            // ErroneousEventsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.erroneousEventsListView);
            this.Name = "ErroneousEventsListForm";
            this.Text = "ErroneousEventsListForm";
            this.Load += new System.EventHandler(this.ErroneousEventsListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView erroneousEventsListView;

    }
}