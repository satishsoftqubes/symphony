using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Threading;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlProjectTerm : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsInsert = false;
        public bool IsUpdate = false;
        public bool IsDelete = false;
        public int RowCount = 0;

        public Guid TermID
        {
            get
            {
                return ViewState["TermID"] != null ? new Guid(Convert.ToString(ViewState["TermID"])) : Guid.Empty;
            }
            set
            {
                ViewState["TermID"] = value;
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
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ProjectTermSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
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
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ProjectTermSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                    ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                    //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                    ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                    if (this.TermID == Guid.Empty)
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
                BindCategory();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindCategory()
        {
            ddlCategory.Items.Clear();
            ddlsCategory.Items.Clear();
            DataSet ds = null;
            Guid CompanyID = this.CompanyID;
            ds = ProjectTermBLL.GetDistinctCategory(CompanyID);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView Dv = new DataView(ds.Tables[0]);
                Dv.Sort = "Category ASC";
                ddlCategory.DataSource = Dv;
                ddlCategory.DataTextField = "Category";
                ddlCategory.DataValueField = "Category";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                ddlsCategory.DataSource = Dv;
                ddlsCategory.DataTextField = "Category";
                ddlsCategory.DataValueField = "Category";
                ddlsCategory.DataBind();
                ddlsCategory.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
            {
                ddlCategory.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlsCategory.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            List<ProjectTerm> lstProjectTermData = null;
            ProjectTerm objSearchData = new ProjectTerm();
            if (ddlsCategory.SelectedValue != Guid.Empty.ToString())
                objSearchData.Category = ddlsCategory.SelectedValue;
            else
                objSearchData.Category = null;            
            objSearchData.CompanyID = this.CompanyID;

            lstProjectTermData = ProjectTermBLL.GetAll(objSearchData);
            lstProjectTermData.Sort((ProjectTerm p1, ProjectTerm p2) => p1.Category.CompareTo(p2.Category));
            RowCount = lstProjectTermData.Count;
            grdProjectTermList.DataSource = lstProjectTermData;
            grdProjectTermList.DataBind();
        }
        /// <summary>
        /// Load Primary Key Data
        /// </summary>
        private void LoadData()
        {
            ProjectTerm objLoadData = new ProjectTerm();
            objLoadData = ProjectTermBLL.GetByPrimaryKey(this.TermID);
            if (objLoadData != null)
            {
                ddlCategory.SelectedValue = Convert.ToString(objLoadData.Category);
                txtTermName.Text = Convert.ToString(objLoadData.DisplayTerm);
                txtTermCode.Text = Convert.ToString(objLoadData.TermCode);
                //txtForeColor.Text = Convert.ToString(objLoadData.ForeColor);
                //txtBackColor.Text = Convert.ToString(objLoadData.BackColor);
            }
        }
        /// <summary>
        /// Clear Controls
        /// </summary>
        private void ClearControl()
        {
            
            ddlCategory.SelectedValue = Guid.Empty.ToString();
            txtTermName.Text = "";
            txtTermCode.Text = "";
            //txtForeColor.Text = "FFFFFF";
            //txtBackColor.Text = "FFFFFF";
            this.TermID = Guid.Empty;
            BindGrid();
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add Term Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        /// <summary>
        /// Save Information
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ProjectTerm IsDupProjectTerm = new ProjectTerm();
                    IsDupProjectTerm.Category = ddlCategory.SelectedValue;
                    IsDupProjectTerm.Term = txtTermName.Text;
                    IsDupProjectTerm.TermCode = txtTermCode.Text;
                    IsDupProjectTerm.IsActive = true;
                    IsDupProjectTerm.CompanyID = this.CompanyID;

                    List<ProjectTerm> LstDupProjectTerm = ProjectTermBLL.GetAll(IsDupProjectTerm);
                    if (LstDupProjectTerm.Count > 0)
                    {
                        if (this.TermID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupProjectTerm[0].TermID)) != Convert.ToString(this.TermID.ToString()))
                            {
                                IsInsert = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsInsert = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    if (this.TermID != Guid.Empty)
                    {
                        ProjectTerm objUpd = new ProjectTerm();
                        ProjectTerm objOldPT = new ProjectTerm();
                        objUpd = ProjectTermBLL.GetByPrimaryKey(this.TermID);
                        objOldPT = ProjectTermBLL.GetByPrimaryKey(this.TermID);

                        objUpd.Category = ddlCategory.SelectedValue;
                        objUpd.TermCode = txtTermCode.Text.Trim();
                        //objUpd.ForeColor = txtForeColor.Text.Trim();
                        //objUpd.BackColor = txtBackColor.Text.Trim();
                        objUpd.LastUpdatedOn = DateTime.Now;
                        objUpd.DisplayTerm = txtTermName.Text;
                        ProjectTermBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPT.ToString(), objUpd.ToString(), "mst_ProjectTerm");
                        IsInsert = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.TermID = Guid.Empty;
                    }
                    else
                    {
                        ProjectTerm objIns = new ProjectTerm();

                        objIns.Category = ddlCategory.SelectedValue;
                        objIns.Term = txtTermName.Text.Trim();
                        objIns.TermCode = txtTermCode.Text.Trim();
                        //objIns.ForeColor = txtForeColor.Text.Trim();
                        //objIns.BackColor = txtBackColor.Text.Trim();
                        objIns.IsActive = true;
                        objIns.LastUpdatedOn = DateTime.Now;
                        objIns.CompanyID = this.CompanyID;
                        objIns.DisplayTerm = txtTermName.Text;
                        ProjectTermBLL.Save(objIns);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "mst_ProjectTerm");
                        IsInsert = true;
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
        /// Cancel Button Event
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
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        #endregion Button Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProjectTermYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TermID != Guid.Empty)
                {
                    msgbx.Hide();
                    ProjectTerm objDelete = ProjectTermBLL.GetByPrimaryKey(this.TermID);
                    ProjectTerm objOldPTDeleteData = ProjectTermBLL.GetByPrimaryKey(this.TermID);

                    objDelete.IsActive = false;

                    ProjectTermBLL.Update(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objOldPTDeleteData.ToString(), null, "mst_ProjectTerm");

                    IsInsert = true;
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
        protected void btnProjectTermNo_Click(object sender, EventArgs e)
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

        #region Grid Event
        /// <summary>
        /// Data Grid Row DataBound Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProjectTermList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditData"))
            {
                this.TermID = new Guid(Convert.ToString(e.CommandArgument));
                LoadAccess();
                LoadData();
                
            }
            else if (e.CommandName.Equals("DeleteData"))
            {
                this.TermID = new Guid(Convert.ToString(e.CommandArgument));
                DeleteMsg.Show();

            }
        }
        #endregion Grid Event

        #region Grid Row Data Bound
        /// <summary>
        /// Project Term List Row Data Bound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdProjectTermList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               

                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DeleteImg = (ImageButton)e.Row.FindControl("btnDelete");

                EditImg.Enabled = Convert.ToBoolean(ViewState["View"]);
                

                bool? IsDefault = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsDefault"));

                ImageButton imgbtnDelete = (ImageButton)e.Row.FindControl("btnDelete");

                
                if (IsDefault == true)
                    imgbtnDelete.Visible = false;
                else
                    DeleteImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }

        #endregion Grid Row Data Bound

        #region Delete Popup
        /// <summary>
        /// Yes Delete Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYesDelete_Click(object sender, EventArgs e)
        {
            ProjectTerm Del = ProjectTermBLL.GetByPrimaryKey(this.TermID);
            //Del.IsActive = false;
            ProjectTermBLL.Delete(this.TermID);
            ActionLogBLL.Save(null, "Delete", Del.ToString(), null, "Mst_ProjectTerm");
            IsInsert = true;
            lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
            this.TermID = new Guid(Guid.Empty.ToString());
            DeleteMsg.Hide();
            ClearControl();
        }
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            this.TermID = new Guid(Guid.Empty.ToString());
            DeleteMsg.Hide();
        }
        #endregion Delete Popup
    }
}
