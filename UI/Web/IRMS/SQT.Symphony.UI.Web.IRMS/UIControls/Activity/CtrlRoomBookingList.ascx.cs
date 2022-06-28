using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlRoomBookingList : System.Web.UI.UserControl
    {
        #region Property and Variable
        public bool IsInsert = false;

        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
        public Guid PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
            }
        }

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }

        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DateFormat = "dd-MM-yyyy";
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                BindResVoucherList();
                LoadInvestor();
            }
        }
        #endregion Page Load

        #region Private Method
        private void LoadInvestor()
        {
            ddlInvestor.Items.Clear();
            DataSet ds = InvestorBLL.GetAllInvestorsForFrontDesk(this.CompanyID,null);
            DataView Dv = new DataView(ds.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlInvestor.DataSource = Dv;
                ddlInvestor.DataTextField = "InvestorFullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }
        private void BindResVoucherList()
        {
            Guid? CompanyID = this.CompanyID;
            string Statusterm = null;
            Guid? InvestorID;


            if (ddlInvestor.SelectedIndex > 0 && ddlInvestor.SelectedValue != Guid.Empty.ToString())
                InvestorID = new Guid(ddlInvestor.SelectedValue);
            else
                InvestorID = null;

            if (ddlStatus.SelectedIndex > 0 && ddlStatus.SelectedValue != string.Empty)
                Statusterm = ddlStatus.SelectedValue;
            else
                Statusterm = null;


            DataSet dsForInvestorList = ReservationVoucherBLL.GetAll_ReservationVoucherList(null, CompanyID, null, InvestorID, Statusterm);

            if (dsForInvestorList != null && dsForInvestorList.Tables.Count > 0 && dsForInvestorList.Tables[0].Rows.Count > 0)
            {
                gvReservationVoucherList.DataSource = dsForInvestorList.Tables[0];
                gvReservationVoucherList.DataBind();
            }
            else
            {
                gvReservationVoucherList.DataSource = null;
                gvReservationVoucherList.DataBind();
            }
        }
        #endregion Private Method

        #region Control Event
        protected void btnYesdelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ResVoucherID"] != null)
                {
                    //// CHange the Status of reservation Voucher To CANCEL and add Total Night to Complementory days in Investor table
                    ReservationVoucher objReserCancel = new ReservationVoucher();
                    objReserCancel = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["ResVoucherID"])));

                    ReservationVoucher objoldReserCancel = new ReservationVoucher();
                    objoldReserCancel = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["ResVoucherID"])));

                    if (objReserCancel != null && objReserCancel.Status_Term.ToUpper().Equals("CONFIRMED"))
                    {
                        DateTime dtForCheckConfirm = Convert.ToDateTime(objReserCancel.CheckInDate);
                        int Calculateddays = (dtForCheckConfirm.Date - DateTime.Now.Date).Days;

                        if (ConfigurationManager.AppSettings["NoOfDaysForBeforeCancel"] != null && Convert.ToString(ConfigurationManager.AppSettings["NoOfDaysForBeforeCancel"]) != string.Empty)
                        {
                            int AllowDays = 0;
                            AllowDays = Convert.ToInt32(Convert.ToString(ConfigurationManager.AppSettings["NoOfDaysForBeforeCancel"]));

                            if (Calculateddays >= AllowDays)
                                objReserCancel.IsToAddDaysBack = true;
                        }
                    }
                    else if (objReserCancel != null && (objReserCancel.Status_Term.ToUpper().Equals("APPROVED") || objReserCancel.Status_Term.ToUpper().Equals("PROVISIONAL")))
                        objReserCancel.IsToAddDaysBack = true;



                    // Send Email To FDE When Voucher is Cancelled

                    if ((objReserCancel.Status_Term.ToUpper().Equals("CONFIRMED") || objReserCancel.Status_Term.ToUpper().Equals("PROVISIONAL")) && ViewState["ResVoucherID"] != null && Convert.ToString(ViewState["ResVoucherID"]) != "")
                    {

                        if (File.Exists(Server.MapPath("~/EmailTemplates/ReservationVoucherToFDE.htm")))
                        {
                            Guid? CompanyID = this.CompanyID;
                            DataSet dsForInvestorList = ReservationVoucherBLL.GetAll_ReservationVoucherList(new Guid(Convert.ToString(ViewState["ResVoucherID"])), CompanyID, null, null, null);
                            if (dsForInvestorList != null && dsForInvestorList.Tables.Count > 0 && dsForInvestorList.Tables[0].Rows.Count > 0)
                            {
                                // Get PropertyConfiguration Information For send Mail
                                DataRow drForResVoucher = dsForInvestorList.Tables[0].Rows[0];
                                PropertyConfiguration objPropertyConfiguration = new PropertyConfiguration();
                                objPropertyConfiguration.CompanyID = this.CompanyID;

                                if (this.PropertyID != Guid.Empty)
                                    objPropertyConfiguration.PropertyID = this.PropertyID;
                                else
                                    objPropertyConfiguration.PropertyID = null;


                                DataSet dsForPropertyConfigInfo = PropertyConfigurationBLL.GetAllWithDataSet(objPropertyConfiguration);
                                if (dsForPropertyConfigInfo != null && dsForPropertyConfigInfo.Tables.Count > 0 && dsForPropertyConfigInfo.Tables[0].Rows.Count > 0)
                                {
                                    DataRow drForPropertyConfig = dsForPropertyConfigInfo.Tables[0].Rows[0];
                                    string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/ReservationVoucherToFDE.htm"));
                                    strHTML = strHTML.Replace("$TEXTFORFDE$", "Reservation voucher is cancelled and voucher information is as below:");
                                    strHTML = strHTML.Replace("$SUGGESTEDROOMTYPE$", "-");
                                    strHTML = strHTML.Replace("$VOUCHERNO$", Convert.ToString(drForResVoucher["VoucherNo"]));
                                    strHTML = strHTML.Replace("$INVNAME$", Convert.ToString(drForResVoucher["InvFullName"]));
                                    strHTML = strHTML.Replace("$GUESTNAME$", Convert.ToString(drForResVoucher["GuestName"]));

                                    if (drForResVoucher["CheckInDate"] != null && Convert.ToString(drForResVoucher["CheckInDate"]) != "")
                                        strHTML = strHTML.Replace("$CHECKINDATE$", Convert.ToDateTime(drForResVoucher["CheckInDate"]).ToString("dd/MM/yyyy"));
                                    else
                                        strHTML = strHTML.Replace("$CHECKINDATE$", "");




                                    if (drForResVoucher["Email"] != null && Convert.ToString(drForResVoucher["Email"]) != "")
                                        strHTML = strHTML.Replace("$GUESTEMAIL$", Convert.ToString(drForResVoucher["Email"]).Trim());
                                    else
                                        strHTML = strHTML.Replace("$GUESTEMAIL$", "");



                                    if (drForResVoucher["Phone"] != null && Convert.ToString(drForResVoucher["Phone"]) != "")
                                        strHTML = strHTML.Replace("$MOBILENO$", Convert.ToString(drForResVoucher["Phone"]).Trim());
                                    else
                                        strHTML = strHTML.Replace("$MOBILENO$", "");




                                    if (drForResVoucher["CheckOutDate"] != null && Convert.ToString(drForResVoucher["CheckOutDate"]) != "")
                                        strHTML = strHTML.Replace("$CHECKOUTDATE$", Convert.ToDateTime(drForResVoucher["CheckOutDate"]).ToString("dd/MM/yyyy"));
                                    else
                                        strHTML = strHTML.Replace("$CHECKOUTDATE$", "");

                                    strHTML = strHTML.Replace("$TOTALNIGHT$", Convert.ToString(drForResVoucher["TotalNights"]));
                                    strHTML = strHTML.Replace("$TOTALGUEST$", Convert.ToString(drForResVoucher["TotalGuest"]));

                                    strHTML = strHTML.Replace("$ADULT$", Convert.ToString(drForResVoucher["Adult"]));
                                    strHTML = strHTML.Replace("$CHILDREN$", Convert.ToString(drForResVoucher["children"]));
                                    strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));


                                    if (drForResVoucher["CreatedOn"] != null && Convert.ToString(drForResVoucher["CreatedOn"]) != "")
                                        strHTML = strHTML.Replace("$VOUCHERDATE$", Convert.ToDateTime(drForResVoucher["CreatedOn"]).ToString("dd/MM/yyyy"));
                                    else
                                        strHTML = strHTML.Replace("$VOUCHERDATE$", "");


                                    string strFDEEmailID = ConfigurationManager.AppSettings["FDEEmailID"].ToString();

                                    SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(drForPropertyConfig["PrimoryDomainName"]), Convert.ToString(drForPropertyConfig["UserName"]), Convert.ToString(drForPropertyConfig["Password"]), Convert.ToString(drForPropertyConfig["SmtpAddress"]), strFDEEmailID, "Reservation Voucher", strHTML, "");
                                }
                                else
                                {
                                    MessageBox.Show("Please set property configuration");
                                }

                            }
                            else
                            {
                                MessageBox.Show("System can't send mail to your email, Sorry for inconvenience.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("System can't send mail to your email, Sorry for inconvenience.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("System can't send mail to your email, Sorry for inconvenience.");
                    }

                    // Send Email To FDE When Voucher is Cancelled



                    objReserCancel.Status_Term = "CANCELLED";
                    objReserCancel.UpdateBy = new Guid(Convert.ToString(Session["UserID"]));
                    objReserCancel.UpdatedOn = DateTime.Now;

                    ReservationVoucherBLL.Update(objReserCancel);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objoldReserCancel.ToString(), objReserCancel.ToString(), "irs_ReservationVoucher");
                    IsInsert = true;
                    lblResVoucherMsg.Text = "Reservation voucher cancelled successfully.";
                    ddlStatus.SelectedIndex = 1;
                    BindResVoucherList();
                    ViewState["ResVoucherID"] = null;
                    msgDelete.Hide();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnCancelmsgdelete_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["ResVoucherID"] = null;
                msgDelete.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Activity/RoomBooking.aspx");
        }

        protected void btnAddTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Activity/RoomBooking.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvReservationVoucherList.PageIndex = 0;
            BindResVoucherList();
        }
        #endregion Control Event

        #region Grid Event

        protected void gvReservationVoucherList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvReservationVoucherList.PageIndex = e.NewPageIndex;
                BindResVoucherList();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvReservationVoucherList_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblGvCreatedDate = (Label)e.Row.FindControl("lblGvCreatedDate");
                if (DataBinder.Eval(e.Row.DataItem, "CreatedOn") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CreatedOn")) != "")
                    lblGvCreatedDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CreatedOn")).ToString("dd-MM-yyyy");
                else
                    lblGvCreatedDate.Text = "";

                Label lblGvCheckInDate = (Label)e.Row.FindControl("lblGvCheckInDate");
                if (DataBinder.Eval(e.Row.DataItem, "CheckInDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CheckInDate")) != "")
                    lblGvCheckInDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CheckInDate")).ToString("dd-MM-yyyy");
                else
                    lblGvCheckInDate.Text = "";

                Label lblGvCheckOutDate = (Label)e.Row.FindControl("lblGvCheckOutDate");
                if (DataBinder.Eval(e.Row.DataItem, "CheckOutDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CheckOutDate")) != "")
                    lblGvCheckOutDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CheckOutDate")).ToString("dd-MM-yyyy");
                else
                    lblGvCheckOutDate.Text = "";

                Image imgCancelres = (Image)e.Row.FindControl("imgCancelres");
                Image imgCheckRoomavail = (Image)e.Row.FindControl("imgCheckRoomavail");
                if (DataBinder.Eval(e.Row.DataItem, "Status_Term") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status_Term")) != string.Empty)
                {
                    string statustermtocompare = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status_Term"));

                    if (statustermtocompare.ToUpper().Equals("APPROVED"))
                    {
                        ((ImageButton)e.Row.FindControl("imgCheckRoomavail")).Visible = true;
                        ((ImageButton)e.Row.FindControl("imgCancelres")).Visible = true;
                    }
                    else if (statustermtocompare.ToUpper().Equals("CONFIRMED"))
                    {
                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                        ((ImageButton)e.Row.FindControl("imgCheckRoomavail")).Visible = false;

                        int Days = (Convert.ToInt32((Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CheckInDate"))) - DateTime.Today).TotalDays));
                        if (Days >= 0)
                            ((ImageButton)e.Row.FindControl("imgCancelres")).Visible = true;
                        else
                            ((ImageButton)e.Row.FindControl("imgCancelres")).Visible = false;
                    }
                    else if (statustermtocompare.ToUpper().Equals("PROVISIONAL"))
                    {
                        ((ImageButton)e.Row.FindControl("imgCancelres")).Visible = true;
                        ((ImageButton)e.Row.FindControl("imgCheckRoomavail")).Visible = false;
                    }
                    else if (statustermtocompare.ToUpper().Equals("CANCELLED"))
                    {
                        ((ImageButton)e.Row.FindControl("imgCancelres")).Visible = false;
                        ((ImageButton)e.Row.FindControl("imgCheckRoomavail")).Visible = false;
                    }
                    else
                    {
                        ((ImageButton)e.Row.FindControl("imgCheckRoomavail")).Visible = false;
                        ((ImageButton)e.Row.FindControl("imgCancelres")).Visible = false;
                    }
                }
            }
        }

        protected void gvReservationVoucherList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            if (e.CommandName.Equals("CANCELVOUCHER"))
            {
                ////CHange the Status of reservation Voucher To CANCEL and add Total Night to Complementory days in Investor table
                //lblSureDelete.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                this.PropertyID = new Guid(Convert.ToString(gvReservationVoucherList.DataKeys[row.RowIndex].Value));
                ViewState["ResVoucherID"] = e.CommandArgument.ToString();
                msgDelete.Show();

            }
            else if (e.CommandName.Equals("CHECKROOMAVAILABILITY"))
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string PropertyIDForSession = Convert.ToString(gvReservationVoucherList.DataKeys[row.RowIndex].Value);
                Session["ResVoucherIDForRoomAvailability"] = Convert.ToString(e.CommandArgument) + "|" + PropertyIDForSession;
                Response.Redirect("~/Applications/Activity/CheckRoomAvailability.aspx");
            }
            else if (e.CommandName.Equals("VOUCHERDETAIL"))
            {
                mpeVouDetails.Show();

                DataSet dsForVoucherDetails = ReservationVoucherBLL.GetAll_ReservationVoucherList(new Guid(e.CommandArgument.ToString()), null, null, null, null);
                if (dsForVoucherDetails != null && dsForVoucherDetails.Tables.Count > 0 && dsForVoucherDetails.Tables[0].Rows.Count > 0)
                {
                    DataRow drForVoucherDetails = dsForVoucherDetails.Tables[0].Rows[0];

                    if (drForVoucherDetails != null)
                    {
                        if (drForVoucherDetails["NoOfRoom"] != null && Convert.ToString(drForVoucherDetails["NoOfRoom"]) != "")
                        {
                            litDispNoOfRooms.Text = Convert.ToString(drForVoucherDetails["NoOfRoom"]);
                        }
                        else
                        {
                            litDispNoOfRooms.Text = "-";
                        }

                        if (drForVoucherDetails["PropertyName"] != null && Convert.ToString(drForVoucherDetails["PropertyName"]) != "")
                        {
                            litDispPropertyName.Text = Convert.ToString(drForVoucherDetails["PropertyName"]);
                        }
                        else
                        {
                            litDispPropertyName.Text = "-";
                        }

                        if (drForVoucherDetails["InvFullName"] != null && Convert.ToString(drForVoucherDetails["InvFullName"]) != "")
                        {
                            litDispInvestor.Text = Convert.ToString(drForVoucherDetails["InvFullName"]);
                        }
                        else
                        {
                            litDispInvestor.Text = "-";
                        }

                        if (drForVoucherDetails["ComplementryDays"] != null && Convert.ToString(drForVoucherDetails["ComplementryDays"]) != "")
                        {
                            lblDispComplementoryDays.Text = Convert.ToString(drForVoucherDetails["ComplementryDays"]);
                        }
                        else
                        {
                            lblDispComplementoryDays.Text = "-";
                        }

                        if (drForVoucherDetails["CheckInDate"] != null && Convert.ToString(drForVoucherDetails["CheckInDate"]) != "")
                        {
                            lblDispCheckInDate.Text = Convert.ToDateTime(drForVoucherDetails["CheckInDate"]).ToString(this.DateFormat);
                        }
                        else
                        {
                            lblDispCheckInDate.Text = "-";
                        }

                        if (drForVoucherDetails["CheckOutDate"] != null && Convert.ToString(drForVoucherDetails["CheckOutDate"]) != "")
                        {
                            lblDispCheckOutDate.Text = Convert.ToDateTime(drForVoucherDetails["CheckOutDate"]).ToString(this.DateFormat);
                        }
                        else
                        {
                            lblDispCheckOutDate.Text = "-";
                        }

                        if (drForVoucherDetails["TotalNights"] != null && Convert.ToString(drForVoucherDetails["TotalNights"]) != "")
                        {
                            lblDisptotalNoofDays.Text = Convert.ToString(drForVoucherDetails["TotalNights"]);
                        }
                        else
                        {
                            lblDisptotalNoofDays.Text = "-";
                        }

                        if (drForVoucherDetails["GuestName"] != null && Convert.ToString(drForVoucherDetails["GuestName"]) != "")
                        {
                            litDispInvestorGuestName.Text = Convert.ToString(drForVoucherDetails["GuestName"]);
                        }
                        else
                        {
                            litDispInvestorGuestName.Text = "-";
                        }

                        if (drForVoucherDetails["TotalGuest"] != null && Convert.ToString(drForVoucherDetails["TotalGuest"]) != "")
                        {
                            lblDispTotalGuest.Text = Convert.ToString(drForVoucherDetails["TotalGuest"]);
                        }
                        else
                        {
                            lblDispTotalGuest.Text = "-";
                        }

                        if (drForVoucherDetails["Adult"] != null && Convert.ToString(drForVoucherDetails["Adult"]) != "")
                        {
                            litDispNoOfAdult.Text = Convert.ToString(drForVoucherDetails["Adult"]);
                        }
                        else
                        {
                            litDispNoOfAdult.Text = "-";
                        }

                        if (drForVoucherDetails["children"] != null && Convert.ToString(drForVoucherDetails["children"]) != "")
                        {
                            litDispNoOfChild.Text = Convert.ToString(drForVoucherDetails["children"]);
                        }
                        else
                        {
                            litDispNoOfChild.Text = "-";
                        }
                        if (drForVoucherDetails["Notes"] != null && Convert.ToString(drForVoucherDetails["Notes"]) != "")
                        {
                            txtDispNotes.Text = Convert.ToString(drForVoucherDetails["Notes"]);
                        }
                        else
                        {
                            txtDispNotes.Text = "";
                        }
                    }
                }
            }
        }

        #endregion Grid Event
    }
}