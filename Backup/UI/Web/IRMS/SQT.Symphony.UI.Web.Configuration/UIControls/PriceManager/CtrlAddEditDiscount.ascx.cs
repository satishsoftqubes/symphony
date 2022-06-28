using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlAddEditDiscount : System.Web.UI.UserControl
    {
        #region Property and Variables
        // Property to save StayTypeID;
        public Guid ucDiscountID
        {
            get
            {
                return ViewState["ucDiscountID"] != null ? new Guid(Convert.ToString(ViewState["ucDiscountID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ucDiscountID"] = value;
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
        // Property to save UpdateLog
        public byte[] UpdateLog
        {
            get
            {
                return ViewState["UpdateLog"] != null ? (byte[])ViewState["UpdateLog"] : null;
            }
            set
            {
                ViewState["UpdateLog"] = value;
            }
        }

        public string strPopupAction
        {
            get
            {
                return ViewState["strPopupAction"] != null ? Convert.ToString(ViewState["strPopupAction"]) : string.Empty;
            }
            set
            {
                ViewState["strPopupAction"] = value;
            }
        }

        public string strExceptionMessage
        {
            get
            {
                return ViewState["strExceptionMessage"] != null ? Convert.ToString(ViewState["strExceptionMessage"]) : string.Empty;
            }
            set
            {
                ViewState["strExceptionMessage"] = value;
            }
        }

        public ModalPopupExtender ucMpeAddEditRecord
        {
            get { return this.mpeAddEditRecord; }
        }

        public event EventHandler btnCallParent_Click;
        // To Give Message.
        public bool IsPopupMessage = false;
        public bool IsDuplicateRecord = false;

        public string ucTxtDiscountName
        {
            get { return txtDiscountName.Text.Trim(); }
            set { txtDiscountName.Text = value; }
        }

        public string ucTxtDiscountRate
        {
            get { return txtDiscountRate.Text.Trim(); }
            set { txtDiscountRate.Text = value; }
        }

        public int ucDdlRateType
        {
            get { return ddlRateType.SelectedIndex; }
            set { ddlRateType.SelectedIndex = value; }
        }

        public string ucDdlDiscountType
        {
            get { return ddlDiscountType.SelectedValue.ToString(); }
            set { ddlDiscountType.SelectedIndex = ddlDiscountType.Items.FindByValue(Convert.ToString(value)) != null ? ddlDiscountType.Items.IndexOf(ddlDiscountType.Items.FindByValue(Convert.ToString(value))) : 0; }
        }

        public string ucTxtDetails
        {
            get { return txtDetails.Text.Trim(); }
            set { txtDetails.Text = value; }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        #endregion

        #region Control Events
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
                    SaveAndUpdate();

                    // If Record is not duplicate, then clear control.
                    if (!IsDuplicateRecord)
                        ClearControl();

                    this.strPopupAction = "SAVE";
                    EventHandler temp = btnCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                    btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
                }
                catch (Exception ex)
                {
                    this.strPopupAction = "EXCEPTION";
                    this.strExceptionMessage = Convert.ToString(ex.Message);

                    EventHandler temp = btnCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
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
                    SaveAndUpdate();

                    this.strPopupAction = "SAVE";
                    if (!IsDuplicateRecord)
                    {
                        // Give update, insert message based on Primary key.
                        if (this.ucDiscountID != Guid.Empty)
                            this.strPopupAction = "lblMsgRecordUpdatedSuccessfully"; 
                        else
                            this.strPopupAction = "lblMsgRecordSavedSuccessfully";

                        ClearControl();
                    }

                    EventHandler temp = btnCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    this.strPopupAction = "EXCEPTION";
                    this.strExceptionMessage = Convert.ToString(ex.Message);

                    EventHandler temp = btnCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
            }
        }

        protected void ddlRateType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SetRateMaxValue();
            this.strPopupAction = "DDLINDEXCHANGE";
            EventHandler temp = btnCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }
        #endregion

        #region Methods
        public void CheckUserAuthentication()
        {
            if (this.ucDiscountID != Guid.Empty)
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
            else
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindData()
        {
            regExpRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regExpRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            BindDDL();
            SetPageLables();
            SetRateMaxValue();
        }

        private void BindDDL()
        {
            List<ProjectTerm> lstDiscountType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "DISCOUNTTYPE");

            if (lstDiscountType.Count != 0)
            {
                ddlDiscountType.DataSource = lstDiscountType;
                ddlDiscountType.DataTextField = "DisplayTerm";
                ddlDiscountType.DataValueField = "TermID";
                ddlDiscountType.DataBind();
                ddlDiscountType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlDiscountType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }

            ddlRateType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlRateType.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));
        }

        private void SetPageLables()
        {
            litHeaderPopupDiscount.Text = clsCommon.GetGlobalResourceText("Discount", "lblHeaderPopupDiscount", "Discount");
            litDiscountName.Text = clsCommon.GetGlobalResourceText("Discount", "lblDiscountName", "Discount Name");
            litDiscountRate.Text = clsCommon.GetGlobalResourceText("Discount", "lblDiscountRate", "Discount Rate");
            litDiscountType.Text = clsCommon.GetGlobalResourceText("Discount", "lblDiscountType", "Discount Type");
            litDetails.Text = clsCommon.GetGlobalResourceText("Discount", "lblDetails", "Details");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            rngvRate.Text = clsCommon.GetGlobalResourceText("Discount", "lblMsgRateLimitInPercentage", "Discount Rate in % should be less than or equal to 100.");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        /// <summary>
        /// Insert and Update StayTypes
        /// </summary>
        private void SaveAndUpdate()
        {
            // Object To check duplicate.
            Discounts objToCheckDuplicate = new Discounts();
            objToCheckDuplicate.DiscountName = txtDiscountName.Text.Trim();
            objToCheckDuplicate.IsActive = true;
            objToCheckDuplicate.CompanyID = clsSession.CompanyID;
            objToCheckDuplicate.PropertyID = clsSession.PropertyID;
            List<Discounts> LstRecordList = null;
            LstRecordList = DiscountsBLL.GetAllForCheckDuplicate(objToCheckDuplicate);

            // Record found in DB.
            if (LstRecordList.Count > 0)
            {
                if (this.ucDiscountID != Guid.Empty)
                {
                    // If Record is open in Edit mode and Edited Record and Record found in DB not same, then,
                    if (LstRecordList[0].DiscountID != this.ucDiscountID)
                    {
                        //Duplicate record exist.
                        IsDuplicateRecord = IsPopupMessage = true;
                        litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        return;
                    }
                }
                else
                {
                    //If Record is in new mode, then Duplicate record exist.
                    IsDuplicateRecord = IsPopupMessage = true;
                    litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    return;
                }
            }

            if (this.ucDiscountID != Guid.Empty)
            {
                // Edit mode.
                Discounts objToUpdate = DiscountsBLL.GetByPrimaryKey(this.ucDiscountID);
                //objUpd.Updatelog = this.UpdateLog;
                Discounts objOldRecord = DiscountsBLL.GetByPrimaryKey(this.ucDiscountID);

                objToUpdate.DiscountName = txtDiscountName.Text.Trim();

                if (txtDiscountRate.Text.Trim() != string.Empty)
                    objToUpdate.DiscountRate = Convert.ToDecimal(txtDiscountRate.Text.Trim());
                else
                    objToUpdate.DiscountRate = null;

                if (ddlRateType.SelectedValue != "0")
                    objToUpdate.IsDiscFlat = true;
                else
                    objToUpdate.IsDiscFlat = false;

                if (ddlDiscountType.SelectedIndex != 0)
                    objToUpdate.DiscountType_TermID = new Guid(ddlDiscountType.SelectedValue);
                else
                    objToUpdate.DiscountRate = null;

                objToUpdate.DiscountDetails = txtDetails.Text.Trim();
                objToUpdate.UpdatedBy = clsSession.UserID;
                objToUpdate.UpdatedOn = DateTime.Now;

                DiscountsBLL.Update(objToUpdate);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldRecord.ToString(), objToUpdate.ToString(), "mst_Discounts");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                Discounts objToInsert = new Discounts();

                objToInsert.CompanyID = clsSession.CompanyID;
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.DiscountName = txtDiscountName.Text.Trim();

                if (txtDiscountRate.Text.Trim() != string.Empty)
                    objToInsert.DiscountRate = Convert.ToDecimal(txtDiscountRate.Text.Trim());
                else
                    objToInsert.DiscountRate = null;

                if (ddlRateType.SelectedValue != "0")
                    objToInsert.IsDiscFlat = true;
                else
                    objToInsert.IsDiscFlat = false;

                if (ddlDiscountType.SelectedIndex != 0)
                    objToInsert.DiscountType_TermID = new Guid(ddlDiscountType.SelectedValue);
                else
                    objToInsert.DiscountRate = null;

                objToInsert.DiscountDetails = txtDetails.Text.Trim();
                objToInsert.IsActive = true;
                objToInsert.IsSynch = false;

                DiscountsBLL.Save(objToInsert);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_Discounts");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
        }

        public void SetRateMaxValue()
        {
            if (ddlRateType.SelectedIndex == 0)
                rngvRate.MaximumValue = "100";
            else
                rngvRate.MaximumValue = "999999999999999999";// 18 chars
        }

        private void ClearControl()
        {
            this.ucDiscountID = Guid.Empty;
            txtDiscountName.Text = txtDiscountRate.Text = txtDetails.Text = "";
            ddlRateType.SelectedIndex = ddlDiscountType.SelectedIndex = 0;
            SetRateMaxValue();
        }
        #endregion
    }
}