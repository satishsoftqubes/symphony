using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration
{
    public partial class WebForm : System.Web.UI.Page
    {
        #region Page Event Test
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookingTable();
            }
        }
        #endregion

        #region Methods
        private void BindBookingTable()
        {
            StringBuilder strBldr = new StringBuilder();

            strBldr.Append("<table cellpadding='0' cellspacing='1' class='maintable'>");

            DataTable dtToBind = GetDataToBind();

            for (int i = 0; i < dtToBind.Rows.Count; i++)
            {
                strBldr.Append("<tr>");
                for (int j = 0; j < dtToBind.Columns.Count; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            strBldr.Append("<td class='commonheader'><b>Room/Date</b></td>");
                        }
                        else
                        {
                            strBldr.Append("<td class='header'>" + j.ToString() + "<br />"+ GetDayName(j) +"</td>");
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            strBldr.Append("<td class='roomname'>Room No. " + i.ToString() + "</td>");
                        }
                        else
                        {
                            string cellID = i.ToString() + j.ToString();
                            strBldr.Append("<td id='" + cellID + "' class='tobookcell' onclick=\"fnClick('"+ cellID +"');\"></td>");
                        }
                    }
                }
                strBldr.Append("</tr>");
            }

            strBldr.Append("</table>");

            dvTest.InnerHtml = strBldr.ToString();
        }

        public DataTable GetDataToBind()
        {
            DataTable dtToReturn = new DataTable();

            for (int i = 1; i <= 30; i++)
            {
                DataColumn dtCol = new DataColumn(i.ToString());
                dtToReturn.Columns.Add(dtCol);
            }

            DataRow dr0 = dtToReturn.NewRow();
            DataRow dr1 = dtToReturn.NewRow();
            DataRow dr2 = dtToReturn.NewRow();
            DataRow dr3 = dtToReturn.NewRow();

            dtToReturn.Rows.Add(dr0);
            dtToReturn.Rows.Add(dr1);
            dtToReturn.Rows.Add(dr2);
            dtToReturn.Rows.Add(dr3);

            return dtToReturn;
        }

        public string GetDayName(int date)
        {
            DateTime dt = new DateTime(2012, 4, date);
            string strDay = dt.ToString("ddd");

            return strDay;
        }
        #endregion
    }
}