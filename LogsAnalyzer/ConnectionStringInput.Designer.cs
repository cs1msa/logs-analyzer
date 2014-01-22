namespace LogsAnalyzer
{
    partial class ConnectionStringInput
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
            this.TB_ConnectionString = new System.Windows.Forms.TextBox();
            this.BT_Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_ConnectionString
            // 
            this.TB_ConnectionString.Location = new System.Drawing.Point(12, 13);
            this.TB_ConnectionString.Name = "TB_ConnectionString";
            this.TB_ConnectionString.Size = new System.Drawing.Size(438, 20);
            this.TB_ConnectionString.TabIndex = 0;
            this.TB_ConnectionString.Text = "Paste connection string here...";
            this.TB_ConnectionString.TextChanged += new System.EventHandler(this.TB_ConnectionString_TextChanged);
            // 
            // BT_Confirm
            // 
            this.BT_Confirm.Location = new System.Drawing.Point(456, 11);
            this.BT_Confirm.Name = "BT_Confirm";
            this.BT_Confirm.Size = new System.Drawing.Size(75, 23);
            this.BT_Confirm.TabIndex = 1;
            this.BT_Confirm.Text = "Confirm";
            this.BT_Confirm.UseVisualStyleBackColor = true;
            this.BT_Confirm.Click += new System.EventHandler(this.BT_Confirm_Click);
            // 
            // ConnectionStringInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 45);
            this.Controls.Add(this.BT_Confirm);
            this.Controls.Add(this.TB_ConnectionString);
            this.Name = "ConnectionStringInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs Analyzer - Connection string input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_ConnectionString;
        private System.Windows.Forms.Button BT_Confirm;
    }
}