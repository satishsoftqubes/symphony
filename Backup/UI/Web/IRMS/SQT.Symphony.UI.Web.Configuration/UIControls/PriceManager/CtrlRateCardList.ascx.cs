using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;
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
        public string strClearDateTooltip
        {
            get
            {
                return ViewState["strClearDateTooltip"] != null ? Convert.ToString(ViewState["strClearDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strClearDateTooltip"] = value;
            }
        }
        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                hfDateFormat.Value = clsSession.DateFormat;
                CheckUserAuthorization();
                calSrchDateFrom.Format = calSrchDateTo.Format = clsSession.DateFormat;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RATECARDLIST.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnRoom.Visible = btnConference.Visible = btnPackage.Visible = btnGDS.Visible = btnCorporate.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        //Method to Bind default data.
        private void BindData()
        {
            try
            {
                BindDDL();
                BindGrid();
                SetPageLables();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblMainHeader", "Ratecard Setup");
            litSrchRateType.Text = "Rate Card Category"; //// clsCommon.GetGlobalResourceText("RateCardList", "lblSearchRateType", "Rate Type");
            litSrchRateName.Text = "Rate Card Name"; ////clsCommon.GetGlobalResourceText("RateCardList", "lblSearchRateName", "Rate Name");
            litSrchRateCode.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblSearchRateCode", "Rate Code");
            litSrchStayType.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblSearchStayType", "Stay Type");
            litSrchDateFrom.Text = "Effective Date";//// clsCommon.GetGlobalResourceText("RateCardList", "lblSearchDateFrom", "Date From");
            litSrchDateTo.Text = "Valid Upto";//// clsCommon.GetGlobalResourceText("RateCardList", "lblSearchDateTo", "Date To");
            btnCorporate.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblBtnCorporate", "Corporate");
            btnGDS.Text = "Web(GDS)"; //clsCommon.GetGlobalResourceText("RateCardList", "lblBtnGDS", "GDS");
            btnPackage.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblBtnPackage", "Package");
            btnConference.Text = "Banquet"; //clsCommon.GetGlobalResourceText("RateCardList", "lblBtnConference", "Conference");
            btnRoom.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblBtnRoom", "Room");
            litGridTitleRatecardList.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblRatecardList", "Ratecard List");

            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("RateCardList", "lblHeaderConfirmDeletePopup", "Rate card");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            this.strClearDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpClearDate", "Clear Date");
            imgSrchDateFrom.ToolTip = imgSrchDateTo.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpChooseDate", "Choose Date");
            ltrHeaderDateValidate.Text = clsCommon.GetGlobalResourceText("Common", "lblHeaderCustomeMessage", "Message");
            ltrMsgDateValidate.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDateFromLessThanOrEqualDateTo", "Date from should be less than or equal to Date to.");
            btnDateMessageOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblRatecardList", "Ratecard Setup");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            //DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            //if (DV.Count > 0)
            //{
            //    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
            //    ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
            //    btnAdd.Enabled = btnAddTop.Enabled = Convert.ToBoolean(DV[0]["IsCreate"]);
            //    ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            //}
            //else
            //    Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            Guid? stayTypeID = null;
            Guid? rateType_TermID = null;
            string code = null, rateCardName = null;
            DateTime? startDate = null, endDate = null;

            if (ddlSrchRateType.SelectedIndex != 0)
                rateType_TermID = new Guid(ddlSrchRateType.SelectedValue);

            if (ddlSrchStayType.SelectedIndex != 0)
                stayTypeID = new Guid(ddlSrchStayType.SelectedValue);

            if (txtSrchRateName.Text.Trim() != string.Empty)
                rateCardName = txtSrchRateName.Text.Trim();

            if (txtSrchRateCode.Text.Trim() != string.Empty)
                code = txtSrchRateCode.Text.Trim();

            if (txtSrchDateFrom.Text.Trim() != string.Empty)
                startDate = DateTime.ParseExact(txtSrchDateFrom.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            if (txtSrchDateTo.Text.Trim() != string.Empty)
                endDate = DateTime.ParseExact(txtSrchDateTo.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            DataSet dsRateCards = RateCardBLL.GetAllByProperty(clsSession.PropertyID, clsSession.CompanyID, stayTypeID, rateType_TermID, code, rateCardName, startDate, endDate);

            gvRateCards.DataSource = dsRateCards;
            gvRateCards.DataBind();

        }

        private void BindDDL()
        {
            //Bind ddlSrchRateType
            List<ProjectTerm> lstRateCardType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RATETYPE");
            if (lstRateCardType.Count != 0)
            {
                ddlSrchRateType.DataSource = lstRateCardType;
                ddlSrchRateType.DataTextField = "DisplayTerm";
                ddlSrchRateType.DataValueField = "TermID";
                ddlSrchRateType.DataBind();
                ddlSrchRateType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
            else
                ddlSrchRateType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));


            //Bind ddlSrchStayType
            StayType objStayTypeToGetList = new StayType();
            objStayTypeToGetList.CompanyID = clsSession.CompanyID;
            objStayTypeToGetList.PropertyID = clsSession.PropertyID;
            objStayTypeToGetList.IsActive = true;
            List<StayType> lstStayType = StayTypeBLL.GetAll(objStayTypeToGetList);
            if (lstStayType.Count != 0)
            {
                ddlSrchStayType.DataSource = lstStayType;
                ddlSrchStayType.DataTextField = "StayTypeName";
                ddlSrchStayType.DataValueField = "StayTypeID";
                ddlSrchStayType.DataBind();
                ddlSrchStayType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
            else
                ddlSrchStayType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
        }

        private void ClearSearchControl()
        {
            txtSrchRateCode.Text = txtSrchRateName.Text = txtSrchDateFrom.Text = txtSrchDateTo.Text = string.Empty;
            ddlSrchRateType.SelectedIndex = ddlSrchStayType.SelectedIndex = 0;
        }
        #endregion Private Method

        #region Control Event

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvRateCards.PageIndex = 0;
                BindGrid();
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
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnRoom_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/RoomRateCard.aspx");
        }

        protected void btnConference_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/ConferenceRateCard.aspx");
        }

        protected void btnPackage_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/PackageRateCard.aspx");
        }

        protected void btnGDS_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/GDSRateCard.aspx");
        }

        protected void btnCorporate_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/CorporateRateCard.aspx");
        }

        protected void ChkIsEnable_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkIsEnable = (CheckBox)sender;

            GridViewRow gr = (GridViewRow)ChkIsEnable.Parent.Parent;
            Guid RateID = new Guid(gvRateCards.DataKeys[gr.RowIndex].Value.ToString());

            //Guid RateID = new Guid(ChkIsEnable.ToolTip);
            RateCard objUpdate = RateCardBLL.GetByPrimaryKey(RateID);

            if (ChkIsEnable.Checked == true)
            {
                objUpdate.IsEnable = true;
            }
            else
            {
                objUpdate.IsEnable = false;
            }

            RateCardBLL.Update(objUpdate);

            BindGrid();


            //SubscriptionService subService = new SubscriptionService();
            //Subscription sub = subService.get(id);
            //sub.IsActive = cb.Checked;
            //subService.update(sub);
            //bindSubscriptionsGrid((int)sub.FkAccountId);
        }

        #endregion Control Event

        #region Grid Event
        protected void gvRateCards_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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

                    Label lblDateFrom = (Label)e.Row.FindControl("lblDateFrom");
                    Label lblDateTo = (Label)e.Row.FindControl("lblDateTo");

                    if (DataBinder.Eval(e.Row.DataItem, "StartDate") != null || DataBinder.Eval(e.Row.DataItem, "EndDate") != null)
                    {
                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StartDate")) != string.Empty)
                            lblDateFrom.Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StartDate"))).ToString(clsSession.DateFormat);
                        else
                            lblDateFrom.Text = "-";

                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EndDate")) != string.Empty)
                            lblDateTo.Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EndDate"))).ToString(clsSession.DateFormat);
                        else
                            lblDateTo.Text = "";
                    }

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrRateCardName")).Text = clsCommon.GetGlobalResourceText("RateCardList", "lblGvHdrRateCardName", "Name");
                    ((Label)e.Row.FindControl("lblGvHdrRateCardCode")).Text = "RC No."; //clsCommon.GetGlobalResourceText("RateCardList", "lblGvHdrRateCardCode", "Code");
                    ((Label)e.Row.FindControl("lblGvHdrRateType")).Text = clsCommon.GetGlobalResourceText("RateCardList", "lblGvHdrRateCardType", "Rate Type");
                    ((Label)e.Row.FindControl("lblGvHdrDateFrom")).Text = "Effective Date"; //clsCommon.GetGlobalResourceText("RateCardList", "lblGvHdrDateFromTo", "Date From-To");
                    ((Label)e.Row.FindControl("lblGvHdrDateTo")).Text = "Valid Upto"; //clsCommon.GetGlobalResourceText("RateCardList", "lblGvHdrDateFromTo", "Date From-To");
                    ((Label)e.Row.FindControl("lblGvHdrDays")).Text = "Days"; //clsCommon.GetGlobalResourceText("RateCardList", "lblGvHdrPostingFrequency", "Posting Freq.");
                    ((Label)e.Row.FindControl("litGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
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

        protected void gvRateCards_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    string strRateType = Convert.ToString(gvRateCards.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["RateTypeNameToCompare"]).ToUpper();
                    switch (strRateType)
                    {
                        case "ROOM":
                            clsSession.ToEditItemID = new Guid(Convert.ToString(gvRateCards.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["RateID"]));
                            clsSession.ToEditItemType = "ROOMRATECARD";
                            Response.Redirect("~/GUI/PriceManager/RoomRateCard.aspx");
                            break;
                        case "CONFERENCE":
                            clsSession.ToEditItemID = new Guid(Convert.ToString(gvRateCards.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["RateID"]));
                            clsSession.ToEditItemType = "CONFERENCERATECARD";
                            Response.Redirect("~/GUI/PriceManager/ConferenceRateCard.aspx");
                            break;
                        case "CORPORATE":
                            clsSession.ToEditItemID = new Guid(Convert.ToString(gvRateCards.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["RateID"]));
                            clsSession.ToEditItemType = "CORPORATERATECARD";
                            Response.Redirect("~/GUI/PriceManager/CorporateRateCard.aspx");
                            break;
                        case "GDS":
                            clsSession.ToEditItemID = new Guid(Convert.ToString(gvRateCards.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["RateID"]));
                            clsSession.ToEditItemType = "GDSRATECARD";
                            Response.Redirect("~/GUI/PriceManager/GDSRateCard.aspx");
                            break;
                        case "PACKAGE":
                            clsSession.ToEditItemID = new Guid(Convert.ToString(gvRateCards.DataKeys[Convert.ToInt32(e.CommandArgument.ToString())]["RateID"]));
                            clsSession.ToEditItemType = "PACKAGERATECARD";
                            Response.Redirect("~/GUI/PriceManager/PackageRateCard.aspx");
                            break;
                    }
                }
                //else if (e.CommandName.Equals("DELETEDATA"))
                //{
                //    this.RateCardID = new Guid(Convert.ToString(e.CommandArgument));
                //    mpeConfirmDelete.Show();
                //}
                else if (e.CommandName.Equals("POSCHARGE"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "RATECARDPOS";
                    Response.Redirect("~/GUI/PriceManager/RateCardPOSCharge.aspx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRateCards_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRateCards.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    RateCard objToDelete = RateCardBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    objToDelete.IsActive = false;

                    RateCardBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_RateCard");
                    IsMessage = true;
                    lblMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //msgbx.Hide();
                //ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event
    }
}