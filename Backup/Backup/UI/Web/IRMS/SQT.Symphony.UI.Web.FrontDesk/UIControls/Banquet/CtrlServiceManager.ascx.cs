using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet
{
    public partial class CtrlServiceManager : System.Web.UI.UserControl
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvServiceManager.ActiveViewIndex = 0;
                GridBind();
                BindBreadCrumb();
            }
        }
        #endregion

        #region Private Method
        private void GridBind()
        {
            try
            {
                DataTable dtgvServiceManagerList = new DataTable();

                DataColumn dc1 = new DataColumn("Manager");

                dtgvServiceManagerList.Columns.Add(dc1);

                DataRow dr1 = dtgvServiceManagerList.NewRow();
                dr1["Manager"] = "HariKrishna Patel";
                dtgvServiceManagerList.Rows.Add(dr1);

                DataRow dr2 = dtgvServiceManagerList.NewRow();
                dr2["Manager"] = "Vijay Mulani";
                dtgvServiceManagerList.Rows.Add(dr2);

                gvServiceManagerList.DataSource = dtgvServiceManagerList;
                gvServiceManagerList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            ddlServiceArea.SelectedIndex = ddlSupplier.SelectedIndex = ddlTitle.SelectedIndex = 0;
            txtAddress.Text = txtCharge.Text = txtCityName.Text = txtContact.Text = txtCountryName.Text = txtDescription.Text = txtEmail.Text = txtFaxNo.Text = txtFirstName.Text = txtLastName.Text = txtSearchManager.Text = txtStateName.Text = txtUrl.Text = txtZipCode.Text = "";
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
            dr4["NameColumn"] = "Banquet";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Service Manager";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Control Event
        protected void btnAddTopServiceManager_OnClick(object sender, EventArgs e)
        {
            mvServiceManager.ActiveViewIndex = 1;
            ClearControl();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            mvServiceManager.ActiveViewIndex = 0;
            ClearControl();
        }

        #endregion
    }
}