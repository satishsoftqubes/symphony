using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlSalesList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        private User user;
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("RPTSalesList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            if (Session["UserID"] != null)           
                user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));
            if (!IsPostBack)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                txtName.Text = "";
                txtDisplayName.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtCity.Text = "";
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Sales List");
                DataSet ds = new DataSet();
                string strName = null;
                string strDisplayName = null;
                string strMobileNo = null;
                string strEmail = null;
                string strCity = null;

                if (!txtName.Text.Equals(""))
                    strName = '%' + txtName.Text.Trim() + '%';
                if (!txtDisplayName.Text.Equals(""))
                    strDisplayName = txtDisplayName.Text.Trim();
                if (!txtMobile.Text.Equals(""))
                    strMobileNo = txtMobile.Text.Trim();
                if (!txtEmail.Text.Equals(""))
                    strEmail = txtEmail.Text.Trim();
                if (!txtCity.Text.Equals(""))
                    strCity = txtCity.Text.Trim();

                if (!txtName.Text.Equals(""))
                    Session.Add("Name", txtName.Text.Trim());
                Session.Add("DisplayName", strDisplayName);    
                Session.Add("Mobile", strMobileNo);
                Session.Add("Email", strEmail);
                Session.Add("City", strCity);

                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.Equals("Admin"))
                    ds = SalesTeamBLL.GetRptSalesList(null, strName, strMobileNo, strEmail, strDisplayName, null, null, strCity);
                else
                    ds = SalesTeamBLL.GetRptSalesList(user.UsearID, strName, strMobileNo, strEmail, strDisplayName, null, null, strCity);
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
    }
}