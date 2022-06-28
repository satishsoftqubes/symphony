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
    public partial class Module : System.Web.UI.Page
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

        #endregion Button Event

        #region Datalist Event

        protected void dtlstModule_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                string str2 = e.CommandName.ToString();
                if (e.CommandName.Equals("PMS ADMIN"))
                {
                    clsSession.SelectedModule = "PMS ADMIN";
                    Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                }
                else if (e.CommandName.Equals("FRONT DESK"))
                {
                    clsSession.SelectedModule = "FRONT DESK";

                    if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
                        Response.Redirect("~/GUI/Property/CompanyList.aspx");
                    else if (clsSession.RoleType.ToUpper() == "ADMINISTRATOR")
                    {
                        ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                        Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                    }
                    else
                    {
                        ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                        Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                    }
                }
                else if (e.CommandName.Equals("ACCOUNTSOPERATION"))
                {
                }
                else if (e.CommandName.Equals("ACCOUNTSSETUP"))
                {
                }
                else if (e.CommandName.Equals("FRONTDESKOPERATION"))
                {
                    clsSession.SelectedModule = "FRONT DESK";
                    if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
                    {
                        Response.Redirect("~/GUI/Property/CompanyList.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                    }
                }
                else if (e.CommandName.Equals("FRONTDESKSETUP"))
                {
                    clsSession.SelectedModule = "FRONT DESK";
                    if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
                    {
                        Response.Redirect("~/GUI/Property/CompanyList.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                    }
                }
                else if (e.CommandName.Equals("PMSADMINSETUP"))
                {
                    clsSession.SelectedModule = "PMS ADMIN";
                    Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                }
                ////if (e.CommandName.Equals("SELECTMODULE"))
                ////{
                ////    string strArgs = Convert.ToString(e.CommandArgument);
                ////    if (strArgs.ToUpper() == "ACCOUNTS")
                ////    {
                ////    }
                ////    else if (strArgs.ToUpper() == "BACKOFFICE")
                ////    {
                ////        clsSession.SelectedModule = "BACKOFFICE";

                ////        if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
                ////            Response.Redirect("~/GUI/Property/CompanyList.aspx");
                ////        else if (clsSession.RoleType.ToUpper() == "ADMINISTRATOR")
                ////        {
                ////            ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                ////            Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                ////        }
                ////        else
                ////        {
                ////            ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                ////            Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                ////        }
                ////    }
                ////    else if (strArgs.ToUpper() == "FRONTDESK")
                ////    {
                ////        clsSession.SelectedModule = "BACKOFFICE";

                ////        if (clsSession.RoleType.ToUpper() == "SUPERADMIN")
                ////            Response.Redirect("~/GUI/Property/CompanyList.aspx");
                ////        else if (clsSession.RoleType.ToUpper() == "ADMINISTRATOR")
                ////        {
                ////            ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                ////            Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                ////        }
                ////        else
                ////        {
                ////            ////Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                ////            Response.Redirect("~/GUI/Configurations/ReservationConfig.aspx");
                ////        }
                ////    }
                ////    else if (strArgs.ToUpper() == "HOUSEKEEPING")
                ////    {
                ////    }
                ////    else if (strArgs.ToUpper() == "HOUSEKEEPING CONFIG")
                ////    {
                ////    }
                ////    else if (strArgs.ToUpper() == "PMS")
                ////    {
                ////    }
                ////    else if (strArgs.ToUpper() == "POS")
                ////    {
                ////    }
                ////    else if (strArgs.ToUpper() == "POS CONFIG")
                ////    {

                ////    }
                ////    else if (strArgs.ToUpper() == "PROPERTY ADMIN")
                ////    {
                ////        clsSession.SelectedModule = "PROPERTY ADMIN";
                ////        Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                ////    }
                ////    else if (strArgs.ToUpper() == "PROPERTY ADMIN")
                ////    {
                ////        clsSession.SelectedModule = "CORPORATE SETUP";
                ////        Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                ////    }
                ////}
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void dtlstModule_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item)
            //{
            try
            {
                string strRoleType = Convert.ToString(clsSession.RoleType);
                string strdtRoltType = Convert.ToString(dtlstModule.DataKeys[e.Item.ItemIndex]);
                bool divVisibility = false;
                bool ModuleVisibility = false;

                Button btnModuleName = (Button)e.Item.FindControl("btnModuleName");
                ////System.Web.UI.HtmlControls.HtmlGenericControl divOperation = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("divOperation");                
                LinkButton lnkSetup = (LinkButton)e.Item.FindControl("lnkSetup");
                LinkButton lnkOperation = (LinkButton)e.Item.FindControl("lnkOperation");

                string strCssClass = string.Empty;
                if (strdtRoltType.ToUpper() == "ACCOUNTS")
                {
                    strCssClass = "home_accounting_button";
                    //divVisibility = false;
                    ModuleVisibility = true;
                }
                //else if (strdtRoltType.ToUpper() == "BACKOFFICE")
                //{
                //    strCssClass = "home_backoffice_button";
                //    divVisibility = ModuleVisibility = true;
                //}
                ////else if (strdtRoltType.ToUpper() == "FRONT DESK")
                ////{
                ////    strCssClass = "home_frontdesk_button";
                ////    lnkSetup.CommandName = "FRONT DESK";
                ////    lnkOperation.CommandName = "FRONT DESK";
                ////    ModuleVisibility = true; 
                ////}
                else if (strdtRoltType.ToUpper() == "ACCOUNTS OPERATION")
                {
                    strCssClass = "home_accounting_button";
                    lnkOperation.Enabled = true;
                    lnkOperation.CommandName = "ACCOUNTSOPERATION";
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "ACCOUNTS SETUP")
                {
                    strCssClass = "home_accounting_button";
                    lnkSetup.Enabled = true;
                    lnkSetup.CommandName = "ACCOUNTSSETUP";
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "FRONT DESK OPERATION")
                {
                    strCssClass = "home_frontdesk_button";
                    lnkOperation.Enabled = true;
                    lnkOperation.CommandName = "FRONTDESKOPERATION";
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "FRONT DESK SETUP")
                {
                    strCssClass = "home_frontdesk_button";
                    lnkSetup.Enabled = true;
                    lnkSetup.CommandName = "FRONTDESKSETUP";
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "PMS ADMIN SETUP")
                {
                    strCssClass = "home_corporate_button";
                    lnkSetup.Enabled = true;
                    lnkSetup.CommandName = "PMSADMINSETUP";
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "HOUSEKEEPING")
                {
                    strCssClass = "home_housekeeping_button";
                    //divVisibility = ModuleVisibility = true;
                    ModuleVisibility = true;
                }
                //else if (strdtRoltType.ToUpper() == "HOUSEKEEPING CONFIG")
                //{
                //    strCssClass = "home_housekeepingconfig_button";
                //    divVisibility = ModuleVisibility= false;                     
                //}
                //else if (strdtRoltType.ToUpper() == "PMS")
                //{
                //    strCssClass = "home_pms_button";
                //    divVisibility = false;
                //    ModuleVisibility = true;
                //}
                else if (strdtRoltType.ToUpper() == "POS")
                {
                    lnkOperation.Enabled = true;
                    lnkSetup.Enabled = true;
                    strCssClass = "home_pos_button";
                    //divVisibility = ModuleVisibility = true;
                    ModuleVisibility = true;
                }
                //else if (strdtRoltType.ToUpper() == "POS CONFIG")
                //{
                //    strCssClass = "home_posconfig_button";
                //    divVisibility = ModuleVisibility = false;
                //}
                //else if (strdtRoltType.ToUpper() == "PROPERTY ADMIN")
                //{
                //    strCssClass = "home_propertyadministrator_button";
                //    divVisibility = false;
                //    ModuleVisibility = true;
                //}
                else if (strdtRoltType.ToUpper() == "PMS ADMIN")
                {
                    strCssClass = "home_corporate_button";
                    lnkSetup.CommandName = "PMS ADMIN";
                    lnkSetup.Enabled = true;
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "HR")
                {
                    strCssClass = "home_hr_button";
                    lnkOperation.Enabled = true;
                    lnkSetup.Enabled = true;
                    divVisibility = false;
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "MAINTENANCE")
                {
                    strCssClass = "home_maintenance_button";
                    lnkOperation.Enabled = true;
                    lnkSetup.Enabled = true;
                    divVisibility = false;
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "SECURITY")
                {
                    strCssClass = "home_security_button";
                    divVisibility = false;
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "STORES")
                {
                    strCssClass = "home_store_button";
                    lnkOperation.Enabled = true;
                    lnkSetup.Enabled = true;
                    divVisibility = false;
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "F&B")
                {
                    strCssClass = "home_fnb_button";
                    lnkOperation.Enabled = true;
                    lnkSetup.Enabled = true;
                    divVisibility = false;
                    ModuleVisibility = true;
                }
                else if (strdtRoltType.ToUpper() == "RESIDENT PORTAL")
                {
                    strCssClass = "home_residentportal_button";
                    lnkOperation.Enabled = true;
                    lnkSetup.Enabled = true;
                    divVisibility = false;
                    ModuleVisibility = true;
                }

                if (strRoleType.ToUpper() == "SUPERADMIN")
                {
                    //if (strRoleType.ToUpper() == "ADMINISTRATOR" || strRoleType.ToUpper() == "ADMIN" || strRoleType.ToUpper() == "SUPERADMIN")
                    //{
                    btnModuleName.CommandName = "SELECTMODULE";
                    btnModuleName.Enabled = true;
                    //btnModuleName.Attributes["style"] = "background-color: #0067A4; width:175px;";
                    btnModuleName.CssClass = strCssClass;
                }
                else
                {
                    if (dtRole != null && dtRole.Rows.Count > 0)
                    {
                        DataRow[] dr = dtRole.Select("RoleType = '" + strdtRoltType + "'");
                        if (dr.Length > 0)
                        {
                            btnModuleName.CommandName = "SELECTMODULE";
                            btnModuleName.Enabled = true;
                            btnModuleName.CssClass = strCssClass;
                            ////btnModuleName.Visible = ModuleVisibility;
                            ////divOperation.Visible = divVisibility;
                        }
                        else
                        {
                            btnModuleName.CommandName = "";
                            btnModuleName.Enabled = false;
                            btnModuleName.CssClass = strCssClass + " button_disable";
                            ////btnModuleName.Visible = ModuleVisibility;
                            ////divOperation.Visible = divVisibility;
                        }
                    }
                    else
                    {
                        btnModuleName.CommandName = "";
                        btnModuleName.Enabled = false;
                        btnModuleName.CssClass = strCssClass + " button_disable";
                        ////btnModuleName.Visible = ModuleVisibility;
                        ////divOperation.Visible = divVisibility;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
            // }
        }

        #endregion Datalist Event

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

            if (dsModule.Tables.Count > 0 && dsModule.Tables[0].Rows.Count > 0)
            {
                ////for (int i = 0; i < dsModule.Tables[0].Rows.Count; i++)
                ////{
                ////    string str = Convert.ToString(dsModule.Tables[0].Rows[i]["RoleType"]);

                ////    if (str.ToUpper() == "FRONTDESK" || str.ToUpper() == "POS CONFIG" || str.ToUpper() == "HOUSEKEEPING CONFIG" || str.ToUpper() == "CORPORATE SETUP") 
                ////        dsModule.Tables[0].Rows[i].Delete();
                ////}

                if (dsModule.Tables.Count > 0 && dsModule.Tables[1].Rows.Count > 0)
                {
                    dtRole = dsModule.Tables[1];
                }

                dtlstModule.DataSource = dsModule.Tables[0];
                dtlstModule.DataBind();


            }
            else
            {
                dtlstModule.DataSource = null;
                dtlstModule.DataBind();
            }
        }

        #endregion Private Method

        protected void lnkTestMolule_OnClick(object sender, EventArgs e)
        {
            if (clsSession.UserID != null && clsSession.UserID != Guid.Empty)
            {
                Response.Redirect("http://frontdesk.uniworldindia.com/?module=" + Convert.ToString(clsSession.UserID));
            }
        }

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