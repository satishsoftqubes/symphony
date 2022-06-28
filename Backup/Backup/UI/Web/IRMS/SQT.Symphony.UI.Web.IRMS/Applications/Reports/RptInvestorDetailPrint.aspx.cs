using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.Applications.Reports
{
    public partial class RptInvestorDetailPrint : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindinvestorDetailGrid();
            }
        }
        #endregion Page Load

        #region Private Method 
        private void BindinvestorDetailGrid()
        {
            string BankName = "";
            Guid? InvestorID = null;
            if (Session["InvestorIDForPrint"] != null)
                InvestorID = new Guid(Convert.ToString(Session["InvestorID"]));
            else
                InvestorID = null;

            if (Convert.ToString(Session["BankNameForPrint"]) != "")
                BankName = Convert.ToString(Session["BankName"]);
            else
                BankName = "";

            DataSet dsForInvDetailGrid = InvestorBLL.GetInvestorDetailReportData(new Guid(Convert.ToString(Session["CompanyID"])), InvestorID, BankName);

            if (dsForInvDetailGrid != null && dsForInvDetailGrid.Tables.Count > 0 && dsForInvDetailGrid.Tables[0].Rows.Count > 0)
            {
                gvInvestorDetailInformation.DataSource = dsForInvDetailGrid.Tables[0];
                gvInvestorDetailInformation.DataBind();

            }
            else
                gvInvestorDetailInformation.DataSource = null;


            Session["InvestorIDForPrint"] = null;
            Session["BankNameForPrint"] = null;
        }
        protected void gvInvestorDetailInformation_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInvestorDetailInformation.PageIndex = e.NewPageIndex;
            BindinvestorDetailGrid();
        }
        #endregion Pricate Method
    }
}