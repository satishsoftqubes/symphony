using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlConferenceRateCard : System.Web.UI.UserControl
    {
        #region Property and Variables
        public Guid RateCardID
        {
            get
            {
                return ViewState["RateCardID"] != null ? new Guid(Convert.ToString(ViewState["RateCardID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateCardID"] = value;
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
        // To Give Message.
        public bool IsListMessage = false;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                hfDateFormat.Value = clsSession.DateFormat;
                ucRateCardBasicInfo.ParentType = "CONFERENCERATECARD";
                BindData();
                SetPageLables();

                if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CONFERENCERATECARD")
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.RateCardID = clsSession.ToEditItemID;
                    LoadRateCardData();
                }

                //Bind after this.RateCardID b'cas If RateCard open in Edit mode then Bind RoomType with this.RateCardID.
                BindConferenceGrid();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                ucRateCardServices.UserRights = this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RATECARDLIST.ASPX");
            else
                ucRateCardServices.UserRights = this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindData()
        {
            try
            {
                ucRateCardCheckInDays.BindCheckboxList();

                //Bind Service DDL
                DataSet dsServiceItems = ItemBLL.SelectAllForRateCard(clsSession.CompanyID, clsSession.PropertyID);
                if (dsServiceItems != null && dsServiceItems.Tables[0].Rows.Count > 0)
                {
                    ucRateCardServices.ddlucServices.DataSource = dsServiceItems.Tables[0];
                    ucRateCardServices.ddlucServices.DataTextField = "ItemName";
                    ucRateCardServices.ddlucServices.DataValueField = "ItemID";
                    ucRateCardServices.ddlucServices.DataBind();
                    ucRateCardServices.ddlucServices.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectService", "-Service-"), Guid.Empty.ToString()));
                }
                else
                    ucRateCardServices.ddlucServices.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectService", "-Service-"), Guid.Empty.ToString()));

                //Bind Service DDL
                StayType ObjToGetStayTypeList = new StayType();
                ObjToGetStayTypeList.IsActive = true;
                ObjToGetStayTypeList.CompanyID = clsSession.CompanyID;
                ObjToGetStayTypeList.PropertyID = clsSession.PropertyID;
                List<StayType> lstStayType = StayTypeBLL.GetAll(ObjToGetStayTypeList);

                if (lstStayType.Count > 0)
                {
                    ucRateCardBasicInfo.ddlucStayType.DataSource = lstStayType;
                    ucRateCardBasicInfo.ddlucStayType.DataTextField = "StayTypeName";
                    ucRateCardBasicInfo.ddlucStayType.DataValueField = "StayTypeID";
                    ucRateCardBasicInfo.ddlucStayType.DataBind();
                    ucRateCardBasicInfo.ddlucStayType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                    ucRateCardBasicInfo.ddlucStayType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));


                // Bind Posting Frequency.
                List<ProjectTerm> lstPostingFreq = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "POSTINGFREQUENCY");

                if (lstPostingFreq.Count != 0)
                {
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataSource = lstPostingFreq;
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataTextField = "DisplayTerm";
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataValueField = "TermID";
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataBind();
                    ucRateCardBasicInfo.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                    ucRateCardServices.ddlucPostingFrequency.DataSource = lstPostingFreq;
                    ucRateCardServices.ddlucPostingFrequency.DataTextField = "DisplayTerm";
                    ucRateCardServices.ddlucPostingFrequency.DataValueField = "TermID";
                    ucRateCardServices.ddlucPostingFrequency.DataBind();
                    ucRateCardServices.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectPostingFrequency", "-Posting Freq.-"), Guid.Empty.ToString()));
                }
                else
                {
                    ucRateCardBasicInfo.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                    ucRateCardServices.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectPostingFrequency", "-Posting Freq.-"), Guid.Empty.ToString()));
                }

                //Bind Tax's Grid
                BindTaxGrid();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex.Message));
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

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblRatecardList", "Ratecard Setup") ;
            dr3["Link"] = "~/GUI/PriceManager/RateCardList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = ucRateCardBasicInfo.ucTxtRateCardName.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblConferenceRatecard", "Conference Ratecard")  : ucRateCardBasicInfo.ucTxtRateCardName.Trim() ;
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("RateCard", "lblMainHeaderConferenceRateCard", "Conference RateCard");
            litTabBasicInformation.Text = clsCommon.GetGlobalResourceText("RateCard", "lblTabBasicInformation", "Basic Information");
            litTabTermsAndConditions.Text = clsCommon.GetGlobalResourceText("RateCard", "lblTabTermsAndConditions", "Term & Condition");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderDateValidate.Text = clsCommon.GetGlobalResourceText("Common", "lblHeaderCustomeMessage", "");
            ltrMsgDateValidate.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDateFromLessThanOrEqualDateTo", "Date from should be less than or equal to Date to.");
            btnDateMessageOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
        }

        private void BindTaxGrid()
        {
            Account objToGetList = new Account();
            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.PropertyID = clsSession.PropertyID;
            objToGetList.IsTaxAcct = objToGetList.IsActive = true;
            objToGetList.IsEnable = true;

            List<Account> lstAccounts = AccountBLL.GetAll(objToGetList);

            ucRateCardTaxes.gvucTaxes.DataSource = lstAccounts;
            ucRateCardTaxes.gvucTaxes.DataBind();
        }

        private void BindConferenceGrid()
        {
            DataSet dsConferences = ConferenceBLL.GetAllForRateCard(clsSession.CompanyID,clsSession.PropertyID, this.RateCardID);

            if (dsConferences.Tables.Count > 1)
            {
                ucConferences.dtExistingDetails = dsConferences.Tables[1];
            }

            ucConferences.gvucConferences.DataSource = dsConferences.Tables[0];
            ucConferences.gvucConferences.DataBind();
        }

        private void LoadRateCardData()
        {
            //Load RateCard Details.
            try
            {
                DataSet dsRateCardData = RateCardBLL.GetDataByPrimaryKey(this.RateCardID);
                if (dsRateCardData != null)
                {
                    // Load Rate Card Data
                    DataRow drRateCard = dsRateCardData.Tables[0].Rows[0];
                    ucRateCardBasicInfo.ucTxtRateCardCode = Convert.ToString(drRateCard["Code"]);
                    ucRateCardBasicInfo.ucTxtRateCardName = Convert.ToString(drRateCard["RateCardName"]);

                    if (Convert.ToString(drRateCard["StartDate"]) != string.Empty)
                        ucRateCardBasicInfo.ucTxtDateFrom = Convert.ToDateTime(drRateCard["StartDate"].ToString()).ToString(clsSession.DateFormat);

                    if (Convert.ToString(drRateCard["EndDate"]) != string.Empty)
                        ucRateCardBasicInfo.ucTxtDateTo = Convert.ToDateTime(drRateCard["EndDate"].ToString()).ToString(clsSession.DateFormat);

                    if (drRateCard["NonRevenueChildren"] != null)
                        ucRateCardBasicInfo.ucTxtAllowedChild = Convert.ToString(drRateCard["NonRevenueChildren"]);

                    if (drRateCard["PkgNoOfAdult"] != null)
                        ucRateCardBasicInfo.ucTxtAllowedAdults = Convert.ToString(drRateCard["PkgNoOfAdult"]);                    

                    if (drRateCard["IsEnable"] != null)
                        ucRateCardBasicInfo.ucChkIsEnable = Convert.ToBoolean(drRateCard["IsEnable"]);

                    ////if (drRateCard["IsStandard"] != null && Convert.ToString(drRateCard["IsStandard"]) != "")
                    ////    ucRateCardBasicInfo.ucChkIsStandardRateCard = Convert.ToBoolean(drRateCard["IsStandard"]);

                    ucRateCardBasicInfo.ddlucStayType.SelectedIndex = ucRateCardBasicInfo.ddlucStayType.Items.FindByValue(Convert.ToString(drRateCard["StayTypeID"])) != null ? ucRateCardBasicInfo.ddlucStayType.Items.IndexOf(ucRateCardBasicInfo.ddlucStayType.Items.FindByValue(Convert.ToString(drRateCard["StayTypeID"]))) : 0;
                    ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex = ucRateCardBasicInfo.ddlucPostingFrequency.Items.FindByValue(Convert.ToString(drRateCard["PostingFreq_TermID"])) != null ? ucRateCardBasicInfo.ddlucPostingFrequency.Items.IndexOf(ucRateCardBasicInfo.ddlucPostingFrequency.Items.FindByValue(Convert.ToString(drRateCard["PostingFreq_TermID"]))) : 0;

                    //Load Terms and Conditions
                    ucTermsAndConditions.ucTxtDetails = Convert.ToString(drRateCard["RateCardDetails"]);
                    ucTermsAndConditions.ucTxtTermsAndConditions = Convert.ToString(drRateCard["TermsAndCondition"]);

                    //Load Check-in Days CheckBoxList
                    for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
                    {
                        switch (ucRateCardCheckInDays.ucChkLstDays.Items[i].Value.ToUpper())
                        {
                            case "MONDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInMonday"]);
                                break;
                            case "TUESDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInTuesday"]);
                                break;
                            case "WEDNESDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInWednesday"]);
                                break;
                            case "THURSDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInThursday"]);
                                break;
                            case "FRIDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInFriday"]);
                                break;
                            case "SATURDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInSaturday"]);
                                break;
                            case "SUNDAY":
                                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInSunday"]);
                                break;
                        }
                    }

                    //Load RateTaxes
                    if (dsRateCardData.Tables.Count > 1)
                    {
                        DataTable dtRateTax = dsRateCardData.Tables[1];

                        for (int i = 0; i < ucRateCardTaxes.gvucTaxes.Rows.Count; i++)
                        {
                            DataRow[] rows = dtRateTax.Select("TaxID = '" + Convert.ToString(ucRateCardTaxes.gvucTaxes.DataKeys[i]["AcctID"]) + "'");
                            if (rows.Length > 0)
                            {
                                ((CheckBox)ucRateCardTaxes.gvucTaxes.Rows[i].FindControl("chkSelect")).Checked = true;
                            }
                        }
                    }

                    //Load RateServices
                    ucRateCardServices.RateID = this.RateCardID;
                    if (dsRateCardData.Tables.Count > 2)
                    {
                        ucRateCardServices.dtRateServices = dsRateCardData.Tables[2];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void ClearControls()
        {
            clsSession.ToEditItemID = this.RateCardID = Guid.Empty;

            //Clear BasicInfo Controls
            //ucRateCardBasicInfo.ClearControls();
            ucRateCardBasicInfo.ucTxtRateCardCode = ucRateCardBasicInfo.ucTxtRateCardName = ucRateCardBasicInfo.ucTxtDateFrom = ucRateCardBasicInfo.ucTxtDateTo = string.Empty;
            ucRateCardBasicInfo.ucTxtNoOfNights = ucRateCardBasicInfo.ucTxtAllowedAdults = ucRateCardBasicInfo.ucTxtAllowedChild = string.Empty;
            ////ucRateCardBasicInfo.ucChkIsEnable = ucRateCardBasicInfo.ucChkIsStandardRateCard = false;
            ucRateCardBasicInfo.ucChkIsEnable = false;
            ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex = ucRateCardBasicInfo.ddlucStayType.SelectedIndex = 0;


            //Clear T&C controls
            ucTermsAndConditions.ucTxtDetails = ucTermsAndConditions.ucTxtTermsAndConditions = string.Empty;

            //Clear Taxes Grid
            for (int i = 0; i < ucRateCardTaxes.gvucTaxes.Rows.Count; i++)
            {
                ((CheckBox)ucRateCardTaxes.gvucTaxes.Rows[i].FindControl("chkSelect")).Checked = false;
            }

            //Clear Services Grid
            Session["RateServiceJoin"] = null;
            ucRateCardServices.RateID = Guid.Empty;
            ucRateCardServices.BindServiceGrid();

            //Clear CheckinDays CheckboxList
            for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
            {
                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = false;
            }

            //Clear RoomType Grid
            BindConferenceGrid();
        }
        #endregion

        #region Control Events
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (ucRateCardBasicInfo.ucTxtDateFrom.Trim() != string.Empty && ucRateCardBasicInfo.ucTxtDateTo.Trim() != string.Empty)
                    {
                        if (DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateFrom.Trim(), clsSession.DateFormat, objCultureInfo) > DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateTo.Trim(), clsSession.DateFormat, objCultureInfo))
                        {
                            MessageBox.Show(clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDateFromLessThanOrEqualDateTo", "Date from should be less than or equal to Date to."));
                            return;
                        }
                    }

                    RateCard objToCheckDuplicate = new RateCard();
                    objToCheckDuplicate.IsActive = true;
                    objToCheckDuplicate.CompanyID = clsSession.CompanyID;
                    objToCheckDuplicate.PropertyID = clsSession.PropertyID;
                    objToCheckDuplicate.RateCardName = ucRateCardBasicInfo.ucTxtRateCardName.Trim();

                    List<RateCard> lstRateCards = RateCardBLL.GetAll(objToCheckDuplicate);
                    if (lstRateCards.Count > 0)
                    {
                        if (this.RateCardID != Guid.Empty)
                        {
                            //Edit Mode
                            if (lstRateCards[0].RateID != this.RateCardID)
                            {
                                IsListMessage = true;
                                litMsgList.Text = clsCommon.GetGlobalResourceText("RateCard", "lblMsgRatecardWithSameNameExists", "Ratecard with same name already exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            litMsgList.Text = clsCommon.GetGlobalResourceText("RateCard", "lblMsgRatecardWithSameNameExists", "Ratecard with same name already exist.");
                            return;
                        }
                    }

                    if (this.RateCardID != Guid.Empty)
                    {
                        //Edit Mode
                        RateCard objToUpdate = RateCardBLL.GetByPrimaryKey(this.RateCardID);
                        RateCard objOldToUpdate = RateCardBLL.GetByPrimaryKey(this.RateCardID);

                        //objToUpdate.AcctID = new Guid("686c2654-b89a-4593-8d52-19612cb367ba");

                        if (ucRateCardBasicInfo.ddlucStayType.SelectedIndex != 0)
                            objToUpdate.StayTypeID = new Guid(ucRateCardBasicInfo.ddlucStayType.SelectedValue.ToString());
                        else
                            objToUpdate.StayTypeID = null;

                        objToUpdate.Code = ucRateCardBasicInfo.ucTxtRateCardCode;
                        objToUpdate.RateCardName = ucRateCardBasicInfo.ucTxtRateCardName;

                        if (ucRateCardBasicInfo.ucTxtDateFrom != string.Empty)
                            objToUpdate.StartDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateFrom.Trim(), clsSession.DateFormat, objCultureInfo);
                        else
                            objToUpdate.StartDate = null;

                        if (ucRateCardBasicInfo.ucTxtDateTo != string.Empty)
                            objToUpdate.EndDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateTo.Trim(), clsSession.DateFormat, objCultureInfo);
                        else
                            objToUpdate.EndDate = null;

                        if (ucRateCardBasicInfo.ucTxtAllowedAdults != string.Empty)
                            objToUpdate.PkgNoOfAdult = Convert.ToInt32(ucRateCardBasicInfo.ucTxtAllowedAdults);
                        else
                            objToUpdate.PkgNoOfAdult = null;

                        if (ucRateCardBasicInfo.ucTxtAllowedChild != string.Empty)
                            objToUpdate.NonRevenueChildren = Convert.ToInt32(ucRateCardBasicInfo.ucTxtAllowedChild);
                        else
                            objToUpdate.NonRevenueChildren = null;

                        if (ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex != 0)
                            objToUpdate.PostingFreq_TermID = new Guid(ucRateCardBasicInfo.ddlucPostingFrequency.SelectedValue.ToString());
                        else
                            objToUpdate.PostingFreq_TermID = null;

                        objToUpdate.IsEnable = ucRateCardBasicInfo.ucChkIsEnable;
                        ////objToUpdate.IsStandard = Convert.ToBoolean(ucRateCardBasicInfo.ucChkIsStandardRateCard);

                        objToUpdate.RateCardDetails = ucTermsAndConditions.ucTxtDetails;
                        objToUpdate.TermsAndCondition = ucTermsAndConditions.ucTxtTermsAndConditions;

                        objToUpdate.IsCheckInMonday = objToUpdate.IsCheckInTuesday = objToUpdate.IsCheckInWednesday =  objToUpdate.IsCheckInThursday = objToUpdate.IsCheckInFriday = false;
                        objToUpdate.IsCheckInSaturday = objToUpdate.IsCheckInSunday = false;

                        for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
                        {
                            if (ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected)
                            {
                                switch (ucRateCardCheckInDays.ucChkLstDays.Items[i].Value.ToUpper())
                                {
                                    case "MONDAY":
                                        objToUpdate.IsCheckInMonday = true; break;
                                    case "TUESDAY":
                                        objToUpdate.IsCheckInTuesday = true; break;
                                    case "WEDNESDAY":
                                        objToUpdate.IsCheckInWednesday = true; break;
                                    case "THURSDAY":
                                        objToUpdate.IsCheckInThursday = true; break;
                                    case "FRIDAY":
                                        objToUpdate.IsCheckInFriday = true; break;
                                    case "SATURDAY":
                                        objToUpdate.IsCheckInSaturday = true; break;
                                    case "SUNDAY":
                                        objToUpdate.IsCheckInSunday = true; break;
                                }
                            }
                        }

                        List<RateTaxes> lstRateTaxes = new List<RateTaxes>();
                        for (int i = 0; i < ucRateCardTaxes.gvucTaxes.Rows.Count; i++)
                        {
                            if (((CheckBox)ucRateCardTaxes.gvucTaxes.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                RateTaxes objToAdd = new RateTaxes();
                                objToAdd.IsActive = true;
                                objToAdd.TaxID = new Guid(Convert.ToString(ucRateCardTaxes.gvucTaxes.DataKeys[i]["AcctID"]));
                                lstRateTaxes.Add(objToAdd);
                            }
                        }

                        List<RateCardDetails> lstRateCardDetails = new List<RateCardDetails>();
                        for (int i = 0; i < ucConferences.gvucConferences.Rows.Count; i++)
                        {
                            if (((CheckBox)ucConferences.gvucConferences.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                TextBox txtRackRate = (TextBox)ucConferences.gvucConferences.Rows[i].FindControl("txtRackRate");
                                TextBox txtExtraAdult = (TextBox)ucConferences.gvucConferences.Rows[i].FindControl("txtExtraAdult");
                                TextBox txtExtraChild = (TextBox)ucConferences.gvucConferences.Rows[i].FindControl("txtExtraChild");                                

                                RateCardDetails objToAdd = new RateCardDetails();
                                objToAdd.IsActive = true;
                                objToAdd.ConferenceID = new Guid(Convert.ToString(ucConferences.gvucConferences.DataKeys[i]["ConferenceID"]));

                                if (txtRackRate != null && txtRackRate.Text.Trim() != string.Empty)
                                    objToAdd.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());
                                else
                                    objToAdd.RackRate = null;

                                if (txtExtraAdult != null && txtExtraAdult.Text.Trim() != string.Empty)
                                    objToAdd.ExtraAdultRate = Convert.ToDecimal(txtExtraAdult.Text.Trim());
                                else
                                    objToAdd.ExtraAdultRate = null;

                                if (txtExtraChild != null && txtExtraChild.Text.Trim() != string.Empty)
                                    objToAdd.ChildRate = Convert.ToDecimal(txtExtraChild.Text.Trim());
                                else
                                    objToAdd.ChildRate = null;

                                lstRateCardDetails.Add(objToAdd);
                            }
                        }

                        //Object to get RateTaxes from DB.
                        RateTaxes objToGetRateTaxesList = new RateTaxes();
                        objToGetRateTaxesList.RateID = this.RateCardID;
                        objToGetRateTaxesList.IsActive = true;
                        List<RateTaxes> lstTaxesFromDB = RateTaxesBLL.GetAll(objToGetRateTaxesList);


                        //Object to get RateCardDetails from DB.
                        RateCardDetails objToGetRateCardDetailsList = new RateCardDetails();
                        objToGetRateCardDetailsList.RateID = this.RateCardID;
                        objToGetRateCardDetailsList.IsActive = true;
                        List<RateCardDetails> lstRateCardDetailsFromDB = RateCardDetailsBLL.GetAll(objToGetRateCardDetailsList);

                        List<CorporateRates> lstCorporates = new List<CorporateRates>();
                        List<CorporateRates> lstCorporatesFromDB = new List<CorporateRates>();

                        RateCardBLL.UpdateRateCard(objToUpdate, lstRateTaxes, lstTaxesFromDB, lstRateCardDetails, lstRateCardDetailsFromDB, lstCorporates, lstCorporatesFromDB, clsSession.UserID, "CONFERENCE",null,null);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldToUpdate.ToString(), objToUpdate.ToString(), "mst_RateCard");
                        litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        IsListMessage = true;

                        /////***********  Update  ************//////////
                    }
                    else
                    {
                        //Insert Mode
                        RateCard objToInsert = new RateCard();

                        objToInsert.AcctID = new Guid("686c2654-b89a-4593-8d52-19612cb367ba");
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.IsActive = true;
                        objToInsert.IsDefault = objToInsert.IsEventChargeEnable = objToInsert.IsRateInclService = objToInsert.IsYieldEnable = false;
                        objToInsert.RateTypeName = "CONFERENCE";

                        if (ucRateCardBasicInfo.ddlucStayType.SelectedIndex != 0)
                            objToInsert.StayTypeID = new Guid(ucRateCardBasicInfo.ddlucStayType.SelectedValue.ToString());

                        objToInsert.Code = ucRateCardBasicInfo.ucTxtRateCardCode;
                        objToInsert.RateCardName = ucRateCardBasicInfo.ucTxtRateCardName;

                        if (ucRateCardBasicInfo.ucTxtDateFrom != string.Empty)
                            objToInsert.StartDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateFrom.Trim(), clsSession.DateFormat, objCultureInfo);

                        if (ucRateCardBasicInfo.ucTxtDateTo != string.Empty)
                            objToInsert.EndDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateTo.Trim(), clsSession.DateFormat, objCultureInfo);

                        if (ucRateCardBasicInfo.ucTxtAllowedAdults != string.Empty)
                            objToInsert.PkgNoOfAdult = Convert.ToInt32(ucRateCardBasicInfo.ucTxtAllowedAdults);

                        if (ucRateCardBasicInfo.ucTxtAllowedChild != string.Empty)
                            objToInsert.NonRevenueChildren = Convert.ToInt32(ucRateCardBasicInfo.ucTxtAllowedChild);

                        if (ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex != 0)
                            objToInsert.PostingFreq_TermID = new Guid(ucRateCardBasicInfo.ddlucPostingFrequency.SelectedValue.ToString());

                        objToInsert.IsEnable = ucRateCardBasicInfo.ucChkIsEnable;
                        ////objToInsert.IsStandard = Convert.ToBoolean(ucRateCardBasicInfo.ucChkIsStandardRateCard);

                        objToInsert.RateCardDetails = ucTermsAndConditions.ucTxtDetails;
                        objToInsert.TermsAndCondition = ucTermsAndConditions.ucTxtTermsAndConditions;

                        for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
                        {
                            if (ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected)
                            {
                                switch (ucRateCardCheckInDays.ucChkLstDays.Items[i].Value.ToUpper())
                                {
                                    case "MONDAY":
                                        objToInsert.IsCheckInMonday = true; break;
                                    case "TUESDAY":
                                        objToInsert.IsCheckInTuesday = true; break;
                                    case "WEDNESDAY":
                                        objToInsert.IsCheckInWednesday = true; break;
                                    case "THURSDAY":
                                        objToInsert.IsCheckInThursday = true; break;
                                    case "FRIDAY":
                                        objToInsert.IsCheckInFriday = true; break;
                                    case "SATURDAY":
                                        objToInsert.IsCheckInSaturday = true; break;
                                    case "SUNDAY":
                                        objToInsert.IsCheckInSunday = true; break;
                                }
                            }
                        }

                        List<RateServiceJoin> lstRateServiceJoin = null;
                        if (Session["RateServiceJoin"] != null)
                            lstRateServiceJoin = (List<RateServiceJoin>)Session["RateServiceJoin"];
                        else
                            lstRateServiceJoin = new List<RateServiceJoin>();

                        List<RateTaxes> lstRateTaxes = new List<RateTaxes>();
                        for (int i = 0; i < ucRateCardTaxes.gvucTaxes.Rows.Count; i++)
                        {
                            if (((CheckBox)ucRateCardTaxes.gvucTaxes.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                RateTaxes objToAdd = new RateTaxes();
                                objToAdd.IsActive = true;
                                objToAdd.TaxID = new Guid(Convert.ToString(ucRateCardTaxes.gvucTaxes.DataKeys[i]["AcctID"]));
                                lstRateTaxes.Add(objToAdd);
                            }
                        }

                        List<RateCardDetails> lstRateCardDetails = new List<RateCardDetails>();
                        for (int i = 0; i < ucConferences.gvucConferences.Rows.Count; i++)
                        {
                            if (((CheckBox)ucConferences.gvucConferences.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                TextBox txtRackRate = (TextBox)ucConferences.gvucConferences.Rows[i].FindControl("txtRackRate");
                                TextBox txtExtraAdult = (TextBox)ucConferences.gvucConferences.Rows[i].FindControl("txtExtraAdult");
                                TextBox txtExtraChild = (TextBox)ucConferences.gvucConferences.Rows[i].FindControl("txtExtraChild");

                                RateCardDetails objToAdd = new RateCardDetails();
                                objToAdd.IsActive = true;
                                objToAdd.ConferenceID = new Guid(Convert.ToString(ucConferences.gvucConferences.DataKeys[i]["ConferenceID"]));

                                if (txtRackRate != null && txtRackRate.Text.Trim() != string.Empty)
                                    objToAdd.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());
                                else
                                    objToAdd.RackRate = null;

                                if (txtExtraAdult != null && txtExtraAdult.Text.Trim() != string.Empty)
                                    objToAdd.ExtraAdultRate = Convert.ToDecimal(txtExtraAdult.Text.Trim());
                                else
                                    objToAdd.ExtraAdultRate = null;

                                if (txtExtraChild != null && txtExtraChild.Text.Trim() != string.Empty)
                                    objToAdd.ChildRate = Convert.ToDecimal(txtExtraChild.Text.Trim());
                                else
                                    objToAdd.ChildRate = null;

                                lstRateCardDetails.Add(objToAdd);
                            }
                        }

                        List<CorporateRates> lstCorporateRates = new List<CorporateRates>();

                        RateCardBLL.SaveRateCard(objToInsert, lstRateTaxes, lstRateServiceJoin, lstRateCardDetails, lstCorporateRates,null,null);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_RateCard");
                        litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        IsListMessage = true;
                    }

                    ClearControls();

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

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            ClearControls();

            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();            
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/PriceManager/RateCardList.aspx");
        }
        #endregion
    }
}