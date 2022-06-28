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


namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Report
{
    public partial class BirthDayListPrint : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyAddress();
                BindGuestBirthDayList();
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
        private void BindGuestBirthDayList()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                int? FromMonth = null;
                int? ToMonth = null;

                int guestBirthDayListPageIndex = 0;
                if (Session["GuestBirthDayListPageIndex"] != null && Convert.ToString(Session["GuestBirthDayListPageIndex"]) != "")
                    guestBirthDayListPageIndex = Convert.ToInt32(Session["GuestBirthDayListPageIndex"]);

                if (Session["BirthDayFromMonth"] != null && Convert.ToString(Session["BirthDayFromMonth"]) != "")
                    FromMonth = Convert.ToInt32(Session["BirthDayFromMonth"]);

                if (Session["BirthDayToMonth"] != null && Convert.ToString(Session["BirthDayToMonth"]) != "")
                    ToMonth = Convert.ToInt32(Session["BirthDayToMonth"]);


                litBirthDayMonthselected.Text = "Selected month : " + Convert.ToString(Session["BirthDayFromMonthText"]) + " to " + Convert.ToString(Session["BirthDayToMonthText"]);
                DataSet dsGuestBirthDayList = GuestBLL.GettGuestBirthDayReport(clsSession.PropertyID, clsSession.CompanyID, FromMonth, ToMonth);

                if (dsGuestBirthDayList != null && dsGuestBirthDayList.Tables.Count > 0 && dsGuestBirthDayList.Tables[0].Rows.Count > 0)
                {
                    gvBirthDayList.PageIndex = guestBirthDayListPageIndex;
                    gvBirthDayList.DataSource = dsGuestBirthDayList;
                    gvBirthDayList.DataBind();
                }
                else
                {
                    gvBirthDayList.DataSource = null;
                    gvBirthDayList.DataBind();
                }
                Session.Remove("BirthDayFromMonth");
                Session.Remove("BirthDayToMonth");
                Session.Remove("BirthDayFromMonthText");
                Session.Remove("BirthDayToMonthText");
                Session.Remove("GuestBirthDayListPageIndex");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion Private Method

        #region Grid Event
        protected void gvBirthDayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvBirthDate = (Label)e.Row.FindControl("lblGvBirthDate");
                    if (DataBinder.Eval(e.Row.DataItem, "DOB") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DOB")) != "")
                    {
                        lblGvBirthDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DOB")).ToString(clsSession.DateFormat);
                    }
                    else
                    {
                        lblGvBirthDate.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvBirthDayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBirthDayList.PageIndex = e.NewPageIndex;
            BindGuestBirthDayList();
        }
        #endregion Grid Event
    }
}