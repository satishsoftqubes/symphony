using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlGuestType : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;

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

        #endregion Variable and Property

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPageData();
                mvGuestyType.ActiveViewIndex = 0;
            }
        }

        #region Method

        private void BindPageData()
        {
            CheckUserAuthorization();
            BindBreadCrumb();
            SetPageLable();
            BindGridGuestType();
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomGuestyType.Visible = btnAddTopGuestyType.Visible = this.UserRights.Substring(1, 1) == "1";
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Guest Type";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetPageLable()
        {
            litDescription.Text = clsCommon.GetGlobalResourceText("GuestType", "litDescription", "Description");
            litType.Text = clsCommon.GetGlobalResourceText("GuestType", "litType", "Guest Type");
            litMainHeader.Text = clsCommon.GetGlobalResourceText("GuestType", "litMainHeader", "Guest Type");
            litGuestyTypeList.Text = clsCommon.GetGlobalResourceText("GuestType", "litGuestyTypeList", "Guest Type List");
            btnAddBottomGuestyType.Text = btnAddTopGuestyType.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
        }

        private void BindGridGuestType()
        {
            string strTerm = null;

            if (txtSearchType.Text != "")
                strTerm = txtSearchType.Text.Trim();

            List<ProjectTerm> lstProjectTermGuestType = ProjectTermBLL.SelectAllByCategoryAndTerm(clsSession.CompanyID, clsSession.PropertyID, "GUESTTYPE", strTerm);

            gvGuestyTypeList.DataSource = lstProjectTermGuestType;
            gvGuestyTypeList.DataBind();
        }

        private void ClearControl()
        {
            txtDescription.Text = "";
            txtSearchType.Text = "";
            txtType.Text = "";
            this.TermID = Guid.Empty;
        }

        #endregion

        #region GridEvent

        protected void gvRoomList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestyTypeList.PageIndex = e.NewPageIndex;
            BindGridGuestType();
        }

        protected void gvRoomList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TermID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrGuestType")).Text = clsCommon.GetGlobalResourceText("GuestType", "litType", "Guest Type");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");

                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void gvRoomList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    this.TermID = new Guid(Convert.ToString(e.CommandArgument));
                    ProjectTerm objProTerm = new ProjectTerm();
                    objProTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    txtType.Text = objProTerm.Term;
                    txtDescription.Text = objProTerm.Description;

                    mvGuestyType.ActiveViewIndex = 1;

                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.TermID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion GridEvent

        #region Button Event

        protected void btnAddBottomGuestyType_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            mvGuestyType.ActiveViewIndex = 1;
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            mvGuestyType.ActiveViewIndex = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridGuestType();
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            ClearControl();
            BindGridGuestType();

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                List<ProjectTerm> lstProjectTermDub = ProjectTermBLL.SelectAllByCategoryAndTerm(clsSession.CompanyID, clsSession.PropertyID, "GUESTTYPE", txtType.Text);

                if (lstProjectTermDub != null && lstProjectTermDub.Count > 0)
                {
                    if (this.TermID != Guid.Empty)
                    {
                        if (lstProjectTermDub[0].TermID != this.TermID)
                        {
                            //Duplicate record exist.
                            IsListMessage = true;
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }
                    else
                    {
                        //If Record is in new mode, then Duplicate record exist.
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        return;
                    }
                }

                if (this.TermID != Guid.Empty)
                {
                    ProjectTerm objOldProTerm = new ProjectTerm();
                    ProjectTerm objUpdProTerm = new ProjectTerm();

                    objOldProTerm = ProjectTermBLL.GetByPrimaryKey(this.TermID);
                    objUpdProTerm = ProjectTermBLL.GetByPrimaryKey(this.TermID);


                    objUpdProTerm.Term = txtType.Text.Trim();
                    objUpdProTerm.DisplayTerm = txtType.Text.Trim();

                    objUpdProTerm.Description = txtDescription.Text.Trim();

                    ProjectTermBLL.Update(objUpdProTerm);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldProTerm.ToString(), objUpdProTerm.ToString(), "mst_ProjectTerm");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                }
                else
                {
                    ProjectTerm objSave = new ProjectTerm();

                    objSave.CompanyID = clsSession.CompanyID;
                    objSave.PropertyID = clsSession.PropertyID;
                    objSave.Term = txtType.Text.Trim();
                    objSave.DisplayTerm = txtType.Text.Trim();
                    objSave.Category = "GUESTTYPE";
                    objSave.IsActive = true;
                    objSave.IsDefault = true;
                    objSave.Description = txtDescription.Text.Trim();

                    ProjectTermBLL.Save(objSave);
                    ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Save", objSave.ToString(), objSave.ToString(), "mst_ProjectTerm");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ClearControl();
            BindGridGuestType();
        }

        #endregion

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    ProjectTerm objDelete = new ProjectTerm();
                    objDelete = ProjectTermBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    ProjectTermBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_ProjectTerm");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGridGuestType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

    }
}