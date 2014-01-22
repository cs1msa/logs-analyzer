namespace LogsAnalyzer
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.GB_FirsChoice = new System.Windows.Forms.GroupBox();
            this.CB_FirstChoice = new System.Windows.Forms.ComboBox();
            this.GB_Users = new System.Windows.Forms.GroupBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.BT_TickAll_Users = new System.Windows.Forms.Button();
            this.STB_Filter_Users = new LogsAnalyzer.SearchTextBox();
            this.CLB_Users = new System.Windows.Forms.CheckedListBox();
            this.GB_EventTypes = new System.Windows.Forms.GroupBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.STB_Filter_EventTypes = new LogsAnalyzer.SearchTextBox();
            this.BT_TickAll_EventTypes = new System.Windows.Forms.Button();
            this.CLB_EventTypes = new System.Windows.Forms.CheckedListBox();
            this.GB_Applications = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.STB_Filter_Applications = new LogsAnalyzer.SearchTextBox();
            this.BT_TickAll_Applications = new System.Windows.Forms.Button();
            this.CLB_Applications = new System.Windows.Forms.CheckedListBox();
            this.GB_EventServices = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.BT_TickAll_EventServices = new System.Windows.Forms.Button();
            this.STB_Filter_EventServices = new LogsAnalyzer.SearchTextBox();
            this.CLB_EventServices = new System.Windows.Forms.CheckedListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LAB_ResultsCount = new System.Windows.Forms.Label();
            this.GB_DateTime_To = new System.Windows.Forms.GroupBox();
            this.DTP_To = new System.Windows.Forms.DateTimePicker();
            this.TTB_To = new LogsAnalyzer.TimeTextBox();
            this.GB_DateTime_From = new System.Windows.Forms.GroupBox();
            this.DTP_From = new System.Windows.Forms.DateTimePicker();
            this.TTB_From = new LogsAnalyzer.TimeTextBox();
            this.DGV_Display = new System.Windows.Forms.DataGridView();
            this.EventsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.locationappDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BW_Worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.GB_FirsChoice.SuspendLayout();
            this.GB_Users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.GB_EventTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.GB_Applications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.GB_EventServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.GB_DateTime_To.SuspendLayout();
            this.GB_DateTime_From.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsBindingSource)).BeginInit();

            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 575);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.GB_FirsChoice);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.GB_Users);
            this.splitContainer7.Panel2.Controls.Add(this.GB_EventTypes);
            this.splitContainer7.Panel2.Controls.Add(this.GB_Applications);
            this.splitContainer7.Panel2.Controls.Add(this.GB_EventServices);
            this.splitContainer7.Size = new System.Drawing.Size(235, 575);
            this.splitContainer7.SplitterDistance = 47;
            this.splitContainer7.TabIndex = 0;
            // 
            // GB_FirsChoice
            // 
            this.GB_FirsChoice.Controls.Add(this.CB_FirstChoice);
            this.GB_FirsChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_FirsChoice.Location = new System.Drawing.Point(0, 0);
            this.GB_FirsChoice.Name = "GB_FirsChoice";
            this.GB_FirsChoice.Size = new System.Drawing.Size(235, 47);
            this.GB_FirsChoice.TabIndex = 1;
            this.GB_FirsChoice.TabStop = false;
            this.GB_FirsChoice.Text = "Entities";
            // 
            // CB_FirstChoice
            // 
            this.CB_FirstChoice.FormattingEnabled = true;
            this.CB_FirstChoice.Location = new System.Drawing.Point(3, 18);
            this.CB_FirstChoice.Name = "CB_FirstChoice";
            this.CB_FirstChoice.Size = new System.Drawing.Size(230, 21);
            this.CB_FirstChoice.TabIndex = 0;
            this.CB_FirstChoice.Text = "Select...";
            this.CB_FirstChoice.SelectedIndexChanged += new System.EventHandler(this.CB_FirstChoice_SelectedIndexChanged);
            // 
            // GB_Users
            // 
            this.GB_Users.Controls.Add(this.splitContainer6);
            this.GB_Users.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_Users.Enabled = false;
            this.GB_Users.Location = new System.Drawing.Point(0, 393);
            this.GB_Users.Name = "GB_Users";
            this.GB_Users.Size = new System.Drawing.Size(235, 131);
            this.GB_Users.TabIndex = 4;
            this.GB_Users.TabStop = false;
            this.GB_Users.Text = "Users";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(3, 16);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.BT_TickAll_Users);
            this.splitContainer6.Panel1.Controls.Add(this.STB_Filter_Users);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.CLB_Users);
            this.splitContainer6.Size = new System.Drawing.Size(229, 112);
            this.splitContainer6.SplitterDistance = 25;
            this.splitContainer6.TabIndex = 0;
            // 
            // BT_TickAll_Users
            // 
            this.BT_TickAll_Users.BackgroundImage = global::LogsAnalyzer.Properties.Resources.tick_;
            this.BT_TickAll_Users.Location = new System.Drawing.Point(210, 3);
            this.BT_TickAll_Users.Name = "BT_TickAll_Users";
            this.BT_TickAll_Users.Size = new System.Drawing.Size(20, 20);
            this.BT_TickAll_Users.TabIndex = 11;
            this.BT_TickAll_Users.UseVisualStyleBackColor = true;
            this.BT_TickAll_Users.Click += new System.EventHandler(this.BT_TickAll_Users_Click);
            // 
            // STB_Filter_Users
            // 
            this.STB_Filter_Users.IconColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.STB_Filter_Users.IconColorHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(137)))), ((int)(((byte)(193)))));
            this.STB_Filter_Users.Location = new System.Drawing.Point(0, 3);
            this.STB_Filter_Users.Name = "STB_Filter_Users";
            this.STB_Filter_Users.Size = new System.Drawing.Size(201, 20);
            this.STB_Filter_Users.TabIndex = 7;
            this.STB_Filter_Users.TextChanged += new System.EventHandler(this.STB_Filter_Users_TextChanged);
            // 
            // CLB_Users
            // 
            this.CLB_Users.CheckOnClick = true;
            this.CLB_Users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLB_Users.FormattingEnabled = true;
            this.CLB_Users.Location = new System.Drawing.Point(0, 0);
            this.CLB_Users.Name = "CLB_Users";
            this.CLB_Users.Size = new System.Drawing.Size(229, 83);
            this.CLB_Users.TabIndex = 6;
            this.CLB_Users.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLB_Users_ItemCheck);
            // 
            // GB_EventTypes
            // 
            this.GB_EventTypes.Controls.Add(this.splitContainer5);
            this.GB_EventTypes.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_EventTypes.Enabled = false;
            this.GB_EventTypes.Location = new System.Drawing.Point(0, 262);
            this.GB_EventTypes.Name = "GB_EventTypes";
            this.GB_EventTypes.Size = new System.Drawing.Size(235, 131);
            this.GB_EventTypes.TabIndex = 3;
            this.GB_EventTypes.TabStop = false;
            this.GB_EventTypes.Text = "Event Types";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 16);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.STB_Filter_EventTypes);
            this.splitContainer5.Panel1.Controls.Add(this.BT_TickAll_EventTypes);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.CLB_EventTypes);
            this.splitContainer5.Size = new System.Drawing.Size(229, 112);
            this.splitContainer5.SplitterDistance = 25;
            this.splitContainer5.TabIndex = 0;
            // 
            // STB_Filter_EventTypes
            // 
            this.STB_Filter_EventTypes.IconColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.STB_Filter_EventTypes.IconColorHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(137)))), ((int)(((byte)(193)))));
            this.STB_Filter_EventTypes.Location = new System.Drawing.Point(0, 3);
            this.STB_Filter_EventTypes.Name = "STB_Filter_EventTypes";
            this.STB_Filter_EventTypes.Size = new System.Drawing.Size(201, 20);
            this.STB_Filter_EventTypes.TabIndex = 2;
            this.STB_Filter_EventTypes.TextChanged += new System.EventHandler(this.STB_Filter_EventTypes_TextChanged);
            // 
            // BT_TickAll_EventTypes
            // 
            this.BT_TickAll_EventTypes.BackgroundImage = global::LogsAnalyzer.Properties.Resources.tick_;
            this.BT_TickAll_EventTypes.Location = new System.Drawing.Point(210, 3);
            this.BT_TickAll_EventTypes.Name = "BT_TickAll_EventTypes";
            this.BT_TickAll_EventTypes.Size = new System.Drawing.Size(20, 20);
            this.BT_TickAll_EventTypes.TabIndex = 10;
            this.BT_TickAll_EventTypes.UseVisualStyleBackColor = true;
            this.BT_TickAll_EventTypes.Click += new System.EventHandler(this.BT_TickAll_EventTypes_Click);
            // 
            // CLB_EventTypes
            // 
            this.CLB_EventTypes.CheckOnClick = true;
            this.CLB_EventTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLB_EventTypes.FormattingEnabled = true;
            this.CLB_EventTypes.Location = new System.Drawing.Point(0, 0);
            this.CLB_EventTypes.Name = "CLB_EventTypes";
            this.CLB_EventTypes.Size = new System.Drawing.Size(229, 83);
            this.CLB_EventTypes.TabIndex = 0;
            this.CLB_EventTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLB_EventTypes_ItemCheck);
            // 
            // GB_Applications
            // 
            this.GB_Applications.Controls.Add(this.splitContainer3);
            this.GB_Applications.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_Applications.Enabled = false;
            this.GB_Applications.Location = new System.Drawing.Point(0, 131);
            this.GB_Applications.Name = "GB_Applications";
            this.GB_Applications.Size = new System.Drawing.Size(235, 131);
            this.GB_Applications.TabIndex = 1;
            this.GB_Applications.TabStop = false;
            this.GB_Applications.Text = "Applications";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.STB_Filter_Applications);
            this.splitContainer3.Panel1.Controls.Add(this.BT_TickAll_Applications);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.CLB_Applications);
            this.splitContainer3.Size = new System.Drawing.Size(229, 112);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.TabIndex = 0;
            // 
            // STB_Filter_Applications
            // 
            this.STB_Filter_Applications.IconColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.STB_Filter_Applications.IconColorHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(137)))), ((int)(((byte)(193)))));
            this.STB_Filter_Applications.Location = new System.Drawing.Point(0, 3);
            this.STB_Filter_Applications.Name = "STB_Filter_Applications";
            this.STB_Filter_Applications.Size = new System.Drawing.Size(201, 20);
            this.STB_Filter_Applications.TabIndex = 5;
            this.STB_Filter_Applications.TextChanged += new System.EventHandler(this.STB_Filter_Applications_TextChanged);
            // 
            // BT_TickAll_Applications
            // 
            this.BT_TickAll_Applications.BackgroundImage = global::LogsAnalyzer.Properties.Resources.tick_;
            this.BT_TickAll_Applications.Location = new System.Drawing.Point(210, 3);
            this.BT_TickAll_Applications.Name = "BT_TickAll_Applications";
            this.BT_TickAll_Applications.Size = new System.Drawing.Size(20, 20);
            this.BT_TickAll_Applications.TabIndex = 8;
            this.BT_TickAll_Applications.UseVisualStyleBackColor = true;
            this.BT_TickAll_Applications.Click += new System.EventHandler(this.BT_TickAll_Applications_Click);
            // 
            // CLB_Applications
            // 
            this.CLB_Applications.CheckOnClick = true;
            this.CLB_Applications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLB_Applications.FormattingEnabled = true;
            this.CLB_Applications.Location = new System.Drawing.Point(0, 0);
            this.CLB_Applications.Name = "CLB_Applications";
            this.CLB_Applications.Size = new System.Drawing.Size(229, 83);
            this.CLB_Applications.TabIndex = 4;
            this.CLB_Applications.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLB_Applications_ItemCheck);
            // 
            // GB_EventServices
            // 
            this.GB_EventServices.Controls.Add(this.splitContainer4);
            this.GB_EventServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_EventServices.Enabled = false;
            this.GB_EventServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GB_EventServices.Location = new System.Drawing.Point(0, 0);
            this.GB_EventServices.Name = "GB_EventServices";
            this.GB_EventServices.Size = new System.Drawing.Size(235, 131);
            this.GB_EventServices.TabIndex = 2;
            this.GB_EventServices.TabStop = false;
            this.GB_EventServices.Text = "Event Services";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 16);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.BT_TickAll_EventServices);
            this.splitContainer4.Panel1.Controls.Add(this.STB_Filter_EventServices);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.CLB_EventServices);
            this.splitContainer4.Size = new System.Drawing.Size(229, 112);
            this.splitContainer4.SplitterDistance = 25;
            this.splitContainer4.TabIndex = 0;
            // 
            // BT_TickAll_EventServices
            // 
            this.BT_TickAll_EventServices.BackgroundImage = global::LogsAnalyzer.Properties.Resources.tick_;
            this.BT_TickAll_EventServices.Location = new System.Drawing.Point(210, 3);
            this.BT_TickAll_EventServices.Name = "BT_TickAll_EventServices";
            this.BT_TickAll_EventServices.Size = new System.Drawing.Size(20, 20);
            this.BT_TickAll_EventServices.TabIndex = 9;
            this.BT_TickAll_EventServices.UseVisualStyleBackColor = true;
            this.BT_TickAll_EventServices.Click += new System.EventHandler(this.BT_TickAll_EventServices_Click);
            // 
            // STB_Filter_EventServices
            // 
            this.STB_Filter_EventServices.IconColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(69)))), ((int)(((byte)(114)))));
            this.STB_Filter_EventServices.IconColorHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(137)))), ((int)(((byte)(193)))));
            this.STB_Filter_EventServices.Location = new System.Drawing.Point(0, 3);
            this.STB_Filter_EventServices.Name = "STB_Filter_EventServices";
            this.STB_Filter_EventServices.Size = new System.Drawing.Size(201, 20);
            this.STB_Filter_EventServices.TabIndex = 3;
            this.STB_Filter_EventServices.TextChanged += new System.EventHandler(this.STB_Filter_EventServices_TextChanged);
            // 
            // CLB_EventServices
            // 
            this.CLB_EventServices.CheckOnClick = true;
            this.CLB_EventServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLB_EventServices.FormattingEnabled = true;
            this.CLB_EventServices.Location = new System.Drawing.Point(0, 0);
            this.CLB_EventServices.Name = "CLB_EventServices";
            this.CLB_EventServices.Size = new System.Drawing.Size(229, 83);
            this.CLB_EventServices.TabIndex = 1;
            this.CLB_EventServices.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLB_EventServices_ItemCheck);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LAB_ResultsCount);
            this.splitContainer2.Panel1.Controls.Add(this.GB_DateTime_To);
            this.splitContainer2.Panel1.Controls.Add(this.GB_DateTime_From);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DGV_Display);
            this.splitContainer2.Size = new System.Drawing.Size(869, 575);
            this.splitContainer2.SplitterDistance = 47;
            this.splitContainer2.TabIndex = 0;
            // 
            // LAB_ResultsCount
            // 
            this.LAB_ResultsCount.AutoSize = true;
            this.LAB_ResultsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LAB_ResultsCount.Location = new System.Drawing.Point(622, 19);
            this.LAB_ResultsCount.Name = "LAB_ResultsCount";
            this.LAB_ResultsCount.Size = new System.Drawing.Size(0, 20);
            this.LAB_ResultsCount.TabIndex = 5;
            // 
            // GB_DateTime_To
            // 
            this.GB_DateTime_To.Controls.Add(this.DTP_To);
            this.GB_DateTime_To.Controls.Add(this.TTB_To);
            this.GB_DateTime_To.Dock = System.Windows.Forms.DockStyle.Left;
            this.GB_DateTime_To.Enabled = false;
            this.GB_DateTime_To.Location = new System.Drawing.Point(308, 0);
            this.GB_DateTime_To.Name = "GB_DateTime_To";
            this.GB_DateTime_To.Size = new System.Drawing.Size(308, 47);
            this.GB_DateTime_To.TabIndex = 4;
            this.GB_DateTime_To.TabStop = false;
            this.GB_DateTime_To.Text = "Date/Time To";
            // 
            // DTP_To
            // 
            this.DTP_To.Location = new System.Drawing.Point(6, 19);
            this.DTP_To.Name = "DTP_To";
            this.DTP_To.Size = new System.Drawing.Size(200, 20);
            this.DTP_To.TabIndex = 1;
            this.DTP_To.ValueChanged += new System.EventHandler(this.DTP_To_ValueChanged);
            // 
            // TTB_To
            // 
            this.TTB_To.Location = new System.Drawing.Point(227, 19);
            this.TTB_To.Name = "TTB_To";
            this.TTB_To.Size = new System.Drawing.Size(73, 20);
            this.TTB_To.TabIndex = 4;
            // 
            // GB_DateTime_From
            // 
            this.GB_DateTime_From.Controls.Add(this.DTP_From);
            this.GB_DateTime_From.Controls.Add(this.TTB_From);
            this.GB_DateTime_From.Dock = System.Windows.Forms.DockStyle.Left;
            this.GB_DateTime_From.Enabled = false;
            this.GB_DateTime_From.Location = new System.Drawing.Point(0, 0);
            this.GB_DateTime_From.Name = "GB_DateTime_From";
            this.GB_DateTime_From.Size = new System.Drawing.Size(308, 47);
            this.GB_DateTime_From.TabIndex = 1;
            this.GB_DateTime_From.TabStop = false;
            this.GB_DateTime_From.Text = "Date/Time From";
            // 
            // DTP_From
            // 
            this.DTP_From.Location = new System.Drawing.Point(6, 19);
            this.DTP_From.Name = "DTP_From";
            this.DTP_From.Size = new System.Drawing.Size(200, 20);
            this.DTP_From.TabIndex = 0;
            this.DTP_From.ValueChanged += new System.EventHandler(this.DTP_From_ValueChanged);
            // 
            // TTB_From
            // 
            this.TTB_From.Location = new System.Drawing.Point(227, 19);
            this.TTB_From.Name = "TTB_From";
            this.TTB_From.Size = new System.Drawing.Size(73, 20);
            this.TTB_From.TabIndex = 3;
            // 
            // DGV_Display
            // 
            this.DGV_Display.AllowUserToAddRows = false;
            this.DGV_Display.AllowUserToDeleteRows = false;
            this.DGV_Display.AllowUserToOrderColumns = true;
            this.DGV_Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Display.Location = new System.Drawing.Point(0, 0);
            this.DGV_Display.Name = "DGV_Display";
            this.DGV_Display.Size = new System.Drawing.Size(869, 524);
            this.DGV_Display.TabIndex = 0;
            // 
            // BW_Worker
            // 
            this.BW_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_Worker_DoWork);
            this.BW_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_Worker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 575);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs Analyzer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.GB_FirsChoice.ResumeLayout(false);
            this.GB_Users.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.GB_EventTypes.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.GB_Applications.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.GB_EventServices.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.GB_DateTime_To.ResumeLayout(false);
            this.GB_DateTime_To.PerformLayout();
            this.GB_DateTime_From.ResumeLayout(false);
            this.GB_DateTime_From.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EventsBindingSource)).EndInit();

            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox CB_FirstChoice;
        private System.Windows.Forms.BindingSource EventsBindingSource;
        private System.Windows.Forms.DataGridView DGV_Display;
        private System.Windows.Forms.BindingSource locationappDataSetBindingSource;
        private System.Windows.Forms.DateTimePicker DTP_To;
        private System.Windows.Forms.DateTimePicker DTP_From;
        private LogsAnalyzer.TimeTextBox TTB_From;
        private LogsAnalyzer.TimeTextBox TTB_To;
        private System.Windows.Forms.CheckedListBox CLB_EventTypes;
        private System.Windows.Forms.CheckedListBox CLB_EventServices;
        private LogsAnalyzer.SearchTextBox STB_Filter_EventTypes;
        private SearchTextBox STB_Filter_EventServices;
        private SearchTextBox STB_Filter_Applications;
        private System.Windows.Forms.CheckedListBox CLB_Applications;
        private System.Windows.Forms.Button BT_TickAll_Applications;
        private SearchTextBox STB_Filter_Users;
        private System.Windows.Forms.CheckedListBox CLB_Users;
        private System.Windows.Forms.Button BT_TickAll_Users;
        private System.Windows.Forms.Button BT_TickAll_EventTypes;
        private System.Windows.Forms.Button BT_TickAll_EventServices;
        private System.Windows.Forms.GroupBox GB_EventServices;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox GB_Applications;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox GB_Users;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.GroupBox GB_EventTypes;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox GB_DateTime_To;
        private System.Windows.Forms.GroupBox GB_DateTime_From;
        private System.Windows.Forms.GroupBox GB_FirsChoice;
        private System.Windows.Forms.Label LAB_ResultsCount;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.ComponentModel.BackgroundWorker BW_Worker;
    }
}

