using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.BackOffice.GUI.Invoice
{
    public partial class CompanyInvoicePrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ReservationID"] != null)
                {
                    BindPropertyAddress();
                    DataSet dsInvoiceInfo = ReservationBLL.SelectReservationInfo4CompanyInvoice(new Guid(Convert.ToString(Request.QueryString["ReservationID"])));
                if (dsInvoiceInfo != null && dsInvoiceInfo.Tables[0].Rows.Count > 0)
                {
                    DataRow drResInfo = dsInvoiceInfo.Tables[0].Rows[0];
                    if (Session["InvoiceNoToPrint"] != null)
                    {
                        ltrBillNo.Text = Convert.ToString(Session["InvoiceNoToPrint"]); 
                    }
                  
                    //To set this at the time of print after saving it.
                    ltrTopRightDate.Text = DateTime.Now.ToString(clsSession.DateFormat) + " " + DateTime.Now.ToString(clsSession.TimeFormat);
                    ltrReservationNo.Text = Convert.ToString(drResInfo["ReservationNo"]);
                    ltrGuestName.Text = Convert.ToString(drResInfo["GuestFullName"]);
                    ltrRoomNo.Text = Convert.ToString(drResInfo["DisplayRoomNo"]);
                    ltrRoomType.Text = Convert.ToString(drResInfo["RoomTypeName"]);
                    ltrRateCard.Text = Convert.ToString(drResInfo["RateCardName"]);
                    ltrBillingInstruction.Text = Convert.ToString(drResInfo["BillingInstruction"]);
                    if (Session["BillingAmountToPrint"] != null && Convert.ToString(Session["BillingAmountToPrint"]) != string.Empty)
                    {
                        ltrRoomRent.Text = litTotal.Text  = Convert.ToString(Session["BillingAmountToPrint"]);
                    }
                    ltrCheckInDate.Text = Convert.ToDateTime(Convert.ToString(drResInfo["CheckInDate"])).ToString(clsSession.DateFormat);
                    ltrCheckOutDate.Text = Convert.ToDateTime(Convert.ToString(drResInfo["CheckOutDate"])).ToString(clsSession.DateFormat);

                    if (Session["BillingPeriodToPrint"] != null && Convert.ToString(Session["BillingPeriodToPrint"]) != string.Empty)
                    {
                         ltrBillingPeriod.Text= Convert.ToString(Session["BillingPeriodToPrint"]);
 
                    }
                    if (dsInvoiceInfo.Tables.Count > 1 && dsInvoiceInfo.Tables[1].Rows.Count > 0)
                    {
                        ltrCompanyName.Text = Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["CompanyName"]);
                        ltrCompanyAddressL.Text = Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["Add1"]) + " " + Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["Add2"]);
                    }
                    Session["BillingAmountToPrint"] = null;
                    Session["BillingPeriodToPrint"] = null;
                    Session["InvoiceNoToPrint"] = null;
                }
              } 
            }
        }

        private void BindPropertyAddress()
        {
            string strPropertyaddress = "select (ISNULL(MA.Add1,'') + ',' + ISNULL(MA.Add2,'') + ',' + ISNULL(MC.CityName,'') + ',' +  ISNULL(MS.StateName,'') + ',' +  ISNULL(MCO.CountryName,'')) as FullAddress FROM mst_Property MP LEFT OUTER JOIN mst_Address MA ON MP.AddressID = MA.AddressID LEFT OUTER JOIN  mst_City MC ON MC.CityID = MA.CityID LEFT OUTER JOIN mst_State MS ON MS.StateID = MA.StateID LEFT OUTER JOIN  mst_Country MCO ON MCO.CountryID = MA.CountryID Where MP.PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' And MP.CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "'";
            DataSet dsPropertyAddress = RoomBLL.GetUnitNo(strPropertyaddress);
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
    }
}