using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice
{
    public partial class CtrlInvoiceSettlement : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsListMessage = false;

        #endregion Property and Variables

        #region Page Loac
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");

            if (!IsPostBack)
            {
                BindCompanyDDL(); 
                BindGrid();
            }
        }
        #endregion

        #region Control Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {

        }
        #endregion Control Event

        #region Private method
        private void BindCompanyDDL()
        {
            string strCompany = "SELECT CorporateID,CompanyName FROM [dbo].[mst_Corporate]  WHERE ISNULL(IsActive,0) = 1 and ISNULL(IsDirectBill,1) = 1  and PropertyID ='" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID= '" + Convert.ToString(clsSession.CompanyID) + "' Order by [CompanyName] asc";
            DataSet dsCompany = RoomBLL.GetUnitNo(strCompany);

            ddlSrchCompany.Items.Clear();
            if (dsCompany != null && dsCompany.Tables.Count > 0 && dsCompany.Tables[0].Rows.Count > 0)
            {
                ddlSrchCompany.DataSource = dsCompany.Tables[0];
                ddlSrchCompany.DataTextField = "CompanyName";
                ddlSrchCompany.DataValueField = "CorporateID";
                ddlSrchCompany.DataBind();
                ddlSrchCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlSrchCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void BindGrid()
        {
            try
            {
                DataSet dsForCompanyInvoiceData = CorporateBLL.GetAgentWithReceipt(clsSession.CompanyID, clsSession.PropertyID);
                if (dsForCompanyInvoiceData != null && dsForCompanyInvoiceData.Tables.Count > 0 && dsForCompanyInvoiceData.Tables[0].Rows.Count > 0)
                {
                    gvCompanyInvoiceList.DataSource = dsForCompanyInvoiceData.Tables[0];
                    gvCompanyInvoiceList.DataBind();
                }
                else
                {
                    gvCompanyInvoiceList.DataSource = null;
                    gvCompanyInvoiceList.DataBind(); 
                }
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