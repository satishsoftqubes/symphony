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

namespace SQT.Symphony.UI.Web.BackOffice.GUI.Invoice
{
    public partial class RPTCompanyPostingPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindcompanyPostingGrid();
            }

        }
        private void BindcompanyPostingGrid()
        {
            try
            {
                DataSet ds = new DataSet();
                DateTime? startdt = null;
                DateTime? enddt = null;
                Guid? cmpID = null;

                //startdt = Convert.ToDateTime(Session["StartDateForPrint"]);
                //enddt = Convert.ToDateTime(Session["EndDateForPrint"]);
                //cmpID = new Guid(Convert.ToString(Session["CorporateID"]));

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (Session["CorporateID"] != null && Convert.ToString(Session["CorporateID"]) != "")
                    cmpID = (Guid?)new Guid(Convert.ToString(Session["CorporateID"]));
                if (Session["StartDateForPrint"] != null && Convert.ToString(Session["StartDateForPrint"]) != "")
                {
                    startdt = Convert.ToDateTime(Convert.ToString(Session["StartDateForPrint"]));
                    lblStartDate.Text = Convert.ToDateTime(Convert.ToString(Session["StartDateForPrint"])).ToString(clsSession.DateFormat);
                }
                if (Session["EndDateForPrint"] != null && Convert.ToString(Session["EndDateForPrint"]) != "")
                {
                    enddt = Convert.ToDateTime(Convert.ToString(Session["EndDateForPrint"]));
                    lblEndDate.Text = Convert.ToDateTime(Convert.ToString(Session["EndDateForPrint"])).ToString(clsSession.DateFormat);
                }

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
                    gvCompanyPosting.DataSource = null;
                    gvCompanyPosting.DataBind();
                }
                Session["StartDateForPrint"] = null;
                Session["EndDateForPrint"] = null;
                Session["CorporateID"] = null;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCompanyPosting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompanyPosting.PageIndex = e.NewPageIndex;
            BindcompanyPostingGrid();
        }
    }
}