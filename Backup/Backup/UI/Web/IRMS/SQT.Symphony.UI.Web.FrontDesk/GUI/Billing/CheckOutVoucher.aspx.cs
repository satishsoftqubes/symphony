using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Billing
{
    public partial class CheckOutVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ResID"] != null && Request["ResFolioID"] != null)
                {
                    ucCheckOutVoucher.BindVoucherData(new Guid(Convert.ToString(Request["ResID"])), new Guid(Convert.ToString(Request["ResFolioID"])), Convert.ToDecimal(Convert.ToString(Request["TotalAmountRefundOrPayment"])), Convert.ToString(Request["StrRefundOrPayment"]), Convert.ToString(Request["StrModeOfRefundOrPayment"]));
                    ucCheckOutVoucher.HidPrintVoucherButton();
                }
            }
        }
    }
}