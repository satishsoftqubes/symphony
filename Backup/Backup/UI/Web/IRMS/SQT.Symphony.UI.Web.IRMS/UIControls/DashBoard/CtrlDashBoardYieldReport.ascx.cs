using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard
{
    public partial class CtrlDashBoardYieldReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRentYieldQuarters();
            }
        }

        public void BindRentYieldQuarters()
        {
            DataSet dsQuarterIncome = RentPayoutQuarterSetupBLL.RentPayoutQuarterSetupTop4QuarterWithIncome();
            if (dsQuarterIncome != null && dsQuarterIncome.Tables[0].Rows.Count > 0)
            {
                gvRentYieldQuarterList.DataSource = dsQuarterIncome.Tables[0];
                gvRentYieldQuarterList.DataBind();
            }
            else
            {
                gvRentYieldQuarterList.DataSource = dsQuarterIncome.Tables[0];
                gvRentYieldQuarterList.DataBind();
            }
        }

        protected void gvRentYieldQuarterList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("GOTOINVSPAGE"))
                {
                    Response.Redirect("~/Applications/Activity/RentPayout.aspx?Qtr=" + Convert.ToString(e.CommandArgument));
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        
    }
}