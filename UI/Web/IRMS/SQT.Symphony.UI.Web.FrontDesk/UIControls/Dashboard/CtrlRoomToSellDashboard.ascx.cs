using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Dashboard
{
    public partial class CtrlRoomToSellDashboard : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindRoomToSellGrid();
                //BindAvailabilityChartGrid();                
            }
        }

        #endregion Page Load

        #region Grid Event

        protected void gvRoomToSell_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("TOTAL"))
                {
                    //BindRoomDetail();
                    mpeRoomDetail.Show();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvBookingChart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("TOTAL"))
                {
                    //BindRoomBookingDetail();
                    mpeBookingDetail.Show();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }



        #endregion

        
    }
}