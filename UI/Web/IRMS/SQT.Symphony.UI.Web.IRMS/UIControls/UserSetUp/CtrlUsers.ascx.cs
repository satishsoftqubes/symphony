using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.IO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Web.Services;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp
{
    public partial class CtrlUsers : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid UserID
        {
            get
            {
                return ViewState["UserID"] != null ? new Guid(Convert.ToString(ViewState["UserID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }

        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("UserSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");

                LoadAccess();

                if (!IsPostBack)
                {

                    hfUserIDToCheckDuplicate.Value = Guid.Empty.ToString();
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultData();
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Send Email To User
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void SendEmail(string FullName, string UserName, string Password)
        {
            if (Session["PropertyConfigurationInfo"] != null)
            {
                PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("User Registration Notification");
                if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                {
                    string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/UserRegistration.htm"));
                    strHTML = strHTML.Replace("$FULLNAME$", FullName);
                    strHTML = strHTML.Replace("$USERNAME$", UserName);
                    strHTML = strHTML.Replace("$PASSWORD$", Password);
                    strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                    SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), UserName, "User Registration", strHTML);
                }
            }
            else
                MessageBox.Show("Please set Company email configuration");
        }

        /// <summary>
        /// Send Email With Password Key
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="UserID"></param>
        /// <param name="PasswordKey"></param>
        private void SendEmailWithPasswordKey(string UserDisplayName, string UserName, string Password, Guid UserID, string PasswordKey)
        {
            try
            {
                //if (File.Exists(Server.MapPath("~/EmailTemplates/NewUserToActivate.htm")))
                DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("User Activation");
                if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                {
                    string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "UserActivation.aspx?UserID=" + UserID.ToString() + "&key=" + PasswordKey;
                    string strActivationLink = "<a href='" + strLink + "'>" + strLink + "</a>";
                    List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.CompanyID, Convert.ToString(this.CompanyID));
                    if (LstPrtConfig.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(LstPrtConfig[0]);
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/NewUserToActivate.htm"));
                        strHTML = strHTML.Replace("$DISPLAYNAME$", UserDisplayName.Trim());
                        strHTML = strHTML.Replace("$USERNAME$", UserName.Trim());
                        strHTML = strHTML.Replace("$PASSWORD$", Password.Trim());
                        strHTML = strHTML.Replace("$ACTIVATIONLINK$", strActivationLink);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), txtUserName.Text.Trim(), "Activate your account on UniworldIndia.com", strHTML);
                    }
                    else
                        MessageBox.Show("Please set Company email configuration");
                }
                else
                    MessageBox.Show("Sorry for inconvenience, System can't send mail to your account.");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("UserSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.UserID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Load Default Data Information
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                BindRoleName();
                BindGrid();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            // Guid? PropertyID;
            string UserName = null;

            if (!(txtSUserName.Text.Trim().Equals("")))
                UserName = txtSUserName.Text.Trim();
            else
                UserName = null;

            DataSet dsUser = UserBLL.SearchData(null, null, this.CompanyID, UserName, null);
            DataView dvUser = new DataView(dsUser.Tables[0]);

            dvUser.Sort = "UserName Asc";
            grdUserList.DataSource = dvUser;
            grdUserList.DataBind();

        }

        /// <summary>
        /// Load UserType
        /// </summary>
        private void BindRoleName()
        {
            //List<Role> lstRole = null;
            //Role objRole = new Role();
            //objRole.IsActive = true;
            //objRole.CompanyID = this.CompanyID;
            //lstRole = RoleBLL.GetAll(objRole);
            //if (lstRole.Count != 0)
            //{
            //    lstRole.Sort((Role r1, Role r2) => r1.RoleName.CompareTo(r2.RoleName));
            //    ddlRoleName.DataSource = lstRole;
            //    ddlRoleName.DataTextField = "RoleName";
            //    ddlRoleName.DataValueField = "RoleID";
            //    ddlRoleName.DataBind();
            //    ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            //}
            //else
            //    ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            ddlRoleName.Items.Clear();
            string strBindRoleName = "select RoleName,RoleID from usr_Role where CompanyID = '" + Convert.ToString(Session["CompanyID"]) + "' and IsActive = 1 and RoleType = 'Admin' order by RoleName asc";
            DataSet dsBindRoleName = RoleBLL.GetRole(strBindRoleName);
            if (dsBindRoleName.Tables.Count > 0 && dsBindRoleName.Tables[0].Rows.Count > 0)
            {
                ddlRoleName.DataSource = dsBindRoleName.Tables[0];
                ddlRoleName.DataTextField = "RoleName";
                ddlRoleName.DataValueField = "RoleID";
                ddlRoleName.DataBind();
                ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            txtUserName.Text = "";
            txtSUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPwd.Text = "";
            txtPassword.Attributes.Add("value", string.Empty);
            txtConfirmPwd.Attributes.Add("value", string.Empty);
            BindRoleName();
            txtDisplayName.Text = "";
            ddlRoleName.SelectedValue = Guid.Empty.ToString();
            BindGrid();
            this.UserID = Guid.Empty;
            hfUserIDToCheckDuplicate.Value = Guid.Empty.ToString();

            ////ddlRoleName.Enabled = true;            
            ////txtUserName.Enabled = txtPassword.Enabled = txtConfirmPwd.Enabled = txtDisplayName.Enabled = true;
            ////trInvestorMsg.Visible = false;
        }

        /// <summary>
        /// Load User Data
        /// </summary>
        private void LoadData()
        {
            DataSet dsUser = UserBLL.SearchData(this.UserID, null, this.CompanyID, null, null);
            if (dsUser.Tables[0].Rows.Count != 0)
            {
                ////BindRoleName();               

                ddlRoleName.Items.Clear();

                if (Convert.ToString(dsUser.Tables[0].Rows[0]["RoleID"]) != "" && dsUser.Tables[0].Rows[0]["RoleID"] != null)
                {
                    string strRoleName = "select RoleName,RoleID from usr_Role where RoleType in (select RoleType from usr_Role where RoleID = '" + Convert.ToString(dsUser.Tables[0].Rows[0]["RoleID"]) + "') and IsActive = 1 and CompanyID = '" + Convert.ToString(Session["CompanyID"]) + "' order by RoleName asc";
                    DataSet dsRoleName = RoleBLL.GetRole(strRoleName);
                    if (dsRoleName.Tables.Count > 0 && dsRoleName.Tables[0].Rows.Count > 0)
                    {
                        ddlRoleName.DataSource = dsRoleName.Tables[0];
                        ddlRoleName.DataTextField = "RoleName";
                        ddlRoleName.DataValueField = "RoleID";
                        ddlRoleName.DataBind();
                        ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                        ddlRoleName.SelectedIndex = ddlRoleName.Items.FindByValue(Convert.ToString(dsUser.Tables[0].Rows[0]["RoleID"])) != null ? ddlRoleName.Items.IndexOf(ddlRoleName.Items.FindByValue(Convert.ToString(dsUser.Tables[0].Rows[0]["RoleID"]))) : 0;
                        //ddlRoleName.SelectedValue = Convert.ToString(dsRoleName.Tables[0].Rows[0]["RoleID"]);

                    }
                    else
                    {
                        ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                }
                else
                {
                    ddlRoleName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }

                txtUserName.Enabled = txtPassword.Enabled = txtConfirmPwd.Enabled = txtDisplayName.Enabled = true;

                txtUserName.Text = Convert.ToString(dsUser.Tables[0].Rows[0]["UserName"]);
                txtDisplayName.Text = Convert.ToString(dsUser.Tables[0].Rows[0]["UserDisplayName"]);
                txtPassword.Attributes.Add("value", Convert.ToString(dsUser.Tables[0].Rows[0]["Password"]));
                txtConfirmPwd.Attributes.Add("value", Convert.ToString(dsUser.Tables[0].Rows[0]["Password"]));

                ////if (Convert.ToString(dsUser.Tables[0].Rows[0]["RoleName"]).ToUpper().Equals("INVESTOR") || Convert.ToString(dsUser.Tables[0].Rows[0]["RoleName"]).ToUpper().Equals("CHANNEL PARTNER"))
                ////    ddlRoleName.Enabled = false;
                ////else
                ////    ddlRoleName.Enabled = true;

                ////if (Convert.ToString(dsUser.Tables[0].Rows[0]["RoleType"]).ToUpper().Equals("INVESTOR") || Convert.ToString(dsUser.Tables[0].Rows[0]["RoleType"]).ToUpper().Equals("CHANNEL PARTNER"))
                ////    ddlRoleName.Enabled = false;
                ////else
                ////    ddlRoleName.Enabled = true;
            }
        }
        #endregion Private Method

        #region Control Event
        /// <summary>
        /// sender as Object
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        /// <summary>
        /// Button Save And Update Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    User IsDupUser = new User();
                    IsDupUser.UserName = txtUserName.Text.Trim();
                    //IsDupUser.IsActive = true;
                    List<User> LstDupUser = UserBLL.GetAll(IsDupUser);
                    if (LstDupUser.Count > 0)
                    {
                        if (this.UserID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupUser[0].UsearID)) != Convert.ToString(this.UserID.ToString()))
                            {
                                IsMessage = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsMessage = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    List<UserRole> lstUserRole = new List<UserRole>();
                    UserRole objUserRole = new UserRole();
                    if (this.UserID != Guid.Empty)
                    {
                        User objUpdUser = new User();
                        User objOldUserData = new User();

                        objUpdUser = UserBLL.GetByPrimaryKey(this.UserID);
                        objOldUserData = UserBLL.GetByPrimaryKey(this.UserID);

                        //objUpdUser.PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));
                        objUpdUser.UserName = txtUserName.Text.Trim();
                        objUpdUser.Password = txtPassword.Text.Trim();
                        objUpdUser.UserDisplayName = txtDisplayName.Text.Trim();

                        objUserRole.RoleID = new Guid(ddlRoleName.SelectedValue);
                        objUserRole.AssignedOn = DateTime.Now;
                        objUserRole.IsSynch = false;
                        objUserRole.AssignedBy = new Guid(Convert.ToString(Session["UserID"]));
                        lstUserRole.Add(objUserRole);

                        if (objOldUserData.UserName.Trim() != txtUserName.Text.Trim())
                        {
                            objUpdUser.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                            objUpdUser.IsActive = false;
                            string strUserType = Convert.ToString(objUpdUser.UserType);
                            if (strUserType.ToUpper() == "SALES")
                            {
                                List<SalesTeam> lstSalesTeam = null;
                                lstSalesTeam = SalesTeamBLL.GetAllBy(SalesTeam.SalesTeamFields.Email, Convert.ToString(objOldUserData.UserName.Trim()));
                                if (lstSalesTeam.Count != 0)
                                {
                                    SalesTeam objUpdateSalesTeam = new SalesTeam();
                                    objUpdateSalesTeam = lstSalesTeam[0];
                                    objUpdateSalesTeam.Email = txtUserName.Text.Trim();
                                    SalesTeamBLL.Update(objUpdateSalesTeam);
                                }
                            }
                            else if (strUserType.ToUpper() == "CHANNEL PARTNER")
                            {
                                List<ChannelPartner> lstChannelPartner = null;
                                lstChannelPartner = ChannelPartnerBLL.GetAllBy(ChannelPartner.ChannelPartnerFields.Email, Convert.ToString(objOldUserData.UserName.Trim()));
                                if (lstChannelPartner.Count != 0)
                                {
                                    ChannelPartner objUpdateChannelPartner = new ChannelPartner();
                                    objUpdateChannelPartner = lstChannelPartner[0];
                                    objUpdateChannelPartner.Email = txtUserName.Text.Trim();
                                    ChannelPartnerBLL.Update(objUpdateChannelPartner);
                                }
                            }
                            else if (strUserType.ToUpper() == "INVESTOR")
                            {
                                List<Investor> lstInvestor = null;
                                lstInvestor = InvestorBLL.GetAllBy(Investor.InvestorFields.EMail, Convert.ToString(objOldUserData.UserName.Trim()));
                                if (lstInvestor.Count != 0)
                                {
                                    Investor objUpdateInvestor = new Investor();
                                    objUpdateInvestor = lstInvestor[0];
                                    objUpdateInvestor.EMail = txtUserName.Text.Trim();
                                    InvestorBLL.Update(objUpdateInvestor);
                                }
                            }
                            ////else if (strUserType.ToUpper() == "ADMIN")
                            ////{
                            else if (strUserType.ToUpper() == "EMPLOYEE")
                            {
                                List<Employee> lstEmployee = null;
                                lstEmployee = EmployeeBLL.GetAllBy(Employee.EmployeeFields.Email, Convert.ToString(objOldUserData.UserName.Trim()));
                                if (lstEmployee.Count != 0)
                                {
                                    Employee objUpdateEmployee = new Employee();
                                    objUpdateEmployee = lstEmployee[0];
                                    objUpdateEmployee.Email = txtUserName.Text.Trim();
                                    EmployeeBLL.Update(objUpdateEmployee);
                                }
                            }
                            ////SendEmailWithPasswordKey(objUpdUser.UserDisplayName, txtUserName.Text.Trim(), txtPassword.Text.Trim(), this.UserID, objUpdUser.PasswordKey);
                        }
                        UserBLL.Update(objUpdUser, lstUserRole);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldUserData.ToString(), objUpdUser.ToString(), "usr_User");

                        if (Convert.ToString(Session["UserID"]) == Convert.ToString(objUpdUser.UsearID))
                        {
                            Session.Clear();
                            Response.Redirect("~/InvChangeEmail.aspx");
                        }

                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        User objInsUser = new User();
                        //objInsUser.PropertyID = new Guid(ddlPropertyName.SelectedValue);                        
                        objInsUser.UsearID = Guid.NewGuid();
                        objInsUser.UserName = txtUserName.Text.Trim();
                        objInsUser.Password = txtPassword.Text.Trim();
                        objInsUser.IsActive = true;
                        objInsUser.CraetedOn = DateTime.Now;
                        objInsUser.IsBlock = false;
                        objInsUser.CompanyID = this.CompanyID;
                        objInsUser.UserDisplayName = txtDisplayName.Text.Trim();
                        objInsUser.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objInsUser.IsSynch = false;

                        string strUserTypeQuery = "select * from usr_Role where IsActive = 1" + (ddlRoleName.SelectedValue == Guid.Empty.ToString() ? "" : " and RoleID = '" + ddlRoleName.SelectedValue.ToString() + "'") + (this.CompanyID == null ? "" : " And CompanyID='" + this.CompanyID.ToString() + "'");
                        DataSet dsUserType = RoleBLL.GetRole(strUserTypeQuery);

                        if (dsUserType.Tables[0].Rows.Count != 0)
                        {
                            objInsUser.UserType = dsUserType.Tables[0].Rows[0]["RoleType"].ToString();
                            objInsUser.UserTypeID = objInsUser.UsearID;
                        }

                        objUserRole.RoleID = new Guid(ddlRoleName.SelectedValue);
                        objUserRole.AssignedOn = DateTime.Now;
                        objUserRole.IsSynch = false;
                        objUserRole.SynchOn = DateTime.Now;
                        objUserRole.AssignedBy = new Guid(Convert.ToString(Session["UserID"]));
                        lstUserRole.Add(objUserRole);
                        UserBLL.Save(objInsUser, lstUserRole);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objInsUser.ToString(), objInsUser.ToString(), "usr_User");
                        ////SendEmail(objInsUser.UserDisplayName, objInsUser.UserName, objInsUser.Password);
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControl();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControl();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event

        protected void grdUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.UserID = new Guid(Convert.ToString(e.CommandArgument));
                    hfUserIDToCheckDuplicate.Value = Convert.ToString(e.CommandArgument);
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.UserID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUserYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UserID != Guid.Empty)
                {
                    msgbx.Hide();
                    User objDelete = UserBLL.GetByPrimaryKey(this.UserID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "usr_User");
                    UserBLL.Delete(objDelete);
                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUserNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event

        #region Drop Down List Event
        /// <summary>
        /// Role Type Selection Change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoleName.SelectedValue != Guid.Empty.ToString())
            {
                string strRoleName = Convert.ToString(ddlRoleName.SelectedItem.Text);

                if (strRoleName.ToUpper() == "INVESTOR")
                {
                    txtUserName.Enabled = txtPassword.Enabled = txtConfirmPwd.Enabled = txtDisplayName.Enabled = false;
                    txtUserName.Text = txtDisplayName.Text = "";
                    txtPassword.Attributes.Add("value", string.Empty);
                    txtConfirmPwd.Attributes.Add("value", string.Empty);
                    trInvestorMsg.Visible = true;
                }
                else
                {
                    txtUserName.Enabled = txtPassword.Enabled = txtConfirmPwd.Enabled = txtDisplayName.Enabled = true;
                    trInvestorMsg.Visible = false;
                }
            }
            else
            {
                txtUserName.Enabled = txtPassword.Enabled = txtConfirmPwd.Enabled = txtDisplayName.Enabled = true;
                trInvestorMsg.Visible = false;
            }
        }

        #endregion Drop DOwn List Event
    }
}