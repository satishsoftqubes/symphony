using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;
namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCancellationVoucher : System.Web.UI.UserControl
    {

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region methods
        public void BindPropertyAddress()
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
        public void BindCancellationVoucherData(Guid ReservationID,string GuestName, string BookingNo, string CheckInDate, string CheckOutDate, string PaidAmount, string PaidAmountMOP, string CancellationCharge, string RefundedAmount, string RefundedMOP)
        {
            hdnReservationID.Value = ReservationID.ToString();
            ltrCancVchrGuestName.Text = GuestName;
            ltrCancVchrBookingNo.Text = BookingNo;
            ltrCancVchrCheckInDate.Text = CheckInDate;
            ltrCancVchrCheckOutDate.Text = CheckOutDate;
            hdnPaidAmount.Value = ltrCancVchrPaidAmount.Text = PaidAmount;
            //ltrCancVchrPaidAmountsMOP.Text = "(" + PaidAmountMOP + ")"; ;
            hdnCancellationCharge.Value = ltrCancVchrCancellationCharge.Text = CancellationCharge;
            ltrCancVchrRefundedAmount.Text = RefundedAmount;
            //ltrCancVchrRefundedAmountsMOP.Text = "(" + RefundedMOP + ")";
            ltrCancVchrRefundedBy.Text = clsSession.DisplayName;
            ltrCancVchrCancellationDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:tt");
        }

        public void HidePrintVoucherButton()
        {
            btnPrint.Visible = false;
        }
        #endregion
    }
}