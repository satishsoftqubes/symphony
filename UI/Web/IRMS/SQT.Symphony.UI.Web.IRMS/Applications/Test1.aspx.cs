using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik;

namespace SQT.Symphony.UI.Web.IRMS.Applications
{
    public partial class Test1 : System.Web.UI.Page
    {
        #region Property and variables
        int intTotalInterestEarned = 0;
        int intTotalAmountAdded = 0;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvCalculator.ActiveViewIndex = 0;
            }
        }
        #endregion

        #region Private Method
        private void BindGrid()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("StartDate");
            DataColumn dc2 = new DataColumn("Amt4Interest");
            DataColumn dc3 = new DataColumn("InterestAmt");
            DataColumn dc4 = new DataColumn("TotalAmtAtBank");
            DataColumn dc5 = new DataColumn("AmtToAdd");

            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);

            int intNoOfYears = Convert.ToInt32(txtNoOfYears.Text.Trim()) + 1;
            decimal dcmlInterest = Math.Round(Convert.ToDecimal(txtInterest.Text.Trim()), 2);
            int intAmountToAdd = Convert.ToInt32(txtAmtToAddEveryYear.Text.Trim());
            int intYear = 2015;
            DateTime dtDate = Convert.ToDateTime(intYear.ToString() + "-01-01");

            for (int i = 0; i < intNoOfYears; i++)
            {
                DataRow dr = null;
                int intAmoutToCalInterest = 0;
                int intInterestAmt = 0;

                if (i != 0)
                {
                    intAmoutToCalInterest = Convert.ToInt32(Convert.ToString(dtTable.Rows[i - 1]["TotalAmtAtBank"])) + intAmountToAdd;
                }

                intInterestAmt = Convert.ToInt32((intAmoutToCalInterest * dcmlInterest) / 100);

                dr = dtTable.NewRow();
                dr["StartDate"] = dtDate.ToString("dd-MM-yyyy");
                dr["Amt4Interest"] = intAmoutToCalInterest.ToString();
                dr["InterestAmt"] = intInterestAmt.ToString();
                dr["TotalAmtAtBank"] = (intAmoutToCalInterest + intInterestAmt).ToString();

                if (i == 1 && !chkIsAmtToAddEveryYear.Checked)
                {
                    intAmountToAdd = 0;
                }

                if (i < (intNoOfYears - 1))
                {
                    dr["AmtToAdd"] = intAmountToAdd.ToString();
                    intTotalAmountAdded = intTotalAmountAdded + intAmountToAdd;
                }
                else
                    dr["AmtToAdd"] = "0";

                dtTable.Rows.Add(dr);

                intYear++;
                dtDate = Convert.ToDateTime(intYear.ToString() + "-01-01");

                intTotalInterestEarned = intTotalInterestEarned + intInterestAmt;

            }

            grdInvestorList.DataSource = dtTable;
            grdInvestorList.DataBind();
        }
        #endregion

        #region Control Event
        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnGo2ITCalc_Click(object sender, EventArgs e)
        {
            mvCalculator.ActiveViewIndex = 1;
        }

        protected void btnITCalcGo_Click(object sender, EventArgs e)
        {
            int intIncomeAmount = 0;
            int intSavingAmount = 0;
            int intAmount2CalTax = 0;
            int intTaxAmount = 0;
            intIncomeAmount = txtYearlyIncome.Text.Trim() != string.Empty ? Convert.ToInt32(txtYearlyIncome.Text.Trim()) : 0;
            intSavingAmount = txtYearlySaving.Text.Trim() != string.Empty ? Convert.ToInt32(txtYearlySaving.Text.Trim()) : 0;

            if (intIncomeAmount <= 200000)
            {
                lblYearlyIncomeToDisplay.Text = intIncomeAmount.ToString();
                lblIncomeTaxAmount.Text = intTaxAmount.ToString();
                lblNetIncome.Text = (intIncomeAmount - intTaxAmount).ToString();
            }
            else if (intIncomeAmount > 200000 && intIncomeAmount <= 500000)
            {
                intAmount2CalTax = intIncomeAmount - intSavingAmount;
                intAmount2CalTax = intAmount2CalTax - 200000;

                if (intAmount2CalTax < 0)
                    intAmount2CalTax = 0;

                intTaxAmount = (intAmount2CalTax * 10) / 100;

                lblYearlyIncomeToDisplay.Text = intIncomeAmount.ToString();
                lblIncomeTaxAmount.Text = intTaxAmount.ToString();
                lblNetIncome.Text = (intIncomeAmount - intTaxAmount).ToString();
            }
            else if (intIncomeAmount > 500000 && intIncomeAmount <= 1000000)
            {
                intAmount2CalTax = intIncomeAmount - intSavingAmount;
                intAmount2CalTax = intAmount2CalTax - 500000;

                if (intAmount2CalTax < 0)
                    intAmount2CalTax = 0;

                intTaxAmount = ((intAmount2CalTax * 20) / 100) + 30000;

                lblYearlyIncomeToDisplay.Text = intIncomeAmount.ToString();
                lblIncomeTaxAmount.Text = intTaxAmount.ToString();
                lblNetIncome.Text = (intIncomeAmount - intTaxAmount).ToString();
            }
            else
            {
                intAmount2CalTax = intIncomeAmount - intSavingAmount;
                intAmount2CalTax = intAmount2CalTax - 1000000;

                if (intAmount2CalTax < 0)
                    intAmount2CalTax = 0;

                intTaxAmount = ((intAmount2CalTax * 30) / 100) + 130000;

                lblYearlyIncomeToDisplay.Text = intIncomeAmount.ToString();
                lblIncomeTaxAmount.Text = intTaxAmount.ToString();
                lblNetIncome.Text = (intIncomeAmount - intTaxAmount).ToString();
            }
        }
        #endregion

        #region Grid Event
        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    //string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Literal litFtrTotalInterestEarned = (Literal)e.Row.FindControl("litFtrTotalInterestEarned");
                    Literal litFtrTotalAmountAdded = (Literal)e.Row.FindControl("litFtrTotalAmountAdded");

                    litFtrTotalInterestEarned.Text = intTotalInterestEarned.ToString();
                    litFtrTotalAmountAdded.Text = intTotalAmountAdded.ToString();

                }
            }
            catch (Exception ex)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }
        #endregion
    }
}