using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;


namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlSearchKeyandRoomNo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsearchRoom_Click(object sender,EventArgs e)
        {
            try
            {
                DataSet dsForRoom = ReservationBLL.SearchKeyAndRoomData(clsSession.PropertyID, "ROOM", Convert.ToString(txtKey.Text));
                if (dsForRoom != null && dsForRoom.Tables.Count > 0 && dsForRoom.Tables[0].Rows.Count > 0)
                {
                    litRoomName.Text = "<span style='font-weight:bold;'>Room No : " + Convert.ToString(dsForRoom.Tables[0].Rows[0]["RoomNumber"]) + "</span>";
                }

                else
                {
                    litRoomName.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
 
        }
        protected void btnSearchKey_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsForRoom = ReservationBLL.SearchKeyAndRoomData(clsSession.PropertyID, "KEY", Convert.ToString(txtRoomNo.Text));
                if (dsForRoom != null && dsForRoom.Tables.Count > 0 && dsForRoom.Tables[0].Rows.Count > 0)
                {

                    litKeyName.Text = "<span style='font-weight:bold; font-color:red;'>Key No : " + Convert.ToString(dsForRoom.Tables[0].Rows[0]["KeyNumber"]) + "</span>";
                }
                else
                {
                    litKeyName.Text = "";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}