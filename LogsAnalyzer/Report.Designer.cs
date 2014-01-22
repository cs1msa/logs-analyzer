namespace LogsAnalyzer
{
    partial class Report
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
            this.FLP_MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SC_First = new System.Windows.Forms.SplitContainer();
            this.SC_Second = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.SC_First)).BeginInit();
            this.SC_First.Panel1.SuspendLayout();
            this.SC_First.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_Second)).BeginInit();
            this.SC_Second.Panel1.SuspendLayout();
            this.SC_Second.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLP_MainPanel
            // 
            this.FLP_MainPanel.BackColor = System.Drawing.Color.White;
            this.FLP_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.FLP_MainPanel.Name = "FLP_MainPanel";
            this.FLP_MainPanel.Size = new System.Drawing.Size(364, 364);
            this.FLP_MainPanel.TabIndex = 0;
            // 
            // SC_First
            // 
            this.SC_First.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_First.Location = new System.Drawing.Point(0, 0);
            this.SC_First.Name = "SC_First";
            this.SC_First.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_First.Panel1
            // 
            this.SC_First.Panel1.Controls.Add(this.SC_Second);
            this.SC_First.Size = new System.Drawing.Size(883, 626);
            this.SC_First.SplitterDistance = 364;
            this.SC_First.TabIndex = 1;
            // 
            // SC_Second
            // 
            this.SC_Second.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_Second.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SC_Second.Location = new System.Drawing.Point(0, 0);
            this.SC_Second.Name = "SC_Second";
            // 
            // SC_Second.Panel1
            // 
            this.SC_Second.Panel1.Controls.Add(this.FLP_MainPanel);
            this.SC_Second.Size = new System.Drawing.Size(883, 364);
            this.SC_Second.SplitterDistance = 364;
            this.SC_Second.TabIndex = 0;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(883, 626);
            this.Controls.Add(this.SC_First);
            this.Name = "Report";
            this.Text = "Report";
            this.SC_First.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_First)).EndInit();
            this.SC_First.ResumeLayout(false);
            this.SC_Second.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_Second)).EndInit();
            this.SC_Second.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FLP_MainPanel;
        private System.Windows.Forms.SplitContainer SC_First;
        private System.Windows.Forms.SplitContainer SC_Second;

    }
}