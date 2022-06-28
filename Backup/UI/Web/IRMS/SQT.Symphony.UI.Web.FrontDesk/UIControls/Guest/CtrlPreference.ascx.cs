using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlPreference : System.Web.UI.UserControl
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindBreadCrumb();
                mvPreference.ActiveViewIndex = 0;
            }
        }
        #endregion

        #region Control Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPreference = new DataTable();

                DataColumn dc1 = new DataColumn("Preference");

                dtPreference.Columns.Add(dc1);

                DataRow dr1 = dtPreference.NewRow();
                dr1["Preference"] = "Car";
                dtPreference.Rows.Add(dr1);

                DataRow dr2 = dtPreference.NewRow();
                dr2["Preference"] = "Bus";
                dtPreference.Rows.Add(dr2);

                DataRow dr3 = dtPreference.NewRow();
                dr3["Preference"] = "Food";
                dtPreference.Rows.Add(dr3);

                DataRow dr4 = dtPreference.NewRow();
                dr4["Preference"] = txtPreference.Text;
                dtPreference.Rows.Add(dr4);

                gvPreference.DataSource = dtPreference;
                gvPreference.DataBind();

                txtPreference.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            txtPreference.Text = "";
            mvPreference.ActiveViewIndex = 0;
        }

        protected void btnTopAdd_OnClick(object sender, EventArgs e)
        {
            mvPreference.ActiveViewIndex = 1;
        }

        #endregion

        #region Private Method
        private void BindGrid()
        {
            try
            {
                DataTable dtPreference = new DataTable();

                DataColumn dc1 = new DataColumn("Preference");

                dtPreference.Columns.Add(dc1);

                DataRow dr1 = dtPreference.NewRow();
                dr1["Preference"] = "Car";
                dtPreference.Rows.Add(dr1);

                DataRow dr2 = dtPreference.NewRow();
                dr2["Preference"] = "Bus";
                dtPreference.Rows.Add(dr2);

                DataRow dr3 = dtPreference.NewRow();
                dr3["Preference"] = "Food";
                dtPreference.Rows.Add(dr3);

                gvPreference.DataSource = dtPreference;
                gvPreference.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Preference";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion
    }
}