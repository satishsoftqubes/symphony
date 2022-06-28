using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlAdddEditStayType : System.Web.UI.UserControl
    {
        #region Property and Variables
        // Property to save StayTypeID;
        public Guid ucStayTypeID
        {
            get
            {
                return ViewState["ucStayTypeID"] != null ? new Guid(Convert.ToString(ViewState["ucStayTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ucStayTypeID"] = value;
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

        public string ucTxtName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string ucTxtCode
        {
            get { return txtCode.Text.Trim(); }
            set { txtCode.Text = value; }
        }

        public string ucTxtDetails
        {
            get { return txtDetails.Text.Trim(); }
            set { txtDetails.Text = value; }
        }

        public string ucTxtMaxDays
        {
            get { return txtMaxDays.Text.Trim(); }
            set { txtMaxDays.Text = value; }
        }

        public string ucTxtMinDays
        {
            get { return txtMinDays.Text.Trim(); }
            set { txtMinDays.Text = value; }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
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
            //if (Page.IsValid)
            //{
            try
            {
                SaveAndUpdateStayType();

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
            //}
        }

        /// <summary>
        /// Save And Update Department with Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            try
            {
                SaveAndUpdateStayType();

                this.strPopupAction = "SAVE";
                if (!IsDuplicateRecord)
                {
                    // Give update, insert message based on Primary key.
                    if (this.ucStayTypeID != Guid.Empty)
                        this.strPopupAction = "LBLMSGRECORDUPDATEDSUCCESSFULLY";
                    else
                        this.strPopupAction = "LBLMSGRECORDSAVEDSUCCESSFULLY";

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
            //}
        }
        #endregion

        #region Methods
        public void CheckUserAuthentication()
        {
            if (this.ucStayTypeID != Guid.Empty)
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
            else
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            litHeaderPopupStayType.Text = clsCommon.GetGlobalResourceText("StayType", "lblHeaderPopupStayType", "Stay Type");
            litCode.Text = clsCommon.GetGlobalResourceText("StayType", "lblCode", "Code");
            litName.Text = clsCommon.GetGlobalResourceText("StayType", "lblName", "Name");
            litMinMaxDays.Text = clsCommon.GetGlobalResourceText("StayType", "lblMinMaxDays", "Min / Max Days");
            litDetails.Text = clsCommon.GetGlobalResourceText("StayType", "lblDetails", "Detail");
            //cmpvMinMaxDays.Text = clsCommon.GetGlobalResourceText("StayType", "lblMsgMinShouldLessThanMaxDays", "Min Days should be less than or equal to Max Days.");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }
        /// <summary>
        /// Insert and Update StayTypes
        /// </summary>
        private void SaveAndUpdateStayType()
        {
            // Object To check duplicate.
            StayType objToCheckDuplicate = new StayType();
            objToCheckDuplicate.StayTypeName = txtName.Text.Trim();
            objToCheckDuplicate.IsActive = true;
            objToCheckDuplicate.CompanyID = clsSession.CompanyID;
            objToCheckDuplicate.PropertyID = clsSession.PropertyID;
            List<StayType> LstRecordList = null;
            LstRecordList = StayTypeBLL.GetAllForCheckDuplicate(objToCheckDuplicate);

            // Record found in DB.
            if (LstRecordList.Count > 0)
            {
                if (this.ucStayTypeID != Guid.Empty)
                {
                    // If Record is open in Edit mode and Edited Record and Record found in DB not same, then,
                    if (LstRecordList[0].StayTypeID != this.ucStayTypeID)
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

            if (this.ucStayTypeID != Guid.Empty)
            {
                // Edit mode.
                StayType objToUpdate = StayTypeBLL.GetByPrimaryKey(this.ucStayTypeID);
                //objUpd.Updatelog = this.UpdateLog;
                StayType objOldRecord = StayTypeBLL.GetByPrimaryKey(this.ucStayTypeID);

                objToUpdate.StayTypeName = txtName.Text.Trim();
                objToUpdate.Code = txtCode.Text.Trim();

                if (txtMinDays.Text.Trim() != string.Empty)
                    objToUpdate.MinDays = Convert.ToInt32(txtMinDays.Text.Trim());
                else
                    objToUpdate.MinDays = null;

                if (txtMaxDays.Text.Trim() != string.Empty)
                    objToUpdate.MaxDays = Convert.ToInt32(txtMaxDays.Text.Trim());
                else
                    objToUpdate.MaxDays = null;

                objToUpdate.Details = txtDetails.Text.Trim();
                objToUpdate.UpdatedBy = clsSession.UserID;
                objToUpdate.UpdatedOn = DateTime.Now;

                StayTypeBLL.Update(objToUpdate);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldRecord.ToString(), objToUpdate.ToString(), "mst_StayType");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                StayType objToInsert = new StayType();

                objToInsert.CompanyID = clsSession.CompanyID;
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.StayTypeName = txtName.Text.Trim();
                objToInsert.Code = txtCode.Text.Trim();

                if (txtMinDays.Text.Trim() != string.Empty)
                    objToInsert.MinDays = Convert.ToInt32(txtMinDays.Text.Trim());

                if (txtMaxDays.Text.Trim() != string.Empty)
                    objToInsert.MaxDays = Convert.ToInt32(txtMaxDays.Text.Trim());

                objToInsert.Details = txtDetails.Text.Trim();
                objToInsert.IsActive = true;
                objToInsert.IsDefault = false;
                objToInsert.IsSynch = false;

                StayTypeBLL.Save(objToInsert);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_StayType");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            ////BindGrid();

        }
        /// <summary>
        /// Clear Control Method
        /// </summary>
        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.ucStayTypeID = Guid.Empty;
            txtName.Text = txtCode.Text = txtDetails.Text = txtMinDays.Text = txtMaxDays.Text = "";
        }
        #endregion
    }
}