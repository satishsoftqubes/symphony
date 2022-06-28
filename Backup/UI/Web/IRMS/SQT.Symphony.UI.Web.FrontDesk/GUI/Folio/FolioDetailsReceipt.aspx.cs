using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Folio
{
    public partial class FolioDetailsReceipt : System.Web.UI.Page
    {
        #region Variable

        Decimal dcmlTotalPayment = Convert.ToDecimal("0.000000");
        Decimal dcmlTotalCharge = Convert.ToDecimal("0.000000");

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdofRes"] != null && Request.QueryString["IdofF"] != null)
                {
                    BindData();
                }
            }
        }

        #endregion

        #region Method

        public void BindData()
        {
            try
            {
                DataSet dsTransaction = TransactionBLL.GetAllTransaction(new Guid(Convert.ToString(Request.QueryString["IdofRes"])), new Guid(Convert.ToString(Request.QueryString["IdofF"])), null, null, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransaction != null && dsTransaction.Tables.Count > 0 && dsTransaction.Tables[0].Rows.Count > 0)
                {
                    DataTable tblPayment = dsTransaction.Tables[0].Clone();
                    DataTable tblTotalCharge = dsTransaction.Tables[0].Clone();
                    foreach (DataRow dtRow in dsTransaction.Tables[0].Rows)
                    {
                        if (dtRow["IsCharge"] != null)
                        {
                            if (Convert.ToBoolean(dtRow["IsCharge"].ToString()) == true)
                            {
                                tblTotalCharge.ImportRow(dtRow);

                                if (dtRow["Amount"] != null && Convert.ToString(dtRow["Amount"]) != string.Empty)
                                    dcmlTotalCharge = dcmlTotalCharge + Convert.ToDecimal(dtRow["Amount"]);
                            }
                            else
                            {
                                tblPayment.ImportRow(dtRow);

                                if (dtRow["Amount"] != null && Convert.ToString(dtRow["Amount"]) != string.Empty)
                                    dcmlTotalPayment = dcmlTotalPayment + Convert.ToDecimal(dtRow["Amount"]);
                            }
                        }
                    }

                    if (tblPayment.Rows.Count > 0)
                    {
                        gvPayment.DataSource = tblPayment;
                        gvPayment.DataBind();
                    }
                    else
                    {
                        gvPayment.DataSource = null;
                        gvPayment.DataBind();
                    }

                    if (tblTotalCharge.Rows.Count > 0)
                    {
                        gvCharge.DataSource = tblTotalCharge;
                        gvCharge.DataBind();
                    }
                    else
                    {
                        gvCharge.DataSource = null;
                        gvCharge.DataBind();
                    }

                    decimal dcmlAmt = Convert.ToDecimal("0.000000");
                    string strText = "Due:-";

                    if (dcmlTotalPayment > dcmlTotalCharge)
                    {
                        dcmlAmt = Convert.ToDecimal(dcmlTotalPayment - dcmlTotalCharge);
                        strText = "Credit:-";
                    }
                    else if (dcmlTotalPayment < dcmlTotalCharge)
                    {
                        dcmlAmt = Convert.ToDecimal(dcmlTotalCharge - dcmlTotalPayment);
                        strText = "Due:-";
                    }

                    lblAmountText.Text = strText;
                    lblDisplayAmount.Text = dcmlAmt.ToString().Substring(0, dcmlAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                }
                else
                {
                    gvPayment.DataSource = null;
                    gvPayment.DataBind();

                    gvCharge.DataSource = null;
                    gvCharge.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Grid Event

        protected void gvPayment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvPaymentAmount = (Label)e.Row.FindControl("lblGvPaymentAmount");
                    decimal dcmlAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")));

                    lblGvPaymentAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtrDisplayPaymentTotal = (Label)e.Row.FindControl("lblGvFtrDisplayPaymentTotal");
                    lblGvFtrDisplayPaymentTotal.Text = dcmlTotalPayment.ToString().Substring(0, dcmlTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {


            }
        }

        protected void gvCharge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvChargeAmount = (Label)e.Row.FindControl("lblGvChargeAmount");
                    decimal dcmlAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")));

                    lblGvChargeAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtrDisplayChargeTotal = (Label)e.Row.FindControl("lblGvFtrDisplayChargeTotal");
                    lblGvFtrDisplayChargeTotal.Text = dcmlTotalCharge.ToString().Substring(0, dcmlTotalCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);                
            }
        }

        #endregion Grid Event
    }
}