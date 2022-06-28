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
    public partial class CtrlDenominationSetup : System.Web.UI.UserControl
    {
        #region Variable & Property
        public bool IsMessage = false;
        public Guid DenominationID
        {
            get
            {
                return ViewState["DenominationID"] != null ? new Guid(Convert.ToString(ViewState["DenominationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["DenominationID"] = value;
            }
        }
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

        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

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
                BindCurrency();
                BindProjTerm();
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
            Denomination objDenomination = new Denomination();
            if (!txtSName.Text.Trim().Equals(""))
                objDenomination.DenominationName = txtSName.Text.Trim();
            else
                objDenomination.DenominationName = null;
            
            objDenomination.PropertyID = clsSession.PropertyID;
            objDenomination.CompanyID = clsSession.CompanyID;

            DataSet Dst = DenominationBLL.GetDenominationInformation(objDenomination.CompanyID, objDenomination.PropertyID, objDenomination.DenominationName);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "DenominationName ASC";
            gvDenominationList.DataSource = Dv; 
            gvDenominationList.DataBind();

        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeading.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrMainHeading", "DENOMINATION SETUP");
            //ltrSearchArea.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrSearchArea");
            ltrName.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrName", "Name");
            //ltrSCode.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrSCode");
            ltrDenominationList.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrDenominationList", "Denomination List");
            //ltrCode.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrCode");

            ltrDenominationHeading.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrDenominationHeading", "DENOMINATION SETUP");
            ltrDenomination.Text = clsCommon.GetGlobalResourceText("Denomination", "ltrDenomination", "Denomination List");
            litCurrencyType.Text = clsCommon.GetGlobalResourceText("Denomination", "litCurrencyType", "Currency Type");
            litValue.Text = clsCommon.GetGlobalResourceText("Denomination", "litValue", "Value");
            btnAddTopDenomination.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnAddBottomDenomination.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");


            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");

            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDenominationSetup", "Denomination Setup") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.DenominationID = Guid.Empty;
            txtDenomination.Text = txtValue.Text = "";
            ddlCurrencyType.SelectedIndex = ddlType.SelectedIndex = 0;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSName.Text = "";
        }
        private void SaveAndUpdateDenomination()
        {
            Denomination IsDenom = new Denomination();
            IsDenom.DenominationName = txtDenomination.Text.Trim();
            IsDenom.IsActive = true;
            IsDenom.PropertyID = clsSession.PropertyID;
            IsDenom.CompanyID = clsSession.CompanyID;
            List<Denomination> LstDenom = null;
            LstDenom = DenominationBLL.GetAll(IsDenom);

            if (LstDenom.Count > 0)
            {
                if (this.DenominationID != Guid.Empty)
                {
                    if (Convert.ToString((LstDenom[0].CurDenominationID)) != Convert.ToString(this.DenominationID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditDenomination.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditDenomination.Show();
                    return;
                }
            }

            if (this.DenominationID != Guid.Empty)
            {
                Denomination objUpd = new Denomination();
                Denomination objOldDenomData = new Denomination();
                objUpd = DenominationBLL.GetByPrimaryKey(this.DenominationID);
                //objUpd.Updatelog = this.UpdateLog;
                objOldDenomData = DenominationBLL.GetByPrimaryKey(this.DenominationID);

                objUpd.CurrencyID = new Guid(ddlCurrencyType.SelectedValue.ToString());
                objUpd.CurrencyType_TermID = new Guid(ddlType.SelectedValue.ToString());
                objUpd.DenominationName = txtDenomination.Text.Trim();
                objUpd.DenominationValue = Convert.ToDecimal(txtValue.Text.Trim());
              
                DenominationBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldDenomData.ToString(), objUpd.ToString(), "mst_Denomination");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                Denomination objIns = new Denomination();

                objIns.CurrencyID = new Guid(ddlCurrencyType.SelectedValue.ToString());
                objIns.CurrencyType_TermID = new Guid(ddlType.SelectedValue.ToString());
                objIns.DenominationName = txtDenomination.Text.Trim();
                objIns.DenominationValue = Convert.ToDecimal(txtValue.Text.Trim());

                objIns.PropertyID = clsSession.PropertyID;
                objIns.CompanyID = clsSession.CompanyID;
                objIns.IsSynch = false;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;
                objIns.IsActive = true;
               
                DenominationBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Denomination");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            BindGrid();

        }

        private void BindProjTerm()
        {
            ProjectTerm objProjTerm = new ProjectTerm();
            objProjTerm.Category = "CURRENCYTYPE";
            objProjTerm.PropertyID = clsSession.PropertyID;
            objProjTerm.CompanyID = clsSession.CompanyID;
            objProjTerm.IsActive = true;

            List<ProjectTerm> lstCurrency = ProjectTermBLL.GetAll(objProjTerm);
            if (lstCurrency.Count > 0)
            {                
                ddlType.DataSource = lstCurrency;
                ddlType.DataTextField = "DisplayTerm";
                ddlType.DataValueField = "TermID";
                ddlType.DataBind();
            }
        }

        private void BindCurrency()
        {
            Currency objCurrency = new Currency();

            objCurrency.PropertyID = clsSession.PropertyID;
            objCurrency.CompanyID = clsSession.CompanyID;
            objCurrency.IsActive = true;

            List<Currency> lstCurrency = CurrencyBLL.GetAll(objCurrency);
            if (lstCurrency.Count > 0)
            {
                lstCurrency.Sort((Currency r1, Currency r2) => r1.CurrencyCode.CompareTo(r2.CurrencyCode));
                ddlCurrencyType.DataSource = lstCurrency;
                ddlCurrencyType.DataTextField = "CurrencyCode";
                ddlCurrencyType.DataValueField = "CurrencyID";
                ddlCurrencyType.DataBind();
                ddlCurrencyType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlCurrencyType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvDenominationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strValue = DataBinder.Eval(e.Row.DataItem, "DenominationValue").ToString();
                ((Label)e.Row.FindControl("lblValue")).Text = strValue.Substring(0, strValue.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Literal)e.Row.FindControl("ltrDenominationNameInfo")).Text = clsCommon.GetGlobalResourceText("Denomination", "ltrDenominationNameInfo", "Denomination Name");
                ((Literal)e.Row.FindControl("ltrValueInfo")).Text = clsCommon.GetGlobalResourceText("Denomination", "ltrValueInfo", "Value");
                ((Literal)e.Row.FindControl("ltrTypeInfo")).Text = clsCommon.GetGlobalResourceText("Denomination", "ltrTypeInfo", "Type");
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
        protected void gvDenominationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                ClearControl();
                mpeAddEditDenomination.Show();
                this.DenominationID = new Guid(Convert.ToString(e.CommandArgument));
                Denomination objDenomination = new Denomination();
                objDenomination = DenominationBLL.GetByPrimaryKey(this.DenominationID);
                if (objDenomination != null)
                {
                    txtDenomination.Text = Convert.ToString(objDenomination.DenominationName);
                    //txtValue.Text = Convert.ToString(objDenomination.DenominationValue);

                    string strVal = Convert.ToString(objDenomination.DenominationValue);

                    if (objDenomination.DenominationValue != null)
                        txtValue.Text = objDenomination.DenominationValue.ToString().Substring(0, objDenomination.DenominationValue.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ddlCurrencyType.SelectedValue =  Convert.ToString(objDenomination.CurrencyID);
                    ddlType.SelectedValue = Convert.ToString(objDenomination.CurrencyType_TermID);

                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.DenominationID = new Guid(Convert.ToString(e.CommandArgument));
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
        protected void btnAddTopDenomination_Click(object sender, EventArgs e)
        {
            ClearSearchControl();
            ClearControl();
            mpeAddEditDenomination.Show();
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateDenomination();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditDenomination.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditDenomination.Hide();
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
                    SaveAndUpdateDenomination();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditDenomination.Hide();
                        IsListMessage = true;

                        if (this.DenominationID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditDenomination.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DenominationID != Guid.Empty)
                {
                    mpeAddEditDenomination.Hide();
                    Denomination objDelete = new Denomination();
                    objDelete = DenominationBLL.GetByPrimaryKey(this.DenominationID);

                    DenominationBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Denomination");
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

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DenominationID != Guid.Empty)
                {
                    mpeAddEditDenomination.Hide();
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