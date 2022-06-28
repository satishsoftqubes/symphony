using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class ChangeRoomNumOnly : System.Web.UI.UserControl
    {
        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "CHANGEWRONGROOMNUMBER")
                {
                    LoadDefaultValue();
                }
            }
        }

        protected void btnGetRooms_Click(object sender, EventArgs e)
        {
            ddlNewRoomNo.Items.Clear();
            DataSet dsRooms = ReservationBLL.SearchRoomByRoomNo(txtNewRoomNo.Text.Trim(),this.ReservationID);
            if (dsRooms.Tables.Count > 0 && dsRooms.Tables[0].Rows.Count > 0)
            {
                ddlNewRoomNo.DataSource = dsRooms.Tables[0];
                ddlNewRoomNo.DataTextField = "DisplayRoomNo";
                ddlNewRoomNo.DataValueField = "RoomID";
                ddlNewRoomNo.DataBind();
                ddlNewRoomNo.Items.Insert(0, new ListItem("--Select--", Guid.Empty.ToString()));
            }
            else
            {
                ddlNewRoomNo.Items.Insert(0, new ListItem("--Select--", Guid.Empty.ToString()));
            }
        }

        protected void btnUpdateRoomNo_Click(object sender, EventArgs e)
        {
            if (this.ReservationID != null)
            {
                if (ReservationBLL.UpdateWronglyAssignedRoomNo(this.ReservationID, new Guid(Convert.ToString(ddlNewRoomNo.SelectedValue))))
                {
                    this.ReservationID = Guid.Empty;
                    txtNewRoomNo.Text = "";
                    ddlNewRoomNo.Items.Clear();

                    MessageBox.Show("Room No. Updated successfully.");
                }
                else
                {
                    MessageBox.Show("Something went wrong, please try again");
                }
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again");
            }
        }

        public void LoadDefaultValue()
        {
            try
            {
                this.ReservationID = clsSession.ToEditItemID;
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                ddlNewRoomNo.Items.Insert(0, new ListItem("--Select--", Guid.Empty.ToString()));

                DataSet dsRservationData = ReservationBLL.GetResrvationViewData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);
                if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsRservationData.Tables[0].Rows[0];

                    //litDspGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    litDisplayFolioNo.Text = Convert.ToString(dr["FolioNo"]);
                    //litDspRoomNo.Text = Convert.ToString(dr["RoomNo"]);

                    DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    litDisplayArrivalDate.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));

                    DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));
                    litDisplayDepatureDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));

                    litDisplayUnitNo.Text = ltrCurrentAssignedRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                    lblFolioDetailsDisplayGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    lblFolioDetailsDisplayMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    lblFolioDetailsDisplayEmail.Text = Convert.ToString(dr["Email"]);
                    litDisplayRoomType.Text = Convert.ToString(dr["RoomTypeName"]);

                    litDisplayRateCard.Text = Convert.ToString(dr["RateCardName"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}