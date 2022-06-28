using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.IRServices
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SrvcInvestorList.InvestorList objInvList = new SrvcInvestorList.InvestorList();
                SrvcInvestorList.InvestorListSoapClient objClient = new SrvcInvestorList.InvestorListSoapClient();
                DataSet ds = objClient.GetInvestorListWihtXML();
            }
        }
    }
}
