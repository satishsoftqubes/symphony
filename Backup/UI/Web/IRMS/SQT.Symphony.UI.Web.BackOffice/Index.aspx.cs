using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Configuration;

namespace SQT.Symphony.UI.Web.BackOffice
{
    public partial class Index : System.Web.UI.Page
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

        bool blIsCatchForCounterLoginPage = false;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //// Coding for getting userid from module page and take appropreate action Start
                    if (Request["module"] != null && Convert.ToString(Request["module"]) != string.Empty)
                    {
                        Guid userID = new Guid(Convert.ToString(Request["module"])); //new Guid(Decrypt(Convert.ToString(Request["module"]), "EncryptDecryptKey"));
                        User objUser = UserBLL.GetByPrimaryKey(userID);
                        if (objUser != null)
                        {
                            txtHotelCode.Text = Convert.ToString(ConfigurationManager.AppSettings["PropertyCode"]);
                            txtUsername.Text = Convert.ToString(objUser.UserName);
                            txtPassword.Text = Convert.ToString(objUser.Password);
                            btnLogin_OnClick(sender, e);
                        }
                        else
                        {
                            Response.Redirect("http://pms.uniworldindia.com/");
                        }
                    }
                    //// Coding for getting userid from module page and take appropreate action End


                    //// Set Property code from web.config file.
                    txtHotelCode.Text = Convert.ToString(ConfigurationManager.AppSettings["PropertyCode"]);

                    SetPageLables();
                    CheckRememberMe();
                    txtUsername.Focus();
                }
                catch
                {
                    if (!blIsCatchForCounterLoginPage)
                        Response.Redirect("http://pms.uniworldindia.com/");
                }
            }
        }
        #endregion

        #region Control Events
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtHotelCode.Text.Trim().Length == 4)
                {
                    DataSet dsUserInfo = UserBLL.UserAuthentication(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    //// If record found...
                    if (dsUserInfo != null && dsUserInfo.Tables[0].Rows.Count > 0)
                    {
                        DataRow drUserInfo = dsUserInfo.Tables[0].Rows[0];

                        string strRoleType = GetRoleType(dsUserInfo.Tables[2]);

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

                        clsSession.RoleType = strRoleType;

                        if (strRoleType == "SUPERADMIN")
                        {
                            //// User is SuperAdmin
                            if (txtHotelCode.Text.Trim() == Convert.ToString(dsUserInfo.Tables[1].Rows[0]["HotelCode"]))
                            {
                                clsSession.HotelCode = txtHotelCode.Text.Trim();
                            }
                            else
                            {
                                lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidHotelLicenceNumber", "Invalid Hotelcode(Licence No.).");
                                mpeMessage.Show();
                                return;
                            }

                            clsSession.UserID = new Guid(Convert.ToString(drUserInfo["UsearID"]));
                            clsSession.UserType = "SUPERADMIN";
                            clsSession.CompanyName = "Softqube Technologies";

                            if (Convert.ToString(drUserInfo["CompanyID"]) != string.Empty)
                                clsSession.CompanyID = new Guid(Convert.ToString(drUserInfo["CompanyID"]));

                            if (Convert.ToString(drUserInfo["PropertyID"]) != string.Empty)
                                clsSession.PropertyID = new Guid(Convert.ToString(drUserInfo["PropertyID"]));

                            clsSession.DisplayName = Convert.ToString(drUserInfo["UserDisplayName"]);
                            clsSession.UserName = Convert.ToString(drUserInfo["UserName"]);
                            clsSession.DateFormat = "dd-MMM-yyyy";
                            clsSession.CurrentCurrency = "INR";
                            clsSession.TimeFormat = "hh:mm tt";
                            clsSession.DigitsAfterDecimalPoint = Convert.ToInt16("2");

                            SetRememberMe();

                            blIsCatchForCounterLoginPage = true;
                            Response.Redirect("~/GUI/AccountsHome.aspx");
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

                                //// If user has enter any hotelcode, then...
                                if (txtHotelCode.Text.Trim().Length > 0)
                                {
                                    ////Any Property found under this company....
                                    if (dsUserInfo.Tables.Count > 1 && dsUserInfo.Tables[1].Rows.Count > 0)
                                    {
                                        DataRow[] rows = dsUserInfo.Tables[1].Select("HotelCode = '" + Convert.ToString(txtHotelCode.Text.Trim()) + "'");
                                        //// If Entered hotelcode is found in list of Hotelcodes under this company...
                                        if (rows.Length > 0)
                                        {
                                            clsSession.HotelCode = txtHotelCode.Text.Trim();

                                            if (Convert.ToString(rows[0]["DateFormat"]) != string.Empty && Convert.ToString(rows[0]["DateFormat"]) != Guid.Empty.ToString())
                                                clsSession.DateFormat = Convert.ToString(rows[0]["DateFormat"]);
                                            else
                                                clsSession.DateFormat = "dd-MMM-yyyy";

                                            //if (Convert.ToString(rows[0]["CurrencyCode"]) != string.Empty && Convert.ToString(rows[0]["CurrencyCode"]) != Guid.Empty.ToString())
                                            //    clsSession.CurrentCurrency = Convert.ToString(rows[0]["CurrencyCode"]);
                                            //else
                                            //    clsSession.CurrentCurrency = "INR";

                                            clsSession.CurrentCurrency = "INR";
                                            if (Convert.ToString(rows[0]["TimeFormat"]) != string.Empty && Convert.ToString(rows[0]["TimeFormat"]) != Guid.Empty.ToString())
                                                clsSession.TimeFormat = Convert.ToString(rows[0]["TimeFormat"]);
                                            else
                                                clsSession.TimeFormat = "hh:mm tt";

                                            if (Convert.ToString(rows[0]["PropertyID"]) != "" && Convert.ToString(rows[0]["PropertyID"]) != null)
                                            {
                                                clsSession.PropertyID = new Guid(Convert.ToString(rows[0]["PropertyID"]));
                                                Property objGetProperty = PropertyBLL.GetByPrimaryKey(clsSession.PropertyID);
                                                if (objGetProperty != null)
                                                    clsSession.PropertyName = Convert.ToString(objGetProperty.PropertyName);
                                            }

                                            blIsCatchForCounterLoginPage = true;
                                            Response.Redirect("~/GUI/AccountsHome.aspx");
                                        }
                                        else//// Invelid hotelcode...
                                        {
                                            lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidHotelLicenceNumber", "Invalid Hotelcode(Licence No.).");
                                            mpeMessage.Show();
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidHotelLicenceNumber", "Invalid Hotelcode(Licence No.).");
                                    mpeMessage.Show();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (strRoleType != string.Empty)
                            {
                                //// Normal User
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
                                    ////Hotelcode exist for this user....
                                    if (dsUserInfo.Tables.Count > 1 && dsUserInfo.Tables[1].Rows.Count > 0)
                                    {
                                        if (txtHotelCode.Text.Trim() == Convert.ToString(dsUserInfo.Tables[1].Rows[0]["HotelCode"]))
                                        {
                                            SetCommonSessionData(drUserInfo);
                                            clsSession.UserType = strRoleType;
                                            clsSession.HotelCode = txtHotelCode.Text.Trim();
                                            SetRememberMe();

                                            if (Convert.ToString(dsUserInfo.Tables[1].Rows[0]["DateFormat"]) != string.Empty && Convert.ToString(dsUserInfo.Tables[1].Rows[0]["DateFormat"]) != Guid.Empty.ToString())
                                                clsSession.DateFormat = Convert.ToString(dsUserInfo.Tables[1].Rows[0]["DateFormat"]);
                                            else
                                                clsSession.DateFormat = "dd-MMM-yyyy";

                                            //if (Convert.ToString(dsUserInfo.Tables[1].Rows[0]["CurrencyCode"]) != string.Empty && Convert.ToString(dsUserInfo.Tables[1].Rows[0]["CurrencyCode"]) != Guid.Empty.ToString())
                                            //    clsSession.CurrentCurrency = Convert.ToString(dsUserInfo.Tables[1].Rows[0]["CurrencyCode"]);
                                            //else
                                            //    clsSession.CurrentCurrency = "INR";

                                            clsSession.CurrentCurrency = "INR";
                                            if (Convert.ToString(dsUserInfo.Tables[1].Rows[0]["TimeFormat"]) != string.Empty && Convert.ToString(dsUserInfo.Tables[1].Rows[0]["TimeFormat"]) != Guid.Empty.ToString())
                                                clsSession.TimeFormat = Convert.ToString(dsUserInfo.Tables[1].Rows[0]["TimeFormat"]);
                                            else
                                                clsSession.TimeFormat = "hh:mm tt";

                                            ////To Redirect home page of normal user....
                                            clsSession.ToEditItemType = "PROPERTYSETUP";
                                            clsSession.ToEditItemID = clsSession.PropertyID;

                                            //Response.Redirect("~/CounterLogin.aspx");
                                            blIsCatchForCounterLoginPage = true;
                                            Response.Redirect("~/GUI/AccountsHome.aspx");
                                        }
                                        else//// Hotel code exist but not match with entered hotelcode....
                                        {
                                            lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidHotelLicenceNumber", "Invalid Hotelcode(Licence No.).");
                                            mpeMessage.Show();
                                            return;
                                        }
                                    }
                                    else//// No Any Property found for this user....
                                    {
                                        lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidHotelLicenceNumber", "Invalid Hotelcode(Licence No.).");
                                        mpeMessage.Show();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgNoRoleAssigned", "No Role assigned to this user, Please contact your Admin.");
                                mpeMessage.Show();
                                return;
                            }
                        }
                    }
                    else//// if dsUserInfo is null or table does not contain any record, then give message...
                    {
                        lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidUserNamePassword", "Invalid User name or Password.");
                        mpeMessage.Show();
                    }
                }
                else//// Hotel code must be 4 character.
                {
                    lblErrorMessage.Text = clsCommon.GetGlobalResourceText("Login", "lblMsgInvalidHotelLicenceNumber", "Invalid Hotelcode(Licence No.).");
                    mpeMessage.Show();
                    return;
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
            txtUsername.Text = txtHotelCode.Text = string.Empty;
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

            rows = dtUserRoles.Select("RoleType = 'ADMIN'");
            if (rows.Length > 0)
                return "ADMIN";
            else
            {
                string strReturnRoleType = string.Empty;
                if (dtUserRoles.Rows.Count > 0)
                {
                    for (int i = 0; i < dtUserRoles.Rows.Count; i++)
                    {
                        if (strReturnRoleType == string.Empty)
                            strReturnRoleType = Convert.ToString(dtUserRoles.Rows[i]["RoleType"]);
                        else
                            strReturnRoleType += "," + Convert.ToString(dtUserRoles.Rows[i]["RoleType"]);
                    }
                }
                return strReturnRoleType;
            }

            return "";
        }

        private void SetRememberMe()
        {
            if (chkRememberMe.Checked)
            {
                Response.Cookies["IRMSUserName"].Value = txtUsername.Text;
                Response.Cookies["IRMSPassword"].Value = txtPassword.Text;
                Response.Cookies["IRMSHotelCode"].Value = txtHotelCode.Text;
                Response.Cookies["IRMSUserName"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["IRMSPassword"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["IRMSHotelCode"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["IRMSUserName"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["IRMSPassword"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["IRMSHotelCode"].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        private void CheckRememberMe()
        {
            if (Request.Cookies["IRMSUserName"] != null)
                txtUsername.Text = Convert.ToString(Request.Cookies["IRMSUserName"].Value);
            if (Request.Cookies["IRMSPassword"] != null)
                txtPassword.Attributes.Add("value", Request.Cookies["IRMSPassword"].Value);
            if (Request.Cookies["IRMSHotelCode"] != null)
                txtHotelCode.Text = Convert.ToString(Request.Cookies["IRMSHotelCode"].Value);

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
            litHotel.Text = clsCommon.GetGlobalResourceText("Login", "lblHotel", "Hotel (Licence No.)");
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
            clsSession.UserName = Convert.ToString(drUserInfo["UserName"]);
            clsSession.DigitsAfterDecimalPoint = Convert.ToInt16("2");
        }
        #endregion
    }
}