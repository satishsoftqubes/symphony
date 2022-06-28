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
    public partial class CtrlDeposits : System.Web.UI.UserControl
    {
        #region Property and Variables
        public Guid DepositID
        {
            get
            {
                return ViewState["DepositID"] != null ? new Guid(Convert.ToString(ViewState["DepositID"])) : Guid.Empty;
            }
            set
            {
                ViewState["DepositID"] = value;
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

        #endregion

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "DEPOSIT.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomDeposit.Visible = btnAddTopDeposit.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindData()
        {
            try
            {
                regExpRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regExpRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
                SetPageLables();
                BindGrid();
                BindAmount();
                SetPercentageMaxValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrid()
        {
            Deposits objDeposit = new Deposits();
            if (txtSDepositName.Text.Trim() != "")
                objDeposit.DepositName = txtSDepositName.Text.Trim();
            objDeposit.PropertyID = clsSession.PropertyID;
            objDeposit.CompanyID = clsSession.CompanyID;
            objDeposit.IsActive = true;

            List<Deposits> lstDeposits = DepositsBLL.GetAllSearchData(objDeposit);

            gvDepositList.DataSource = lstDeposits;
            gvDepositList.DataBind();

        }

        private void BindAmount()
        {
            //ProjectTerm objAmount = new ProjectTerm();
            //objAmount.Category = "perflat";
            //objAmount.PropertyID = clsSession.PropertyID;
            //objAmount.CompanyID = clsSession.CompanyID;
            //objAmount.IsActive = true;

            //List<ProjectTerm> lstDeposits = ProjectTermBLL.GetAll(objAmount);
            //if (lstDeposits.Count > 0)
            //{
            //    ddlAmount.DataSource = lstDeposits;
            //    ddlAmount.DataTextField = "DisplayTerm";
            //    ddlAmount.DataValueField = "Term";
            //    ddlAmount.DataBind();
            //    ddlAmount.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            //}
            //else
            //    ddlAmount.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            ddlAmount.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlAmount.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDeposit", "Deposit") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Deposits", "lblMainHeader", "DEPOSIT");
            litSDepositName.Text = clsCommon.GetGlobalResourceText("Deposits", "lblSDepositName", "Deposit");
            btnAddBottomDeposit.Text = btnAddTopDeposit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litDepositList.Text = clsCommon.GetGlobalResourceText("Deposits", "lblDepositList", "Deposit List");
            litDepositInputHeader.Text = clsCommon.GetGlobalResourceText("Deposits", "lblDepositInputHeader", "DEPOSIT SETUP");
            litDeposit.Text = clsCommon.GetGlobalResourceText("Deposits", "lblDeposit", "Deposit List");
            litDepositAmount.Text = clsCommon.GetGlobalResourceText("Deposits", "lblDepositAmount", "Amount");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Deposits", "lblHeaderConfirmDeletePopup", "Deposit");

            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancelDelete.Text = btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            rngvDeposit.Text = clsCommon.GetGlobalResourceText("Deposits", "lblMsgDepositMarginLimitInPercentage", "Percentage should be less than or equal to 100.");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        private void SaveAndUpdateDeposits()
        {
            Deposits IsDep = new Deposits();
            //IsCurr.Name = txtCurrency.Text.Trim();
            IsDep.DepositName = txtDeposit.Text.Trim();
            //   IsCurr.Rate = Convert.ToDecimal(txtRate.Text.Trim());
            IsDep.IsActive = true;
            IsDep.PropertyID = clsSession.PropertyID;
            IsDep.CompanyID = clsSession.CompanyID;
            List<Deposits> LstDep = null;
            LstDep = DepositsBLL.GetAll(IsDep);

            if (LstDep.Count > 0)
            {
                if (this.DepositID != Guid.Empty)
                {
                    if (Convert.ToString(LstDep[0].DepositID) != Convert.ToString(this.DepositID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeDepositData.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeDepositData.Show();
                    return;

                }
            }
            if (this.DepositID != Guid.Empty)
            {
                Deposits objUpd = new Deposits();
                Deposits objOldDep = new Deposits();
                objUpd = DepositsBLL.GetByPrimaryKey(this.DepositID);
                objOldDep = DepositsBLL.GetByPrimaryKey(this.DepositID);

                objUpd.DepositName = txtDeposit.Text.Trim();
                objUpd.DepositRate = Convert.ToDecimal(txtDepositAmount.Text.Trim());

                //if (ddlAmount.SelectedValue != Guid.Empty.ToString())
                //{
                //    if (ddlAmount.SelectedValue.Equals("%"))
                //        objUpd.IsFlat = false;
                //    else
                //        objUpd.IsFlat = true;
                //}
                //else
                //    objUpd.IsFlat = null;

                if (ddlAmount.SelectedValue != "0")
                    objUpd.IsFlat = true;
                else
                    objUpd.IsFlat = false;

                DepositsBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldDep.ToString(), objUpd.ToString(), "mst_Deposits");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            }
            else
            {
                Deposits objIns = new Deposits();
                objIns.DepositName = txtDeposit.Text.Trim();
                objIns.DepositRate = Convert.ToDecimal(txtDepositAmount.Text.Trim());
                //if (ddlAmount.SelectedValue != Guid.Empty.ToString())
                //{
                //    if (ddlAmount.SelectedValue.Equals("%"))
                //        objIns.IsFlat = false;
                //    else
                //        objIns.IsFlat = true;
                //}
                //else
                //    objIns.IsFlat = null;

                if (ddlAmount.SelectedValue != "0")
                    objIns.IsFlat = true;
                else
                    objIns.IsFlat = false;
               
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsSynch = false;
                objIns.IsActive = true;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;

                DepositsBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Deposits");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
        }

        public void SetPercentageMaxValue()
        {
            if (ddlAmount.SelectedIndex == 0)
                rngvDeposit.MaximumValue = "100";
            else
                rngvDeposit.MaximumValue = "999999999999999999";// 18 chars
        }

        private void ClearSearchControl()
        {
            txtSDepositName.Text = "";
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.DepositID = Guid.Empty;
            txtDeposit.Text = txtDepositAmount.Text = "";
            ddlAmount.SelectedIndex = 0;
            SetPercentageMaxValue();
        }
        #endregion Private Method

        #region GridView Event

        protected void gvDepositList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepositList.PageIndex = e.NewPageIndex;
        }

        protected void gvDepositList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = btnSaveAndExit.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                mpeDepositData.Show();
                this.DepositID = new Guid(Convert.ToString(e.CommandArgument));
                Deposits objDeposits = new Deposits();
                objDeposits = DepositsBLL.GetByPrimaryKey(this.DepositID);
                if (objDeposits != null)
                {
                    txtDeposit.Text = objDeposits.DepositName;

                    //if (objDeposits.IsFlat == null)
                    //    ddlAmount.SelectedIndex = 0;
                    //else if (objDeposits.IsFlat == false)
                    //    ddlAmount.SelectedValue = "%";
                    //else
                    //    ddlAmount.SelectedValue = "Flat";

                    if (Convert.ToBoolean(objDeposits.IsFlat))
                        ddlAmount.SelectedIndex = 1;
                    else
                        ddlAmount.SelectedIndex = 0;

                    SetPercentageMaxValue();

                    //ddlAmount.SelectedValue = Convert.ToString(objDeposits.IsFlat);
                    string strRate = Convert.ToString(objDeposits.DepositRate);
                    txtDepositAmount.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
          
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.DepositID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }

        }

        protected void gvDepositList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepositRate")) != string.Empty)
                {
                    Label lblRate = (Label)e.Row.FindControl("lblDepositAmount");
                    string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepositRate"));
                    if (strRate != string.Empty)
                    {
                        lblRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        if (!Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsFlat")))
                            lblRate.Text = lblRate.Text + " %";
                    }
                }

                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepositID")));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions","Actions");
                ((Label)e.Row.FindControl("lblGvHdrDepositName")).Text = clsCommon.GetGlobalResourceText("Deposits", "lblGvHdrDepositName", "Deposit Name");
                ((Label)e.Row.FindControl("lblGvHdrDepositAmount")).Text = clsCommon.GetGlobalResourceText("Deposits", "lblGvHdrDepositAmount", "Amount");

            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        #endregion

        #region Button Event
        
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

        protected void btnAddTopDeposit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = btnSaveAndExit.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            mpeDepositData.Show();
        }

        #endregion Button Event

        #region Popup Event
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeDepositData.Hide();
                    Deposits objDelete = new Deposits();
                    objDelete = DepositsBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    DepositsBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Deposits");
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateDeposits();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeDepositData.Show();
                }
                catch (Exception ex)
                {
                    mpeDepositData.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateDeposits();
                    if (!IsDuplicateRecord)
                    {
                        mpeDepositData.Hide();
                        IsListMessage = true;

                        if (this.DepositID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeDepositData.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            
        }
        
        #endregion

        #region Checkbox Event
        protected void ddlAmount_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetPercentageMaxValue();
            mpeDepositData.Show();
        }
        #endregion

    }
}