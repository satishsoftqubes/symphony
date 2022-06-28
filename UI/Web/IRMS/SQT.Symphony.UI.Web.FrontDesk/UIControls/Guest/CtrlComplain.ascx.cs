using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlComplain : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                mvMessage.ActiveViewIndex = 0;
                BindMessageGrid();
            }
        }

        #endregion  Page Load

        #region Private Method

        private void BindMessageGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Department");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("NatureOfComplain");
                DataColumn dc4 = new DataColumn("Guest");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["Department"] = "FrontDesk";
                dr1["Date"] = "25-7-2012";
                dr1["NatureOfComplain"] = "Service Complain";
                dr1["Guest"] = "Abc";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Department"] = "POS";
                dr2["Date"] = "26-7-2012";
                dr2["NatureOfComplain"] = "Room Complain";
                dr2["Guest"] = "Xyz";

                dtTable.Rows.Add(dr2);

                gvComplainList.DataSource = dtTable;
                gvComplainList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            ddlDepartment.SelectedIndex = 0;
            txtDate.Text = txtDescription.Text = txtNatureOfComplaint.Text = txtTime.Text = "";
        }


        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Complain";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion  Private Method

        #region Control Event

        protected void btnTopAddMessage_Click(object sender, EventArgs e)
        {
            ClearControl();
            mvMessage.ActiveViewIndex = 1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvMessage.ActiveViewIndex = 0;
        }
        #endregion  Control Event
    }
}