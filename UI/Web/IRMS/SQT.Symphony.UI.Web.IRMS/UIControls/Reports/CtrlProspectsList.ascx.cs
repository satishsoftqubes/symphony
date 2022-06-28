using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlProspectsList : System.Web.UI.UserControl
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

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {
                if (RoleRightJoinBLL.GetAccessString("RPTProspectsList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                if (Session["UserID"] != null)
                    user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));

                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));       
                if(!IsPostBack)
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
                BindStatus();
                txtSProspectName.Text = "";
                txtLocation.Text = "";
                txtReference.Text = "";
                txtCompanyName.Text = "";
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Status
        /// </summary>
        private void BindStatus()
        {
            ProjectTerm termStatus = new ProjectTerm();
            termStatus.CompanyID = this.CompanyID;
            termStatus.Category = "PROSPECTSTATUS";
            termStatus.IsActive = true;
            List<ProjectTerm> lstTerm = ProjectTermBLL.GetAll(termStatus);
            ddlProspectStatus.DataSource = lstTerm;
            ddlProspectStatus.DataTextField = "DisplayTerm";
            ddlProspectStatus.DataValueField = "TermID";
            ddlProspectStatus.DataBind();
            ddlProspectStatus.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }       

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Prospects List");
                DataSet ds = new DataSet();
                string strName = null;
                string strRef = null;
                string strLocation = null;
                Guid? idStatus = null;
                string strCmp = null;              

                if (!txtSProspectName.Text.Equals(""))
                    strName = txtSProspectName.Text.Trim();
                if (!txtCompanyName.Text.Equals(""))
                    strCmp = txtCompanyName.Text.Trim();
                if (!txtReference.Text.Equals(""))
                    strRef = txtReference.Text.Trim();
                if (!txtLocation.Text.Equals(""))
                    strLocation = txtLocation.Text.Trim();                
                if (!ddlProspectStatus.SelectedValue.Equals(Guid.Empty.ToString()))
                    idStatus = new Guid(Convert.ToString(ddlProspectStatus.SelectedValue));

                Session.Add("Name",strName);
                Session.Add("City", strLocation);
                if (!ddlProspectStatus.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Status", ddlProspectStatus.SelectedItem.Text);
                Session.Add("Reference", strRef);                
                Session.Add("Region", strCmp);

                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.Equals("Admin"))
                    ds = ProspectsBLL.SearchInfo(null, null, null, strCmp, strName, idStatus, CompanyID, null, null, strLocation, strRef, null, null);
                else
                    ds = ProspectsBLL.SearchInfo(null, null, null, strCmp, strName, idStatus, CompanyID, null, user.UserTypeID, strLocation, strRef, null, null);
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
        /// <summary>
        /// Print Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {            
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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