using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup
{
    public partial class CtrlCompanyInvoice : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

        #endregion Property and Variables

        #region Control Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {

        }
        #endregion Control Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");
            BindData();
            mvCompanyInvoice.ActiveViewIndex = 0;
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {

        }
        protected void btnDeleteRow_OnClick(object sender, EventArgs e)
        {

        }
        #region Private method
        private void BindData()
        {
            try
            {

                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindGrid()
        {
            try
            {

                DataTable dtCompanyInvoiceData = new DataTable();
               
                DataColumn cl = new DataColumn("Company");
                DataColumn c2 = new DataColumn("Type");
                DataColumn c3 = new DataColumn("ContactPersonName");
                DataColumn c4 = new DataColumn("REC");
                DataColumn c5 = new DataColumn("UNUSED");
                DataColumn c6 = new DataColumn("OSTD");
                DataColumn c7 = new DataColumn("CR");
            dtCompanyInvoiceData.Columns.Add(cl);
            dtCompanyInvoiceData.Columns.Add(c2);
            dtCompanyInvoiceData.Columns.Add(c3);
            dtCompanyInvoiceData.Columns.Add(c4);
            dtCompanyInvoiceData.Columns.Add(c5);

            dtCompanyInvoiceData.Columns.Add(c6);
            dtCompanyInvoiceData.Columns.Add(c7);
            DataRow dr = dtCompanyInvoiceData.NewRow();
            dr["Company"] = "Softqube";
            dr["Type"] = "CA";
            dr["ContactPersonName"] = "Mr. Anthony";
            dr["REC"] = "2200.00";
            dr["UNUSED"] = "0.0";
            dr["OSTD"] = "1,400.00";
            dr["CR"] = "-1,400.00";
            dtCompanyInvoiceData.Rows.Add(dr);
            gvCompanyInvoiceList.DataSource = dtCompanyInvoiceData;
            gvCompanyInvoiceList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        #endregion Private method
        #region Grid event
      
        #endregion Grid event

    }
}