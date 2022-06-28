using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonGuestHistory : System.Web.UI.UserControl
    {
        #region Variable

        public event EventHandler btnGuestHistoryCallParent_Click;

        public Literal uclitGuestHistoryName
        {
            get { return this.litGuestHistoryName; }
        }

        public Literal uclitGuestHistoryContactNo
        {
            get { return this.litGuestHistoryContactNo; }
        }

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Page Load

        #region Private Method

        public void BindGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("RESNo");
                DataColumn dc2 = new DataColumn("Unit");
                DataColumn dc3 = new DataColumn("CheckIn");
                DataColumn dc4 = new DataColumn("Nights");
                DataColumn dc5 = new DataColumn("RateCard");
                DataColumn dc6 = new DataColumn("InvoiceAMT");
                DataColumn dc7 = new DataColumn("Status");
                DataColumn dc8 = new DataColumn("CheckOut");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);
                dtTable.Columns.Add(dc6);
                dtTable.Columns.Add(dc7);
                dtTable.Columns.Add(dc8);

                DataRow dr1 = dtTable.NewRow();
                dr1["RESNo"] = "30421";
                dr1["Unit"] = "15";
                dr1["CheckIn"] = "10-08-2012";
                dr1["CheckOut"] = "13-08-2012";
                dr1["Nights"] = "3";
                dr1["RateCard"] = "Room Ratecard";
                dr1["InvoiceAMT"] = "";
                dr1["Status"] = "<img src='../../images/Confirmed22x22.png' alt='Confirmed' title='Confirmed' />";
                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["RESNo"] = "30417";
                dr2["Unit"] = "60";
                dr2["CheckIn"] = "07-08-2012";
                dr2["CheckOut"] = "09-08-2012";
                dr2["Nights"] = "2";
                dr2["RateCard"] = "Conference Ratecard";
                dr2["InvoiceAMT"] = "117.60";
                dr2["Status"] = "<img src='../../images/CheckIn22x22.png' alt='Confirmed' title='Checked In' />";
                dtTable.Rows.Add(dr2);

                gvGuestHistory.DataSource = dtTable;
                gvGuestHistory.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetPageName()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            string[] strArray = path.Split('/');
            string strPageName = "";
            return strPageName = Convert.ToString(strArray[strArray.Length - 1]);
        }

        #endregion

        #region Button Event

        protected void btnGuestHistoryCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string strGetPageName = GetPageName();
                if (strGetPageName.ToUpper() == "GUESTPROFILE.ASPX")
                {
                    EventHandler temp = btnGuestHistoryCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                else if (strGetPageName.ToUpper() == "GUESTMASTER.ASPX")
                {
                    EventHandler temp = btnGuestHistoryCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                else if (strGetPageName.ToUpper() == "BANQUETMANAGEMENT.ASPX")
                {
                    EventHandler temp = btnGuestHistoryCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event
    }
}