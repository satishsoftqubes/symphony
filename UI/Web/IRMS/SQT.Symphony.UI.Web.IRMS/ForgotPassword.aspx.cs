using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;
using System.Configuration;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvForgetPwd.ActiveViewIndex = 0;
            }
        }
        #endregion

        #region Control Events
        protected void btnGetPassword_OnClick(object sender, EventArgs e)
        {
            try
            {
                SQT.Symphony.BusinessLogic.Configuration.DTO.User objUser = new User();
                objUser.UserName = txtEmail.Text.Trim();
                objUser.IsActive = true;
                objUser.IsBlock = false;
                List<User> lstUser = UserBLL.GetAll(objUser);

                if (lstUser.Count > 0)
                {
                    //if (File.Exists(Server.MapPath("~/EmailTemplates/ForgotPassword.htm")))
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Forgot password");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        SQT.Symphony.BusinessLogic.Configuration.DTO.User usrUser = lstUser[0];
                        string strPwdKey = Guid.NewGuid().ToString().Substring(0, 25);
                        //string strPasswordLink = "<a href='" + Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "ResetPassword.aspx?key=" + strPwdKey + "'>Click here</a>";
                        string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "ResetPassword.aspx?key=" + strPwdKey;
                        string strPasswordLink = "<a href='" + Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "ResetPassword.aspx?key=" + strPwdKey + "'>" + strLink + "</a>";
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
                            string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/ForgotPassword.htm"));
                            strHTML = strHTML.Replace("$PASSWORDLINK$", strPasswordLink);
                            strHTML = strHTML.Replace("$COMPANYCONTACTNO$", strCompanyPhoneNo);
                            SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), txtEmail.Text.Trim(), "Forgot password", strHTML);

                            usrUser.PasswordKey = strPwdKey;
                            UserBLL.Update(usrUser);

                            mvForgetPwd.ActiveViewIndex = 1;
                        }
                    }
                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        //MessageBox.Show("Sorry for inconvenience.");
                        litMessageBox.Text = "Sorry for inconvenience.";
                        mpeMessageBox.Show();
                    }
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    //MessageBox.Show("No user found with this Email.");
                    litMessageBox.Text = "No user found with this Email.";
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
            
            /*
            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("CollA");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("CollB");
            dt.Columns.Add(cl1);

            DataRow dr = dt.NewRow();
            dr["CollA"] = "Row11";
            dr["CollB"] = "Row12";
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["CollA"] = "Row21";
            dr1["CollB"] = "Row22";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["CollA"] = "Row31";
            dr4["CollB"] = "Row32";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["CollA"] = "Row41";
            dr3["CollB"] = "Row42";
            dt.Rows.Add(dr3);


            if (dt.Rows.Count > 0)
            {
                string filename = "DownloadMobileNoExcel.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
             * */
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion
    }
}