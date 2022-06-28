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
using System.Configuration;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.UserSetup
{
    public partial class CtrlUsers : System.Web.UI.UserControl
    {
        #region Variable and Property
        public bool IsListMessage = false;

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

        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }

        #endregion Variable and Property

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();

                mvUser.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }
        #endregion Page Load

        #region Private Methods

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "USERS.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomUser.Visible = btnAddTopUser.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Users", "lblMainHeader", "USER SETUP");
            litSearchUserName.Text = clsCommon.GetGlobalResourceText("Users", "lblSearchUserName", "User Name");
            btnAddBottomUser.Text = btnAddTopUser.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litUserList.Text = clsCommon.GetGlobalResourceText("Users", "lblUserList", "User List");
            litRole.Text = clsCommon.GetGlobalResourceText("Users", "lblRole", "Role");
            litIsFunctionalRole .Text = clsCommon.GetGlobalResourceText("Users", "lblFunctionalRole", "Functional Role");
            litUserName.Text = clsCommon.GetGlobalResourceText("Users", "lblUserName", "User Name");
            litPassword.Text = clsCommon.GetGlobalResourceText("Users", "lblPassword", "Password");
            litConfirmPassword.Text = clsCommon.GetGlobalResourceText("Users", "lblConfirmPassword", "Confirm Password");
            litDisplayName.Text = clsCommon.GetGlobalResourceText("Users", "lblDisplayName", "Display Name");
            btnNo.Text = btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litHeaderConfirmDeletePopup.Text = litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Users", "lblHeaderConfirmDeletePopup", "User Setup");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            litHeaderCustomePopupMessage.Text = clsCommon.GetGlobalResourceText("Users", "lblHeaderCustomePopupMsg", "User Setup");
            litCustomePopupMsg.Text = clsCommon.GetGlobalResourceText("Users", "lblCustomePopupMsg", "Please Select Atleast One Role");
            litEmployeeName.Text = clsCommon.GetGlobalResourceText("Users", "lblEmployeeName", "Employee Name");
            btnSearchUser.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                string UserName = null;
                Guid? DepartmentID;

                if (!(txtSearchUserName.Text.Trim().Equals("")))
                    UserName = txtSearchUserName.Text.Trim();
                else
                    UserName = null;
                if (ddlSearchDepartmentName.SelectedValue != Guid.Empty.ToString())
                    DepartmentID = new Guid(ddlSearchDepartmentName.SelectedValue);
                else
                    DepartmentID = null;

                DataSet dsUser = new DataSet();

                if (clsSession.UserType.ToUpper() == "ADMIN")
                    dsUser = UserBLL.SearchData(clsSession.UserID, clsSession.PropertyID, clsSession.CompanyID, UserName, DepartmentID);
                else
                    dsUser = UserBLL.SearchData(null, clsSession.PropertyID, clsSession.CompanyID, UserName, DepartmentID);

                gvUser.DataSource = dsUser.Tables[0];
                gvUser.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSettiongs", "User Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.UserID != Guid.Empty || mvUser.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUsers", "Users");
                dr3["Link"] = "~/GUI/UserSetup/Users.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = ddlEmployeeName.SelectedIndex == 0 ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewUser", "New User") : ddlEmployeeName.SelectedItem.Text;
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUsers", "Users");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindData()
        {
            try
            {
                SetPageLables();
                BindRoleName();
                BindEmployeeName();
                BindDepartment();
                BindGrid();
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            txtUserName.Text = txtPassword.Text = txtConfirmPassword.Text = txtDisplayName.Text = "";
            ddlEmployeeName.Enabled = true;
            BindEmployeeName();
            txtPassword.Attributes.Add("value", string.Empty);
            txtConfirmPassword.Attributes.Add("value", string.Empty);
            BindRoleName();
            this.UserID = Guid.Empty;
            hfUserIDToCheckDuplicate.Value = Guid.Empty.ToString();
        }

        /// <summary>
        /// Bind Role Name
        /// </summary>
        private void BindRoleName()
        {
            List<Role> lstRole = null;
            Role objRole = new Role();
            objRole.IsActive = true;
            objRole.CompanyID = clsSession.CompanyID;
            objRole.PropertyID = clsSession.PropertyID;

            chklstRole.Items.Clear();
            chkIsFunctionalRole.Items.Clear();

            lstRole = RoleBLL.GetAll(objRole);
            if (lstRole.Count != 0)
            {
                var filteredRole = from c in lstRole
                                   orderby c.RoleName 
                                   where c.IsFunctional == false || c.IsFunctional.Equals(null)
                                   select c;

                chklstRole.DataSource = filteredRole;
                chklstRole.DataTextField = "RoleName";
                chklstRole.DataValueField = "RoleID";
                chklstRole.DataBind();



                //lstRole.Sort((Role r1, Role r2) => r1.RoleName.CompareTo(r2.RoleName));
                //chklstRole.DataSource = lstRole;
                //chklstRole.DataTextField = "RoleName";
                //chklstRole.DataValueField = "RoleID";
                //chklstRole.DataBind();


                // START

                var filteredRoleFunctional = from c in lstRole
                                             orderby c.RoleName 
                                   where c.IsFunctional == true
                                   select c;
                chkIsFunctionalRole.DataSource = filteredRoleFunctional;
                chkIsFunctionalRole.DataTextField = "RoleName";
                chkIsFunctionalRole.DataValueField = "RoleID";
                chkIsFunctionalRole.DataBind();
                //END
            }
        }

        /// <summary>
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void ChangePasswordEmail(string FullName, string UserName, string Password)
        {
            try
            {
                Guid? companyID = null;
                Guid? propertyID = null;
                if (Convert.ToString(clsSession.PropertyID) != string.Empty)
                    propertyID = clsSession.PropertyID;

                if (Convert.ToString(clsSession.CompanyID) != string.Empty)
                    companyID = clsSession.CompanyID;

                DataSet dsSearchEmailTemplate = SQT.Symphony.BusinessLogic.Configuration.BLL.EMailTemplatesBLL.GetDataByProperty(propertyID, companyID, "Change Password");
                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);

                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        string strHTML = Convert.ToString(dsSearchEmailTemplate.Tables[0].Rows[0]["Body"]);
                        strHTML = strHTML.Replace("$FULLNAME$", FullName);
                        strHTML = strHTML.Replace("$PASSWORD$", Password);

                        SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, UserName, clsCommon.GetGlobalResourceText("CommonMessage", "lblPasswordChangeEmailSubject", "Password Change Notification"), strHTML);
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Employee
        /// </summary>
        private void BindEmployeeName()
        {
            //Employee objEmployee = new Employee();
            //objEmployee.CompanyID = clsSession.CompanyID;
            //objEmployee.PropertyID = clsSession.PropertyID;
            //objEmployee.IsActive = true;
            //List<Employee> lstEmployee = null;
            //lstEmployee = EmployeeBLL.GetAll(objEmployee);
            //string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            //if (lstEmployee.Count != 0)
            //{
            //    lstEmployee.Sort((Employee e1, Employee e2) => e1.Email.CompareTo(e2.Email));
            //    ddlEmployeeName.DataSource = lstEmployee;
            //    ddlEmployeeName.DataTextField = "FullName";
            //    ddlEmployeeName.DataValueField = "EmployeeID";
            //    ddlEmployeeName.DataBind();
            //    ddlEmployeeName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            //}
            //else
            //    ddlEmployeeName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            DataSet dsEmployee = EmployeeBLL.SelectEmployeeForUser(clsSession.PropertyID, clsSession.CompanyID);
            if (dsEmployee.Tables[0].Rows.Count != 0)
            {
                ddlEmployeeName.DataSource = dsEmployee.Tables[0];
                ddlEmployeeName.DataTextField = "FullName";
                ddlEmployeeName.DataValueField = "EmployeeID";
                ddlEmployeeName.DataBind();
                ddlEmployeeName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlEmployeeName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

        }

        /// <summary>
        /// Bind User Data
        /// </summary>
        private void BindUserData()
        {
            User objUser = new User();
            objUser = UserBLL.GetByPrimaryKey(this.UserID);

            if (objUser != null)
            {
                txtUserName.Text = Convert.ToString(objUser.UserName);
                txtDisplayName.Text = Convert.ToString(objUser.UserDisplayName);
                txtPassword.Attributes.Add("value", Convert.ToString(objUser.Password));
                txtConfirmPassword.Attributes.Add("value", Convert.ToString(objUser.Password));
                ddlEmployeeName.SelectedIndex = ddlEmployeeName.Items.FindByValue(Convert.ToString(objUser.UserTypeID)) != null ? ddlEmployeeName.Items.IndexOf(ddlEmployeeName.Items.FindByValue(Convert.ToString(objUser.UserTypeID))) : 0;
                ddlEmployeeName.Enabled = false;

                BindRoleName();

                //DataSet dsRoles = new DataSet();
                DataSet dsFunctionalRoles = new DataSet();
                UserRole objLoadUserRole = new UserRole();
                objLoadUserRole.UserID = objUser.UsearID;
               // dsRoles = UserRoleBLL.GetAllWithDataSet(objLoadUserRole);
                dsFunctionalRoles = UserRoleBLL.GetAllWithDataSetFunctionalRoleOnly(objLoadUserRole);
                //if (dsRoles.Tables[0].Rows.Count != 0)
                //{
                //for (int i = 0; i < chklstRole.Items.Count; i++)
                //{
                //    DataRow[] rows = dsRoles.Tables[0].Select("RoleID = '" + chklstRole.Items[i].Value.ToString() + "'");
                //    if (rows.Length > 0)
                //        chklstRole.Items[i].Selected = true;
                //}
                //}

                if (dsFunctionalRoles != null && dsFunctionalRoles.Tables.Count > 0 && dsFunctionalRoles.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < chkIsFunctionalRole.Items.Count; i++)
                    {
                        DataRow[] rows = dsFunctionalRoles.Tables[0].Select("RoleID = '" + chkIsFunctionalRole.Items[i].Value.ToString() + "' And IsFunctional = 1");
                        if (rows.Length > 0)
                            chkIsFunctionalRole.Items[i].Selected = true;
                    }
                    for (int i = 0; i < chklstRole.Items.Count; i++)
                    {
                        DataRow[] rows = dsFunctionalRoles.Tables[0].Select("RoleID = '" + chklstRole.Items[i].Value.ToString() + "'  And (IsFunctional IS NULL Or IsFunctional = 0) ");
                        if (rows.Length > 0)
                            chklstRole.Items[i].Selected = true;
                    }
                }
               
            }
        }

        /// <summary>
        /// Bind Department
        /// </summary>
        private void BindDepartment()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-");
            Department objDepartment = new Department();
            objDepartment.IsActive = true;
            objDepartment.CompanyID = clsSession.CompanyID;
            objDepartment.PropertyID = clsSession.PropertyID;

            List<Department> lstDepartment = DepartmentBLL.GetAll(objDepartment);
            if (lstDepartment.Count > 0)
            {
                lstDepartment.Sort((Department d1, Department d2) => d1.DepartmentName.CompareTo(d2.DepartmentName));
                ddlSearchDepartmentName.DataSource = lstDepartment;
                ddlSearchDepartmentName.DataTextField = "DepartmentName";
                ddlSearchDepartmentName.DataValueField = "DepartmentID";
                ddlSearchDepartmentName.DataBind();
                ddlSearchDepartmentName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlSearchDepartmentName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchUserName.Text = "";
            ddlSearchDepartmentName.SelectedIndex = 0;
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
                Guid? companyID = null;
                Guid? propertyID = null;
                if (Convert.ToString(clsSession.PropertyID) != string.Empty)
                    propertyID = clsSession.PropertyID;

                if (Convert.ToString(clsSession.CompanyID) != string.Empty)
                    companyID = clsSession.CompanyID;

                PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);

                if (ObjPrtConfig != null)
                {
                    DataSet dsSearchEmailTemplateForUser = SQT.Symphony.BusinessLogic.Configuration.BLL.EMailTemplatesBLL.GetDataByProperty(clsSession.PropertyID, clsSession.CompanyID, "User Activation");

                    if (dsSearchEmailTemplateForUser.Tables[0] != null && dsSearchEmailTemplateForUser.Tables[0].Rows.Count != 0)
                    {
                        string strLink = Convert.ToString(ConfigurationSettings.AppSettings["ApplicationPath"]) + "UserActivation.aspx?UserID=" + UserID.ToString() + "&key=" + PasswordKey;
                        string strActivationLink = "<a href='" + strLink + "'>" + strLink + "</a>";

                        string strHTML = Convert.ToString(dsSearchEmailTemplateForUser.Tables[0].Rows[0]["Body"]);
                        strHTML = strHTML.Replace("$DISPLAYNAME$", UserDisplayName.Trim());
                        strHTML = strHTML.Replace("$USERNAME$", UserName.Trim());
                        strHTML = strHTML.Replace("$PASSWORD$", Password.Trim());
                        strHTML = strHTML.Replace("$HOTELCODE$", Convert.ToString(clsSession.HotelCode));
                        strHTML = strHTML.Replace("$ACTIVATIONLINK$", strActivationLink);

                        SentMail.SendMail(Convert.ToString(ObjPrtConfig.PrimoryDomainName), Convert.ToString(ObjPrtConfig.UserName), Convert.ToString(ObjPrtConfig.Password), Convert.ToString(ObjPrtConfig.SmtpAddress), UserName, clsCommon.GetGlobalResourceText("CommonMessage", "lblUserActivationEmailSubject", "Activate your account on UniworldIndia.com"), strHTML);
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Private Methods

        #region Grid Event
        protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkBlock = (LinkButton)e.Row.FindControl("lnkBlock");

                    Image imgBlock = (Image)e.Row.FindControl("imgBlock");
                    bool IsBlock = Convert.ToBoolean(gvUser.DataKeys[e.Row.DataItemIndex].Value.ToString());

                    if (IsBlock)
                    {
                        imgBlock.ImageUrl = "~/images/deactive_inq.png";
                        lnkBlock.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpUnBlock", "Unblock");
                    }
                    else
                    {
                        imgBlock.ImageUrl = "~/images/active_inq.png";
                        lnkBlock.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpBlock", "Block");
                    }


                    if (this.UserRights.Substring(2, 1) == "1")
                    {
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                        lnkBlock.Visible = true;
                    }
                    else
                    {
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");
                        lnkBlock.Visible = false;
                    }

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UsearID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdUserName")).Text = clsCommon.GetGlobalResourceText("Users", "lblGvHrdUserName", "User Name");
                    ((Label)e.Row.FindControl("lblGvHrdDisplayName")).Text = clsCommon.GetGlobalResourceText("Users", "lblGvHrdDisplayName", "Display Name");
                    ((Label)e.Row.FindControl("lblGvHrdBlock")).Text = clsCommon.GetGlobalResourceText("Users", "lblGvHrdBlock", "Block");
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHrdEmplyeeName")).Text = clsCommon.GetGlobalResourceText("Users", "lblGvHrdEmplyeeName", "Employee Name");
                    ((Label)e.Row.FindControl("lblGvHrdDepartmentName")).Text = clsCommon.GetGlobalResourceText("Users", "lblGvHrdDepartmentName", "Department Name");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControl();
                    mvUser.ActiveViewIndex = 1;
                    this.UserID = new Guid(Convert.ToString(e.CommandArgument));
                    BindUserData();

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.UserID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
                else if (e.CommandName.Equals("BLOCKDATA"))
                {
                    ClearControl();
                    User objUpdateUser = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    if (objUpdateUser != null)
                    {
                        if (Convert.ToBoolean(objUpdateUser.IsBlock))
                            objUpdateUser.IsBlock = false;
                        else
                            objUpdateUser.IsBlock = true;
                        UserBLL.Update(objUpdateUser);
                        if (Convert.ToString(clsSession.UserID) == Convert.ToString(e.CommandArgument))
                        {
                            Session.Clear();
                            Response.Redirect("~/Index.aspx");
                        }
                        BindGrid();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Control Event

        protected void btnAddTopUser_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mvUser.ActiveViewIndex = 1;

                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindGrid();
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindGrid();
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
                mvUser.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    User IsDupUser = new User();
                    IsDupUser.UserName = txtUserName.Text.Trim();
                    IsDupUser.PropertyID = clsSession.PropertyID;
                    List<User> LstDupUser = UserBLL.GetAll(IsDupUser);
                    if (LstDupUser.Count > 0)
                    {
                        if (this.UserID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupUser[0].UsearID)) != Convert.ToString(this.UserID.ToString()))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                mvUser.ActiveViewIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            mvUser.ActiveViewIndex = 1;
                            return;
                        }
                    }

                    List<UserRole> lstUserRole = new List<UserRole>();

                    if (this.UserID != Guid.Empty)
                    {
                        User objUpdUser = new User();
                        User objOldUserData = new User();

                        objUpdUser = UserBLL.GetByPrimaryKey(this.UserID);
                        objOldUserData = UserBLL.GetByPrimaryKey(this.UserID);

                        objUpdUser.PropertyID = clsSession.PropertyID;
                        objUpdUser.UserName = txtUserName.Text.Trim();
                        objUpdUser.Password = txtPassword.Text.Trim();
                        objUpdUser.UserDisplayName = txtDisplayName.Text.Trim();


                        for (int i = 0; i < chklstRole.Items.Count; i++)
                        {
                            if (chklstRole.Items[i].Selected)
                            {
                                UserRole objTempUserRole = new UserRole();
                                objTempUserRole.RoleID = new Guid(Convert.ToString(chklstRole.Items[i].Value));
                                objTempUserRole.AssignedOn = DateTime.Now;
                                objTempUserRole.IsSynch = false;
                                objTempUserRole.AssignedBy = clsSession.UserID;
                                lstUserRole.Add(objTempUserRole);
                            }
                        }
                        for (int i = 0; i < chkIsFunctionalRole .Items.Count; i++)
                        {
                            if (chkIsFunctionalRole.Items[i].Selected)
                            {
                                UserRole objTempUserRole = new UserRole();
                                objTempUserRole.RoleID = new Guid(Convert.ToString(chkIsFunctionalRole.Items[i].Value));
                                objTempUserRole.AssignedOn = DateTime.Now;
                                objTempUserRole.IsSynch = false;
                                objTempUserRole.AssignedBy = clsSession.UserID;
                                lstUserRole.Add(objTempUserRole);
                            }
                        }



                        UserBLL.Update(objUpdUser, lstUserRole);
                        if (Convert.ToString(objUpdUser.Password) != Convert.ToString(objOldUserData.Password))
                        {
                            ChangePasswordEmail(objUpdUser.UserDisplayName, objUpdUser.UserName, objUpdUser.Password);
                        }
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldUserData.ToString(), objUpdUser.ToString(), "usr_User");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        User objInsUser = new User();
                        objInsUser.PropertyID = clsSession.PropertyID;
                        objInsUser.UsearID = Guid.NewGuid();
                        objInsUser.UserName = txtUserName.Text.Trim();
                        objInsUser.Password = txtPassword.Text.Trim();
                        objInsUser.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        objInsUser.IsActive = false;
                        objInsUser.CraetedOn = DateTime.Now;
                        objInsUser.IsBlock = false;
                        objInsUser.CompanyID = clsSession.CompanyID;
                        objInsUser.UserDisplayName = txtDisplayName.Text.Trim();
                        objInsUser.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objInsUser.IsSynch = false;
                        objInsUser.UserTypeID = new Guid(ddlEmployeeName.SelectedValue);
                        objInsUser.UserType = "Employee";
                        objInsUser.IsDefault = false;
                        objInsUser.IsSymphonyUser = true;
                        objInsUser.IsSystemUser = false;

                        for (int i = 0; i < chklstRole.Items.Count; i++)
                        {
                            if (chklstRole.Items[i].Selected)
                            {
                                UserRole objTempUserRole = new UserRole();
                                objTempUserRole.RoleID = new Guid(Convert.ToString(chklstRole.Items[i].Value));
                                objTempUserRole.AssignedOn = DateTime.Now;
                                objTempUserRole.IsSynch = false;
                                objTempUserRole.AssignedBy = clsSession.UserID;
                                lstUserRole.Add(objTempUserRole);
                            }
                        }

                        for (int i = 0; i < chkIsFunctionalRole .Items.Count; i++)
                        {
                            if (chkIsFunctionalRole.Items[i].Selected)
                            {
                                UserRole objTempUserRole = new UserRole();
                                objTempUserRole.RoleID = new Guid(Convert.ToString(chkIsFunctionalRole.Items[i].Value));
                                objTempUserRole.AssignedOn = DateTime.Now;
                                objTempUserRole.IsSynch = false;
                                objTempUserRole.AssignedBy = clsSession.UserID;
                                lstUserRole.Add(objTempUserRole);
                            }
                        }

                        Employee objUpdateEmployee = new Employee();
                        objUpdateEmployee = EmployeeBLL.GetByPrimaryKey(new Guid(Convert.ToString(ddlEmployeeName.SelectedValue)));

                        if (objUpdateEmployee == null)
                            objUpdateEmployee = new Employee();

                        UserBLL.SaveWithEmployeeID(objInsUser, lstUserRole, objUpdateEmployee);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objInsUser.ToString(), objInsUser.ToString(), "usr_User");
                        //SendEmail(objInsUser.UserDisplayName, objInsUser.UserName, objInsUser.Password);
                        SendEmailWithPasswordKey(Convert.ToString(objInsUser.UserDisplayName), Convert.ToString(objInsUser.UserName), Convert.ToString(objInsUser.Password), objInsUser.UsearID, Convert.ToString(objInsUser.PasswordKey));
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }
                    ClearControl();
                    mvUser.ActiveViewIndex = 1;

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSearchUser_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvUser.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region DropDown Event
        protected void ddlEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlEmployeeName.SelectedValue != Guid.Empty.ToString())
            {
                Employee objEmp = new Employee();
                objEmp = EmployeeBLL.GetByPrimaryKey(new Guid(Convert.ToString(ddlEmployeeName.SelectedValue)));
                if (objEmp != null)
                {
                    txtUserName.Text = objEmp.Email;
                    List<User> lstUser = null;
                    User objGetUser = new User();
                    objGetUser.UserType = "Employee";
                    objGetUser.PropertyID = clsSession.PropertyID;
                    objGetUser.CompanyID = clsSession.CompanyID;
                    objGetUser.UserTypeID = new Guid(ddlEmployeeName.SelectedValue);
                    objGetUser.IsActive = true;

                    lstUser = UserBLL.GetAll(objGetUser);

                    if (lstUser.Count == 1)
                    {
                        btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                        this.UserID = lstUser[0].UsearID;
                        BindUserData();
                    }
                    else
                    {
                        btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                        ddlEmployeeName.Enabled = true;
                    }
                }
                else
                {
                    ddlEmployeeName.Enabled = true;
                    txtUserName.Text = "";
                }

                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            else
            {
                ddlEmployeeName.Enabled = true;
                txtUserName.Text = "";
            }
        }
        #endregion DropDown Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    User objDelete = new User();
                    objDelete = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    UserBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "usr_User");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    if (Convert.ToString(clsSession.UserID) == Convert.ToString(hdnConfirmDelete.Value))
                    {
                        Session.Clear();
                        Response.Redirect("~/Index.aspx");
                    }
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }

}