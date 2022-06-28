using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;
using System.Text;
using System.Configuration;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlCheckRoomAvailability : System.Web.UI.UserControl
    {
        #region Property and variable
        public bool IsInsert = false;
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
        #endregion Property and variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DateFormat = "dd-MM-yyyy";
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                BindRoomType();
            }
        }
        #endregion Page Load

        #region Privae Method
        private string GetRoomNumber(string strRoomNumber)
        {
            string strRoomNo = string.Empty;


            string[] str = strRoomNumber.Split('|');
            if (str.Length > 0)
                strRoomNo = str[0] + "(" + str[1] + ")";

            return strRoomNo;
        }
        private void BindRoomReservationChart()
        {
            if (Session["ResVoucherIDForRoomAvailability"] != null)
            {
                string[] ResVoucherID = Convert.ToString(Session["ResVoucherIDForRoomAvailability"]).Split('|');

                if (ResVoucherID[0] != null)
                {
                    ReservationVoucher objResVou = new ReservationVoucher();
                    objResVou = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ResVoucherID[0])));

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime dtCheckInDate = DateTime.Today;
                    DateTime dtCheckoutDate = DateTime.Today;


                    Guid? RoomTypeID = null;



                    if (objResVou.CheckInDate != null)
                        dtCheckInDate = Convert.ToDateTime(objResVou.CheckInDate);
                    if (objResVou.CheckOutDate != null)
                        dtCheckoutDate = Convert.ToDateTime(objResVou.CheckOutDate);
                    if (ddlSearchRoomType.SelectedIndex != 0)
                        RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);





                    StringBuilder strBldr = new StringBuilder();



                    SrvcOccupancy.CheckInGuestListSoapClient objClient = new SrvcOccupancy.CheckInGuestListSoapClient();

                    //objClient.Get
                    //DataSet dsRoomData = objClient.Get(Convert.ToString(startdt.ToString("dd-MM-yyyy")), Convert.ToString(enddt.ToString("dd-MM-yyyy")));

                    DataSet dsRoomData = objClient.GetDataForRoomAvailabilityChart(dtCheckInDate.ToString(this.DateFormat), dtCheckoutDate.ToString(this.DateFormat), RoomTypeID, 24);

                    //DataSet dsRoomData = ReservationBLL.GetRoomResrvationChartData(dtCheckInDate, dtCheckoutDate, RoomTypeID, clsSession.PropertyID, clsSession.CompanyID, 24);

                    if (dsRoomData.Tables.Count > 0 && dsRoomData.Tables[0].Rows.Count > 0)
                    {
                        strBldr.Append("<table id='tblchart' name='tblchart' cellpadding='0' cellspacing='1' class='maintable' width='100%'>");

                        for (int i = 0; i < dsRoomData.Tables[0].Rows.Count + 1; i++)
                        {
                            strBldr.Append("<tr>");
                            for (int j = 0; j < dsRoomData.Tables[0].Columns.Count - 2; j++)
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                        strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                                    else
                                    {
                                        DateTime dtDate = Convert.ToDateTime(Convert.ToString(dsRoomData.Tables[0].Columns[j + 2].ColumnName));
                                        strBldr.Append("<td class='cellheader'>" + (dtDate.ToString("dd-MM-yy")) + "<br />" + Convert.ToString(dtDate.ToString("ddd")) + "</td>");
                                    }
                                }
                                else
                                {
                                    if (j == 0)
                                    {
                                        strBldr.Append("<td class='roomname' style=\"cursor:pointer;\">" + (GetRoomNumber(Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]))) + "</td>");
                                    }
                                    else
                                    {
                                        string strData = Convert.ToString(dsRoomData.Tables[0].Rows[i - 1][j + 2]);
                                        if (strData != string.Empty)
                                        {
                                            string[] strResult = strData.Split('~');
                                            if (strResult.Length != 0)
                                            {
                                                string strSymphonyValue = Convert.ToString(strResult[0]);
                                                string strCompanyName = Convert.ToString(strResult[2]);
                                                string strGuestName = Convert.ToString(strResult[3]);
                                                string strCalss = "availableroom";

                                                switch (Convert.ToInt32(strSymphonyValue))
                                                {
                                                    case 27:
                                                        strCalss = "availableroom";
                                                        break;
                                                    case (28):
                                                        strCalss = "bookedroom";
                                                        break;
                                                    case (29):
                                                        strCalss = "";
                                                        break;
                                                    case (32):
                                                        strCalss = "checkinroom";
                                                        break;
                                                    case (33):
                                                        strCalss = "";
                                                        break;
                                                    case (34):
                                                        strCalss = "";
                                                        break;
                                                }
                                                //oosroom 
                                                //string strRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                                                strCompanyName = strCompanyName != "" ? " | " + strCompanyName : "";
                                                string srtTitle = strGuestName + strCompanyName;
                                                strBldr.Append("<td class='" + strCalss + "' title='" + srtTitle + "'></td>");
                                            }
                                            else
                                                strBldr.Append("<td class='availableroom'></td>");
                                        }
                                        else
                                            strBldr.Append("<td class='availableroom'></td>");
                                    }
                                }
                            }
                            strBldr.Append("</tr>");
                        }
                        strBldr.Append("</table>");

                        dvChart.Visible = true;
                        dvChart.InnerHtml = strBldr.ToString();
                    }


                }
            }
        }
        private void BindRoomType()
        {
            SrvcOccupancy.CheckInGuestListSoapClient objClient = new SrvcOccupancy.CheckInGuestListSoapClient();
            DataSet dsRoomType = objClient.GetDataForRoomType();
            ddlSearchRoomType.Items.Clear();
            if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
            {
                ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                ddlSearchRoomType.DataTextField = "RoomTypeName";
                ddlSearchRoomType.DataValueField = "RoomTypeID";
                ddlSearchRoomType.DataBind();

                ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            }
            //if (Session["ResVoucherIDForRoomAvailability"] != null)
            //{
            //    string[] PropertyID = Convert.ToString(Session["ResVoucherIDForRoomAvailability"]).Split('|');

            //    if (PropertyID[1] != null)
            //    {

            //        SrvcOccupancy.CheckInGuestListSoapClient objClient = new SrvcOccupancy.CheckInGuestListSoapClient();
            //        DataSet dsRoomType = objClient.GetDataForRoomType();
            //        ddlSearchRoomType.Items.Clear();
            //        if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
            //        {
            //            ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
            //            ddlSearchRoomType.DataTextField = "RoomTypeName";
            //            ddlSearchRoomType.DataValueField = "RoomTypeID";
            //            ddlSearchRoomType.DataBind();

            //            ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            //        }
            //        else
            //        {
            //            ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            //        }
            //    }
            //    else
            //    {
            //        ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            //    }
            //}
            //else
            //{
            //    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            //}
        }
        #endregion Private Method

        #region Control Event
        protected void btnSendEmailToFDE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Page.IsValid)
                {
                    if (Session["ResVoucherIDForRoomAvailability"] != null)
                    {
                        string[] ResVoucherID = Convert.ToString(Session["ResVoucherIDForRoomAvailability"]).Split('|');
                        if (File.Exists(Server.MapPath("~/EmailTemplates/ReservationVoucherToFDE.htm")) && (ResVoucherID[1] != null && ResVoucherID[1] != string.Empty) && (ResVoucherID[0] != null && ResVoucherID[0] != string.Empty))
                        {
                            Guid? CompanyID = this.CompanyID;
                            DataSet dsForInvestorList = ReservationVoucherBLL.GetAll_ReservationVoucherList(new Guid(Convert.ToString(ResVoucherID[0])), CompanyID, null, null, null);
                            if (dsForInvestorList != null && dsForInvestorList.Tables.Count > 0 && dsForInvestorList.Tables[0].Rows.Count > 0)
                            {
                                //Send Email To FDE


                                // Get PropertyConfiguration Information For send Mail
                                DataRow drForResVoucher = dsForInvestorList.Tables[0].Rows[0];


                                PropertyConfiguration objPropertyConfiguration = new PropertyConfiguration();
                                objPropertyConfiguration.CompanyID = this.CompanyID;
                                objPropertyConfiguration.PropertyID = new Guid(ResVoucherID[1]);
                                DataSet dsForPropertyConfigInfo = PropertyConfigurationBLL.GetAllWithDataSet(objPropertyConfiguration);
                                if (dsForPropertyConfigInfo != null && dsForPropertyConfigInfo.Tables.Count > 0 && dsForPropertyConfigInfo.Tables[0].Rows.Count > 0)
                                {
                                    DataRow drForPropertyConfig = dsForPropertyConfigInfo.Tables[0].Rows[0];
                                    string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/ReservationVoucherToFDE.htm"));
                                    strHTML = strHTML.Replace("$TEXTFORFDE$", "Please create reservation as per voucher information and voucher information is as below:");
                                    strHTML = strHTML.Replace("$SUGGESTEDROOMTYPE$", Convert.ToString(ddlSearchRoomType.SelectedItem.Text));
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

                                    strHTML = strHTML.Replace("$NOTES$", Convert.ToString(drForResVoucher["Notes"]).Trim());

                                    string strFDEEmailID = ConfigurationManager.AppSettings["FDEEmailID"].ToString();

                                    SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(drForPropertyConfig["PrimoryDomainName"]), Convert.ToString(drForPropertyConfig["UserName"]), Convert.ToString(drForPropertyConfig["Password"]), Convert.ToString(drForPropertyConfig["SmtpAddress"]), strFDEEmailID, "Reservation Voucher", strHTML, "");


                                    // CHange the Status of reservation Voucher To Email send to FDE

                                    ReservationVoucher objReserCancel = new ReservationVoucher();
                                    objReserCancel = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ResVoucherID[0])));


                                    ReservationVoucher objoldReserCancel = new ReservationVoucher();
                                    objoldReserCancel = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ResVoucherID[0])));


                                    objReserCancel.Status_Term = "PROVISIONAL";
                                    objReserCancel.UpdateBy = new Guid(Convert.ToString(Session["UserID"]));
                                    objReserCancel.UpdatedOn = DateTime.Now;

                                    ReservationVoucherBLL.Update(objReserCancel);
                                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objoldReserCancel.ToString(), objReserCancel.ToString(), "irs_ReservationVoucher");
                                    IsInsert = true;
                                    btnSendEmailToFDE.Visible = false;
                                    btnNotAvailable.Visible = false;
                                    lblRoomAvailmsg.Text = "Email send to Frontdesk executive successfully.";

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
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnNotAvailable_Click(object sender, EventArgs e)
        {
            try
            {
                // CHange the Status of reservation Voucher To Email send to FDE
                string[] ResVoucherID = Convert.ToString(Session["ResVoucherIDForRoomAvailability"]).Split('|');
                if ((ResVoucherID[0] != null && ResVoucherID[0] != string.Empty))
                {
                    ReservationVoucher objReserCancel = new ReservationVoucher();
                    objReserCancel = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ResVoucherID[0])));


                    ReservationVoucher objoldReserCancel = new ReservationVoucher();
                    objoldReserCancel = ReservationVoucherBLL.GetByPrimaryKey(new Guid(Convert.ToString(ResVoucherID[0])));


                    objReserCancel.Status_Term = "NOT AVAILABLE";
                    objReserCancel.UpdateBy = new Guid(Convert.ToString(Session["UserID"]));
                    objReserCancel.UpdatedOn = DateTime.Now;

                    ReservationVoucherBLL.Update(objReserCancel);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objoldReserCancel.ToString(), objReserCancel.ToString(), "irs_ReservationVoucher");
                    IsInsert = true;
                    btnSendEmailToFDE.Visible = false;
                    btnNotAvailable.Visible = false;
                    lblRoomAvailmsg.Text = "Room is now not available";

                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }


        }
        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Activity/RoomBookingList.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    litDisplayRoomType.Text = Convert.ToString(ddlSearchRoomType.SelectedItem.Text);
                    BindRoomReservationChart();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Control Event

    }
}