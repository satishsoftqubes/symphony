using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{

    public partial class CtrlRoomService : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;

        public Guid RoomServiceID
        {
            get
            {
                return ViewState["RoomServiceID"] != null ? new Guid(Convert.ToString(ViewState["RoomServiceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomServiceID"] = value;
            }
        }

        public Guid ItemID
        {
            get
            {
                return ViewState["ItemID"] != null ? new Guid(Convert.ToString(ViewState["ItemID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ItemID"] = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());
            if (!IsPostBack)
            {
                CheckUserAuthorization();
                mvRoomService.ActiveViewIndex = 0;
                BindGridRoomServiceList();
                SetPageLableText();
                BindBreadCrumb();
            }
        }

        #region Button Event
        protected void btnTopAdd_Click(object sender, EventArgs e)
        {
            mvRoomService.ActiveViewIndex = 1;
            ClearControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                try
                {
                    if (this.ItemID != Guid.Empty)
                    {
                        Item objUpd = new Item();

                        objUpd = ItemBLL.GetByPrimaryKey(this.ItemID);

                        objUpd.CompanyID = clsSession.CompanyID;
                        objUpd.PropertyID = clsSession.PropertyID;

                        objUpd.ItemName = txtTitle.Text.Trim();

                        objUpd.ItemDetails = Convert.ToString(txtDescription.Text.Trim());
                        objUpd.IsRoomService = true;
                        objUpd.PostingAcctID = new Guid("9D4ADA1C-89C6-4F23-8480-153D0D250FA7");


                        objUpd.UpdatedBy = clsSession.UserID;
                        objUpd.UpdatedOn = DateTime.Now.Date;

                        ItemBLL.Update(objUpd);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", null, objUpd.ToString(), "mst_Item");
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Item objIns = new Item();
                        objIns.CompanyID = clsSession.CompanyID;
                        objIns.PropertyID = clsSession.PropertyID;
                        objIns.ItemName = txtTitle.Text.Trim();
                        objIns.ItemDetails = Convert.ToString(txtDescription.Text.Trim());
                        objIns.IsRoomService = true;
                        objIns.IsActive = true;

                        ItemBLL.Save(objIns);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Item");
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    }

                    BindGridRoomServiceList();
                    ClearControl();
                    mvRoomService.ActiveViewIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {

            mvRoomService.ActiveViewIndex = 0;
            BindGridRoomServiceList();
            ClearControl();
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGridRoomServiceList();

        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearControl();
                BindGridRoomServiceList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Event

        protected void gvRoomService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemID")));

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrTitle")).Text = clsCommon.GetGlobalResourceText("RoomService", "lblGvHdrTitle", "Item");

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

        protected void gvRoomService_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    mvRoomService.ActiveViewIndex = 1;

                    this.ItemID = new Guid(Convert.ToString(e.CommandArgument));
                    Item objItem = new Item();
                    objItem = ItemBLL.GetByPrimaryKey(this.ItemID);
                    if (objItem != null)
                    {
                        txtTitle.Text = objItem.ItemName;
                        txtDescription.Text = objItem.ItemDetails;
                    }

                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.ItemID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomService_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomServiceList.PageIndex = e.NewPageIndex;
            BindGridRoomServiceList();
        }

        #endregion

        #region Private Methode

        private void ClearControl()
        {
            txtDescription.Text = "";
            txtTitle.Text = "";
            txtSearchTitle.Text = "";
            this.ItemID = Guid.Empty;
        }

        private void SetPageLableText()
        {

            litMainHeaderRoomService.Text = clsCommon.GetGlobalResourceText("RoomService", "litMainHeaderTranscript", "Room Service");
            litSearchTitle.Text = clsCommon.GetGlobalResourceText("RoomService", "litSearchTitle", "Item");
            litTitle.Text = clsCommon.GetGlobalResourceText("RoomService", "litTitle", "Item");
            litDescription.Text = clsCommon.GetGlobalResourceText("RoomService", "litDescription", "Description");
            btnButtomAdd.Text = btnTopAdd.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litRoomServiceList.Text = clsCommon.GetGlobalResourceText("RoomService", "litRecovery", "Room Service List");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("RoomService", "litMainHeaderTranscript", "Room Service");
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITTYPESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindGridRoomServiceList()
        {
            try
            {
                string Title = null;

                if (txtSearchTitle.Text.Trim() != string.Empty)
                    Title = Convert.ToString(txtSearchTitle.Text.Trim());
                else
                    Title = null;

                List<Item> litItem = ItemBLL.SearchDataForRoomService(clsSession.PropertyID, clsSession.CompanyID, Title);
                gvRoomServiceList.DataSource = litItem;
                gvRoomServiceList.DataBind();
            }
            catch (Exception ex)
            {
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Room Service"; //clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitList", "Room Service");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Popup Event


        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    Item objDelete = new Item();
                    objDelete = ItemBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    ItemBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Item");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                    BindGridRoomServiceList();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindGridRoomServiceList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}