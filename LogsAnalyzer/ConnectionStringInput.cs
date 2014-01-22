using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogsAnalyzer
{
    public partial class ConnectionStringInput : Form
    {
        public static string ConnectionString;
        public ConnectionStringInput()
        {
            InitializeComponent();
            BT_Confirm.Enabled = false;
        }

        private void BT_Confirm_Click(object sender, EventArgs e)
        {
            ConnectionString = TB_ConnectionString.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void TB_ConnectionString_TextChanged(object sender, EventArgs e)
        {
            if (TB_ConnectionString.Text.Contains(';')) // veeeery simple validation
                BT_Confirm.Enabled = true;
            else
                BT_Confirm.Enabled = false;
        }

    }
}
