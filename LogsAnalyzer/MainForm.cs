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
using System.Threading;

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
            while(!TestConnection(dcdc.Connection))
            {   
            retry:
                ConnectionStringInput connStrForm = new ConnectionStringInput();
                if (connStrForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)                
                    Environment.Exit(0);
                try
                {
                    dcdc.Connection.ConnectionString = ConnectionStringInput.ConnectionString;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Provided connection string is in wrong format!" + Environment.NewLine + "Details:" + Environment.NewLine + e.Message, "Logs Analyzer - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto retry;
                }
            }

            setGroupBoxes();

            CB_FirstChoice.DataSource = Enum.GetValues(typeof(Entities));
            CB_FirstChoice.SelectedItem = null;
            CB_FirstChoice.Text = "Select Entity...";
            
            DTP_From.Value = DTP_From.Value = DateTime.Now.AddYears(-2);
            DTP_To.Value = DTP_To.Value = DateTime.Now.Date;

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

        private bool TestConnection(System.Data.Common.DbConnection dbConnection)
        {
            try
            {
                dbConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Can not connect to database." + Environment.NewLine + "Details:" + Environment.NewLine + e.Message, "Logs Analyzer - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                dbConnection.Close();                
            }
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
                BeginInvoke((MethodInvoker)delegate
                {

                    if ((Entities)CB_FirstChoice.SelectedItem == Entities.Users)
                    {
                        if (!DGV_Display.Columns.Contains("Report"))
                            AddReportColumn();
                    }
                    else
                        RemoveReportColumn();

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
                                         where checkedUsers.Contains(evnt.EventUserId.ToString())
                                         where checkedEventServices.Contains(evnt.EventServiceId.ToString())
                                         where checkedEventTypes.Contains(evnt.EventTypeId.ToString())                                        
                                         where checkedApplications.Contains(evnt.EventAppId.ToString())                                         
                                         select new { evnt.EventId, evnt.EventDate, evnt.EventDate.TimeOfDay, evnt.EventType.EventTypeName, evnt.EventService.ServiceName, evnt.application.AppName, evnt.User.UserName, evnt.Customer.CustomerName }
                                             into anon //continous query with the results of the previous one
                                             orderby anon.EventDate descending
                                             select anon).ToList(); 
                    else
                        if ((Entities)CB_FirstChoice.SelectedItem == Entities.Applications)
                            bs.DataSource = (from app in dcdc.applications
                                             join cstmr in dcdc.Customers on app.CustomerId equals cstmr.CustomerId
                                             where checkedApplications.Contains(app.AppId.ToString())
                                             select new { app.AppId, app.AppName, app.AppDescription, app.AppAddress, cstmr.CustomerName }).ToList();
                        else
                            if ((Entities)CB_FirstChoice.SelectedItem == Entities.Customer)
                                bs.DataSource = (from cstmr in dcdc.Customers
                                                 select new { cstmr.CustomerId, cstmr.CustomerName, cstmr.CustomerDescrption }).ToList();
                            else
                                if ((Entities)CB_FirstChoice.SelectedItem == Entities.Users)
                                    bs.DataSource = (from usr in dcdc.Users
                                                     where checkedUsers.Contains(usr.UserId.ToString())
                                                     select new { usr.UserId, usr.UserName, usr.UserDescription }).ToList();
                                else
                                    if ((Entities)CB_FirstChoice.SelectedItem == Entities.EventTypes)
                                        bs.DataSource = (from et in dcdc.EventTypes
                                                         where checkedEventTypes.Contains(et.EventTypeId.ToString())
                                                         select new { et.EventTypeId, et.EventTypeName, et.EventTypePriority, et.EventTypeDescription }).ToList();
                                    else
                                        if ((Entities)CB_FirstChoice.SelectedItem == Entities.EventService)
                                            bs.DataSource = (from es in dcdc.EventServices
                                                             where checkedEventServices.Contains(es.ServiceId.ToString())
                                                             select new { es.ServiceId, es.ServiceName, es.Service_Description }).ToList();


                    DGV_Display.DataSource = bs;


                    foreach (DataGridViewColumn col in DGV_Display.Columns)
                        col.ReadOnly = true;

                    foreach (DataGridViewColumn col in DGV_Display.Columns)
                    {
                        if (col.Name.EndsWith("Id"))
                            col.Visible = false;
                        col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);
                    }
                    LAB_ResultsCount.Text = "Number of results: " + DGV_Display.RowCount.ToString();

                });
            }
        }

        private void RemoveReportColumn()
        {
            if(DGV_Display.Columns.Contains("Report"))
                DGV_Display.Columns.Remove("Report");
        }

        private void AddReportColumn()
        {
            var bt_col = new DataGridViewImageColumn();
            bt_col.DataPropertyName = "Report";
            bt_col.HeaderText = "Report";
            bt_col.Name = "Report";
            bt_col.Image = LogsAnalyzer.Properties.Resources.market_report_icon;
            bt_col.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DGV_Display.Columns.Add(bt_col);
            DGV_Display.CellMouseClick += new DataGridViewCellMouseEventHandler(DGV_Display_CellMouseClick);
            DGV_Display.CellMouseEnter += new DataGridViewCellEventHandler(DGV_Display_CellMouseEnter);
            DGV_Display.CellMouseLeave += new DataGridViewCellEventHandler(DGV_Display_CellMouseLeave);

        }

        void DGV_Display_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                if (DGV_Display.Columns[e.ColumnIndex].Name == "Report")
                    (DGV_Display.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewImageCell).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        void DGV_Display_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0 && e.ColumnIndex>=0)
                if (DGV_Display.Columns[e.ColumnIndex].Name == "Report")
                    (DGV_Display.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewImageCell).ImageLayout = DataGridViewImageCellLayout.Normal; //(DGV_Display.Columns[e.ColumnIndex] as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom; //LogsAnalyzer.Properties.Resources.market_report_icon;

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
                LoadData();
        }
#endregion

#region Filter_SearchTextBoxEvents
        private void STB_Filter_EventTypes_TextChanged(object sender, EventArgs e)
        {
            CLB_EventTypes.SelectedItem = CLB_EventTypes.Items.Cast<EventType>().Where(et => et.EventTypeName.Contains(STB_Filter_EventTypes.Text)).FirstOrDefault();
        }

        private void STB_Filter_EventServices_TextChanged(object sender, EventArgs e)
        {
            CLB_EventServices.SelectedItem = CLB_EventServices.Items.Cast<EventService>().Where(es => es.ServiceName.Contains(STB_Filter_EventServices.Text)).FirstOrDefault();
        }

        private void STB_Filter_Applications_TextChanged(object sender, EventArgs e)
        {
            CLB_Applications.SelectedItem = CLB_Applications.Items.Cast<application>().Where(app => app.AppName.Contains(STB_Filter_Applications.Text)).FirstOrDefault();
        }
        
        private void STB_Filter_Users_TextChanged(object sender, EventArgs e)
        {
            CLB_Users.SelectedItem = CLB_Users.Items.Cast<User>().Where(usr => usr.UserName.Contains(STB_Filter_Users.Text)).FirstOrDefault();
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

        Loader loaderForm;
        Report reportForm;
        void DGV_Display_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex != -1 && e.RowIndex != -1)
                if (DGV_Display.Columns[e.ColumnIndex].Name == "Report")
                {
                    loaderForm = new Loader();
                    BW_Worker.RunWorkerAsync(e.RowIndex);
                    loaderForm.ShowDialog();
                    reportForm.Show();
                }
        }

        private void BW_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {                                                
                foreach (DataGridViewColumn col in DGV_Display.Columns)
                    if (col.Name.EndsWith("Id"))
                    {
                        if ((Entities)CB_FirstChoice.SelectedItem == Entities.Users) //just to be sure
                            e.Result = (User)(from usr in dcdc.Users
                                            where usr.UserId == (int)DGV_Display.Rows[(int)e.Argument].Cells[col.Index].Value
                                            select usr).FirstOrDefault();
                        break;
                    }
            });

            if (e.Result != null)
            {
                reportForm = new Report(dcdc, e.Result as User);
            }
            else
                MessageBox.Show("Can not create a report for this user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }        
        private void BW_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loaderForm.Dispose();            
        }
    }
}
