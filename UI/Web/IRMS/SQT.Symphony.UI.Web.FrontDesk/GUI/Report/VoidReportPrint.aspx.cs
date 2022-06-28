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
    public partial class VoidReportPrint : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyAddress();
                BindVoidReportGrid();
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
        private void BindVoidReportGrid()
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;
                string strGuestName = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                int guestBirthDayListPageIndex = 0;

                if (Session["VoidSearchStartDate"] != null && Convert.ToString(Session["VoidSearchStartDate"]) != "")
                {
                    litFromDate.Text = Convert.ToString(Session["VoidSearchStartDate"]);
                    startdt = DateTime.ParseExact(Convert.ToString(Session["VoidSearchStartDate"]), clsSession.DateFormat, objCultureInfo);
                }
                if (Session["VoidSearchEndDate"] != null && Convert.ToString(Session["VoidSearchEndDate"]) != "")
                {
                    litToDate.Text = Convert.ToString(Session["VoidSearchEndDate"]);
                    enddt = DateTime.ParseExact(Convert.ToString(Session["VoidSearchEndDate"]), clsSession.DateFormat, objCultureInfo);
                }
                if (Session["VoidSearchGuestName"] != null && Convert.ToString(Session["VoidSearchGuestName"]) != "")
                {
                    litGuestName.Text = Convert.ToString(Session["VoidSearchGuestName"]);
                    strGuestName = Convert.ToString(Session["VoidSearchGuestName"]);
                }
                if (Session["VoidSearchGridPageIndex"] != null && Convert.ToString(Session["VoidSearchGridPageIndex"]) != "")
                    guestBirthDayListPageIndex = Convert.ToInt32(Session["VoidSearchGridPageIndex"]);

                DataSet ds = BookKeepingBLL.GetVoidReport(clsSession.CompanyID, clsSession.PropertyID, startdt, enddt, strGuestName);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvVoidTrnasactions.PageIndex = guestBirthDayListPageIndex;
                    gvVoidTrnasactions.DataSource = ds.Tables[0];
                    gvVoidTrnasactions.DataBind();
                }

                Session.Remove("VoidSearchStartDate");
                Session.Remove("VoidSearchEndDate");
                Session.Remove("VoidSearchGuestName");
                Session.Remove("VoidSearchGridPageIndex");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion Private Method
    }
}