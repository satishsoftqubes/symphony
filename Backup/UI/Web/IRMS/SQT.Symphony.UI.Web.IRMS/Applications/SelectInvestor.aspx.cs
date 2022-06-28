using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.Applications
{
    public partial class SelectInvestor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsInvestors = InvestorBLL.GetCoOrdinators("INVESTORSDATA",new Guid(Convert.ToString(Session["InvID"])));
                if (dsInvestors != null && dsInvestors.Tables.Count > 0 && dsInvestors.Tables[0].Rows.Count > 0)
                {
                    if (dsInvestors.Tables[0].Rows.Count > 1)
                    {
                        //this investor is CoOrdinator of some investor(s), so give selection option.
                        ucSelectInvestor.BindCoOrdinatorWithInvestors(dsInvestors);
                    }
                    else
                    {
                        Response.Redirect("~/Applications/investordashboard.aspx");
                    }
                }                
            }
        }
    }
}