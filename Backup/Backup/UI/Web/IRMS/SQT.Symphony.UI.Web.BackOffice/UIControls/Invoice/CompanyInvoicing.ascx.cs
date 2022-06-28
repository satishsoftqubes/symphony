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
    public partial class CompanyInvoicing : System.Web.UI.UserControl
    {
        #region Property and Variables
        public decimal TotalofCompanyInvoice = Convert.ToDecimal("0.000000");
        public decimal TotalofCreatedInvoice = Convert.ToDecimal("0.000000");
        public bool IsListMessage = false;
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
        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
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
        public Guid AgentID
        {
            get
            {
                return ViewState["AgentID"] != null ? new Guid(Convert.ToString(ViewState["AgentID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AgentID"] = value;
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
        #endregion Property and Variables

        #region Page Load Event
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
                //BindCreatedInvoicesGrid();  //Don't bind Grid at the time of Page load.
            }
        }
        #endregion

        #region Control Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
            BindCreatedInvoicesGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnPrintInvoice_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.strBillingFromDate != string.Empty && this.strBillingToDate != string.Empty)
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Invoice objToInsert = new BusinessLogic.FrontDesk.DTO.Invoice();
                    objToInsert.ReservationID = this.ReservationID;
                    objToInsert.FolioID = this.FolioID;
                    objToInsert.CustomerID = objToInsert.GuestID = this.GuestID;
                    objToInsert.AgentID = this.AgentID;
                    objToInsert.InvoiceDate = DateTime.Now;
                    objToInsert.Amt = this.BillingAmount;
                    objToInsert.IsPaid = false;
                    //objToInsert.PendingAmount = 0;
                    //objToInsert.CustomerID = 0;
                    objToInsert.TransactionOrigin_TermID = 40;
                    objToInsert.CompanyID = clsSession.CompanyID;
                    objToInsert.PropertyID = clsSession.PropertyID;
                    objToInsert.IsPrinted = true;
                    objToInsert.PrintedOn = DateTime.Now;
                    objToInsert.IsLocked = false;
                    objToInsert.IsVoid = false;
                    objToInsert.IsActive = true;
                    objToInsert.IsDiscInPercentage = objToInsert.IsSynch = objToInsert.IsDiscount = false;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime dtFromDate = DateTime.Today;
                    DateTime dtToDate = DateTime.Today;

                    if (this.strBillingFromDate != "")
                        dtFromDate = Convert.ToDateTime(this.strBillingFromDate); //DateTime.ParseExact(this.strBillingFromDate, clsSession.DateFormat, objCultureInfo);
                    if (this.strBillingToDate != "")
                        dtToDate = Convert.ToDateTime(this.strBillingToDate); //DateTime.ParseExact(this.strBillingToDate, clsSession.DateFormat, objCultureInfo);

                    InvoiceBLL.Save(objToInsert, dtFromDate, dtToDate);

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Invoice objToselect = new BusinessLogic.FrontDesk.DTO.Invoice();
                    objToselect = InvoiceBLL.GetByPrimaryKey(objToInsert.InvoiceID);


                    Session["InvoiceNoToPrint"] = Convert.ToString(objToselect.InvoiceNo);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnCompanyInvoicePrint();", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Call my function", "fnCompanyInvoicePrint();", true);

                    BindGrid();
                    BindCreatedInvoicesGrid();
                }
                else
                {
                    MessageBox.Show("Invalide Date period.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region Private method


        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CompanyInvoicing.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
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

                DataSet dsInvoices = ReservationBLL.GetReservation4CompanyInvoice(dtFromDate, dtToDate, null, CorporateID, clsSession.PropertyID, clsSession.CompanyID, BillingInstrID);
                if (dsInvoices != null && dsInvoices.Tables[0].Rows.Count > 0)
                {
                    object sumObject;
                    sumObject = dsInvoices.Tables[0].Compute("Sum(BillingAmount)", "");

                    litTotalCompanyInvoice.Text = "Total :" + Convert.ToString(sumObject.ToString().Substring(0, sumObject.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
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
        private void BindCreatedInvoicesGrid()
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

                DataSet dsInvoices = InvoiceBLL.GetAll4RePrintCompanyInvoice(dtFromDate, dtToDate, CorporateID, clsSession.PropertyID, clsSession.CompanyID, BillingInstrID);
                if (dsInvoices != null && dsInvoices.Tables[0].Rows.Count > 0)
                {
                    object sumObject;
                    sumObject = dsInvoices.Tables[0].Compute("Sum(BillingAmount)", "");

                    litTotalCreatedInvoice.Text = "Total :" + Convert.ToString(sumObject.ToString().Substring(0, sumObject.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    gvCreatedInvoices.DataSource = dsInvoices.Tables[0];
                    gvCreatedInvoices.DataBind();
                }
                else
                {
                    gvCreatedInvoices.DataSource = null;
                    gvCreatedInvoices.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Private method

        #region Grid event
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
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    Literal ltrBillingAmount = (Literal)row.FindControl("ltrBillingAmount");

                    this.strBillingFromDate = Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["BillingFromDate"]);
                    this.strBillingToDate = Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["BillingToDate"]);
                    decimal posChargePerDay = Convert.ToDecimal("0.00");
                    posChargePerDay = Convert.ToDecimal(Convert.ToString(gvCompanyInvoiceList.DataKeys[row.RowIndex]["POSChargePerDay"]));

                    if (ltrBillingAmount != null && Convert.ToDecimal(ltrBillingAmount.Text) > -1)
                        this.BillingAmount = Convert.ToDecimal(ltrBillingAmount.Text);

                    this.ReservationID = new Guid(e.CommandArgument.ToString());
                    hdnReservationID.Value = Convert.ToString(this.ReservationID);
                    DataSet dsInvoiceInfo = ReservationBLL.SelectReservationInfo4CompanyInvoice(this.ReservationID);
                    if (dsInvoiceInfo != null && dsInvoiceInfo.Tables[0].Rows.Count > 0)
                    {
                        DataRow drResInfo = dsInvoiceInfo.Tables[0].Rows[0];

                        this.FolioID = new Guid(Convert.ToString(drResInfo["FolioID"]));
                        this.GuestID = new Guid(Convert.ToString(drResInfo["GuestID"]));
                        this.AgentID = new Guid(Convert.ToString(drResInfo["AgentID"]));

                        ltrBillNo.Text = "";//To set this at the time of print after saving it.
                        ltrTopRightDate.Text = DateTime.Now.ToString(clsSession.DateFormat) + " " + DateTime.Now.ToString(clsSession.TimeFormat);
                        ltrReservationNo.Text = Convert.ToString(drResInfo["ReservationNo"]);
                        ltrGuestName.Text = Convert.ToString(drResInfo["GuestFullName"]);
                        ltrRoomNo.Text = Convert.ToString(drResInfo["DisplayRoomNo"]);
                        ltrRoomType.Text = Convert.ToString(drResInfo["RoomTypeName"]);
                        ltrRateCard.Text = Convert.ToString(drResInfo["RateCardName"]);
                        ltrBillingInstruction.Text = Convert.ToString(drResInfo["BillingInstruction"]);

                        DateTime dtStartDate = Convert.ToDateTime(this.strBillingFromDate);
                        DateTime dtEndDate = Convert.ToDateTime(this.strBillingToDate);
                        
                        int intNoOfDays = (Convert.ToInt32(((dtEndDate) - (dtStartDate)).TotalDays)) + 1;
                        decimal dcmlPOSCharges = Convert.ToDecimal("0.00");
                        dcmlPOSCharges = intNoOfDays * posChargePerDay;

                        ltrRoomRent.Text = (this.BillingAmount + dcmlPOSCharges).ToString().Substring(0, (this.BillingAmount + dcmlPOSCharges).ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        ltrCheckInDate.Text = Convert.ToDateTime(Convert.ToString(drResInfo["CheckInDate"])).ToString(clsSession.DateFormat);
                        ltrCheckOutDate.Text = Convert.ToDateTime(Convert.ToString(drResInfo["CheckOutDate"])).ToString(clsSession.DateFormat);

                        ltrBillingPeriod.Text = Convert.ToDateTime(this.strBillingFromDate).ToString(clsSession.DateFormat) + " to " + Convert.ToDateTime(this.strBillingToDate).ToString(clsSession.DateFormat);

                        if (dsInvoiceInfo.Tables.Count > 1 && dsInvoiceInfo.Tables[1].Rows.Count > 0)
                        {
                            ltrCompanyName.Text = Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["CompanyName"]);
                            ltrCompanyAddressL.Text = Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["Add1"]) + " " + Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["Add2"]);
                        }
                        Session["BillingAmountToPrint"] = ltrRoomRent.Text;
                        Session["BillingPeriodToPrint"] = ltrBillingPeriod.Text;
                        //Session["ActualBillingAmount"] = Convert.ToString(this.BillingAmount);

                        mpePrintInvoice.Show();
                    }
                    else
                    {
                        MessageBox.Show("No reservation found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCompanyInvoiceList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompanyInvoiceList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvCreatedInvoices_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCreatedInvoices_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompanyInvoiceList.PageIndex = e.NewPageIndex;
            BindCreatedInvoicesGrid();
        }
        #endregion Grid event
    }
}