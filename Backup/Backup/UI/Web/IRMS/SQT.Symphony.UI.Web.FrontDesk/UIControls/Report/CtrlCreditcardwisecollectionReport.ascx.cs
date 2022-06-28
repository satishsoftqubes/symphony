using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlCreditcardwisecollectionReport : System.Web.UI.UserControl
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calInqStartDate.Format = clsSession.DateFormat;
                calSearchInqGuestDeptDate.Format = clsSession.DateFormat;
                BindCreditCardWiseCollectionReportData();
            }
        }
        #region Private Method
        private void ClearSearch()
        {
            txtSearchCreditCard.Text = "";
            txtSearchName.Text = "";
            txtSearchSearchEndDate.Text = "";
            txtSearchStartDate.Text = "";
        }
        private void BindCreditCardWiseCollectionReportData()
        {
            DateTime? dtStartDate = null;
            DateTime? dtEndDate = null;
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            string strGuestFullnameTosearch = "";
            string CardNoToSearch = "";

            if (txtSearchStartDate.Text.Trim() != "")
                dtStartDate = DateTime.ParseExact(txtSearchStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            if (txtSearchSearchEndDate.Text.Trim() != "")
                dtEndDate = DateTime.ParseExact(txtSearchSearchEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            if (txtSearchName.Text.Trim() != "")
                strGuestFullnameTosearch = txtSearchName.Text.Trim();

            if (txtSearchCreditCard.Text.Trim() != "")
                CardNoToSearch = txtSearchCreditCard.Text.Trim();
             

            DataSet dsForCreditCardWiseCollection = ReservationBLL.GetCreditCardWiseCollection(clsSession.CompanyID, clsSession.PropertyID, null, dtStartDate, dtEndDate, false, null, null, null, strGuestFullnameTosearch, CardNoToSearch);
            if (dsForCreditCardWiseCollection != null && dsForCreditCardWiseCollection.Tables.Count > 0 && dsForCreditCardWiseCollection.Tables[0].Rows.Count > 0)
            {
                gvCreditCardCollection.DataSource = dsForCreditCardWiseCollection.Tables[0];
                gvCreditCardCollection.DataBind();
            }
            else
            {
                gvCreditCardCollection.DataSource = dsForCreditCardWiseCollection;
                gvCreditCardCollection.DataBind();
            }

        }
        #endregion Private Method
        #endregion Page Load

        #region Control Event
        protected void imtbtnSearchCreditCard_Click(object sender, EventArgs e)
        {
            try
            {
                gvCreditCardCollection.PageIndex = 0;
                BindCreditCardWiseCollectionReportData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void imtbtnSearchClearCreditCard_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvCreditCardCollection.PageIndex = 0;
                BindCreditCardWiseCollectionReportData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event
        protected void gvCreditCardCollection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCreditCardCollection.PageIndex = e.NewPageIndex;
            BindCreditCardWiseCollectionReportData();
        }
        protected void gvCreditCardCollection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("VIEWDETAILTRANSACTION") && e.CommandArgument != null)
            {
                string[] strReportDetailPara = Convert.ToString(e.CommandArgument).Split('|');
                string strGuestNameToPass = "";
               
                DateTime? dtTransactionDateToPass = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                Guid? AcctIDToPass = null;

                if (strReportDetailPara[0] != "")
                    strGuestNameToPass = strReportDetailPara[0].Trim();

                if (strReportDetailPara[1] != "")
                    dtTransactionDateToPass = Convert.ToDateTime(strReportDetailPara[1].Trim());


                if (strReportDetailPara[2] != "")
                    AcctIDToPass = new Guid(strReportDetailPara[2].Trim());



                DataSet dsForCreditCardWiseCollection = ReservationBLL.GetCreditCardWiseCollection(clsSession.CompanyID, clsSession.PropertyID, null, null, null, true, dtTransactionDateToPass, strGuestNameToPass, AcctIDToPass,null,null);
                if (dsForCreditCardWiseCollection != null && dsForCreditCardWiseCollection.Tables.Count > 0 && dsForCreditCardWiseCollection.Tables[0].Rows.Count > 0)
                {
                    gvCreditCardCollectionDetail.DataSource = dsForCreditCardWiseCollection.Tables[0];
                    gvCreditCardCollectionDetail.DataBind();
                    mpeCreditCardDetailsTransaction.Show();
                }
                else
                {
                    gvCreditCardCollectionDetail.DataSource = dsForCreditCardWiseCollection;
                    gvCreditCardCollectionDetail.DataBind();
                    mpeCreditCardDetailsTransaction.Show();
                }
            }
        }
        protected void gvCreditCardCollection_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            Label lblGvTransDeptlDate = (Label)e.Row.FindControl("lblGvTransDeptlDate");
            if (DataBinder.Eval(e.Row.DataItem, "TransDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TransDate")) != "")
            {
                lblGvTransDeptlDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "TransDate")).ToString(clsSession.DateFormat);
            }

        }
        #endregion Grid Event
    }
}