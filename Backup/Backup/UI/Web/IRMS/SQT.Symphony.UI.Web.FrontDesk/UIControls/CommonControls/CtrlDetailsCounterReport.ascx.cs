using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlDetailsCounterReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                BindGridCounterDetails();
            }
        }

        #region Private Methode

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



            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Detail Counter Report";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGridCounterDetails()
        {
            try
            {
                DataTable dtData = new DataTable();

                DataColumn dc1 = new DataColumn("Description");
                DataColumn dc2 = new DataColumn("SystemAmount");
                DataColumn dc3 = new DataColumn("NetAmount");
                DataColumn dc4 = new DataColumn("NewTransID");
                DataColumn dc5 = new DataColumn("OldTransID");

                dtData.Columns.Add(dc1);
                dtData.Columns.Add(dc2);
                dtData.Columns.Add(dc3);
                dtData.Columns.Add(dc4);
                dtData.Columns.Add(dc5);

                DataRow dr1 = dtData.NewRow();
                dr1["NewTransID"] = "0011";
                dr1["OldTransID"] = "0001";
                dr1["Description"] = "Abc";
                dr1["SystemAmount"] = "10000.00";
                dr1["NetAmount"] = "10200.00";
                dtData.Rows.Add(dr1);

                DataRow dr2 = dtData.NewRow();
                dr2["NewTransID"] = "0022";
                dr2["OldTransID"] = "0002";
                dr2["Description"] = "Xyz";
                dr2["SystemAmount"] = "20000.00";
                dr2["NetAmount"] = "22200.00";
                dtData.Rows.Add(dr2);

                DataRow dr3 = dtData.NewRow();
                dr3["NewTransID"] = "0033";
                dr3["OldTransID"] = "0003";
                dr3["Description"] = "Xyz";
                dr3["SystemAmount"] = "30000.00";
                dr3["NetAmount"] = "30000.00";
                dtData.Rows.Add(dr3);

                gvDetailsCounterReport.DataSource = dtData;
                gvDetailsCounterReport.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}