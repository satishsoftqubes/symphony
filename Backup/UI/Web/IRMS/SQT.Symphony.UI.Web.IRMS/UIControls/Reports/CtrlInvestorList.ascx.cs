using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlInvestorList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
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
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {
                if (RoleRightJoinBLL.GetAccessString("RPTInvestorList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                if (Session["UserID"] != null)
                    user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));

                if (!IsPostBack)
                    LoadDefaultValue();
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
        /// Load Default Control
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindOccupation();
                txtName.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtCompanyName.Text = "";
                txtCity.Text = "";               
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Occupation
        /// </summary>
        private void BindOccupation()
        {
            ProjectTerm termOcc = new ProjectTerm();
            termOcc.CompanyID = this.CompanyID;
            termOcc.Category = "OCCUPATION";
            termOcc.IsActive = true;
            List<ProjectTerm> lstTerm = ProjectTermBLL.GetAll(termOcc);
            ddlOccupation.DataSource = lstTerm;
            ddlOccupation.DataTextField = "DisplayTerm";
            ddlOccupation.DataValueField = "TermID";
            ddlOccupation.DataBind();
            ddlOccupation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Investor List");
                DataSet ds = new DataSet();
                string strName = null;
                string strMobileNo = null;
                string strEmail = null;
                string strCity = null;             
                string strCompName = null;
                Guid? idOccupation = null;

                if (!txtName.Text.Equals(""))
                    strName = '%' + txtName.Text.Trim() + '%';
                if (!txtMobile.Text.Equals(""))
                    strMobileNo = txtMobile.Text.Trim();
                if (!txtEmail.Text.Equals(""))
                    strEmail = txtEmail.Text.Trim();
                if (!txtCity.Text.Equals(""))
                    strCity = txtCity.Text.Trim();               
                if (!ddlOccupation.SelectedValue.Equals(Guid.Empty.ToString()))
                    idOccupation = new Guid(Convert.ToString(ddlOccupation.SelectedValue));
                if (!txtCompanyName.Text.Equals(""))
                    strCompName = '%' + txtCompanyName.Text.Trim() + '%';

                if (!txtName.Text.Equals(""))
                    Session.Add("Name", txtName.Text.Trim());
                Session.Add("Mobile", strMobileNo);
                Session.Add("Email", strEmail);
                Session.Add("City", strCity);
                if (!ddlOccupation.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Occupation", ddlOccupation.SelectedItem.Text);
                if (!txtCompanyName.Text.Equals(""))
                    Session.Add("Company", txtCompanyName.Text.Trim());

                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.Equals("Admin"))
                    ds = InvestorBLL.GetRptInvestorList(strName, strMobileNo, strEmail, idOccupation, null, null, strCity, strCompName, null);
                else
                    ds = InvestorBLL.GetRptInvestorList(strName, strMobileNo, strEmail, idOccupation, null, null, strCity, strCompName, user.UserTypeID);
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

        #region Button Event
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
    }
}