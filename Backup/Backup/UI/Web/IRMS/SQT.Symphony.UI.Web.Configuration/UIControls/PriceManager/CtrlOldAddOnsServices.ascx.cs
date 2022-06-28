using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlOldAddOnsServices : System.Web.UI.UserControl
    {
        #region Property and Variables

        public Guid AddOnID
        {
            get
            {
                return ViewState["AddOnID"] != null ? new Guid(Convert.ToString(ViewState["AddOnID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AddOnID"] = value;
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

        public bool IsListMessage = false;

        public bool IsAddEditMessage = false;

        public DataTable dtExistingDetails = null;

        #endregion Property and Variables

        #region Form Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();

                mvAddOnsServices.ActiveViewIndex = 0;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Control Event

        protected void btnSearchAddOnsServices_OnClick(object sender, EventArgs e)
        {
            gvAddOnsServices.PageIndex = 0;
            BindAddOnsInformation();
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindAddOnsInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddTopAddOnsServices_OnClick(object sender, EventArgs e)
        {
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
            Clearcontrols();
            mvAddOnsServices.ActiveViewIndex = 1;

            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
        }

        protected void btnAddOnsServicesSave_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    AddOns objToCheckDuplicate = new AddOns();
                    objToCheckDuplicate.IsActive = true;
                    objToCheckDuplicate.CompanyID = clsSession.CompanyID;
                    objToCheckDuplicate.PropertyID = clsSession.PropertyID;
                    objToCheckDuplicate.AddOnTitle = txtAddOnsServicesTitle.Text.Trim();

                    List<AddOns> lstAddOns = AddOnsBLL.GetAll(objToCheckDuplicate);
                    if (lstAddOns.Count > 0)
                    {
                        if (this.AddOnID != Guid.Empty)
                        {
                            //Edit Mode
                            if (lstAddOns[0].AddOnID != this.AddOnID)
                            {
                                IsAddEditMessage = true;
                                litAddEditMessage.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblMsgAddOnWithSameTitleExist", "Add On with same title already exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsAddEditMessage = true;
                            litAddEditMessage.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblMsgAddOnWithSameTitleExist", "Add On with same title already exist.");
                            return;
                        }
                    }

                    if (this.AddOnID != Guid.Empty)
                    {
                        //Edit mode.
                        //Object declaration
                        AddOns objToUpdate = AddOnsBLL.GetByPrimaryKey(this.AddOnID);
                        AddOns objOldToUpdate = AddOnsBLL.GetByPrimaryKey(this.AddOnID);

                        objToUpdate.AddOnTitle = txtAddOnsServicesTitle.Text.Trim();

                        if (ddlAddOnsServicesPostingFreq.SelectedIndex != 0)
                            objToUpdate.PostingFreq_TermID = new Guid(ddlAddOnsServicesPostingFreq.SelectedValue.ToString());
                        else
                            objToUpdate.PostingFreq_TermID = null;

                        if (ddlAddOnsServicesChargePer.SelectedIndex != 0)
                            objToUpdate.Chargeper_TermID = new Guid(ddlAddOnsServicesChargePer.SelectedValue.ToString());
                        else
                            objToUpdate.Chargeper_TermID = null;

                        if (ddlAvailableOnPOS.SelectedIndex != 0)
                            objToUpdate.AvailablePOSPointID = new Guid(ddlAvailableOnPOS.SelectedValue.ToString());
                        else
                            objToUpdate.AvailablePOSPointID = null;

                        if (txtAddOnsServicesBasePrice.Text.Trim() != string.Empty)
                            objToUpdate.BasePrice = Convert.ToDecimal(txtAddOnsServicesBasePrice.Text.Trim());
                        else
                            objToUpdate.BasePrice = null;

                        objToUpdate.IsAvailableOnIRS = chkIsAvailableOnIRS.Checked;
                        objToUpdate.AddOnDetail = txtDetail.Text.Trim();
                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.UpdatedOn = DateTime.Now;

                        List<AddOnItems> lstAddOnItems = new List<AddOnItems>();
                        for (int i = 0; i < gvAddOnsServices.Rows.Count; i++)
                        {
                            if (((CheckBox)gvAddOnsServices.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                TextBox txtQuentity = (TextBox)gvAddOnsServices.Rows[i].FindControl("txtQuentity");

                                AddOnItems objToAdd = new AddOnItems();
                                objToAdd.IsActive = true;
                                objToAdd.ItemID = new Guid(Convert.ToString(gvAddOnsServices.DataKeys[i]["ItemID"]));

                                if (txtQuentity != null && txtQuentity.Text.Trim() != string.Empty)
                                    objToAdd.Qty = Convert.ToDecimal(txtQuentity.Text.Trim());
                                else
                                    objToAdd.Qty = null;

                                lstAddOnItems.Add(objToAdd);
                            }
                        }

                        //Object to get RateCardDetails from DB.
                        AddOnItems objToGetAddOnItemsList = new AddOnItems();
                        objToGetAddOnItemsList.AddOnID = this.AddOnID;
                        objToGetAddOnItemsList.IsActive = true;
                        List<AddOnItems> lstAddOnItemsFromDB = AddOnItemsBLL.GetAll(objToGetAddOnItemsList);

                        AddOnsBLL.Update(objToUpdate, lstAddOnItems, lstAddOnItemsFromDB, clsSession.UserID);

                        //Save action log.
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldToUpdate.ToString(), objToUpdate.ToString(), "mst_AddOns");
                        IsAddEditMessage = true;
                        litAddEditMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        Clearcontrols();
                    }
                    else
                    {
                        //Insert Mode.
                        //Object declaration
                        AddOns objToInsert = new AddOns();

                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.IsActive = true;
                        objToInsert.AddOnTitle = txtAddOnsServicesTitle.Text.Trim();

                        if (ddlAddOnsServicesPostingFreq.SelectedIndex != 0)
                            objToInsert.PostingFreq_TermID = new Guid(ddlAddOnsServicesPostingFreq.SelectedValue.ToString());

                        if (ddlAddOnsServicesChargePer.SelectedIndex != 0)
                            objToInsert.Chargeper_TermID = new Guid(ddlAddOnsServicesChargePer.SelectedValue.ToString());

                        if (ddlAvailableOnPOS.SelectedIndex != 0)
                            objToInsert.AvailablePOSPointID = new Guid(ddlAvailableOnPOS.SelectedValue.ToString());

                        if (txtAddOnsServicesBasePrice.Text.Trim() != string.Empty)
                            objToInsert.BasePrice = Convert.ToDecimal(txtAddOnsServicesBasePrice.Text.Trim());
                        else
                            objToInsert.BasePrice = null;

                        objToInsert.IsAvailableOnIRS = chkIsAvailableOnIRS.Checked;
                        objToInsert.AddOnDetail = txtDetail.Text.Trim();

                        List<AddOnItems> lstAddOnItems = new List<AddOnItems>();
                        for (int i = 0; i < gvAddOnsServices.Rows.Count; i++)
                        {
                            if (((CheckBox)gvAddOnsServices.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                TextBox txtQuentity = (TextBox)gvAddOnsServices.Rows[i].FindControl("txtQuentity");

                                AddOnItems objToAdd = new AddOnItems();
                                objToAdd.IsActive = true;
                                objToAdd.ItemID = new Guid(Convert.ToString(gvAddOnsServices.DataKeys[i]["ItemID"]));

                                if (txtQuentity != null && txtQuentity.Text.Trim() != string.Empty)
                                    objToAdd.Qty = Convert.ToDecimal(txtQuentity.Text.Trim());
                                else
                                    objToAdd.Qty = null;

                                lstAddOnItems.Add(objToAdd);
                            }
                        }

                        AddOnsBLL.Save(objToInsert, lstAddOnItems);

                        //Save action log.
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_AddOns");
                        IsAddEditMessage = true;
                        litAddEditMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        Clearcontrols();
                    }

                    BindAddOnsInformation();

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
        }

        protected void btnAddOnsServicesCancel_OnClick(object sender, EventArgs e)
        {
            this.AddOnID = Guid.Empty;

            txtAddOnsServicesTitle.Text = string.Empty;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            this.AddOnID = Guid.Empty;
            mvAddOnsServices.ActiveViewIndex = 0;

            txtAddOnsServicesTitle.Text = string.Empty;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
        }

        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;

            if (chkSelect != null)
            {
                int rowIndex = Convert.ToInt32(hfRowIndex.Value);
                TextBox txtQuentity = (TextBox)gvAddOnsServices.Rows[rowIndex].FindControl("txtQuentity");
                RequiredFieldValidator rfvQuentity = (RequiredFieldValidator)gvAddOnsServices.Rows[rowIndex].FindControl("rfvQuentity");

                if (chkSelect.Checked)
                {
                    rfvQuentity.Enabled = txtQuentity.Enabled = true;
                    ((RegularExpressionValidator)gvAddOnsServices.Rows[rowIndex].FindControl("regQuentity")).Enabled = true;
                }
                else
                {
                    rfvQuentity.Enabled = txtQuentity.Enabled = false;
                    txtQuentity.Text = "";
                    ((RegularExpressionValidator)gvAddOnsServices.Rows[rowIndex].FindControl("regQuentity")).Enabled = false;
                }
            }
        }

        #endregion Control Event

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ADDONSSERVICES.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomAddOnsServices.Visible = btnAddTopAddOnsServices.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblMainHeader", "Add On Services");
            litSearchTitle.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblSearchTitle", "Title");
            litSearchPostingFrequency.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblSearchPostingFrequency", "Posting Freq.");
            btnAddTopAddOnsServices.Text = btnAddBottomAddOnsServices.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litAddOnsServicesList.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblAddOnsServicesList", "Add On Services");
            litTitle.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblTitle", "Title");
            litPostingFreq.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblPostingFrequency", "Posting Freq.");
            litBasePrice.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblBasePrice", "Base Price");
            litChargePer.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblChargePer", "Charge Per");
            litAvailableOnPOS.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblAvailableOnPOS", "Available on POS");
            litHeaderServices.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblHeaderServices", "Services");
            litDetail.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblDetail", "Detail");

            chkIsAvailableOnIRS.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblIsAvailableOnIRS", "Is Available On IRS");

            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblHeaderConfirmDeletePopup", "Add Ons");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearchAddOnsServices.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.AddOnID != Guid.Empty || mvAddOnsServices.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAddOnsServices", "Add On Services");
                dr3["Link"] = "~/GUI/PriceManager/AddOnsServices.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = txtAddOnsServicesTitle.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewAddonsService", "New Add On Service") : txtAddOnsServicesTitle.Text.Trim();
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAddOnsServices", "Add On Services");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearSearchControl()
        {
            txtSearchTitle.Text = string.Empty;
            ddlSearchPostingFrequency.SelectedIndex = 0;
        }

        private void BindData()
        {
            try
            {
                regBasePrice.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                regBasePrice.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
                SetPageLabels();
                BindDDL();
                BindAddOnsInformation();
                BindServicesGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void BindDDL()
        {
            List<ProjectTerm> lstPostingFeq = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "POSTINGFREQUENCY");
            if (lstPostingFeq.Count != 0)
            {
                ddlAddOnsServicesPostingFreq.DataSource = lstPostingFeq;
                ddlAddOnsServicesPostingFreq.DataTextField = "DisplayTerm";
                ddlAddOnsServicesPostingFreq.DataValueField = "TermID";
                ddlAddOnsServicesPostingFreq.DataBind();
                ddlAddOnsServicesPostingFreq.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                ddlSearchPostingFrequency.DataSource = lstPostingFeq;
                ddlSearchPostingFrequency.DataTextField = "DisplayTerm";
                ddlSearchPostingFrequency.DataValueField = "TermID";
                ddlSearchPostingFrequency.DataBind();
                ddlSearchPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlAddOnsServicesPostingFreq.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                ddlSearchPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }

            List<ProjectTerm> lstChargePer = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "CHARGEPERUNIT");
            if (lstChargePer.Count != 0)
            {
                ddlAddOnsServicesChargePer.DataSource = lstChargePer;
                ddlAddOnsServicesChargePer.DataTextField = "DisplayTerm";
                ddlAddOnsServicesChargePer.DataValueField = "TermID";
                ddlAddOnsServicesChargePer.DataBind();
                ddlAddOnsServicesChargePer.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlAddOnsServicesChargePer.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

            POSPoints objToGetList = new POSPoints();
            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.PropertyID = clsSession.PropertyID;
            objToGetList.IsActive = true;

            List<POSPoints> lstPOSPoints = POSPointsBLL.GetAll(objToGetList);
            if (lstPOSPoints.Count != 0)
            {
                ddlAvailableOnPOS.DataSource = lstPOSPoints;
                ddlAvailableOnPOS.DataTextField = "PointDisplayName";
                ddlAvailableOnPOS.DataValueField = "POSPointID";
                ddlAvailableOnPOS.DataBind();
                ddlAvailableOnPOS.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlAvailableOnPOS.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
        }

        private void BindAddOnsInformation()
        {
            AddOns objToGetList = new AddOns();
            objToGetList.PropertyID = clsSession.PropertyID;
            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.IsActive = true;

            if (txtSearchTitle.Text.Trim() != string.Empty)
                objToGetList.AddOnTitle = txtSearchTitle.Text.Trim();

            if (ddlSearchPostingFrequency.SelectedIndex != 0)
                objToGetList.PostingFreq_TermID = new Guid(ddlSearchPostingFrequency.SelectedValue);

            DataSet dsAddOns = AddOnsBLL.GetAllWithDataSetForSearch(objToGetList);

            gvAddOnsInformation.DataSource = dsAddOns;
            gvAddOnsInformation.DataBind();
        }

        private void BindServicesGrid()
        {
            DataSet dsServices = ItemBLL.GetAllAllForAddOns(clsSession.CompanyID, clsSession.PropertyID, this.AddOnID);

            if (dsServices != null && dsServices.Tables[0].Rows.Count > 0)
            {
                if (dsServices.Tables.Count > 0 && dsServices.Tables[1].Rows.Count > 0)
                {
                    dtExistingDetails = dsServices.Tables[1];
                }

                gvAddOnsServices.DataSource = dsServices.Tables[0];
                gvAddOnsServices.DataBind();
            }
            else
            {
                gvAddOnsServices.DataSource = null;
                gvAddOnsServices.DataBind();
            }
        }

        private void Clearcontrols()
        {
            this.AddOnID = Guid.Empty;
            txtSearchTitle.Text = txtAddOnsServicesBasePrice.Text = txtAddOnsServicesTitle.Text = txtDetail.Text = string.Empty;
            ddlAddOnsServicesChargePer.SelectedIndex = ddlAddOnsServicesPostingFreq.SelectedIndex = ddlAvailableOnPOS.SelectedIndex = 0;
            chkIsAvailableOnIRS.Checked = false;
            BindServicesGrid();
            //BindAddOnsInformation();
        }

        #endregion Private Method

        #region Grid Event

        protected void gvAddOnsInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AddOnID")));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Label)e.Row.FindControl("lblGvHdrTitle")).Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblGvHdrTitle", "Title");
                ((Label)e.Row.FindControl("lblGvHdrPostingFreq")).Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblGvHdrPostingFrequency", "Posting Frequency");
                ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        protected void gvAddOnsInformation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                Clearcontrols();
                this.AddOnID = new Guid(e.CommandArgument.ToString());
                AddOns objToLoadData = AddOnsBLL.GetByPrimaryKey(this.AddOnID);

                if (objToLoadData != null)
                {
                    txtAddOnsServicesTitle.Text = Convert.ToString(objToLoadData.AddOnTitle);
                    txtDetail.Text = Convert.ToString(objToLoadData.AddOnDetail);

                    if (Convert.ToString(objToLoadData.BasePrice) != string.Empty)
                        txtAddOnsServicesBasePrice.Text = objToLoadData.BasePrice.ToString().Substring(0, objToLoadData.BasePrice.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);

                    ddlAddOnsServicesPostingFreq.SelectedIndex = ddlAddOnsServicesPostingFreq.Items.FindByValue(Convert.ToString(objToLoadData.PostingFreq_TermID)) != null ? ddlAddOnsServicesPostingFreq.Items.IndexOf(ddlAddOnsServicesPostingFreq.Items.FindByValue(Convert.ToString(objToLoadData.PostingFreq_TermID))) : 0;
                    ddlAddOnsServicesChargePer.SelectedIndex = ddlAddOnsServicesChargePer.Items.FindByValue(Convert.ToString(objToLoadData.Chargeper_TermID)) != null ? ddlAddOnsServicesChargePer.Items.IndexOf(ddlAddOnsServicesChargePer.Items.FindByValue(Convert.ToString(objToLoadData.Chargeper_TermID))) : 0;
                    ddlAvailableOnPOS.SelectedIndex = ddlAvailableOnPOS.Items.FindByValue(Convert.ToString(objToLoadData.AvailablePOSPointID)) != null ? ddlAvailableOnPOS.Items.IndexOf(ddlAvailableOnPOS.Items.FindByValue(Convert.ToString(objToLoadData.AvailablePOSPointID))) : 0;

                    chkIsAvailableOnIRS.Checked = Convert.ToBoolean(objToLoadData.IsAvailableOnIRS);

                    BindServicesGrid();
                    mvAddOnsServices.ActiveViewIndex = 1;
                }

                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                Clearcontrols();
                this.AddOnID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        protected void gvAddOnsInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddOnsServices.PageIndex = e.NewPageIndex;
        }

        protected void gvAddOnsServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Attributes.Add("onclick", "fnSetRowIndex('" + Convert.ToString(e.Row.DataItemIndex) + "');");

                RegularExpressionValidator regQuentity = (RegularExpressionValidator)e.Row.FindControl("regQuentity");

                regQuentity.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";

                if (dtExistingDetails != null)
                {
                    DataRow[] rows = dtExistingDetails.Select("ItemID = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemID")) + "'");
                    if (rows.Length > 0)
                    {
                        ((RequiredFieldValidator)e.Row.FindControl("rfvQuentity")).Enabled = true;
                        ((CheckBox)e.Row.FindControl("chkSelect")).Checked = true;

                        TextBox txtQuentity = (TextBox)e.Row.FindControl("txtQuentity");
                        txtQuentity.Enabled = true;

                        string strQuentity = Convert.ToString(rows[0]["Qty"]);
                        if (strQuentity != string.Empty)
                            txtQuentity.Text = strQuentity.Substring(0, strQuentity.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("common", "lblGvHdrSelect", "Select");
                ((Label)e.Row.FindControl("lblGvHdrService")).Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblGvHdrService", "Service");
                ((Label)e.Row.FindControl("lblGvHdrQty")).Text = clsCommon.GetGlobalResourceText("AddOnsServices", "lblGvHdrQuentity", "Quantity");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        #endregion Grid Event

        #region Popup Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    AddOns objToDelete = AddOnsBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    objToDelete.IsActive = false;

                    AddOnsBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_AddOns");
                    IsListMessage = true;
                    litListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    Clearcontrols();
                }
                BindAddOnsInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Event
    }
}