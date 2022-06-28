using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Globalization;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorPaymentList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsEmail = false;

        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
        decimal PurchaseAmountTotal = 0;
        decimal AmountPaidTotal = 0;
        private DataSet ds = null;
        public bool IsPreview = false;

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InvID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("InvestorPaymentReceiptSetUP.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();
                if (!IsPostBack)
                {
                    if (Session["CompanyID"] == null)
                    {
                        Session.Clear();
                        Response.Redirect("~/Default.aspx");
                    }
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                    if (Session["PropertyConfigurationInfo"] != null)
                    {
                        PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                        string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                        DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                        if (ds.Tables[0].Rows.Count != 0)
                            this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                        else
                            this.DateFormat = "dd/MM/yyyy";
                    }
                    else
                        this.DateFormat = "dd/MM/yyyy";

                    caltxtLedgerDateFrom.Format = this.DateFormat;
                    caltxtLedgerToDate.Format = this.DateFormat;

                    txtPropertyName.Text = "";
                    txtUnitNo.Text = "";
                    LoadDefaultValue();
                    BindProperty();
                    PaymentReceipt_Grid();

                    if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
                        btnSendEmail.Visible = true;
                    else
                        btnSendEmail.Visible = false;
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            try
            {
                DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorPaymentReceiptSetUP.aspx", new Guid(Convert.ToString(Session["UserID"])));
                if (DV.Count > 0)
                {

                    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                    ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                    ViewState["Add"] = Convert.ToBoolean(DV[0]["IsCreate"]);
                    ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
                }
                else
                    Response.Redirect("~/Applications/AccessDenied.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                DataSet dsProperty = InvestorsUnitBLL.SelectPropertyName(new Guid(Convert.ToString(Session["InvID"])), this.CompanyID);
                if (dsProperty != null && dsProperty.Tables[0].Rows.Count != 0)
                {
                    ddlLadgerProperty.DataSource = dsProperty.Tables[0];
                    ddlLadgerProperty.DataTextField = "PropertyName";
                    ddlLadgerProperty.DataValueField = "PropertyID";
                    ddlLadgerProperty.DataBind();
                    ddlLadgerProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlLadgerProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                BindGrid();
                BindLadgerGrids();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            try
            {
                ViewState["InvestorID"] = Session["InvID"];
                string strPName = null;
                string strRNo = null;
                if (!txtPropertyName.Text.Equals(""))
                    strPName = txtPropertyName.Text.Trim();
                if (!txtUnitNo.Text.Equals(""))
                    strRNo = txtUnitNo.Text.Trim();
                ds = InvestorBLL.GetPaymentList(new Guid(Convert.ToString(ViewState["InvestorID"])), null, strPName, strRNo);

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    decimal totalPurchaseAmountCount = 0;
                    decimal totalAmountPaidCount = 0;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        totalPurchaseAmountCount += Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalPurchaseAmount"]);
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        totalAmountPaidCount += Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalReceivedAmount"]);
                    }

                    PurchaseAmountTotal = totalPurchaseAmountCount;
                    AmountPaidTotal = totalAmountPaidCount;
                    //btnPrint.Visible = true;
                }
                else
                {
                    //btnPrint.Visible = false;
                }

                grdInvestorPaymentList.DataSource = ds;
                grdInvestorPaymentList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void BindLadgerGrids()
        {
            try
            {
                if (ddlLadgerProperty.SelectedIndex != 0)
                {
                    trLedgerStatement.Visible = true;

                    trNoPropertyMessage.Visible = false;
                    trOpeningBalance.Visible = trGrids.Visible = trHrLine.Visible = trTotal.Visible = trBalance.Visible = true;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    Guid investorID = new Guid(Convert.ToString(Session["InvID"]));
                    Guid propertyID = new Guid(ddlLadgerProperty.SelectedValue.ToString());

                    DateTime? dateFrom = null;
                    DateTime? dateTo = null;

                    if (txtLedgerDateFrom.Text.Trim() != string.Empty)
                    {
                        dateFrom = DateTime.ParseExact(txtLedgerDateFrom.Text.Trim(), this.DateFormat, objCultureInfo);
                    }

                    if (txtLedgerToDate.Text.Trim() != string.Empty)
                    {
                        dateTo = DateTime.ParseExact(txtLedgerToDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    }

                    DataSet dsLadger = PaymentScheduleBLL.PaymentScheduleGetLadgerStatement(investorID, propertyID, dateFrom, dateTo);
                    if (dsLadger != null && dsLadger.Tables.Count > 0)
                    {

                        if (dsLadger.Tables.Count > 4 && dsLadger.Tables[4].Rows.Count > 0 && dsLadger.Tables[4].Rows[0]["TotalOpeningPayableAmount"] != null)
                        {
                            lblOpeningMilestoneAmount.Text = Convert.ToString(dsLadger.Tables[4].Rows[0]["TotalOpeningPayableAmount"]);
                        }
                        else
                            lblOpeningMilestoneAmount.Text = "0";


                        if (dsLadger.Tables.Count > 5 && dsLadger.Tables[5].Rows.Count > 0 && dsLadger.Tables[5].Rows[0]["TotalOpeningReceivedAmount"] != null)
                        {
                            lblOpeningReceivedAmount.Text = Convert.ToString(dsLadger.Tables[5].Rows[0]["TotalOpeningReceivedAmount"]);
                        }
                        else
                            lblOpeningReceivedAmount.Text = "0";


                        if (dsLadger.Tables[0].Rows.Count > 0)
                        {
                            gvMilestones.DataSource = dsLadger.Tables[0];
                            gvMilestones.DataBind();
                        }
                        else
                        {
                            gvMilestones.DataSource = null;
                            gvMilestones.DataBind();
                        }

                        if (dsLadger.Tables.Count > 1 && dsLadger.Tables[1].Rows.Count > 0 && dsLadger.Tables[1].Rows[0]["TotalPayableAmount"] != null)
                        {
                            lblTotalPayableAmuont.Text = Convert.ToString(Convert.ToDecimal(dsLadger.Tables[1].Rows[0]["TotalPayableAmount"]) + Convert.ToDecimal(lblOpeningMilestoneAmount.Text));
                        }
                        else
                            lblTotalPayableAmuont.Text = "0";


                        if (dsLadger.Tables.Count > 2 && dsLadger.Tables[2].Rows.Count > 0)
                        {
                            gvReceipts.DataSource = dsLadger.Tables[2];
                            gvReceipts.DataBind();
                        }
                        else
                        {
                            gvReceipts.DataSource = null;
                            gvReceipts.DataBind();
                        }

                        if (dsLadger.Tables.Count > 3 && dsLadger.Tables[3].Rows.Count > 0 && dsLadger.Tables[3].Rows[0]["TotalReceivedAmount"] != null)
                        {
                            lblTotalReceivedAmount.Text = Convert.ToString(Convert.ToDecimal(dsLadger.Tables[3].Rows[0]["TotalReceivedAmount"]) + Convert.ToDecimal(lblOpeningReceivedAmount.Text));
                        }
                        else
                            lblTotalReceivedAmount.Text = "0";

                        if (Convert.ToDecimal(lblTotalPayableAmuont.Text) > Convert.ToDecimal(lblTotalReceivedAmount.Text))
                        {
                            lblBalanceDueAmount.Text = Convert.ToString(Convert.ToDecimal(lblTotalPayableAmuont.Text) - Convert.ToDecimal(lblTotalReceivedAmount.Text));
                            lblBalaceCreditAmount.Text = "0";
                        }
                        else if (Convert.ToDecimal(lblTotalPayableAmuont.Text) < Convert.ToDecimal(lblTotalReceivedAmount.Text))
                        {
                            lblBalaceCreditAmount.Text = Convert.ToString(Convert.ToDecimal(lblTotalReceivedAmount.Text) - Convert.ToDecimal(lblTotalPayableAmuont.Text));
                            lblBalanceDueAmount.Text = "0";
                        }
                        else
                        {
                            lblBalaceCreditAmount.Text = "0";
                            lblBalanceDueAmount.Text = "0";
                        }
                    }
                }
                else
                {
                    trLedgerStatement.Visible = false;
                    trNoPropertyMessage.Visible = true;
                    trOpeningBalance.Visible = trGrids.Visible = trHrLine.Visible = trTotal.Visible = trBalance.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindProperty()
        {
            ddlSearchProperty.Items.Clear();

            if (ddlSearchProperty.SelectedValue != Guid.Empty.ToString())
            {
                DataSet dsProperty = SQT.Symphony.BusinessLogic.IRMS.BLL.InvestorsUnitBLL.SelectPropertyName(new Guid(Convert.ToString(Session["InvID"])), this.CompanyID);

                if (dsProperty.Tables[0].Rows.Count != 0)
                {
                    ddlSearchProperty.DataSource = dsProperty.Tables[0];
                    ddlSearchProperty.DataTextField = "PropertyName";
                    ddlSearchProperty.DataValueField = "PropertyID";
                    ddlSearchProperty.DataBind();
                    ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void PaymentReceipt_Grid()
        {

            Guid? propertyID = null;
            if (ddlSearchProperty.SelectedValue != Guid.Empty.ToString())
                propertyID = new Guid(ddlSearchProperty.SelectedValue);
            else
                propertyID = null;

            DataSet dsPaymentReceipt = InvestorPaymentReceiptBLL.SelectPaymentReceipt(new Guid(Convert.ToString(Session["InvID"])), propertyID);

            if (dsPaymentReceipt.Tables.Count > 0 && dsPaymentReceipt.Tables[0].Rows.Count > 0)
            {
                gvPaymentReceipt.DataSource = dsPaymentReceipt.Tables[0];
                gvPaymentReceipt.DataBind();
            }
            else
            {
                gvPaymentReceipt.DataSource = null;
                gvPaymentReceipt.DataBind();
            }

        }

        /// <summary>
        /// Load Report
        /// </summary>
        private void LoadReport()
        {
            try
            {
                string strPName = null;
                string strRNo = null;
                if (!txtPropertyName.Text.Equals(""))
                    strPName = txtPropertyName.Text.Trim();
                if (!txtUnitNo.Text.Equals(""))
                    strRNo = txtUnitNo.Text.Trim();
                if (txtPropertyName.Text.Trim() != "")
                    Session.Add("Name", Convert.ToString(txtPropertyName.Text.Trim()));
                if (txtUnitNo.Text.Trim() != "")
                    Session.Add("Unit", Convert.ToString(txtUnitNo.Text.Trim()));

                ds = InvestorBLL.GetPaymentList(new Guid(Convert.ToString(ViewState["InvestorID"])), null, strPName, strRNo);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Load_Ledger_Report()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                Guid investorID = new Guid(Convert.ToString(Session["InvID"]));
                Guid propertyID = new Guid(ddlLadgerProperty.SelectedValue.ToString());
                if (!ddlLadgerProperty.SelectedValue.Equals(Guid.Empty.ToString()))
                    Session.Add("Led_stmt_Property", Convert.ToString(ddlLadgerProperty.SelectedItem.Text));

                Investor inv = InvestorBLL.GetByPrimaryKey(investorID);
                Session.Add("Led_stmt_Investor", inv.Title + " " + inv.FName + " " + inv.LName);
                DateTime? dateFrom = null;
                DateTime? dateTo = null;

                if (txtLedgerDateFrom.Text.Trim() != string.Empty)
                {
                    dateFrom = DateTime.ParseExact(txtLedgerDateFrom.Text.Trim(), this.DateFormat, objCultureInfo);
                }

                if (txtLedgerToDate.Text.Trim() != string.Empty)
                {
                    dateTo = DateTime.ParseExact(txtLedgerToDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }
                Session.Add("Led_stmt_StartDate", dateFrom);
                Session.Add("Led_stmt_EndDate", dateTo);

                DataSet dsLadger = PaymentScheduleBLL.PaymentScheduleGetLadgerStatement(investorID, propertyID, dateFrom, dateTo);
                if (dsLadger != null && dsLadger.Tables.Count > 0)
                {

                    if (dsLadger.Tables.Count > 4 && dsLadger.Tables[4].Rows.Count > 0 && dsLadger.Tables[4].Rows[0]["TotalOpeningPayableAmount"] != null)
                    {
                        lblOpeningMilestoneAmount.Text = Convert.ToString(dsLadger.Tables[4].Rows[0]["TotalOpeningPayableAmount"]);
                    }
                    else
                        lblOpeningMilestoneAmount.Text = "0";

                    Session.Add("Led_stmt_OpeningBalance_MileStone", lblOpeningMilestoneAmount.Text);
                    if (dsLadger.Tables.Count > 5 && dsLadger.Tables[5].Rows.Count > 0 && dsLadger.Tables[5].Rows[0]["TotalOpeningReceivedAmount"] != null)
                    {
                        lblOpeningReceivedAmount.Text = Convert.ToString(dsLadger.Tables[5].Rows[0]["TotalOpeningReceivedAmount"]);
                    }
                    else
                        lblOpeningReceivedAmount.Text = "0";
                    Session.Add("Led_stmt_OpeningBalance_Receipt", lblOpeningReceivedAmount.Text);

                    if (dsLadger.Tables.Count > 1 && dsLadger.Tables[1].Rows.Count > 0 && dsLadger.Tables[1].Rows[0]["TotalPayableAmount"] != null)
                    {
                        lblTotalPayableAmuont.Text = Convert.ToString(Convert.ToDecimal(dsLadger.Tables[1].Rows[0]["TotalPayableAmount"]) + Convert.ToDecimal(lblOpeningMilestoneAmount.Text));
                    }
                    else
                        lblTotalPayableAmuont.Text = "0";

                    Session.Add("Led_stmt_Total_MileStone", lblTotalPayableAmuont.Text);

                    if (dsLadger.Tables.Count > 3 && dsLadger.Tables[3].Rows.Count > 0 && dsLadger.Tables[3].Rows[0]["TotalReceivedAmount"] != null)
                    {
                        lblTotalReceivedAmount.Text = Convert.ToString(Convert.ToDecimal(dsLadger.Tables[3].Rows[0]["TotalReceivedAmount"]) + Convert.ToDecimal(lblOpeningReceivedAmount.Text));
                    }
                    else
                        lblTotalReceivedAmount.Text = "0";
                    Session.Add("Led_stmt_Total_Rec", lblTotalReceivedAmount.Text);
                    if (Convert.ToDecimal(lblTotalPayableAmuont.Text) > Convert.ToDecimal(lblTotalReceivedAmount.Text))
                    {
                        lblBalanceDueAmount.Text = Convert.ToString(Convert.ToDecimal(lblTotalPayableAmuont.Text) - Convert.ToDecimal(lblTotalReceivedAmount.Text));
                        lblBalaceCreditAmount.Text = "0";
                    }
                    else if (Convert.ToDecimal(lblTotalPayableAmuont.Text) < Convert.ToDecimal(lblTotalReceivedAmount.Text))
                    {
                        lblBalaceCreditAmount.Text = Convert.ToString(Convert.ToDecimal(lblTotalReceivedAmount.Text) - Convert.ToDecimal(lblTotalPayableAmuont.Text));
                        lblBalanceDueAmount.Text = "0";
                    }
                    else
                    {
                        lblBalaceCreditAmount.Text = "0";
                        lblBalanceDueAmount.Text = "0";
                    }
                    Session.Add("Led_stmt_BalanceCredit", lblBalaceCreditAmount.Text);
                    Session.Add("Led_stmt_BalanceDue", lblBalanceDueAmount.Text);
                }

                Session["DataSource"] = dsLadger;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        protected void ibtnSearchLadger_Click(object sender, EventArgs e)
        {
            BindLadgerGrids();
        }

        protected void btnPropertySearch_Click(object sender, EventArgs e)
        {
            PaymentReceipt_Grid();
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Payment Information");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Payment Information");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Payment Information");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Payment Information");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Payment Information");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }

        protected void btnPrint_Ledger_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Ledger Statement");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            Load_Ledger_Report();
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
        }

        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreview_Ledger_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Ledger Statement");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            Load_Ledger_Report();
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
        }

        protected void imgbtnPDF_Ledger_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Ledger Statement");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            Load_Ledger_Report();
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
        }

        protected void imgbtnXLSX_Ledger_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Ledger Statement");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            Load_Ledger_Report();
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
        }

        protected void imgbtnDOC_Ledger_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Ledger Statement");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            Load_Ledger_Report();
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Server.MapPath("~/EmailTemplates/LedgerStatement.htm")))
                {
                    List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.CompanyID, Convert.ToString(this.CompanyID));
                    if (LstPrtConfig.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(LstPrtConfig[0]);
                        string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/LedgerStatement.htm"));

                        Guid InvestorID = new Guid(Convert.ToString(Session["InvID"]));
                        Investor objInvestor = InvestorBLL.GetByPrimaryKey(InvestorID);
                        if (objInvestor != null && Convert.ToString(objInvestor.EMail) != "")
                        {
                            if (Convert.ToString(objInvestor.LName) != "")
                                strHTML = strHTML.Replace("$INVESTORNAME$", Convert.ToString(objInvestor.Title + " " + objInvestor.FName + " " + objInvestor.LName));
                            else
                                strHTML = strHTML.Replace("$INVESTORNAME$", Convert.ToString(objInvestor.Title + " " + objInvestor.FName));

                            strHTML = strHTML.Replace("$PROPERTYNAME$", Convert.ToString(ddlLadgerProperty.SelectedItem.Text));
                            if (txtLedgerDateFrom.Text.Trim() != "")
                                strHTML = strHTML.Replace("$FROMDATE$", Convert.ToString(txtLedgerDateFrom.Text.Trim()));
                            else
                                strHTML = strHTML.Replace("$FROMDATE$", "-");
                            if (txtLedgerToDate.Text.Trim() != "")
                                strHTML = strHTML.Replace("$TODATE$", Convert.ToString(txtLedgerToDate.Text.Trim()));
                            else
                                strHTML = strHTML.Replace("$TODATE$", "-");

                            string strMileStone = string.Empty;
                            string strReceipt = string.Empty;

                            int milestonecount = Convert.ToInt32(gvMilestones.Rows.Count);
                            int receiptcount = Convert.ToInt32(gvReceipts.Rows.Count);

                            for (int i = 0; i < gvMilestones.Rows.Count; i++)
                            {
                                if (i == 0)
                                    strMileStone = "<table cellpadding=\"2\" cellspacing=\"2\" width=\"100%\"><tr><td width=\"20%\" style=\"vertical-align:top;\"><b>Due Date</b></td><td width=\"20%\" style=\"vertical-align:top;\"><b>Unit No.</b></td><td width=\"35%\" style=\"vertical-align:top;\"><b>Milestone title</b></td><td width=\"25%\" style=\"text-align:right; vertical-align:top;\"><b>Amount</b></td></tr>";

                                Label lblUnitNo = (Label)gvMilestones.Rows[i].FindControl("lblUnitNo");
                                Label lblMilestoneTitle = (Label)gvMilestones.Rows[i].FindControl("lblMilestoneTitle");
                                Label lblDueDate = (Label)gvMilestones.Rows[i].FindControl("lblDueDate");
                                Label lblAmountPayable = (Label)gvMilestones.Rows[i].FindControl("lblAmountPayable");

                                DateTime dtDueDate = Convert.ToDateTime(lblDueDate.Text.Trim());

                                strMileStone += "<tr><td style=\"vertical-align:top;\">" + Convert.ToString(dtDueDate.ToString(this.DateFormat)) + "</td><td style=\"vertical-align:top;\">" + Convert.ToString(lblUnitNo.Text.Trim()) + "</td><td style=\"vertical-align:top;\">" + Convert.ToString(lblMilestoneTitle.Text.Trim()) + "</td><td align=\"right\" style=\"vertical-align:top; text-align:right; \">" + Convert.ToString(lblAmountPayable.Text.Trim()) + "</td></tr>";


                                if (i == milestonecount - 1)
                                    strMileStone += "</table>";
                            }

                            for (int j = 0; j < gvReceipts.Rows.Count; j++)
                            {
                                if (j == 0)
                                    strReceipt = "<table cellpadding=\"2\" cellspacing=\"2\" width=\"100%\"><tr><td width=\"36%\" style=\"vertical-align:top;\"><b>Date</b></td><td width=\"30%\" style=\"vertical-align:top;\"><b>Receipt No</b></td><td width=\"34%\" style=\"vertical-align:top; text-align:right; \"><b>Amount</b></td></tr>";

                                Label lblReceiptNo = (Label)gvReceipts.Rows[j].FindControl("lblReceiptNo");
                                Label lblPaidAmount = (Label)gvReceipts.Rows[j].FindControl("lblPaidAmount");
                                Label lblDate = (Label)gvReceipts.Rows[j].FindControl("lblDate");

                                DateTime dtDate = Convert.ToDateTime(lblDate.Text);

                                strReceipt += "<tr><td style=\"vertical-align:top;\">" + Convert.ToString(dtDate.ToString(this.DateFormat)) + "</td><td style=\"vertical-align:top;\">" + Convert.ToString(lblReceiptNo.Text.Trim()) + "</td><td style=\"vertical-align:top; text-align:right; \">" + Convert.ToString(lblPaidAmount.Text.Trim()) + "</td></tr>";


                                if (j == receiptcount - 1)
                                    strReceipt += "</table>";
                            }

                            if (strMileStone == string.Empty)
                                strHTML = strHTML.Replace("$MILESTONE$", "No Record Found");
                            else
                                strHTML = strHTML.Replace("$MILESTONE$", strMileStone);

                            if (strReceipt == string.Empty)
                                strHTML = strHTML.Replace("$RECEIPT$", "No Record Found");
                            else
                                strHTML = strHTML.Replace("$RECEIPT$", strReceipt);

                            strHTML = strHTML.Replace("$MILESTONEOPENINGBALANCE$", Convert.ToString(lblOpeningMilestoneAmount.Text.Trim()));
                            strHTML = strHTML.Replace("$RECEIPTOPENINGBALANCE$", Convert.ToString(lblOpeningReceivedAmount.Text.Trim()));
                            strHTML = strHTML.Replace("$MILESTONETOTAL$", Convert.ToString(lblTotalPayableAmuont.Text.Trim()));
                            strHTML = strHTML.Replace("$RECEIPTTOTAL$", Convert.ToString(lblTotalReceivedAmount.Text.Trim()));
                            strHTML = strHTML.Replace("$BALANCECREDIT$", Convert.ToString(lblBalaceCreditAmount.Text.Trim()));
                            strHTML = strHTML.Replace("$BALANCEDUE$", Convert.ToString(lblBalanceDueAmount.Text.Trim()));

                            strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));

                            SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), Convert.ToString(objInvestor.EMail), "Ledger Statement", strHTML);
                            IsEmail = true;
                            lblEmailMsg.Text = "Email Send Successfully.";
                        }
                        else
                        {
                            MessageBox.Show("System cannot send ledger statement as E-mail Id is not specified for this investor.");
                        }
                    }
                    else
                        MessageBox.Show("Please set Company email configuration");
                }
                else
                    MessageBox.Show("Sorry for inconvenience, System can't send mail to your account.");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Grid Row DAta Bound Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void grdInvestorPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double TotalPurValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
                //double PaidAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PaidAmount"));

                LinkButton lnkbtnUnitInfo = (LinkButton)e.Row.FindControl("lnkbtnUnitInfo");
                lnkbtnUnitInfo.Enabled = Convert.ToBoolean(ViewState["View"]);

                //if (TotalPurValue == PaidAmount)
                //    e.Row.BackColor = System.Drawing.Color.Lime; 

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal litPurchaseAmount = (Literal)e.Row.FindControl("litPurchaseAmount");
                //Literal litAmountPaid = (Literal)e.Row.FindControl("litAmountPaid");

                if (litPurchaseAmount != null)
                {
                    litPurchaseAmount.Text = Convert.ToString(PurchaseAmountTotal);
                }

                //if (litAmountPaid != null)
                //{
                //    litAmountPaid.Text = Convert.ToString(AmountPaidTotal);
                //}
            }
        }
        /// <summary>
        /// Grid Row Command
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void grdInvestorPaymentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                string[] strID = e.CommandArgument.ToString().Split(new char[] { ',' }); ;
                if (strID.Length == 1)
                    Response.Redirect("~/Applications/Investors/InvestorPaymentDetilas.aspx?Val=True&InvRm=" + Convert.ToString(strID[0]));
                else if (strID.Length == 2)
                    Response.Redirect("~/Applications/Investors/InvestorPaymentDetilas.aspx?Val=True&InvRm=" + Convert.ToString(strID[0]) + "&PRID=" + Convert.ToString(strID[1]));
            }
        }

        protected void gvMilestones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //double TotalPurValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));

                //LinkButton lnkbtnUnitInfo = (LinkButton)e.Row.FindControl("lnkbtnUnitInfo");
                //lnkbtnUnitInfo.Enabled = Convert.ToBoolean(ViewState["View"]);
                ((Label)e.Row.FindControl("lblDueDate")).Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DueDate")).ToString(this.DateFormat);
            }
        }

        protected void gvReceipts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //double TotalPurValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));

                //LinkButton lnkbtnUnitInfo = (LinkButton)e.Row.FindControl("lnkbtnUnitInfo");
                //lnkbtnUnitInfo.Enabled = Convert.ToBoolean(ViewState["View"]);
                ((Label)e.Row.FindControl("lblDate")).Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DateToPay")).ToString(this.DateFormat);
            }
        }

        protected void gvPaymentReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton imgViewDoc = (ImageButton)e.Row.FindControl("imgViewDoc");

                    imgViewDoc.ToolTip = "Click to View/Download";
                    if (DataBinder.Eval(e.Row.DataItem, "DocumentName") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DocumentName")) != string.Empty)
                        imgViewDoc.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPaymentReceipt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("VIEWDOC"))
                {
                    string fName = Server.MapPath("~/Document") + "\\" + Convert.ToString(e.CommandArgument);
                    FileInfo fi = new FileInfo(fName);
                    long sz = fi.Length;
                    Response.ClearContent();
                    Response.ContentType = MimeType(Path.GetExtension(fName));
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fName)));
                    Response.AddHeader("Content-Length", sz.ToString("F0"));
                    Response.TransmitFile(fName);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        } 

        #endregion Grid Event
    }
}