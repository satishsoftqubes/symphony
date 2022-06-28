using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class CancellationVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ResID"] != null)
                {
                    DataSet dsRservationData = ReservationBLL.GetResrvationViewData(new Guid(Convert.ToString(Request["ResID"])), clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);

                    if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsRservationData.Tables[0].Rows[0];

                        DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                        DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));

                        string strReservationNo = Convert.ToString(dr["ReservationNo"]);
                        string strCheckInDate = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                        string strCheckOutDate = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                        string strGuestName = Convert.ToString(dr["GuestFullName"]);

                        decimal dcmlRefundedAmt = Convert.ToDecimal(Convert.ToString(Request["PaidAmount"])) - Convert.ToDecimal(Convert.ToString(Request["CancellationCharge"]));
                        string strRefundedAmt = dcmlRefundedAmt.ToString().Substring(0, dcmlRefundedAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        ucCancellationVoucher.BindCancellationVoucherData(new Guid(Convert.ToString(Request["ResID"])), strGuestName, strReservationNo, strCheckInDate, strCheckOutDate, Convert.ToString(Request["PaidAmount"]), "Cash", Convert.ToString(Request["CancellationCharge"]), strRefundedAmt, "RefMOP");
                        ucCancellationVoucher.HidePrintVoucherButton();
                        ucCancellationVoucher.BindPropertyAddress();
                    }
                }
            }
        }
    }
}
