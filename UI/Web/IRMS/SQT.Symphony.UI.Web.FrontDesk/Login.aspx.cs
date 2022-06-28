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
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SQT.Symphony.UI.Web.FrontDesk
{
    public partial class Login : System.Web.UI.Page
    {
        #region property and variables
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
                            btnLogin_OnClick(sender,e);
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

                    string str11 = Encrypt(clsSession.UserID.ToString(), "EncryptDecryptKey");
                    string origStr = Decrypt(str11, "EncryptDecryptKey");
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
                        clsSession.RoleType = strRoleType;

                        //clsSession.DefaultCounterID = new Guid("acadee48-26ec-4a92-8aae-bc2f8c4e8037");
                        clsSession.DefaultDepositAcctID = new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6");
                        clsSession.Location_TermID = new Guid("06FC0F7E-EB83-40A3-95A0-828C54C29AAB");

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

                            //if (Convert.ToString(drUserInfo["CompanyID"]) != string.Empty)
                            //    clsSession.CompanyID = new Guid(Convert.ToString(drUserInfo["CompanyID"]));

                            //if (Convert.ToString(drUserInfo["PropertyID"]) != string.Empty)
                            //    clsSession.PropertyID = new Guid(Convert.ToString(drUserInfo["PropertyID"]));

                            clsSession.DisplayName = Convert.ToString(drUserInfo["UserDisplayName"]);
                            clsSession.UserName = Convert.ToString(drUserInfo["UserName"]);
                            clsSession.DateFormat = "dd-MM-yyyy";
                            clsSession.CurrentCurrency = "INR";
                            clsSession.TimeFormat = "hh:mm tt";
                            clsSession.DigitsAfterDecimalPoint = Convert.ToInt16("2");

                            SetRememberMe();
                            blIsCatchForCounterLoginPage = true;
                            Response.Redirect("~/CounterLogin.aspx");
                            //To redirect companylist page...
                            ////////Response.Redirect("~/GUI/Property/CompanyList.aspx");
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

                                            clsSession.DateFormat = "dd-MM-yyyy";
                                            //if (Convert.ToString(rows[0]["DateFormat"]) != string.Empty && Convert.ToString(rows[0]["DateFormat"]) != Guid.Empty.ToString())
                                            //    clsSession.DateFormat = Convert.ToString(rows[0]["DateFormat"]);
                                            //else
                                            //    clsSession.DateFormat = "dd-MMM-yyyy";

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
                                            ////Response.Redirect("~/GUI/Property/CompanySetup.aspx"); 

                                            ////////Response.Redirect("~/GUI/Property/PropertySetup.aspx");  //for loging purpose by hotel code
                                            blIsCatchForCounterLoginPage = true;
                                            Response.Redirect("~/CounterLogin.aspx");
                                            //Response.Redirect("~/GUI/Dashboard.aspx");
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

                                            clsSession.DateFormat = "dd-MM-yyyy";
                                            //if (Convert.ToString(dsUserInfo.Tables[1].Rows[0]["DateFormat"]) != string.Empty && Convert.ToString(dsUserInfo.Tables[1].Rows[0]["DateFormat"]) != Guid.Empty.ToString())
                                            //    clsSession.DateFormat = Convert.ToString(dsUserInfo.Tables[1].Rows[0]["DateFormat"]);
                                            //else
                                            //    clsSession.DateFormat = "dd-MMM-yyyy";

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

                                            ////////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                                            blIsCatchForCounterLoginPage = true;
                                            Response.Redirect("~/CounterLogin.aspx");
                                            //Response.Redirect("~/GUI/Dashboard.aspx");
                                            //Response.Redirect("~/GUI/Property/CompanyConfiguration.aspx"); //Temparary until homepage defined...
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

        #region Methods
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
        private void SetRememberMe()
        {
            if (chkRememberMe.Checked)
            {
                Response.Cookies["FrontDeskUserName"].Value = txtUsername.Text;
                Response.Cookies["FrontDeskPassword"].Value = txtPassword.Text;
                Response.Cookies["FrontDeskHotelCode"].Value = txtHotelCode.Text;
                Response.Cookies["FrontDeskUserName"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["FrontDeskPassword"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["FrontDeskHotelCode"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["FrontDeskUserName"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["FrontDeskPassword"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["FrontDeskHotelCode"].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        private void CheckRememberMe()
        {
            if (Request.Cookies["FrontDeskUserName"] != null)
                txtUsername.Text = Convert.ToString(Request.Cookies["FrontDeskUserName"].Value);
            if (Request.Cookies["FrontDeskPassword"] != null)
                txtPassword.Attributes.Add("value", Request.Cookies["FrontDeskPassword"].Value);
            if (Request.Cookies["FrontDeskHotelCode"] != null)
                txtHotelCode.Text = Convert.ToString(Request.Cookies["FrontDeskHotelCode"].Value);

            if (Request.Cookies["FrontDeskUserName"] != null && Request.Cookies["FrontDeskPassword"] != null && Request.Cookies["FrontDeskHotelCode"] != null)
                chkRememberMe.Checked = true;
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            litPageTitle.Text = "FrontDesk | Login"; //clsCommon.GetGlobalResourceText("Login", "lblPageTitle", "Uniworld | Login");
            litMainHeader.Text = "LOGIN"; //clsCommon.GetGlobalResourceText("Login", "lblLogin", "LOGIN");
            lblUserName.Text = "User Name"; //clsCommon.GetGlobalResourceText("Login", "lblUserName", "User Name");
            lblPassword.Text = "Password";//clsCommon.GetGlobalResourceText("Login", "lblPassword", "Password");
            chkRememberMe.Text = "Remember me";//clsCommon.GetGlobalResourceText("Login", "lblchkRememberMe", "Remember me");
            btnLogin.Text = "Login";//clsCommon.GetGlobalResourceText("Login", "lblbtnLogin", "Login");
            btnCancel.Text = "Cancel";//clsCommon.GetGlobalResourceText("Login", "lblCancel", "Cancel");
            lnkForgotPassword.Text = "Forgot Password";//clsCommon.GetGlobalResourceText("Login", "lblForgotPassword", "Forgot Password");
            litHotel.Text = "Hotel";//clsCommon.GetGlobalResourceText("Login", "lblHotel", "Hotel");
            btnOk.Text = "OK";//clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");
        }

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
                        if (dtUserRoles.Rows[i]["RoleType"] != null && Convert.ToString(dtUserRoles.Rows[i]["RoleType"]) != "")
                        {
                            if (strReturnRoleType == string.Empty)
                                strReturnRoleType = Convert.ToString(dtUserRoles.Rows[i]["RoleType"]);
                            else
                                strReturnRoleType += "," + Convert.ToString(dtUserRoles.Rows[i]["RoleType"]);
                        }
                    }
                }
                return strReturnRoleType;
            }

            return "";
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


        #region Encrypt-Decrypt Method Start
        private const string initVector = "tu89geji340t89u2";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;
        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
        #endregion Encrypt-Decrypt Method End
    }
}