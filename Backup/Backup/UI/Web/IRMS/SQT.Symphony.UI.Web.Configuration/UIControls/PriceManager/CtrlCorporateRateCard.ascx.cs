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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlCorporateRateCard : System.Web.UI.UserControl
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

        public string OldDate
        {
            get
            {
                return ViewState["OldDate"] != null ? Convert.ToString(ViewState["OldDate"]) : string.Empty;
            }
            set
            {
                ViewState["OldDate"] = value;
            }
        }

        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                Session["ComplimentoryServices"] = Session["TaxList"] = Session["MinDaysRequired"] = Session["SpecialDays"] = null;

                CheckUserAuthorization();
                hfDateFormat.Value = clsSession.DateFormat;
                BindData();
                SetPageLables();

                gvDispalySpecialDays.DataSource = null;
                gvDispalySpecialDays.DataBind();

                if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATERATECARD")
                {
                    btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.RateCardID = ucRateCardCorporates.RateCardID = clsSession.ToEditItemID;
                    LoadRateCardData();
                    LoadSpecialDaysGrid();
                }

                //Bind after this.RateCardID b'cas If RateCard open in Edit mode then Bind RoomType with this.RateCardID.
                BindRoomTypeGrid();
                BindCorporateGrid();
                LoadCompServiceData();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RATECARDLIST.ASPX");
            else
                this.UserRights = "1111";

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
                ////DataSet dsServiceItems = ItemBLL.SelectAllForRateCard(clsSession.CompanyID, clsSession.PropertyID);
                ////if (dsServiceItems != null && dsServiceItems.Tables[0].Rows.Count > 0)
                ////{
                ////    ucRateCardServices.ddlucServices.DataSource = dsServiceItems.Tables[0];
                ////    ucRateCardServices.ddlucServices.DataTextField = "ItemName";
                ////    ucRateCardServices.ddlucServices.DataValueField = "ItemID";
                ////    ucRateCardServices.ddlucServices.DataBind();
                ////    ucRateCardServices.ddlucServices.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectService", "-Service-"), Guid.Empty.ToString()));
                ////}
                ////else
                ////    ucRateCardServices.ddlucServices.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectService", "-Service-"), Guid.Empty.ToString()));

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


                CancellationPolicyMaster ObjToGetCancellationPolicy = new CancellationPolicyMaster();
                ObjToGetCancellationPolicy.IsActive = true;
                ObjToGetCancellationPolicy.CompanyID = clsSession.CompanyID;
                ObjToGetCancellationPolicy.PropertyID = clsSession.PropertyID;
                List<CancellationPolicyMaster> lstCancellationPolicy = CancellationPolicyMasterBLL.GetAll(ObjToGetCancellationPolicy);

                if (lstCancellationPolicy.Count > 0)
                {
                    lstCancellationPolicy.Sort((CancellationPolicyMaster d1, CancellationPolicyMaster d2) => d1.PolicyTitle.CompareTo(d2.PolicyTitle));
                    ucRateCardBasicInfo.ddlucCancellationPolicy.DataSource = lstCancellationPolicy;
                    ucRateCardBasicInfo.ddlucCancellationPolicy.DataTextField = "PolicyTitle";
                    ucRateCardBasicInfo.ddlucCancellationPolicy.DataValueField = "ResPolicyID";
                    ucRateCardBasicInfo.ddlucCancellationPolicy.DataBind();
                    ucRateCardBasicInfo.ddlucCancellationPolicy.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
                else
                    ucRateCardBasicInfo.ddlucCancellationPolicy.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));


                // Bind Posting Frequency.
                List<ProjectTerm> lstPostingFreq = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "POSTINGFREQUENCY");

                if (lstPostingFreq.Count != 0)
                {
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataSource = lstPostingFreq;
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataTextField = "DisplayTerm";
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataValueField = "TermID";
                    ucRateCardBasicInfo.ddlucPostingFrequency.DataBind();
                    ucRateCardBasicInfo.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                    ////ucRateCardServices.ddlucPostingFrequency.DataSource = lstPostingFreq;
                    ////ucRateCardServices.ddlucPostingFrequency.DataTextField = "DisplayTerm";
                    ////ucRateCardServices.ddlucPostingFrequency.DataValueField = "TermID";
                    ////ucRateCardServices.ddlucPostingFrequency.DataBind();
                    ////ucRateCardServices.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectPostingFrequency", "-Posting Freq.-"), Guid.Empty.ToString()));
                }
                else
                {
                    ucRateCardBasicInfo.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                    ////ucRateCardServices.ddlucPostingFrequency.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("RateCardServices", "lblDDLSelectPostingFrequency", "-Posting Freq.-"), Guid.Empty.ToString()));
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
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblRatecardList", "Ratecard Setup");
            dr3["Link"] = "~/GUI/PriceManager/RateCardList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = ucRateCardBasicInfo.ucTxtRateCardName.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblCorporateRatecard", "Corporate Ratecard") : ucRateCardBasicInfo.ucTxtRateCardName.Trim();
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("RateCard", "lblMainHeaderCorporateRateCard", "Corporate RateCard");
            //litTabBasicInformation.Text = clsCommon.GetGlobalResourceText("RateCard", "lblTabBasicInformation", "Basic Information");
            //litTabTermsAndConditions.Text = clsCommon.GetGlobalResourceText("RateCard", "lblTabTermsAndConditions", "Term & Condition");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderDateValidate.Text = clsCommon.GetGlobalResourceText("Common", "lblHeaderCustomeMessage", "Message");
            ltrMsgDateValidate.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDateFromLessThanOrEqualDateTo", "Date from should be less than or equal to Date to.");
            btnDateMessageOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnOK", "OK");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");

            this.strClearDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpClearDate", "Clear Date");

            calDate.Format = clsSession.DateFormat;
        }

        private void BindTaxGrid()
        {
            Account objToGetList = new Account();
            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.PropertyID = clsSession.PropertyID;
            objToGetList.IsActive = true;
            objToGetList.IsEnable = true;
            objToGetList.IsTaxAcct = true;

            List<Account> lstAccounts = AccountBLL.GetAll(objToGetList);

            if (lstAccounts != null && lstAccounts.Count > 0)
            {
                ucRateCardTaxes.gvucTaxes.DataSource = lstAccounts;
                ucRateCardTaxes.gvucTaxes.DataBind();
            }
            else
            {
                ucRateCardTaxes.gvucTaxes.DataSource = null;
                ucRateCardTaxes.gvucTaxes.DataBind();
            }

            //Account objToGetList = new Account();
            //objToGetList.CompanyID = clsSession.CompanyID;
            //objToGetList.PropertyID = clsSession.PropertyID;
            //objToGetList.IsTaxAcct = objToGetList.IsActive = true;
            //objToGetList.IsEnable = true;

            //List<Account> lstAccounts = AccountBLL.GetAll(objToGetList);

            //ucRateCardTaxes.gvucTaxes.DataSource = lstAccounts;
            //ucRateCardTaxes.gvucTaxes.DataBind();
        }

        private void BindRoomTypeGrid()
        {
            DataSet dsRoomType = RoomTypeBLL.GetAllForRateCard(clsSession.PropertyID, this.RateCardID);

            if (dsRoomType.Tables.Count > 1)
            {
                ucRateCardRoomTypes.dtExistingDetails = dsRoomType.Tables[1];
            }

            ucRateCardRoomTypes.gvucRoomTypes.DataSource = dsRoomType.Tables[0];
            ucRateCardRoomTypes.gvucRoomTypes.DataBind();

            if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATERATECARD")
            {
                SessionTaxList();
                //old Method for tax calculation
                ////CalculateRate();

                //New method for tax calculation
                CalculateTaxRate_New();
            }
        }

        private void BindCorporateGrid()
        {
            DataSet dsCorporate = CorporateBLL.GetAllForRateCard(clsSession.CompanyID, clsSession.PropertyID, this.RateCardID);

            if (dsCorporate.Tables.Count > 1)
            {
                ucRateCardCorporates.dtExistingDetails = dsCorporate.Tables[1];
            }

            ucRateCardCorporates.gvucCorporates.DataSource = dsCorporate.Tables[0];
            ucRateCardCorporates.gvucCorporates.DataBind();
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
                    ucRateCardBasicInfo.ucTxtRateCardDispName = Convert.ToString(drRateCard["RateCardDispName"]);

                    if (Convert.ToString(drRateCard["MinimumDaysRequired"]) != string.Empty)
                    {
                        ucRateCardBasicInfo.ucTxtStayDuration = Convert.ToString(drRateCard["MinimumDaysRequired"]);
                        Session["MinDaysRequired"] = Convert.ToString(drRateCard["MinimumDaysRequired"]);
                    }

                    if (Convert.ToString(drRateCard["StartDate"]) != string.Empty)
                        ucRateCardBasicInfo.ucTxtDateFrom = Convert.ToDateTime(drRateCard["StartDate"].ToString()).ToString(clsSession.DateFormat);

                    if (Convert.ToString(drRateCard["EndDate"]) != string.Empty)
                        ucRateCardBasicInfo.ucTxtDateTo = Convert.ToDateTime(drRateCard["EndDate"].ToString()).ToString(clsSession.DateFormat);

                    if (drRateCard["NonRevenueChildren"] != null)
                        ucRateCardBasicInfo.ucTxtAllowedChild = Convert.ToString(drRateCard["NonRevenueChildren"]);

                    if (drRateCard["IsEnable"] != null)
                        ucRateCardBasicInfo.ucChkIsEnable = Convert.ToBoolean(drRateCard["IsEnable"]);

                    if (drRateCard["IsPerRoom"] != null)
                        ucRateCardBasicInfo.ucChkIsPerRoom = Convert.ToBoolean(drRateCard["IsPerRoom"]);

                    if (drRateCard["RetentionChargePercent"] != null)
                        ucRateCardBasicInfo.ucTxtRetentionCharge = Convert.ToString(drRateCard["RetentionChargePercent"]);

                    //////if (drRateCard["IsStandard"] != null && Convert.ToString(drRateCard["IsStandard"]) != "")
                    //////    ucRateCardBasicInfo.ucChkIsStandardRateCard = Convert.ToBoolean(drRateCard["IsStandard"]);

                    ucRateCardBasicInfo.ddlucStayType.SelectedIndex = ucRateCardBasicInfo.ddlucStayType.Items.FindByValue(Convert.ToString(drRateCard["StayTypeID"])) != null ? ucRateCardBasicInfo.ddlucStayType.Items.IndexOf(ucRateCardBasicInfo.ddlucStayType.Items.FindByValue(Convert.ToString(drRateCard["StayTypeID"]))) : 0;
                    ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex = ucRateCardBasicInfo.ddlucPostingFrequency.Items.FindByValue(Convert.ToString(drRateCard["PostingFreq_TermID"])) != null ? ucRateCardBasicInfo.ddlucPostingFrequency.Items.IndexOf(ucRateCardBasicInfo.ddlucPostingFrequency.Items.FindByValue(Convert.ToString(drRateCard["PostingFreq_TermID"]))) : 0;
                    ucRateCardBasicInfo.ddlucCancellationPolicy.SelectedIndex = ucRateCardBasicInfo.ddlucCancellationPolicy.Items.FindByValue(Convert.ToString(drRateCard["CancellationPolicyID"])) != null ? ucRateCardBasicInfo.ddlucCancellationPolicy.Items.IndexOf(ucRateCardBasicInfo.ddlucCancellationPolicy.Items.FindByValue(Convert.ToString(drRateCard["CancellationPolicyID"]))) : 0;

                    //Load Terms and Conditions
                    //ucTermsAndConditions.ucTxtDetails = Convert.ToString(drRateCard["RateCardDetails"]);
                    //ucTermsAndConditions.ucTxtTermsAndConditions = Convert.ToString(drRateCard["TermsAndCondition"]);

                    //Load Check-in Days CheckBoxList
                    //for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
                    //{
                    //    switch (ucRateCardCheckInDays.ucChkLstDays.Items[i].Value.ToUpper())
                    //    {
                    //        case "MONDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInMonday"]);
                    //            break;
                    //        case "TUESDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInTuesday"]);
                    //            break;
                    //        case "WEDNESDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInWednesday"]);
                    //            break;
                    //        case "THURSDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInThursday"]);
                    //            break;
                    //        case "FRIDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInFriday"]);
                    //            break;
                    //        case "SATURDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInSaturday"]);
                    //            break;
                    //        case "SUNDAY":
                    //            ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = Convert.ToBoolean(drRateCard["IsCheckInSunday"]);
                    //            break;
                    //    }
                    //}

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
                    ////if (dsRateCardData.Tables.Count > 2)
                    ////{
                    ////    ucRateCardServices.RateID = this.RateCardID;
                    ////    ucRateCardServices.dtRateServices = dsRateCardData.Tables[2];
                    ////}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void ClearControls()
        {
            clsSession.ToEditItemID = this.RateCardID = ucRateCardCorporates.RateCardID = Guid.Empty;

            //Clear BasicInfo Controls
            //ucRateCardBasicInfo.ClearControls();
            ucRateCardBasicInfo.ucTxtRateCardCode = ucRateCardBasicInfo.ucTxtRateCardName = ucRateCardBasicInfo.ucTxtDateFrom = ucRateCardBasicInfo.ucTxtDateTo = ucRateCardBasicInfo.ucTxtRateCardDispName = ucRateCardBasicInfo.ucTxtRetentionCharge = string.Empty;
            ucRateCardBasicInfo.ucTxtNoOfNights = ucRateCardBasicInfo.ucTxtAllowedAdults = ucRateCardBasicInfo.ucTxtAllowedChild = string.Empty;
            ////ucRateCardBasicInfo.ucChkIsEnable = ucRateCardBasicInfo.ucChkIsStandardRateCard = false;
            ucRateCardBasicInfo.ucChkIsEnable = false;
            ucRateCardBasicInfo.ucTxtStayDuration = "";
            ucRateCardBasicInfo.ddlucCancellationPolicy.SelectedIndex = 0;
            ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex = ucRateCardBasicInfo.ddlucStayType.SelectedIndex = 0;


            //Clear T&C controls
            //ucTermsAndConditions.ucTxtDetails = ucTermsAndConditions.ucTxtTermsAndConditions = string.Empty;

            //Clear Taxes Grid
            for (int i = 0; i < ucRateCardTaxes.gvucTaxes.Rows.Count; i++)
            {
                ((CheckBox)ucRateCardTaxes.gvucTaxes.Rows[i].FindControl("chkSelect")).Checked = false;
            }

            //Clear Services Grid
            ////Session["RateServiceJoin"] = null;
            ////ucRateCardServices.RateID = Guid.Empty;
            ////ucRateCardServices.BindServiceGrid();

            //Clear CheckinDays CheckboxList
            for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
            {
                ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected = false;
            }

            //Clear RoomType Grid
            BindRoomTypeGrid();

            //Clear Corporate Grid
            BindCorporateGrid();

            Session["ComplimentoryServices"] = Session["TaxList"] = Session["MinDaysRequired"] = Session["SpecialDays"] = null;

            gvDispalySpecialDays.DataSource = null;
            gvDispalySpecialDays.DataBind();
        }

        private void LoadSpecialDaysGrid()
        {
            try
            {
                CalenderEvent objCalenderEvent = new CalenderEvent();
                objCalenderEvent.PropertyID = clsSession.PropertyID;
                objCalenderEvent.RateID = this.RateCardID;

                string strCalendearQuery = "select * from mst_CalenderEvent where RateID = '" + Convert.ToString(this.RateCardID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1";
                DataSet dsLoadCalenderEvent = RoomTypeBLL.GetUnitType(strCalendearQuery);

                if (dsLoadCalenderEvent.Tables.Count > 0 && dsLoadCalenderEvent.Tables[0].Rows.Count > 0)
                {
                    DataTable dtSessionSpecialDays = dsLoadCalenderEvent.Tables[0];
                    Session["SpecialDays"] = dtSessionSpecialDays;

                    DataTable dtBindSpecialDaysGrid = new DataTable();
                    DataView dView = new DataView(dtSessionSpecialDays);
                    string[] arrColumns = { "EventName", "EventDate" };
                    dtSessionSpecialDays = dView.ToTable(true, arrColumns);

                    if (dtSessionSpecialDays.Rows.Count > 0)
                    {
                        gvDispalySpecialDays.DataSource = dtSessionSpecialDays;
                        gvDispalySpecialDays.DataBind();
                    }
                    else
                    {
                        gvDispalySpecialDays.DataSource = null;
                        gvDispalySpecialDays.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        public void LoadCompServiceData()
        {
            DataSet dsData = RateServiceJoinBLL.SelectAllDataByRateID(this.RateCardID);

            if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
            {
                DataTable dtdata = dsData.Tables[0];
                Session["ComplimentoryServices"] = dtdata;
            }
        }

        private void SessionTaxList()
        {
            try
            {
                string strTax = string.Empty;

                //DataTable dttax = new DataTable();

                //DataColumn dc1 = new DataColumn("AcctID");
                //DataColumn dc2 = new DataColumn("AcctName");
                //DataColumn dc3 = new DataColumn("MultipleAcctID");

                //dttax.Columns.Add(dc1);
                //dttax.Columns.Add(dc2);

                for (int i = 0; i < ucRateCardTaxes.gvucTaxes.Rows.Count; i++)
                {
                    CheckBox chkSelect = (CheckBox)(ucRateCardTaxes.gvucTaxes).Rows[i].FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        //DataRow dr = dttax.NewRow();
                        //dr["AcctID"] = Convert.ToString(ucRateCardTaxes.gvucTaxes.DataKeys[i]["AcctID"]);
                        //dr["AcctName"] = Convert.ToString(lblTax.Text.Trim());
                        //AcctID

                        if (strTax == string.Empty)
                            strTax += "'" + Convert.ToString(ucRateCardTaxes.gvucTaxes.DataKeys[i]["AcctID"]) + "'";
                        else
                            strTax += ",'" + Convert.ToString(ucRateCardTaxes.gvucTaxes.DataKeys[i]["AcctID"]) + "'";

                        //dr["MultipleAcctID"] = strTax;

                        //dttax.Rows.Add(dr);
                    }
                }

                Session["TaxList"] = strTax;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void CalculateRate()
        {
            try
            {
                string strTaxList = "";
                DataTable dtData = new DataTable();

                if (Session["TaxList"] != null)
                {
                    strTaxList = Convert.ToString(Session["TaxList"]);
                    if (Convert.ToString(strTaxList) != "" && strTaxList != null)
                    {
                        string strTaxSlabeQuery = "select TaxID,TaxRate,IsTaxFlat,MinAmount,IsNull(MaxAmount,99999999.99)'MaxAmount' from acc_TaxSlabe where TaxID in (" + Convert.ToString(strTaxList) + ") order by TaxID,MinAmount asc";
                        DataSet dsTaxSlabe = new DataSet();
                        dsTaxSlabe = RoomBLL.GetUnitNo(strTaxSlabeQuery);

                        if (dsTaxSlabe.Tables.Count > 0 && dsTaxSlabe.Tables[0].Rows.Count > 0)
                        {
                            dtData = dsTaxSlabe.Tables[0];
                        }
                    }
                }

                for (int i = 0; i < ucRateCardRoomTypes.gvucRoomTypes.Rows.Count; i++)
                {
                    CheckBox chkSelect = (CheckBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        TextBox txtDeposit = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtDeposit");
                        TextBox txtTotalRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTotalRackRate");
                        TextBox txtTaxes = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTaxes");
                        Label lblTotal = (Label)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("lblTotal");
                        TextBox txtRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtRackRate");

                        decimal dcTotalRaceRate = Convert.ToDecimal(0.00);

                        if (Session["TaxList"] != null)
                        {
                            if (Convert.ToString(strTaxList) != "" && strTaxList != null)
                            {
                                string[] strsplit = strTaxList.Split(',');
                                if (strsplit.Length > 0)
                                {
                                    for (int k = 0; k < strsplit.Length; k++)
                                    {
                                        if (dtData.Rows.Count > 0)
                                        {
                                            if (txtTotalRackRate.Text.Trim() != "" && txtRackRate.Text.Trim() != "")
                                            {
                                                //for (int j = 0; j < dt.Rows.Count; j++)
                                                //{
                                                string strTaxRate = txtRackRate.Text.Trim().IndexOf('.') > -1 ? txtRackRate.Text.Trim() + "000000" : txtRackRate.Text.Trim() + ".000000";
                                                decimal dcTaxRate = Convert.ToDecimal(strTaxRate);

                                                DataRow[] drSelectTax = dtData.Select("TaxID = '" + Convert.ToString(strsplit[k].Replace("'", " ").Trim()) + "' and '" + dcTaxRate + "' >= MinAmount and '" + dcTaxRate + "' <= MaxAmount");

                                                if (drSelectTax.Length > 0)
                                                {
                                                    string strRate = Convert.ToString(drSelectTax[0]["TaxRate"]);
                                                    string strIsFlat = Convert.ToString(drSelectTax[0]["IsTaxFlat"]);

                                                    if (strRate != "" && strIsFlat != "")
                                                    {
                                                        if (Convert.ToBoolean(strIsFlat) == true)
                                                        {
                                                            dcTotalRaceRate += Convert.ToDecimal(strRate);
                                                        }
                                                        else if (Convert.ToBoolean(strIsFlat) == false)
                                                        {
                                                            string strRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";

                                                            decimal dcRaceRate = Convert.ToDecimal(strRackRate);
                                                            decimal dcpercentage = Convert.ToDecimal(strRate);
                                                            dcTotalRaceRate += Convert.ToDecimal((dcRaceRate * dcpercentage) / 100);
                                                        }
                                                    }
                                                }
                                                // }
                                            }
                                            else
                                                txtTaxes.Text = Convert.ToString(0.00);
                                        }
                                        else
                                            txtTaxes.Text = Convert.ToString(0.00);
                                    }

                                    if (dcTotalRaceRate == 0)
                                        dcTotalRaceRate = Convert.ToDecimal("0.000000");

                                    txtTaxes.Text = Convert.ToString(dcTotalRaceRate.ToString().Substring(0, dcTotalRaceRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                }
                                else
                                    txtTaxes.Text = Convert.ToString(0.00);
                            }
                            else
                                txtTaxes.Text = Convert.ToString(0.00);


                        }
                        else
                            txtTaxes.Text = Convert.ToString(0.00);

                        decimal dcDisplayDeposit = 0;
                        decimal dcDisplayRackrate = 0;
                        decimal dcDisplayTaxes = 0;

                        if (txtDeposit.Text.Trim() != "")
                        {
                            string strDeposit = txtDeposit.Text.Trim().IndexOf('.') > -1 ? txtDeposit.Text.Trim() + "000000" : txtDeposit.Text.Trim() + ".000000";
                            dcDisplayDeposit = Convert.ToDecimal(strDeposit);
                        }

                        if (txtTotalRackRate.Text.Trim() != "")
                        {
                            string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                            dcDisplayRackrate = Convert.ToDecimal(strTotalRackRate);
                        }

                        if (txtTaxes.Text.Trim() != "")
                        {
                            string strTaxes = txtTaxes.Text.Trim().IndexOf('.') > -1 ? txtTaxes.Text.Trim() + "000000" : txtTaxes.Text.Trim() + ".000000";
                            dcDisplayTaxes = Convert.ToDecimal(strTaxes);
                        }

                        decimal dcDisplayTotal = Convert.ToDecimal(dcDisplayDeposit + dcDisplayRackrate + dcDisplayTaxes);
                        string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";

                        lblTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void CalculateTaxRate_New()
        {
            try
            {
                string strTaxList = "";

                for (int i = 0; i < ucRateCardRoomTypes.gvucRoomTypes.Rows.Count; i++)
                {
                    CheckBox chkSelect = (CheckBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        TextBox txtDeposit = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtDeposit");
                        TextBox txtTotalRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTotalRackRate");
                        TextBox txtTaxes = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTaxes");
                        Label lblTotal = (Label)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("lblTotal");
                        TextBox txtRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtRackRate");

                        decimal taxesOfRackRate = Convert.ToDecimal("0.000000");

                        if (Session["TaxList"] != null)
                        {
                            strTaxList = Convert.ToString(Session["TaxList"]);

                            if (Convert.ToString(strTaxList) != "" && strTaxList != null)
                            {
                                if (txtTotalRackRate.Text.Trim() != "" && txtRackRate.Text.Trim() != "" && Convert.ToString(ucRateCardBasicInfo.ucTxtStayDuration.Trim()) != "")
                                {
                                    ////string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                                    ////decimal dcTotalRackRate = Convert.ToDecimal(strTotalRackRate);
                                    string str_RackRate = txtRackRate.Text.Trim().IndexOf('.') > -1 ? txtRackRate.Text.Trim() + "000000" : txtRackRate.Text.Trim() + ".000000";
                                    decimal dcml_RackRate = Convert.ToDecimal(str_RackRate);

                                    Guid? acctid = new Guid("AC77361D-6E87-4A59-8866-F479299B4A8A");

                                    ////taxesOfRackRate += BlockDateRateBLL.CalculateTax(acctid, dcTotalRackRate, "CR", null, null, 1, null, strTaxList, clsSession.PropertyID, clsSession.CompanyID);
                                    taxesOfRackRate += BlockDateRateBLL.CalculateTax(acctid, dcml_RackRate, "CR", null, null, 1, null, null, clsSession.PropertyID, clsSession.CompanyID);
                                }

                                string strDspTax = taxesOfRackRate.ToString().IndexOf('.') > -1 ? taxesOfRackRate.ToString() + "000000" : taxesOfRackRate.ToString() + ".000000";

                                int mindays = 0;
                                if (Convert.ToString(ucRateCardBasicInfo.ucTxtStayDuration.Trim()) != "")
                                    mindays = Convert.ToInt32(ucRateCardBasicInfo.ucTxtStayDuration.Trim());

                                decimal dcmlOriginalTax = Convert.ToDecimal(strDspTax) * mindays;
                                txtTaxes.Text = Convert.ToString(dcmlOriginalTax.ToString().Substring(0, dcmlOriginalTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                            }
                            else
                                txtTaxes.Text = Convert.ToString(0.00);
                        }
                        else
                            txtTaxes.Text = Convert.ToString(0.00);

                        decimal dcDisplayDeposit = 0;
                        decimal dcDisplayRackrate = 0;
                        decimal dcDisplayTaxes = 0;

                        if (txtDeposit.Text.Trim() != "")
                        {
                            string strDeposit = txtDeposit.Text.Trim().IndexOf('.') > -1 ? txtDeposit.Text.Trim() + "000000" : txtDeposit.Text.Trim() + ".000000";
                            dcDisplayDeposit = Convert.ToDecimal(strDeposit);
                        }

                        if (txtTotalRackRate.Text.Trim() != "")
                        {
                            string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                            dcDisplayRackrate = Convert.ToDecimal(strTotalRackRate);
                        }

                        if (txtTaxes.Text.Trim() != "")
                        {
                            string strTaxes = txtTaxes.Text.Trim().IndexOf('.') > -1 ? txtTaxes.Text.Trim() + "000000" : txtTaxes.Text.Trim() + ".000000";
                            dcDisplayTaxes = Convert.ToDecimal(strTaxes);
                        }

                        decimal dcDisplayTotal = Convert.ToDecimal(dcDisplayDeposit + dcDisplayRackrate + dcDisplayTaxes);
                        string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";

                        lblTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        public void CalculateRackRateCharge(string strval)
        {
            try
            {
                if (strval != "")
                {
                    for (int i = 0; i < ucRateCardRoomTypes.gvucRoomTypes.Rows.Count; i++)
                    {
                        CheckBox chkSelect = (CheckBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("chkSelect");

                        if (chkSelect.Checked)
                        {
                            TextBox txtTotalRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTotalRackRate");
                            TextBox txtRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtRackRate");

                            TextBox txtDeposit = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtDeposit");
                            TextBox txtTaxes = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTaxes");
                            Label lblTotal = (Label)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("lblTotal");

                            if (txtTotalRackRate.Text.Trim() != "")
                            {
                                if (Session["MinDaysRequired"] != null)
                                {
                                    decimal days = 0;
                                    string strRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                                    days = Convert.ToDecimal(strRackRate) / Convert.ToDecimal(Convert.ToString(Session["MinDaysRequired"]));
                                    txtRackRate.Text = Convert.ToString(days.ToString().Substring(0, days.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                }
                                else
                                    txtRackRate.Text = "";
                            }
                            else
                                txtRackRate.Text = "";

                            decimal dcDisplayDeposit = 0;
                            decimal dcDisplayRackrate = 0;
                            decimal dcDisplayTaxes = 0;

                            if (txtDeposit.Text.Trim() != "")
                            {
                                string strDeposit = txtDeposit.Text.Trim().IndexOf('.') > -1 ? txtDeposit.Text.Trim() + "000000" : txtDeposit.Text.Trim() + ".000000";
                                dcDisplayDeposit = Convert.ToDecimal(strDeposit);
                            }

                            if (txtTotalRackRate.Text.Trim() != "")
                            {
                                string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                                dcDisplayRackrate = Convert.ToDecimal(strTotalRackRate);
                            }

                            if (txtTaxes.Text.Trim() != "")
                            {
                                string strTaxes = txtTaxes.Text.Trim().IndexOf('.') > -1 ? txtTaxes.Text.Trim() + "000000" : txtTaxes.Text.Trim() + ".000000";
                                dcDisplayTaxes = Convert.ToDecimal(strTaxes);
                            }

                            decimal dcDisplayTotal = Convert.ToDecimal(dcDisplayDeposit + dcDisplayRackrate + dcDisplayTaxes);
                            string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";

                            lblTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ucRateCardRoomTypes.gvucRoomTypes.Rows.Count; i++)
                    {
                        CheckBox chkSelect = (CheckBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("chkSelect");

                        if (chkSelect.Checked)
                        {
                            TextBox txtTotalRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTotalRackRate");
                            TextBox txtRackRate = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtRackRate");

                            TextBox txtDeposit = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtDeposit");
                            TextBox txtTaxes = (TextBox)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("txtTaxes");
                            Label lblTotal = (Label)(ucRateCardRoomTypes.gvucRoomTypes).Rows[i].FindControl("lblTotal");

                            if (txtTotalRackRate.Text.Trim() != "")
                            {
                                if (Session["MinDaysRequired"] != null)
                                {
                                    decimal days = 0;
                                    string strRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                                    days = Convert.ToInt32(strRackRate) / Convert.ToDecimal(Convert.ToString(Session["MinDaysRequired"]));
                                    txtRackRate.Text = Convert.ToString(days.ToString().Substring(0, days.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                }
                                else
                                    txtRackRate.Text = "";
                            }
                            else
                                txtRackRate.Text = "";

                            decimal dcDisplayDeposit = 0;
                            decimal dcDisplayRackrate = 0;
                            decimal dcDisplayTaxes = 0;

                            if (txtDeposit.Text.Trim() != "")
                            {
                                string strDeposit = txtDeposit.Text.Trim().IndexOf('.') > -1 ? txtDeposit.Text.Trim() + "000000" : txtDeposit.Text.Trim() + ".000000";
                                dcDisplayDeposit = Convert.ToDecimal(strDeposit);
                            }

                            if (txtTotalRackRate.Text.Trim() != "")
                            {
                                string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                                dcDisplayRackrate = Convert.ToDecimal(strTotalRackRate);
                            }

                            if (txtTaxes.Text.Trim() != "")
                            {
                                string strTaxes = txtTaxes.Text.Trim().IndexOf('.') > -1 ? txtTaxes.Text.Trim() + "000000" : txtTaxes.Text.Trim() + ".000000";
                                dcDisplayTaxes = Convert.ToDecimal(strTaxes);
                            }

                            decimal dcDisplayTotal = Convert.ToDecimal(dcDisplayDeposit + dcDisplayRackrate + dcDisplayTaxes);
                            string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";

                            lblTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void BindSpecialDaysRoomType()
        {
            try
            {
                txtSpecialDaysTitle.Text = txtSpecialDaysDate.Text = "";
                this.OldDate = string.Empty;

                RoomType Rm = new RoomType();
                Rm.PropertyID = clsSession.PropertyID;
                Rm.IsActive = true;

                string strQuery = "select RoomTypeID,RoomTypeName,'' as EventDate from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName";

                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strQuery);

                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    gvSpecialDays.DataSource = dsRoomType.Tables[0];
                    gvSpecialDays.DataBind();
                }
                else
                {
                    gvSpecialDays.DataSource = null;
                    gvSpecialDays.DataBind();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
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
                    //objToCheckDuplicate.RateCardName = ucRateCardBasicInfo.ucTxtRateCardName.Trim();
                    objToCheckDuplicate.RateCardDispName = ucRateCardBasicInfo.ucTxtRateCardDispName.Trim();

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

                        objToUpdate.AcctID = new Guid("AC77361D-6E87-4A59-8866-F479299B4A8A");
                        if (ucRateCardBasicInfo.ddlucStayType.SelectedIndex != 0)
                            objToUpdate.StayTypeID = new Guid(ucRateCardBasicInfo.ddlucStayType.SelectedValue.ToString());
                        else
                            objToUpdate.StayTypeID = null;

                        objToUpdate.Code = ucRateCardBasicInfo.ucTxtRateCardCode;
                        objToUpdate.RateCardName = ucRateCardBasicInfo.ucTxtRateCardName;
                        objToUpdate.RateCardDispName = ucRateCardBasicInfo.ucTxtRateCardDispName;

                        if (ucRateCardBasicInfo.ucChkIsPerRoom)
                            objToUpdate.IsPerRoom = true;
                        else
                            objToUpdate.IsPerRoom = false;

                        if (ucRateCardBasicInfo.ucTxtRetentionCharge != string.Empty)
                            objToUpdate.RetentionChargePercent = Convert.ToInt32(ucRateCardBasicInfo.ucTxtRetentionCharge);

                        if (ucRateCardBasicInfo.ucTxtStayDuration != string.Empty)
                            objToUpdate.MinimumDaysRequired = Convert.ToInt32(ucRateCardBasicInfo.ucTxtStayDuration);
                        else
                            objToUpdate.MinimumDaysRequired = null;

                        if (ucRateCardBasicInfo.ucTxtDateFrom != string.Empty)
                            objToUpdate.StartDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateFrom.Trim(), clsSession.DateFormat, objCultureInfo);
                        else
                            objToUpdate.StartDate = null;

                        if (ucRateCardBasicInfo.ucTxtDateTo != string.Empty)
                            objToUpdate.EndDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateTo.Trim(), clsSession.DateFormat, objCultureInfo);
                        else
                            objToUpdate.EndDate = null;

                        if (ucRateCardBasicInfo.ucTxtAllowedChild != string.Empty)
                            objToUpdate.NonRevenueChildren = Convert.ToInt32(ucRateCardBasicInfo.ucTxtAllowedChild);
                        else
                            objToUpdate.NonRevenueChildren = null;

                        if (ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex != 0)
                            objToUpdate.PostingFreq_TermID = new Guid(ucRateCardBasicInfo.ddlucPostingFrequency.SelectedValue.ToString());
                        else
                            objToUpdate.PostingFreq_TermID = null;

                        objToUpdate.IsEnable = true;//ucRateCardBasicInfo.ucChkIsEnable;
                        objToUpdate.IsStandard = true; //Convert.ToBoolean(ucRateCardBasicInfo.ucChkIsStandardRateCard);

                        if (ucRateCardBasicInfo.ddlucCancellationPolicy.SelectedIndex != 0)
                            objToUpdate.CancellationPolicyID = new Guid(ucRateCardBasicInfo.ddlucCancellationPolicy.SelectedValue.ToString());
                        else
                            objToUpdate.PostingFreq_TermID = null;

                        //objToUpdate.RateCardDetails = ucTermsAndConditions.ucTxtDetails;
                        //objToUpdate.TermsAndCondition = ucTermsAndConditions.ucTxtTermsAndConditions;

                        objToUpdate.IsCheckInMonday = objToUpdate.IsCheckInTuesday = objToUpdate.IsCheckInWednesday =  objToUpdate.IsCheckInThursday = objToUpdate.IsCheckInFriday = false;
                        objToUpdate.IsCheckInSaturday = objToUpdate.IsCheckInSunday = false;

                        //for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
                        //{
                        //    if (ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected)
                        //    {
                        //        switch (ucRateCardCheckInDays.ucChkLstDays.Items[i].Value.ToUpper())
                        //        {
                        //            case "MONDAY":
                        //                objToUpdate.IsCheckInMonday = true; break;
                        //            case "TUESDAY":
                        //                objToUpdate.IsCheckInTuesday = true; break;
                        //            case "WEDNESDAY":
                        //                objToUpdate.IsCheckInWednesday = true; break;
                        //            case "THURSDAY":
                        //                objToUpdate.IsCheckInThursday = true; break;
                        //            case "FRIDAY":
                        //                objToUpdate.IsCheckInFriday = true; break;
                        //            case "SATURDAY":
                        //                objToUpdate.IsCheckInSaturday = true; break;
                        //            case "SUNDAY":
                        //                objToUpdate.IsCheckInSunday = true; break;
                        //        }
                        //    }
                        //}

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
                        for (int i = 0; i < ucRateCardRoomTypes.gvucRoomTypes.Rows.Count; i++)
                        {
                            if (((CheckBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                TextBox txtDeposit = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtDeposit");
                                TextBox txtRackRate = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtRackRate");
                                TextBox txtTotalRackRate = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtTotalRackRate");
                                TextBox txtExtraBedCharge = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtExtraBedCharge");
                                //TextBox txtExtraAdult = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtExtraAdult");
                                //TextBox txtExtraChild = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtExtraChild");
                                TextBox txtMonday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtMonday");
                                TextBox txtTuesday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtTuesday");
                                TextBox txtWednesday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtWednesday");
                                TextBox txtThursday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtThursday");
                                TextBox txtFriday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtFriday");
                                TextBox txtSaturday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtSaturday");
                                TextBox txtSunday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtSunday");

                                RateCardDetails objToAdd = new RateCardDetails();
                                objToAdd.IsActive = true;
                                objToAdd.RoomTypeID = new Guid(Convert.ToString(ucRateCardRoomTypes.gvucRoomTypes.DataKeys[i]["RoomTypeID"]));

                                if (txtRackRate != null && txtRackRate.Text.Trim() != string.Empty)
                                    objToAdd.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());
                                else
                                    objToAdd.RackRate = null;

                                if (txtDeposit != null && txtDeposit.Text.Trim() != string.Empty)
                                    objToAdd.DepositAmount = Convert.ToDecimal(txtDeposit.Text.Trim());

                                if (txtTotalRackRate != null && txtTotalRackRate.Text.Trim() != string.Empty)
                                    objToAdd.TotalRackRate = Convert.ToDecimal(txtTotalRackRate.Text.Trim());

                                if (txtExtraBedCharge != null && txtExtraBedCharge.Text.Trim() != string.Empty)
                                    objToAdd.ExtarbedCharge = Convert.ToDecimal(txtExtraBedCharge.Text.Trim());

                                //if (txtExtraAdult != null && txtExtraAdult.Text.Trim() != string.Empty)
                                //    objToAdd.ExtraAdultRate = Convert.ToDecimal(txtExtraAdult.Text.Trim());
                                //else
                                //    objToAdd.ExtraAdultRate = null;

                                //if (txtExtraChild != null && txtExtraChild.Text.Trim() != string.Empty)
                                //    objToAdd.ChildRate = Convert.ToDecimal(txtExtraChild.Text.Trim());
                                //else
                                //    objToAdd.ChildRate = null;

                                if (txtMonday != null && txtMonday.Text.Trim() != string.Empty)
                                    objToAdd.MondayRate = Convert.ToDecimal(txtMonday.Text.Trim());
                                else
                                    objToAdd.MondayRate = null;

                                if (txtTuesday != null && txtTuesday.Text.Trim() != string.Empty)
                                    objToAdd.TuesdayRate = Convert.ToDecimal(txtTuesday.Text.Trim());
                                else
                                    objToAdd.TuesdayRate = null;

                                if (txtWednesday != null && txtWednesday.Text.Trim() != string.Empty)
                                    objToAdd.WednesdayRate = Convert.ToDecimal(txtWednesday.Text.Trim());
                                else
                                    objToAdd.WednesdayRate = null;

                                if (txtThursday != null && txtThursday.Text.Trim() != string.Empty)
                                    objToAdd.ThursdayRate = Convert.ToDecimal(txtThursday.Text.Trim());
                                else
                                    objToAdd.ThursdayRate = null;

                                if (txtFriday != null && txtFriday.Text.Trim() != string.Empty)
                                    objToAdd.FridayRate = Convert.ToDecimal(txtFriday.Text.Trim());
                                else
                                    objToAdd.FridayRate = null;

                                if (txtSaturday != null && txtSaturday.Text.Trim() != string.Empty)
                                    objToAdd.SaturdayRate = Convert.ToDecimal(txtSaturday.Text.Trim());
                                else
                                    objToAdd.SaturdayRate = null;

                                if (txtSunday != null && txtSunday.Text.Trim() != string.Empty)
                                    objToAdd.SundayRate = Convert.ToDecimal(txtSunday.Text.Trim());
                                else
                                    objToAdd.SundayRate = null;

                                lstRateCardDetails.Add(objToAdd);
                            }
                        }

                        List<CorporateRates> lstCorporateRates = new List<CorporateRates>();
                        for (int i = 0; i < ucRateCardCorporates.gvucCorporates.Rows.Count; i++)
                        {
                            if (((CheckBox)ucRateCardCorporates.gvucCorporates.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                CheckBox chkIsDefault = (CheckBox)ucRateCardCorporates.gvucCorporates.Rows[i].FindControl("chkIsDefault");

                                CorporateRates objToAdd = new CorporateRates();
                                objToAdd.IsActive = true;
                                objToAdd.CorporateID = new Guid(Convert.ToString(ucRateCardCorporates.gvucCorporates.DataKeys[i]["CorporateID"]));
                                objToAdd.IsDefaultThis = chkIsDefault.Checked;

                                lstCorporateRates.Add(objToAdd);
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

                        //Object to get CorporateRates from DB.
                        CorporateRates objToGetCorporateRatesList = new CorporateRates();
                        objToGetCorporateRatesList.RateID = this.RateCardID;
                        objToGetCorporateRatesList.IsActive = true;
                        List<CorporateRates> lstCorporateRatesFromDB = CorporateRatesBLL.GetAll(objToGetCorporateRatesList);

                        DataTable dtInsertData = new DataTable();
                        if (Session["ComplimentoryServices"] != null)
                        {
                            dtInsertData = (DataTable)Session["ComplimentoryServices"];
                        }

                        DataTable dtInsertSpecialDays = new DataTable();
                        if (Session["SpecialDays"] != null)
                        {
                            dtInsertSpecialDays = (DataTable)Session["SpecialDays"];
                        }

                        RateCardBLL.UpdateRateCard(objToUpdate, lstRateTaxes, lstTaxesFromDB, lstRateCardDetails, lstRateCardDetailsFromDB, lstCorporateRates, lstCorporateRatesFromDB, clsSession.UserID, "ROOM", dtInsertData, null);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldToUpdate.ToString(), objToUpdate.ToString(), "mst_RateCard");
                        litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        IsListMessage = true;

                        /////***********  Update  ************//////////
                    }
                    else
                    {
                        //Insert Mode
                        RateCard objToInsert = new RateCard();

                        objToInsert.AcctID = new Guid("AC77361D-6E87-4A59-8866-F479299B4A8A");
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.IsActive = true;
                        objToInsert.IsDefault = objToInsert.IsEventChargeEnable = objToInsert.IsRateInclService = objToInsert.IsYieldEnable = false;
                        objToInsert.RateTypeName = "CORPORATE";

                        if (ucRateCardBasicInfo.ucTxtStayDuration != string.Empty)
                            objToInsert.MinimumDaysRequired = Convert.ToInt32(ucRateCardBasicInfo.ucTxtStayDuration);

                        if (ucRateCardBasicInfo.ddlucStayType.SelectedIndex != 0)
                            objToInsert.StayTypeID = new Guid(ucRateCardBasicInfo.ddlucStayType.SelectedValue.ToString());

                        objToInsert.Code = ucRateCardBasicInfo.ucTxtRateCardCode;
                        objToInsert.RateCardName = ucRateCardBasicInfo.ucTxtRateCardName;
                        objToInsert.RateCardDispName = ucRateCardBasicInfo.ucTxtRateCardDispName;
                        if (ucRateCardBasicInfo.ucChkIsPerRoom)
                            objToInsert.IsPerRoom = true;
                        else
                            objToInsert.IsPerRoom = false;

                        if (ucRateCardBasicInfo.ucTxtRetentionCharge != string.Empty)
                            objToInsert.RetentionChargePercent = Convert.ToInt32(ucRateCardBasicInfo.ucTxtRetentionCharge);

                        if (ucRateCardBasicInfo.ucTxtDateFrom != string.Empty)
                            objToInsert.StartDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateFrom.Trim(), clsSession.DateFormat, objCultureInfo);

                        if (ucRateCardBasicInfo.ucTxtDateTo != string.Empty)
                            objToInsert.EndDate = DateTime.ParseExact(ucRateCardBasicInfo.ucTxtDateTo.Trim(), clsSession.DateFormat, objCultureInfo);

                        if (ucRateCardBasicInfo.ucTxtAllowedChild != string.Empty)
                            objToInsert.NonRevenueChildren = Convert.ToInt32(ucRateCardBasicInfo.ucTxtAllowedChild);

                        if (ucRateCardBasicInfo.ddlucPostingFrequency.SelectedIndex != 0)
                            objToInsert.PostingFreq_TermID = new Guid(ucRateCardBasicInfo.ddlucPostingFrequency.SelectedValue.ToString());

                        objToInsert.IsEnable = true;//ucRateCardBasicInfo.ucChkIsEnable;
                        objToInsert.IsStandard = true;//Convert.ToBoolean(ucRateCardBasicInfo.ucChkIsStandardRateCard);

                        //objToInsert.RateCardDetails = ucTermsAndConditions.ucTxtDetails;
                        //objToInsert.TermsAndCondition = ucTermsAndConditions.ucTxtTermsAndConditions;

                        if (ucRateCardBasicInfo.ddlucCancellationPolicy.SelectedIndex != 0)
                            objToInsert.CancellationPolicyID = new Guid(ucRateCardBasicInfo.ddlucCancellationPolicy.SelectedValue.ToString());
                        else
                            objToInsert.PostingFreq_TermID = null;

                        //for (int i = 0; i < ucRateCardCheckInDays.ucChkLstDays.Items.Count; i++)
                        //{
                        //    if (ucRateCardCheckInDays.ucChkLstDays.Items[i].Selected)
                        //    {
                        //        switch (ucRateCardCheckInDays.ucChkLstDays.Items[i].Value.ToUpper())
                        //        {
                        //            case "MONDAY":
                        //                objToInsert.IsCheckInMonday = true; break;
                        //            case "TUESDAY":
                        //                objToInsert.IsCheckInTuesday = true; break;
                        //            case "WEDNESDAY":
                        //                objToInsert.IsCheckInWednesday = true; break;
                        //            case "THURSDAY":
                        //                objToInsert.IsCheckInThursday = true; break;
                        //            case "FRIDAY":
                        //                objToInsert.IsCheckInFriday = true; break;
                        //            case "SATURDAY":
                        //                objToInsert.IsCheckInSaturday = true; break;
                        //            case "SUNDAY":
                        //                objToInsert.IsCheckInSunday = true; break;
                        //        }
                        //    }
                        //}

                        objToInsert.IsCheckInMonday = objToInsert.IsCheckInTuesday = objToInsert.IsCheckInWednesday = objToInsert.IsCheckInThursday = objToInsert.IsCheckInFriday = objToInsert.IsCheckInSaturday = objToInsert.IsCheckInSunday = true;

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
                        for (int i = 0; i < ucRateCardRoomTypes.gvucRoomTypes.Rows.Count; i++)
                        {
                            if (((CheckBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                TextBox txtRackRate = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtRackRate");
                                TextBox txtDeposit = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtDeposit");
                                TextBox txtTotalRackRate = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtTotalRackRate");
                                TextBox txtExtraBedCharge = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtExtraBedCharge");
                                //TextBox txtExtraAdult = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtExtraAdult");
                                //TextBox txtExtraChild = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtExtraChild");
                                TextBox txtMonday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtMonday");
                                TextBox txtTuesday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtTuesday");
                                TextBox txtWednesday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtWednesday");
                                TextBox txtThursday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtThursday");
                                TextBox txtFriday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtFriday");
                                TextBox txtSaturday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtSaturday");
                                TextBox txtSunday = (TextBox)ucRateCardRoomTypes.gvucRoomTypes.Rows[i].FindControl("txtSunday");

                                RateCardDetails objToAdd = new RateCardDetails();
                                objToAdd.IsActive = true;
                                objToAdd.RoomTypeID = new Guid(Convert.ToString(ucRateCardRoomTypes.gvucRoomTypes.DataKeys[i]["RoomTypeID"]));

                                if (txtRackRate != null && txtRackRate.Text.Trim() != string.Empty)
                                    objToAdd.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());

                                //if (txtExtraAdult != null && txtExtraAdult.Text.Trim() != string.Empty)
                                //    objToAdd.ExtraAdultRate = Convert.ToDecimal(txtExtraAdult.Text.Trim());

                                //if (txtExtraChild != null && txtExtraChild.Text.Trim() != string.Empty)
                                //    objToAdd.ChildRate = Convert.ToDecimal(txtExtraChild.Text.Trim());

                                if (txtDeposit != null && txtDeposit.Text.Trim() != string.Empty)
                                    objToAdd.DepositAmount = Convert.ToDecimal(txtDeposit.Text.Trim());

                                if (txtTotalRackRate != null && txtTotalRackRate.Text.Trim() != string.Empty)
                                    objToAdd.TotalRackRate = Convert.ToDecimal(txtTotalRackRate.Text.Trim());

                                if (txtExtraBedCharge != null && txtExtraBedCharge.Text.Trim() != string.Empty)
                                    objToAdd.ExtarbedCharge = Convert.ToDecimal(txtExtraBedCharge.Text.Trim());

                                if (txtMonday != null && txtMonday.Text.Trim() != string.Empty)
                                    objToAdd.MondayRate = Convert.ToDecimal(txtMonday.Text.Trim());

                                if (txtTuesday != null && txtTuesday.Text.Trim() != string.Empty)
                                    objToAdd.TuesdayRate = Convert.ToDecimal(txtTuesday.Text.Trim());

                                if (txtWednesday != null && txtWednesday.Text.Trim() != string.Empty)
                                    objToAdd.WednesdayRate = Convert.ToDecimal(txtWednesday.Text.Trim());

                                if (txtThursday != null && txtThursday.Text.Trim() != string.Empty)
                                    objToAdd.ThursdayRate = Convert.ToDecimal(txtThursday.Text.Trim());

                                if (txtFriday != null && txtFriday.Text.Trim() != string.Empty)
                                    objToAdd.FridayRate = Convert.ToDecimal(txtFriday.Text.Trim());

                                if (txtSaturday != null && txtSaturday.Text.Trim() != string.Empty)
                                    objToAdd.SaturdayRate = Convert.ToDecimal(txtSaturday.Text.Trim());

                                if (txtSunday != null && txtSunday.Text.Trim() != string.Empty)
                                    objToAdd.SundayRate = Convert.ToDecimal(txtSunday.Text.Trim());

                                lstRateCardDetails.Add(objToAdd);
                            }
                        }

                        List<CorporateRates> lstCorporateRates = new List<CorporateRates>();
                        for (int i = 0; i < ucRateCardCorporates.gvucCorporates.Rows.Count; i++)
                        {
                            if (((CheckBox)ucRateCardCorporates.gvucCorporates.Rows[i].FindControl("chkSelect")).Checked)
                            {
                                CheckBox chkIsDefault = (CheckBox)ucRateCardCorporates.gvucCorporates.Rows[i].FindControl("chkIsDefault");

                                CorporateRates objToAdd = new CorporateRates();
                                objToAdd.IsActive = true;
                                objToAdd.CorporateID = new Guid(Convert.ToString(ucRateCardCorporates.gvucCorporates.DataKeys[i]["CorporateID"]));
                                objToAdd.IsDefaultThis = chkIsDefault.Checked;

                                lstCorporateRates.Add(objToAdd);
                            }
                        }


                        DataTable dtInsertData = new DataTable();
                        if (Session["ComplimentoryServices"] != null)
                        {
                            dtInsertData = (DataTable)Session["ComplimentoryServices"];
                        }

                        DataTable dtInsertSpecialDays = new DataTable();
                        if (Session["SpecialDays"] != null)
                        {
                            dtInsertSpecialDays = (DataTable)Session["SpecialDays"];
                        }


                        RateCardBLL.SaveRateCard(objToInsert, lstRateTaxes, lstRateServiceJoin, lstRateCardDetails, lstCorporateRates, dtInsertData, dtInsertSpecialDays);
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
                    MessageBox.Show(Convert.ToString(ex.ToString()));
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
            Session["ComplimentoryServices"] = Session["TaxList"] = Session["MinDaysRequired"] = Session["SpecialDays"] = null;
            Response.Redirect("~/GUI/PriceManager/RateCardList.aspx");
        }

        protected void lnkCalculateTax_Click(object sender, EventArgs e)
        {
            Session["TaxList"] = null;
            SessionTaxList();
            //old Method for tax calculation
            ////CalculateRate();

            //New method for tax calculation
            CalculateTaxRate_New();
        }

        protected void btnAddSpecialDays_Click(object sender, EventArgs e)
        {
            try
            {
                BindSpecialDaysRoomType();
                mpeAddEditSpecialDays.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnSaveSpecialDays_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                mpeAddEditSpecialDays.Show();
                if (this.Page.IsValid)
                {
                    DataTable dtSpecialDays = new DataTable();

                    DataColumn dc1 = new DataColumn("EventName");
                    DataColumn dc2 = new DataColumn("EventDate");
                    DataColumn dc3 = new DataColumn("IsFlat");
                    DataColumn dc4 = new DataColumn("Rate");
                    DataColumn dc5 = new DataColumn("RoomTypeID");

                    dtSpecialDays.Columns.Add(dc1);
                    dtSpecialDays.Columns.Add(dc2);
                    dtSpecialDays.Columns.Add(dc3);
                    dtSpecialDays.Columns.Add(dc4);
                    dtSpecialDays.Columns.Add(dc5);

                    if (Session["SpecialDays"] != null)
                    {
                        dtSpecialDays = (DataTable)Session["SpecialDays"];

                        if (this.OldDate != string.Empty)
                        {
                            DataRow[] drDelete = dtSpecialDays.Select("EventDate = '" + Convert.ToString(this.OldDate) + "'");

                            foreach (DataRow dr in drDelete)
                            {
                                dtSpecialDays.Rows.Remove(dr);
                            }

                            dtSpecialDays.AcceptChanges();

                            if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATERATECARD")
                            {
                                CalenderEventBLL.DeleteDataByDateAndRateID(clsSession.PropertyID, this.RateCardID, Convert.ToDateTime(this.OldDate));
                            }

                            ////string _filterName_needed = Convert.ToString(this.OldDate);
                            ////object obj = dtSpecialDays.Select("EventDate=' " + _filterName_needed + " ' ");
                            ////DataRow drr = dtSpecialDays.Rows.Find(obj);
                            ////if (drr != null)
                            ////{
                            ////    drr.Delete();
                            ////}
                        }
                        else
                        {
                            string strDate = Convert.ToString(DateTime.ParseExact(txtSpecialDaysDate.Text.Trim(), clsSession.DateFormat, objCultureInfo));

                            DataRow[] drDelete = dtSpecialDays.Select("EventDate = '" + strDate + "'");

                            if (drDelete.Length > 0)
                            {
                                foreach (DataRow dr in drDelete)
                                {
                                    dtSpecialDays.Rows.Remove(dr);
                                }

                                dtSpecialDays.AcceptChanges();

                                if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATERATECARD")
                                {
                                    CalenderEventBLL.DeleteDataByDateAndRateID(clsSession.PropertyID, this.RateCardID, Convert.ToDateTime(this.OldDate));
                                }
                            }
                        }
                    }

                    for (int i = 0; i < gvSpecialDays.Rows.Count; i++)
                    {
                        TextBox txtDiscountCharges = (TextBox)gvSpecialDays.Rows[i].FindControl("txtDiscountCharges");
                        DropDownList ddlDiscountType = (DropDownList)gvSpecialDays.Rows[i].FindControl("ddlDiscountType");

                        bool strIsFlat = false;
                        if (ddlDiscountType.SelectedIndex == 0)
                            strIsFlat = true;
                        else
                            strIsFlat = false;

                        DataRow dr = dtSpecialDays.NewRow();

                        dr["EventName"] = Convert.ToString(txtSpecialDaysTitle.Text.Trim());
                        DateTime dtDate = DateTime.ParseExact(txtSpecialDaysDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        //dr["EventDate"] = Convert.ToString(dtDate.ToString(clsSession.DateFormat));
                        dr["EventDate"] = Convert.ToString(dtDate);
                        dr["IsFlat"] = Convert.ToBoolean(strIsFlat);
                        string strInsertRate = txtDiscountCharges.Text.Trim().IndexOf('.') > -1 ? txtDiscountCharges.Text.Trim() + "000000" : txtDiscountCharges.Text.Trim() + ".000000";
                        dr["Rate"] = Convert.ToString(strInsertRate);
                        dr["RoomTypeID"] = Convert.ToString(gvSpecialDays.DataKeys[i]["RoomTypeID"]);

                        dtSpecialDays.Rows.Add(dr);

                        if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATERATECARD")
                        {
                            CalenderEvent objSaveCalenderEvent = new CalenderEvent();

                            objSaveCalenderEvent.EventID = Guid.NewGuid();
                            objSaveCalenderEvent.PropertyID = clsSession.PropertyID;
                            objSaveCalenderEvent.EventDate = dtDate;
                            objSaveCalenderEvent.EventName = Convert.ToString(txtSpecialDaysTitle.Text.Trim());
                            objSaveCalenderEvent.Rate = Convert.ToDecimal(txtDiscountCharges.Text.Trim());
                            objSaveCalenderEvent.IsFlat = strIsFlat;
                            objSaveCalenderEvent.IsActive = true;
                            objSaveCalenderEvent.RateID = this.RateCardID;
                            objSaveCalenderEvent.RoomTypeID = new Guid(Convert.ToString(gvSpecialDays.DataKeys[i]["RoomTypeID"]));

                            CalenderEventBLL.Save(objSaveCalenderEvent);
                        }

                    }

                    Session["SpecialDays"] = dtSpecialDays;

                    if (dtSpecialDays.Rows.Count > 0)
                    {
                        DataTable dtBindData = new DataTable();

                        DataView dView = new DataView(dtSpecialDays);
                        string[] arrColumns = { "EventName", "EventDate" };
                        dtBindData = dView.ToTable(true, arrColumns);

                        //dttest = dtSpecialDays.DefaultView.ToTable(true, "EventName");

                        //dtSpecialDays.DefaultView.ToTable(true, "EventName");
                        gvDispalySpecialDays.DataSource = dtBindData;
                        gvDispalySpecialDays.DataBind();
                    }
                    else
                    {
                        gvDispalySpecialDays.DataSource = null;
                        gvDispalySpecialDays.DataBind();
                    }

                    mpeAddEditSpecialDays.Hide();

                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        #endregion

        #region Dropdown Event

        protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mpeAddEditSpecialDays.Show();

                GridViewRow row = ((GridViewRow)((DropDownList)sender).NamingContainer);
                DropDownList ddlDiscountType = (DropDownList)row.FindControl("ddlDiscountType");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        #endregion Dropdown Event

        #region Grid Event

        protected void gvSpecialDays_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DropDownList ddlDiscountType = (DropDownList)e.Row.FindControl("ddlDiscountType");

                    ddlDiscountType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));
                    ddlDiscountType.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));

                    ////RangeValidator rngvDiscountCharges = (RangeValidator)e.Row.FindControl("rngvDiscountCharges");

                    ////if (ddlDiscountType.SelectedIndex == 0)
                    ////{
                    ////    ////rngvDiscountCharges.MinimumValue = "-100";
                    ////    ////rngvDiscountCharges.MaximumValue = "100";
                    ////}
                    ////else
                    ////{
                    ////    ////rngvDiscountCharges.MinimumValue = "-999999999999999999";
                    ////    ////rngvDiscountCharges.MaximumValue = "999999999999999999";// 18 chars
                    ////}
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
        }

        protected void gvDispalySpecialDays_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    if (Session["SpecialDays"] != null)
                    {
                        BindSpecialDaysRoomType();

                        this.OldDate = Convert.ToString(e.CommandArgument);

                        DataTable dtEditData = new DataTable();
                        dtEditData = (DataTable)Session["SpecialDays"];

                        DataRow[] drdata = dtEditData.Select("EventDate = '" + Convert.ToString(this.OldDate) + "'");
                        if (drdata.Length > 0)
                        {
                            txtSpecialDaysTitle.Text = Convert.ToString(drdata[0]["EventName"]);
                            DateTime dtEventDate = Convert.ToDateTime(Convert.ToString(drdata[0]["EventDate"]));
                            txtSpecialDaysDate.Text = Convert.ToString(dtEventDate.ToString(clsSession.DateFormat));
                        }
                        else
                            txtSpecialDaysTitle.Text = txtSpecialDaysDate.Text = "";

                        for (int i = 0; i < gvSpecialDays.Rows.Count; i++)
                        {
                            //DateTime dtEditDate = Convert.ToDateTime(Convert.ToString(e.CommandArgument));

                            DataRow[] dr = dtEditData.Select("RoomTypeID = '" + Convert.ToString(gvSpecialDays.DataKeys[i]["RoomTypeID"]) + "' and EventDate = '" + Convert.ToString(this.OldDate) + "'");
                            if (dr.Length > 0)
                            {
                                DropDownList ddlDiscountType = (DropDownList)gvSpecialDays.Rows[i].FindControl("ddlDiscountType");
                                TextBox txtDiscountCharges = (TextBox)gvSpecialDays.Rows[i].FindControl("txtDiscountCharges");
                                ////RangeValidator rngvDiscountCharges = (RangeValidator)gvDispalySpecialDays.Rows[i].FindControl("rngvDiscountCharges");

                                bool strFlat = Convert.ToBoolean(dr[0]["IsFlat"]);
                                decimal dcRate = 0;

                                if (strFlat == false)
                                {
                                    ddlDiscountType.SelectedIndex = 1;
                                    ////rngvDiscountCharges.MinimumValue = "-100";
                                    ////rngvDiscountCharges.MaximumValue = "100";
                                }
                                else
                                {
                                    ddlDiscountType.SelectedIndex = 0;
                                    ////rngvDiscountCharges.MinimumValue = "-999999999999999999";
                                    ////rngvDiscountCharges.MaximumValue = "999999999999999999";// 18 chars                                    
                                }

                                if (Convert.ToString(dr[0]["Rate"]) != "" && dr[0]["Rate"] != null)
                                    dcRate = Convert.ToDecimal(dr[0]["Rate"]);

                                if (Convert.ToString(dcRate) != "")
                                {
                                    txtDiscountCharges.Text = dcRate.ToString().Substring(0, dcRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                }
                                else
                                    txtDiscountCharges.Text = "0.00";
                            }
                        }

                        mpeAddEditSpecialDays.Show();
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    if (Session["SpecialDays"] != null)
                    {
                        DataTable dtDeleteData = (DataTable)Session["SpecialDays"];

                        DataRow[] drDelete = dtDeleteData.Select("EventDate = '" + Convert.ToString(e.CommandArgument) + "'");

                        foreach (DataRow dr in drDelete)
                        {
                            dtDeleteData.Rows.Remove(dr);
                        }

                        dtDeleteData.AcceptChanges();

                        DataTable dtData = new DataTable();

                        DataView dv = new DataView(dtDeleteData);
                        string[] arrColumns = { "EventName", "EventDate" };
                        dtData = dv.ToTable(true, arrColumns);

                        gvDispalySpecialDays.DataSource = dtData;
                        gvDispalySpecialDays.DataBind();
                    }

                    if (clsSession.ToEditItemType != string.Empty && clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType.ToUpper() == "CORPORATERATECARD")
                    {
                        CalenderEventBLL.DeleteDataByDateAndRateID(clsSession.PropertyID, this.RateCardID, Convert.ToDateTime(Convert.ToString(e.CommandArgument)));
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        #endregion Grid Event
    }
}