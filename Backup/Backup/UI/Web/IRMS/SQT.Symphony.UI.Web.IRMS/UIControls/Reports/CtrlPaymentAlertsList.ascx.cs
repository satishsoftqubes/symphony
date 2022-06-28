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
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlPaymentAlertsList : System.Web.UI.UserControl
    {

        #region Variable
        public bool? IsPreview = false;
        public bool IsAlert = false;
        private User user;

        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }

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
            if (Request.QueryString["Val"] != null)
            {
                if(Convert.ToString(Request.QueryString["Val"]).Equals("Due"))
                    IsAlert = true;            
                else
                    IsAlert = false;
            }

            if (Session["CompanyID"] != null)
            {
                
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                if (Session["UserID"] != null)
                    user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));

                if (!IsPostBack)
                    LoadControlValue();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
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
                ddlInvestor.Enabled = true;
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    ProjectTerm objProjectTerm = new ProjectTerm();
                    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                    if (objProjectTerm != null)
                    {
                        calStartDate.Format = calEndDate.Format = objProjectTerm.Term;
                        this.DateFormat = objProjectTerm.Term;
                    }
                    else
                    {
                        calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                        this.DateFormat = "dd/MM/yyyy";
                    }
                }
                else
                {
                    calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                    this.DateFormat = "dd/MM/yyyy";
                }
                chkStartDate.Checked = chkEndDate.Checked = false;
                chkStartDate_CheckedChanged(null, null);
                chkEndDate_CheckedChanged(null, null);              
                BindProperty();
                BindInvestor();
                ddlInvestor_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Property
        /// </summary>
        private void BindProperty()
        {
            Property objProperty = new Property();
            objProperty.CompanyID = this.CompanyID;
            objProperty.IsActive = true;
            List<Property> lstProperty = PropertyBLL.GetAll(objProperty);
            lstProperty.Sort((Property p1, Property p2) => p1.PropertyName.CompareTo(p2.PropertyName));
            if (lstProperty.Count > 0)
            {
                ddlProperty.DataSource = lstProperty;
                ddlProperty.DataTextField = "PropertyName";
                ddlProperty.DataValueField = "PropertyID";
                ddlProperty.DataBind();
            }
            ddlProperty.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
           
        }

        /// <summary>
        /// Load Investor
        /// </summary>
        private void BindInvestor()
        {
            string InvestorQuery;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.Equals("Admin"))
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            else if (UserType.Equals("Investor"))
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "' And InvestorID = '" +  (Guid?)new Guid(Convert.ToString(Session["InvID"])) + "'");
            else
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1 And RelationShipManagerID = '" + user.UserTypeID + "'" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            DataSet dsInvestor = InvestorBLL.GetSearchData(InvestorQuery);

            if (dsInvestor.Tables[0].Rows.Count != 0)
            {
                DataView dvInvestor = new DataView(dsInvestor.Tables[0]);
                dvInvestor.Sort = "FullName Asc";
                ddlInvestor.DataSource = dvInvestor;
                ddlInvestor.DataTextField = "FullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            if (UserType.Equals("Investor"))
            {
                if(Session["InvID"] != null)
                {
                    ddlInvestor.SelectedValue = Convert.ToString(Session["InvID"]);
                    ddlInvestor.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {                  
                DataSet ds = new DataSet();
                Guid? idProperty = null;
                Guid? idInvestor = null;
                Guid? idUnit = null;                
                DateTime? startdt = null;
                DateTime? enddt = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!ddlProperty.SelectedValue.Equals(Guid.Empty.ToString()))
                    idProperty = new Guid(Convert.ToString(ddlProperty.SelectedValue));
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                    idInvestor = new Guid(Convert.ToString(ddlInvestor.SelectedValue));
                if (!ddlUnit.SelectedValue.Equals(Guid.Empty.ToString()))
                    idUnit = new Guid(Convert.ToString(ddlUnit.SelectedValue));
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (!ddlProperty.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Property", ddlProperty.SelectedItem.Text);                
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Investor", ddlInvestor.SelectedItem.Text);
                if (!ddlUnit.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Unit", ddlUnit.SelectedItem.Text);                
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);

                if (IsAlert)
                {
                    Session.Add("ReportName", "Payment Alert List");
                    string UserType = Convert.ToString(Session["UserType"]);
                    if (UserType.Equals("Admin") || UserType.Equals("Investor"))
                        ds = InvestorPaymentReceiptBLL.GetRptPaymentAlerts(idInvestor, startdt, enddt, idUnit, idProperty,null);
                    else
                        ds = InvestorPaymentReceiptBLL.GetRptPaymentAlerts(idInvestor, startdt, enddt, idUnit, idProperty,user.UserTypeID);
                }
                else
                {
                    Session.Add("ReportName", "Payment Receipt List");
                    string UserType = Convert.ToString(Session["UserType"]);
                    if (UserType.Equals("Admin") || UserType.Equals("Investor"))
                        ds = InvestorPaymentReceiptBLL.GetRptPaymentReceipt(idInvestor, startdt, enddt, idUnit, idProperty,null);
                    else
                        ds = InvestorPaymentReceiptBLL.GetRptPaymentReceipt(idInvestor, startdt, enddt, idUnit, idProperty,user.UserTypeID);
                }
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
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
            txtStartDate.Text = "";
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion

        #region DropDownList Event
        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    ddlUnit.Items.Clear();
                    DataSet dsUnit = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, new Guid(Convert.ToString(ddlInvestor.SelectedValue)), null,null,null);
                    if (dsUnit.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView(dsUnit.Tables[0]);
                        dv.Sort = "RoomNo";
                        ddlUnit.DataSource = dv;
                        ddlUnit.DataTextField = "RoomNo";
                        ddlUnit.DataValueField = "RoomID";
                        ddlUnit.DataBind();
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlUnit.Items.Clear();
                    List<Room> LstRoom = RoomBLL.GetAll();
                    if (LstRoom.Count > 0)
                    {
                        LstRoom.Sort((Room r1, Room r2) => r1.RoomNo.CompareTo(r2.RoomNo));
                        ddlUnit.DataSource = LstRoom;
                        ddlUnit.DataTextField = "RoomNo";
                        ddlUnit.DataValueField = "RoomID";
                        ddlUnit.DataBind();
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                    }
                    else
                        ddlUnit.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}