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
    public partial class CtrlExchangeRate : System.Web.UI.UserControl
    { 
        #region Property and Variables
        // property to save companyid;
        public Guid ExchangeRateID
        {
            get
            {
                return ViewState["ExchangeRateID"] != null ? new Guid(Convert.ToString(ViewState["ExchangeRateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ExchangeRateID"] = value;
            }
        }

      

        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Property and Variables

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
        /// Load Default Value
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindDestinationCurrency();
                BindSourceCurrency();

                BindGrid();
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
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Exchange Rate&nbsp;";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Label
        /// </summary>
        private void SetPageLables()
        {
            litMainHeading.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "lblMainHeading", "EXCHANGE RATE");
            litSSourceCurrency.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "lblSSourceCurrencyName", "Source Currency");
            btnAddTopExchangeRate.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "btnAddTopExchangeRate", "Add New");
            btnAddBottomExchangeRate.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "btnAddBottomExchangeRate", "Add New");
            litmdeExchangeRate.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "lblmdeExchangeRate", "Exchange Rate");
            litSourceCurrencyName.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litSourceCurrencyName", "Source Currency");
            litSourceCurrencyValue.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litSourceCurrencyValue", "Value");
            litTo.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litTo", "To");
            litToValue.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litToValue", "To");
            litMarginRate.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "lblMarginRate", "Margin Rate");
            litExchangeRateList.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "lblExchangeRateList", "Exchange Rate List");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            litSDesignationCurrency.Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrDestinationCurrency", "Destination currrency");


            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");


            //Set Regular Expression Value
            regSoruceValue.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regSoruceValue.ErrorMessage = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrSourceValue", "Source Value") + " " + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            regDesginationValue.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regDesginationValue.ErrorMessage = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrDestinationValue", "Destination Value") + " " + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            regMarginRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regMarginRate.ErrorMessage = clsCommon.GetGlobalResourceText("ExchangeRate", "lblMarginRate", "Margin Rate") + " " + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rgValidator.ErrorMessage = clsCommon.GetGlobalResourceText("ExchangeRate", "lblMarginRateRangeMessage", "Margin Rate should be 0 to 100");

            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            Guid? SourceCurrencyID = null;
            Guid? DesignationCurrencyID = null;
            if (ddlSSourceCurrency.SelectedValue != Guid.Empty.ToString())
                SourceCurrencyID  = new Guid(ddlSSourceCurrency.SelectedValue.ToString());
            if (ddlSDesignationCurrency.SelectedValue != Guid.Empty.ToString())
                DesignationCurrencyID = new Guid(ddlSDesignationCurrency.SelectedValue.ToString());
            DataSet Dst = ExchangeRateBLL.SearchData(clsSession.PropertyID, clsSession.CompanyID, SourceCurrencyID, DesignationCurrencyID);  
            DataView dv = new DataView(Dst.Tables[0]);
            gvExcahngeRateList.DataSource = dv;
            gvExcahngeRateList.DataBind();
        }
        
        private void BindDestinationCurrency()
        {
            Currency objCurrency = new Currency();

            objCurrency.PropertyID = clsSession.PropertyID;
            objCurrency.CompanyID = clsSession.CompanyID;
            objCurrency.IsActive = true;

            List<Currency> lstCurrency = CurrencyBLL.GetAll(objCurrency);
            if (lstCurrency.Count > 0)
            {
                lstCurrency.Sort((Currency d1, Currency d2) => d1.CurrencyCode.CompareTo(d2.CurrencyCode));
                ddlDestinationCurrency.DataSource = lstCurrency;
                ddlDestinationCurrency.DataTextField = "CurrencyCode";
                ddlDestinationCurrency.DataValueField = "CurrencyID";
                ddlDestinationCurrency.DataBind();
                ddlDestinationCurrency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


                ddlSDesignationCurrency.DataSource = lstCurrency;
                ddlSDesignationCurrency.DataTextField = "CurrencyCode";
                ddlSDesignationCurrency.DataValueField = "CurrencyID";
                ddlSDesignationCurrency.DataBind();
                ddlSDesignationCurrency.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
            else
            {
                ddlDestinationCurrency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSDesignationCurrency.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }

        private void BindSourceCurrency()
        {
            Currency objCurrency = new Currency();

            objCurrency.PropertyID = clsSession.PropertyID;
            objCurrency.CompanyID = clsSession.CompanyID;
            objCurrency.IsActive = true;

            List<Currency> lstCurrency = CurrencyBLL.GetAll(objCurrency);
            if (lstCurrency.Count > 0)
            {
                lstCurrency.Sort((Currency d1, Currency d2) => d1.CurrencyCode.CompareTo(d2.CurrencyCode));
                ddlSourceCurrency.DataSource = lstCurrency;
                ddlSourceCurrency.DataTextField = "CurrencyCode";
                ddlSourceCurrency.DataValueField = "CurrencyID";
                ddlSourceCurrency.DataBind();
                ddlSourceCurrency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


                ddlSSourceCurrency.DataSource = lstCurrency;
                ddlSSourceCurrency.DataTextField = "CurrencyCode";
                ddlSSourceCurrency.DataValueField = "CurrencyID";
                ddlSSourceCurrency.DataBind();
                ddlSSourceCurrency.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));

            }
            else
            {
                ddlSourceCurrency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSSourceCurrency.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.ExchangeRateID = Guid.Empty;
            txtDesginationCurrecyValue.Text = txtMarginRate.Text = txtSourceCurrencyValue.Text = "";
            ddlDestinationCurrency.SelectedIndex = ddlSourceCurrency.SelectedIndex = 0;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            ddlSSourceCurrency.SelectedIndex = ddlSDesignationCurrency.SelectedIndex = 0;
        }
        private void SaveAndUpdateExchangeRate()
        {
            ExchangeRate IsExchange = new ExchangeRate();
            IsExchange.SourceCurrencyID =new Guid(ddlSourceCurrency.SelectedValue.ToString());
            IsExchange.DestinationCurrencyID = new Guid(ddlDestinationCurrency.SelectedValue.ToString());
            IsExchange.IsActive = true;
            IsExchange.PropertyID = clsSession.PropertyID;
            IsExchange.CompanyID = clsSession.CompanyID;
            List<ExchangeRate> LstExchange = null;
            LstExchange = ExchangeRateBLL.GetAll(IsExchange);

            if (LstExchange.Count > 0)
            {
                if (this.ExchangeRateID != Guid.Empty)
                {
                    if(LstExchange[0].ExchangeRateID!=this.ExchangeRateID)
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mdeExchangeRate.Show();
                        return;
                    }
                }
                else
                {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mdeExchangeRate.Show();
                        return;
                }
            }
            if (this.ExchangeRateID != Guid.Empty)
            {
                ExchangeRate objUpd = new ExchangeRate();
                ExchangeRate objOldExchData = new ExchangeRate();
                objUpd = ExchangeRateBLL.GetByPrimaryKey(this.ExchangeRateID);
                objOldExchData = ExchangeRateBLL.GetByPrimaryKey(this.ExchangeRateID);

                objUpd.SourceCurrencyID = new Guid(ddlSourceCurrency.SelectedValue);
                objUpd.SourceRate = Convert.ToDecimal(txtSourceCurrencyValue.Text.Trim());
                objUpd.DestinationCurrencyID = new Guid(ddlDestinationCurrency.SelectedValue);
                objUpd.DestinationRate = Convert.ToDecimal(txtDesginationCurrecyValue.Text.Trim());
                objUpd.MarginRateInPercentage = Convert.ToDecimal(txtMarginRate.Text.Trim());

                ExchangeRateBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldExchData.ToString(), objUpd.ToString(), "mst_ExchangeRate");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                ExchangeRate objIns = new ExchangeRate();

                objIns.PropertyID = clsSession.PropertyID;
                objIns.CompanyID = clsSession.CompanyID;
                objIns.IsSynch = false;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;
                objIns.IsActive = true;
                
                objIns.SourceCurrencyID = new Guid(ddlSourceCurrency.SelectedValue);
                objIns.SourceRate = Convert.ToDecimal(txtSourceCurrencyValue.Text.Trim());
                objIns.DestinationCurrencyID = new Guid(ddlDestinationCurrency.SelectedValue);
                objIns.DestinationRate = Convert.ToDecimal(txtDesginationCurrecyValue.Text.Trim());
                objIns.MarginRateInPercentage = Convert.ToDecimal(txtMarginRate.Text.Trim());

                ExchangeRateBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_ExchangeRate");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            BindGrid();
           
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Page Index Change Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewPageEventArgs</param>
        protected void gvExcahngeRateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        /// <summary>
        /// Grdi Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvExcahngeRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strRate = DataBinder.Eval(e.Row.DataItem, "MarginRateInPercentage").ToString();
                ((Label)e.Row.FindControl("lblRate")).Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                
                string SourceValue = DataBinder.Eval(e.Row.DataItem, "SourceRate").ToString();
                string DesignationValue = DataBinder.Eval(e.Row.DataItem, "DestinationRate").ToString();
                
                if (DataBinder.Eval(e.Row.DataItem, "SourceRate") != null)
                    ((Label)e.Row.FindControl("lblgvSourceValue")).Text = SourceValue.Substring(0, SourceValue.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                if (DataBinder.Eval(e.Row.DataItem, "DestinationRate") != null)
                    ((Label)e.Row.FindControl("lblgvDestinationValue")).Text = DesignationValue.Substring(0, DesignationValue.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");                
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Literal)e.Row.FindControl("litGvrNo")).Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvrNo", "No.");
                ((Literal)e.Row.FindControl("litGvHdrSourceCurrency")).Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrSourceCurrency", "Source Currency");
                ((Literal)e.Row.FindControl("litGvHdrDestinationCurrency")).Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrDestinationCurrency", "Destination currrency");
                ((Literal)e.Row.FindControl("ltrGvHdrRate")).Text = clsCommon.GetGlobalResourceText("ExchangeRate", "lblMarginRate", "Margin Rate");
                ((Literal)e.Row.FindControl("litGvHdrDestinationValue")).Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrDestinationValue", "Destination Value");
                ((Literal)e.Row.FindControl("litGvHdrSourceValue")).Text = clsCommon.GetGlobalResourceText("ExchangeRate", "litGvHdrSourceValue", "Source Value");
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
        protected void gvExcahngeRateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                ClearControl();
                this.ExchangeRateID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
            else if (e.CommandName.Equals("EDITDATA"))
            {
                ClearControl();
                mdeExchangeRate.Show();
                this.ExchangeRateID = new Guid(Convert.ToString(e.CommandArgument));
                ExchangeRate objExchangeRate = new ExchangeRate();
                objExchangeRate = ExchangeRateBLL.GetByPrimaryKey(this.ExchangeRateID);
                if (objExchangeRate != null)
                {  
                    ddlSourceCurrency.SelectedValue = Convert.ToString(objExchangeRate.SourceCurrencyID);

                    string strSourceRate = Convert.ToString(objExchangeRate.SourceRate);
                    txtSourceCurrencyValue.Text = strSourceRate.Substring(0, strSourceRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ddlDestinationCurrency.SelectedValue = Convert.ToString(objExchangeRate.DestinationCurrencyID);

                    string strDestinationRate = Convert.ToString(objExchangeRate.DestinationRate);
                    txtDesginationCurrecyValue.Text = strDestinationRate.Substring(0, strDestinationRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    string strMarginRate = Convert.ToString(objExchangeRate.MarginRateInPercentage);
                    txtMarginRate.Text = strMarginRate.Substring(0, strMarginRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
        }

        #endregion Grid Event

        #region Add New Exchange Rate Information
        /// <summary>
        /// Add New Exchange Rate 
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopExchangeRate_Click(object sender, EventArgs e)
        {
            ClearSearchControl();
            ClearControl();
            mdeExchangeRate.Show();
        }

        #endregion Add New Exchange Rate Information

        #region Button Event
        /// <summary>
        /// Save Exchange Rate
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateExchangeRate();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mdeExchangeRate.Show();
                }
                catch (Exception ex)
                {
                    mdeExchangeRate.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Save And Close Exchange Rate
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateExchangeRate();
                    if (!IsDuplicateRecord)
                    {
                        mdeExchangeRate.Hide();
                        IsListMessage = true;

                        if (this.ExchangeRateID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        ClearControl();
                    }
                }
                catch(Exception ex)
                {
                    mdeExchangeRate.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Close Exchange Rate
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Delete Popup Yes On Click
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ExchangeRateID != Guid.Empty)
                {
                    mdeExchangeRate.Hide();
                    ExchangeRate objDelete = new ExchangeRate();
                    objDelete = ExchangeRateBLL.GetByPrimaryKey(this.ExchangeRateID);

                    ExchangeRateBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_ExchangeRate");
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
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ExchangeRateID != Guid.Empty)
                {
                    mdeExchangeRate.Hide();
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
        /// Search Exchange Rate Information
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
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