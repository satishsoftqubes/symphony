using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlPaymentDueReport : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        private User user;

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

        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("RPTPaymentDueReport.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                    user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"]))); 

                LoadControlValue();
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
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
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
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
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
            DataSet ds = PropertyBLL.SelectData(this.CompanyID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlProperty.DataSource = dv;
                ddlProperty.DataTextField = "PropertyName";
                ddlProperty.DataValueField = "PropertyID";
                ddlProperty.DataBind();
                ddlProperty.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlProperty.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Investor
        /// </summary>
        private void BindInvestor()
        {
            string InvestorQuery;
            if (user.UserType.Equals("Admin"))
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            else
                InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1 And RelationShipManagerID like '" + user.UsearID + "'" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");            
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
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Payment Due Report");
                DataSet ds = new DataSet();
                Guid? propID = null;
                Guid? invID = null;
                Guid? rmID = null;
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!ddlProperty.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    propID = new Guid(Convert.ToString(ddlProperty.SelectedValue));
                    Session.Add("Property", ddlProperty.SelectedItem.Text);
                }
                if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
                {
                    invID = new Guid(Convert.ToString(ddlInvestor.SelectedValue));
                    Session.Add("Investor", ddlInvestor.SelectedItem.Text);
                }
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);

                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.Equals("Admin"))
                    ds = InvestorsUnitBLL.GetPaymentDueReport(invID, propID, null, startdt, enddt);
                else
                {
                    rmID = (Guid)Session["UserID"];
                    ds = InvestorsUnitBLL.GetPaymentDueReport(invID, propID, rmID, startdt, enddt);
                }
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
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
    }
}