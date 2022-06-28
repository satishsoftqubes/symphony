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
    public partial class CtrlNewInvoiceSettlement : System.Web.UI.UserControl
    {
        #region Property and Variables
        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }
        public bool IsListMessage = false;

        #endregion Property and Variables

        #region Page Loac
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");

                CheckUserAuthorization();
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

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "InvoiceSettlement.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
        }
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
        protected void gvCompanyInvoiceList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompanyInvoiceList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvCompanyInvoiceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //LinkButton lnkDelete1 = (LinkButton)e.Row.FindControl("lnkDelete1");
                    //Label lblTaxRateAmount = (Label)e.Row.FindControl("lblTaxRateAmount");
                    //Label lblGvDisplayMinAmt = (Label)e.Row.FindControl("lblGvDisplayMinAmt");
                    //Label lblGvDisplayMaxAmt = (Label)e.Row.FindControl("lblGvDisplayMaxAmt");

                    //decimal dcTaxRateAmount = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TaxRate")));
                    //decimal dcminamt = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MinAmount")));

                    //if (this.UserRights.Substring(2, 1) == "1")
                    //    ((LinkButton)e.Row.FindControl("lnkEdit1")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    //else
                    //    ((LinkButton)e.Row.FindControl("lnkEdit1")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    //lnkDelete1.Visible = this.UserRights.Substring(3, 1) == "1";
                    //lnkDelete1.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    //lnkDelete1.OnClientClick = string.Format("return fnConfirmDeleteRow('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TaxSlabID")));

                    //lblTaxRateAmount.Text = Convert.ToString(dcTaxRateAmount.ToString().Substring(0, dcTaxRateAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    //lblGvDisplayMinAmt.Text = Convert.ToString(dcminamt.ToString().Substring(0, dcminamt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                    //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaxAmount")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaxAmount")) != "")
                    //{
                    //    decimal dcmaxamt = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MaxAmount")));
                    //    lblGvDisplayMaxAmt.Text = Convert.ToString(dcmaxamt.ToString().Substring(0, dcmaxamt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    //}
                    //else
                    //    lblGvDisplayMaxAmt.Text = "";
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    //((Label)e.Row.FindControl("lblGvHrdNo1")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    //((Label)e.Row.FindControl("lblGvHdrTaxRate1")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxRate1", "Tax Rate");
                    //((Label)e.Row.FindControl("lblGvHdrTaxType")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrTaxType", "Type");
                    //((Label)e.Row.FindControl("lblGvHdrStartDate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrStartDate", "Start Date");
                    //((Label)e.Row.FindControl("lblGvHdrEndDate")).Text = clsCommon.GetGlobalResourceText("Tax", "lblGvHdrEndDate", "End Date");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void gvCompanyInvoiceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("SETTLEINVOICE"))
                {
                    clsSession.ToEditItemType = "INVOICESETTLEMENT";
                    clsSession.ToEditItemID = new Guid(e.CommandArgument.ToString());
                    Response.Redirect("~/GUI/Invoice/CompanyInvoices.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        #endregion Grid event
    }
}