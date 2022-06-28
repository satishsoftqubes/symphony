using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace SQT.Symphony.UI.Web.Configuration
{
    public partial class UserModuleSelection : System.Web.UI.Page
    {
        #region Variable

        DataTable dtRole = new DataTable();

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.UserID == Guid.Empty || clsSession.UserID == null)
            {
                Session.Clear();
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                //Update with SVN
                LoadDefaultValue();

            }
        }

        #endregion Page Load

        #region Button Event

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSession.LogInLogID != Guid.Empty)
                {
                    LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                    objToUpdate.Logout = DateTime.Now;
                    LoginLogBLL.Update(objToUpdate);
                }

                string strUserType = clsSession.UserType.ToUpper();

                Session.Clear();
                if (strUserType == "SUPERADMIN" || strUserType == "ADMINISTRATOR")
                {
                    ////Response.Redirect("~/CompanyLogin.aspx");
                    Response.Redirect("~/Index.aspx");
                }
                else
                    Response.Redirect("~/Index.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkPMSSetup_Click(object sender, EventArgs e)
        {
            InsertLoginLogDetails();
            clsSession.SelectedModule = "PMS Admin Setup";
            Response.Redirect("~/GUI/Property/PropertySetup.aspx"); 
        }

        protected void lnkFrontDeskSetup_Click(object sender, EventArgs e)
        {
            InsertLoginLogDetails();
            clsSession.SelectedModule = "Front Desk Setup";
            if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
            {
                Response.Redirect("~/GUI/Property/CompanyList.aspx");
            }
            else
            {
                Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
            }
        }

        protected void lnkFrontDeskOperation_Click(object sender, EventArgs e)
        {
            //clsSession.SelectedModule = "Front Desk Operation";            
            if (clsSession.UserID != null && clsSession.UserID != Guid.Empty)
            {
                Response.Redirect("http://frontdesk.uniworldindia.com/?module=" + Convert.ToString(clsSession.UserID));
            }
        }

        protected void lnkAccountsSetup_Click(object sender, EventArgs e)
        {
            if (clsSession.UserID != null && clsSession.UserID != Guid.Empty)
            {
                Response.Redirect("http://backoffice.uniworldindia.com/?module=" + Convert.ToString(clsSession.UserID));
            }
        }

        protected void lnkAccountsOperation_Click(object sender, EventArgs e)
        {
            if (clsSession.UserID != null && clsSession.UserID != Guid.Empty)
            {
                Response.Redirect("http://backoffice.uniworldindia.com/?module=" + Convert.ToString(clsSession.UserID));
            }
        }

        protected void lnkTestMolule_OnClick(object sender, EventArgs e)
        {
            if (clsSession.UserID != null && clsSession.UserID != Guid.Empty)
            {
                Response.Redirect("http://frontdesk.uniworldindia.com/?module=" + Convert.ToString(clsSession.UserID));
            }
        }

        #endregion Button Event

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                SetLabel();
                BindModule();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void InsertLoginLogDetails()
        {
            LoginLog objToInsert = new LoginLog();
            if (clsSession.CompanyID != null && clsSession.CompanyID != Guid.Empty)
                objToInsert.CompanyID = clsSession.CompanyID;

            if (clsSession.PropertyID != null && clsSession.PropertyID != Guid.Empty)
                objToInsert.PropertyID = clsSession.PropertyID;

            if (clsSession.UserID != null && clsSession.UserID != Guid.Empty)
                objToInsert.UserID = clsSession.UserID;

            objToInsert.LogIn = DateTime.Now;
            objToInsert.SessionID = Session.SessionID;
            objToInsert.IsSynch = false;

            LoginLogBLL.Save(objToInsert);
            clsSession.LogInLogID = objToInsert.LogInLogID;
        }
        private void SetLabel()
        {
            lblUserDisplayName.Text = clsSession.DisplayName;
            lblUserRoleType.Text = clsSession.UserType;
            lblPropertyName.Text = clsSession.PropertyName != string.Empty ? clsSession.PropertyName : "";
            if (clsSession.DateFormat != string.Empty)
                litDate.Text = DateTime.Now.Date.ToString(Convert.ToString(clsSession.DateFormat));
            else
                litDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

            if (clsSession.TimeFormat != string.Empty)
                litTime.Text = DateTime.Now.ToString(clsSession.TimeFormat);
            else
                litTime.Text = DateTime.Now.ToString("hh:mm tt");

            lblDate.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblDate", "Date");
            lblTime.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblTime", "Time");
            lnkLogout.Text = clsCommon.GetGlobalResourceText("AdminMaster", "lblBtnLogOut", "Log Out");
        }

        private void BindModule()
        {
            Guid? PropertyID = null;
            Guid? CompanyID = null;

            if (clsSession.PropertyID != null && clsSession.PropertyID != Guid.Empty)
                PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));

            if (clsSession.CompanyID != null && clsSession.CompanyID != Guid.Empty)
                CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

            DataSet dsModule = UserBLL.UserSelectModule(new Guid(Convert.ToString(Session["UserID"])), PropertyID, CompanyID);

            if (dsModule.Tables.Count > 1 && dsModule.Tables[1].Rows.Count > 0)
            {
                DataRow[] dr1 = dsModule.Tables[1].Select("RoleType = 'Front Desk Setup'");
                DataRow[] dr2 = dsModule.Tables[1].Select("RoleType = 'Front Desk Operation'");
                DataRow[] dr3 = dsModule.Tables[1].Select("RoleType = 'Accounts Operation'");
                DataRow[] dr4 = dsModule.Tables[1].Select("RoleType = 'Accounts Setup'");
                DataRow[] dr5 = dsModule.Tables[1].Select("RoleType = 'PMS Admin Setup'");

                if (dr1.Length > 0)
                {
                    lnkFrontDeskSetup.Enabled = true;
                    btnFrontDeskModule.CssClass = "home_frontdesk_button";
                }
                if (dr2.Length > 0)
                {
                    lnkFrontDeskOperation.Enabled = true;
                    btnFrontDeskModule.CssClass = "home_frontdesk_button";
                }
                if (dr3.Length > 0)
                {
                    lnkAccountsOperation.Enabled = true;
                    btnAccountsModule.CssClass = "home_accounting_button";
                }
                if (dr4.Length > 0)
                {
                    lnkAccountsSetup.Enabled = true;
                    btnAccountsModule.CssClass = "home_accounting_button";
                }
                if (dr5.Length > 0)
                {
                    lnkPMSSetup.Enabled = true;
                    btnPMSModule.CssClass = "home_corporate_button";
                }
            }
        }

        #endregion Private Method
    }
}