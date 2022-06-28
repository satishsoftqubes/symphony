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
    public partial class CtrlAmenitiesSetup : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;        

        public Guid AmenitiesID
        {
            get
            {
                return ViewState["AmenitiesID"] != null ? new Guid(Convert.ToString(ViewState["AmenitiesID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AmenitiesID"] = value;
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

        #endregion Property and Variables

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                mvAmenities.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Control Events
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {                
                gvAmenities.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddTopAmenities_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = this.UserRights.Substring(1, 1) == "1";           
                ClearControl();
                mvAmenities.ActiveViewIndex = 1;
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {                    
                    Amenities IsDupAmenities = new Amenities();
                    IsDupAmenities.PropertyID = clsSession.PropertyID;
                    IsDupAmenities.AmenitiesName = txtAmenitiesName.Text.Trim();
                    IsDupAmenities.IsActive = true;

                    List<Amenities> lstIsDupAmenities = AmenitiesBLL.GetAll(IsDupAmenities);
                    if (lstIsDupAmenities.Count > 0)
                    {
                        if (this.AmenitiesID != Guid.Empty)
                        {
                            if (Convert.ToString((lstIsDupAmenities[0].AmenitiesID)) != Convert.ToString(this.AmenitiesID.ToString()))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                mvAmenities.ActiveViewIndex = 1;
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            mvAmenities.ActiveViewIndex = 1;
                            return;
                        }
                    }

                    if (this.AmenitiesID != Guid.Empty)
                    {
                        Amenities objUpdate = new Amenities();
                        Amenities objOldUpdateData = new Amenities();

                        objUpdate = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);
                        objOldUpdateData = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);
                        
                        objUpdate.AmenitiesCode = txtAmenitiesCode.Text.Trim();
                        objUpdate.AmenitiesDescription = txtDescription.Text.Trim();
                        objUpdate.AmenitiesName = txtAmenitiesName.Text.Trim();
                        objUpdate.UpdatedOn = DateTime.Now;
                        objUpdate.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objUpdate.AmenitiesTypeTermID = new Guid(ddlAmenitiesFor.SelectedValue);

                        AmenitiesBLL.Update(objUpdate);
                        ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldUpdateData.ToString(), objUpdate.ToString(), "mst_Amenities");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Amenities objSave = new Amenities();
                        objSave.PropertyID = clsSession.PropertyID;
                        objSave.AmenitiesCode = txtAmenitiesCode.Text.Trim();
                        objSave.AmenitiesDescription = txtDescription.Text.Trim();
                        objSave.AmenitiesName = txtAmenitiesName.Text.Trim();
                        objSave.IsActive = true;
                        objSave.IsSynch = false;
                        objSave.CreatedOn = DateTime.Now;
                        objSave.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objSave.AmenitiesTypeTermID = new Guid(ddlAmenitiesFor.SelectedValue);

                        AmenitiesBLL.Save(objSave);
                        ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Save", objSave.ToString(), objSave.ToString(), "mst_Amenities");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }
                    ClearControl();
                    BindGrid();
                    mvAmenities.ActiveViewIndex = 1;
                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            BindGrid();
            mvAmenities.ActiveViewIndex = 0;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
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
        #endregion

        #region Methods

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AMENITIESSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomAmenities.Visible = btnAddTopAmenities.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLables();
                BindAmenities();                
                BindGrid();
                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.AmenitiesID != Guid.Empty || mvAmenities.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAmenities", "Amenities");
                dr3["Link"] = "~/GUI/Configurations/AmenitiesSetup.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = txtAmenitiesName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewAmenities", "New Amenity") : txtAmenitiesName.Text.Trim();
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAmenities", "Amenities");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Method Information
        /// </summary>
        private void BindGrid()
        {
            try
            {                
                string AmenitiesName = null;
                if (txtSearchAmeniteisName.Text.Trim() != "")
                    AmenitiesName = txtSearchAmeniteisName.Text.Trim();
                else
                    AmenitiesName = null;

                DataSet dsAmenities = AmenitiesBLL.SearchAmenitiesData(null, clsSession.PropertyID, AmenitiesName, null);

                gvAmenities.DataSource = dsAmenities.Tables[0];
                gvAmenities.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblMainHeader", "AMENITIES SETUP");
            ltrSearchAmeniteisName.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblSearchAmenitiesName", "Amenities Name");
            ltrAmenitiesName.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblAmenitiesName", "Amenities Name");
            ltrAmenitiesCode.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblAmenitiesCode", "Amenities Code");
            ltrAmenitiesFor.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblAmenitiesFor", "Amenities For");
            ltrDescription.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblAmenitiesDescription", "Amenities Description");
            btnAddTopAmenities.Text = btnAddBottomAmenities.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");             
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            ltrAmenitiesList.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblAmenitiesList", "Amenities List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblHdrConfirmDeletePopup", "Amenities");
            btnSearchAmenities.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            ddlAmenitiesFor.SelectedIndex = 0;
            txtAmenitiesCode.Text = txtAmenitiesName.Text = txtDescription.Text = "";
            this.AmenitiesID = Guid.Empty;
            //mvAmenities.ActiveViewIndex = 0;
            //BindGrid();
        }

        /// <summary>
        /// Bind Amenities Information
        /// </summary>
        private void BindAmenities()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect","-Select-");
            ProjectTerm Prj = new ProjectTerm();
            Prj.Category = "AmenitiesType";
            Prj.CompanyID = clsSession.CompanyID;
            Prj.PropertyID = clsSession.PropertyID;
            Prj.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(Prj);
            if (Lst.Count > 0)
            {
                ddlAmenitiesFor.DataSource = Lst;
                ddlAmenitiesFor.DataTextField = "DisplayTerm";
                ddlAmenitiesFor.DataValueField = "TermID";
                ddlAmenitiesFor.DataBind();
                ddlAmenitiesFor.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlAmenitiesFor.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSearchAmeniteisName.Text = "";
        }
        #endregion

        #region Grid Event
        protected void gvAmenities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmenitiesID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrAmenitiesName")).Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblGvHdrAmenitiesName", "Amenities Name");
                    ((Label)e.Row.FindControl("lblGvHdrAmenitiesCode")).Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblGvHdrAmenitiesCode", "Amenities Code");
                    ((Label)e.Row.FindControl("lblGvHdrAmenitiesFor")).Text = clsCommon.GetGlobalResourceText("AmenitiesSetup", "lblGvHdrAmenitiesFor", "Amenities For"); 
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

        protected void gvAmenities_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    ClearControl();
                    mvAmenities.ActiveViewIndex = 1;
                    Amenities objAmenities = new Amenities();
                    objAmenities = AmenitiesBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    if (objAmenities != null)
                    {
                        this.AmenitiesID = objAmenities.AmenitiesID;                        
                        txtAmenitiesCode.Text = objAmenities.AmenitiesCode;
                        txtAmenitiesName.Text = objAmenities.AmenitiesName;
                        txtDescription.Text = objAmenities.AmenitiesDescription;
                        ddlAmenitiesFor.SelectedIndex = ddlAmenitiesFor.Items.FindByValue(Convert.ToString(objAmenities.AmenitiesTypeTermID)) != null ? ddlAmenitiesFor.Items.IndexOf(ddlAmenitiesFor.Items.FindByValue(Convert.ToString(objAmenities.AmenitiesTypeTermID))) : 0;
                    }

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.AmenitiesID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAmenities_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAmenities.PageIndex = e.NewPageIndex;
            BindGrid();
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
                    Amenities objDelete = new Amenities();
                    objDelete = AmenitiesBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    AmenitiesBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Amenities");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}