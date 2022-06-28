using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlRentPayoutDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        #region Private Method
        public void BindGrid()
        {


            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("UnitNo");
            DataColumn dc2 = new DataColumn("SFT");
            DataColumn dc3 = new DataColumn("YieldSFT");
            DataColumn dc4 = new DataColumn("YieldAmount");


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);



            DataRow dr1 = dtTable.NewRow();
            dr1["UnitNo"] = "A0-007";
            dr1["SFT"] = "100";
            dr1["YieldSFT"] = "100";
            dr1["YieldAmount"] = "10000";

            dtTable.Rows.Add(dr1);



            DataRow dr2 = dtTable.NewRow();
            dr2["UnitNo"] = "A0-013";
            dr2["SFT"] = "100";
            dr2["YieldSFT"] = "100";
            dr2["YieldAmount"] = "10000";

            dtTable.Rows.Add(dr2);

            DataRow dr3 = dtTable.NewRow();
            dr3["UnitNo"] = "A0-022";
            dr3["SFT"] = "100";
            dr3["YieldSFT"] = "100";
            dr3["YieldAmount"] = "10000";

            dtTable.Rows.Add(dr3);




            gvRentPayout.DataSource = dtTable;
            gvRentPayout.DataBind();

        }
        #endregion
    }

}
