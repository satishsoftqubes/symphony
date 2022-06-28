using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;


namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class GuestListPrint : System.Web.UI.Page
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyAddress();
                BindGrid();
            }
        }
        #endregion

        #region Prival methods
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

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }

        private void BindGrid()
        {
            try
            {
                int guestListPageIndex = 0;
                if (Session["GuestListPageIndex"] != null && Convert.ToString(Session["GuestListPageIndex"]) != "")
                    guestListPageIndex = Convert.ToInt32(Session["GuestListPageIndex"]);

                string strName = null;
                string strMobileNo = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? BillingInstructionID = null;

                if (Session["GuestListSearchName"] != null && Convert.ToString(Session["GuestListSearchName"]) != "")
                    strName = Convert.ToString(Session["GuestListSearchName"]);

                if (Session["GuestListSearchMobileNo"] != null && Convert.ToString(Session["GuestListSearchMobileNo"]) != "")
                    strMobileNo = Convert.ToString(Session["GuestListSearchMobileNo"]);

                if (Session["GuestListSearcReservationNo"] != null && Convert.ToString(Session["GuestListSearcReservationNo"]) != "")
                    strReservationNo = Convert.ToString(Session["GuestListSearcReservationNo"]);

                if (Session["GuestListSearchUnitNo"] != null && Convert.ToString(Session["GuestListSearchUnitNo"]) != "")
                    strRoomNo = Convert.ToString(Session["GuestListSearchUnitNo"]);

                if (Session["GuestListBillingInstructionID"] != null && Convert.ToString(Session["GuestListBillingInstructionID"]) != "")
                    BillingInstructionID = new Guid(Convert.ToString(Session["GuestListBillingInstructionID"]));

                DataSet dsReservationData = GuestBLL.GetCurrentGuestListData(null, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, strRoomNo, BillingInstructionID);

                if (dsReservationData != null && dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
                {
                    gvGuestList.PageIndex = guestListPageIndex;
                    gvGuestList.DataSource = dsReservationData.Tables[0];
                    gvGuestList.DataBind();
                }
                else
                {
                    gvGuestList.DataSource = null;
                    gvGuestList.DataBind();
                }

                Session.Remove("GuestListPageIndex");
                Session.Remove("GuestListSearchName");
                Session.Remove("GuestListSearchMobileNo");
                Session.Remove("GuestListSearcReservationNo");
                Session.Remove("GuestListSearchUnitNo");
                Session.Remove("GuestListBillingInstructionID");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Event
        protected void gvGuestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}