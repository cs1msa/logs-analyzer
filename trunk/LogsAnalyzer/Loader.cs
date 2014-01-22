using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LogsAnalyzer
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
            this.L_Loader.Text = "Generating Report";
            Timer.Start();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel1.Dock = DockStyle.None;
            panel1.Location = new Point(2, 2);
            panel1.Width = this.Width - 4;            
            panel1.Height = this.Height - 4;
        }

        private int tickCounter = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.L_Loader.Text += ".";         
            if(tickCounter % 4 == 0)
                this.L_Loader.Text = "Generating Report";                            
            tickCounter++;
        }
    }
}
