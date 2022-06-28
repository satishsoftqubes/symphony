using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
namespace SQT.Symphony.UI.Web.Configuration
{
    public partial class CompanyLogin : System.Web.UI.Page
    {
        #region Property and Variables
        public DataSet dsUserData
        {
            get
            {
                return ViewState["dsUserData"] != null ? (DataSet)ViewState["dsUserData"] : null;
            }
            set
            {
                ViewState["dsUserData"] = value;
            }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
                CheckRememberMe();
                txtUsername.Focus();
            }
        }
        #endregion

        #region Control Events
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dsUserInfo = UserBLL.UserAuthentication(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                //// If record found...
                if (dsUserInfo != null && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    string strRoleType = GetRoleType(dsUserInfo.Tables[2]);
                    if (strRoleType != string.Empty)
                    {
                        DataRow drUserInfo = dsUserInfo.Tables[0].Rows[0];

                        LoginLog objToInsert = new LoginLog();
                        if (Convert.ToString(drUserInfo["CompanyID"]) != "" && Convert.ToString(drUserInfo["CompanyID"]) != null)
                            objToInsert.CompanyID = new Guid(Convert.ToString(drUserInfo["CompanyID"]));

                        if (Convert.ToString(drUserInfo["PropertyID"]) != "" && Convert.ToString(drUserInfo["PropertyID"]) != null)
                            objToInsert.PropertyID = new Guid(Convert.ToString(drUserInfo["PropertyID"]));

                        objToInsert.UserID = new Guid(Convert.ToString(drUserInfo["UsearID"]));
                        objToInsert.LogIn = DateTime.Now;
                        objToInsert.SessionID = Session.SessionID;
                        objToInsert.IsSynch = false;

                        LoginLogBLL.Save(objToInsert);
                        clsSession.LogInLogID = objToInsert.LogInLogID;

                        if (strRoleType == "SUPERADMIN")
                        {
                            //// User is SuperAdmin
                            clsSession.UserID = new Guid(Convert.ToString(drUserInfo["UsearID"]));
                            clsSession.UserType = "SUPERADMIN";

                            clsSession.DisplayName = Convert.ToString(drUserInfo["UserDisplayName"]);
                            clsSession.UserName = Convert.ToString(drUserInfo["UserName"]);
                            clsSession.DateFormat = "dd-MMM-yyyy";
                            clsSession.DigitsAfterDecimalPoint = Convert.ToInt16("2");

                            SetRememberMe();

                            //To redirect companylist page...
                            Response.Redirect("~/GUI/Property/CompanyList.aspx");
                        }
                        else if (strRoleType == "ADMINISTRATOR")
                        {
                            //// User is CompanyAdmin
                            if (Convert.ToBoolean(drUserInfo["IsBlock"].ToString()))
                            {
                                //// User is blocked....
                                lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgBlockedUser", "This user is bloked.");
                                mpeMessage.Show();
                                return;
                            }
                            else
                            {
                                //// Active User...

                                SetCommonSessionData(drUserInfo);
                                clsSession.UserType = "ADMINISTRATOR"; //Convert.ToString(drUserInfo["UserType"]);
                                SetRememberMe();

                                Response.Redirect("~/GUI/Property/PropertyList.aspx");
                            }
                        }
                        else
                        {
                            lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidUserNamePassword", "Invalid User name or Password.");
                            mpeMessage.Show();
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidUserNamePassword", "Invalid User name or Password.");
                        mpeMessage.Show();
                    }
                }
                else//// if dsUserInfo is null or table does not contain any record, then give message...
                {
                    lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidUserNamePassword", "Invalid User name or Password.");
                    mpeMessage.Show();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgSystemCantLoginYou", "System can't login you, Please try again later.");
                mpeMessage.Show();
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Attributes.Add("value", string.Empty);
            chkRememberMe.Checked = false;
        }
        #endregion

        #region Private method
        private string GetRoleType(DataTable dtUserRoles)
        {
            DataRow[] rows;
            rows = dtUserRoles.Select("RoleType = 'SUPERADMIN'");
            if (rows.Length > 0)
                return "SUPERADMIN";

            rows = dtUserRoles.Select("RoleType = 'ADMINISTRATOR'");
            if (rows.Length > 0)
                return "ADMINISTRATOR";

            return "";
        }

        private void SetRememberMe()
        {
            if (chkRememberMe.Checked)
            {
                Response.Cookies["IRMSUserName"].Value = txtUsername.Text;
                Response.Cookies["IRMSPassword"].Value = txtPassword.Text;
                Response.Cookies["IRMSUserName"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["IRMSPassword"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["IRMSUserName"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["IRMSPassword"].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        private void CheckRememberMe()
        {
            if (Request.Cookies["IRMSUserName"] != null)
                txtUsername.Text = Convert.ToString(Request.Cookies["IRMSUserName"].Value);
            if (Request.Cookies["IRMSPassword"] != null)
                txtPassword.Attributes.Add("value", Request.Cookies["IRMSPassword"].Value);

            if (Request.Cookies["IRMSUserName"] != null && Request.Cookies["IRMSPassword"] != null && Request.Cookies["IRMSHotelCode"] != null)
                chkRememberMe.Checked = true;
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            litPageTitle.Text = clsCommon.GetGlobalResourceText("Login", "lblPageTitle", "Uniworld | Login");
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Login", "lblLogin", "LOGIN");
            lblUserName.Text = clsCommon.GetGlobalResourceText("Login", "lblUserName", "User Name");
            lblPassword.Text = clsCommon.GetGlobalResourceText("Login", "lblPassword", "Password");
            chkRememberMe.Text = clsCommon.GetGlobalResourceText("Login", "lblchkRememberMe", "Remember me");
            btnLogin.Text = clsCommon.GetGlobalResourceText("Login", "lblbtnLogin", "Login");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Login", "lblCancel", "Cancel");
            lnkForgotPassword.Text = clsCommon.GetGlobalResourceText("Login", "lblForgotPassword", "Forgot Password");
            btnOk.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");
        }

        private static void SetCommonSessionData(DataRow drUserInfo)
        {
            clsSession.UserID = new Guid(Convert.ToString(drUserInfo["UsearID"]));

            if (Convert.ToString(drUserInfo["CompanyID"]) != string.Empty)
                clsSession.CompanyID = new Guid(Convert.ToString(drUserInfo["CompanyID"]));

            if (Convert.ToString(drUserInfo["PropertyID"]) != string.Empty)
                clsSession.PropertyID = new Guid(Convert.ToString(drUserInfo["PropertyID"]));

            clsSession.DisplayName = Convert.ToString(drUserInfo["UserDisplayName"]);
            clsSession.DateFormat = "dd-MMM-yyyy";
            clsSession.DigitsAfterDecimalPoint = Convert.ToInt16("2");
        }
        #endregion
    }
}