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
    public partial class CtrlAddEditVIPType : System.Web.UI.UserControl
    {
        #region Property and Variables
        // Property to save StayTypeID;
        public Guid ucVIPTypeID
        {
            get
            {
                return ViewState["ucVIPTypeID"] != null ? new Guid(Convert.ToString(ViewState["ucVIPTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ucVIPTypeID"] = value;
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

        public string ucTxtVIPTypeName
        {
            get { return txtVIPTypeName.Text.Trim(); }
            set { txtVIPTypeName.Text = value; }
        }

        public string ucTxtCode
        {
            get { return txtCode.Text.Trim(); }
            set { txtCode.Text = value; }
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
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateVIPType();

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
                    SaveAndUpdateVIPType();

                    this.strPopupAction = "SAVE";
                    if (!IsDuplicateRecord)
                    {
                        // Give update, insert message based on Primary key.
                        if (this.ucVIPTypeID != Guid.Empty)
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
            }
        }
        #endregion

        #region Methods
        public void CheckUserAuthentication()
        {
            if (this.ucVIPTypeID != Guid.Empty)
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
            else
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void SetPageLables()
        {
            litHeaderPopupVIPType.Text = clsCommon.GetGlobalResourceText("VIPType", "lblHeaderPopupVIPType", "VIP Type");
            litCode.Text = clsCommon.GetGlobalResourceText("VIPType", "lblCode", "Code");
            litVIPTypeName.Text = clsCommon.GetGlobalResourceText("VIPType", "lblVIPTypeName", "VIP Type");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }

        /// <summary>
        /// Insert and Update StayTypes
        /// </summary>
        private void SaveAndUpdateVIPType()
        {
            // Object To check duplicate.
            VIPTypes objToCheckDuplicate = new VIPTypes();
            objToCheckDuplicate.VIPTypeName = txtVIPTypeName.Text.Trim();
            objToCheckDuplicate.IsActive = true;
            objToCheckDuplicate.CompanyID = clsSession.CompanyID;
            objToCheckDuplicate.PropertyID = clsSession.PropertyID;
            List<VIPTypes> LstRecordList = null;
            LstRecordList = VIPTypesBLL.GetAllForCheckDuplicate(objToCheckDuplicate);

            // Record found in DB.
            if (LstRecordList.Count > 0)
            {
                if (this.ucVIPTypeID != Guid.Empty)
                {
                    // If Record is open in Edit mode and Edited Record and Record found in DB not same, then,
                    if (LstRecordList[0].VIPTypeID != this.ucVIPTypeID)
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

            if (this.ucVIPTypeID != Guid.Empty)
            {
                // Edit mode.
                VIPTypes objToUpdate = VIPTypesBLL.GetByPrimaryKey(this.ucVIPTypeID);
                //objUpd.Updatelog = this.UpdateLog;
                VIPTypes objOldRecord = VIPTypesBLL.GetByPrimaryKey(this.ucVIPTypeID);

                objToUpdate.VIPTypeName = txtVIPTypeName.Text.Trim();
                objToUpdate.TypeCode = txtCode.Text.Trim();

                objToUpdate.UpdatedBy = clsSession.UserID;
                objToUpdate.UpdatedOn = DateTime.Now;

                VIPTypesBLL.Update(objToUpdate);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldRecord.ToString(), objToUpdate.ToString(), "mst_VIPTypes");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                VIPTypes objToInsert = new VIPTypes();

                objToInsert.CompanyID = clsSession.CompanyID;
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.VIPTypeName = txtVIPTypeName.Text.Trim();
                objToInsert.TypeCode = txtCode.Text.Trim();

                objToInsert.IsActive = true;
                objToInsert.IsSynch = false;

                VIPTypesBLL.Save(objToInsert);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_VIPTypes");
                IsPopupMessage = true;
                litMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            //BindGrid();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.ucVIPTypeID = Guid.Empty;
            txtCode.Text = txtVIPTypeName.Text = "";
        }
        #endregion
    }
}