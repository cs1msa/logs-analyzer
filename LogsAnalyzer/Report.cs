using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LogsAnalyzer
{
    public partial class Report : Form
    {
        private DataClassesDataContext dcdc;

        public Report()
        {
            InitializeComponent();
        }
        private Report(DataClassesDataContext dcdc)
            : this()
        {
            this.dcdc = dcdc;
            
        }
        public Report(DataClassesDataContext dcdc, User ent)
            :this(dcdc)
        {
            CreateReportForUser((ent as User));
        }


        private static Font HeaderFont = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10F, FontStyle.Bold);
        private static Font MainFont = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 9.5F, FontStyle.Regular);
        private static Font EventCountFont = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 45, FontStyle.Bold);
        private static readonly string LabelNewLine = Environment.NewLine + " ";
        private ComboBox CB_ApplicationsUsed;
        Label L_EventsCount;

        private void CreateReportForUser(User user)
        {
            this.Text = "User " + user.UserName;
            GroupBox GB_UpperLeft = new GroupBox();
            GB_UpperLeft.Size = new Size(176, 176);
            GB_UpperLeft.Text = "Summary";
            GB_UpperLeft.Font = HeaderFont;
            
            FlowLayoutPanel FLP_Summary = new FlowLayoutPanel();
            FLP_Summary.Dock = DockStyle.Fill;
            GB_UpperLeft.Controls.Add(FLP_Summary);
            Label L_UserName = new Label();
            L_UserName.Text = Environment.NewLine + "Username: " + user.UserName + LabelNewLine;
            L_UserName.Font = MainFont;
            L_UserName.AutoSize = true;

            var dates =(from evnt in dcdc.Events where evnt.User.UserId == user.UserId select evnt).OrderBy(e => e.EventDate).ToList();

            Label L_FirstActionDate = new Label();
            L_FirstActionDate.Text = string.Format("First activity at {0}", dates.Count > 0 ? dates.First().EventDate.ToString() : "No activities") + LabelNewLine;
            L_FirstActionDate.AutoSize = true;
            L_FirstActionDate.Font = MainFont;

            Label L_LastActionDate = new Label();
            L_LastActionDate.Text = string.Format("Last activity at {0}", dates.Count > 0 ? dates.Last().EventDate.ToString() : "No activities") + LabelNewLine;
            L_LastActionDate.AutoSize = true;
            L_LastActionDate.Font = MainFont;
            

            FLP_Summary.Controls.Add(L_UserName);
            L_UserName.MaximumSize = new Size(L_UserName.Parent.Width, 100);
            FLP_Summary.Controls.Add(L_FirstActionDate);            
            L_FirstActionDate.MaximumSize = new Size(L_FirstActionDate.Parent.Width, 100);
            FLP_Summary.Controls.Add(L_LastActionDate);
            L_LastActionDate.MaximumSize = new Size(L_LastActionDate.Parent.Width, 100);

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            GroupBox GB_UpperRight = new GroupBox();
            GB_UpperRight.Size = new Size(176, 176);
            GB_UpperRight.Text = "User Description";
            GB_UpperRight.Font = HeaderFont;

            RichTextBox RTB_UserDescription = new RichTextBox();
            RTB_UserDescription.Text = user.UserDescription;
            RTB_UserDescription.Dock = DockStyle.Fill;
            RTB_UserDescription.ReadOnly = true;
            RTB_UserDescription.Font = MainFont;
            GB_UpperRight.Controls.Add(RTB_UserDescription);
 
            FLP_MainPanel.Controls.Add(GB_UpperLeft);
            FLP_MainPanel.Controls.Add(GB_UpperRight);

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            GroupBox GB_LowerLeft = new GroupBox();
            GB_LowerLeft.Size = new Size(176, 176);
            GB_LowerLeft.Text = "Applications used";
            GB_LowerLeft.Font = HeaderFont;
            FlowLayoutPanel FLP_Applications = new FlowLayoutPanel();
            FLP_Applications.Dock = DockStyle.Fill;
            FLP_Applications.FlowDirection = FlowDirection.TopDown;
            GB_LowerLeft.Controls.Add(FLP_Applications);


            CB_ApplicationsUsed = new ComboBox();
            List<string> cb_items = (from evnt in dcdc.Events where evnt.User.UserId == user.UserId select evnt.application.AppName).Distinct().ToList();
            cb_items.Insert(0, "Overall");
            CB_ApplicationsUsed.Items.AddRange(cb_items.ToArray());
            CB_ApplicationsUsed.SelectedIndex = 0;

            Label L_ApplicationsUsedCount = new Label();
            L_ApplicationsUsedCount.Text = string.Format(Environment.NewLine + "In total: {0}", (cb_items.Count - 1)) + LabelNewLine;
            L_ApplicationsUsedCount.Font = MainFont;
            L_ApplicationsUsedCount.AutoSize = true;

            Label L_SelectApplication = new Label();
            L_SelectApplication.Font = MainFont;
            L_SelectApplication.Text = "Select:" + LabelNewLine;

            FLP_Applications.Controls.Add(L_ApplicationsUsedCount);
            FLP_Applications.Controls.Add(L_SelectApplication);
            FLP_Applications.Controls.Add(CB_ApplicationsUsed);

            CB_ApplicationsUsed.Size = new Size(CB_ApplicationsUsed.Parent.Width -8, 21);
            FLP_MainPanel.Controls.Add(GB_LowerLeft);

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------           

            GroupBox GB_LowerRight = new GroupBox();
            GB_LowerRight.Size = new Size(176, 176);
            GB_LowerRight.Text = "Events count";
            GB_LowerRight.Font = HeaderFont;
            L_EventsCount = new Label();
            L_EventsCount.AutoSize = true;            
            L_EventsCount.Text = (from evnt in dcdc.Events where evnt.User.UserId == user.UserId && 
                                ((string)CB_ApplicationsUsed.SelectedItem !="Overall" ? evnt.application.AppName == (string)CB_ApplicationsUsed.SelectedItem : true) select evnt).Count().ToString();
            L_EventsCount.Font = EventCountFont;
            L_EventsCount.BorderStyle = BorderStyle.FixedSingle;
            Panel P_EventsCount = new Panel();
            P_EventsCount.Dock = DockStyle.Fill;
            P_EventsCount.Controls.Add(L_EventsCount);

            GB_LowerRight.Controls.Add(P_EventsCount);
            FLP_MainPanel.Controls.Add(GB_LowerRight);
            AdjustLabelPosition(ref L_EventsCount);

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------           

            Chart pieEventTypes = CreatePieChart(GetLegend("Event Types", Docking.Right), new Title(string.Format("Parts of Event Types launched by user {0}", user.UserName), Docking.Top, new Font(
                new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10, FontStyle.Bold), Color.Black), GetUser_EventTypes(user,(string)CB_ApplicationsUsed.SelectedItem));
            SC_Second.Panel2.Controls.Add(pieEventTypes);

            Chart linearActivities = CreateLinearChart(GetLegend("Activities", Docking.Bottom), new Title(string.Format("Events count in time produced by user {0}", user.UserName), Docking.Top, new Font(
                new FontFamily(System.Drawing.Text.GenericFontFamilies.SansSerif), 10, FontStyle.Bold), Color.Black), GetUser_Activities(user, (string)CB_ApplicationsUsed.SelectedItem));
            SC_First.Panel2.Controls.Add(linearActivities);

            CB_ApplicationsUsed.SelectedValueChanged += (sender, e) => UpdateChart(sender, e, ref linearActivities, user);
            CB_ApplicationsUsed.SelectedValueChanged += (sender, e) => UpdateChart(sender, e, ref pieEventTypes, user);
        }


        private void AdjustLabelPosition(ref Label label)
        {
            label.Top = (int)((label.Parent.Height - label.Bounds.Height) / 2);
            label.Left = (int)((label.Parent.Width - label.Bounds.Width) / 2);
        }


        private void UpdateChart(object sender, EventArgs e, ref Chart chart, User user)
        {
            chart.Series[chart.Series[0].Name].Points.Clear();
            
            if(chart.Series[chart.Series[0].Name].ChartType == SeriesChartType.Pie)
                foreach (var entry in GetUser_EventTypes(user, (string)CB_ApplicationsUsed.SelectedItem))
                    chart.Series[chart.Series[0].Name].Points.AddXY(entry.Key, entry.Value);
            else
                foreach (var entry in GetUser_Activities(user, (string)CB_ApplicationsUsed.SelectedItem))            
                    chart.Series[chart.Series[0].Name].Points.AddXY(entry.Key, entry.Value);
            
            L_EventsCount.Text = (from evnt in dcdc.Events where evnt.User.UserId == user.UserId && 
                                 ((string)CB_ApplicationsUsed.SelectedItem != "Overall" ? evnt.application.AppName == (string)CB_ApplicationsUsed.SelectedItem : true) select evnt).Count().ToString();
            AdjustLabelPosition(ref L_EventsCount);
        }


        private Dictionary<string, int> GetUser_EventTypes(User user, string appname)
        {
            Dictionary<string,int> dpc = new Dictionary<string,int>();
            if (appname != "Overall")
                foreach (var et in dcdc.EventTypes)
                {
                    int count = (from e in dcdc.Events where e.EventTypeId == et.EventTypeId where e.User.UserId == user.UserId && e.application.AppName == appname select e).Count();
                    if(count > 0)
                        dpc.Add(et.EventTypeName, count);                
                }
            else
                foreach (var et in dcdc.EventTypes)
                {
                    int count = (from e in dcdc.Events where e.EventTypeId == et.EventTypeId where e.User.UserId == user.UserId select e).Count();
                    if (count > 0)
                        dpc.Add(et.EventTypeName, count);
                }
            return dpc;            
        }


        private Dictionary<DateTime, int> GetUser_Activities(User user, string appname)
        {
            Dictionary<DateTime, int> dpc = new Dictionary<DateTime, int>();
            List<Event> orderedEvents = new List<Event>( dcdc.Events.OrderBy(e => e.EventDate));
            List<Event> tempOrderedEvents = new List<Event>( dcdc.Events.OrderBy(e => e.EventDate));
            DateTime previous = DateTime.MinValue;
            
            if(appname != "Overall")
                for (DateTime date = orderedEvents.First().EventDate.Date; date < orderedEvents.Last().EventDate.Date; date = date.AddDays(1))
                {
                    int count = tempOrderedEvents.Where(ev => (ev.EventDate.Date == date && ev.User.UserId == user.UserId && ev.application.AppName == appname)).Count();
                    dpc.Add(date, count);
                    tempOrderedEvents.RemoveAll(ev => ev.EventDate.Date == date);
                }
            else
                for (DateTime date = orderedEvents.First().EventDate.Date; date < orderedEvents.Last().EventDate.Date; date = date.AddDays(1))
                {
                    int count = tempOrderedEvents.Where(ev => (ev.EventDate.Date == date && ev.User.UserId == user.UserId)).Count();
                    dpc.Add(date, count);
                    tempOrderedEvents.RemoveAll(ev => ev.EventDate.Date == date);
                }

            return dpc;
        }


        private Legend GetLegend(string title, Docking dock)
        {
            Legend legend = new Legend();
            legend.Title = title;
            legend.Docking = dock;
            legend.Alignment = StringAlignment.Center;
            return legend;
        }


        private Chart CreateLinearChart(Legend legend, Title title, Dictionary<DateTime, int> dpc)
        {
            var chart = new Chart();
            chart.Size = new Size(800, 250);
            chart.Titles.Add(title);
            var chartArea = new ChartArea();
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = "Number of events";
            series.ChartType = SeriesChartType.Line;

            chart.Legends.Add(legend);
            chart.Series.Add(series);

            foreach (var entry in dpc)            
                chart.Series["Number of events"].Points.AddXY(entry.Key, entry.Value);
            chart.Dock = DockStyle.Fill;
            return chart;
        }


        private Chart CreatePieChart(Legend legend, Title title, Dictionary<string, int> dpc)
        {
            var chart = new Chart();
            chart.Size = new Size(600, 450);
            chart.Titles.Add(title);
            var chartArea = new ChartArea();
            
            chart.ChartAreas.Add(chartArea);
            
            var series = new Series();
            series.Name = "series";
            series.ChartType = SeriesChartType.Pie;
            
            //chart.Legends.Add(legend);
            chart.Series.Add(series);

            foreach (var entry in dpc)
            {
                if(entry.Value > 0)
                    chart.Series["series"].Points.AddXY(entry.Key, entry.Value);
            }

            chart.Dock = DockStyle.Fill;
            return chart;     
        }
    }
}
