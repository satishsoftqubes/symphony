using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.IRMS.Applications.Reports
{
    public partial class RPTPaymentScheduleReport : Symphony.UI.Web.IRMS.CommonPages.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {
                if (RoleRightJoinBLL.GetAccessString("RPTPaymentScheduleReport.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
            }
        }
    }
}