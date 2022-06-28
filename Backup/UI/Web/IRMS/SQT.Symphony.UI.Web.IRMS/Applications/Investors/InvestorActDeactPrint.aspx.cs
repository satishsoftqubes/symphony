using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Configuration;
using System.IO;

namespace SQT.Symphony.UI.Web.IRMS.Applications.Investors
{
    public partial class InvestorActDeactPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        #region Private Method
        private void BindGrid()
        {
            Investor GetInv = new Investor();
            string InvestorName, Location, FirmName;

            int InvestorListPageIndex = 0;
            if (Session["GridInvPageIndex"] != null && Convert.ToString(Session["GridInvPageIndex"]) != "")
                InvestorListPageIndex = Convert.ToInt32(Session["GridInvPageIndex"]);


            if (Convert.ToString(Session["InvestorNameToPrint"]) != "")
                InvestorName = Convert.ToString(Session["InvestorNameToPrint"]);
            else
                InvestorName = null;

            if (!Convert.ToString(Session["LocationToPrint"]).Trim().Equals(""))
                Location = Convert.ToString(Session["LocationToPrint"]).Trim();
            else
                Location = null;

            FirmName = null;



            DataSet Dst = InvestorBLL.SelectAllInvestorsForActiveInActive(InvestorName, Location, FirmName, Convert.ToString(Session["StatusToPrint"]), new Guid(Convert.ToString(Session["CompanyIDForPrint"])));
            if (Dst != null && Dst.Tables.Count > 0 && Dst.Tables[0].Rows.Count > 0)
            {
                grdInvestorList.PageIndex = InvestorListPageIndex;
                grdInvestorList.DataSource = Dst.Tables[0];
                grdInvestorList.DataBind();
            }
            else
            {
                grdInvestorList.DataSource = Dst.Tables[0];
                grdInvestorList.DataBind();
            }

            Session.Remove("GridInvPageIndex");
            Session.Remove("InvestorNameToPrint");
            Session.Remove("LocationToPrint");
            Session.Remove("StatusToPrint");
            Session.Remove("CompanyIDForPrint");
        }
        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
        }
        #endregion Private Method
        #region Grid Event
        protected void grdInvestorList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInvestorList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            litMobileNo.Text = "";
                    }
                    if (DataBinder.Eval(e.Row.DataItem, "UserName") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserName")) != string.Empty)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "IsActive") != null && Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsActive")))
                        {

                            ((Label)e.Row.FindControl("litStatus")).Text = "Active";
                        }
                        else
                        {
                            ((Label)e.Row.FindControl("litStatus")).Text = "DeActive";
                        }
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("litStatus")).Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event
    }
}