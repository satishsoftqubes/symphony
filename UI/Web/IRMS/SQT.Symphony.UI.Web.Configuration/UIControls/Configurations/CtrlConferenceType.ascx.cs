using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlConferenceType : System.Web.UI.UserControl
    {
        #region Property and Variables
        // property to save companyid;
        public Guid ConferenceTypeID
        {
            get
            {
                return ViewState["ConferenceTypeID"] != null ? new Guid(Convert.ToString(ViewState["ConferenceTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ConferenceTypeID"] = value;
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

        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Property and Variables

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Grid Event

        protected void gvConferenceTypeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvConferenceTypeList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvConferenceTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControl();
                    mpeAddEditConferenceType.Show();
                    this.ConferenceTypeID = new Guid(Convert.ToString(e.CommandArgument));
                    ConferenceType objConferenceType = new ConferenceType();
                    objConferenceType = ConferenceTypeBLL.GetByPrimaryKey(this.ConferenceTypeID);
                    if (objConferenceType != null)
                    {
                        txtConferenceTypeName.Text = Convert.ToString(objConferenceType.ConferenceTypeName);
                        //txtMaximumCapacity.Text = Convert.ToString(objConferenceType.MaximumCapacity);
                    }
                }
                else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.ConferenceTypeID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                mpeAddEditConferenceType.Hide();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvConferenceTypeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ConferenceTypeID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrConferenceTypeName")).Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblGvHdrConferenceTypeName", "Conference Sitting Arrangement");
                    //((Label)e.Row.FindControl("lblGvHdrMaximumCapacity")).Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblGvHdrMaximumCapacity", "Maximum Capacity");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                mpeAddEditConferenceType.Hide();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Control Event

        protected void btnAddTopConferenceType_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1"; 
                ClearControl();
                mpeAddEditConferenceType.Show();
            }
            catch (Exception ex)
            {
                mpeAddEditConferenceType.Hide();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Save And Update Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateConferenceType();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditConferenceType.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditConferenceType.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Save And Update Department with Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateConferenceType();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditConferenceType.Hide();
                        IsListMessage = true;

                        if (this.ConferenceTypeID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditConferenceType.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }


        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvConferenceTypeList.PageIndex = 0;
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

        #region Popup Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeAddEditConferenceType.Hide();
                    ConferenceType objDelete = new ConferenceType();
                    objDelete = ConferenceTypeBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    ConferenceTypeBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_ConfConferenceType");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
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

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CONFERENCEBANQUETTYPES.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomConferenceType.Visible = btnAddTopConferenceType.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindGrid();
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblConferenceBanquetTypes", "Conference Sitting Arrangement");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string ConferenceTypeName = null;
                        
            if (txtSearchConferenceTypeName.Text.Trim() != "")
                ConferenceTypeName = txtSearchConferenceTypeName.Text.Trim();

            DataSet dsSearchConferenceType = ConferenceTypeBLL.SearchConferenceTypeData(null, clsSession.PropertyID, clsSession.CompanyID, ConferenceTypeName);

            gvConferenceTypeList.DataSource = dsSearchConferenceType.Tables[0];
            gvConferenceTypeList.DataBind();
        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblMainHeader", "CONFERENCE SITTING ARRANGEMENT");
            ltrSearchConferenceTypeName.Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblSearchConferenceTypeName", "Conference Sitting Arrangement");
            btnAddTopConferenceType.Text = btnAddBottomConferenceType.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConferenceTypeList.Text = clsCommon.GetGlobalResourceText("ConferenceType", "ltrConferenceTypeList", "Conference Sitting Arrangement List");
            ltrHeaderPopupConferenceType.Text = clsCommon.GetGlobalResourceText("ConferenceType", "ltrHeaderPopupConferenceType", "Conference Sitting Arrangement");
            ltrConferenceTypeName.Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblConferenceTypeName", "Conference Sitting Arrangement");
            //ltrMaximumCapacity.Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblMaximumCapacity", "Maximum Capacity");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancelDelete.Text = btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("ConferenceType", "lblHeaderConfirmDeletePopup", "Conference Sitting Arrangement");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");             
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }
        /// <summary>
        /// Insert and Update Department
        /// </summary>
        private void SaveAndUpdateConferenceType()
        {
            ConferenceType IsConferenceTypeDup = new ConferenceType();
            IsConferenceTypeDup.ConferenceTypeName = txtConferenceTypeName.Text.Trim();
            IsConferenceTypeDup.IsActive = true;
            IsConferenceTypeDup.PropertyID = clsSession.PropertyID;
            List<ConferenceType> LstDupConferenceType = null;
            LstDupConferenceType = ConferenceTypeBLL.GetAll(IsConferenceTypeDup);

            if (LstDupConferenceType.Count > 0)
            {
                if (this.ConferenceTypeID != Guid.Empty)
                {
                    if (Convert.ToString((LstDupConferenceType[0].ConferenceTypeID)) != Convert.ToString(this.ConferenceTypeID))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditConferenceType.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditConferenceType.Show();
                    return;
                }
            }

            if (this.ConferenceTypeID != Guid.Empty)
            {
                ConferenceType objToUpdate = new ConferenceType();
                ConferenceType objOldCTData = new ConferenceType();
                objToUpdate = ConferenceTypeBLL.GetByPrimaryKey(this.ConferenceTypeID);
                objOldCTData = ConferenceTypeBLL.GetByPrimaryKey(this.ConferenceTypeID);


                objToUpdate.ConferenceTypeName = txtConferenceTypeName.Text.Trim();
                //if (txtMaximumCapacity.Text.Trim() != "")
                //    objToUpdate.MaximumCapacity = Convert.ToInt32(txtMaximumCapacity.Text.Trim());
                //else
                //    objToUpdate.MaximumCapacity = null;
                objToUpdate.UpdatedOn = DateTime.Now;
                objToUpdate.UpdatedBy = clsSession.UserID;


                ConferenceTypeBLL.Update(objToUpdate);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCTData.ToString(), objToUpdate.ToString(), "mst_ConfConferenceType");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                ConferenceType objToInsert = new ConferenceType();

                objToInsert.CompanyID = clsSession.CompanyID;
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.ConferenceTypeName = txtConferenceTypeName.Text.Trim();
                //if (txtMaximumCapacity.Text.Trim() != "")
                //    objToInsert.MaximumCapacity = Convert.ToInt32(txtMaximumCapacity.Text.Trim());
                objToInsert.IsActive = true;
                objToInsert.UpdatedOn = DateTime.Now;
                objToInsert.UpdatedBy = clsSession.UserID;

                objToInsert.IsSynch = false;

                ConferenceTypeBLL.Save(objToInsert);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_ConfConferenceType");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            BindGrid();

        }
        /// <summary>
        /// Clear Control Method
        /// </summary>
        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.ConferenceTypeID = Guid.Empty;
            txtConferenceTypeName.Text = "";
            //txtMaximumCapacity.Text = "";
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchConferenceTypeName.Text = "";
        }
        #endregion Private Method
    }
}