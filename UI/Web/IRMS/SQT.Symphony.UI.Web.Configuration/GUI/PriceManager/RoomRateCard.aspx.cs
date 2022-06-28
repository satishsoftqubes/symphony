using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.Configuration.GUI.PriceManager
{
    public partial class RoomRateCard : CommonPages.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DisplayRackRate(string message)
        {
            ucRoomRateCard.CalculateRackRateCharge(message);
        }
    }
}