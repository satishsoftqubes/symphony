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
    public partial class CtrlGuestPreferenceSetup : System.Web.UI.UserControl
    {
        #region Variable
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

        public bool IsListMessage = false;

        public Guid PreferenceID
        {
            get
            {
                return ViewState["PreferenceID"] != null ? new Guid(Convert.ToString(ViewState["PreferenceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PreferenceID"] = value;
            }
        }
        #endregion Variable

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                LoadData();
                BindBreadCrumb();
                mvPreference.ActiveViewIndex = 0;
            }
        }

        #region Private Method

        private void LoadData()
        {
            SetPageLabels();
            BindGridPreference();
        }

        private void BindGridPreference()
        {

            string strPref = null;

            if (txtSearchPreference.Text.Trim() != "")
                strPref = txtSearchPreference.Text.Trim();

            //DataSet dsPref = PreferenceMasterBLL.GetAllForList(clsSession.PropertyID, clsSession.CompanyID);
            List<PreferenceMaster> lstPref = PreferenceMasterBLL.SelectAllByPreference(clsSession.CompanyID, clsSession.PropertyID, strPref);
            gvPreference.DataSource = lstPref;
            gvPreference.DataBind();
        }

        private void ClearControl()
        {
            txtPreference.Text = txtPreferenceDetail.Text = txtSearchPreference.Text = "";
            this.PreferenceID = Guid.Empty;
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
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Guest Preference";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("GuestPreferenceSetup", "litMainHeader", "Guest Preference");
            btnTopAdd.Text = btnBottumAdd.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litPreferenceList.Text = clsCommon.GetGlobalResourceText("GuestPreferenceSetup", "litPreferenceList", "Guest Preference List");

            litPreference.Text = litSearchPreference.Text = ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("GuestPreferenceSetup", "litPreference", "Preference");
            litPreferenceDetail.Text = clsCommon.GetGlobalResourceText("GuestPreferenceSetup", "litPreferenceDetail", "Preference Detail");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "EMPLOYEESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

             btnBottumAdd.Visible = btnTopAdd.Visible = this.UserRights.Substring(1, 1) == "1";
        }


        #endregion

        #region Control Event


        protected void btnTopAdd_OnClick(object sender, EventArgs e)
        {
            mvPreference.ActiveViewIndex = 1;
            ClearControl();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            mvPreference.ActiveViewIndex = 0;
            ClearControl();
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                List<PreferenceMaster> lstPref = PreferenceMasterBLL.SelectAllByPreference(clsSession.CompanyID, clsSession.PropertyID, txtPreference.Text.Trim());

                if (lstPref != null && lstPref.Count > 0)
                {
                    if (this.PreferenceID != Guid.Empty)
                    {
                        if (lstPref[0].PreferenceID != this.PreferenceID)
                        {
                            //Duplicate record exist.
                            IsListMessage = true;
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }
                    else
                    {
                        //If Record is in new mode, then Duplicate record exist.
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        return;
                    }
                }

                if (this.PreferenceID != Guid.Empty)
                {
                    PreferenceMaster objOldProPref = new PreferenceMaster();
                    PreferenceMaster objUpdProPref = new PreferenceMaster();

                    objOldProPref = PreferenceMasterBLL.GetByPrimaryKey(this.PreferenceID);
                    objUpdProPref = PreferenceMasterBLL.GetByPrimaryKey(this.PreferenceID);


                    objUpdProPref.PreferenceName = txtPreference.Text.Trim();
                    objUpdProPref.PreferenceDetails = txtPreferenceDetail.Text.Trim();
                    objUpdProPref.UpdatedBy = clsSession.UserID;
                    objUpdProPref.UpdatedOn = DateTime.Now.Date;

                    PreferenceMasterBLL.Update(objUpdProPref);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldProPref.ToString(), objUpdProPref.ToString(), "mst_preferencemaster");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                }
                else
                {
                    PreferenceMaster objSave = new PreferenceMaster();

                    objSave.CompanyID = clsSession.CompanyID;
                    objSave.PropertyID = clsSession.PropertyID;
                    objSave.PreferenceDetails = txtPreferenceDetail.Text.Trim();
                    objSave.PreferenceName = txtPreference.Text.Trim();
                    objSave.IsActive = true;

                    PreferenceMasterBLL.Save(objSave);
                    ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Save", objSave.ToString(), objSave.ToString(), "mst_preferencemaster");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ClearControl();
            BindGridPreference();
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvPreference.PageIndex = 0;
                BindGridPreference();
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
                BindGridPreference();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    PreferenceMaster objDelete = new PreferenceMaster();
                    objDelete = PreferenceMasterBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    PreferenceMasterBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_preferencemaster");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGridPreference();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region  Grid Event
        protected void gvPreference_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PreferenceID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrPreference")).Text = clsCommon.GetGlobalResourceText("GuestPreferenceSetup", "lblGvHdrPreference", "Preference");
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

        protected void gvPreference_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    this.PreferenceID = new Guid(Convert.ToString(e.CommandArgument));
                    PreferenceMaster objPref = new PreferenceMaster();
                    objPref = PreferenceMasterBLL.GetByPrimaryKey(this.PreferenceID);

                    txtPreference.Text = objPref.PreferenceName.ToString();
                    txtPreferenceDetail.Text = objPref.PreferenceDetails.ToString();
                    mvPreference.ActiveViewIndex = 1;
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.PreferenceID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPreference_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvPreference.PageIndex = e.NewPageIndex;
                BindGridPreference();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}