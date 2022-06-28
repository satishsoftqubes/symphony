using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlFolioAssignPackage : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucCtrlFolioAssingPackage
        {
            get { return this.mpeFolioAssignPackage; }
        }
        #endregion
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAssignPackage.DataSource = null;
                gvAssignPackage.DataBind();
                gvAssignPackageItem.DataSource = null;
                gvAssignPackageItem.DataBind();
            }
        }

        protected void btnAssignPackageAdd_OnClick(object sender, EventArgs e)
        {
            try
            {
                int i;
                decimal total = 0;

                if (ddlAssignPackageSrvPkg.SelectedIndex == 1)
                {

                    DataTable dtTable = new DataTable();

                    DataColumn dc1 = new DataColumn("ItemName");
                    DataColumn dc2 = new DataColumn("Amount");
                    DataColumn dc3 = new DataColumn("Qty");
                    DataColumn dc4 = new DataColumn("Total");



                    dtTable.Columns.Add(dc1);
                    dtTable.Columns.Add(dc2);
                    dtTable.Columns.Add(dc3);
                    dtTable.Columns.Add(dc4);

                    DataRow dr1 = dtTable.NewRow();
                    dr1["ItemName"] = "Dinner";
                    dr1["Amount"] = "23.00";
                    dr1["Qty"] = "1";
                    dr1["Total"] = "23.00";
                    dtTable.Rows.Add(dr1);

                    DataRow dr2 = dtTable.NewRow();
                    dr2["ItemName"] = "Lunch";
                    dr2["Amount"] = "18.00";
                    dr2["Qty"] = "1";
                    dr2["Total"] = "18.00";
                    dtTable.Rows.Add(dr2);

                    gvAssignPackageItem.DataSource = dtTable;
                    gvAssignPackageItem.DataBind();



                    for (i = 0; i < dtTable.Rows.Count; i++)
                    {

                        total += Convert.ToDecimal(dtTable.Rows[i][3]);

                    }
                    litAssignPackageTotal.Text = total.ToString();
                }
                else if (ddlAssignPackageSrvPkg.SelectedIndex == 2)
                {
                    DataTable dtTable = new DataTable();

                    DataColumn dc1 = new DataColumn("ItemName");
                    DataColumn dc2 = new DataColumn("Amount");
                    DataColumn dc3 = new DataColumn("Qty");
                    DataColumn dc4 = new DataColumn("Total");



                    dtTable.Columns.Add(dc1);
                    dtTable.Columns.Add(dc2);
                    dtTable.Columns.Add(dc3);
                    dtTable.Columns.Add(dc4);

                    DataRow dr1 = dtTable.NewRow();
                    dr1["ItemName"] = "Coffee";
                    dr1["Amount"] = "2.50";
                    dr1["Qty"] = "1";
                    dr1["Total"] = "2.50";
                    dtTable.Rows.Add(dr1);

                    DataRow dr2 = dtTable.NewRow();
                    dr2["ItemName"] = "Room Hire";
                    dr2["Amount"] = "5.00";
                    dr2["Qty"] = "1";
                    dr2["Total"] = "5.00";
                    dtTable.Rows.Add(dr2);

                    gvAssignPackageItem.DataSource = dtTable;
                    gvAssignPackageItem.DataBind();

                    for (i = 0; i < dtTable.Rows.Count; i++)
                    {

                        total += Convert.ToDecimal(dtTable.Rows[i][3]);

                    }
                    litAssignPackageTotal.Text = total.ToString();
                }
                else
                {
                    gvAssignPackageItem.DataSource = null;
                }
                mpeFolioAssignPackage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAssignPackageSave_Onclick(object sender, EventArgs e)
        {
            try
            {
                if (ddlAssignPackageSrvPkg.SelectedIndex == 0)
                {
                    gvAssignPackageItem.DataSource = null;
                }
                else
                {
                    DataTable dtTable = new DataTable();

                    DataColumn dc1 = new DataColumn("PackageName");
                    DataColumn dc2 = new DataColumn("Date");
                    DataColumn dc3 = new DataColumn("Cost");

                    dtTable.Columns.Add(dc1);
                    dtTable.Columns.Add(dc2);
                    dtTable.Columns.Add(dc3);

                    DataRow dr1 = dtTable.NewRow();
                    dr1["PackageName"] = ddlAssignPackageSrvPkg.SelectedValue;
                    dr1["Date"] = txtAssignPackageDate.Text;
                    dr1["Cost"] = litAssignPackageTotal.Text;
                    dtTable.Rows.Add(dr1);
                    gvAssignPackage.DataSource = dtTable;
                    gvAssignPackage.DataBind();

                    mpeFolioAssignPackage.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }        
    }
}