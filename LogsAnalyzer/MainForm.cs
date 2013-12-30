using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.Linq.SqlClient;

namespace LogsAnalyzer
{
    public partial class MainForm : Form
    {
        public static readonly string connectionString = "Data Source=locationapp.mssql.somee.com;Initial Catalog=locationapp;User ID=delprzemo_SQLLogin_1;Password=qwert12345";
        public DataClassesDataContext dcdc;

        public enum Entities
        {
            EventService = 0x00,
            Events = 0x01,
            Applications = 0x02,
            EventTypes = 0x04,
            Users = 0x08,
            Customer = 0x10
        }

        private bool _setupCompleted = false;
        private List<GroupBox> _groupBoxes;
        private List<string> _eventIDs = new List<string>();

        public MainForm()
        {
            InitializeComponent();
                        
            dcdc = new DataClassesDataContext(connectionString);

            setGroupBoxes();

            CB_FirstChoice.DataSource = Enum.GetValues(typeof(Entities));
            CB_FirstChoice.SelectedItem = null;
            CB_FirstChoice.Text = "Select Category...";
            
            DTP_From.Value = DateTime.Now.Date.AddYears(-250); //DTP_From.Value = DateTime.Now.Date.AddDays(-7);
            DTP_To.Value = DateTime.Now.Date.AddYears(300);  //DTP_To.Value = DateTime.Now.Date;

            CLB_EventTypes.Items.AddRange((from et in dcdc.EventTypes select et).ToArray());
            CLB_EventTypes.DisplayMember = "EventTypeName";

            CLB_EventServices.Items.AddRange((from es in dcdc.EventServices select es).ToArray());
            CLB_EventServices.DisplayMember = "ServiceName";

            CLB_Applications.Items.AddRange((from app in dcdc.applications select app).ToArray());
            CLB_Applications.DisplayMember = "AppName";

            CLB_Users.Items.AddRange((from usr in dcdc.Users select usr).ToArray());
            CLB_Users.DisplayMember = "UserName";            

            TTB_From.SetTime(DateTime.Now.TimeOfDay);
            TTB_To.SetTime(DateTime.Now.TimeOfDay);

            
            SetToolTips();
            _setupCompleted = true;
        }

        private void CB_FirstChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            _groupBoxes.ForEach(gb => gb.Enabled = false);

            if (CB_FirstChoice.SelectedItem != null)
            {
                if ((Entities)CB_FirstChoice.SelectedItem == Entities.Events)
                    _groupBoxes.ForEach(gb => gb.Enabled = true);
                else
                    if ((Entities)CB_FirstChoice.SelectedItem == Entities.Applications)
                        _groupBoxes.Where(gb => gb.Name == GB_Applications.Name).First().Enabled = true;
                    else
                        if ((Entities)CB_FirstChoice.SelectedItem == Entities.Users)
                            _groupBoxes.Where(gb => gb.Name == GB_Users.Name).First().Enabled = true;
                        else
                            if ((Entities)CB_FirstChoice.SelectedItem == Entities.EventService)
                                _groupBoxes.Where(gb => gb.Name == GB_EventServices.Name).First().Enabled = true;
                            else
                                if ((Entities)CB_FirstChoice.SelectedItem == Entities.EventTypes)
                                    _groupBoxes.Where(gb => gb.Name == GB_EventTypes.Name).First().Enabled = true;                

                LoadData();
            }
        }

        private void LoadData()
        {
            if (_setupCompleted)
            {
                if (!DGV_Display.Columns.Contains("Select"))
                    AddSelectColumn();

                DateTime DateTimeFrom = DTP_From.Value.AddTicks(TTB_From.Time.Ticks);
                DateTime DateTimeTo = DTP_To.Value.AddTicks(TTB_To.Time.Ticks);

                List<string> checkedEventTypes = new List<string>();
                foreach (var id in CLB_EventTypes.CheckedItems)
                    checkedEventTypes.Add(((EventType)id).EventTypeId.ToString());

                List<string> checkedEventServices = new List<string>();
                foreach (var serv in CLB_EventServices.CheckedItems)
                    checkedEventServices.Add(((EventService)serv).ServiceId.ToString());

                List<string> checkedApplications = new List<string>();
                foreach (var app in CLB_Applications.CheckedItems)
                    checkedApplications.Add(((application)app).AppId.ToString());

                List<string> checkedUsers = new List<string>();
                foreach (var usr in CLB_Users.CheckedItems)
                    checkedUsers.Add(((User)usr).UserId.ToString());

                BindingSource bs = new BindingSource();
                if ((Entities)CB_FirstChoice.SelectedItem == Entities.Events)
                    bs.DataSource = (from evnt in dcdc.Events
                                     where evnt.EventDate >= DateTimeFrom
                                     where evnt.EventDate <= DateTimeTo
                                     where checkedEventTypes.Contains(evnt.EventTypeId.ToString())
                                     where checkedEventServices.Contains(evnt.EventServiceId.ToString())
                                     where checkedApplications.Contains(evnt.EventAppId.ToString())
                                     where checkedUsers.Contains(evnt.EventUserId.ToString())
                                     select new { evnt.EventDate, evnt.EventDate.TimeOfDay, evnt.EventType.EventTypeName, evnt.EventService.ServiceName, evnt.application.AppName, evnt.User.UserName}).ToList();
                else
                    if ((Entities)CB_FirstChoice.SelectedItem == Entities.Applications)
                        bs.DataSource = (from app in dcdc.applications
                                         join cstmr in dcdc.Customers on app.CustomerId equals cstmr.CustomerId
                                         where checkedApplications.Contains(app.AppId.ToString())
                                         select new { app.AppName, app.AppDescription, app.AppAddress, cstmr.CustomerName }).ToList();
                    else
                        if ((Entities)CB_FirstChoice.SelectedItem == Entities.Customer)
                            bs.DataSource = (from cstmr in dcdc.Customers
                                             select new { cstmr.CustomerName, cstmr.CustomerDescrption }).ToList();
                        else
                            if ((Entities)CB_FirstChoice.SelectedItem == Entities.Users)
                                bs.DataSource = (from usr in dcdc.Users
                                                 where checkedUsers.Contains(usr.UserId.ToString())
                                                 select new { usr.UserName, usr.UserDescription }).ToList();
                            else
                                if ((Entities)CB_FirstChoice.SelectedItem == Entities.EventTypes)
                                    bs.DataSource = (from et in dcdc.EventTypes
                                                     where checkedEventTypes.Contains(et.EventTypeId.ToString())
                                                     select new { et.EventTypeName, et.EventTypePriority, et.EventTypeDescription }).ToList();
                                else
                                    if ((Entities)CB_FirstChoice.SelectedItem == Entities.EventService)
                                        bs.DataSource = (from es in dcdc.EventServices
                                                         where checkedEventServices.Contains(es.ServiceId.ToString())
                                                         select new { es.ServiceName, es.Service_Description }).ToList();


                DGV_Display.DataSource = bs;
                foreach (DataGridViewColumn col in DGV_Display.Columns)
                    col.ReadOnly = true;

                DGV_Display.Columns["Select"].ReadOnly = false;

                foreach(DataGridViewColumn col in DGV_Display.Columns)
                    col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);

                LAB_ResultsCount.Text = "Number of results: " + DGV_Display.RowCount.ToString();
            }
        }

        private void AddSelectColumn()
        {
            var cb_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            cb_col.DataPropertyName = "Select";
            cb_col.HeaderText = "Select";
            cb_col.Name = "Select";
            cb_col.FalseValue = "0";
            cb_col.TrueValue = "1";
            DGV_Display.Columns.Add(cb_col);
        }

        private void DTP_From_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DTP_To_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

#region Initialization_Functions
        private void SetToolTips()
        {
            ToolTip TT_CheckAll = new System.Windows.Forms.ToolTip();
            string TT_CheckAll_Message = "Check/Uncheck all";
            TT_CheckAll.SetToolTip(BT_TickAll_Applications, TT_CheckAll_Message);
            TT_CheckAll.SetToolTip(BT_TickAll_EventServices, TT_CheckAll_Message);
            TT_CheckAll.SetToolTip(BT_TickAll_EventTypes, TT_CheckAll_Message);
            TT_CheckAll.SetToolTip(BT_TickAll_Users, TT_CheckAll_Message);
        }
        private void setGroupBoxes()
        {
            _groupBoxes = new List<GroupBox>();
            _groupBoxes.Add(GB_Applications);
            _groupBoxes.Add(GB_EventServices);
            _groupBoxes.Add(GB_EventTypes);
            _groupBoxes.Add(GB_Users);
            _groupBoxes.Add(GB_DateTime_From);
            _groupBoxes.Add(GB_DateTime_To);
        }
#endregion

#region Filter_CheckedListboxEvents
        private void CLB_EventTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clb_ItemCheck();
        }

        private void CLB_EventServices_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clb_ItemCheck();
        }
        
        private void CLB_Applications_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clb_ItemCheck();
        }

        private void CLB_Users_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clb_ItemCheck();
        }
        private void clb_ItemCheck()
        {
            if (!tickall)
                this.BeginInvoke((MethodInvoker)delegate  // workaround for lack of ItemChecked event for CheckedListBox control
                {
                    LoadData();
                });
        }
#endregion

#region Filter_SearchTextBoxEvents
        private void STB_Filter_EventTypes_TextChanged(object sender, EventArgs e)
        {
            CLB_EventTypes.SelectedItem = CLB_EventTypes.Items.Cast<EventType>().Where(et => et.EventTypeName.StartsWith(STB_Filter_EventTypes.Text)).FirstOrDefault();
        }

        private void STB_Filter_EventServices_TextChanged(object sender, EventArgs e)
        {
            CLB_EventServices.SelectedItem = CLB_EventServices.Items.Cast<EventService>().Where(es => es.ServiceName.StartsWith(STB_Filter_EventServices.Text)).FirstOrDefault();
        }

        private void STB_Filter_Applications_TextChanged(object sender, EventArgs e)
        {
            CLB_Applications.SelectedItem = CLB_Applications.Items.Cast<application>().Where(app => app.AppName.StartsWith(STB_Filter_Applications.Text)).FirstOrDefault();
        }
        
        private void STB_Filter_Users_TextChanged(object sender, EventArgs e)
        {
            CLB_Users.SelectedItem = CLB_Users.Items.Cast<User>().Where(usr => usr.UserName.StartsWith(STB_Filter_Users.Text)).FirstOrDefault();
        }
#endregion

#region Filter_TickAllButtonEvents
        bool tickall = false;

        private bool _toggleApp = true;
        private void BT_TickAll_Applications_Click(object sender, EventArgs e)
        {
            tickAll_Click(CLB_Applications, ref _toggleApp);
        }

        private bool _toggleEvntSrvcs = true;
        private void BT_TickAll_EventServices_Click(object sender, EventArgs e)
        {
            tickAll_Click(CLB_EventServices, ref _toggleEvntSrvcs);
        }

        private bool _toggleEvntTp = true;
        private void BT_TickAll_EventTypes_Click(object sender, EventArgs e)
        {
            tickAll_Click(CLB_EventTypes, ref _toggleEvntTp);
        }

        private bool _toggleUsr = true;
        private void BT_TickAll_Users_Click(object sender, EventArgs e)
        {
            tickAll_Click(CLB_Users, ref _toggleUsr);
        }

        private void tickAll_Click(CheckedListBox clb, ref bool state)
        {
            tickall = true; // <workaround>
            for (int i = 0; i < clb.Items.Count; i++)
                clb.SetItemChecked(i, state);
            LoadData();
            tickall = false; // </workaround>
            state = !state;
        }
#endregion
    }
}
