using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Card
{
    public partial class CtrlLostCard : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBreadCrumb();
                mvLostCard.ActiveViewIndex = 0;                
            }
        }

        #endregion  Page Load

        #region Button Event

        protected void btnStatemente_Click(object sender,EventArgs e)
        {
            Response.Redirect("~/GUI/Card/PrintStatement.aspx?Statement=true");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvLostCard.ActiveViewIndex = 0;
        }

        protected void btnSearchGuestCallParent_Click(object sender, EventArgs e)
        {
            ClearControl();
            mvLostCard.ActiveViewIndex = 1;
        }

        #endregion  Button Event

        #region Private Method

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
            dr4["NameColumn"] = "CashCard";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Lost/Cancel Card";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControl()
        {
            txtRefundAmount.Text = txtReason.Text = "";
            chkPMT.Checked = true;
            //ddlPMT.SelectedIndex = 0;
        }

        #endregion  Private Method
    }
}