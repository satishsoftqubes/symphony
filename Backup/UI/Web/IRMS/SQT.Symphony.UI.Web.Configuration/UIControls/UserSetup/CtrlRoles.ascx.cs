using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.UserSetup
{
    public partial class CtrlRoles : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

        public Guid RoleID
        {
            get
            {
                return ViewState["RoleID"] != null ? new Guid(Convert.ToString(ViewState["RoleID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoleID"] = value;
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
        #endregion Property and Variables

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();

                mvRoles.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Methods

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ROLE.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomRoles.Visible = btnAddTopRoles.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLables();
                BindRoleType();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                string RoleName = null;
                if (!(txtSearchRoleName.Text.Trim().Equals("")))
                    RoleName = txtSearchRoleName.Text.Trim();
                else
                    RoleName = null;

                DataSet ds = RoleBLL.SearchRoleData(null, clsSession.CompanyID, clsSession.PropertyID, RoleName);
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "RoleName Asc";
                gvRoles.DataSource = dv;
                gvRoles.DataBind();
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
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSettiongs", "User Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.RoleID != Guid.Empty || mvRoles.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblRoles", "Roles");
                dr3["Link"] = "~/GUI/UserSetup/Role.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = txtRoleName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewRole", "New Role") : txtRoleName.Text.Trim();
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblRoles", "Roles");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Role Type Information
        /// </summary>
        private void BindRoleType()
        {
            Role objGetRoleType = new Role();
            objGetRoleType.IsActive = true;
            objGetRoleType.IsDefault = true;
            objGetRoleType.CompanyID = clsSession.CompanyID;
            objGetRoleType.PropertyID = clsSession.PropertyID;

            List<Role> lstGetRoleType = null;
            lstGetRoleType = RoleBLL.GetAll(objGetRoleType);
            
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            if (lstGetRoleType.Count > 0)
            {
                var filteredOutLets = from c in lstGetRoleType
                                      orderby c.RoleType
                                      where (c.IsFunctional == null || c.IsFunctional == false) && c.IsActive == true
                                      select c;

                //lstGetRoleType.Sort((Role r1, Role r2) => r1.RoleType.CompareTo(r2.RoleType));
                if (filteredOutLets != null)
                {
                    ddlRoleType.DataSource = filteredOutLets;
                    ddlRoleType.DataTextField = "RoleType";
                    ddlRoleType.DataValueField = "RoleID";
                    ddlRoleType.DataBind();
                    ddlRoleType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlRoleType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlRoleType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind Role Grid Information
        /// </summary>
        private void BindRightInformation()
        {
            Guid RoleID = new Guid(ddlRoleType.SelectedValue);
            //List<Role> lstRole = null;
            //Role objRole = new Role();
            //objRole.RoleType = Convert.ToString(ddlRoleType.SelectedValue);
            //objRole.IsDefault = true;
            //objRole.PropertyID = clsSession.PropertyID;
            //objRole.CompanyID = clsSession.CompanyID;
            //lstRole = RoleBLL.GetAll(objRole);
            //if (lstRole.Count != 0)            
            DataSet Dst = RoleRightJoinBLL.SearchByRole(RoleID);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "MenuName Asc";
            trRights.Visible = true;
            gvRoleRightAssignemnt.DataSource = Dv;
            gvRoleRightAssignemnt.DataBind();

        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("Role", "lblMainHeader", "ROLE SETUP");
            litSearchRoleName.Text = clsCommon.GetGlobalResourceText("Role", "lblSearchRoleName", "Role Name");
            ltrRolesList.Text = clsCommon.GetGlobalResourceText("Role", "lblRolesList", "Role List");
            ltrRoleType.Text = clsCommon.GetGlobalResourceText("Role", "lblRoleType", "Role Type");
            ltrRoleName.Text = clsCommon.GetGlobalResourceText("Role", "lblRoleName", "Role Name");
            ltrRoleDescription.Text = clsCommon.GetGlobalResourceText("Role", "lblRoleDescription", "Description");
            btnAddTopRoles.Text = btnAddBottomRoles.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");             
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Role", "lblHdrConfirmDeletePopup", "Role");
            btnSearchAmenities.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            ddlRoleType.SelectedIndex = 0;
            txtRoleName.Text = txtRoleDescription.Text = "";
            this.RoleID = Guid.Empty;
            //mvRoles.ActiveViewIndex = 0;
            trRights.Visible = false;            
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchRoleName.Text = "";
        }
        #endregion Method

        #region Button Event

        /// <summary>
        /// Save and Update Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    Role IsDupRole = new Role();
                    IsDupRole.RoleName = txtRoleName.Text.Trim();
                    IsDupRole.IsActive = true;                    
                    IsDupRole.PropertyID = clsSession.PropertyID;

                    List<Role> LstDupRole = RoleBLL.GetAll(IsDupRole);

                    if (LstDupRole.Count > 0)
                    {
                        if (this.RoleID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupRole[0].RoleID)) != Convert.ToString(this.RoleID.ToString()))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                mvRoles.ActiveViewIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            mvRoles.ActiveViewIndex = 1;
                            return;
                        }
                    }

                    List<RoleRightJoin> lstRoleRightJoin = new List<RoleRightJoin>();

                    if (this.RoleID != Guid.Empty)
                    {
                        Role objUpdateRole = new Role();
                        Role objOldRoleData = new Role();
                        objUpdateRole = RoleBLL.GetByPrimaryKey(this.RoleID);
                        objOldRoleData = RoleBLL.GetByPrimaryKey(this.RoleID);
                        
                        objUpdateRole.RoleName = txtRoleName.Text.Trim();                        
                        objUpdateRole.AboutRole = txtRoleDescription.Text.Trim();
                        objUpdateRole.RoleType = Convert.ToString(ddlRoleType.SelectedItem.Text);                        

                        for (int i = 0; i < gvRoleRightAssignemnt.Rows.Count; i++)
                        {
                            CheckBox chkIsView = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsView");
                            CheckBox chkIsCreate = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsCreate");
                            CheckBox chkIsUpdate = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsUpdate");
                            CheckBox chkIsDelete = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsDelete");

                            if (chkIsView.Checked || chkIsCreate.Checked || chkIsUpdate.Checked || chkIsDelete.Checked)
                            {
                                RoleRightJoin tempRRj = new RoleRightJoin();
                                tempRRj.RightID = new Guid(gvRoleRightAssignemnt.DataKeys[i].Value.ToString());
                                tempRRj.IsView = Convert.ToBoolean(chkIsView.Checked);
                                tempRRj.IsCreate = Convert.ToBoolean(chkIsCreate.Checked);
                                tempRRj.IsUpdate = Convert.ToBoolean(chkIsUpdate.Checked);
                                tempRRj.IsDelete = Convert.ToBoolean(chkIsDelete.Checked);
                                lstRoleRightJoin.Add(tempRRj);
                            }
                        }

                        RoleBLL.Update(objUpdateRole, lstRoleRightJoin);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldRoleData.ToString(), objUpdateRole.ToString(), "usr_Role");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Role objSaveRole = new Role();
                        objSaveRole.PropertyID = clsSession.PropertyID;
                        objSaveRole.RoleName = txtRoleName.Text.Trim();                        
                        objSaveRole.AboutRole = txtRoleDescription.Text.Trim();
                        objSaveRole.IsActive = true;
                        objSaveRole.CompanyID = clsSession.CompanyID;
                        objSaveRole.CreatedOn = DateTime.Now;
                        objSaveRole.RoleType = Convert.ToString(ddlRoleType.SelectedItem.Text);
                        objSaveRole.IsDefault = false;
                        objSaveRole.CreatedBy = clsSession.UserID;                        
                        objSaveRole.IsSynch = false;

                        for (int i = 0; i < gvRoleRightAssignemnt.Rows.Count; i++)
                        {

                            CheckBox chkIsView = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsView");
                            CheckBox chkIsCreate = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsCreate");
                            CheckBox chkIsUpdate = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsUpdate");
                            CheckBox chkIsDelete = (CheckBox)gvRoleRightAssignemnt.Rows[i].FindControl("chkIsDelete");

                            if (chkIsView.Checked || chkIsCreate.Checked || chkIsUpdate.Checked || chkIsDelete.Checked)
                            {
                                RoleRightJoin tempRRj = new RoleRightJoin();
                                tempRRj.RightID = new Guid(gvRoleRightAssignemnt.DataKeys[i].Value.ToString());
                                tempRRj.IsView = Convert.ToBoolean(chkIsView.Checked);
                                tempRRj.IsCreate = Convert.ToBoolean(chkIsCreate.Checked);
                                tempRRj.IsUpdate = Convert.ToBoolean(chkIsUpdate.Checked);
                                tempRRj.IsDelete = Convert.ToBoolean(chkIsDelete.Checked);
                                lstRoleRightJoin.Add(tempRRj);
                            }
                        }

                        RoleBLL.Save(objSaveRole, lstRoleRightJoin);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objSaveRole.ToString(), objSaveRole.ToString(), "usr_Role");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }
                    ClearControl();
                    mvRoles.ActiveViewIndex = 1;

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

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            ClearControl();
            BindGrid();
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
            mvRoles.ActiveViewIndex = 0;
        }

        /// <summary>
        /// Add new Role Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddTopRoles_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mvRoles.ActiveViewIndex = 1;

                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchAmenities_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvRoles.PageIndex = 0;
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
        #endregion Button Event

        #region Grid Event
        protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControl();
                    mvRoles.ActiveViewIndex = 1;
                    Role objRole = new Role();
                    objRole = RoleBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    if (objRole != null)
                    {
                        this.RoleID = objRole.RoleID;
                        ddlRoleType.SelectedIndex = ddlRoleType.Items.FindByText(Convert.ToString(objRole.RoleType)) != null ? ddlRoleType.Items.IndexOf(ddlRoleType.Items.FindByText(Convert.ToString(objRole.RoleType))) : 0;
                        txtRoleName.Text = objRole.RoleName;
                        txtRoleDescription.Text = objRole.AboutRole;

                        BindRightInformation();
                        DataSet dsRights = new DataSet();
                        RoleRightJoin objLoadRoleRight = new RoleRightJoin();
                        objLoadRoleRight.RoleID = objRole.RoleID;
                        dsRights = RoleRightJoinBLL.GetAllWithDataSet(objLoadRoleRight);

                        if (dsRights.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < gvRoleRightAssignemnt.Rows.Count; i++)
                            {
                                GridViewRow row = gvRoleRightAssignemnt.Rows[i];
                                DataRow[] rows = dsRights.Tables[0].Select("RightID = '" + gvRoleRightAssignemnt.DataKeys[i]["RightID"].ToString() + "'");
                                if (rows.Length > 0)
                                {
                                    ((CheckBox)row.FindControl("chkIsView")).Checked = Convert.ToBoolean(rows[0]["IsView"]);
                                    ((CheckBox)row.FindControl("chkIsCreate")).Checked = Convert.ToBoolean(rows[0]["IsCreate"]);
                                    ((CheckBox)row.FindControl("chkIsUpdate")).Checked = Convert.ToBoolean(rows[0]["IsUpdate"]);
                                    ((CheckBox)row.FindControl("chkIsDelete")).Checked = Convert.ToBoolean(rows[0]["IsDelete"]);
                                }
                            }
                        }

                        BindBreadCrumb();
                        UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                        uPnlBreadCrumb.Update();
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.RoleID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoleID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrRoleName")).Text = clsCommon.GetGlobalResourceText("Role", "lblGvHdrRoleName", "Role Name");
                    ((Label)e.Row.FindControl("lblGvHdrRoleType")).Text = clsCommon.GetGlobalResourceText("Role", "lblGvHdrRoleType", "Role Type");
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

        protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoles.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvRoleRightAssignemnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("chkViewSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkViewSelectAll")).ClientID + "','" + 1 + "')");
                ((CheckBox)e.Row.FindControl("chkCreateSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkCreateSelectAll")).ClientID + "','" + 2 + "')");
                ((CheckBox)e.Row.FindControl("chkUpdateSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkUpdateSelectAll")).ClientID + "','" + 3 + "')");
                ((CheckBox)e.Row.FindControl("chkDeleteSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkDeleteSelectAll")).ClientID + "','" + 4 + "')");

                ((Label)e.Row.FindControl("lblGvHdrMenuName")).Text = clsCommon.GetGlobalResourceText("Role", "lblGvHdrMenuName", "Menu Name");
                ((Label)e.Row.FindControl("lblGvHdrView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrView", "View");
                ((Label)e.Row.FindControl("lblGvHdrCreate")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrCreate", "Create");
                ((Label)e.Row.FindControl("lblGvHdrUpdate")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrUpdate", "Update");
                ((Label)e.Row.FindControl("lblGvHdrDelete")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrDelete", "Delete");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((CheckBox)e.Row.FindControl("chkIsView")).Attributes.Add("onclick", "javascript:SetCheckbox('" + "View','" + Convert.ToString(e.Row.RowIndex) + "')");

                ((CheckBox)e.Row.FindControl("chkIsCreate")).Attributes.Add("onclick", "javascript:SetCheckbox('" +
                        "Create','" + Convert.ToString(e.Row.RowIndex) + "')");

                ((CheckBox)e.Row.FindControl("chkIsUpdate")).Attributes.Add("onclick", "javascript:SetCheckbox('" +
                        "Update','" + Convert.ToString(e.Row.RowIndex) + "')");

                ((CheckBox)e.Row.FindControl("chkIsDelete")).Attributes.Add("onclick", "javascript:SetCheckbox('" +
                        "Delete','" + Convert.ToString(e.Row.RowIndex) + "')");

                Guid Rightid = new Guid(gvRoleRightAssignemnt.DataKeys[e.Row.RowIndex].Value.ToString());
                string strMenuName = "lbl" + Rightid.ToString().Replace("-", "_");
                ((Label)e.Row.FindControl("lblGvMenuName")).Text = clsCommon.GetGlobalResourceText("Rights", strMenuName, "strMenuName");                
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblGvRoleRightNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }


        #endregion Grid Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    Role objDelete = new Role();
                    objDelete = RoleBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    RoleBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "usr_Role");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
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

        #region DropDown Event
        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRoleType.SelectedValue != Guid.Empty.ToString())
                    BindRightInformation();
                else
                    trRights.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion DropDown Event
    }
}

