using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlTranscript : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;

        public Guid TranscriptID
        {
            get
            {
                return ViewState["TranscriptID"] != null ? new Guid(Convert.ToString(ViewState["TranscriptID"])) : Guid.Empty;
            }
            set
            {
                ViewState["TranscriptID"] = value;
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
        #endregion Variable and Property

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();
                mvTranscript.ActiveViewIndex = 0;
                SetPageLableText();
                BindGridTranscript();
                BindBreadCrumb();
                ClearControl();
            }
        }
        #endregion

        #region Control Event
        protected void btnTopAdd_Click(object sender, EventArgs e)
        {
            ClearControl();
            mvTranscript.ActiveViewIndex = 1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.TranscriptID != Guid.Empty)
                    {
                        Transcript objUpd = new Transcript();

                        objUpd = TranscriptBLL.GetByPrimaryKey(this.TranscriptID);

                        objUpd.CompanyID = clsSession.CompanyID;
                        objUpd.PropertyID = clsSession.PropertyID;
                        objUpd.Title = txtTitle.Text.Trim();
                        objUpd.ModulName = Convert.ToString(ddlModuleName.SelectedValue.ToString());
                        objUpd.TranscriptType = Convert.ToString(ddlTranscriptType.SelectedValue.ToString());

                        objUpd.Description = ckDetail.Text;

                        objUpd.IsActive = true;

                        objUpd.UpdatedBy = clsSession.UserID;
                        objUpd.UpdatedOn = DateTime.Now.Date;
                        //EMailTemplatesBLL.Update(objUpd);
                        // ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_EMailTemplates");
                        TranscriptBLL.Update(objUpd);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", null, objUpd.ToString(), "mst_Transcript");
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Transcript objIns = new Transcript();
                        objIns.CompanyID = clsSession.CompanyID;
                        objIns.PropertyID = clsSession.PropertyID;
                        objIns.Title = txtTitle.Text.Trim();
                        objIns.TranscriptType = Convert.ToString(ddlTranscriptType.SelectedValue.ToString());
                        objIns.ModulName = Convert.ToString(ddlModuleName.SelectedValue.ToString());
                        objIns.Description = ckDetail.Text;
                        objIns.IsActive = true;
                        objIns.CreatedBy = clsSession.UserID;
                        objIns.CreatedOn = DateTime.Now.Date;
                        TranscriptBLL.Save(objIns);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Transcript");
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    }
                    BindGridTranscript();
                    ClearControl();
                    mvTranscript.ActiveViewIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


            ClearControl();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            mvTranscript.ActiveViewIndex = 0;
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvTranscriptList.PageIndex = 0;
                BindGridTranscript();
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
                ClearControl();
                BindGridTranscript();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITTYPESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void ClearControl()
        {
            txtTitle.Text = "";
            ckDetail.Text = txtTitle.Text = "";
            ddlTranscriptType.SelectedIndex = 0;
            this.TranscriptID = Guid.Empty;
            txtSearchTitle.Text = "";
            ddlSearchType.SelectedIndex = 0;
            txtSearchModuleName.Text = "";
            ddlModuleName.SelectedIndex = 0;

        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Guest";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Transcript & SOP's";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGridTranscript()
        {
            try
            {
                string Title = null;
                string ModuleName = null;
                string Type = null;
                if (txtSearchTitle.Text.Trim() != string.Empty)
                    Title = Convert.ToString(txtSearchTitle.Text.Trim());
                else
                    Title = null;


                if (txtSearchModuleName.Text.Trim() != string.Empty)
                    ModuleName = Convert.ToString(txtSearchModuleName.Text.Trim());
                else
                    ModuleName = null;

                if (ddlSearchType.SelectedValue != Guid.Empty.ToString())
                    Type = Convert.ToString(ddlSearchType.Text);
                else
                    Type = null;

                List<Transcript> lstTranscript = null;
                lstTranscript = TranscriptBLL.TranscriptSearchData(clsSession.PropertyID, Title, ModuleName, Type);

                gvTranscriptList.DataSource = lstTranscript;
                gvTranscriptList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetPageLableText()
        {
            litMainHeaderTranscript.Text = clsCommon.GetGlobalResourceText("Transcript", "litMainHeaderTranscript", "SOP");
            litSearchTitle.Text = clsCommon.GetGlobalResourceText("Transcript", "litSearchTitle", "Title");

            litSearchType.Text = clsCommon.GetGlobalResourceText("Transcript", "litSearchType", "Type");
            litSearchModulName.Text = clsCommon.GetGlobalResourceText("Transcript", "litSearchModulName", "Module Name");
            litTitle.Text = clsCommon.GetGlobalResourceText("Transcript", "litTitle", "Title");
            litTranscriptType.Text = clsCommon.GetGlobalResourceText("Transcript", "litTranscriptType", "Type");
            litModuleName.Text = clsCommon.GetGlobalResourceText("Transcript", "litModuleName", "Modul Name");
            litContent.Text = clsCommon.GetGlobalResourceText("Transcript", "litContent", "Content");
            btnButtomAdd.Text = btnTopAdd.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Transcript", "litMainHeaderTranscript", "Transcript & SOP's");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litTranscript.Text = clsCommon.GetGlobalResourceText("Transcript", "litGvMainHeader", "Transcript List");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");



        }
        #endregion

        #region Grid Event

        protected void gvTranscript_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    //lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    //if (this.UserRights.Substring(2, 1) == "1")
                    //    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    //else
                    //    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TranscriptID")));

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrTitle")).Text = clsCommon.GetGlobalResourceText("Transcript", "lblGvHdrTitle", "Title");
                    ((Label)e.Row.FindControl("lblGvHdrType")).Text = clsCommon.GetGlobalResourceText("Transcript", "lblGvHdrType", "Type");
                    ((Label)e.Row.FindControl("lblGvHdrModuleName")).Text = clsCommon.GetGlobalResourceText("Transcript", "lblGvHdrModuleName", "Module Name");
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

        protected void gvTranscript_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    mvTranscript.ActiveViewIndex = 1;

                    this.TranscriptID = new Guid(Convert.ToString(e.CommandArgument));
                    Transcript objTran = new Transcript();
                    objTran = TranscriptBLL.GetByPrimaryKey(this.TranscriptID);
                    if (objTran != null)
                    {
                        txtTitle.Text = objTran.Title;
                        //txtModuleName.Text = objTran.ModulName;




                        if (objTran.ModulName != null)
                            ddlModuleName.SelectedIndex = ddlModuleName.Items.FindByValue(Convert.ToString(objTran.ModulName)) != null ? ddlModuleName.Items.IndexOf(ddlModuleName.Items.FindByValue(Convert.ToString(objTran.ModulName))) : 0;



                        if (objTran.TranscriptType != null)
                            ddlTranscriptType.SelectedIndex = ddlTranscriptType.Items.FindByValue(Convert.ToString(objTran.TranscriptType)) != null ? ddlTranscriptType.Items.IndexOf(ddlTranscriptType.Items.FindByValue(Convert.ToString(objTran.TranscriptType))) : 0;
                        ckDetail.Text = objTran.Description;
                    }

                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.TranscriptID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        protected void gvTranscript_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTranscriptList.PageIndex = e.NewPageIndex;
            BindGridTranscript();
        }

        #endregion Grid Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    SQT.Symphony.BusinessLogic.Configuration.DTO.Transcript objDelete = new SQT.Symphony.BusinessLogic.Configuration.DTO.Transcript();
                    objDelete = TranscriptBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    TranscriptBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Transcript");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGridTranscript();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}