using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.Configuration.GUI.PriceManager
{
    public partial class CorporateRateCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DisplayRackRate(string message)
        {
            ucCorporateRateCard.CalculateRackRateCharge(message);
        }
    }
}