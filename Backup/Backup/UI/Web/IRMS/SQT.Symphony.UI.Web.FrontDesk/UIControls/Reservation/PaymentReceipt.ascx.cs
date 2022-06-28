using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class PaymentReceipt : System.Web.UI.UserControl
    {
        public string gstGuestEmail
        {
            get
            {
                return ViewState["gstGuestEmail"] != null ? Convert.ToString(ViewState["gstGuestEmail"]) : string.Empty;
            }
            set
            {
                ViewState["gstGuestEmail"] = value;
            }
        }
        Decimal dcTotalAmount;

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        public void BindSinglePaymentDetails(Guid ReservationID, Guid GuestID, string GuestName, string PaidAmount, string PaymentMethod, string strReturnBookID)
        {
            try
            {
                ltrGuestName.Text = GuestName;
                hdnReservationID.Value = Convert.ToString(ReservationID);
                hdnBookID.Value = Convert.ToString(strReturnBookID);

                //lblPaidAmount.Text = PaidAmount;

                //if (PaymentMethod != string.Empty)
                //    lblPaidAmount.Text = lblPaidAmount.Text + " (" + PaymentMethod + ")";

                lblPaymentDate.Text = DateTime.Today.ToString(clsSession.DateFormat);
                lblPaymentTime.Text = DateTime.Now.ToString(clsSession.TimeFormat);
                lblPaymentReceivedBy.Text = clsSession.DisplayName;

                DataSet dsPayment = BookKeepingBLL.GetPaymentForCheckInVoucher(ReservationID, clsSession.PropertyID, clsSession.CompanyID, strReturnBookID);

                dcTotalAmount = Convert.ToDecimal("0.000000");

                if (dsPayment.Tables.Count > 0 && dsPayment.Tables[0].Rows.Count > 0)
                {
                    lblFolioNo.Text = Convert.ToString(dsPayment.Tables[0].Rows[0]["FolioNo"]);

                    if (dsPayment.Tables.Count > 1 && dsPayment.Tables[1].Rows.Count > 0)
                    {
                        dcTotalAmount = Convert.ToDecimal(Convert.ToString(dsPayment.Tables[1].Rows[0]["TotalAmount"]));
                    }

                    gvPaymentList.DataSource = dsPayment.Tables[0];
                    gvPaymentList.DataBind();

                    if (dsPayment.Tables.Count > 2 && dsPayment.Tables[2].Rows.Count > 0)
                    {
                        this.gstGuestEmail = Convert.ToString(dsPayment.Tables[2].Rows[0]["Email"]);
                    }
                }
                else
                {
                    lblFolioNo.Text = "";
                    gvPaymentList.DataSource = null;
                    gvPaymentList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Event

        protected void gvPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strAmount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount"));
                    ((Label)e.Row.FindControl("lblGvAmount")).Text = strAmount.Substring(0, strAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    string strTotalAmount = Convert.ToString(dcTotalAmount);
                    ((Label)e.Row.FindControl("lblDisplayTotalAmount")).Text = strTotalAmount.Substring(0, strTotalAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }

            catch (Exception ex)
            {
            }
        }

        #endregion Grid Event
    }
}