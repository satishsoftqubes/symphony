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
    public partial class CheckInLogPrint : System.Web.UI.Page
    {
        int totalSeconds = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyAddress();
                BindGrid();
            }

        }

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

        private void BindGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;
                Guid? fdExecutiveID = null;

                if (Session["CheckInDate"] != null && Convert.ToString(Session["CheckInDate"]) != "")
                    dtCheckInDate = Convert.ToDateTime(Session["CheckInDate"]);
                if (Session["CheckoutDate"] != null && Convert.ToString(Session["CheckoutDate"]) != "")
                    dtCheckoutDate = Convert.ToDateTime(Session["CheckoutDate"]);
                if (Session["ExecutiveID"] != null && Convert.ToString(Session["ExecutiveID"]) != "")
                    fdExecutiveID = new Guid(Convert.ToString(Session["ExecutiveID"]));

                DataSet dsCheckinTimeLog = CheckinTimeLogBLL.SelectCheckInLog(dtCheckInDate, dtCheckoutDate, fdExecutiveID, clsSession.PropertyID, clsSession.CompanyID);
                if (dsCheckinTimeLog != null && dsCheckinTimeLog.Tables.Count > 0 && dsCheckinTimeLog.Tables[0].Rows.Count > 0)
                {
                    gvCheckInLog.DataSource = dsCheckinTimeLog.Tables[0];
                    gvCheckInLog.DataBind();

                    int avgTimeTakenInSeconds = totalSeconds / gvCheckInLog.Rows.Count;
                    int actualMinutes = avgTimeTakenInSeconds / 60;
                    int actualSeconds = avgTimeTakenInSeconds - (actualMinutes * 60);

                    ltrAverageTimeTaken.Text = actualMinutes.ToString() + "m " + actualSeconds.ToString() + "s";
                }
                else
                {
                    gvCheckInLog.DataSource = null;
                    gvCheckInLog.DataBind();
                    ltrAverageTimeTaken.Text = "--";
                }

                Session["CheckInDate"] = null;
                Session["CheckoutDate"] = null;
                Session["ExecutiveID"] = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCheckInLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int timeTakenInSeconds = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotalSeconds")));

                    int actualMinutes = timeTakenInSeconds / 60;
                    int actualSeconds = timeTakenInSeconds - (actualMinutes * 60);

                    totalSeconds = totalSeconds + timeTakenInSeconds;

                    ((Literal)e.Row.FindControl("ltrTimetaken")).Text = actualMinutes.ToString() + "m " + actualSeconds.ToString() + "s";

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //protected void gvCheckInLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvCheckInLog.PageIndex = e.NewPageIndex;
        //    BindGrid();
        //}
    }
}