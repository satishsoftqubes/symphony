using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRoomReservationList : System.Web.UI.UserControl
    {
        #region Property and Variables
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
        public bool IsCancelationProcess
        {
            get
            {
                return ViewState["IsCancelationProcess"] != null ? Convert.ToBoolean(ViewState["IsCancelationProcess"]) : false;
            }
            set
            {
                ViewState["IsCancelationProcess"] = value;
            }
        }

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public int SymphonyValue
        {
            get
            {
                return ViewState["SymphonyValue"] != null ? Convert.ToInt32(ViewState["SymphonyValue"]) : 0;
            }
            set
            {
                ViewState["SymphonyValue"] = value;
            }
        }

        public int RowIndex
        {
            get
            {
                return ViewState["RowIndex"] != null ? Convert.ToInt32(ViewState["RowIndex"]) : 0;
            }
            set
            {
                ViewState["RowIndex"] = value;
            }
        }

        public string strIsValidate
        {
            get
            {
                return ViewState["strIsValidate"] != null ? Convert.ToString(ViewState["strIsValidate"]) : string.Empty;
            }
            set
            {
                ViewState["strIsValidate"] = value;
            }
        }

        public string strOpenModalDialog
        {
            get
            {
                return ViewState["strOpenModalDialog"] != null ? Convert.ToString(ViewState["strOpenModalDialog"]) : string.Empty;
            }
            set
            {
                ViewState["strOpenModalDialog"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();


                mvRoomReservation.ActiveViewIndex = 0;
                LoadDefaultValue();
            }
        }

        #endregion

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RoomReservationList.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            // btnAddBottomEmployee.Visible = btnAddTopEmployee.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        protected void LoadDefaultValue()
        {
            try
            {
                //BindMonth();
                BindBookingStatus();
                BindRoomType();
                BindBillingInstruction();
                BindReservationGrid();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindReservationGrid()
        {
            try
            { 
                Guid? RoomTypeID = null;
                Guid? BillingInstructionID = null;
                string strName = null;
                string strMobileNo = null;
                string strReservationNo = null;
                string strCompanyName = null;
                int? status = null;

                if (txtSearchName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchName.Text.Trim());

                if (txtMobileNo.Text.Trim() != "")
                    strMobileNo = Convert.ToString(txtMobileNo.Text.Trim());

                if (txtSearcReservationNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearcReservationNo.Text.Trim());

                if (ddlSrchRoomType.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlSrchRoomType.SelectedValue);

                //if (txtSearchCompanyName.Text.Trim() != "")
                //    strCompanyName = Convert.ToString(txtSearchCompanyName.Text.Trim());

                if (ddlSearchStatus.SelectedIndex != 0)
                    status = Convert.ToInt32(ddlSearchStatus.SelectedValue);
                if (ddlbillinginstruction.SelectedIndex != 0)
                    BillingInstructionID = new Guid(ddlbillinginstruction.SelectedValue);
                DataSet dsReservationList = ReservationBLL.GetResrvationList(null, RoomTypeID, strName, strMobileNo,  strReservationNo, clsSession.PropertyID, clsSession.CompanyID, strCompanyName, status, BillingInstructionID);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvRoomReservationList.DataSource = dsReservationList.Tables[0];
                    gvRoomReservationList.DataBind();

                    if (dsReservationList.Tables[1] != null && dsReservationList.Tables[1].Rows.Count > 0)
                        hdnNoOfAmendmentCriteria.Value = Convert.ToString(dsReservationList.Tables[1].Rows[0]["NoOfAmendmentCriteria"]);
                    else
                        hdnNoOfAmendmentCriteria.Value = "";
                }
                else
                {
                    gvRoomReservationList.DataSource = null;
                    gvRoomReservationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGridAmendment(Guid? ReservationIDForAmend)
        {
            //DataTable dtTable = new DataTable();

            //DataColumn dc2 = new DataColumn("ReservationNo");
            //DataColumn dc3 = new DataColumn("GuestName");
            //DataColumn dc4 = new DataColumn("Company");
            //DataColumn dc5 = new DataColumn("RateCardType");
            //DataColumn dc6 = new DataColumn("RoomType");
            //DataColumn dc7 = new DataColumn("RoomNo");
            //DataColumn dc8 = new DataColumn("CheckIn");
            //DataColumn dc9 = new DataColumn("CheckOut");
            //DataColumn dc10 = new DataColumn("AmendmentBy");
            //DataColumn dc11 = new DataColumn("AmendmentDate");

            //dtTable.Columns.Add(dc2);
            //dtTable.Columns.Add(dc3);
            //dtTable.Columns.Add(dc4);
            //dtTable.Columns.Add(dc5);
            //dtTable.Columns.Add(dc6);
            //dtTable.Columns.Add(dc7);
            //dtTable.Columns.Add(dc8);
            //dtTable.Columns.Add(dc9);
            //dtTable.Columns.Add(dc10);
            //dtTable.Columns.Add(dc11);

            //DataRow dr1 = dtTable.NewRow();
            //dr1["ReservationNo"] = "123456";
            //dr1["GuestName"] = "Mr. Jayesh Patel";
            //dr1["Company"] = "AbcInfo.";
            //dr1["RateCardType"] = "Room RateCard";
            //dr1["RoomType"] = "Standard";
            //dr1["RoomNo"] = "A1-013";
            //dr1["CheckIn"] = "10-08-2012";
            //dr1["CheckOut"] = "12-08-2012";
            //dr1["AmendmentBy"] = "Mr. Rajan Patel";
            //dr1["AmendmentDate"] = "11-08-2012";

            //dtTable.Rows.Add(dr1);

            //DataRow dr2 = dtTable.NewRow();
            //dr2["ReservationNo"] = "123456";
            //dr2["GuestName"] = "Mr. Jayesh Patel";
            //dr2["Company"] = "XyzInfo.";
            //dr2["RateCardType"] = "Standard";
            //dr2["RoomType"] = "Suite - King Bed";
            //dr2["RoomNo"] = "A3-013";
            //dr2["CheckIn"] = "14-08-2012";
            //dr2["CheckOut"] = "18-08-2012";
            //dr2["AmendmentBy"] = "Mr. Mit Dabhi";
            //dr2["AmendmentDate"] = "16-08-2012";

            //dtTable.Rows.Add(dr2);
           
            string strSearchAmendmentBy = null;
            string strSearchReservationNo = null;
            DateTime? dtForAmendSerach = null;
             CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
             if (txtSearchAmendmentDate.Text.Trim() != "")
                 dtForAmendSerach = DateTime.ParseExact(txtSearchAmendmentDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
             else
                 dtForAmendSerach = null;

            // DateTime.ParseExact(txtCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo)
            if (txtSearchAmendmentBy .Text.Trim() != "")
                strSearchAmendmentBy = Convert.ToString(txtSearchAmendmentBy.Text.Trim());

            if (txtSearchBooking.Text.Trim() != "")
                strSearchReservationNo = Convert.ToString(txtSearchBooking.Text.Trim());

            DataSet dsAmendHistoryData = ReservationBLL.GetReservationAmendHistoryData(ReservationIDForAmend, clsSession.PropertyID, clsSession.CompanyID, null, null, null,strSearchReservationNo ,null , strSearchAmendmentBy,dtForAmendSerach);
            gvAmendment.DataSource = dsAmendHistoryData.Tables[0];
            gvAmendment.DataBind();
        }

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Reservation";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Reservation List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        //private void BindMonth()
        //{
        //    for (int i = 0; i < 12; i++)
        //    {
        //        DateTime dt = DateTime.Now;
        //        dt = dt.AddMonths(i);
        //        int smnth = dt.Month;
        //        string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(smnth);
        //        int year = dt.Year;

        //        ddlSearchByMonth.Items.Insert(i, new ListItem(Convert.ToString(strMonthName + " " + year), Convert.ToString(strMonthName + " " + year)));
        //    }

        //    ddlSearchByMonth.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

        private void ClearSearch()
        {
            txtSearchName.Text = txtMobileNo.Text = txtSearcReservationNo.Text = "";
            ddlSrchRoomType.SelectedIndex = ddlSearchStatus.SelectedIndex = 0;
        }
        private void ClearAmendSearch()
        {
            txtSearchAmendmentBy .Text = txtSearchAmendmentDate .Text = txtSearchBooking .Text = "";
           
        }
        private void BindRoomType()
        {
            try
            {
                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";

                ddlSrchRoomType.Items.Clear();
                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    ddlSrchRoomType.DataSource = dsRoomType.Tables[0];
                    ddlSrchRoomType.DataTextField = "RoomTypeName";
                    ddlSrchRoomType.DataValueField = "RoomTypeID";
                    ddlSrchRoomType.DataBind();

                    ddlSrchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlSrchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetMobileNo(string strPhoneNo)
        {
            string strReturn = "";
            string[] strArray = strPhoneNo.Split('-');
            if (strArray.Length > 0)
            {
                if (strArray.Length > 0 && strArray[1] != "")
                    strReturn = strPhoneNo;
                else
                    strReturn = "";
            }
            else
                strReturn = "";
            return strReturn;
        }

        private void BindBookingStatus()
        {
            try
            {
                DataSet dstBookingStatus = ProjectTermBLL.SelectAllResStatusByPageType("RESERVATIONLIST", clsSession.CompanyID, clsSession.PropertyID);
                if (dstBookingStatus != null && dstBookingStatus.Tables[0].Rows.Count > 0)
                {
                    ddlSearchStatus.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                    int i = 1;
                    foreach (DataRow dr in dstBookingStatus.Tables[0].Rows)
                    {
                        if (Convert.ToString(dr["Term"]).ToUpper() == "UNCONFIRMED" || Convert.ToString(dr["Term"]).ToUpper() == "WAITING LIST" || Convert.ToString(dr["Term"]).ToUpper() == "CONFIRMED" || Convert.ToString(dr["Term"]).ToUpper() == "NO SHOW" || Convert.ToString(dr["Term"]).ToUpper() == "CANCELLED")
                        {
                            ddlSearchStatus.Items.Insert(i, new ListItem(Convert.ToString(dr["DisplayTerm"]), Convert.ToString(dr["SymphonyValue"])));
                            i++;
                        }
                    }
                }
                else
                    ddlSearchStatus.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBillingInstruction()
        {
            try
            {
                ddlbillinginstruction.Items.Clear();
                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "BILLINGINSTRUCTION");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlbillinginstruction.DataSource = lstProjectTermTitle;
                    ddlbillinginstruction.DataTextField = "DisplayTerm";
                    ddlbillinginstruction.DataValueField = "TermID";
                    ddlbillinginstruction.DataBind();
                    ddlbillinginstruction.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlbillinginstruction.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetCardNo(string strCardNo)
        {
            string strReturn = "";
            if (strCardNo.Length == 16)
            {
                strReturn = "************" + strCardNo.Substring(12, 4);
            }
            return strReturn;
        }

        private void BindResCancelRequestMode()
        {
            try
            {
                ddlChangeRequestMode.Items.Clear();
                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RESERVATION CANCEL REQUEST MODE");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlChangeRequestMode.DataSource = lstProjectTermTitle;
                    ddlChangeRequestMode.DataTextField = "DisplayTerm";
                    ddlChangeRequestMode.DataValueField = "TermID";
                    ddlChangeRequestMode.DataBind();
                    ddlChangeRequestMode.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlChangeRequestMode.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Control Event

        protected void btnAddTopRoomReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/Reservation.aspx");
        }

        //Event which is called from AddEditRecord's userControl Opened in ModalPopup.
        protected void btnQuickPostCallParent_Click(object sender, EventArgs e)
        {
            ctrlQuickPost.mvOpenQuickPost.ActiveViewIndex = 1;
            ctrlQuickPost.ucMpeAddEditQuickPost.Show();
        }

        //protected void btnPaymentCallParent_Click(object sender, EventArgs e)
        //{
        //    //ctrlPayment.mvOpenPayment.ActiveViewIndex = 1;
        //    //ctrlPayment.ucMpeAddEditPayment.Show();
        //}

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            mvRoomReservation.ActiveViewIndex = 0;
        }

        protected void btnReservationGuestMgtCallParent_Click(object sender, EventArgs e)
        {

            string strView = Convert.ToString(ctrlidReservationGuestMgt.ToActivateView);

            if (strView == "1")
                ctrlidReservationGuestMgt.mvOpenGuest.ActiveViewIndex = 1;
            else if (strView == "2")
                ctrlidReservationGuestMgt.mvOpenGuest.ActiveViewIndex = 2;

            ctrlidReservationGuestMgt.ucMpeAddEditGuestMgt.Show();
        }

        protected void lnkAutoAssignRoom_Click(object sender, EventArgs e)
        {
            CtrlAutoAssignUnit.ucMpeAddEditAutoAssignUnit.Show();
        }

        protected void btnCancelViewAmendment_OnClick(object sender, EventArgs e)
        {
            mvRoomReservation.ActiveViewIndex = 0;
        }

        //protected void btnExtendReservationCallParent_Click(object sender, EventArgs e)
        //{
        //    mpeExtendReservation.Show();
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvRoomReservationList.PageIndex = 0;
                BindReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvRoomReservationList.PageIndex = 0;
                BindReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnSearchAmendData_OnClick(object sender, EventArgs e)
        {
            try
            {
                gvAmendment.PageIndex = 0;
                BindGridAmendment(this.ReservationID);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnrefreshAmendData_OnClick(object sender, EventArgs e)
        {
            try
            {
                ClearAmendSearch();
                gvAmendment .PageIndex = 0;
                BindGridAmendment(this.ReservationID);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnVerificationComplete_OnClick(object sender, EventArgs e)
        {
            mpeOpenAmendment.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    if (this.ReservationID != Guid.Empty)
                    {
                        clsSession.ToEditItemID = this.ReservationID;
                        clsSession.ToEditItemType = "AMENDMENTRESERVATION";
                        Session["CancelOperationRequestModeID"] = Convert.ToString(ddlChangeRequestMode.SelectedValue);
                        Session["CancelOperationRequestBy"] = Convert.ToString(txtChangeRequestBy.Text.Trim());
                        Session["CancelSymphonyValue"] = Convert.ToString(this.SymphonyValue);

                        Response.Redirect("~/GUI/Reservation/AmendReservation.aspx");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion

        #region Grid Event

        protected void gvRoomReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(e.CommandArgument.ToString());
                    clsSession.ToEditItemType = "EDITRESERVATION";
                    Response.Redirect("~/GUI/Reservation/EditReservation.aspx");
                }
                else if (e.CommandName.Equals("VIEWDATA"))
                {
                    mvRoomReservation.ActiveViewIndex = 1;
                    DataSet dsRservationData = ReservationBLL.GetResrvationViewData(new Guid(Convert.ToString(e.CommandArgument)), clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);

                    if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                    {
                        DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dsRservationData.Tables[0].Rows[0]["CheckInDate"]));
                        DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dsRservationData.Tables[0].Rows[0]["CheckOutDate"]));
                        lblViewBillingInstruction.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["BillingInstruction"]);
                        litViewGuestType.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["GuestType"]);
                        lblViewBookingStatus.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["BookingStatus"]);
                        litViewSourceofBusiness.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["SourceofBusiness"]);
                        litDisplayCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                        litDisplayCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                        litDisplayRoomType.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["RoomTypeName"]);
                        litDisplayCompanyName.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["CompanyName"]);
                        litDisplayRateCard.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["RateCardName"]);
                        litDisplayAdult.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Adults"]);

                        if (Convert.ToString(dsRservationData.Tables[0].Rows[0]["Children"]) != null && Convert.ToString(dsRservationData.Tables[0].Rows[0]["Children"]) != "")
                            litDisplayChild.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Children"]);
                        else
                            litDisplayChild.Text = "-";

                        if (Convert.ToString(dsRservationData.Tables[0].Rows[0]["Infant"]) != null && Convert.ToString(dsRservationData.Tables[0].Rows[0]["Infant"]) != "")
                            litDisplayInf.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Infant"]);
                        else
                            litDisplayInf.Text = "-";

                        if (Convert.ToString(dsRservationData.Tables[0].Rows[0]["IsToPickUp"]) != null && Convert.ToString(dsRservationData.Tables[0].Rows[0]["IsToPickUp"]) != "")
                        {
                            bool IsToPickUp = Convert.ToBoolean(Convert.ToString(dsRservationData.Tables[0].Rows[0]["IsToPickUp"]));
                            if (IsToPickUp)
                                litDisplayPickup.Text = "Yes";
                            else
                                litDisplayPickup.Text = "No";
                        }
                        else
                            litDisplayPickup.Text = "";


                        if (Convert.ToString(dsRservationData.Tables[0].Rows[0]["IsSmoking"]) != null && Convert.ToString(dsRservationData.Tables[0].Rows[0]["IsSmoking"]) != "")
                        {
                            bool IsToSmoking = Convert.ToBoolean(Convert.ToString(dsRservationData.Tables[0].Rows[0]["IsSmoking"]));
                            if (IsToSmoking)
                                litvIsSmoking .Text = "Yes";
                            else
                                litvIsSmoking.Text = "No";
                        }
                        else
                            litvIsSmoking.Text = "";

                        litviewBookedBy.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["BookedBy"]);
                        litDisplayNote.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["SpecificNote"]);
                        litDisplayStandardInstruction.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["StandardInstruction"]);
                        ////litDisplayStayType.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0][""]);
                        litDisplayNationality.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Nationality"]);
                        litDisplayGuestName.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["GuestFullName"]);
                        litDisplayMobile.Text = Convert.ToString(GetMobileNo(Convert.ToString(dsRservationData.Tables[0].Rows[0]["Phone1"])));
                        litDisplayEmail.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Email"]);
                        litDisplayAddress.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Add1"]);
                        litDisplayCityName.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["CityName"]);
                        litDisplayZipCode.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["ZipCode"]);
                        litDisplayStateName.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["StateName"]);
                        litDisplayCountryName.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["CountryName"]);
                        //litDisplayPmt.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["MOP"]);
                        //litDisplayStatus.Text = Convert.ToString(dsRservationData.Tables[0].Rows[0]["Status"]);

                        decimal RoomRent = Convert.ToDecimal("0.000000");
                        decimal Tax = Convert.ToDecimal("0.000000");
                        decimal TotalAmount = Convert.ToDecimal("0.000000");
                        int NoofDays = 0;
                        decimal DepositAmount = Convert.ToDecimal("0.000000");
                        decimal PaidDeposit = Convert.ToDecimal("0.000000");
                        int InfraServiceCharge = 0;
                        int PaidInfraServiceCharge = 0;
                        int FoodCharges = 0;
                        int PaidFoodCharges = 0;
                        int ElectricityCharges = 0;
                        int PaidElectricityCharges = 0;
                        decimal TotalAmountPayable = Convert.ToDecimal("0.000000");
                        decimal DueBalanceAmount = Convert.ToDecimal("0.000000");
                        decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                        DataTable dtPaidAmountInfo = null;

                        clsCommon.GetReservationPaymentInfo(new Guid(Convert.ToString(e.CommandArgument)), ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                        string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strTotalAmountReceived, strDueBalanceAmount = "";

                        strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        TotalAmountPayable = TotalAmount + DepositAmount;
                        strTotalAmountPayable = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
                        lblDisplayRoomRent.Text = Convert.ToString(strRoomRent);
                        lblDisplayTax.Text = Convert.ToString(strTax);
                        lblDisplayTotalAmount.Text = Convert.ToString(strTotalAmount);
                        lblDisplayDepositAmount.Text = Convert.ToString(strDepositAmount);

                        lblTotalAmountPayable.Text = lblDisplayAmount.Text = Convert.ToString(strTotalAmountPayable);

                        strTotalAmountReceived = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        lblDisplayTotalAmountReceived.Text = Convert.ToString(strTotalAmountReceived);

                        if (TotalAmountPayable >= TotalPaymentReceived)
                        {
                            ltrViewReservationBalanceAmt.Text = "Balance Amount(Due)";
                            DueBalanceAmount = TotalAmountPayable - TotalPaymentReceived;
                            lblDisplayBalanceAmountDue.Text = DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else
                        {
                            ltrViewReservationBalanceAmt.Text = "Balance Amount(Credit)";
                            DueBalanceAmount = TotalPaymentReceived  - TotalAmountPayable;
                            lblDisplayBalanceAmountDue.Text = DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                    }
                    else
                    {
                        litDisplayCheckInDate.Text = litDisplayCheckOutDate.Text = litDisplayRoomType.Text = litDisplayRateCard.Text = litDisplayAdult.Text = litDisplayChild.Text = litDisplayInf.Text = litDisplayPickup.Text = litDisplayNote.Text = ""; // litDisplayPmt.Text = litDisplayStatus.Text = "";
                        litDisplayStandardInstruction.Text = litDisplayNationality.Text = litDisplayGuestName.Text = litDisplayMobile.Text = litDisplayEmail.Text = litDisplayAddress.Text = litDisplayCityName.Text = litDisplayZipCode.Text = litDisplayStateName.Text = litDisplayCountryName.Text = ""; //litDisplayStayType = "";
                        lblDisplayNoOfDays.Text = lblDisplayRoomRent.Text = lblDisplayTax.Text = lblDisplayTotalAmount.Text = lblDisplayDepositAmount.Text = lblTotalAmountPayable.Text = lblDisplayAmount.Text = lblDisplayTotalAmountReceived.Text = lblDisplayBalanceAmountDue.Text = "";
                    }
                }
                else if (e.CommandName.Equals("REINSTATE"))
                {
                    clsSession.ToEditItemID = new Guid(e.CommandArgument.ToString());
                    clsSession.ToEditItemType = "AMENDMENTRESERVATION";

                    Response.Redirect("~/GUI/Reservation/AmendReservation.aspx?Mode=Reinstate");
                }
                else if (e.CommandName.Equals("AMENDRESERVATION"))
                {
                    chkMobileNo.Checked = chkEmail.Checked = chkCreditCard.Checked = chkCompanyName.Checked = false;

                    mpeOpenAmendment.Show();

                    BindResCancelRequestMode();

                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvGuestFullName = (Label)row.FindControl("lblGvGuestFullName");
                    Label lblGvPhone = (Label)row.FindControl("lblGvPhone");
                    Label lblGvCompanyName = (Label)row.FindControl("lblGvCompanyName");
                    Label lblGvReservationNo = (Label)row.FindControl("lblGvReservationNo");

                    string strCardNo = Convert.ToString(gvRoomReservationList.DataKeys[row.RowIndex]["CardNo"]);
                    this.SymphonyValue = Convert.ToInt32(Convert.ToString(gvRoomReservationList.DataKeys[row.RowIndex]["SymphonyValue"]));

                    litDisplayAmendmentGuestName.Text = Convert.ToString(lblGvGuestFullName.Text.Trim());
                    litDisplayAmendmentBookingNo.Text = Convert.ToString(lblGvReservationNo.Text.Trim());
                    litDisplayMobileNo.Text = Convert.ToString(lblGvPhone.Text.Trim());
                    litDispAmendmentEmail.Text = Convert.ToString(gvRoomReservationList.DataKeys[row.RowIndex]["Email"]);

                    if (strCardNo != "" && strCardNo != null)
                        litDispayCreditCard.Text = Convert.ToString(GetCardNo(strCardNo));
                    else
                        litDispayCreditCard.Text = "";
                    litDispayCompany.Text = Convert.ToString(lblGvCompanyName.Text.Trim());

                }
                else if (e.CommandName.Equals("GUESTMGT"))
                {
                    ctrlidReservationGuestMgt.ucMpeAddEditGuestMgt.Show();
                }
                else if (e.CommandName.Equals("CHECKOUT"))
                {
                    ctrlQuickPost.ucMpeAddEditQuickPost.Show();
                }
                else if (e.CommandName.Equals("VIEWFOLIO"))
                {
                    Response.Redirect("~/GUI/Folio/FolioDetails.aspx");
                }
                else if (e.CommandName.Equals("AMENDMENT"))
                {
                    mvRoomReservation.ActiveViewIndex = 2;
                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                    BindGridAmendment(this.ReservationID);
                }
                else if (e.CommandName.Equals("RESERVATIONPAYMENT"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "PAYMENT";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");

                        ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                        ucCommonCounterLogin.CounterName = string.Empty;

                        ucCommonCounterLogin.CheckAuthentication();

                        if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                        {
                            mpeOpenCounter.Show();
                        }
                        else
                        {
                            lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                            mpeCounterErrorMessage.Show();
                            return;
                        }

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    LoadPaymentData();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAmendmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("AMENDMENT"))
                {
                    mpeAmendment.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomReservationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //System.Web.UI.HtmlControls.HtmlImage

                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkEdit.Visible = this.UserRights.Substring(2, 1) == "1";
                    lnkView.Visible = this.UserRights.Substring(0, 1) == "1";


                    int SymphonyValue = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SymphonyValue")));
                    Guid? GroupReservationID = null;

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupReservationID")) != "")
                        GroupReservationID = new Guid(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GroupReservationID")));

                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));

                    lblGvPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvRoomNo = (Label)e.Row.FindControl("lblGvRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    Image imgReservationStatus = (Image)e.Row.FindControl("imgReservationStatus");
                    Image imgGroupReservation = (Image)e.Row.FindControl("imgGroupReservation");

                    string strimagesrc = "";
                    string strAltTag = "";

                    switch (SymphonyValue)
                    {
                        case 27:
                            strimagesrc = "~/images/UnConfirmed22x22.png";
                            strAltTag = " Provisional";
                            break;
                        case (28):
                            strimagesrc = "~/images/Confirmed22x22.png";
                            strAltTag = "Confirmed";
                            break;
                        case (29):
                            strimagesrc = "~/images/WaitingList22x22.png";
                            strAltTag = "Waiting List";
                            break;
                        case (32):
                            strimagesrc = "~/images/CheckIn22x22.png";
                            strAltTag = "Check In";
                            break;
                        case (33):
                            strimagesrc = "~/images/CheckOut22x22.png";
                            strAltTag = "Check Out";                            
                            break;
                        case (34):
                            strimagesrc = "~/images/Cancelled22x22.png";
                            strAltTag = "Cancelled";
                            break;
                        case (35):
                            strimagesrc = "~/images/No-Show32x32.png";
                            strAltTag = "No Show";
                            break;

                    }

                    imgReservationStatus.ImageUrl = strimagesrc;
                    imgReservationStatus.ToolTip = strAltTag;

                    if (GroupReservationID != null && GroupReservationID != Guid.Empty)
                    {
                        imgGroupReservation.Visible = true;
                        imgGroupReservation.ImageUrl = "~/images/groupreservation.png";
                        imgGroupReservation.ToolTip = "Group Reservation";
                    }
                    else
                        imgGroupReservation.Visible = false;

                    LinkButton lnkReservationPayment = (LinkButton)e.Row.FindControl("lnkReservationPayment");
                    LinkButton lnkReInstateReservation = (LinkButton)e.Row.FindControl("lnkReinstantReservation");

                    //if (Convert.ToString(SymphonyValue) == "29" ||Convert.ToString(SymphonyValue) == "32" || Convert.ToString(SymphonyValue) == "33" || Convert.ToString(SymphonyValue) == "34")
                    //    lnkReservationPayment.Visible = false;
                    //else
                    //    lnkReservationPayment.Visible = true;

                    if (Convert.ToString(SymphonyValue) == "27" || Convert.ToString(SymphonyValue) == "28" || Convert.ToString(SymphonyValue) == "29")
                        lnkEdit.Visible = true;
                    else
                        lnkEdit.Visible = false;

                    if (Convert.ToString(SymphonyValue) == "34" || Convert.ToString(SymphonyValue) == "35")
                        lnkReInstateReservation.Visible = true;
                    else
                        lnkReInstateReservation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomReservationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomReservationList.PageIndex = e.NewPageIndex;
            BindReservationGrid();
        }

        #endregion

        private void LoadPaymentData()
        {
            try
            {
                int row = this.RowIndex;

                ctrlPayment.strProcess = "RESERVATIONPAYMENT";
                ctrlPayment.ucMpeAddEditPayment.Show();

                Label lblGvGuestFullName = (Label)gvRoomReservationList.Rows[row].FindControl("lblGvGuestFullName");
                Label lblGvRoomNo = (Label)gvRoomReservationList.Rows[row].FindControl("lblGvRoomNo");
                Label lblGvRoomTypeName = (Label)gvRoomReservationList.Rows[row].FindControl("lblGvRoomTypeName");

                ctrlPayment.IsMessage = false;
                ctrlPayment.uclitDisplayPaymentFolioNo.Text = "-";
                ctrlPayment.uclitDisplayPaymentGuestName.Text = Convert.ToString(lblGvGuestFullName.Text.Trim());
                ctrlPayment.uclitDisplayRoomNoAndRoomType.Text = Convert.ToString(lblGvRoomNo.Text.Trim() + " - " + lblGvRoomTypeName.Text.Trim());
                ctrlPayment.uclitDisplayPaymentBalance.Text = "-";

                ctrlPayment.ReservationID = new Guid(gvRoomReservationList.DataKeys[row]["ReservationID"].ToString());
                ctrlPayment.FolioID = new Guid(gvRoomReservationList.DataKeys[row]["FolioID"].ToString());
                ctrlPayment.GuestID = new Guid(Convert.ToString(gvRoomReservationList.DataKeys[row]["GuestID"]));

                if (Convert.ToString(gvRoomReservationList.DataKeys[row]["RoomID"]) != "" && Convert.ToString(gvRoomReservationList.DataKeys[row]["RoomID"]) != null)
                    ctrlPayment.RoomID = new Guid(Convert.ToString(gvRoomReservationList.DataKeys[row]["RoomID"]));
                else
                    ctrlPayment.RoomID = Guid.Empty;

                ctrlPayment.BindPaymentMode();
                ctrlPayment.ClearPaymentControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveCounterData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strIsValidate == "YES")
                {
                    mpeOpenCounter.Show();

                    if (ucCommonCounterLogin.ucddlCounter.SelectedIndex != 0)
                        ucCommonCounterLogin.SaveDataInCounter();
                    else
                    {
                        mpeCounterErrorMessage.Show();
                        return;
                    }
                }

                mpeOpenCounter.Hide();

                if (ucCommonCounterLogin.DefaultCounterID != Guid.Empty && ucCommonCounterLogin.CounterLoginLogID != Guid.Empty)
                {
                    clsSession.DefaultCounterID = ucCommonCounterLogin.DefaultCounterID;
                    clsSession.CounterLoginLogID = ucCommonCounterLogin.CounterLoginLogID;
                    clsSession.CounterName = Convert.ToString(ucCommonCounterLogin.CounterName);

                    if (this.strOpenModalDialog == "PAYMENT")
                        LoadPaymentData();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}