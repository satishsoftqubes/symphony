using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Guest
{
    public partial class UpgradeDownGradePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UpgradeVoucherPrintData"] != null)
                {
                    DataTable dtUpgradeVoucherPrintData = (DataTable)Session["UpgradeVoucherPrintData"];
                    if (dtUpgradeVoucherPrintData != null && dtUpgradeVoucherPrintData.Rows.Count > 0)
                    {
                        litDispGuestName.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["GuestName"]);
                        litDispBookingNo.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["BookingNo"]);
                        litDispNewRoomNo.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["NewRoomNo"]);
                        litDispNewRoomType.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["NewRoomType"]);
                        litDispOldRoomNo.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["OldRoomNo"]);
                        litDispOldRoomType.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["OldRoomType"]);
                        litDispCheckoutDate.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["CheckOutDate"]);
                        litDispCheckInDate.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["CheckInDate"]);
                        litDispNoOfDaysAffected .Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["NoofDaysAffected"]);
                        litDispCurrentDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

                        litDispPreviousTotalRent.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["AvailabelBalance"]);
                        litDispPreviousTotalDeposit.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["PreviousDeposit"]);
                        litDispNewTotalRent.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["NewRoomRent"]);
                        litDispNewTotalDeposit.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["NewDeposit"]);
                        litDispRoomBalanceDueCredit.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["RoomRentBalance"]);
                        litDispDepositBalanceDueCredit.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["DepositBalance"]);
                        litDispRoomRentDue.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["RoomRentBalance"]);
                        litDispDepositDue.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["DepositBalance"]);
                        litDispNetBalance.Text = Convert.ToString(dtUpgradeVoucherPrintData.Rows[0]["NetBalance"]);

                        if (Convert.ToDecimal(litDispPreviousTotalRent.Text) > Convert.ToDecimal(litDispNewTotalRent.Text) || Convert.ToDecimal(litDispPreviousTotalRent.Text) == Convert.ToDecimal(litDispNewTotalRent.Text))
                        {
                            litRoomBalanceDue.Text = "Balance(Credit)";
                            litRoomRentDue.Text = "Room Rent(Credit)";
                            litNetBalance.Text = "Net Balance(Credit)";
                        }
                        else
                        {
                            litRoomBalanceDue.Text = "Balance(Due)";
                            litRoomRentDue.Text = "Room Rent(Due)";
                            litNetBalance.Text = "Net Balance(Due)";
                        }
                        if (Convert.ToDecimal(litDispPreviousTotalDeposit.Text) > Convert.ToDecimal(litDispNewTotalDeposit.Text) || Convert.ToDecimal(litDispPreviousTotalDeposit.Text) == Convert.ToDecimal(litDispNewTotalDeposit.Text))
                        {
                            litDepositBalanceDue.Text = "Balance(Credit)";
                            litDepositDue.Text = "Deposit(Credit)";
                        }
                        else
                        {
                            litDepositBalanceDue.Text = "Balance(Due)";
                            litDepositDue.Text = "Deposit(Due)";
                        }


                        
                    }
                }
                BindPropertyAddress();
                Session["UpgradeVoucherPrintData"] = null;
            }

        }
        private void BindPropertyAddress()
        {
            try
            {
                DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
                lblPropertyaddress.Text = "";
                if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
                {
                    lblPropertyaddress.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
                }
                else
                {
                    lblPropertyaddress.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}