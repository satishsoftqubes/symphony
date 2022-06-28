using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Collections;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Configuration;
using System.Globalization;

//using SQT.Symphony.BusinessLogic.Configuration.BLL;
//using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.UserID == Guid.Empty || clsSession.UserID == null)
            {
                Session.Clear();
                Response.Redirect(Convert.ToString(ConfigurationManager.AppSettings["LogOutPath"]));
                //Response.Redirect("~/Login.aspx");
            }

            Page.Header.DataBind();
            if (!IsPostBack)
            {
                SetMenuItemsVisibility();
                SetLabel();
                BindAlertsAndMessages();
                BindFrontDeskAlert();
                BindTroubleTicket();
                BindUserGrid();
                BindUserWhoEmp();
                RemovePageRelatedSessionData();
                BindSOP();
                BindNoOfTroubleTicket();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Set Page Label
        /// </summary>
        private void SetLabel()
        {
            lblUserDisplayName.Text = clsSession.DisplayName;
            //lblUserRoleType.Text = "Front Desk Admin";//clsSession.UserType;
            lblPropertyName.Text = clsSession.PropertyName != string.Empty ? clsSession.PropertyName : "";
            //if (clsSession.DateFormat != string.Empty)
            //    litDate.Text = DateTime.Now.Date.ToString(Convert.ToString(clsSession.DateFormat));
            //else
            litDate.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");

            //if (clsSession.TimeFormat != string.Empty)
            //    litTime.Text = DateTime.Now.ToString(clsSession.TimeFormat);
            //else
            litTime.Text = DateTime.Now.ToString("hh:mm tt");

            lblDate.Text = "Date"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblDate", "Date");
            lblTime.Text = "Time"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblTime", "Time");
            lnkLogout.Text = "Log Out"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblBtnLogOut", "Log Out");
            ltrModuleTitle.Text = "Front Desk Operation"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblModuleTitle", "Property Management Setup");
            ltrSetting.Text = "Settings"; //clsCommon.GetGlobalResourceText("AdminMaster", "lblUserSetting", "Setting");
        }

        private void BindSOP()
        {
            Transcript objTranscript = new Transcript();
            objTranscript.CompanyID = clsSession.CompanyID;
            objTranscript.PropertyID = clsSession.PropertyID;
            objTranscript.TranscriptType = "SOP";
            objTranscript.ModulName = "Front Desk";
            objTranscript.IsActive = true;
            DataSet dsForSOP = TranscriptBLL.GetAllWithDataSet(objTranscript);
            if (dsForSOP != null && dsForSOP.Tables.Count > 0 && dsForSOP.Tables[0].Rows.Count > 0)
            {
                gvSOP.DataSource = dsForSOP.Tables[0];
                gvSOP.DataBind();
            }


        }
        private void BindMarketingStatusTerm()
        {
            List<ProjectTerm> lstMarketingStatusTerm = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "Email Database Type");
            ddlMarketingValueStatus.Items.Clear();
            if (lstMarketingStatusTerm.Count != 0)
            {
                ddlMarketingValueStatus.DataSource = lstMarketingStatusTerm;
                ddlMarketingValueStatus.DataTextField = "DisplayTerm";
                ddlMarketingValueStatus.DataValueField = "TermID";
                ddlMarketingValueStatus.DataBind();
                ddlMarketingValueStatus.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlMarketingValueStatus.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }
        private void ClearInquiryData()
        {
            BindGenderList();
            lblInqCurrentTime.Text = DateTime.Now.ToString(clsSession.DateFormat + "" + " hh:mm tt");
            if (rblInqGuestGender.Items.Count > 0 && rblInqGuestGender.Items.FindByText("Male") != null)
            {
                rblInqGuestGender.Items.FindByText("Male").Selected = true;
            }
            calInqArrivalDate.StartDate = DateTime.Now;
            calInqDeptDate.StartDate = DateTime.Now;
            txtInqArrivalDate.Text = "";
            txtInqDeptDate.Text = "";
            txtInqGuestCompanyName.Text = "";
            txtInqGuestEmail.Text = "";
            txtInqGuestFirstName.Text = "";
            txtInqGuestLastName.Text = "";
            trMarketingValue.Visible = false;
            txtInqGuestMobile.Text = "";
            litDateValidationmsg.Visible = false;
        }
        private void BindNoOfTroubleTicket()
        {
            DataSet dsTicketList = TroubleTicketBLL.GetTroubleTicketList(clsSession.CompanyID, clsSession.PropertyID, null, null, false, null, null, null);

            if (dsTicketList != null && dsTicketList.Tables.Count > 0 && dsTicketList.Tables[0].Rows.Count > 0)
            {
                litNoOfOpenTicket.Text = "Open Tickets : " + Convert.ToString(dsTicketList.Tables[0].Rows.Count);
            }
            else
            {
                litNoOfOpenTicket.Text = "Open Tickets : " + "0";

            }
        }
        private void SetMenuItemsVisibility()
        {
            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                return;
            }

            if (clsSession.UserRights == string.Empty)
            {
                DataSet dsUserAuthorization = UserBLL.GetUserAllAuthorization(clsSession.UserID, null, clsSession.PropertyID, clsSession.CompanyID);
                if (dsUserAuthorization != null && dsUserAuthorization.Tables[0].Rows.Count > 0)
                {
                    clsSession.UserRights = Convert.ToString(dsUserAuthorization.Tables[0].Rows[0]["UserRights"]);
                }
            }


            // Reservation Menu
            liMRoomAvailability.Visible = clsSession.UserRights.IndexOf("ROOMAVAILABILITY.ASPX") > -1;
            liMNewReservation.Visible = clsSession.UserRights.IndexOf("RESERVATION.ASPX") > -1;
            liMAssignRoom.Visible = clsSession.UserRights.IndexOf("ASSIGNROOM.ASPX") > -1;
            liMGroupReservation.Visible = clsSession.UserRights.IndexOf("GROUPRESERVATIONLIST.ASPX") > -1;
            liMAmendReservation.Visible = clsSession.UserRights.IndexOf("AMENDMENTLIST.ASPX") > -1;
            liMReservationList.Visible = clsSession.UserRights.IndexOf("ROOMRESERVATIONLIST.ASPX") > -1;
            liMRoomStatus.Visible = clsSession.UserRights.IndexOf("ROOMSTATUS.ASPX") > -1;


            // Check in menu

            liMCheckInList.Visible = clsSession.UserRights.IndexOf("CHECKINLIST.ASPX") > -1;
            liMWalkIn.Visible = clsSession.UserRights.IndexOf("RESERVATION.ASPX") > -1;
            // liMGroupCheckIn.Visible = clsSession.UserRights.IndexOf("RESERVATION.ASPX") > -1;
            liMRegistrationForm.Visible = clsSession.UserRights.IndexOf("REGISTRATIONFORM.ASPX") > -1;
            liMCheckInLog.Visible = clsSession.UserRights.IndexOf("CHECKINLOG.ASPX") > -1;
            liMRoomStatusReport.Visible = clsSession.UserRights.IndexOf("ROOMSTATUSVIEW.ASPX") > -1;


            // Guest MGMT menu

            liMGuestList.Visible = clsSession.UserRights.IndexOf("CURRENTGUESTLIST.ASPX") > -1;
            liMFolio.Visible = clsSession.UserRights.IndexOf("FOLIOLIST.ASPX") > -1;
            liMExtendStay.Visible = clsSession.UserRights.IndexOf("EXTENDRESERVATION.ASPX") > -1;
            liMChangeRoom.Visible = clsSession.UserRights.IndexOf("CHANGEROOM.ASPX") > -1;
            liMUpDownRoom.Visible = clsSession.UserRights.IndexOf("UPGRADEDOWNGRADEROOM.ASPX") > -1;
            liMGuestHistory.Visible = clsSession.UserRights.IndexOf("GUESTMASTER.ASPX") > -1;
            // liMRoomHistory.Visible = clsSession.UserRights.IndexOf("") > -1;
            // liMRoomHistory.Visible = clsSession.UserRights.IndexOf("") > -1;


            // Check Out menu

            liMDeparturelist.Visible = clsSession.UserRights.IndexOf("DEPARTURELIST.ASPX") > -1;
            liMunsetteledcheckout.Visible = clsSession.UserRights.IndexOf("UNSETTLEDCHECKOUT.ASPX") > -1;


            // Cashier menu

            liMSecurityDeposit.Visible = clsSession.UserRights.IndexOf("SECURITYDEPOSIT.ASPX") > -1;
            liMRentReceipt.Visible = clsSession.UserRights.IndexOf("RENTRECEIPT.ASPX") > -1;
            liMCahsierCheckOut.Visible = clsSession.UserRights.IndexOf("CASHIERCHECKOUT.ASPX") > -1;
            liMReprintPayment.Visible = clsSession.UserRights.IndexOf("REPRINTPAYMENTINVOICE.ASPX") > -1;
            liMCancelReservation.Visible = clsSession.UserRights.IndexOf("CANCELRESERVATIONLIST.ASPX") > -1;


            // Night Audit Menu


            liMCloseCounter.Visible = clsSession.UserRights.IndexOf("CLOSECOUNTER.ASPX") > -1;
            liMDayEnd.Visible = clsSession.UserRights.IndexOf("DAYEND.ASPX") > -1;


            // MIS Report
            //liMOccupancy.Visible = clsSession.UserRights.IndexOf("RPTOCCUPANCYCHARTBYBLOCKTYPE.ASPX") > -1;
            //liMYieldreport.Visible = clsSession.UserRights.IndexOf("RPTYEILDCALCULATION.ASPX") > -1;
            //liMRoomRentRevenue.Visible = clsSession.UserRights.IndexOf("RPTREVENUEDETAIL.ASPX") > -1;
            //liMVacantRoomList.Visible = clsSession.UserRights.IndexOf("RPTVACANTROOMLIST.ASPX") > -1;
            //liMCFormReport.Visible = clsSession.UserRights.IndexOf("RPTCFORMREPORT.ASPX") > -1;
            //liMCancelationreport.Visible = clsSession.UserRights.IndexOf("RPTCANCELLATIONCHARGES.ASPX") > -1;
            //liMRetentionReport.Visible = clsSession.UserRights.IndexOf("RPTRETENTIONCHARGES.ASPX") > -1;

            // Acct. Report MENU

            //liMAccountsDashBoard.Visible = clsSession.UserRights.IndexOf("") > -1;
            //liMCashreport.Visible = clsSession.UserRights.IndexOf("RPTCASHREPORT.ASPX") > -1;
            //liMCollectionreoprt.Visible = clsSession.UserRights.IndexOf("COLLECTIONSUMMARYREPORT.ASPX") > -1;
            //liMSecdepositreport.Visible = clsSession.UserRights.IndexOf("RPTROOMDEPOSIT.ASPX") > -1;
            //liMRoomrentadvancereport.Visible = clsSession.UserRights.IndexOf("RPTROOMRENTADVANCE.ASPX") > -1;
            //liMLedgeracctreport.Visible = clsSession.UserRights.IndexOf("RPTACCOUNTREVENUE.ASPX") > -1;
            //liMCompanyposting.Visible = clsSession.UserRights.IndexOf("RPTCOMPANYPOSTING.ASPX") > -1;


            // Cash Card MENU


            // liMCardlist.Visible = clsSession.UserRights.IndexOf("") > -1;
            //liMNewCard.Visible = clsSession.UserRights.IndexOf("ISSUECARD.ASPX") > -1;
            //liMCancelCard.Visible = clsSession.UserRights.IndexOf("LOSTCARD.ASPX") > -1;
            //liMRecharge.Visible = clsSession.UserRights.IndexOf("CARDRECHARGE.ASPX") > -1;



            //AcPnGeneralSetting.Visible = (liLPropertyList.Visible || liLSystemSetup.Visible || liInfillSetup.Visible || liLEmailConfiguration.Visible || liLEmailTemplates.Visible || liLUnitOfMeasure.Visible);
        }

        private void BindAlertsAndMessages()
        {

            DataSet dsUnreadMsg = GuestMsgJoinBLL.GetGuestMsgJoinSelectUnreadMsgList(clsSession.PropertyID, clsSession.CompanyID, null);
            //datatable1.AsEnumerable().Reverse().Take(5);

            if (dsUnreadMsg.Tables[0].Rows.Count > 3)
            {
                DataTable dtn = dsUnreadMsg.Tables[0].Clone();
                for (int i = 0; i < 3; i++)
                {
                    dtn.ImportRow(dsUnreadMsg.Tables[0].Rows[i]);
                }

                gvGuestMsgList.DataSource = dtn;
                gvGuestMsgList.DataBind();

                linMore.Visible = true;
            }
            else
            {
                linMore.Visible = false;
                gvGuestMsgList.DataSource = dsUnreadMsg.Tables[0];
                gvGuestMsgList.DataBind();
            }

        }

        public void BindFrontDeskAlert()
        {
            //DataTable dtData = new DataTable();

            //DataColumn dc1 = new DataColumn("Message");

            //dtData.Columns.Add(dc1);

            //DataRow dr4 = dtData.NewRow();
            //dr4["Message"] = "* HKP person is on leave.";
            //dtData.Rows.Add(dr4);

            //DataRow dr5 = dtData.NewRow();
            //dr5["Message"] = "* new VVIP in room 07.";
            //dtData.Rows.Add(dr5);

            //gvFrontDeskAlert.DataSource = dtData;
            //gvFrontDeskAlert.DataBind();

            DateTime? dtMessageDateTimeToPass = DateTime.Now;
            DataSet dsFrontDeskAlertMasterNew = FrontDeskAlertMasterBLL.GetFrontDeskAlertList(clsSession.PropertyID, clsSession.CompanyID, clsSession.UserID, null, dtMessageDateTimeToPass);
            //DataSet dsUnreadMsg = GuestMsgJoinBLL.GetGuestMsgJoinSelectUnreadMsgList(clsSession.PropertyID, clsSession.CompanyID, null);
            //datatable1.AsEnumerable().Reverse().Take(5);

            if (dsFrontDeskAlertMasterNew != null && dsFrontDeskAlertMasterNew.Tables.Count > 0 && dsFrontDeskAlertMasterNew.Tables[0].Rows.Count > 3)
            {
                DataTable dtn = dsFrontDeskAlertMasterNew.Tables[0].Clone();
                for (int i = 0; i < 3; i++)
                {
                    dtn.ImportRow(dsFrontDeskAlertMasterNew.Tables[0].Rows[i]);
                }

                gvFrontDeskAlert.DataSource = dtn;
                gvFrontDeskAlert.DataBind();

                FrontDeskMore.Visible = true;
            }
            else
            {
                FrontDeskMore.Visible = false;
                gvFrontDeskAlert.DataSource = dsFrontDeskAlertMasterNew.Tables[0];
                gvFrontDeskAlert.DataBind();
            }


        }

        private void BindTroubleTicket()
        {
            DataTable dtData = new DataTable();

            DataColumn dc1 = new DataColumn("ComplainBy");
            DataColumn dc2 = new DataColumn("Complain");
            DataColumn dc3 = new DataColumn("ComplainDateTime");


            dtData.Columns.Add(dc1);
            dtData.Columns.Add(dc2);
            dtData.Columns.Add(dc3);


            DataRow dr1 = dtData.NewRow();
            dr1["ComplainBy"] = "Mr. Sachin Khandelwal";
            dr1["Complain"] = "Ac not working in Room A3-022";
            dr1["ComplainDateTime"] = "14-09-2012 10:30:00";

            dtData.Rows.Add(dr1);

            DataRow dr2 = dtData.NewRow();
            dr2["ComplainBy"] = "Mr. Raj Patel";
            dr2["Complain"] = "House keeping issue in Room B1-013";
            dr2["ComplainDateTime"] = "14-09-2012 07:30:00";

            dtData.Rows.Add(dr2);

            gvTroubleTicket.DataSource = dtData;
            gvTroubleTicket.DataBind();
        }

        private void RemovePageRelatedSessionData()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            ////Remove BlockDateRate table if Page is not New Reservation
            if (!(path.ToUpper().Contains("RESERVATION/RESERVATION.ASPX")))
            {
                if (Session["lstNewReservationBlockDateRates"] != null)
                {
                    Session["lstNewReservationBlockDateRates"] = null;
                }

                if (Session["lstNewReservationRoomServices"] != null)
                {
                    Session["lstNewReservationRoomServices"] = null;
                }
            }

            if (!(path.ToUpper().Contains("GUEST/CHANGEROOM.ASPX")))
            {
                if (Session["lstMoveRoomBlockDateRate"] != null)
                {
                    Session["lstMoveRoomBlockDateRate"] = null;
                }

                if (Session["lstMoveRoomResService"] != null)
                {
                    Session["lstMoveRoomResService"] = null;
                }
            }

            //Don't clear session b'cas payment will done by cashier from other page before saving extend reservation info.
            //if (!(path.ToUpper().Contains("GUEST/CHANGEROOM.ASPX")))
            //{
            //    if (Session["lstExtendReservationBlockDateRate"] != null)
            //    {
            //        Session["lstExtendReservationBlockDateRate"] = null;
            //    }

            //    if (Session["lstExtendReservationResService"] != null)
            //    {
            //        Session["lstExtendReservationResService"] = null;
            //    }
            //}
        }

        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }

        private void BindUserGrid()
        {
            //DataTable dtUser = new DataTable();


            //DataColumn dc1 = new DataColumn("User");
            //DataColumn dc2 = new DataColumn("Department");



            //dtUser.Columns.Add(dc1);
            //dtUser.Columns.Add(dc2);



            //DataRow dr1 = dtUser.NewRow();
            //dr1["User"] = "Miss Meeta Patel";
            //dr1["Department"] = "HR";



            //dtUser.Rows.Add(dr1);

            //DataRow dr2 = dtUser.NewRow();
            //dr2["User"] = "Mr. Satish Thummar";
            //dr2["Department"] = "Account";


            //dtUser.Rows.Add(dr2);

            //gvUserList.DataSource = dtUser;
            //gvUserList.DataBind();

            string strEmployeeList = "select HE.EmployeeID,HE.FullName as [User],MD.DepartmentName as Department  FROM hrm_Employee HE INNER JOIN mst_Department MD ON HE.PropertyID= MD.PropertyID And HE.CompanyID = MD.CompanyID And HE.DepartmentID  = MD.DepartmentID  where HE.CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "'  And  HE.PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "'";
            DataSet dsEmpList = FrontDeskAlertBLL.GetAllUserWhoEmpBLL(strEmployeeList);
            if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
            {
                gvUserList.DataSource = dsEmpList.Tables[0];
                gvUserList.DataBind();
            }

        }


        // Method added to retrieve All User List For Specific Company and Property and also UserType = "Employee"
        private void BindUserWhoEmp()
        {
            string strUserAllWhoEmp = "select UsearID,UserDisplayName from usr_user where CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "'  And  PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and UserType ='Employee'  order by UsearID asc";
            DataSet dsUserAllWhoEmp = FrontDeskAlertBLL.GetAllUserWhoEmpBLL(strUserAllWhoEmp);
            ddlMassegeBy.Items.Clear();
            if (dsUserAllWhoEmp != null && dsUserAllWhoEmp.Tables.Count > 0 && dsUserAllWhoEmp.Tables[0].Rows.Count > 0)
            {
                ddlMassegeBy.DataSource = dsUserAllWhoEmp.Tables[0];
                ddlMassegeBy.DataTextField = "UserDisplayName";
                ddlMassegeBy.DataValueField = "UsearID";
                ddlMassegeBy.DataBind();

                ddlMassegeBy.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlMassegeBy.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void BindGenderList()
        {
            List<ProjectTerm> lstGenders = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");
            rblInqGuestGender.Items.Clear();
            if (lstGenders.Count != 0)
            {
                rblInqGuestGender.DataSource = lstGenders;
                rblInqGuestGender.DataTextField = "DisplayTerm";
                rblInqGuestGender.DataValueField = "TermID";
                rblInqGuestGender.DataBind();
            }
        }


        #endregion Private Method

        #region Control Event
        /// <summary>
        /// Log Out Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            string strUserType = clsSession.UserType.ToUpper();

            if (clsSession.LogInLogID != Guid.Empty)
            {
                LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                objToUpdate.Logout = DateTime.Now;
                LoginLogBLL.Update(objToUpdate);
            }

            Session.Clear();
            Response.Redirect(Convert.ToString(ConfigurationManager.AppSettings["LogOutPath"]));
            //Response.Redirect("http://pms.uniworldindia.com");
            ////Response.Redirect("~/Login.aspx");
        }

        protected void lnkUserSettings_OnClick(object sender, EventArgs e)
        {
            //Response.Redirect("~/GUI/UserSetup/UserSetting.aspx");
        }

        //protected void btnSearchRoom_OnClick(object sender, EventArgs e)
        //{
        //    mpeAvailabilityByCalendar.Show();
        //}

        protected void imgMassegePopup_OnClick(object sender, EventArgs e)
        {
            mpeMessege.Show();

        }
        protected void rblInquiryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblInquiryStatus.SelectedIndex == 2 && rblInquiryStatus.SelectedValue.Equals("Email Database"))
            {
                BindMarketingStatusTerm();
                trMarketingValue.Visible = true;
                rfvInqArrivalDate.Enabled = false;
                rfvInqDeptDate.Enabled = false;
                tdArrivalDateForClass.Attributes.Remove("class");
                tdDeptDateForClass.Attributes.Remove("class");
                mpeInquiryData.Show();
            }
            else
            {
                ddlMarketingValueStatus.Items.Clear();
                trMarketingValue.Visible = false;
                rfvInqArrivalDate.Enabled = true;
                rfvInqDeptDate.Enabled = true;
                tdArrivalDateForClass.Attributes.Add("class", "isrequire");
                tdDeptDateForClass.Attributes.Add("class", "isrequire");
                mpeInquiryData.Show();
            }

        }
        protected void imgInquiryFormOpen_OnClick(object sender, EventArgs e)
        {
            ClearInquiryData();
            mpeInquiryData.Show();
        }
        protected void btnSaveInquiry_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    DateTime? dtStartDate = null;
                    DateTime? dtEndDate = null;
                    if (!rblInquiryStatus.SelectedValue.Equals("Email Database") && rblInquiryStatus.SelectedIndex != 2)
                    {
                        dtEndDate = DateTime.ParseExact(txtInqDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo).Date;
                        dtStartDate = DateTime.ParseExact(txtInqArrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo).Date;
                        if (dtEndDate <= dtStartDate)
                        {
                            litDateValidationmsg.Visible = true;
                            mpeInquiryData.Show();
                            return;
                        }
                        else
                        {
                            litDateValidationmsg.Visible = false;
                        }
                    }
                    else
                    {
                        dtStartDate = null;
                        dtEndDate = null;
                    }
                    Inquiry objInquiryToInsert = new Inquiry();
                    objInquiryToInsert.CompanyID = clsSession.CompanyID;
                    objInquiryToInsert.PropertyID = clsSession.PropertyID;
                    objInquiryToInsert.IsActive = true;
                    objInquiryToInsert.CreatedOn = DateTime.Now;
                    objInquiryToInsert.CreatedBy = clsSession.UserID;

                    if (txtInqArrivalDate.Text != null && txtInqArrivalDate.Text != "")
                        objInquiryToInsert.ArrivalDate = DateTime.ParseExact(txtInqArrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    else
                        objInquiryToInsert.ArrivalDate = null;


                    if (txtInqDeptDate.Text != null && txtInqDeptDate.Text != "")
                        objInquiryToInsert.DepartureDate = DateTime.ParseExact(txtInqDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    else
                        objInquiryToInsert.DepartureDate = null;


                    if (ddlInqGuestTitle.SelectedIndex != 0)
                        objInquiryToInsert.Title = Convert.ToString(ddlInqGuestTitle.SelectedItem.Text);
                    else
                        objInquiryToInsert.Title = null;

                    if (ddlMarketingValueStatus.SelectedIndex != 0)
                        objInquiryToInsert.EmailDatabase_TermID = new Guid(ddlMarketingValueStatus.SelectedValue);
                    else
                        objInquiryToInsert.EmailDatabase_TermID = null;


                    objInquiryToInsert.FName = clsCommon.GetUpperCaseText(Convert.ToString(txtInqGuestFirstName.Text.Trim()));
                    objInquiryToInsert.LName = clsCommon.GetUpperCaseText(Convert.ToString(txtInqGuestLastName.Text.Trim()));


                    if (txtInqGuestEmail.Text != null && txtInqGuestEmail.Text != "")
                        objInquiryToInsert.Email = clsCommon.GetUpperCaseText(Convert.ToString(txtInqGuestEmail.Text.Trim()));
                    else
                        objInquiryToInsert.Email = null;

                    objInquiryToInsert.GuestFullName = clsCommon.GetUpperCaseText(Convert.ToString(ddlInqGuestTitle.SelectedItem.Text) + " " + txtInqGuestFirstName.Text.Trim() + " " + txtInqGuestLastName.Text.Trim());

                    if (txtInqGuestCompanyName.Text != null && txtInqGuestCompanyName.Text != "")
                        objInquiryToInsert.Company_Name = clsCommon.GetUpperCaseText(Convert.ToString(txtInqGuestCompanyName.Text.Trim()));
                    else
                        objInquiryToInsert.Company_Name = null;

                    if (txtInqGuestCode.Text.Trim() == "")
                        objInquiryToInsert.Phone = "-" + txtInqGuestMobile.Text.Trim();
                    else
                        objInquiryToInsert.Phone = txtInqGuestCode.Text.Trim() + "-" + txtInqGuestMobile.Text.Trim();


                    if (rblInqGuestGender.SelectedIndex >= 0)
                        objInquiryToInsert.GenderTermID = new Guid(rblInqGuestGender.SelectedValue);
                    else
                        objInquiryToInsert.GenderTermID = null;


                    if (rblInquiryStatus.SelectedValue != null)
                        objInquiryToInsert.Inq_StatusTerm = rblInquiryStatus.SelectedValue;
                    else
                        objInquiryToInsert.Inq_StatusTerm = null;


                    InquiryBLL.Save(objInquiryToInsert);
                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objInquiryToInsert.ToString(), objInquiryToInsert.ToString(), "res_Inquiry", null);
                    ClearInquiryData();
                    mpeInquiryData.Hide();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mpeMessege.Hide();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<FrontDeskAlert> lstFrontDeskAlert = new List<FrontDeskAlert>();
            // To Insert a Data in to Front Desk Alert Master Table 

            FrontDeskAlertMaster objInsertFrontDeskAlertMaster = new FrontDeskAlertMaster();
            FrontDeskAlert objFrontDeskAlert;
            objInsertFrontDeskAlertMaster.FrontDeskAlertMsgID = Guid.NewGuid();
            if (txtMassege.Text.Trim() != "")
            {
                objInsertFrontDeskAlertMaster.Messege = Convert.ToString(txtMassege.Text.Trim());
            }
            objInsertFrontDeskAlertMaster.MsgDateTime = DateTime.Now;
            if (ddlMassegeBy.SelectedIndex != 0)
                objInsertFrontDeskAlertMaster.MessageBy = new Guid(ddlMassegeBy.SelectedValue);
            else
                objInsertFrontDeskAlertMaster.MessageBy = null;
            objInsertFrontDeskAlertMaster.CompanyID = clsSession.CompanyID;
            objInsertFrontDeskAlertMaster.PropertyID = clsSession.PropertyID;
            objInsertFrontDeskAlertMaster.IsActive = true; // By Default insert it to TRUE
            objInsertFrontDeskAlertMaster.IsInformed = true; // By Default insert it to TRUE
            objInsertFrontDeskAlertMaster.CreatedOn = DateTime.Now;
            objInsertFrontDeskAlertMaster.CreatedBy = clsSession.UserID;

            // Get all selected item for insert in to Front Desk Alert Detail 

            foreach (GridViewRow row in gvUserList.Rows)
            {
                CheckBox chkBox = row.FindControl("chkSelectUser") as CheckBox;
                if (chkBox != null && chkBox.Checked)
                {
                    objFrontDeskAlert = new FrontDeskAlert();
                    objFrontDeskAlert.FrontDeskAlertID = Guid.NewGuid();
                    objFrontDeskAlert.FrontDeskAlertMsgID = objInsertFrontDeskAlertMaster.FrontDeskAlertMsgID;
                    objFrontDeskAlert.MsgFor = new Guid(Convert.ToString(gvUserList.DataKeys[row.RowIndex]["EmployeeID"]));
                    objFrontDeskAlert.CompanyID = clsSession.CompanyID;
                    objFrontDeskAlert.PropertyID = clsSession.PropertyID;
                    objFrontDeskAlert.CreatedOn = DateTime.Now;
                    objFrontDeskAlert.CreatedBy = clsSession.UserID;
                    objFrontDeskAlert.IsActive = true;
                    objFrontDeskAlert.AsReceive = true;
                    lstFrontDeskAlert.Add(objFrontDeskAlert);
                }
            }

            FrontDeskAlertBLL.SaveWithDetails(objInsertFrontDeskAlertMaster, lstFrontDeskAlert);
            ClearControlOfForntDeskAlert();
            BindFrontDeskAlert();

        }
        private void ClearControlOfForntDeskAlert()
        {
            txtMassege.Text = "";
            ddlMassegeBy.SelectedIndex = 0;
            //  chkSelectUser
            foreach (GridViewRow row in gvUserList.Rows)
            {
                CheckBox chkBox = row.FindControl("chkSelectUser") as CheckBox;
                if (chkBox != null && chkBox.Checked)
                {
                    chkBox.Checked = false;
                }
            }
        }

        //protected void btnYes_Click(object sender, EventArgs e)
        //{

        //    if (Convert.ToString(hdnConfirmDeleteMst.Value) != string.Empty)
        //    {

        //        GuestMsgJoin objToDetele = GuestMsgJoinBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDeleteMst.Value)));
        //        GuestMsgJoinBLL.Delete(objToDetele);
        //        BindAlertsAndMessages();
        //        mpeCommonMsg.Show();

        //    }
        //}

        #endregion

        #region Grid Event
        protected void gvSOP_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkOpen = (LinkButton)e.Row.FindControl("lnkSOPTitle");
                lnkOpen.OnClientClick = string.Format("return fnOpenTranscript('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Title") + "|" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TranscriptID"))));
            }


        }

        protected void gvGuestMsgList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("MESSAGEDELETE"))
                {
                    GuestMsgJoin objToUpdate = GuestMsgJoinBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    objToUpdate.IsRead = true;
                    objToUpdate.UpdatedBy = clsSession.UserID;
                    objToUpdate.UpdatedOn = DateTime.Now;
                    GuestMsgJoinBLL.Update(objToUpdate);
                    BindAlertsAndMessages();
                }
            }
            catch
            {

            }
        }

        protected void gvFrontDeskAlert_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("MESSAGEDELETE"))
                {
                    FrontDeskAlertMaster objFrontDeskAltUpdate = FrontDeskAlertMasterBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    objFrontDeskAltUpdate.IsRead = true;
                    objFrontDeskAltUpdate.UpdatedBy = clsSession.UserID;
                    objFrontDeskAltUpdate.UpdatedOn = DateTime.Now;
                    FrontDeskAlertMasterBLL.Update(objFrontDeskAltUpdate);
                    BindFrontDeskAlert();
                }
            }
            catch
            {

            }
        }


        protected void gvGuestMsgList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestMsgList.PageIndex = e.NewPageIndex;
            //BindGrid();
        }

        //protected void gvConferenceList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            LinkButton lnkDeleteMsgMst = (LinkButton)e.Row.FindControl("lnkDeleteMsgMst");
        //            lnkDeleteMsgMst.OnClientClick = string.Format("return fnConfirmDeleteMst('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GuestMessageID")));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message.ToString());
        //    }
        //}
        #endregion
    }
}