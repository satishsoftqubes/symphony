using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlChannelPartnerList : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        private User user;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("RPTChannelPartnerList.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            if (Session["UserID"] != null)
                user = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));      

            if (!IsPostBack)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                txtName.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtCompanyName.Text = "";
                txtCity.Text = "";
            }
        }

        #region Private Method
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Channel Partner List");
                DataSet ds = new DataSet();
                string strName = null;
                string strMobileNo = null;
                string strEmail = null;
                string strCity = null;
                string strCompName = null;                

                if (!txtName.Text.Equals(""))
                    strName = '%' + txtName.Text.Trim() + '%';
                if (!txtMobile.Text.Equals(""))
                    strMobileNo = txtMobile.Text.Trim();
                if (!txtEmail.Text.Equals(""))
                    strEmail = txtEmail.Text.Trim();
                if (!txtCity.Text.Equals(""))
                    strCity = txtCity.Text.Trim();
                if (!txtCompanyName.Text.Equals(""))
                    strCompName = '%' + txtCompanyName.Text.Trim() + '%';
                
                if (!txtName.Text.Equals(""))
                    Session.Add("Name", txtName.Text.Trim());
                Session.Add("City", strCity);                
                Session.Add("MobileNo", strMobileNo);
                Session.Add("Email", strEmail);
                if (!txtCompanyName.Text.Equals(""))
                    Session.Add("CompName", txtCompanyName.Text.Trim());
                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.Equals("Admin"))
                    ds = ChannelPartnerBLL.GetRptChannelPartnerList(strName, strMobileNo, strEmail, strCompName, null, null, strCity, null);
                else
                    ds = ChannelPartnerBLL.GetRptChannelPartnerList(strName, strMobileNo, strEmail, strCompName, null, null, strCity, user.UserTypeID);
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