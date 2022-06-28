﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class TodayArrivalPrint : System.Web.UI.Page
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArrivalGrid();
                BindPropertyAddress();
            }
        }

        #endregion Page Load

        #region Private Method
        private void BindPropertyAddress()
        {
            try
            {
                DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
                lblPropertyaddress.Text = "";
                if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
                {
                    lblPropertyaddress.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
                }
                else
                {
                    lblPropertyaddress.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindArrivalGrid()
        {
            try
            {
                DataSet dsReservationList = ReservationBLL.GetArrivalListData(null, clsSession.PropertyID, clsSession.CompanyID, null, null, null, DateTime.Now, DateTime.Now, "LIST", null);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvArrival.DataSource = dsReservationList.Tables[0];
                    gvArrival.DataBind();
                }
                else
                {
                    gvArrival.DataSource = null;
                    gvArrival.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        protected void gvArrival_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int SymphonyValue = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SymphonyValue")));

                    Label lblGvPickUp = (Label)e.Row.FindControl("lblGvPickUp");
                    ((Label)e.Row.FindControl("lblGvPhone")).Text = clsCommon.GetMobileNo(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1")));
                    ((Label)e.Row.FindControl("lblGvRoomNo")).Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo")));

                    string strPickUp = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsToPickUp"));

                    if (strPickUp == "0")
                        lblGvPickUp.Text = "NO";
                    else
                        lblGvPickUp.Text = "YES";

                    Image imgReservationStatus = (Image)e.Row.FindControl("imgReservationStatus");

                    string strimagesrc = "";
                    string strAltTag = "";

                    switch (SymphonyValue)
                    {
                        case 27:
                            strimagesrc = "~/images/UnConfirmed22x22.png";
                            strAltTag = " Provisional";
                            break;
                        case (28):
                            strimagesrc = "~/images/Confirmed22x22.png";
                            strAltTag = "Confirmed";
                            break;
                        case (29):
                            strimagesrc = "~/images/WaitingList22x22.png";
                            strAltTag = "Waiting List";
                            break;
                        case (32):
                            strimagesrc = "~/images/CheckIn22x22.png";
                            strAltTag = "Check In";
                            break;
                        case (33):
                            strimagesrc = "~/images/CheckOut22x22.png";
                            strAltTag = "Check Out";
                            break;
                        case (34):
                            strimagesrc = "~/images/Cancelled22x22.png";
                            strAltTag = "Cancelled";
                            break;
                    }

                    imgReservationStatus.ImageUrl = strimagesrc;
                    imgReservationStatus.ToolTip = strAltTag;

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}