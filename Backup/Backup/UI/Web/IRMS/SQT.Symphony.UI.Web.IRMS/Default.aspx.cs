using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Web.Services;

namespace SQT.Symphony.UI.Web.IRMS
{
    public partial class _Default : System.Web.UI.Page
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
                try
                {
                    LoadDefaultData();
                    CheckRememberMe();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Form Load

        #region Private Method

        private void LoadDefaultData()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
            Session["User"] = null;
        }

        private void CheckRememberMe()
        {
            if (Request.Cookies["SymphonyUserName"] != null)
                txtUsername.Text = Convert.ToString(Request.Cookies["SymphonyUserName"].Value);
            if (Request.Cookies["SymphonyPassword"] != null)
                txtPassword.Attributes.Add("value", Request.Cookies["SymphonyPassword"].Value);

            if (Request.Cookies["SymphonyUserName"] != null && Request.Cookies["SymphonyPassword"] != null)
                chkRememberMe.Checked = true;
        }

        private void SetRememberMe()
        {
            if (chkRememberMe.Checked)
            {
                Response.Cookies["SymphonyUserName"].Value = txtUsername.Text;
                Response.Cookies["SymphonyPassword"].Value = txtPassword.Text;
                Response.Cookies["SymphonyUserName"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["SymphonyPassword"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["SymphonyUserName"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["SymphonyPassword"].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Load Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                SQT.Symphony.BusinessLogic.Configuration.DTO.User Usr = new BusinessLogic.Configuration.DTO.User();
                Usr.UserName = txtUsername.Text.Trim();
                Usr.Password = txtPassword.Text.Trim();

                DataSet Dst = UserBLL.UserCredential(Usr.UserName.Trim(), Usr.Password.Trim());
                DataView Dv = new DataView(Dst.Tables[0]);
                if (Dv.Count == 1)
                {
                    SetRememberMe();
                    PropertyConfiguration objSessionPropertyConfiguration = new PropertyConfiguration();
                    objSessionPropertyConfiguration.IsActive = true;
                    objSessionPropertyConfiguration.CompanyID = new Guid(Convert.ToString(Convert.ToString(Dv[0]["CompanyID"])));
                    List<PropertyConfiguration> lstSessionPropertyConfiguration = null;
                    lstSessionPropertyConfiguration = PropertyConfigurationBLL.GetAll(objSessionPropertyConfiguration);
                    if (lstSessionPropertyConfiguration.Count != 0)
                    {
                        objSessionPropertyConfiguration = lstSessionPropertyConfiguration[0];
                        Session["PropertyConfigurationInfo"] = objSessionPropertyConfiguration;
                    }

                    SQT.Symphony.BusinessLogic.Configuration.DTO.User usrObj = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Dv[0]["UsearID"])));
                    LoginLog objLogInfo = new LoginLog();
                    objLogInfo.UserID = new Guid(Convert.ToString(Dv[0]["UsearID"]));
                    objLogInfo.ActorTypeTermID = Convert.ToString(Dv[0]["RoleID"]);
                    objLogInfo.CompanyID = new Guid(Convert.ToString(Dv[0]["CompanyID"]));
                    objLogInfo.LogIn = DateTime.Now.Date;
                    //objLogInfo.PropertyID = new Guid(Convert.ToString(Dv[0]["PropertyID"]));
                    objLogInfo.SessionID = Session.SessionID;
                    LoginLogBLL.Save(objLogInfo);
                    usrObj.LastLogingDate = System.DateTime.Now;
                    UserBLL.Update(usrObj);
                    Session["LoginLogID"] = Convert.ToString(objLogInfo.LogInLogID);
                    Session["User"] = Convert.ToString(Dv[0]["UserDisplayName"]);
                    Session["UserID"] = new Guid(Convert.ToString(Dv[0]["UsearID"]));
                    Session["UserTypeID"] = new Guid(Convert.ToString(Dv[0]["UserTypeID"]));
                    Session["UserType"] = Convert.ToString(Dv[0]["RoleType"]);

                    //Only User In Investor Page
                    Session["InvUserType"] = Convert.ToString(Dv[0]["UserType"]);
                    //Session["PropertyID"] = new Guid(Convert.ToString(Dv[0]["PropertyID"]));
                    Session["CompanyID"] = new Guid(Convert.ToString(Convert.ToString(Dv[0]["CompanyID"])));

                    if (Convert.ToString(Dv[0]["CompanyID"]) != "")
                    {
                        Company objLodaCmpData = CompanyBLL.GetByPrimaryKey(new Guid(Convert.ToString(Dv[0]["CompanyID"])));
                        if (objLodaCmpData != null)
                        {
                            Session["CompanyContactNo"] = Convert.ToString(objLodaCmpData.PrimaryPhone);
                        }
                    }

                    if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
                    {
                        Response.Redirect("~/Applications/Index.aspx");
                    }
                    if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        List<Investor> LstInv = InvestorBLL.GetAllBy(Investor.InvestorFields.UserID, Convert.ToString(Dv[0]["UserTypeID"]));
                        if (LstInv.Count == 1)
                        {
                            Session["InvID"] = Convert.ToString(LstInv[0].InvestorID);
                            Response.Redirect("~/Applications/SelectInvestor.aspx");
                        }
                        else
                        {
                            msgbx.Show();
                        }

                    }
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                    {
                        Response.Redirect("~/Applications/SalesDashBoard.aspx");
                    }
                }
                else
                {
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show("Enter Valid Username and Password");
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        #endregion Button Event

        [WebMethod]
        public static string GetUser(string name)
        {
            string s = name;
            return "";
        }
    }
}