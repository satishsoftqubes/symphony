using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;


namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlUnitOfMeasure : System.Web.UI.UserControl
    {
        #region Variable & Property

        public Guid UOMID
        {
            get
            {
                return ViewState["UOMID"] != null ? new Guid(Convert.ToString(ViewState["UOMID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UOMID"] = value;
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


        /// <summary>
        /// Form Load Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 



        #endregion Variable & Property

        #region Form Load

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

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITOFMEASURE.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddTopUnitOfMeasure.Visible = btnAddBottomUnitOfMeasure.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblMainHeader", "UNIT OF MEASURE");
            litSearchUnitOfMeasureName.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblSearchUnitOfMeasureName", "Name");
            btnAddTopUnitOfMeasure.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "btnAddTopUnitOfMeasure", "ADD NEW");
            litUnitOfMeasureList.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblUnitOfMeasureList", "Unit Of Measure List");
            litUnitOfMeasure.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblUnitOfMeasure", "UOM Code");
            litUnitOfMeasureCode.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblUnitOfMeasureCode", "UOM Code");
            litHeaderPopupUnitOfMeasure.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblHeaderPopupUnitOfMeasure", "UNIT OF MEASURE");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblHeaderConfirmDeletePopup", "Unit Of Measure");

            btnAddTopUnitOfMeasure.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnAddBottomUnitOfMeasure.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");

            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        private void SaveAndUpdateUOM()
        {
            UOM IsCurr = new UOM();
            IsCurr.UOMName = txtUnitOfMeasure.Text.Trim();
            IsCurr.IsActive = true;
            IsCurr.PropertyID = clsSession.PropertyID;
            IsCurr.CompanyID = clsSession.CompanyID;
            List<UOM> LstUnit = null;
            LstUnit = UOMBLL.GetAll(IsCurr);

            if (LstUnit.Count > 0)
            {
                if (this.UOMID != Guid.Empty)
                {
                    if (Convert.ToString(LstUnit[0].UOMID) != Convert.ToString(this.UOMID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditUnitOfMeasure.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditUnitOfMeasure.Show();
                    return;

                }
            }
            if (this.UOMID != Guid.Empty)
            {
                UOM objUpd = new UOM();
                UOM objOldCurr = new UOM();
                objUpd = UOMBLL.GetByPrimaryKey(this.UOMID);
                objOldCurr = UOMBLL.GetByPrimaryKey(this.UOMID);

                objUpd.UOMName = txtUnitOfMeasure.Text.Trim();
                objUpd.UOMCode = txtUnitOfMeasureCode.Text.Trim();
               
                UOMBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_UOM");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            }
            else
            {
                UOM objIns = new UOM();
                objIns.UOMName = txtUnitOfMeasure.Text.Trim();
                objIns.UOMCode = txtUnitOfMeasureCode.Text.Trim();
                
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsSynch = false;
                objIns.IsActive = true;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;

                UOMBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_UOM");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblMaterialManagementSetup", "Item Master Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitOfMeasure", "Unit Of Measure") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.UOMID = Guid.Empty;
            txtUnitOfMeasure.Text = txtUnitOfMeasureCode.Text = "";
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSUnitOfMeasureName.Text = "";
        }
        #endregion Private Method

        #region Grid Event

        private void BindGrid()
        {
            UOM objUnit = new UOM();
            if (!txtSUnitOfMeasureName.Text.Trim().Equals(""))
                objUnit.UOMName = txtSUnitOfMeasureName.Text.Trim();
            
          
            objUnit.PropertyID = clsSession.PropertyID;
            objUnit.CompanyID = clsSession.CompanyID;
            objUnit.IsActive = true;

            List<UOM> lstUOM = UOMBLL.GetAll(objUnit);
            lstUOM.Sort((UOM d1, UOM d2) => d1.UOMName.CompareTo(d2.UOMName));

            gvUnitOfMeasureList.DataSource = lstUOM;
            gvUnitOfMeasureList.DataBind();

        }

        protected void gvUnitOfMeasureList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                ((LinkButton)e.Row.FindControl("lnkDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UOMID")));

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrNo")).Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblGvHdrNo", "No.");
                ((Label)e.Row.FindControl("lblGvHdrName")).Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblGvHdrName", "Name");
                ((Label)e.Row.FindControl("lblGvHdrCode")).Text = clsCommon.GetGlobalResourceText("UnitOfMeasure", "lblGvHdrCode", "Code");
                ((Label)e.Row.FindControl("lblGvHdrViewDelete")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }

        }

        protected void gvUnitOfMeasureList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnitOfMeasureList.PageIndex = e.NewPageIndex;
        }

        protected void gvUnitOfMeasureList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                mpeAddEditUnitOfMeasure.Show();
                this.UOMID = new Guid(Convert.ToString(e.CommandArgument));
                UOM objCurrency = new UOM();
                objCurrency = UOMBLL.GetByPrimaryKey(this.UOMID);
                if (objCurrency != null)
                {
                    txtUnitOfMeasure.Text = objCurrency.UOMName;
                    txtUnitOfMeasureCode.Text = objCurrency.UOMCode;

                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.UOMID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }


        #endregion Grid Event

        #region Button Event

        protected void btnAddTopUnitOfMeasure_Click(object sender, EventArgs e)
        {
            btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            mpeAddEditUnitOfMeasure.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateUOM();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditUnitOfMeasure.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditUnitOfMeasure.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }      

        protected void btnSaveAndClose_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateUOM();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditUnitOfMeasure.Hide();
                        IsListMessage = true;

                        if (this.UOMID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditUnitOfMeasure.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }       

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }       

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeAddEditUnitOfMeasure.Hide();
                    UOM objDelete = new UOM();
                    objDelete = UOMBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    UOMBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_UOM");
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
    }
}