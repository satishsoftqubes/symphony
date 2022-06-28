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
    public partial class CtrlCounterName : System.Web.UI.UserControl
    {
        #region Property and Variables
        // property to save companyid;
        public Guid CounterID
        {
            get
            {
                return ViewState["CounterID"] != null ? new Guid(Convert.ToString(ViewState["CounterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CounterID"] = value;
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

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "COUNTERSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomCounterName.Visible = btnAddTopCounterName.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("CounterName", "lblMainHeader", "COUNTER SETUP");
            //ltrMsgList.Text = clsCommon.GetGlobalResourceText("CounterName", "lblMsgList", "");
            btnAddTopCounterName.Text = btnAddBottomCounterName.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litSearchCounterName.Text = clsCommon.GetGlobalResourceText("CounterName", "lblSearchCounterName", "Counter No.");
            ltrCounterNameList.Text = clsCommon.GetGlobalResourceText("CounterName", "lblCounterNameList", "Counter No. List");
            ltrHeaderPopupCounterName.Text = clsCommon.GetGlobalResourceText("CounterName", "lblHeaderPopupCounterName", "Counter No.");
            litCounterName.Text = clsCommon.GetGlobalResourceText("CounterName", "lblCounterName", "Counter No.");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("CounterName", "lblHeaderConfirmDeletePopup", "Counter No.");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");

            litTransactionZone.Text = "Location";
            litPos.Text = "POS";
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCounterSetup", "Counter Setup");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindTransactionZone();                
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
            string strCounterNo = null;
            if (txtSearchCounterName.Text.Trim() != "")
                strCounterNo = txtSearchCounterName.Text.Trim();

            DataSet dsCounterData = CountersBLL.SearchCounterData(null, clsSession.PropertyID, clsSession.CompanyID, strCounterNo);

            if (dsCounterData.Tables.Count > 0 && dsCounterData.Tables[0].Rows.Count > 0)
            {
                gvCounterNameList.DataSource = dsCounterData.Tables[0];
                gvCounterNameList.DataBind();
            }
            else
            {
                gvCounterNameList.DataSource = null;
                gvCounterNameList.DataBind();
            }
            
        }
        /// <summary>
        /// Insert and Update Department
        /// </summary>
        private void SaveAndUpdateCounters()
        {
            Counters IsDeptCounters = new Counters();
            IsDeptCounters.CounterNo = txtCounterName.Text.Trim();
            IsDeptCounters.IsActive = true;
            IsDeptCounters.PropertyID = clsSession.PropertyID;
            List<Counters> LstDupCounters = null;
            LstDupCounters = CountersBLL.GetAll(IsDeptCounters);

            if (LstDupCounters.Count > 0)
            {
                if (this.CounterID != Guid.Empty)
                {
                    if (Convert.ToString((LstDupCounters[0].CounterID)) != Convert.ToString(this.CounterID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditCounterName.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditCounterName.Show();
                    return;
                }
            }

            if (this.CounterID != Guid.Empty)
            {
                Counters objToUpdate = new Counters();
                Counters objOldCountersData = new Counters();
                objToUpdate = CountersBLL.GetByPrimaryKey(this.CounterID);
                objOldCountersData = CountersBLL.GetByPrimaryKey(this.CounterID);

                objToUpdate.CounterNo = txtCounterName.Text.Trim();
                objToUpdate.Location_TermID = new Guid(ddlTransactionZone.SelectedValue);
                objToUpdate.POSPointID = new Guid(ddlPos.SelectedValue);
                objToUpdate.UpdatedOn = DateTime.Now;
                objToUpdate.UpdatedBy = clsSession.UserID;

                CountersBLL.Update(objToUpdate);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCountersData.ToString(), objToUpdate.ToString(), "mst_Counters");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                Counters objInsert = new Counters();

                objInsert.CompanyID = clsSession.CompanyID;
                objInsert.PropertyID = clsSession.PropertyID;
                objInsert.CounterNo = txtCounterName.Text.Trim();
                objInsert.IsActive = true;
                objInsert.UpdatedOn = DateTime.Now;
                objInsert.UpdatedBy = clsSession.UserID;
                objInsert.IsDefault = false;
                objInsert.IsSynch = false;
                objInsert.Location_TermID = new Guid(ddlTransactionZone.SelectedValue);
                objInsert.POSPointID = new Guid(ddlPos.SelectedValue);

                CountersBLL.Save(objInsert);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objInsert.ToString(), objInsert.ToString(), "mst_Counters");
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
            this.CounterID = Guid.Empty;
            txtCounterName.Text = "";
            ddlTransactionZone.SelectedIndex = 0;
            ddlPos.Items.Clear();
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            ddlPos.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }
        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchCounterName.Text = "";
        }

        private void BindTransactionZone()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            ddlTransactionZone.Items.Clear();
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "TRANSACTION ZONE");
            if (lstProjectTermTitle.Count != 0)
            {
                ddlTransactionZone.DataSource = lstProjectTermTitle;
                ddlTransactionZone.DataTextField = "DisplayTerm";
                ddlTransactionZone.DataValueField = "TermID";
                ddlTransactionZone.DataBind();
                ddlTransactionZone.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlTransactionZone.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        private void BindPOS()
        {
            try
            {
                string strPOSQuery = "select PosPointName,POSPointID from pos_POSPoints where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and POSLocation_TermID = '" + Convert.ToString(ddlTransactionZone.SelectedValue) + "' and IsActive = 1 order by PosPointName asc";
                DataSet dsPOS = POSPointsBLL.SelectPosPoints(strPOSQuery);

                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                if (dsPOS.Tables.Count > 0 && dsPOS.Tables[0].Rows.Count > 0)
                {
                    ddlPos.DataSource = dsPOS.Tables[0];
                    ddlPos.DataTextField = "PosPointName";
                    ddlPos.DataValueField = "POSPointID";
                    ddlPos.DataBind();
                    ddlPos.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlPos.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Command Evnet
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvCounterNameList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                mpeAddEditCounterName.Show();
                this.CounterID = new Guid(Convert.ToString(e.CommandArgument));
                Counters objCounters = new Counters();
                objCounters = CountersBLL.GetByPrimaryKey(this.CounterID);
                if (objCounters != null)
                {
                    txtCounterName.Text = Convert.ToString(objCounters.CounterNo);
                    ddlTransactionZone.SelectedIndex = ddlTransactionZone.Items.FindByValue(Convert.ToString(objCounters.Location_TermID)) != null ? ddlTransactionZone.Items.IndexOf(ddlTransactionZone.Items.FindByValue(Convert.ToString(objCounters.Location_TermID))) : 0;
                    ddlTransactionZone_SelectedIndexChanged(null,null);
                    ddlPos.SelectedIndex = ddlPos.Items.FindByValue(Convert.ToString(objCounters.POSPointID)) != null ? ddlPos.Items.IndexOf(ddlPos.Items.FindByValue(Convert.ToString(objCounters.POSPointID))) : 0;
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.CounterID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        /// <summary>
        /// Grid Row Data Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvCounterNameList_RowDataBound(object sender, GridViewRowEventArgs e)
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

                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CounterID")));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrCounterNo")).Text = clsCommon.GetGlobalResourceText("CounterName", "lblGvHdrCounterNo", "Counter No.");
                ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        /// <summary>
        /// Paging Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCounterNameList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCounterNameList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Counter
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>        
        protected void btnAddTopCounterName_Click(object sender, EventArgs e)
        {
            btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            mpeAddEditCounterName.Show();
        }

        /// <summary>
        /// Save And Update Counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateCounters();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditCounterName.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditCounterName.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Save And Update Counter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateCounters();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditCounterName.Hide();
                        IsListMessage = true;

                        if (this.CounterID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditCounterName.Hide();
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
                gvCounterNameList.PageIndex = 0;
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

        #region Popup Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeAddEditCounterName.Hide();
                    Counters objDelete = new Counters();
                    objDelete = CountersBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    CountersBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Counters");
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

        #region DropDown Event
        protected void ddlTransactionZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mpeAddEditCounterName.Show();
                ddlPos.Items.Clear();
                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

                if (ddlTransactionZone.SelectedIndex != 0)
                {
                    BindPOS();
                }
                else
                    ddlPos.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion DropDown Event
    }
}