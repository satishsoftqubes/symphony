using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlRoomRentAdvance : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadControlValue();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Load Control Value
        /// </summary>
        private void LoadControlValue()
        {
            try
            {
                //if (Session["PropertyConfigurationInfo"] != null)
                //{
                //    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                //    ProjectTerm objProjectTerm = new ProjectTerm();
                //    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                //    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                //    if (objProjectTerm != null)
                //    {
                //        calStartDate.Format = calEndDate.Format = objProjectTerm.Term;
                //        this.DateFormat = objProjectTerm.Term;
                //    }
                //    else
                //    {
                //        calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                //        this.DateFormat = "dd/MM/yyyy";
                //    }
                //}
                //else
                //{
                    calStartDate.Format = calEndDate.Format = "dd-MM-yyyy";
                    this.DateFormat = "dd-MM-yyyy";
                //}
                chkEndDate.Checked = false;
                chkEndDate_CheckedChanged(null, null);
                chkStartDate.Checked = true;
                chkStartDate_CheckedChanged(null, null);
                txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                BindCounter();
                BindCashier();
                rdoSummary.Checked = true;
                rdoDetail_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Counter
        /// </summary>
        private void BindCounter()
        {
            Counters objCnt = new Counters();
            objCnt.CompanyID = clsSession.CompanyID;
            objCnt.PropertyID = clsSession.PropertyID;
            objCnt.IsActive = true;

            List<Counters> LstCnt = CountersBLL.GetAll(objCnt);
            if (LstCnt.Count > 0)
            {
                LstCnt.Sort((Counters c1, Counters c2) => c1.CounterNo.CompareTo(c2.CounterNo));
                ddlCounter.DataSource = LstCnt;
                ddlCounter.DataTextField = "CounterNo";
                ddlCounter.DataValueField = "CounterID";
                ddlCounter.DataBind();
                ddlCounter.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlCounter.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Cashier
        /// </summary>
        private void BindCashier()
        {
            User objUsr = new User();
            objUsr.CompanyID = clsSession.CompanyID;
            objUsr.PropertyID = clsSession.PropertyID;
            objUsr.IsActive = true;
            ddlCashier.DataSource = UserBLL.GetAllWithDataSet(objUsr);
            ddlCashier.DataTextField = "UserName";
            ddlCashier.DataValueField = "UsearID";
            ddlCashier.DataBind();
            ddlCashier.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {                
                DataSet ds = new DataSet();
                Guid? iCntID = null;
                Guid? iUserID = null;
                Guid? iAcctID = null;
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;


                if (!ddlCounter.SelectedValue.Equals(Guid.Empty.ToString()))
                    iCntID = (Guid?)new Guid(Convert.ToString(ddlCounter.SelectedValue));
                if (!ddlCashier.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlCashier.SelectedValue.Equals("")))
                    iUserID = (Guid?)new Guid(Convert.ToString(ddlCashier.SelectedValue));
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }
                if (!ddlCounter.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("RptCounter", ddlCounter.SelectedItem.Text);
                if (!ddlCashier.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlCashier.SelectedValue.Equals("")))
                    Session.Add("RptCashier", ddlCashier.SelectedItem.Text);

                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);
                TimeSpan span = ((DateTime)enddt).Subtract((DateTime)startdt);
                Session.Add("Days", (int)span.TotalDays);
                List<Account> lstAcct = AccountBLL.GetAllBy(Account.AccountFields.SymphonyAcctID, 17);
                if (lstAcct.Count > 0)
                    iAcctID = lstAcct[0].AcctID;
                Session.Add("AcctID", iAcctID);

                if (rdoSummary.Checked)
                    ds = BookKeepingBLL.GetRPTRoomRentAdvance_4Summary(clsSession.CompanyID, clsSession.PropertyID, iCntID, iUserID, iAcctID, startdt, enddt);
                else
                    ds = BookKeepingBLL.GetRPTRoomRentAdvance(clsSession.CompanyID, clsSession.PropertyID, iCntID, iUserID, iAcctID, startdt, enddt);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }
        #endregion

        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;            
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion   
        
        protected void rdoDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetail.Checked)
                Session.Add("ReportName", "Room Rent Advance");
            else if (rdoSummary.Checked)
                Session.Add("ReportName", "Room Rent Advance Summary");
        }      
    }
}