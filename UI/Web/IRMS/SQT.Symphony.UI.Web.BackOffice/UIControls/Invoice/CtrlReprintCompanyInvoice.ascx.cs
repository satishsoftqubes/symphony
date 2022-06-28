using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice
{
    public partial class CtrlReprintCompanyInvoice : System.Web.UI.UserControl
    {
        #region Property and Variable 

        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }

        public Decimal BillingAmount
        {
            get
            {
                return ViewState["BillingAmount"] != null ? Convert.ToDecimal(ViewState["BillingAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["BillingAmount"] = value;
            }
        }
        public string strBillingFromDate
        {
            get
            {
                return ViewState["strBillingFromDate"] != null ? Convert.ToString(ViewState["strBillingFromDate"]) : string.Empty;
            }
            set
            {
                ViewState["strBillingFromDate"] = value;
            }
        }
        public string strBillingToDate
        {
            get
            {
                return ViewState["strBillingToDate"] != null ? Convert.ToString(ViewState["strBillingToDate"]) : string.Empty;
            }
            set
            {
                ViewState["strBillingToDate"] = value;
            }
        }
        #endregion Property and Variable
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");

                CheckUserAuthorization();

                BindBillingInstruction();
                BindCompany();
                
                //BindGrid(); //Don't bind Grid at the time of Page load.
            }
        }

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ReprintCompanyInvoice.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
        }
        private void Clearcontrol()
        {
            txtSearchFromDate.Text = "";
            txtSearchToDate.Text = "";
            ddlBillingInstruction.SelectedIndex = 0;
            ddlSearchCompany.SelectedIndex = 0;

        }
        private void BindBillingInstruction()
        {
            ddlBillingInstruction.Items.Clear();
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "BILLINGINSTRUCTION");
            if (lstProjectTermTitle.Count != 0)
            {
                ddlBillingInstruction.DataSource = lstProjectTermTitle;
                ddlBillingInstruction.DataTextField = "DisplayTerm";
                ddlBillingInstruction.DataValueField = "TermID";
                ddlBillingInstruction.DataBind();
                ddlBillingInstruction.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlBillingInstruction.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void BindCompany()
        {
            string strCompany = "SELECT CorporateID,CompanyName FROM [dbo].[mst_Corporate]  WHERE ISNULL(IsActive,0) = 1 and ISNULL(IsDirectBill,1) = 1  and PropertyID ='" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID= '" + Convert.ToString(clsSession.CompanyID) + "' Order by [CompanyName] asc";
            DataSet dsCompany = RoomBLL.GetUnitNo(strCompany);

            ddlSearchCompany.Items.Clear();
            if (dsCompany != null && dsCompany.Tables.Count > 0 && dsCompany.Tables[0].Rows.Count > 0)
            {
                ddlSearchCompany.DataSource = dsCompany.Tables[0];
                ddlSearchCompany.DataTextField = "CompanyName";
                ddlSearchCompany.DataValueField = "CorporateID";
                ddlSearchCompany.DataBind();
                ddlSearchCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlSearchCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void BindGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime dtFromDate = DateTime.Today;
                DateTime dtToDate = DateTime.Today;
                Guid? BillingInstrID = null;
                Guid? CorporateID = null;

                if (txtSearchFromDate.Text.Trim() != "")
                    dtFromDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (txtSearchToDate.Text.Trim() != "")
                    dtToDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (ddlBillingInstruction.SelectedIndex != 0)
                    BillingInstrID = new Guid(ddlBillingInstruction.SelectedValue);

                if (ddlSearchCompany.SelectedIndex != 0)
                    CorporateID = new Guid(ddlSearchCompany.SelectedValue);

                DataSet dsInvoices = InvoiceBLL.GetAll4RePrintCompanyInvoice (dtFromDate, dtToDate, CorporateID, clsSession.PropertyID, clsSession.CompanyID, BillingInstrID);
                if (dsInvoices != null && dsInvoices.Tables[0].Rows.Count > 0)
                {
                    gvCompanyInvoiceList.DataSource = dsInvoices.Tables[0];
                    gvCompanyInvoiceList.DataBind();
                }
                else
                {
                    gvCompanyInvoiceList.DataSource = null;
                    gvCompanyInvoiceList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Private Method

        #region Grid Event
        protected void gvCompanyInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcBillingAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BillingAmount")));
                    ((Literal)e.Row.FindControl("ltrBillingAmount")).Text = Convert.ToString(dcBillingAmount.ToString().Substring(0, dcBillingAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                    DateTime dtChkInDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CheckInDate").ToString());
                    DateTime dtChkOutDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CheckOutDate").ToString());

                    ((Literal)e.Row.FindControl("ltrCheckInDate")).Text = Convert.ToString(dtChkInDate.ToString(clsSession.DateFormat));
                    ((Literal)e.Row.FindControl("ltrCheckOutDate")).Text = Convert.ToString(dtChkOutDate.ToString(clsSession.DateFormat));
                    
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvCompanyInvoiceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("PRINT"))
                {

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    Literal ltrBillingAmount = (Literal)row.FindControl("ltrBillingAmount");

                    hdnReservationID.Value = Convert.ToString(new Guid(e.CommandArgument.ToString()));
                    this.strBillingFromDate = Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["BillingFromDate"]);
                    this.strBillingToDate = Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["BillingToDate"]);
                    decimal posChargePerDay = Convert.ToDecimal("0.00");
                    posChargePerDay = Convert.ToDecimal(Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["POSChargePerDay"]));

                    if (ltrBillingAmount != null && Convert.ToDecimal(ltrBillingAmount.Text) > 0)
                        this.BillingAmount = Convert.ToDecimal(ltrBillingAmount.Text);

                    DateTime dtStartDate = Convert.ToDateTime(this.strBillingFromDate);
                    DateTime dtEndDate = Convert.ToDateTime(this.strBillingToDate);

                    int intNoOfDays = (Convert.ToInt32(((dtEndDate) - (dtStartDate)).TotalDays)) + 1;
                    decimal dcmlPOSCharges = Convert.ToDecimal("0.00");
                    dcmlPOSCharges = intNoOfDays * posChargePerDay;

                    string strTotalAmount = (this.BillingAmount + dcmlPOSCharges).ToString().Substring(0, (this.BillingAmount + dcmlPOSCharges).ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    
                    Session["BillingAmountToPrint"] = Convert.ToString(strTotalAmount);
                    Session["BillingPeriodToPrint"] = Convert.ToDateTime(this.strBillingFromDate).ToString(clsSession.DateFormat) + " to " + Convert.ToDateTime(this.strBillingToDate).ToString(clsSession.DateFormat);

                    Session["InvoiceNoToPrint"] = Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["InvoiceNo"]);
                    LinkButton lnkPrintReceipt = (LinkButton)row.FindControl("lnkPrint");
                    //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                    //scriptManager.RegisterPostBackControl(lnkPrintReceipt); 

                   
                    //lnkPrintReceipt.OnClientClick = "fnCompanyInvoicePrint();";
                    //btnPrintInvoice.Attributes.Add("OnClientClick", "fnCompanyInvoicePrint();");
                   Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnCompanyInvoicePrint();", true);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event

        #region Control Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            Clearcontrol();
            BindGrid();
        }
        #endregion Control Event


    }
}