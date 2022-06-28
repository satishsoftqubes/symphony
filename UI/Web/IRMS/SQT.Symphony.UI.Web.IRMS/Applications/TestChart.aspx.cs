using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik;

namespace SQT.Symphony.UI.Web.IRMS.Applications
{
    public partial class TestChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        #region Private Method
        private void BindGrid()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("StartDate");
            DataColumn dc2 = new DataColumn("Amt4Interest");
            DataColumn dc3 = new DataColumn("InterestAmt");
            DataColumn dc4 = new DataColumn("TotalAmtAtBank");
            DataColumn dc5 = new DataColumn("AmtToAdd");


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);

            DataRow dr1 = dtTable.NewRow();
            dr1["StartDate"] = "1-1-2015";
            dr1["Amt4Interest"] = "100000";
            dr1["InterestAmt"] = "9500";
            dr1["TotalAmtAtBank"] = "109500";
            dr1["AmtToAdd"] = "100000";
            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["StartDate"] = "1-1-2016";
            dr2["Amt4Interest"] = "209500";
            dr2["InterestAmt"] = "19900";
            dr2["TotalAmtAtBank"] = "229400";
            dr2["AmtToAdd"] = "100000";
            dtTable.Rows.Add(dr2);

            DataRow dr3 = dtTable.NewRow();
            dr3["StartDate"] = "1-1-2017";
            dr3["Amt4Interest"] = "329400";
            dr3["InterestAmt"] = "31293";
            dr3["TotalAmtAtBank"] = "360693";
            dr3["AmtToAdd"] = "100000";
            dtTable.Rows.Add(dr3);

            DataRow dr4 = dtTable.NewRow();
            dr4["StartDate"] = "1-1-2018";
            dr4["Amt4Interest"] = "460693";
            dr4["InterestAmt"] = "43765";
            dr4["TotalAmtAtBank"] = "504458";
            dr4["AmtToAdd"] = "100000";
            dtTable.Rows.Add(dr4);

            grdInvestorList.DataSource = dtTable;
            grdInvestorList.DataBind();
        }
        #endregion

        #region Grid Event
        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    //string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    //e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }
        #endregion
    }
}