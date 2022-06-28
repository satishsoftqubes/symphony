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
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyDDL();
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
                //////////if (txtHotelCode.Text.Trim().Length == 4)
                if (ddlProperty.SelectedIndex != 0)
                {
                    DataSet dsUserInfo = UserBLL.UserAuthentication(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    //// If record found...
                    if (dsUserInfo != null && dsUserInfo.Tables[0].Rows.Count > 0)
                    {
                        DataRow drUserInfo = dsUserInfo.Tables[0].Rows[0];

                        string strRoleType = GetRoleType(dsUserInfo.Tables[2]);

                        clsSession.RoleType = strRoleType;

                        if (strRoleType == "SUPERADMIN")
                        {
                            //// User is SuperAdmin
                            //////////if (txtHotelCode.Text.Trim() == Convert.ToString(dsUserInfo.Tables[1].Rows[0]["HotelCode"]))
                            if (ddlProperty.SelectedValue.ToString() == Convert.ToString(dsUserInfo.Tables[1].Rows[0]["HotelCode"]))
                            {
                                clsSession.HotelCode = ddlProperty.SelectedValue.ToString(); //////////////txtHotelCode.Text.Trim();
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
                            clsSession.DateFormat = "dd-MMM-yyyy";
                            clsSession.CurrentCurrency = "INR";
                            clsSession.TimeFormat = "hh:mm tt";
                            clsSession.DigitsAfterDecimalPoint = Convert.ToInt16("2");

                            SetRememberMe();
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
                                //////////////////if (txtHotelCode.Text.Trim().Length > 0)
                                if (ddlProperty.SelectedIndex != 0)
                                {
                                    ////Any Property found under this company....
                                    if (dsUserInfo.Tables.Count > 1 && dsUserInfo.Tables[1].Rows.Count > 0)
                                    {
                                        ////////////////////DataRow[] rows = dsUserInfo.Tables[1].Select("HotelCode = '" + Convert.ToString(txtHotelCode.Text.Trim()) + "'");
                                        DataRow[] rows = dsUserInfo.Tables[1].Select("HotelCode = '" + Convert.ToString(ddlProperty.SelectedValue) + "'");
                                        //// If Entered hotelcode is found in list of Hotelcodes under this company...
                                        if (rows.Length > 0)
                                        {
                                            clsSession.HotelCode = ddlProperty.SelectedValue.ToString(); /////////////////////txtHotelCode.Text.Trim();

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

                                            //clsSession.ToEditItemType = "COMPANY";
                                            //clsSession.ToEditItemID = clsSession.CompanyID;

                                            LoginLog objToInsert = new LoginLog();
                                            if (Convert.ToString(drUserInfo["CompanyID"]) != "" && Convert.ToString(drUserInfo["CompanyID"]) != null)
                                                objToInsert.CompanyID = clsSession.CompanyID = new Guid(Convert.ToString(drUserInfo["CompanyID"]));

                                            if (Convert.ToString(rows[0]["PropertyID"]) != "" && Convert.ToString(rows[0]["PropertyID"]) != null)
                                            {
                                                objToInsert.PropertyID = clsSession.PropertyID = new Guid(Convert.ToString(rows[0]["PropertyID"]));
                                                Property objGetProperty = PropertyBLL.GetByPrimaryKey((Guid)objToInsert.PropertyID);
                                                if (objGetProperty != null)
                                                    clsSession.PropertyName = Convert.ToString(objGetProperty.PropertyName);
                                            }

                                            clsSession.ToEditItemType = "PROPERTYSETUP";
                                            clsSession.ToEditItemID = clsSession.PropertyID;

                                            objToInsert.UserID = new Guid(Convert.ToString(drUserInfo["UsearID"]));
                                            objToInsert.LogIn = DateTime.Now;
                                            objToInsert.SessionID = Session.SessionID;
                                            objToInsert.IsSynch = false;

                                            LoginLogBLL.Save(objToInsert);
                                            clsSession.LogInLogID = objToInsert.LogInLogID;

                                            ////Response.Redirect("~/GUI/Property/CompanySetup.aspx"); 

                                            ////////Response.Redirect("~/GUI/Property/PropertySetup.aspx");  //for loging purpose by hotel code
                                            //Response.Redirect("~/Module.aspx");
                                            Response.Redirect("~/UserModuleSelection.aspx");
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
                                        //////////////////if (txtHotelCode.Text.Trim() == Convert.ToString(dsUserInfo.Tables[1].Rows[0]["HotelCode"]))
                                        if (ddlProperty.SelectedValue.ToString() == Convert.ToString(dsUserInfo.Tables[1].Rows[0]["HotelCode"]))
                                        {
                                            SetCommonSessionData(drUserInfo);
                                            clsSession.UserType = strRoleType;
                                            clsSession.HotelCode = ddlProperty.SelectedValue.ToString(); ////////////////////txtHotelCode.Text.Trim();
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

                                            LoginLog objToInsert = new LoginLog();
                                            if (Convert.ToString(drUserInfo["CompanyID"]) != "" && Convert.ToString(drUserInfo["CompanyID"]) != null)
                                                objToInsert.CompanyID = new Guid(Convert.ToString(drUserInfo["CompanyID"]));

                                            if (Convert.ToString(drUserInfo["PropertyID"]) != "" && Convert.ToString(drUserInfo["PropertyID"]) != null)
                                            {
                                                objToInsert.PropertyID = new Guid(Convert.ToString(drUserInfo["PropertyID"]));

                                                Property objGetProperty = PropertyBLL.GetByPrimaryKey((Guid)objToInsert.PropertyID);
                                                if (objGetProperty != null)
                                                    clsSession.PropertyName = Convert.ToString(objGetProperty.PropertyName);
                                            }

                                            objToInsert.UserID = new Guid(Convert.ToString(drUserInfo["UsearID"]));
                                            objToInsert.LogIn = DateTime.Now;
                                            objToInsert.SessionID = Session.SessionID;
                                            objToInsert.IsSynch = false;

                                            LoginLogBLL.Save(objToInsert);
                                            clsSession.LogInLogID = objToInsert.LogInLogID;

                                            ////////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                                            ////Response.Redirect("~/Module.aspx");
                                            Response.Redirect("~/UserModuleSelection.aspx");
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
            txtUsername.Text = string.Empty;
            ///////txtHotelCode.Text = string.Empty;
            txtPassword.Attributes.Add("value", string.Empty);
            chkRememberMe.Checked = false;
        }
        #endregion

        #region Private method
        private void BindPropertyDDL()
        {
            Property objProperty = new Property();
            objProperty.CompanyID = new Guid("14F1A0DC-3A5B-4E7E-9869-96979A03EA3A");
            objProperty.IsActive = true;
            List<Property> lstProperty = PropertyBLL.GetAll(objProperty);
            if (lstProperty != null && lstProperty.Count > 0)
            {
                ddlProperty.DataSource = lstProperty;
                ddlProperty.DataTextField = "PropertyName";
                ddlProperty.DataValueField = "LicenceNo";
                ddlProperty.DataBind();
                ddlProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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
                Response.Cookies["IRMSHotelCode"].Value = ddlProperty.SelectedValue.ToString(); /////////txtHotelCode.Text;
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
                ddlProperty.SelectedIndex = ddlProperty.Items.FindByValue(Convert.ToString(Request.Cookies["IRMSHotelCode"].Value)) != null ? ddlProperty.Items.IndexOf(ddlProperty.Items.FindByValue(Convert.ToString(Request.Cookies["IRMSHotelCode"].Value))) : 0;
                ////////////txtHotelCode.Text = Convert.ToString(Request.Cookies["IRMSHotelCode"].Value);

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
            litHotel.Text = "Property"; //clsCommon.GetGlobalResourceText("Login", "lblHotel", "Hotel (Licence No.)");
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