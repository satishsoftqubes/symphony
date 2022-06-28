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

namespace SQT.Symphony.UI.Web.IRMS.Applications.Activity
{
    public partial class InvestorRentPayoutPrint : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["QuarterIDForInvPrint"] != null && Convert.ToString(Session["QuarterIDForInvPrint"]) != "")
                {
                    this.QuarterID = new Guid(Convert.ToString(Session["QuarterIDForInvPrint"]));
                }

                if (Session["InvID"] != null)
                {
                    this.InvestorID = new Guid(Convert.ToString(Session["InvID"]));
                }
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                }
                this.DateFormat = "dd-MM-yyyy";
                BindRentPayoutDataByQuarter();
            }
        }
        #region Private Method
        private void ClearDetailControl()
        {
            this.QuarterID = Guid.Empty;
            NoOfDays = 0;
            PropertymgmtPercentage = string.Empty;
            litDisplayRentYieldPerDay.Text = litDisplayRentYieldPerSFT.Text = litDisplaySelfOccupiedArea.Text = litDisplayTotalAreaOfComplex.Text = litDispTotalAmountTodistribute.Text = litDisplayLessPropertyManegefees.Text = litDisplayNetAreaUnderPMS.Text = litDisplayRentToDistributed.Text = litDisplayRoomRentForPeriod.Text = litDispInterestOnRoomRent.Text = "0.00";
        }
        public void BindRentPayoutGrid()
        {
            ////More Search
            DataSet dsForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, this.InvestorID, this.QuarterID, false,null,null,null,null);
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
        private void BindRentPayoutDataByQuarter()
        {
            if (Session["QuarterIDForInvPrint"] != null && Convert.ToString(Session["QuarterIDForInvPrint"]) != "")
            {
                ClearDetailControl();
                this.QuarterID = new Guid(Convert.ToString(Session["QuarterIDForInvPrint"]));
                RentPayoutQuarterSetup objRentPauoutData = new RentPayoutQuarterSetup();
                objRentPauoutData = RentPayoutQuarterSetupBLL.GetByPrimaryKey(this.QuarterID);
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                int intNoOfDays;
                BindRentPayoutGrid();
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
                        lblRemainingRoomRent.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RemainingRoomRent)).ToString();

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
                    }
                    Session["QuarterIDForInvPrint"] = null;
                }
            }
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
        protected void btnBackToQuarterList_Click(object sender, EventArgs e)
        {

        }
        #endregion Private Method
    }
}