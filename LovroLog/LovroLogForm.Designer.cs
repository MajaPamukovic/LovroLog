namespace LovroLog
{
    partial class LovroLogForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LovroLogForm));
            this.askForDetailsCheckBox = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.stopwatchDiaperLabel = new System.Windows.Forms.Label();
            this.stopwatchFoodLabel = new System.Windows.Forms.Label();
            this.stopwatchSleepLabel = new System.Windows.Forms.Label();
            this.filterByTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.filterByTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.filterByTypeComboBox = new System.Windows.Forms.ComboBox();
            this.dateGroupBox = new System.Windows.Forms.GroupBox();
            this.displayedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.goBackTimeButton = new System.Windows.Forms.Button();
            this.goForwardTimeButton = new System.Windows.Forms.Button();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.RefreshLogViewButton = new System.Windows.Forms.Button();
            this.filterByDateCheckBox = new System.Windows.Forms.CheckBox();
            this.rightSidePanel = new System.Windows.Forms.Panel();
            this.logListView = new System.Windows.Forms.ListView();
            this.frogALogLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SilentModeCheckBox = new System.Windows.Forms.CheckBox();
            this.ToggleSoundButton = new System.Windows.Forms.Button();
            this.AnalyzeDataButton = new System.Windows.Forms.Button();
            this.viewSleepChartButton = new System.Windows.Forms.Button();
            this.otherEventButton = new System.Windows.Forms.Button();
            this.toggleLogPBoxBtn = new System.Windows.Forms.PictureBox();
            this.stopwatchSleepPictureBox = new System.Windows.Forms.PictureBox();
            this.stopwatchFoodPictureBox = new System.Windows.Forms.PictureBox();
            this.stopwatchDiaperPictureBox = new System.Windows.Forms.PictureBox();
            this.poopyDiaperChangedButton = new System.Windows.Forms.Button();
            this.bathedButton = new System.Windows.Forms.Button();
            this.wetDiaperChangedButton = new System.Windows.Forms.Button();
            this.wokeUpButton = new System.Windows.Forms.Button();
            this.fellAsleep = new System.Windows.Forms.Button();
            this.foodButton = new System.Windows.Forms.Button();
            this.shitButton = new System.Windows.Forms.Button();
            this.editEventButton = new System.Windows.Forms.Button();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.goToTodayButton = new System.Windows.Forms.Button();
            this.filterByTypeGroupBox.SuspendLayout();
            this.dateGroupBox.SuspendLayout();
            this.rightSidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleLogPBoxBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopwatchSleepPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopwatchFoodPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopwatchDiaperPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // askForDetailsCheckBox
            // 
            this.askForDetailsCheckBox.AutoSize = true;
            this.askForDetailsCheckBox.Location = new System.Drawing.Point(367, 145);
            this.askForDetailsCheckBox.Name = "askForDetailsCheckBox";
            this.askForDetailsCheckBox.Size = new System.Drawing.Size(137, 17);
            this.askForDetailsCheckBox.TabIndex = 8;
            this.askForDetailsCheckBox.Text = "Uredi detalje (Ctrl+click)";
            this.askForDetailsCheckBox.UseVisualStyleBackColor = true;
            this.askForDetailsCheckBox.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Bath-20px.png");
            this.imageList1.Images.SetKeyName(1, "diaper-poopy-20.png");
            this.imageList1.Images.SetKeyName(2, "diaper-wet-20.png");
            this.imageList1.Images.SetKeyName(3, "food-20px.png");
            this.imageList1.Images.SetKeyName(4, "shit-20.png");
            this.imageList1.Images.SetKeyName(5, "sleep-transparent-20px.png");
            this.imageList1.Images.SetKeyName(6, "wakeUp-transparent-20px.png");
            this.imageList1.Images.SetKeyName(7, "ellipsis-20px.png");
            // 
            // stopwatchDiaperLabel
            // 
            this.stopwatchDiaperLabel.AutoSize = true;
            this.stopwatchDiaperLabel.Font = new System.Drawing.Font("Digital-7 Italic", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopwatchDiaperLabel.Location = new System.Drawing.Point(47, 81);
            this.stopwatchDiaperLabel.Name = "stopwatchDiaperLabel";
            this.stopwatchDiaperLabel.Size = new System.Drawing.Size(131, 38);
            this.stopwatchDiaperLabel.TabIndex = 20;
            this.stopwatchDiaperLabel.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.stopwatchDiaperLabel, "Vrijeme proteklo od posljednje promjene pelena");
            // 
            // stopwatchFoodLabel
            // 
            this.stopwatchFoodLabel.AutoSize = true;
            this.stopwatchFoodLabel.Font = new System.Drawing.Font("Digital-7 Italic", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopwatchFoodLabel.Location = new System.Drawing.Point(217, 81);
            this.stopwatchFoodLabel.Name = "stopwatchFoodLabel";
            this.stopwatchFoodLabel.Size = new System.Drawing.Size(131, 38);
            this.stopwatchFoodLabel.TabIndex = 23;
            this.stopwatchFoodLabel.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.stopwatchFoodLabel, "Vrijeme proteklo od posljednjeg hranjenja");
            // 
            // stopwatchSleepLabel
            // 
            this.stopwatchSleepLabel.AutoSize = true;
            this.stopwatchSleepLabel.Font = new System.Drawing.Font("Digital-7 Italic", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopwatchSleepLabel.Location = new System.Drawing.Point(380, 81);
            this.stopwatchSleepLabel.Name = "stopwatchSleepLabel";
            this.stopwatchSleepLabel.Size = new System.Drawing.Size(131, 38);
            this.stopwatchSleepLabel.TabIndex = 24;
            this.stopwatchSleepLabel.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.stopwatchSleepLabel, "Vrijeme proteklo od posljednjeg spavanja");
            // 
            // filterByTypeCheckBox
            // 
            this.filterByTypeCheckBox.AutoSize = true;
            this.filterByTypeCheckBox.Location = new System.Drawing.Point(225, 11);
            this.filterByTypeCheckBox.Name = "filterByTypeCheckBox";
            this.filterByTypeCheckBox.Size = new System.Drawing.Size(102, 17);
            this.filterByTypeCheckBox.TabIndex = 17;
            this.filterByTypeCheckBox.Text = "Prikaži samo tip:";
            this.filterByTypeCheckBox.UseVisualStyleBackColor = true;
            this.filterByTypeCheckBox.CheckedChanged += new System.EventHandler(this.filterByTypeCheckBox_CheckedChanged);
            // 
            // filterByTypeGroupBox
            // 
            this.filterByTypeGroupBox.Controls.Add(this.filterByTypeComboBox);
            this.filterByTypeGroupBox.Enabled = false;
            this.filterByTypeGroupBox.Location = new System.Drawing.Point(225, 35);
            this.filterByTypeGroupBox.Name = "filterByTypeGroupBox";
            this.filterByTypeGroupBox.Size = new System.Drawing.Size(185, 54);
            this.filterByTypeGroupBox.TabIndex = 18;
            this.filterByTypeGroupBox.TabStop = false;
            this.filterByTypeGroupBox.Text = "Tip";
            // 
            // filterByTypeComboBox
            // 
            this.filterByTypeComboBox.FormattingEnabled = true;
            this.filterByTypeComboBox.Location = new System.Drawing.Point(7, 20);
            this.filterByTypeComboBox.Name = "filterByTypeComboBox";
            this.filterByTypeComboBox.Size = new System.Drawing.Size(167, 21);
            this.filterByTypeComboBox.TabIndex = 0;
            this.filterByTypeComboBox.SelectedValueChanged += new System.EventHandler(this.filterByTypeComboBox_SelectedValueChanged);
            // 
            // dateGroupBox
            // 
            this.dateGroupBox.Controls.Add(this.goToTodayButton);
            this.dateGroupBox.Controls.Add(this.displayedDatePicker);
            this.dateGroupBox.Controls.Add(this.goBackTimeButton);
            this.dateGroupBox.Controls.Add(this.goForwardTimeButton);
            this.dateGroupBox.Location = new System.Drawing.Point(2, 33);
            this.dateGroupBox.Name = "dateGroupBox";
            this.dateGroupBox.Size = new System.Drawing.Size(217, 56);
            this.dateGroupBox.TabIndex = 16;
            this.dateGroupBox.TabStop = false;
            this.dateGroupBox.Text = "Datum";
            // 
            // displayedDatePicker
            // 
            this.displayedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.displayedDatePicker.Location = new System.Drawing.Point(36, 21);
            this.displayedDatePicker.Name = "displayedDatePicker";
            this.displayedDatePicker.Size = new System.Drawing.Size(113, 20);
            this.displayedDatePicker.TabIndex = 12;
            this.displayedDatePicker.ValueChanged += new System.EventHandler(this.displayedDatePicker_ValueChanged);
            // 
            // goBackTimeButton
            // 
            this.goBackTimeButton.Location = new System.Drawing.Point(9, 20);
            this.goBackTimeButton.Name = "goBackTimeButton";
            this.goBackTimeButton.Size = new System.Drawing.Size(24, 23);
            this.goBackTimeButton.TabIndex = 13;
            this.goBackTimeButton.Text = "<";
            this.goBackTimeButton.UseVisualStyleBackColor = true;
            this.goBackTimeButton.Click += new System.EventHandler(this.goBackTimeButton_Click);
            // 
            // goForwardTimeButton
            // 
            this.goForwardTimeButton.Location = new System.Drawing.Point(151, 20);
            this.goForwardTimeButton.Name = "goForwardTimeButton";
            this.goForwardTimeButton.Size = new System.Drawing.Size(24, 23);
            this.goForwardTimeButton.TabIndex = 14;
            this.goForwardTimeButton.Text = ">";
            this.goForwardTimeButton.UseVisualStyleBackColor = true;
            this.goForwardTimeButton.Click += new System.EventHandler(this.goForwardTimeButton_Click);
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(6, 562);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(52, 13);
            this.summaryLabel.TabIndex = 11;
            this.summaryLabel.Text = "Sumarno:";
            // 
            // RefreshLogViewButton
            // 
            this.RefreshLogViewButton.Location = new System.Drawing.Point(463, 557);
            this.RefreshLogViewButton.Name = "RefreshLogViewButton";
            this.RefreshLogViewButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshLogViewButton.TabIndex = 10;
            this.RefreshLogViewButton.Text = "Refresh";
            this.RefreshLogViewButton.UseVisualStyleBackColor = true;
            this.RefreshLogViewButton.Visible = false;
            this.RefreshLogViewButton.Click += new System.EventHandler(this.RefreshLogViewButton_Click);
            // 
            // filterByDateCheckBox
            // 
            this.filterByDateCheckBox.AutoSize = true;
            this.filterByDateCheckBox.Checked = true;
            this.filterByDateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterByDateCheckBox.Location = new System.Drawing.Point(4, 10);
            this.filterByDateCheckBox.Name = "filterByDateCheckBox";
            this.filterByDateCheckBox.Size = new System.Drawing.Size(120, 17);
            this.filterByDateCheckBox.TabIndex = 15;
            this.filterByDateCheckBox.Text = "Prikaži samo datum:";
            this.filterByDateCheckBox.UseVisualStyleBackColor = true;
            this.filterByDateCheckBox.CheckedChanged += new System.EventHandler(this.filterByDateCheckBox_CheckedChanged);
            // 
            // rightSidePanel
            // 
            this.rightSidePanel.Controls.Add(this.editEventButton);
            this.rightSidePanel.Controls.Add(this.deleteEventButton);
            this.rightSidePanel.Controls.Add(this.filterByDateCheckBox);
            this.rightSidePanel.Controls.Add(this.logListView);
            this.rightSidePanel.Controls.Add(this.RefreshLogViewButton);
            this.rightSidePanel.Controls.Add(this.summaryLabel);
            this.rightSidePanel.Controls.Add(this.dateGroupBox);
            this.rightSidePanel.Controls.Add(this.filterByTypeGroupBox);
            this.rightSidePanel.Controls.Add(this.filterByTypeCheckBox);
            this.rightSidePanel.Location = new System.Drawing.Point(540, 5);
            this.rightSidePanel.Name = "rightSidePanel";
            this.rightSidePanel.Size = new System.Drawing.Size(548, 635);
            this.rightSidePanel.TabIndex = 26;
            // 
            // logListView
            // 
            this.logListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logListView.Location = new System.Drawing.Point(4, 107);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(539, 444);
            this.logListView.TabIndex = 9;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.logListView_KeyDown);
            this.logListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logListView_MouseDoubleClick);
            // 
            // frogALogLabel
            // 
            this.frogALogLabel.AutoSize = true;
            this.frogALogLabel.Font = new System.Drawing.Font("Segoe Script", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.frogALogLabel.Location = new System.Drawing.Point(122, -7);
            this.frogALogLabel.Name = "frogALogLabel";
            this.frogALogLabel.Size = new System.Drawing.Size(307, 74);
            this.frogALogLabel.TabIndex = 27;
            this.frogALogLabel.Text = "Frog-A-Log";
            // 
            // SilentModeCheckBox
            // 
            this.SilentModeCheckBox.AutoSize = true;
            this.SilentModeCheckBox.Location = new System.Drawing.Point(428, 5);
            this.SilentModeCheckBox.Name = "SilentModeCheckBox";
            this.SilentModeCheckBox.Size = new System.Drawing.Size(90, 17);
            this.SilentModeCheckBox.TabIndex = 34;
            this.SilentModeCheckBox.Text = "Nečujni alarm";
            this.SilentModeCheckBox.UseVisualStyleBackColor = true;
            this.SilentModeCheckBox.Visible = false;
            // 
            // ToggleSoundButton
            // 
            this.ToggleSoundButton.Image = global::LovroLog.Properties.Resources.sound_off2_201;
            this.ToggleSoundButton.Location = new System.Drawing.Point(84, 16);
            this.ToggleSoundButton.Name = "ToggleSoundButton";
            this.ToggleSoundButton.Size = new System.Drawing.Size(32, 32);
            this.ToggleSoundButton.TabIndex = 35;
            this.toolTip1.SetToolTip(this.ToggleSoundButton, "Uključi/isključi zvuk");
            this.ToggleSoundButton.UseVisualStyleBackColor = true;
            this.ToggleSoundButton.Click += new System.EventHandler(this.ToggleSoundButton_Click);
            // 
            // AnalyzeDataButton
            // 
            this.AnalyzeDataButton.Image = global::LovroLog.Properties.Resources.errorViewer_20;
            this.AnalyzeDataButton.Location = new System.Drawing.Point(45, 16);
            this.AnalyzeDataButton.Name = "AnalyzeDataButton";
            this.AnalyzeDataButton.Size = new System.Drawing.Size(32, 32);
            this.AnalyzeDataButton.TabIndex = 33;
            this.toolTip1.SetToolTip(this.AnalyzeDataButton, "Provjeri greške");
            this.AnalyzeDataButton.UseVisualStyleBackColor = true;
            this.AnalyzeDataButton.Click += new System.EventHandler(this.AnalyzeDataButton_Click);
            // 
            // viewSleepChartButton
            // 
            this.viewSleepChartButton.Image = global::LovroLog.Properties.Resources.chart_20;
            this.viewSleepChartButton.Location = new System.Drawing.Point(7, 16);
            this.viewSleepChartButton.Name = "viewSleepChartButton";
            this.viewSleepChartButton.Size = new System.Drawing.Size(32, 32);
            this.viewSleepChartButton.TabIndex = 32;
            this.toolTip1.SetToolTip(this.viewSleepChartButton, "Grafički prikaz spavanja");
            this.viewSleepChartButton.UseVisualStyleBackColor = true;
            this.viewSleepChartButton.Click += new System.EventHandler(this.viewSleepChartButton_Click);
            // 
            // otherEventButton
            // 
            this.otherEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.otherEventButton.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.otherEventButton.Image = global::LovroLog.Properties.Resources.ellipsis_60px;
            this.otherEventButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.otherEventButton.Location = new System.Drawing.Point(347, 281);
            this.otherEventButton.Name = "otherEventButton";
            this.otherEventButton.Size = new System.Drawing.Size(154, 102);
            this.otherEventButton.TabIndex = 31;
            this.otherEventButton.Text = "Razno...";
            this.otherEventButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.otherEventButton.UseVisualStyleBackColor = false;
            this.otherEventButton.Click += new System.EventHandler(this.otherEventButton_Click);
            // 
            // toggleLogPBoxBtn
            // 
            this.toggleLogPBoxBtn.Image = global::LovroLog.Properties.Resources.plus3d_35px;
            this.toggleLogPBoxBtn.Location = new System.Drawing.Point(503, 47);
            this.toggleLogPBoxBtn.Name = "toggleLogPBoxBtn";
            this.toggleLogPBoxBtn.Size = new System.Drawing.Size(36, 35);
            this.toggleLogPBoxBtn.TabIndex = 30;
            this.toggleLogPBoxBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.toggleLogPBoxBtn, "Klikni za otvaranje/zatvaranje loga");
            this.toggleLogPBoxBtn.Click += new System.EventHandler(this.toggleLogPBoxBtn_Click);
            this.toggleLogPBoxBtn.MouseEnter += new System.EventHandler(this.toggleLogPBoxBtn_MouseEnter);
            this.toggleLogPBoxBtn.MouseLeave += new System.EventHandler(this.toggleLogPBoxBtn_MouseLeave);
            // 
            // stopwatchSleepPictureBox
            // 
            this.stopwatchSleepPictureBox.Image = global::LovroLog.Properties.Resources.sleep_transparent_60opx;
            this.stopwatchSleepPictureBox.InitialImage = global::LovroLog.Properties.Resources.food_20px;
            this.stopwatchSleepPictureBox.Location = new System.Drawing.Point(342, 79);
            this.stopwatchSleepPictureBox.Name = "stopwatchSleepPictureBox";
            this.stopwatchSleepPictureBox.Size = new System.Drawing.Size(40, 40);
            this.stopwatchSleepPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stopwatchSleepPictureBox.TabIndex = 25;
            this.stopwatchSleepPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.stopwatchSleepPictureBox, "Vrijeme proteklo od posljednjeg spavanja");
            // 
            // stopwatchFoodPictureBox
            // 
            this.stopwatchFoodPictureBox.Image = global::LovroLog.Properties.Resources.food_60px;
            this.stopwatchFoodPictureBox.InitialImage = global::LovroLog.Properties.Resources.food_20px;
            this.stopwatchFoodPictureBox.Location = new System.Drawing.Point(179, 79);
            this.stopwatchFoodPictureBox.Name = "stopwatchFoodPictureBox";
            this.stopwatchFoodPictureBox.Size = new System.Drawing.Size(40, 40);
            this.stopwatchFoodPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stopwatchFoodPictureBox.TabIndex = 22;
            this.stopwatchFoodPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.stopwatchFoodPictureBox, "Vrijeme proteklo od posljednjeg hranjenja");
            // 
            // stopwatchDiaperPictureBox
            // 
            this.stopwatchDiaperPictureBox.Image = global::LovroLog.Properties.Resources.diaper_poopy_60;
            this.stopwatchDiaperPictureBox.InitialImage = global::LovroLog.Properties.Resources.diaper_poopy_60;
            this.stopwatchDiaperPictureBox.Location = new System.Drawing.Point(9, 79);
            this.stopwatchDiaperPictureBox.Name = "stopwatchDiaperPictureBox";
            this.stopwatchDiaperPictureBox.Size = new System.Drawing.Size(40, 40);
            this.stopwatchDiaperPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stopwatchDiaperPictureBox.TabIndex = 21;
            this.stopwatchDiaperPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.stopwatchDiaperPictureBox, "Vrijeme proteklo od posljednje promjene pelena");
            // 
            // poopyDiaperChangedButton
            // 
            this.poopyDiaperChangedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.poopyDiaperChangedButton.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.poopyDiaperChangedButton.Image = global::LovroLog.Properties.Resources.diaper_poopy_60;
            this.poopyDiaperChangedButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.poopyDiaperChangedButton.Location = new System.Drawing.Point(178, 395);
            this.poopyDiaperChangedButton.Name = "poopyDiaperChangedButton";
            this.poopyDiaperChangedButton.Size = new System.Drawing.Size(154, 102);
            this.poopyDiaperChangedButton.TabIndex = 7;
            this.poopyDiaperChangedButton.Text = "Promijeniše mi pelenu - posranu";
            this.poopyDiaperChangedButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.poopyDiaperChangedButton.UseVisualStyleBackColor = false;
            this.poopyDiaperChangedButton.Click += new System.EventHandler(this.PoopyDiaperChangedButton_Click);
            // 
            // bathedButton
            // 
            this.bathedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bathedButton.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bathedButton.Image = global::LovroLog.Properties.Resources.Bath_60px;
            this.bathedButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bathedButton.Location = new System.Drawing.Point(347, 170);
            this.bathedButton.Name = "bathedButton";
            this.bathedButton.Size = new System.Drawing.Size(154, 102);
            this.bathedButton.TabIndex = 6;
            this.bathedButton.Text = "Okupali su me";
            this.bathedButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bathedButton.UseVisualStyleBackColor = false;
            this.bathedButton.Click += new System.EventHandler(this.BathedButton_Click);
            // 
            // wetDiaperChangedButton
            // 
            this.wetDiaperChangedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.wetDiaperChangedButton.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wetDiaperChangedButton.Image = global::LovroLog.Properties.Resources.diaper_wet_60;
            this.wetDiaperChangedButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.wetDiaperChangedButton.Location = new System.Drawing.Point(8, 395);
            this.wetDiaperChangedButton.Name = "wetDiaperChangedButton";
            this.wetDiaperChangedButton.Size = new System.Drawing.Size(154, 102);
            this.wetDiaperChangedButton.TabIndex = 5;
            this.wetDiaperChangedButton.Text = "Promijeniše mi pelenu - mokru";
            this.wetDiaperChangedButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.wetDiaperChangedButton.UseVisualStyleBackColor = false;
            this.wetDiaperChangedButton.Click += new System.EventHandler(this.WetDiaperChangedButton_Click);
            // 
            // wokeUpButton
            // 
            this.wokeUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.wokeUpButton.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wokeUpButton.Image = global::LovroLog.Properties.Resources.wakeUp_transparent_60px;
            this.wokeUpButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.wokeUpButton.Location = new System.Drawing.Point(178, 281);
            this.wokeUpButton.Name = "wokeUpButton";
            this.wokeUpButton.Size = new System.Drawing.Size(154, 102);
            this.wokeUpButton.TabIndex = 3;
            this.wokeUpButton.Text = "Probudio sam se";
            this.wokeUpButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.wokeUpButton.UseVisualStyleBackColor = false;
            this.wokeUpButton.Click += new System.EventHandler(this.WokeUpButton_Click);
            // 
            // fellAsleep
            // 
            this.fellAsleep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fellAsleep.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fellAsleep.Image = global::LovroLog.Properties.Resources.sleep_transparent_60opx;
            this.fellAsleep.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.fellAsleep.Location = new System.Drawing.Point(8, 281);
            this.fellAsleep.Name = "fellAsleep";
            this.fellAsleep.Size = new System.Drawing.Size(154, 102);
            this.fellAsleep.TabIndex = 2;
            this.fellAsleep.Text = "Zaspao sam";
            this.fellAsleep.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fellAsleep.UseVisualStyleBackColor = false;
            this.fellAsleep.Click += new System.EventHandler(this.FellAsleep_Click);
            // 
            // foodButton
            // 
            this.foodButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.foodButton.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodButton.Image = global::LovroLog.Properties.Resources.food_60px;
            this.foodButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.foodButton.Location = new System.Drawing.Point(8, 170);
            this.foodButton.Name = "foodButton";
            this.foodButton.Size = new System.Drawing.Size(154, 102);
            this.foodButton.TabIndex = 1;
            this.foodButton.Text = "Jeo sam";
            this.foodButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.foodButton.UseVisualStyleBackColor = false;
            this.foodButton.Click += new System.EventHandler(this.FoodButton_Click);
            // 
            // shitButton
            // 
            this.shitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.shitButton.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.shitButton.Image = global::LovroLog.Properties.Resources.shit_60;
            this.shitButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.shitButton.Location = new System.Drawing.Point(178, 170);
            this.shitButton.Name = "shitButton";
            this.shitButton.Size = new System.Drawing.Size(154, 102);
            this.shitButton.TabIndex = 0;
            this.shitButton.Text = "Čujno sam srao";
            this.shitButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.shitButton.UseVisualStyleBackColor = false;
            this.shitButton.Click += new System.EventHandler(this.ShitButton_Click);
            // 
            // editEventButton
            // 
            this.editEventButton.Image = global::LovroLog.Properties.Resources.edit_darker_20px;
            this.editEventButton.Location = new System.Drawing.Point(503, 54);
            this.editEventButton.Name = "editEventButton";
            this.editEventButton.Size = new System.Drawing.Size(40, 36);
            this.editEventButton.TabIndex = 20;
            this.editEventButton.UseVisualStyleBackColor = true;
            this.editEventButton.Click += new System.EventHandler(this.editEventButton_Click);
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Image = global::LovroLog.Properties.Resources.Delete_20px;
            this.deleteEventButton.Location = new System.Drawing.Point(436, 53);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(40, 36);
            this.deleteEventButton.TabIndex = 19;
            this.deleteEventButton.UseVisualStyleBackColor = true;
            this.deleteEventButton.Click += new System.EventHandler(this.deleteEventButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::LovroLog.Properties.Resources.frog_icon;
            this.logoPictureBox.Location = new System.Drawing.Point(334, 429);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(184, 180);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 28;
            this.logoPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.logoPictureBox, "Bok, ja sam žaba!");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LovroLog.Properties.Resources.pruga2;
            this.pictureBox2.Image = global::LovroLog.Properties.Resources.pruga;
            this.pictureBox2.Location = new System.Drawing.Point(519, -10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 650);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // goToTodayButton
            // 
            this.goToTodayButton.Location = new System.Drawing.Point(181, 20);
            this.goToTodayButton.Name = "goToTodayButton";
            this.goToTodayButton.Size = new System.Drawing.Size(27, 23);
            this.goToTodayButton.TabIndex = 15;
            this.goToTodayButton.Text = ">>";
            this.goToTodayButton.UseVisualStyleBackColor = true;
            this.goToTodayButton.Click += new System.EventHandler(this.goToTodayButton_Click);
            // 
            // LovroLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(235)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(539, 582);
            this.Controls.Add(this.ToggleSoundButton);
            this.Controls.Add(this.SilentModeCheckBox);
            this.Controls.Add(this.AnalyzeDataButton);
            this.Controls.Add(this.viewSleepChartButton);
            this.Controls.Add(this.otherEventButton);
            this.Controls.Add(this.toggleLogPBoxBtn);
            this.Controls.Add(this.stopwatchSleepPictureBox);
            this.Controls.Add(this.stopwatchSleepLabel);
            this.Controls.Add(this.stopwatchFoodPictureBox);
            this.Controls.Add(this.stopwatchDiaperPictureBox);
            this.Controls.Add(this.stopwatchDiaperLabel);
            this.Controls.Add(this.askForDetailsCheckBox);
            this.Controls.Add(this.poopyDiaperChangedButton);
            this.Controls.Add(this.bathedButton);
            this.Controls.Add(this.wetDiaperChangedButton);
            this.Controls.Add(this.wokeUpButton);
            this.Controls.Add(this.fellAsleep);
            this.Controls.Add(this.foodButton);
            this.Controls.Add(this.shitButton);
            this.Controls.Add(this.stopwatchFoodLabel);
            this.Controls.Add(this.rightSidePanel);
            this.Controls.Add(this.frogALogLabel);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1106, 620);
            this.MinimumSize = new System.Drawing.Size(555, 620);
            this.Name = "LovroLogForm";
            this.Text = "Frog-A-Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LovroLogForm_FormClosed);
            this.Load += new System.EventHandler(this.LovroLogForm_Load);
            this.filterByTypeGroupBox.ResumeLayout(false);
            this.dateGroupBox.ResumeLayout(false);
            this.rightSidePanel.ResumeLayout(false);
            this.rightSidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleLogPBoxBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopwatchSleepPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopwatchFoodPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopwatchDiaperPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shitButton;
        private System.Windows.Forms.Button foodButton;
        private System.Windows.Forms.Button fellAsleep;
        private System.Windows.Forms.Button wokeUpButton;
        private System.Windows.Forms.Button wetDiaperChangedButton;
        private System.Windows.Forms.Button bathedButton;
        private System.Windows.Forms.Button poopyDiaperChangedButton;
        private System.Windows.Forms.CheckBox askForDetailsCheckBox;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label stopwatchDiaperLabel;
        private System.Windows.Forms.PictureBox stopwatchDiaperPictureBox;
        private System.Windows.Forms.PictureBox stopwatchFoodPictureBox;
        private System.Windows.Forms.Label stopwatchFoodLabel;
        private System.Windows.Forms.Label stopwatchSleepLabel;
        private System.Windows.Forms.PictureBox stopwatchSleepPictureBox;
        private System.Windows.Forms.CheckBox filterByTypeCheckBox;
        private System.Windows.Forms.GroupBox filterByTypeGroupBox;
        private System.Windows.Forms.ComboBox filterByTypeComboBox;
        private System.Windows.Forms.GroupBox dateGroupBox;
        private System.Windows.Forms.DateTimePicker displayedDatePicker;
        private System.Windows.Forms.Button goBackTimeButton;
        private System.Windows.Forms.Button goForwardTimeButton;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Button RefreshLogViewButton;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.CheckBox filterByDateCheckBox;
        private System.Windows.Forms.Panel rightSidePanel;
        private System.Windows.Forms.Button editEventButton;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.Label frogALogLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox toggleLogPBoxBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button otherEventButton;
        private System.Windows.Forms.Button viewSleepChartButton;
        private System.Windows.Forms.Button AnalyzeDataButton;
        private System.Windows.Forms.CheckBox SilentModeCheckBox;
        private System.Windows.Forms.Button ToggleSoundButton;
        private System.Windows.Forms.Button goToTodayButton;
    }
}

