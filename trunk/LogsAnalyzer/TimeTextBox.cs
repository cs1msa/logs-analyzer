using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

namespace LogsAnalyzer
{
    public class TimeTextBox : TextBox
    {
        private string timeSeparator = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
        private readonly string timeFormat = @"hh\:mm\:ss";

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if(!(e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
                if (this.Text.Length != 0 && this.Text.Length < 8)
                    if ( (this.Text[this.Text.Length-1] != timeSeparator[0] ) && (this.Text.Length - this.Text.Count(c => c == timeSeparator[0])) % 2 == 0)
                    {
                        this.Text += timeSeparator;
                        this.Select(this.Text.Length, 0);
                    }
        
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            string keyInput = e.KeyChar.ToString();

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b') // backspace is ok
            {
                e.Handled = true;
            }
            else
                if (this.Text.Length > 7)
                    if(e.KeyChar != '\b')
                        e.Handled = true;
        }

        public TimeSpan Time
        {
            get
            {
                return TimeSpan.ParseExact(this.Text, timeFormat, CultureInfo.CurrentCulture);
            }
        }


        internal void SetTime(TimeSpan timeSpan)
        {
            this.Text = "";
            this.Text = timeSpan.ToString(timeFormat);
        }
    }
}
