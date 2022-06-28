using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlCurrencyType : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

        public Guid CurrencyTypeID
        {
            get
            {
                return ViewState["CurrencyTypeID"] != null ? new Guid(Convert.ToString(ViewState["CurrencyTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CurrencyTypeID"] = value;
            }
        }
        string strDelete = string.Empty;
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
        #endregion Property and Variables

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
            //    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                //CheckUserAuthorization();
                BindGrid();
                mvCurrencyType.ActiveViewIndex = 0;
                BindData();

            }
        }

        #endregion Page Load

        #region Methods

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CATEGORY.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddTopCurrencyType.Visible = btnAddBottomCurrencyTypeList.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
               
                SetPageLables();
                BindCurrencySymbolAndType();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindCurrencySymbolAndType()
        {
            try
            {

                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-select-");
                ProjectTerm objProjectTerm = new ProjectTerm();
                objProjectTerm.PropertyID = clsSession.PropertyID;
                objProjectTerm.CompanyID = clsSession.CompanyID;
                objProjectTerm.Category = "CURRENCYTYPE";
                DataSet dsProjectTermCurrencyType = ProjectTermBLL.GetAllWithDataSet(objProjectTerm);
                if (dsProjectTermCurrencyType.Tables.Count > 0 && dsProjectTermCurrencyType.Tables[0].Rows.Count > 0)
                {
                    ddlCurrencyType.DataSource = dsProjectTermCurrencyType.Tables[0];
                    ddlCurrencyType.DataTextField = "DisplayTerm";
                    ddlCurrencyType.DataValueField = "DisplayTerm";
                    ddlCurrencyType.DataBind();
                    ddlCurrencyType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                {
                    ddlCurrencyType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                //trTreeGrid.Visible = false;
                //trNormalGrid.Visible = true;

                //string CategoryName = null;
                //string CategoryCode = null;

                //if (!(txtSearchCategoryName.Text.Trim().Equals("")))
                //    CategoryName = txtSearchCategoryName.Text.Trim();

                //if (!(txtSearceCategoryCode.Text.Trim().Equals("")))
                //    CategoryCode = txtSearceCategoryCode.Text.Trim();

                //DataSet dsSearchCategory = CategoryBLL.SearchCategory(null, clsSession.PropertyID, clsSession.CompanyID, CategoryCode, CategoryName);

                //gvCategoryList.DataSource = dsSearchCategory.Tables[0];
                //gvCategoryList.DataBind();

                DataSet dsCurrencyType = new DataSet();
                CurrencyTypes objCurrencyTypes = new CurrencyTypes();
                objCurrencyTypes.PropertyID = clsSession.PropertyID;
                objCurrencyTypes.CompanyID = clsSession.CompanyID;
                objCurrencyTypes.IsActive = true;
                dsCurrencyType = CurrencyTypeBLL.GetAllWithDataSet(objCurrencyTypes);
                if (dsCurrencyType != null && dsCurrencyType.Tables.Count > 0 && dsCurrencyType.Tables[0].Rows.Count > 0)
                {
                    gvCurrencyType.DataSource = dsCurrencyType.Tables[0];
                    gvCurrencyType.DataBind();
                }
                else
                {
                    gvCurrencyType.DataSource = dsCurrencyType;
                    gvCurrencyType.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }





        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = litCurrencydenominations.Text = clsCommon.GetGlobalResourceText("CurrencyType", "lblMainHeader", "Currency denominations");
            litCurrencyName.Text = clsCommon.GetGlobalResourceText("CurrencyType", "litCurrencyName", "Currency Name");
            litCurrencyType.Text = clsCommon.GetGlobalResourceText("CurrencyType", "litCurrencyType", "Currency Type");
            litCurrencyValue.Text = clsCommon.GetGlobalResourceText("CurrencyType", "litCurrencyValue", "Currency Value");
            litCurrencySymbol.Text = clsCommon.GetGlobalResourceText("CurrencyType", "litCurrencySymbol", "Currency Symbol");
            btnAddTopCurrencyType.Text = btnAddBottomCurrencyTypeList.Text = clsCommon.GetGlobalResourceText("CurrencyType", "btnAddTopCurrencyType", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("CurrencyType", "ltrHeaderConfirmDeletePopup", "Currency denominations");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {

            txtCurrencyName.Text = txtCurrencyValue.Text = "";
            this.CurrencyTypeID = Guid.Empty;
            ddlCurrencyType.SelectedIndex = 0;

        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
           // txtSrchCurrencyValue.Text = txtSrchCurrencyType.Text = "";
        }

        private void SaveData()
        {
            CurrencyTypes IsCurrencyType = new CurrencyTypes();
            IsCurrencyType.CurrencyName = Convert.ToString(txtCurrencyName.Text.Trim());
            IsCurrencyType.IsActive = true;
            IsCurrencyType.PropertyID = clsSession.PropertyID;
            IsCurrencyType.CompanyID = clsSession.CompanyID;
            List<CurrencyTypes> LstDupCurrencyType = CurrencyTypeBLL.GetAll(IsCurrencyType);
            if (LstDupCurrencyType.Count > 0)
            {
                if (this.CurrencyTypeID != Guid.Empty)
                {
                    if (Convert.ToString((LstDupCurrencyType[0].CurrencyTypeID)) != Convert.ToString(this.CurrencyTypeID))
                    {
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mvCurrencyType.ActiveViewIndex = 1;
                        return;
                    }
                }
                else
                {
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mvCurrencyType.ActiveViewIndex = 1;
                    return;
                }
            }
            if (this.CurrencyTypeID != Guid.Empty)
            {
                CurrencyTypes objCurrencyTypeToUpdate = new CurrencyTypes();
                CurrencyTypes objCurrencyoldData = new CurrencyTypes();
                objCurrencyTypeToUpdate = CurrencyTypeBLL.GetByPrimaryKey(this.CurrencyTypeID);
                objCurrencyoldData = CurrencyTypeBLL.GetByPrimaryKey(this.CurrencyTypeID);
                objCurrencyTypeToUpdate.CurrencyName = Convert.ToString(txtCurrencyName.Text.Trim());
                objCurrencyTypeToUpdate.CurrencyValue = Convert.ToDecimal(txtCurrencyValue.Text.Trim());
                objCurrencyTypeToUpdate.PropertyID = clsSession.PropertyID;
                objCurrencyTypeToUpdate.CompanyID = clsSession.CompanyID;
                if (txtCurrencySymbol.Text.Trim() != "")
                    objCurrencyTypeToUpdate.CurrencyCode = Convert.ToString(txtCurrencySymbol.Text.Trim());
                else
                    objCurrencyTypeToUpdate.CurrencyCode = null;

                if (ddlCurrencyType.SelectedIndex != 0)
                {
                    objCurrencyTypeToUpdate.CurrencyType_Term = Convert.ToString(ddlCurrencyType.SelectedValue);
                    objCurrencyTypeToUpdate.CurrencyType = Convert.ToString(ddlCurrencyType.SelectedValue);
                }
                else
                {
                    objCurrencyTypeToUpdate.CurrencyType_Term = null;
                    objCurrencyTypeToUpdate.CurrencyType = null;
                }
                objCurrencyTypeToUpdate.UpdatedBy = clsSession.UserID;
                objCurrencyTypeToUpdate.UpdatedOn = DateTime.Now;
                CurrencyTypeBLL.Update(objCurrencyTypeToUpdate);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objCurrencyoldData.ToString(), objCurrencyTypeToUpdate.ToString(), "con_CurrencyType");
                IsListMessage = true;
                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                CurrencyTypes objCurrencyTypeToInsert = new CurrencyTypes();
                objCurrencyTypeToInsert.CurrencyName = Convert.ToString(txtCurrencyName.Text.Trim());
                objCurrencyTypeToInsert.CurrencyValue = Convert.ToDecimal(txtCurrencyValue.Text.Trim());
                objCurrencyTypeToInsert.PropertyID = clsSession.PropertyID;
                objCurrencyTypeToInsert.CompanyID = clsSession.CompanyID;
                objCurrencyTypeToInsert.IsActive = true;
                if (txtCurrencySymbol.Text.Trim() != "")
                    objCurrencyTypeToInsert.CurrencyCode = Convert.ToString(txtCurrencySymbol.Text.Trim());
                else
                    objCurrencyTypeToInsert.CurrencyCode = null;

                if (ddlCurrencyType.SelectedIndex != 0)
                {
                    objCurrencyTypeToInsert.CurrencyType_Term = Convert.ToString(ddlCurrencyType.SelectedValue);
                    objCurrencyTypeToInsert.CurrencyType = Convert.ToString(ddlCurrencyType.SelectedValue);
                }
                else
                {
                    objCurrencyTypeToInsert.CurrencyType_Term = null;
                    objCurrencyTypeToInsert.CurrencyType = null;
                }
                CurrencyTypeBLL.Save(objCurrencyTypeToInsert);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objCurrencyTypeToInsert.ToString(), objCurrencyTypeToInsert.ToString(), "con_CurrencyType");
                IsListMessage = true;
                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }

        }


        #endregion Method

        #region Button Event

        /// <summary>
        /// Save and Update Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    SaveData();
                    ClearControl();
                    BindGrid();
                    mvCurrencyType.ActiveViewIndex = 1;
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                ClearSearchControl();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            ClearControl();
            ClearSearchControl();
            mvCurrencyType.ActiveViewIndex = 0;
        }

        /// <summary>
        /// Add new Role Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddTopCurrencyType_Click(object sender, EventArgs e)
        {
            try
            {
                //btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mvCurrencyType.ActiveViewIndex = 1;
               
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
        
        #endregion Button Event

        #region Grid Event

        protected void gvCurrencyType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControl();
                    this.CurrencyTypeID = new Guid(Convert.ToString(e.CommandArgument));
                    mvCurrencyType.ActiveViewIndex = 1;
                    CurrencyTypes objCurrencyTypeToEdit = new CurrencyTypes();
                    objCurrencyTypeToEdit = CurrencyTypeBLL.GetByPrimaryKey(this.CurrencyTypeID);
                    if (objCurrencyTypeToEdit != null)
                    {
                        txtCurrencyName.Text = Convert.ToString(objCurrencyTypeToEdit.CurrencyName);
                        txtCurrencyValue.Text = Convert.ToString(objCurrencyTypeToEdit.CurrencyValue);
                        ddlCurrencyType.SelectedIndex = ddlCurrencyType.Items.FindByValue(Convert.ToString(objCurrencyTypeToEdit.CurrencyType_Term)) != null ? ddlCurrencyType.Items.IndexOf(ddlCurrencyType.Items.FindByValue(Convert.ToString(objCurrencyTypeToEdit.CurrencyType_Term))) : 0;
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.CurrencyTypeID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCurrencyType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    //if (this.UserRights.Substring(2, 1) == "1")
                    //    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    //else
                    //    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    //lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CurrencyTypeID")));

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrCurrencyType")).Text = clsCommon.GetGlobalResourceText("CurrencyType", "lblGvHdrCurrencyType", "Type");
                    ((Label)e.Row.FindControl("lblGvHdrCurrencyValue")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCurrencyValue", "Value");
                    ((Label)e.Row.FindControl("lblGvHdrCurrencyName")).Text = clsCommon.GetGlobalResourceText("Category", "lblGvHdrCurrencyName", "Name");

                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");

                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCurrencyType_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCurrencyType.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    CurrencyTypeBLL.Delete(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}