using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        #region Property and variables
        public bool IsToRedirectToHome
        {
            get
            {
                return ViewState["IsToRedirectToHome"] != null ? Convert.ToBoolean(ViewState["IsToRedirectToHome"]) : false;
            }
            set
            {
                ViewState["IsToRedirectToHome"] = value;
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvResetPassword.ActiveViewIndex = 0;
            }
        }
        #endregion

        #region Control events
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["key"] != null)
                {
                    SQT.Symphony.BusinessLogic.Configuration.DTO.User objUser = new User();
                    objUser.UserName = txtEmail.Text.Trim();
                    objUser.PasswordKey = Convert.ToString(Request["key"]);
                    objUser.IsActive = true;
                    objUser.IsBlock = false;
                    List<User> lstUser = UserBLL.GetAll(objUser);
                    if (lstUser.Count > 0)
                    {
                        mvResetPassword.ActiveViewIndex = 1;
                    }
                    else
                    {
                        //MessageBox.Show("No user found with this Email.");
                        litMessageBox.Text = "No user found with this Email.";
                        mpeMessageBox.Show();
                    }
                }
                else
                {
                    //MessageBox.Show("Password key not found.");
                    litMessageBox.Text = "Password key not found.";
                    mpeMessageBox.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //MessageBox.Show("Sorry for inconvenience.");
                litMessageBox.Text = "Sorry for inconvenience.";
                mpeMessageBox.Show();
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["key"] != null)
                {
                    SQT.Symphony.BusinessLogic.Configuration.DTO.User objUser = new User();
                    objUser.UserName = txtEmail.Text.Trim();
                    objUser.PasswordKey = Convert.ToString(Request["key"]);
                    objUser.IsActive = true;
                    objUser.IsBlock = false;
                    List<User> lstUser = UserBLL.GetAll(objUser);
                    if (lstUser.Count > 0)
                    {
                        SQT.Symphony.BusinessLogic.Configuration.DTO.User usrUser = lstUser[0];
                        usrUser.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        usrUser.Password = txtPassword.Text.Trim();
                        UserBLL.Update(usrUser);
                        this.IsToRedirectToHome = true;

                        //if (File.Exists(Server.MapPath("~/EmailTemplates/PasswordResetMessage.htm")))
                        DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Reset password");
                        if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                        {
                            List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.CompanyID, Convert.ToString(usrUser.CompanyID));
                            if (LstPrtConfig.Count > 0)
                            {
                                string strCompanyPhoneNo = string.Empty;

                                if (Convert.ToString(lstUser[0].CompanyID) != "")
                                {
                                    Company objCompany = new Company();
                                    objCompany = CompanyBLL.GetByPrimaryKey(new Guid(Convert.ToString(lstUser[0].CompanyID)));
                                    if (objCompany != null)
                                    {
                                        strCompanyPhoneNo = Convert.ToString(objCompany.PrimaryPhone);
                                    }
                                }

                                PropertyConfiguration Prj = (PropertyConfiguration)(LstPrtConfig[0]); 

                                //string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/PasswordResetMessage.htm"));
                                string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]);
                                strHTML = strHTML.Replace("$PASSWORD$", txtPassword.Text.Trim());
                                strHTML = strHTML.Replace("$COMPANYCONTACTNO$", strCompanyPhoneNo);
                                SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), txtEmail.Text.Trim(), "Notification of Reset password", strHTML);
                                mvResetPassword.ActiveViewIndex = 2;

                            }
                        }
                        else
                            mvResetPassword.ActiveViewIndex = 2;
                    }
                    else
                        MessageBox.Show("No user found with this Email.");
                }
                else
                    MessageBox.Show("Password key not found.");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show("Sorry for inconvenience.");
            }
        }

        protected void btnCancelSave_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        #endregion
    }
}