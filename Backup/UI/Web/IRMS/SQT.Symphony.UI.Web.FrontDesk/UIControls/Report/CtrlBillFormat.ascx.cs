using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlBillFormat : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadControlValue();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Load Control Value
        /// </summary>
        private void LoadControlValue()
        {
            try
            {                
                BindInvoice();
                rdoDetail.Checked = true;
                rdoDetail_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Invoice
        /// </summary>
        private void BindInvoice()
        {
            
            List<Invoice> lstInv = InvoiceBLL.GetAll();
            if (lstInv.Count > 0)
            {
                lstInv.Sort((Invoice i1, Invoice i2) => i1.InvoiceNo.CompareTo(i2.InvoiceNo));
                ddlInvoice.DataSource = lstInv;
                ddlInvoice.DataTextField = "InvoiceNo";
                ddlInvoice.DataValueField = "InvoiceID";
                ddlInvoice.DataBind();
                ddlInvoice.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlInvoice.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {               
                DataSet ds = new DataSet();
                Guid? ID = null;                          
                Invoice inv = null;

                if (!ddlInvoice.SelectedValue.Equals(Guid.Empty.ToString()))
                    ID = (Guid?)new Guid(Convert.ToString(ddlInvoice.SelectedValue));               
                if(ID != null)
                    inv = InvoiceBLL.GetByPrimaryKey((Guid)ID);
                if (rdoDetail.Checked)
                    ds = InvoiceBLL.GetRPTInvoiceBillDetail(inv.ReservationID, inv.FolioID);
                else if (rdoSummary.Checked)
                {
                    DataSet dsMain = InvoiceBLL.GetRPTInvoiceReservationDetail(null, inv.ReservationID, inv.FolioID);
                    DataSet dsDetail = InvoiceBLL.GetRPTInvoiceBillSummary(inv.ReservationID, inv.FolioID);
                    DataTable MainDS = dsMain.Tables[0].Copy();
                    MainDS.Merge(dsDetail.Tables[0], true);
                    ds.Tables.Add(MainDS);
                }

                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion

        protected void rdoDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetail.Checked)
                Session.Add("ReportName", "Bill Format");
            else if (rdoSummary.Checked)
                Session.Add("ReportName", "Bill Summary");
        }    
    }
}