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
    public partial class CtrlCurrencySetup : System.Web.UI.UserControl
    {
        #region Variable & Property

        public Guid CurrencyID
        {
            get
            {
                return ViewState["CurrencyID"] != null ? new Guid(Convert.ToString(ViewState["CurrencyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CurrencyID"] = value;
            }

        }
        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Variable & Property

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                regExpRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regExpRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
                SetPageLables();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            Currency objCurrency = new Currency();
            if (!txtSrcCurrencyCode.Text.Trim().Equals(""))
                objCurrency.CurrencyCode = txtSrcCurrencyCode.Text.Trim();
            else
                objCurrency.CurrencyCode = null;
            if (!txtSrcCurrencyName.Text.Trim().Equals(""))
                objCurrency.Name = txtSrcCurrencyName.Text.Trim();
            else
                objCurrency.Name = null;
            objCurrency.PropertyID = clsSession.PropertyID;
            objCurrency.CompanyID = clsSession.CompanyID;
            objCurrency.IsActive = true;

            List<Currency> lstCurrency = CurrencyBLL.GetAll(objCurrency);
            lstCurrency.Sort((Currency d1, Currency d2) => d1.Name.CompareTo(d2.Name));

            gvCurrencyList.DataSource = lstCurrency;
            gvCurrencyList.DataBind();

        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeading.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrMainHeading", "CURRENCY SETUP");
            ltrCurrencyList.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrCurrencyList", "Currency List");
            ltrCurrencyHeading.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrCurrencyHeading", "CURRENCY SETUP");
            ltrCode.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrCode", "Code");
            ltrCurrency.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrCurrency", "Name");
            litRate.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "litRate", "Rate");
            btnAddBottomCurrency.Text = btnAddTopCurrency.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrSrcName.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrSrcName", "Name");
            ltrSrcCode.Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrSrcCode", "Code");

            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");

            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        private void SaveAndUpdateCurrency()
        {
            Currency IsCurr = new Currency();
            //IsCurr.Name = txtCurrency.Text.Trim();
            IsCurr.CurrencyCode = txtCode.Text.Trim();
            //   IsCurr.Rate = Convert.ToDecimal(txtRate.Text.Trim());
            IsCurr.IsActive = true;
            IsCurr.PropertyID = clsSession.PropertyID;
            IsCurr.CompanyID = clsSession.CompanyID;
            List<Currency> LstCurr = null;
            LstCurr = CurrencyBLL.GetAll(IsCurr);

            if (LstCurr.Count > 0)
            {
                if (this.CurrencyID != Guid.Empty)
                {
                    if (Convert.ToString(LstCurr[0].CurrencyID) != Convert.ToString(this.CurrencyID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditCurrency.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditCurrency.Show();
                    return;

                }
            }
            if (this.CurrencyID != Guid.Empty)
            {
                Currency objUpd = new Currency();
                Currency objOldCurr = new Currency();
                objUpd = CurrencyBLL.GetByPrimaryKey(this.CurrencyID);
                objOldCurr = CurrencyBLL.GetByPrimaryKey(this.CurrencyID);

                objUpd.Name = txtCode.Text.Trim();
                objUpd.CurrencyCode = txtCode.Text.Trim();
                objUpd.Rate = Convert.ToDecimal(txtRate.Text.Trim());
                objUpd.DisplayLocale = txtCurrency.Text.Trim();

                CurrencyBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_Currency");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            }
            else
            {
                Currency objIns = new Currency();
                objIns.Name = txtCurrency.Text.Trim();
                objIns.CurrencyCode = txtCode.Text.Trim();
                objIns.Rate = Convert.ToDecimal(txtRate.Text.Trim());
                objIns.DisplayLocale = txtCurrency.Text.Trim();
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsSynch = false;
                objIns.IsActive = true;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;

                CurrencyBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Currency");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.CurrencyID = Guid.Empty;
            txtCurrency.Text = txtCode.Text = txtRate.Text = "";
        }

        private void ClearSearchControl()
        {
            txtSrcCurrencyCode.Text = txtSrcCurrencyName.Text = string.Empty;
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCurrencySetup", "Currency Setup") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvCurrencyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete"); 

              //  txtRate.Text = strCurrencyRate.Substring(0, strCurrencyRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
               string strRate = DataBinder.Eval(e.Row.DataItem, "Rate").ToString();
                ((Label)e.Row.FindControl("lblRate")).Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Literal)e.Row.FindControl("ltrGvHdrCurrencyCode")).Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrGvHdrCurrencyCode", "Code");
                ((Literal)e.Row.FindControl("ltrGvHdrCurrencyName")).Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrGvHdrCurrencyName", "Name");
                ((Literal)e.Row.FindControl("ltrGvHdrRate")).Text = clsCommon.GetGlobalResourceText("CurrencySetup", "ltrGvHdrRate", "Rate");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }
        /// <summary>
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvCurrencyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                ClearControl();
                mpeAddEditCurrency.Show();
                this.CurrencyID = new Guid(Convert.ToString(e.CommandArgument));
                Currency objCurrency = new Currency();
                objCurrency = CurrencyBLL.GetByPrimaryKey(this.CurrencyID);
                if (objCurrency != null)
                {
                    txtCurrency.Text = objCurrency.Name;
                    txtCode.Text = objCurrency.CurrencyCode;

                    string strRate = Convert.ToString(objCurrency.Rate);
                    if (objCurrency.Rate != null)
                        txtRate.Text = objCurrency.Rate.ToString().Substring(0, objCurrency.Rate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    //txtRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    // txtRate.Text = Convert.ToString(objCurrency.Rate);
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.CurrencyID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Currency Value
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e a EventArgs</param>
        protected void btnAddTopCurrency_Click(object sender, EventArgs e)
        {
            ClearControl();
            ClearSearchControl();
            mpeAddEditCurrency.Show();

        }
        /// <summary>
        /// Add New Currency Value
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e a EventArgs</param>

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateCurrency();
                    if (!IsDuplicateRecord)
                      ClearControl();
                    mpeAddEditCurrency.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditCurrency.Hide();
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
                    SaveAndUpdateCurrency();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditCurrency.Hide();
                        IsListMessage = true;

                        if (this.CurrencyID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditCurrency.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
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

        #endregion Button Event

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
                if (this.CurrencyID != Guid.Empty)
                {
                    mpeAddEditCurrency.Hide();
                    Currency objDelete = new Currency();
                    objDelete = CurrencyBLL.GetByPrimaryKey(this.CurrencyID);

                    CurrencyBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Currency");
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

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrencyID != Guid.Empty)
                {
                    mpeAddEditCurrency.Hide();
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}