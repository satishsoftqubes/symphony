using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlUnitBooking : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtInvestorName.Text = Convert.ToString(Session["User"]);
                if (Session["InvID"] == null)
                    txtInvestorName.Text = "INFORMATION";
                else
                {
                    Investor Inv = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["InvID"])));
                    if (Inv != null)
                        txtInvestorName.Text = Inv.Title + " " + Inv.FName + " " + Inv.LName;
                    Random rdBookingVoucherNo = new Random();

                    txtBookingVoucherNo.Text = rdBookingVoucherNo.Next(1, 1000).ToString();

                }
            }
        }
    }
}