using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class CheckInPaymentRecipt : System.Web.UI.Page
    {
        Decimal dcTotalAmount;

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdofRes"] != null)
                {
                    BindPropertyAddress();
                    BindSinglePaymentDetails();
                }
            }
        }
        #endregion

        #region Methods
        private void BindPropertyAddress()
        {
            try
            {
                DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
                lblPropertyaddress.Text = "";
                if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
                {
                    lblPropertyaddress.Text = lblPropertyaddress1.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
                }
                else
                {
                    lblPropertyaddress.Text = lblPropertyaddress.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void BindSinglePaymentDetails()
        {
            try
            {
                lblPaymentDate.Text = lblPaymentDate1.Text = DateTime.Today.ToString(clsSession.DateFormat);
                lblPaymentTime.Text = lblPaymentTime1.Text = DateTime.Now.ToString(clsSession.TimeFormat);
                lblPaymentReceivedBy.Text = lblPaymentReceivedBy1.Text = clsSession.DisplayName;

                string strBookID = null;

                if (Request.QueryString["IdofBook"] != null)
                    strBookID = Convert.ToString(Request.QueryString["IdofBook"]);
                else if (Request.QueryString["IdOfTranNo"] != null && Convert.ToString(Request.QueryString["IdOfTranNo"]) != "")
                    strBookID = Convert.ToString(Request.QueryString["IdOfTranNo"]);

                DataSet dsPayment = BookKeepingBLL.GetPaymentForCheckInVoucherForReprint(new Guid(Convert.ToString(Request.QueryString["IdofRes"])), clsSession.PropertyID, clsSession.CompanyID, strBookID);

                if (dsPayment.Tables.Count > 0 && dsPayment.Tables[0].Rows.Count > 0)
                {
                    ltrGuestName.Text = ltrGuestName1.Text = Convert.ToString(dsPayment.Tables[0].Rows[0]["GuestFullName"]);
                    lblFolioNo.Text = lblFolioNo1.Text = Convert.ToString(dsPayment.Tables[0].Rows[0]["FolioNo"]);

                    if (dsPayment.Tables.Count > 1 && dsPayment.Tables[1].Rows.Count > 0)
                    {
                        dcTotalAmount = Convert.ToDecimal(Convert.ToString(dsPayment.Tables[1].Rows[0]["TotalAmount"]));
                    }

                    gvPaymentList.DataSource = dsPayment.Tables[0];
                    gvPaymentList.DataBind();

                    gvPaymentList1.DataSource = dsPayment.Tables[0];
                    gvPaymentList1.DataBind();
                }
                else
                {
                    ltrGuestName.Text = ltrGuestName1.Text = "";
                    lblFolioNo.Text = lblFolioNo1.Text = "";
                    gvPaymentList.DataSource = null;
                    gvPaymentList.DataBind();
                    gvPaymentList1.DataSource = null;
                    gvPaymentList1.DataBind();
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
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MOP")) == string.Empty)
                    {
                        //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")).ToUpper() == "DEPOSIT TRANSFER")
                        //    ((Label)e.Row.FindControl("lblGVMOP")).Text = "Transferred from Deposit";
                    }
                    else
                        ((Label)e.Row.FindControl("lblGVMOP")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MOP"));

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

        protected void gvPaymentList1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MOP")) == string.Empty)
                    {
                        //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")).ToUpper() == "DEPOSIT TRANSFER")
                        //    ((Label)e.Row.FindControl("lblGVMOP")).Text = "Transferred from Deposit";
                    }
                    else
                        ((Label)e.Row.FindControl("lblGVMOP")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MOP"));

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