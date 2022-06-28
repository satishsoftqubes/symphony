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
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlFolioDetails : System.Web.UI.UserControl
    {
        #region Variable
        public bool IsPreview = false;
        Decimal dcmlTotalCredit = Convert.ToDecimal("0.000000");
        Decimal dcmlTotalDebit = Convert.ToDecimal("0.000000");
        Decimal dcmlBalanceAmount = Convert.ToDecimal("0.000000");

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
            }
        }

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "FOLIODETAILS")
                {
                    this.ReservationID = clsSession.ToEditItemID;
                    this.FolioID = new Guid(Convert.ToString(Session["GuestFolioID"]));

                    hdnReservationID.Value = Convert.ToString(this.ReservationID);
                    hdnFolioID.Value = Convert.ToString(this.FolioID);

                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                    Session.Remove("GuestFolioID");

                    BindData();
                    BindBreadCrumb();
                }
            }
        }

        #endregion

        #region Method

        public void BindData()
        {
            try
            {
                DataSet dsTransaction = TransactionBLL.GetAllTransaction(this.ReservationID, this.FolioID, null, null, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransaction != null && dsTransaction.Tables.Count > 0 && dsTransaction.Tables[0].Rows.Count > 0)
                {
                    lblAmountText.Visible = lblDisplayAmount.Visible = btnPrintReceipt.Visible = true;

                    gvFolioSummary.DataSource = dsTransaction.Tables[0];
                    gvFolioSummary.DataBind();

                    decimal dcmlAmt = Convert.ToDecimal("0.000000");
                    string strText = "Due:";

                    if (dcmlTotalCredit > dcmlTotalDebit)
                    {
                        dcmlAmt = Convert.ToDecimal(dcmlTotalCredit - dcmlTotalDebit);
                        strText = "Credit:";
                    }
                    else if (dcmlTotalCredit < dcmlTotalDebit)
                    {
                        dcmlAmt = Convert.ToDecimal(dcmlTotalDebit - dcmlTotalCredit);
                        strText = "Due:";
                    }

                    lblAmountText.Text = strText;
                    lblDisplayAmount.Text = dcmlAmt.ToString().Substring(0, dcmlAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                {
                    lblAmountText.Visible = lblDisplayAmount.Visible = btnPrintReceipt.Visible = false;

                    gvFolioSummary.DataSource = null;
                    gvFolioSummary.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Folio Details";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Grid Event

        protected void gvFolioSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlAmount = Convert.ToDecimal("0.000000");
                    if (DataBinder.Eval(e.Row.DataItem, "IsCharge") != null)// Charged Amount
                    {
                        if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsCharge")) == true)
                        {
                            if (DataBinder.Eval(e.Row.DataItem, "Amount") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")) != string.Empty)
                            {
                                dcmlAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")));
                                ((Label)e.Row.FindControl("lblGvDebitAmount")).Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                                dcmlBalanceAmount = dcmlBalanceAmount - dcmlAmount;
                                
                                
                                dcmlTotalDebit = dcmlTotalDebit + dcmlAmount;
                            }
                        }
                        else// Credited Amount
                        {
                            if (DataBinder.Eval(e.Row.DataItem, "Amount") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")) != string.Empty)
                            {
                                dcmlAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount")));
                                ((Label)e.Row.FindControl("lblGvCreditAmount")).Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                                dcmlBalanceAmount = dcmlBalanceAmount + dcmlAmount;
                                
                                dcmlTotalCredit = dcmlTotalCredit + dcmlAmount;
                            }
                        }
                    }

                    //// Set Banalce Amount.
                    ((Label)e.Row.FindControl("lblGvBalanceAmount")).Text = dcmlBalanceAmount.ToString().Substring(0, dcmlBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        protected void btnPrintStatement_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Folio Statement");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void LoadReport()
        {
            try
            {
                Symphony.BusinessLogic.FrontDesk.DTO.Folio folio = FolioBLL.GetByPrimaryKey(this.FolioID);
                Session.Add("FolioNo", folio.FolioNo );                
                
                DataSet Dst = FolioBLL.GetRptFolioStatement(this.ReservationID, this.FolioID, null, null, true);

                Session["DataSource"] = Dst;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}