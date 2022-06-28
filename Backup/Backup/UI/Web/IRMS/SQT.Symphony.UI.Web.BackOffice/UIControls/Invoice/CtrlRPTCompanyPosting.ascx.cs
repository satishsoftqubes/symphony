using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice
{
    public partial class CtrlRPTCompanyPosting : System.Web.UI.UserControl
    {
        #region Property and Variable
        public bool? IsPreview = false;
        public bool IsMessage = false;

        #endregion Property and Variable
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
                calSearchInqGuestDeptDate.Format = calInqGuestarrivalDate.Format = clsSession.DateFormat;

            }
        }
        #region Private Method

        #endregion Private Method

        protected void imtbtnSearCompanyPosting_Click(object sender, EventArgs e)
        {
            try
            {
                gvCompanyPosting.PageIndex = 0;
                BindcompanyPostingGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearSearch()
        {
            txtSearchInqGuestarrivalDate.Text = "";
            txtSearchInqGuestDeptDate.Text = "";
            ddlSearchCompany.SelectedIndex = 0;
        }
        protected void imtbtnRefreshCompanyPosting_Click(object sender, EventArgs e)
        {

            try
            {
                ClearSearch();
                gvCompanyPosting.PageIndex = 0;
                BindcompanyPostingGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindCompany()
        {
            string strCompany = "SELECT CorporateID,CompanyName FROM [dbo].[mst_Corporate]  WHERE ISNULL(IsActive,0) = 1 and ISNULL(IsDirectBill,1) = 1  and PropertyID ='" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID= '" + Convert.ToString(clsSession.CompanyID) + "' Order by [CompanyName] asc";
            DataSet dsCompany = RoomBLL.GetUnitNo(strCompany);

            ddlSearchCompany.Items.Clear();
            if (dsCompany != null && dsCompany.Tables.Count > 0 && dsCompany.Tables[0].Rows.Count > 0)
            {
                ddlSearchCompany.DataSource = dsCompany.Tables[0];
                ddlSearchCompany.DataTextField = "CompanyName";
                ddlSearchCompany.DataValueField = "CorporateID";
                ddlSearchCompany.DataBind();
                ddlSearchCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlSearchCompany.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        private void BindcompanyPostingGrid()
        {
            DataSet ds = new DataSet();
            DateTime? startdt = null;
            DateTime? enddt = null;
            Guid? cmpID = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            if (!ddlSearchCompany.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlSearchCompany.SelectedValue.Equals("")))
                cmpID = (Guid?)new Guid(Convert.ToString(ddlSearchCompany.SelectedValue));
            if (!txtSearchInqGuestarrivalDate.Text.Equals(""))
                startdt = DateTime.ParseExact(txtSearchInqGuestarrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (!txtSearchInqGuestDeptDate.Text.Equals(""))
                enddt = DateTime.ParseExact(txtSearchInqGuestDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            ds = ReservationBLL.GetCompanyPostingReportData(startdt, enddt, cmpID, clsSession.CompanyID, clsSession.PropertyID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                object sumObject;
                sumObject = ds.Tables[0].Compute("Sum(TotalAmount)", "");

                litTotalAmount.Text = "Total : " + Convert.ToString(sumObject.ToString().Substring(0, sumObject.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                gvCompanyPosting.DataSource = ds.Tables[0];
                gvCompanyPosting.DataBind();
            }
            else
            {
                litTotalAmount.Text = "Total : ";
                gvCompanyPosting.DataSource = null;
                gvCompanyPosting.DataBind();
            }
        }

        protected void gvCompanyPosting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompanyPosting.PageIndex = e.NewPageIndex;
            BindcompanyPostingGrid();
        }
        protected void btnPrintCompPosting_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DateTime? startdt = null;
            DateTime? enddt = null;
            Guid? cmpID = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            if (!ddlSearchCompany.SelectedValue.Equals(Guid.Empty.ToString()) && !(ddlSearchCompany.SelectedValue.Equals("")))
                cmpID = (Guid?)new Guid(Convert.ToString(ddlSearchCompany.SelectedValue));
            if (!txtSearchInqGuestarrivalDate.Text.Equals(""))
                startdt = DateTime.ParseExact(txtSearchInqGuestarrivalDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (!txtSearchInqGuestDeptDate.Text.Equals(""))
                enddt = DateTime.ParseExact(txtSearchInqGuestDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            Session["StartDateForPrint"] = startdt;
            Session["EndDateForPrint"] = enddt;
            Session["CorporateID"] = cmpID;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
        }
    }
}