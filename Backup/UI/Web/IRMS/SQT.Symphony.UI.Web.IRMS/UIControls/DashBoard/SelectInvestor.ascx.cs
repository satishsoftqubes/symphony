using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard
{
    public partial class SelectInvestor : System.Web.UI.UserControl
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        public void BindCoOrdinatorWithInvestors(DataSet dsInvestors)
        {
            grdInvestorList.DataSource = dsInvestors;
            grdInvestorList.DataBind();
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
        #endregion

        #region Grid Event
        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }

        protected void grdInvestorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SELECTINVESTOR"))
            {
                Session["InvID"] = e.CommandArgument.ToString();
                Response.Redirect("~/Applications/investordashboard.aspx");
            }
        }
        #endregion
    }
}