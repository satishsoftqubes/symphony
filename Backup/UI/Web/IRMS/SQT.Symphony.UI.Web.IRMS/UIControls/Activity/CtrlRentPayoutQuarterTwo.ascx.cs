using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;
using System.Text;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlRentPayoutQuarterTwo : System.Web.UI.UserControl
    {
        #region Property and Variable
        public bool IsInsert = false;
        decimal dblTotalSqft = 0;
        decimal dblTotalYieldAmount = 0;
        public bool IsInsertForDetails = false;
        public bool IsToHideDateImages = false;
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
        public int NoOfDays
        {
            get
            {
                return ViewState["NoOfDays"] != null ? Convert.ToInt32(ViewState["NoOfDays"]) : 0;
            }
            set
            {
                ViewState["NoOfDays"] = value;
            }
        }
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
        public Guid InvestorID
        {
            get
            {
                return ViewState["InvestorID"] != null ? new Guid(Convert.ToString(ViewState["InvestorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InvestorID"] = value;
            }
        }
        public Guid QuarterID
        {
            get
            {
                return ViewState["QuarterID"] != null ? new Guid(Convert.ToString(ViewState["QuarterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["QuarterID"] = value;
            }
        }
        public Guid QuarterIDForHeader
        {
            get
            {
                return ViewState["QuarterID"] != null ? new Guid(Convert.ToString(ViewState["QuarterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["QuarterID"] = value;
            }
        }
        public string PropertymgmtPercentage
        {
            get
            {
                return ViewState["PropertymgmtPercentage"] != null ? Convert.ToString(ViewState["PropertymgmtPercentage"]) : string.Empty;
            }
            set
            {
                ViewState["PropertymgmtPercentage"] = value;
            }
        }
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.DateFormat = "dd-MM-yyyy";
                    if (Session["CompanyID"] != null)
                    {
                        this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    }
                    if (Session["InvID"] != null)
                    {
                        this.InvestorID = new Guid(Convert.ToString(Session["InvID"]));
                    }
                    BindRentPayoutQuarterInfo();
                    mvRentPayout.ActiveViewIndex = 1;

                    if (Request["Qtr"] != null)
                    {
                        this.QuarterID = new Guid(Convert.ToString(Request["Qtr"]));

                        if (this.QuarterID.ToString().ToUpper() != "447A57B9-3075-44F0-B740-64128DD470B3")
                        {
                            if (Request["Val"] != null && Convert.ToString(Request["Val"]).ToUpper() == "TRUE")
                                Response.Redirect("~/Applications/Activity/RentPayout.aspx?Val=True&Qtr=" + this.QuarterID.ToString());
                            else
                                Response.Redirect("~/Applications/Activity/RentPayout.aspx?Qtr=" + this.QuarterID.ToString());
                        }

                        BindInvestorsQuarterDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Page Load

        #region Private Method
        private void BindRentPayoutQuarterInfo()
        {
            DataSet dsForRentPayoutInfo = RentPayoutQuarterSetupBLL.GetAllWithDataSet();
            if (dsForRentPayoutInfo != null && dsForRentPayoutInfo.Tables.Count > 0 && dsForRentPayoutInfo.Tables[0].Rows.Count > 0)
            {
                DataView dvForRentPayout = new DataView(dsForRentPayoutInfo.Tables[0]);
                dvForRentPayout.Sort = "StartDate asc";
                dlRentPayOutQuarter.DataSource = dvForRentPayout;
                dlRentPayOutQuarter.DataBind();
            }
        }
        private void BindGrid()
        {
            DataTable dtAvailability = new DataTable();

            DataColumn dc1 = new DataColumn("Year");



            dtAvailability.Columns.Add(dc1);


            DataRow dr1 = dtAvailability.NewRow();
            dr1["Year"] = "FY 2012-2013";


            dtAvailability.Rows.Add(dr1);

            DataRow dr2 = dtAvailability.NewRow();
            dr2["Year"] = "FY 2013-2014";
            dtAvailability.Rows.Add(dr2);


            gvRentPayout.DataSource = dtAvailability;
            gvRentPayout.DataBind();

            BindChildGrid();
        }

        public void BindChildGrid()
        {
            foreach (GridViewRow gvi in gvRentPayout.Rows)
            {
                GridView gvInnerGridRentPayout = (GridView)(gvi.FindControl("gvInnerGridRentPayout"));

                DataTable dtTableInnderGrid = new DataTable();

                DataColumn dc1 = new DataColumn("Q1");
                DataColumn dc2 = new DataColumn("Q2");
                DataColumn dc3 = new DataColumn("Q3");
                DataColumn dc4 = new DataColumn("Q4");


                dtTableInnderGrid.Columns.Add(dc1);
                dtTableInnderGrid.Columns.Add(dc2);
                dtTableInnderGrid.Columns.Add(dc3);
                dtTableInnderGrid.Columns.Add(dc4);


                int i = Convert.ToInt32(gvi.RowIndex);

                if (i == 0)
                {

                    DataRow dr1 = dtTableInnderGrid.NewRow();
                    dr1["Q1"] = "01-Apr-2012 to 30-Jun-2012";
                    dr1["Q2"] = "01-Jul-2012 to 30-Sep-2012";
                    dr1["Q3"] = "01-Oct-2012 to 31-Dec-2010";
                    dr1["Q4"] = "01-Jan-2013 to 31-Mar-2013";

                    dtTableInnderGrid.Rows.Add(dr1);



                }
                else if (i == 1)
                {

                    DataRow dr2 = dtTableInnderGrid.NewRow();
                    dr2["Q1"] = "01-Apr-2013 to 30-Jun-2013";
                    dr2["Q2"] = "01-Jul-2013 to 30-Sep-2013";
                    dr2["Q3"] = "01-Oct-2013 to 31-Dec-2013";
                    dr2["Q4"] = "01-Jan-2014 to 31-Mar-2014";

                    dtTableInnderGrid.Rows.Add(dr2);


                }

                gvInnerGridRentPayout.DataSource = dtTableInnderGrid;
                gvInnerGridRentPayout.DataBind();

            }
        }

        public void BindRentPayoutGrid()
        {
            DataSet dsForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, this.InvestorID, this.QuarterID, false, null, null, null, null);
            if (dsForRentPayout != null && dsForRentPayout.Tables.Count > 0 && dsForRentPayout.Tables[0] != null && dsForRentPayout.Tables[0].Rows.Count > 0)
            {
                decimal TotalSFT = 0;
                decimal TotalYieldAmount = 0;

                TotalSFT = (decimal)dsForRentPayout.Tables[0].Compute("sum(TotalSqft)", "InvName IS NOT NULL");
                TotalYieldAmount = (decimal)dsForRentPayout.Tables[0].Compute("sum(YieldAmount)", "InvName IS NOT NULL");
                dblTotalSqft = TotalSFT;
                dblTotalYieldAmount = TotalYieldAmount;
                //TotalYieldAmount
            }
            gvAdminRendPayoutDetails.DataSource = dsForRentPayout;
            gvAdminRendPayoutDetails.DataBind();

        }

        #endregion


        protected void dlRentPayOutQuarter_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    LinkButton lnkToViewQuarterDetail = (LinkButton)e.Item.FindControl("lnkToViewQuarterDetail");
                    if (DataBinder.Eval(e.Item.DataItem, "StartDate") != null && Convert.ToString(DataBinder.Eval(e.Item.DataItem, "StartDate")) != "" && DataBinder.Eval(e.Item.DataItem, "EndDate") != null && Convert.ToString(DataBinder.Eval(e.Item.DataItem, "EndDate")) != "")
                    {
                        lnkToViewQuarterDetail.Text = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "StartDate")).ToString(this.DateFormat) + " to " + Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "EndDate")).ToString(this.DateFormat);
                    }
                    else
                    {
                        lnkToViewQuarterDetail.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearDetailControl()
        {
            this.QuarterID = Guid.Empty;
            NoOfDays = 0;
            PropertymgmtPercentage = string.Empty;


            litDisplayRentYieldPerDay.Text = litDisplayRentYieldPerSFT.Text = litDisplaySelfOccupiedArea.Text = litDisplayTotalAreaOfComplex.Text = litDispTotalAmountTodistribute.Text = litDisplayLessPropertyManegefees.Text = litDisplayNetAreaUnderPMS.Text = litDisplayRentToDistributed.Text = litDisplayRoomRentForPeriod.Text = litDispInterestOnRoomRent.Text = "0.00";
        }
        protected void dlRentPayOutQuarter_ItemCommand(Object sender, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("QUARTERDETAILS") && e.CommandArgument != null && Convert.ToString(e.CommandArgument) != string.Empty)
                {
                    ClearDetailControl();
                    this.QuarterID = new Guid(e.CommandArgument.ToString());

                    BindInvestorsQuarterDetail();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void BindInvestorsQuarterDetail()
        {
            RentPayoutQuarterSetup objRentPauoutData = new RentPayoutQuarterSetup();
            objRentPauoutData = RentPayoutQuarterSetupBLL.GetByPrimaryKey(this.QuarterID);
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            int intNoOfDays;
            BindRentPayoutGrid();

            Documents doc = new Documents();
            doc.AssociationID = this.QuarterID;
            doc.AssociationType = "Quarter Certificate";
            doc.IsActive = true;

            List<Documents> lstDocs = DocumentsBLL.GetAll(doc);
            if (lstDocs != null && lstDocs.Count > 0)
            {
                string str = "~/Document/" + lstDocs[0].DocumentName;
                ancViewCertificate.HRef = str;
            }
            else
                ancViewCertificate.Visible = false;

            if (objRentPauoutData.StartDate != null && Convert.ToString(objRentPauoutData.StartDate) != "" && objRentPauoutData.EndDate != null && Convert.ToString(objRentPauoutData.EndDate) != "")
            {
                DateTime dtStartDate = Convert.ToDateTime(objRentPauoutData.StartDate);
                litDisplayPeriodFrom.Text = Convert.ToDateTime(objRentPauoutData.StartDate).ToString(this.DateFormat);
                DateTime dtEndDate = Convert.ToDateTime(objRentPauoutData.EndDate);
                litDisplayTo.Text = Convert.ToDateTime(objRentPauoutData.EndDate).ToString(this.DateFormat);
                intNoOfDays = (Convert.ToInt32((dtEndDate - dtStartDate).TotalDays));
                NoOfDays = intNoOfDays + 1;
                litNoOfays.Text = "No of Days : " + Convert.ToString(intNoOfDays + 1);

                List<RentPayOutPerQuarter> objRentPerPauoutData = RentPayOutPerQuarterBLL.GetAllBy(RentPayOutPerQuarter.RentPayOutPerQuarterFields.QuarterID, Convert.ToString(this.QuarterID));
                if (objRentPerPauoutData.Count > 0)
                {
                    litDisplayTotalAreaOfComplex.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].TotalAreaOfComplex)).ToString(); //Convert.ToString(objRentPerPauoutData[0].TotalAreaOfComplex).Substring(0, Convert.ToString(objRentPerPauoutData[0].TotalAreaOfComplex).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDisplaySelfOccupiedArea.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].SelfOccupiedArea)).ToString(); //Convert.ToString(objRentPerPauoutData[0].SelfOccupiedArea).Substring(0, Convert.ToString(objRentPerPauoutData[0].SelfOccupiedArea).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDisplayNetAreaUnderPMS.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].AreaUnderPMS)).ToString(); //Convert.ToString(objRentPerPauoutData[0].AreaUnderPMS).Substring(0, Convert.ToString(objRentPerPauoutData[0].AreaUnderPMS).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDisplayRoomRentForPeriod.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RoomRentCollected)).ToString(); //Convert.ToString(objRentPerPauoutData[0].RoomRentCollected).Substring(0, Convert.ToString(objRentPerPauoutData[0].RoomRentCollected).LastIndexOf(".") + 1 + Convert.ToInt16("2"));

                    litDisppropertymangeper.Text = Convert.ToString(objRentPauoutData.PropertyManagementCharge); //PropertymgmtPercentage.Substring(0, PropertymgmtPercentage.LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDispInterestOnRoomRent.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].InterestOnRoomRent)).ToString(); //Convert.ToString(objRentPerPauoutData[0].InterestOnRoomRent).Substring(0, Convert.ToString(objRentPerPauoutData[0].InterestOnRoomRent).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDispTotalAmountTodistribute.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].TotalAmountToDistribute)).ToString(); //Convert.ToString(objRentPerPauoutData[0].TotalAmountToDistribute).Substring(0, Convert.ToString(objRentPerPauoutData[0].TotalAmountToDistribute).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDisplayLessPropertyManegefees.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].PropertyManagementCharge)).ToString(); //Convert.ToString(objRentPerPauoutData[0].PropertyManagementCharge).Substring(0, Convert.ToString(objRentPerPauoutData[0].PropertyManagementCharge).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    ltrServiceTax.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].ServiceTax)).ToString();
                    ltrBankCharges.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].BankCharges)).ToString();
                    ltrTotalAmountToDeduct.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].TotalAmountToDeduct)).ToString();
                    litDisplayRentToDistributed.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].NetAmountToDistribute)).ToString(); //Convert.ToString(objRentPerPauoutData[0].NetAmountToDistribute).Substring(0, Convert.ToString(objRentPerPauoutData[0].NetAmountToDistribute).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDisplayRentYieldPerSFT.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RentYieldPerSqft), 3).ToString(); //Convert.ToString(objRentPerPauoutData[0].RentYieldPerSqft).Substring(0, Convert.ToString(objRentPerPauoutData[0].RentYieldPerSqft).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    litDisplayRentYieldPerDay.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RentYieldPerDay), 3).ToString(); //Convert.ToString(objRentPerPauoutData[0].RentYieldPerDay).Substring(0, Convert.ToString(objRentPerPauoutData[0].RentYieldPerDay).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    mvRentPayout.ActiveViewIndex = 2;
                    return;
                }
                else
                {
                    mvRentPayout.ActiveViewIndex = 2;
                }
            }
        }

        protected void btnBackToQuarterList_Click(object sender, EventArgs e)
        {
            if (Request["Val"] != null && Convert.ToString(Request["Val"]).ToUpper() == "TRUE")
                Response.Redirect("~/Applications/Activity/RentPayout.aspx?Val=True");
            else
                Response.Redirect("~/Applications/Activity/RentPayout.aspx");
        }
        protected void gvAdminRendPayoutDetails_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal litTotalSFT = (Literal)e.Row.FindControl("litTotalSFT");
                Literal litTotalYieldAmount = (Literal)e.Row.FindControl("litTotalYieldAmount");

                if (litTotalSFT != null)
                {
                    litTotalSFT.Text = Convert.ToString(dblTotalSqft.ToString().Substring(0, dblTotalSqft.ToString().LastIndexOf(".") + 1 + 2));
                }
                if (litTotalYieldAmount != null)
                {
                    litTotalYieldAmount.Text = Convert.ToString(dblTotalYieldAmount.ToString().Substring(0, dblTotalYieldAmount.ToString().LastIndexOf(".") + 1 + 2));
                }

            }
        }
        protected void gvRentPayout_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mvRentPayout.ActiveViewIndex = 1;
            string strval = Convert.ToString(e.CommandArgument);

            StringBuilder sb = new StringBuilder();
            sb.Append(strval);
            sb.Replace("to", "|");

            string str = Convert.ToString(sb);

            string[] strResults = str.Split('|');

            litDisplayPeriodFrom.Text = strResults[0];
            litDisplayTo.Text = strResults[1];
            BindRentPayoutGrid();
        }

        protected void btnRentPayoutDetailsCancel_Click(object sender, EventArgs e)
        {
            mvRentPayout.ActiveViewIndex = 0;
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["QuarterIDForInvPrint"] = this.QuarterID;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewerForPrint();", true);
        }
    }
}