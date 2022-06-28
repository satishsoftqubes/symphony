using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlDepartment : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid DepartmentID
        {
            get
            {
                return ViewState["DepartmentID"] != null ? new Guid(Convert.ToString(ViewState["DepartmentID"])) : Guid.Empty;
            }
            set
            {
                ViewState["DepartmentID"] = value;
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
            if (RoleRightJoinBLL.GetAccessString("DepartmentSetp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            if (Session["CompanyID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("DepartmentSetp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
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
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("DepartmentSetp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.DepartmentID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Values
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                //BindPropetyName();
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
            //Guid? PropertyID;
            Guid? CompanyID;
            string DepartmentName = null;

            //if (ddlSProperty.SelectedValue != Guid.Empty.ToString())
            //    PropertyID = new Guid(ddlSProperty.SelectedValue);
            //else
            //    PropertyID = null;

            if (!txtSTermName.Text.Trim().Equals(""))
                DepartmentName = txtSTermName.Text.Trim();
            else
                DepartmentName = null;
            CompanyID = this.CompanyID;

            DataSet ds = DepartmentBLL.GetSearcahDepartmentData(null, null, DepartmentName, CompanyID);

            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "DepartmentName Asc";
            grdDepartmentList.DataSource = dv;
            grdDepartmentList.DataBind();
        }

        //private void BindPropetyName()
        //{
        //    List<Property> lstProperty = null;
        //    Property objProperty = new Property();
        //    objProperty.CompanyID = this.CompanyID;
        //    lstProperty = PropertyBLL.GetAll(objProperty);

        //    if (lstProperty.Count != 0)
        //    {
        //        lstProperty.Sort((Property p1, Property p2) => p1.PropertyName.CompareTo(p2.PropertyName));
        //        ddlPropertyName.DataSource = lstProperty;
        //        ddlPropertyName.DataTextField = "PropertyName";
        //        ddlPropertyName.DataValueField = "PropertyID";
        //        ddlPropertyName.DataBind();
        //        ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        //        ddlSProperty.DataSource = lstProperty;
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

        private void LoadData()
        {
            Department objUpdateData = new Department();
            objUpdateData = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);

            if (objUpdateData != null)
            {
                //ddlPropertyName.SelectedValue = Convert.ToString(objUpdateData.PropertyID);
                txtDepartmentName.Text = Convert.ToString(objUpdateData.DepartmentName);
                txtDepartmentCode.Text = Convert.ToString(objUpdateData.DepartmentCode);
                //txtDescription.Text = Convert.ToString(objUpdateData.Description);
            }
        }

        private void ClearControl()
        {
            //ddlPropertyName.Items.Clear();
            //ddlSProperty.Items.Clear();
            //BindPropetyName();
            //ddlPropertyName.SelectedValue = Guid.Empty.ToString();
            //ddlSProperty.SelectedValue = Guid.Empty.ToString();
            txtDepartmentCode.Text = "";
            txtDepartmentName.Text = "";
            //txtDescription.Text = "";
            this.DepartmentID = Guid.Empty;
        }

        #endregion Private Method

        #region Control Event
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Department IsDeptDup = new Department();
                    IsDeptDup.DepartmentName = txtDepartmentName.Text.Trim();                    
                    IsDeptDup.IsActive = true;
                    IsDeptDup.CompanyID = this.CompanyID;

                    List<Department> LstDupDept = DepartmentBLL.GetAll(IsDeptDup);
                    if (LstDupDept.Count > 0)
                    {
                        if (this.DepartmentID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupDept[0].DepartmentID)) != Convert.ToString(this.DepartmentID.ToString()))
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

                    if (this.DepartmentID != Guid.Empty)
                    {
                        Department objUpd = new Department();
                        Department objOldDeptData = new Department();
                        objUpd = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);
                        objOldDeptData = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);

                        //objUpd.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objUpd.DepartmentName = txtDepartmentName.Text.Trim();
                        objUpd.DepartmentCode = txtDepartmentCode.Text.Trim();
                        //objUpd.Description = txtDescription.Text.Trim();

                        DepartmentBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldDeptData.ToString(), objUpd.ToString(), "mst_Department");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        Department objIns = new Department();

                        objIns.CompanyID = this.CompanyID;
                        //objIns.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objIns.DepartmentName = txtDepartmentName.Text.Trim();
                        objIns.DepartmentCode = txtDepartmentCode.Text.Trim();
                        //objIns.Description = txtDescription.Text.Trim();
                        objIns.IsActive = true;
                        objIns.CreatedOn = DateTime.Now;
                        objIns.CraetedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objIns.IsDefault = false;
                        objIns.CraetedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objIns.IsSynch = false;

                        DepartmentBLL.Save(objIns);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "mst_Department");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControl();
                    BindGrid();
                }
                catch (Exception ex)
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControl();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        protected void btnDepartmentYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DepartmentID != Guid.Empty)
                {
                    msgbx.Hide();
                    //Modified By: Harikrishna on 31-Dec-2011
                    Department objDelete = new Department();
                    //Department objDeleteDeptData = new Department();
                    objDelete = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);
                    //objDeleteDeptData = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);

                    //objDelete.IsActive = false;

                    //DepartmentBLL.Update(objDelete);
                    DepartmentBLL.Delete(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "mst_Department");
                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();

                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
               //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
               MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnDepartmentNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DepartmentID != Guid.Empty)
                {
                    msgbx.Hide();
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        #endregion Control Event

        #region Grid Event
        protected void grdDepartmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.DepartmentID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.DepartmentID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdDepartmentList_RowDataBound(object sender, GridViewRowEventArgs e)
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

                string strDepartmentName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepartmentName"));
                if (strDepartmentName.ToUpper() == "SALES")
                    EditImg.Visible = DelImg.Visible = false;                
            }
        }
        #endregion Grid Event
    }
}