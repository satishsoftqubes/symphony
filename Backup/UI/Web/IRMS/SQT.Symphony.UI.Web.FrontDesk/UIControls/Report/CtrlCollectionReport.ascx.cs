using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlCollectionReport : System.Web.UI.UserControl
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
                rdoSummary.Checked = true;
                rdoDetail_CheckedChanged(null, null);
                BindCounter();
                BindGeneralType();
                BindPaymentMode();
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
            ddlCounter.DataSource = CountersBLL.GetAll();
            ddlCounter.DataTextField = "CounterNo";
            ddlCounter.DataValueField = "CounterID";
            ddlCounter.DataBind();
            ddlCounter.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));          
        }

        /// <summary>
        /// Load GeneralType
        /// </summary>
        private void BindGeneralType()
        {
            ddlGeneralIDType.DataSource = BookKeepingBLL.GetDistinctGeneralType();
            ddlGeneralIDType.DataTextField = "GeneralIDType_Term";
            ddlGeneralIDType.DataValueField = "GeneralIDType_Term";
            ddlGeneralIDType.DataBind();
            ddlGeneralIDType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Payment Mode
        /// </summary>
        private void BindPaymentMode()
        {
            DataView dv = new DataView(AccountBLL.GetAllWithDataSet().Tables[0]);
            dv.RowFilter = "IsMOPAccount = 'True' or IsPaidOut = 'True'";
            ddlPaymentMode.DataSource = dv;
            ddlPaymentMode.DataTextField = "AcctName";
            ddlPaymentMode.DataValueField = "AcctID";
            ddlPaymentMode.DataBind();
            ddlPaymentMode.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
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
                string strGeneralTermID = null;
                Guid? iPay = null;
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                
                if (!ddlGeneralIDType.SelectedValue.Equals(Guid.Empty.ToString()))
                    strGeneralTermID = Convert.ToString(ddlGeneralIDType.SelectedValue);
                if (!ddlCounter.SelectedValue.Equals(Guid.Empty.ToString()))
                    iCntID = (Guid?) new Guid(Convert.ToString(ddlCounter.SelectedValue));
                if (!ddlPaymentMode.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlPaymentMode.SelectedValue.Equals("")))
                    iPay = (Guid?)new Guid(Convert.ToString(ddlPaymentMode.SelectedValue));
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
                if (!ddlGeneralIDType.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlGeneralIDType.SelectedValue.Equals("")))
                    Session.Add("RptGenIDTyp", ddlGeneralIDType.SelectedItem.Text);
                if (!ddlPaymentMode.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlPaymentMode.SelectedValue.Equals("")))
                    Session.Add("RptPaymentMode", ddlPaymentMode.SelectedItem.Text);
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);
                TimeSpan span = ((DateTime)enddt).Subtract((DateTime)startdt);
                Session.Add("Days", (int)span.TotalDays);

                if (rdoSummary.Checked)
                    ds = BookKeepingBLL.GetRPTCollectionSummary_OnlySummary(clsSession.CompanyID, clsSession.PropertyID, null, iCntID, iPay, strGeneralTermID, startdt, enddt);
                else
                    ds = BookKeepingBLL.GetRPTCollectionSummary(clsSession.CompanyID, clsSession.PropertyID, null, iCntID, iPay, strGeneralTermID, startdt, enddt);
                
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

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
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
            if(rdoDetail.Checked)
                Session.Add("ReportName", "Collection Summary");
            else if(rdoSummary.Checked)
                Session.Add("ReportName", "Collection Detail Summary");
        }        
    }
}