using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonAddServices : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditAddService
        {
            get { return this.mpeAddServices; }
        }

        public event EventHandler btnAddServicesCallParent_Click;
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvServiceList.DataSource = null;
                gvServiceList.DataBind();
            }
        }

        #endregion

        #region RadioButton Event

        protected void rdblServicePackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlServicesAndPackages.Items.Clear();
                mpeAddServices.Show();
                if (rdblServicePackage.SelectedValue == "1")
                {
                    ddlServicesAndPackages.Items.Add(new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlServicesAndPackages.Items.Add(new ListItem("Tea", "Tea"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Coffe", "Coffe"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Cold Drink", "Cold Drink"));

                }
                else
                {
                    ddlServicesAndPackages.Items.Add(new ListItem("-Select-", Guid.Empty.ToString()));
                    ddlServicesAndPackages.Items.Add(new ListItem("Special Package", "Special Package"));
                    ddlServicesAndPackages.Items.Add(new ListItem("Regular Package", "Regular Package"));
                }

                EventHandler temp = btnAddServicesCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Private Method

        public void BindServiceList()
        {
            try
            {
                DataTable dtService = new DataTable();

                DataColumn dc1 = new DataColumn("Service");
                DataColumn dc2 = new DataColumn("Date");
                DataColumn dc3 = new DataColumn("Time");
                DataColumn dc4 = new DataColumn("Notes");
                DataColumn dc5 = new DataColumn("Amount");
                DataColumn dc6 = new DataColumn("Qty");
                DataColumn dc7 = new DataColumn("ServiceRate");
                DataColumn dc8 = new DataColumn("Tax");
                DataColumn dc9 = new DataColumn("SrvTax");
                DataColumn dc10 = new DataColumn("Total");

                dtService.Columns.Add(dc1);
                dtService.Columns.Add(dc2);
                dtService.Columns.Add(dc3);
                dtService.Columns.Add(dc4);
                dtService.Columns.Add(dc5);
                dtService.Columns.Add(dc6);
                dtService.Columns.Add(dc7);
                dtService.Columns.Add(dc8);
                dtService.Columns.Add(dc9);
                dtService.Columns.Add(dc10);

                DataRow dr1 = dtService.NewRow();
                dr1["Service"] = "Tea";
                dr1["Date"] = "31-5-2012";
                dr1["Time"] = "15:15";
                dr1["Notes"] = "";
                dr1["Amount"] = "10.00";
                dr1["Qty"] = "1";
                dr1["ServiceRate"] = "0.00";
                dr1["Tax"] = "5.00";
                dr1["SrvTax"] = "0.00";
                dr1["Total"] = "10.00";

                dtService.Rows.Add(dr1);

                DataRow dr2 = dtService.NewRow();
                dr2["Service"] = "Cold Drink";
                dr2["Date"] = "01-6-2012";
                dr2["Time"] = "16:00";
                dr2["Notes"] = "";
                dr2["Amount"] = "25.00";
                dr2["Qty"] = "2";
                dr2["ServiceRate"] = "0.00";
                dr2["Tax"] = "10.00";
                dr2["SrvTax"] = "0.80";
                dr2["Total"] = "50.00";

                dtService.Rows.Add(dr2);

                gvServiceList.DataSource = dtService;
                gvServiceList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearServiceControl()
        {
            txtServiceDate.Text = txtServiceTime.Text = txtQty.Text = txtAmount.Text = "";
            ddlServiceFrequency.SelectedIndex = ddlServicesAndPackages.SelectedIndex = 0;
            litTotalServiceRate.Text = "0.00";
            gvServiceList.DataSource = null;
            gvServiceList.DataBind();
        }

        #endregion

        #region Control Event

        protected void btnAddServices_Click(object sender, EventArgs e)
        {
            try
            {
                BindServiceList();
                litTotalServiceRate.Text = "60.00";

                EventHandler temp = btnAddServicesCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event

        protected void gvServiceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("POSTDATA"))
                {
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}