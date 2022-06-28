using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlQuickRoomReservation : System.Web.UI.UserControl
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindBookingTable();
            }
        }
        #endregion

        #region Control Events
        protected void ddlViewType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            BindBookingTable();
        }
        #endregion

        #region Methods
        private void BindBookingTable()
        {
            try
            {
                StringBuilder strBldr = new StringBuilder();

                if (ddlViewType.SelectedValue.ToString().ToUpper() == "DAILY")
                {
                    lblCalanderToFrom.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy") + " - " + DateTime.Today.AddDays(13).ToString("dd/MM/yyyy");
                    strBldr.Append("<table cellpadding='0' cellspacing='0' class='maintable'>");
                    DataTable dtToBind = GetDataToBind("DAILY");

                    for (int i = 0; i < dtToBind.Rows.Count; i++)
                    {
                        strBldr.Append("<tr>");
                        for (int j = 0; j < dtToBind.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                                else
                                    strBldr.Append("<td class='cellheader'>" + DateTime.Today.AddDays(j - 2).ToString("dd/MM") + "<br />" + GetDayName(j) + "</td>");
                            }
                            else if (i == 1)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>DOUBLE</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 6)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>FAMILY</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 12)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>STANDARD</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    if (i < 6)
                                        strBldr.Append("<td class='roomname'>DBL-B" + (i - 1).ToString() + "</td>");
                                    else if (i <= 11)
                                        strBldr.Append("<td class='roomname'>FML-B" + (i - 6).ToString() + "</td>");
                                    else if (i <= 16)
                                        strBldr.Append("<td class='roomname'>STD-B" + (i - 12).ToString() + "</td>");
                                }
                                else
                                {
                                    string cellID = i.ToString() + j.ToString();
                                    strBldr.Append("<td id='" + cellID + "' class='tobookcell' onclick=\"fnClick('" + cellID + "');\"></td>");
                                }
                            }
                        }
                        strBldr.Append("</tr>");
                    }

                    strBldr.Append("</table>");
                }
                else if (ddlViewType.SelectedValue.ToString().ToUpper() == "WEEKLY")
                {
                    lblCalanderToFrom.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy") + " - " + DateTime.Today.AddDays(13).ToString("dd/MM/yyyy");
                    strBldr.Append("<table cellpadding='0' cellspacing='0' class='maintable'>");
                    DataTable dtToBind = GetDataToBind("WEEKLY");

                    for (int i = 0; i < dtToBind.Rows.Count; i++)
                    {
                        strBldr.Append("<tr>");
                        for (int j = 0; j < dtToBind.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                                else
                                    strBldr.Append("<td class='cellheader'>" + DateTime.Today.AddDays(((j - 1) * 7) + 1).ToString("dd/MM/yyyy") + " to <br />" + DateTime.Today.AddDays((j) * 7).ToString("dd/MM/yyyy") + "</td>");
                            }
                            else if (i == 1)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>DOUBLE</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 6)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>FAMILY</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 12)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>STANDARD</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    if (i < 6)
                                        strBldr.Append("<td class='roomname'>DBL-B" + (i - 1).ToString() + "</td>");
                                    else if (i <= 11)
                                        strBldr.Append("<td class='roomname'>FML-B" + (i - 6).ToString() + "</td>");
                                    else if (i <= 16)
                                        strBldr.Append("<td class='roomname'>STD-B" + (i - 12).ToString() + "</td>");
                                }
                                else
                                {
                                    string cellID = i.ToString() + j.ToString();
                                    strBldr.Append("<td id='" + cellID + "' class='tobookcell' onclick=\"fnClick('" + cellID + "');\"></td>");
                                }
                            }
                        }
                        strBldr.Append("</tr>");
                    }

                    strBldr.Append("</table>");
                }
                else if (ddlViewType.SelectedValue.ToString().ToUpper() == "MONTHLY")
                {
                    //lblCalanderToFrom.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy") + " - " + DateTime.Today.AddDays(13).ToString("dd/MM/yyyy");
                    strBldr.Append("<table cellpadding='0' cellspacing='0' class='maintable'>");
                    DataTable dtToBind = GetDataToBind("MONTHLY");

                    for (int i = 0; i < dtToBind.Rows.Count; i++)
                    {
                        strBldr.Append("<tr>");
                        for (int j = 0; j < dtToBind.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                                else
                                    strBldr.Append("<td class='cellheader'>" + GetMonthName(j) + "</td>");
                            }
                            else if (i == 1)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>DOUBLE</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 6)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>FAMILY</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 12)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>STANDARD</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    if (i < 6)
                                        strBldr.Append("<td class='roomname'>DBL-B" + (i - 1).ToString() + "</td>");
                                    else if (i <= 11)
                                        strBldr.Append("<td class='roomname'>FML-B" + (i - 6).ToString() + "</td>");
                                    else if (i <= 16)
                                        strBldr.Append("<td class='roomname'>STD-B" + (i - 12).ToString() + "</td>");
                                }
                                else
                                {
                                    string cellID = i.ToString() + j.ToString();
                                    strBldr.Append("<td id='" + cellID + "' class='tobookcell' onclick=\"fnClick('" + cellID + "');\"></td>");
                                }
                            }
                        }
                        strBldr.Append("</tr>");
                    }

                    strBldr.Append("</table>");
                }
                else if (ddlViewType.SelectedValue.ToString().ToUpper() == "QUARTERLY")
                {
                    //lblCalanderToFrom.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy") + " - " + DateTime.Today.AddDays(13).ToString("dd/MM/yyyy");
                    strBldr.Append("<table cellpadding='0' cellspacing='0' class='maintable'>");
                    DataTable dtToBind = GetDataToBind("QUARTERLY");

                    for (int i = 0; i < dtToBind.Rows.Count; i++)
                    {
                        strBldr.Append("<tr>");
                        for (int j = 0; j < dtToBind.Columns.Count; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                                else
                                    strBldr.Append("<td class='cellheader'>" + DateTime.Today.AddMonths(((j - 1) * 2) + (j - 1)).ToString("MMM-yyyy") + " to <br />" + DateTime.Today.AddMonths(((j - 1) * 2) + (j - 1) + 2).ToString("MMM-yyyy") + "</td>");
                            }
                            else if (i == 1)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>DOUBLE</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 6)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>FAMILY</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else if (i == 12)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>STANDARD</b></td>");
                                else
                                    strBldr.Append("<td class='commonheader'></td>");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    if (i < 6)
                                        strBldr.Append("<td class='roomname'>DBL-B" + (i - 1).ToString() + "</td>");
                                    else if (i <= 11)
                                        strBldr.Append("<td class='roomname'>FML-B" + (i - 6).ToString() + "</td>");
                                    else if (i <= 16)
                                        strBldr.Append("<td class='roomname'>STD-B" + (i - 12).ToString() + "</td>");
                                }
                                else
                                {
                                    string cellID = i.ToString() + j.ToString();
                                    strBldr.Append("<td id='" + cellID + "' class='tobookcell' onclick=\"fnClick('" + cellID + "');\"></td>");
                                }
                            }
                        }
                        strBldr.Append("</tr>");
                    }

                    strBldr.Append("</table>");
                }


                dvTest.InnerHtml = strBldr.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public DataTable GetDataToBind(string strViewType)
        {
            DataTable dtToReturn = new DataTable();

            int iColCount = 0;
            if (strViewType.ToUpper() == "DAILY")
                iColCount = 16;
            else if (strViewType.ToUpper() == "WEEKLY")
                iColCount = 11;
            else if (strViewType.ToUpper() == "MONTHLY")
                iColCount = 13;
            else if (strViewType.ToUpper() == "QUARTERLY")
                iColCount = 10;

            for (int i = 1; i <= iColCount; i++)
            {
                DataColumn dtCol = new DataColumn(i.ToString());
                dtToReturn.Columns.Add(dtCol);
            }

            DataRow dr0 = dtToReturn.NewRow(); DataRow dr1 = dtToReturn.NewRow(); DataRow dr2 = dtToReturn.NewRow(); DataRow dr3 = dtToReturn.NewRow();
            DataRow dr4 = dtToReturn.NewRow(); DataRow dr5 = dtToReturn.NewRow(); DataRow dr6 = dtToReturn.NewRow(); DataRow dr7 = dtToReturn.NewRow();
            DataRow dr8 = dtToReturn.NewRow(); DataRow dr9 = dtToReturn.NewRow(); DataRow dr10 = dtToReturn.NewRow(); DataRow dr11 = dtToReturn.NewRow();
            DataRow dr12 = dtToReturn.NewRow(); DataRow dr13 = dtToReturn.NewRow(); DataRow dr14 = dtToReturn.NewRow(); DataRow dr15 = dtToReturn.NewRow();
            DataRow dr16 = dtToReturn.NewRow();

            dtToReturn.Rows.Add(dr0); dtToReturn.Rows.Add(dr1); dtToReturn.Rows.Add(dr2); dtToReturn.Rows.Add(dr3); dtToReturn.Rows.Add(dr4);
            dtToReturn.Rows.Add(dr5); dtToReturn.Rows.Add(dr6); dtToReturn.Rows.Add(dr7); dtToReturn.Rows.Add(dr8); dtToReturn.Rows.Add(dr9);
            dtToReturn.Rows.Add(dr10); dtToReturn.Rows.Add(dr11); dtToReturn.Rows.Add(dr12); dtToReturn.Rows.Add(dr13); dtToReturn.Rows.Add(dr14);
            dtToReturn.Rows.Add(dr15); dtToReturn.Rows.Add(dr16);

            return dtToReturn;
        }

        public string GetDayName(int date)
        {
            DateTime dt = DateTime.Today.AddDays(date - 2);
            string strDay = dt.ToString("ddd");

            return strDay;
        }

        public string GetMonthName(int count)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddMonths(count - 1);
            int smnth = dt.Month;
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(smnth);
            int year = dt.Year;

            return strMonthName + "-" + year.ToString();
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["NameColumn"] = clsSession.CompanyName;
            //    dr["Link"] = "~/GUI/Property/CompanyList.aspx";
            //    dt.Rows.Add(dr);
            //}

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City"; //clsSession.PropertyName;
            //dr1["Link"] = "";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Reservation"; //clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Quick Room Reservation"; //clsCommon.GetGlobalResourceText("BreadCrumb", "lblCorporateList", "Corporate List");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion
    }
}