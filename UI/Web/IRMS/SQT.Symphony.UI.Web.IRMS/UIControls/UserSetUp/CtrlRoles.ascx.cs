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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp
{
    public partial class CtrlRoles : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

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
                if (RoleRightJoinBLL.GetAccessString("RoleSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();
                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultData();
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("RoleSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.RoleID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                BindRoleType();
                //BindRightInformation();
                //BindPropertyName();

                BindRoleGrid();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Role Type Information
        /// </summary>
        private void BindRoleType()
        {
            DataSet Dst = InvestorBLL.GetSearchData("Select RoleID,RoleType From usr_Role Where IsDefault = 1 And IsActive = 1 And RoleID Not in ('AACFE91E-1C5D-405E-8240-3BD01A1D2A1E')");
            DataView DV = new DataView(Dst.Tables[0]);
            if (DV.Count > 0)
            {
                DV.Sort = "RoleType ASC";
                ddlRoleType.DataSource = DV;
                ddlRoleType.DataTextField = "RoleType";
                ddlRoleType.DataValueField = "RoleType";
                ddlRoleType.DataBind();
                ddlRoleType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlRoleType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Role Grid Information
        /// </summary>
        private void BindRoleGrid()
        {
            //Guid? PropertyID;
            string RoleName = null;
            //if (ddlSProperty.SelectedValue != Guid.Empty.ToString())
            //    PropertyID = new Guid(ddlSProperty.SelectedValue);
            //else
            //    PropertyID = null;
            if (!(txtSRoleName.Text.Trim().Equals("")))
                RoleName = txtSRoleName.Text.Trim();
            else
                RoleName = null;

            DataSet ds = RoleBLL.SearchRoleData(null, this.CompanyID, null, RoleName);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "RoleName Asc";
            grdRoleList.DataSource = dv;
            grdRoleList.DataBind();
        }

        /// <summary>
        /// Bind Role Grid Information
        /// </summary>
        private void BindRightInformation()
        {
            Guid RoleID = new Guid(Guid.Empty.ToString());

            List<Role> lstRole = null;
            Role objRole = new Role();
            objRole.RoleType = ddlRoleType.SelectedValue;
            objRole.IsDefault = true;
            lstRole = RoleBLL.GetAll(objRole);
            if (lstRole.Count != 0)
                RoleID = lstRole[0].RoleID;
            DataSet Dst = RoleRightJoinBLL.SearchByRole(RoleID);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "MenuName Asc";
            trRights.Visible = true;
            grdRightRoleAssignemnt.DataSource = Dv;
            grdRightRoleAssignemnt.DataBind();

        }

        ///// <summary>
        ///// Load Property Name
        ///// </summary>
        //private void BindPropertyName()
        //{
        //    DataSet ds = PropertyBLL.SelectData(this.CompanyID);

        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        DataView dv = new DataView(ds.Tables[0]);
        //        dv.Sort = "PropertyName Asc";

        //        ddlPropertyName.DataSource = dv;
        //        ddlPropertyName.DataTextField = "PropertyName";
        //        ddlPropertyName.DataValueField = "PropertyID";
        //        ddlPropertyName.DataBind();
        //        ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        //        ddlSProperty.DataSource = dv;
        //        ddlSProperty.DataTextField = "PropertyName";
        //        ddlSProperty.DataValueField = "PropertyID";
        //        ddlSProperty.DataBind();
        //        ddlSProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //    {
        //        ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //        ddlSProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //}

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            this.RoleID = Guid.Empty;
            //BindPropertyName();
            //ddlPropertyName.SelectedValue = Guid.Empty.ToString();
           // ddlSProperty.SelectedValue = Guid.Empty.ToString();
            ddlRoleType.SelectedValue = Guid.Empty.ToString();
            //txtRoleCode.Text = "";
            txtRoleDescription.Text = "";
            txtRoleName.Text = "";
            txtRoleName.Text = "";
            trRights.Visible = false;
            //BindRightInformation();
            BindRoleGrid();
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
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
        /// Button Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    Role IsDupRole = new Role();
                    IsDupRole.RoleName = txtRoleName.Text.Trim();
                    IsDupRole.IsActive = true;
                    IsDupRole.CompanyID = this.CompanyID;

                    List<Role> LstDupRole = RoleBLL.GetAll(IsDupRole);

                    if (LstDupRole.Count > 0)
                    {
                        if (this.RoleID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupRole[0].RoleID)) != Convert.ToString(this.RoleID.ToString()))
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

                    List<RoleRightJoin> lstRoleRightJoin = new List<RoleRightJoin>();

                    if (this.RoleID != Guid.Empty)
                    {
                        Role objUpdateRole = new Role();
                        Role objOldRoleData = new Role();
                        objUpdateRole = RoleBLL.GetByPrimaryKey(this.RoleID);
                        objOldRoleData = RoleBLL.GetByPrimaryKey(this.RoleID);

                        //objUpdateRole.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objUpdateRole.RoleName = txtRoleName.Text.Trim();
                        //objUpdateRole.RoleCode = txtRoleCode.Text.Trim();
                        objUpdateRole.AboutRole = txtRoleDescription.Text.Trim();
                        objUpdateRole.RoleType = ddlRoleType.SelectedValue;

                        for (int i = 0; i < grdRightRoleAssignemnt.Rows.Count; i++)
                        {

                            CheckBox chkIsView = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsView");
                            CheckBox chkIsCreate = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsCreate");
                            CheckBox chkIsUpdate = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsUpdate");
                            CheckBox chkIsDelete = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsDelete");

                            if (chkIsView.Checked || chkIsCreate.Checked || chkIsUpdate.Checked || chkIsDelete.Checked)
                            {
                                RoleRightJoin tempRRj = new RoleRightJoin();
                                tempRRj.RightID = new Guid(grdRightRoleAssignemnt.DataKeys[i].Value.ToString());
                                tempRRj.IsView = Convert.ToBoolean(chkIsView.Checked);
                                tempRRj.IsCreate = Convert.ToBoolean(chkIsCreate.Checked);
                                tempRRj.IsUpdate = Convert.ToBoolean(chkIsUpdate.Checked);
                                tempRRj.IsDelete = Convert.ToBoolean(chkIsDelete.Checked);
                                lstRoleRightJoin.Add(tempRRj);
                            }
                        }

                        RoleBLL.Update(objUpdateRole, lstRoleRightJoin);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldRoleData.ToString(), objUpdateRole.ToString(), "usr_Role");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        Role objSaveRole = new Role();
                        //objSaveRole.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objSaveRole.RoleName = txtRoleName.Text.Trim();
                        //objSaveRole.RoleCode = txtRoleCode.Text.Trim();
                        objSaveRole.AboutRole = txtRoleDescription.Text.Trim();
                        objSaveRole.IsActive = true;
                        objSaveRole.CompanyID = this.CompanyID;
                        objSaveRole.CreatedOn = DateTime.Now;
                        objSaveRole.RoleType = ddlRoleType.SelectedValue;
                        objSaveRole.IsDefault = false;
                        objSaveRole.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objSaveRole.CreatedOn = DateTime.Now;
                        objSaveRole.IsSynch = false;

                        for (int i = 0; i < grdRightRoleAssignemnt.Rows.Count; i++)
                        {

                            CheckBox chkIsView = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsView");
                            CheckBox chkIsCreate = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsCreate");
                            CheckBox chkIsUpdate = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsUpdate");
                            CheckBox chkIsDelete = (CheckBox)grdRightRoleAssignemnt.Rows[i].FindControl("chkIsDelete");

                            if (chkIsView.Checked || chkIsCreate.Checked || chkIsUpdate.Checked || chkIsDelete.Checked)
                            {
                                RoleRightJoin tempRRj = new RoleRightJoin();
                                tempRRj.RightID = new Guid(grdRightRoleAssignemnt.DataKeys[i].Value.ToString());
                                tempRRj.IsView = Convert.ToBoolean(chkIsView.Checked);
                                tempRRj.IsCreate = Convert.ToBoolean(chkIsCreate.Checked);
                                tempRRj.IsUpdate = Convert.ToBoolean(chkIsUpdate.Checked);
                                tempRRj.IsDelete = Convert.ToBoolean(chkIsDelete.Checked);
                                lstRoleRightJoin.Add(tempRRj);
                            }
                        }

                        RoleBLL.Save(objSaveRole, lstRoleRightJoin);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objSaveRole.ToString(), objSaveRole.ToString(), "usr_Role");
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
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindRoleGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Grid Event
        protected void grdRoleList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.RoleID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    Role objLoadRole = new Role();
                    objLoadRole = RoleBLL.GetByPrimaryKey(this.RoleID);
                    
                    if (objLoadRole != null)
                    {
                        //ddlPropertyName.SelectedValue = Convert.ToString(objLoadRole.PropertyID);
                        BindRoleType();
                        if(Convert.ToString(objLoadRole.RoleType) != null)
                            ddlRoleType.SelectedValue = Convert.ToString(objLoadRole.RoleType);
                        txtRoleName.Text = Convert.ToString(objLoadRole.RoleName);
                        //txtRoleCode.Text = Convert.ToString(objLoadRole.RoleCode);
                        txtRoleDescription.Text = Convert.ToString(objLoadRole.AboutRole);
                        BindRightInformation();
                        DataSet dsRights = new DataSet();
                        RoleRightJoin objLoadRoleRight = new RoleRightJoin();
                        objLoadRoleRight.RoleID = objLoadRole.RoleID;
                        dsRights = RoleRightJoinBLL.GetAllWithDataSet(objLoadRoleRight);

                        if (dsRights.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < grdRightRoleAssignemnt.Rows.Count; i++)
                            {
                                GridViewRow row = grdRightRoleAssignemnt.Rows[i];
                                DataRow[] rows = dsRights.Tables[0].Select("RightID = '" + grdRightRoleAssignemnt.DataKeys[i]["RightID"].ToString() + "'");
                                if (rows.Length > 0)
                                {
                                    ((CheckBox)row.FindControl("chkIsView")).Checked = Convert.ToBoolean(rows[0]["IsView"]);
                                    ((CheckBox)row.FindControl("chkIsCreate")).Checked = Convert.ToBoolean(rows[0]["IsCreate"]);
                                    ((CheckBox)row.FindControl("chkIsUpdate")).Checked = Convert.ToBoolean(rows[0]["IsUpdate"]);
                                    ((CheckBox)row.FindControl("chkIsDelete")).Checked = Convert.ToBoolean(rows[0]["IsDelete"]);
                                }
                            }
                        }
                    }
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.RoleID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdRightRoleAssignemnt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("chkViewSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkViewSelectAll")).ClientID + "','" + 1 + "')");
                ((CheckBox)e.Row.FindControl("chkCreateSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkCreateSelectAll")).ClientID + "','" + 2 + "')");
                ((CheckBox)e.Row.FindControl("chkUpdateSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkUpdateSelectAll")).ClientID + "','" + 3 + "')");
                ((CheckBox)e.Row.FindControl("chkDeleteSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkDeleteSelectAll")).ClientID + "','" + 4 + "')");

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((CheckBox)e.Row.FindControl("chkIsView")).Attributes.Add("onclick", "javascript:SetCheckbox('" + "View','" + Convert.ToString(e.Row.RowIndex) + "')");

                ((CheckBox)e.Row.FindControl("chkIsCreate")).Attributes.Add("onclick", "javascript:SetCheckbox('" +
                        "Create','" + Convert.ToString(e.Row.RowIndex) + "')");

                ((CheckBox)e.Row.FindControl("chkIsUpdate")).Attributes.Add("onclick", "javascript:SetCheckbox('" +
                        "Update','" + Convert.ToString(e.Row.RowIndex) + "')");

                ((CheckBox)e.Row.FindControl("chkIsDelete")).Attributes.Add("onclick", "javascript:SetCheckbox('" +
                        "Delete','" + Convert.ToString(e.Row.RowIndex) + "')");
            }
        }

        protected void grdRoleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strRoleName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoleName"));
                if (strRoleName.ToUpper() == "SALES" || strRoleName.ToUpper() == "ADMIN" || strRoleName.ToUpper() == "INVESTOR")
                {
                    ((ImageButton)e.Row.FindControl("btnEdit")).Visible = false;
                    ((ImageButton)e.Row.FindControl("btnDelete")).Visible = false;
                }

                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");
                                
                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }
        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRoleYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RoleID != Guid.Empty)
                {
                    List<RoleRightJoin> lstRoleRightJoin = new List<RoleRightJoin>();
                    msgbx.Hide();
                    Role objDelete = RoleBLL.GetByPrimaryKey(this.RoleID);

                    RoleBLL.Delete(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(),null, "usr_Role");
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
        protected void btnRoleNo_Click(object sender, EventArgs e)
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
        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoleType.SelectedValue != Guid.Empty.ToString())
                BindRightInformation();
            else
            {
                trRights.Visible = false;
            }
        }

        #endregion Drop DOwn List Event

        
    }
}