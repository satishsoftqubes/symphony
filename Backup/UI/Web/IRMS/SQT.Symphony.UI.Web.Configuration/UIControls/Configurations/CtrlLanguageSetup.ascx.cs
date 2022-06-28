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
    public partial class CtrlLanguageSetup : System.Web.UI.UserControl
    {
        #region Variable and Property

        public Guid LanguageID
        {
            get
            {
                return ViewState["LanguageID"] != null ? new Guid(Convert.ToString(ViewState["LanguageID"])) : Guid.Empty;
            }
            set
            {
                ViewState["LanguageID"] = value;
            }

        }
        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Variable and Property

        #region Form Load 
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

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblMainHeader", "LANGUAGE SETUP");
            litSearchLanguageName.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblSearchLanguageName", "Name");
            litLanguageSetupList.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblLanguageSetupList", "Name");
            litHeaderPopupLanguageSetup.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblHeaderPopupLanguageSetup", "Language Setup");
            litLanguageName.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblLanguageName", "Name");
            litLanguageCalture.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblLanguageCalture", "Language Calture");
            //litCountry.Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblCountry");

            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnAddTopLanguageSetup.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnAddBottomLanguageSetup.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
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
            dr3["NameColumn"] = "Language Setup&nbsp;";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindGrid();
                //BindCountry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrid()
        {
            Language objLanguage = new Language();

            if (!txtSLanguageName.Text.Trim().Equals(""))
                objLanguage.Name = txtSLanguageName.Text.Trim();          

            objLanguage.IsActive = true;
            objLanguage.PropertyID = clsSession.PropertyID;
            objLanguage.CompanyID = clsSession.CompanyID;

            List<Language> lstLanguage = LanguageBLL.GetAll(objLanguage);
            lstLanguage.Sort((Language d1, Language d2) => d1.Name.CompareTo(d2.Name));

            gvLanguageSetupList.DataSource = lstLanguage;
            gvLanguageSetupList.DataBind();

        }

        //private void BindCountry()
        //{
        //    Country objCountry = new Country();

        //    //objCountry.CompanyID = clsSession.CompanyID;
        //    objCountry.IsActive = true;

        //    List<Country> lstCountry = CountryBLL.GetAll(objCountry);
        //    if (lstCountry.Count > 0)
        //    {
        //        ddlCountry.DataSource = lstCountry;
        //        ddlCountry.DataTextField = "CountryName";
        //        ddlCountry.DataValueField = "CountryID";
        //        ddlCountry.DataBind();
        //        ddlCountry.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlCountry.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

        private void SaveAndUpdateLanguage()
        {
            Language IsLan = new Language();
            IsLan.Name = txtLanguageName.Text.Trim();
            IsLan.IsActive = true;
            IsLan.PropertyID = clsSession.PropertyID;
            IsLan.CompanyID = clsSession.CompanyID;
            List<Language> LstLan = null;
            LstLan = LanguageBLL.GetAll(IsLan);

            if (LstLan.Count > 0)
            {
                if (this.LanguageID != Guid.Empty)
                {
                    if (Convert.ToString(LstLan[0].LanguageID) != Convert.ToString(this.LanguageID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditLanguageSetup.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditLanguageSetup.Show();
                    return;

                }
            }
            if (this.LanguageID != Guid.Empty)
            {
                Language objUpd = new Language();
                Language objOldLan = new Language();
                objUpd = LanguageBLL.GetByPrimaryKey(this.LanguageID);
                objOldLan = LanguageBLL.GetByPrimaryKey(this.LanguageID);


                objUpd.Name = txtLanguageName.Text.Trim();
                objUpd.LanguageCulture = txtLanguageCalture.Text.Trim();
                objUpd.CountryID = null; //new Guid(ddlCountry.SelectedValue.ToString());

                LanguageBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldLan.ToString(), objUpd.ToString(), "mst_Language");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            }
            else
            {
                Language objIns = new Language();
                objIns.Name = txtLanguageName.Text.Trim();
                objIns.LanguageCulture = txtLanguageCalture.Text.Trim();
                objIns.CountryID = null; //new Guid(ddlCountry.SelectedValue.ToString());
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsSynch = false;
                objIns.IsActive = true;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;

                LanguageBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Language");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
        }

        
        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.LanguageID = Guid.Empty;
            txtLanguageCalture.Text =  txtLanguageName.Text = "";
            //ddlCountry.SelectedIndex = 0;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSLanguageName.Text = "";
        }
        #endregion Private Method

        #region Grid Event
        protected void gvLanguageSetupList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrLanguageName")).Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblGvHdrLanguageName", "Name");
                ((Label)e.Row.FindControl("lblGvHdrLanguageCalture")).Text = clsCommon.GetGlobalResourceText("LanguageSetup", "lblGvHdrLanguageCalture", "Language Calture");
                ((Label)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        protected void gvLanguageSetupList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLanguageSetupList.PageIndex = e.NewPageIndex;
        }

        protected void gvLanguageSetupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                ClearControl();
                mpeAddEditLanguageSetup.Show();
                this.LanguageID = new Guid(Convert.ToString(e.CommandArgument));
                Language objLanguage = new Language();
                objLanguage = LanguageBLL.GetByPrimaryKey(this.LanguageID);
                if (objLanguage != null)
                {
                    txtLanguageName.Text = objLanguage.Name;
                    txtLanguageCalture.Text = objLanguage.LanguageCulture;
                    //ddlCountry.SelectedValue = Convert.ToString(objLanguage.CountryID);
                   
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.LanguageID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        #endregion Grid Event
        
        #region Control Event

        protected void btnAddTopLanguageSetup_Click(object sender, EventArgs e)
        {
            ClearSearchControl();
            ClearControl();
            mpeAddEditLanguageSetup.Show();

        }

        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateLanguage();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditLanguageSetup.Hide();
                        IsListMessage = true;

                        if (this.LanguageID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditLanguageSetup.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateLanguage();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditLanguageSetup.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditLanguageSetup.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

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
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.LanguageID != Guid.Empty)
                {
                    mpeAddEditLanguageSetup.Hide();
                    Language objDelete = new Language();
                    objDelete = LanguageBLL.GetByPrimaryKey(this.LanguageID);

                    LanguageBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Language");
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
                if (this.LanguageID != Guid.Empty)
                {
                    mpeAddEditLanguageSetup.Hide();
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event
    }
}