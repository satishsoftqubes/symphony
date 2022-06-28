using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCounterCloseHistoryOnThisMachine : System.Web.UI.UserControl
    {
        #region Property and Variable

        public bool IsPreview = false;
        decimal dcmlHistoryFtTotalAmount = Convert.ToDecimal("0.000000");
        decimal dcmlHistoryFtTotalNetAmount = Convert.ToDecimal("0.000000");

        public TextBox uctxtRow
        {
            get { return this.txtRow; }
        }

        public event EventHandler btnCounterCloseHistoryOnThisMachineCallParent_Click;

        public Guid CloseID
        {
            get
            {
                return ViewState["CloseID"] != null ? new Guid(Convert.ToString(ViewState["CloseID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CloseID"] = value;
            }
        }

        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindBreadCrumb();
                //BindHostoryOfCounterCloseGridByRowFilter();
            }
        }

        #endregion Page Load

        #region Private Methode

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");
            //
            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);



            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Counter Close History";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        public void BindCountersHistoryGird()
        {
            try
            {

                if (this.CloseID != Guid.Empty)
                {
                    DataSet dsHistroyData = CountersBLL.GetCounterCloseSummaryData(null, clsSession.DefaultCounterID, this.CloseID);

                    if (dsHistroyData.Tables.Count > 0 && dsHistroyData.Tables[0].Rows.Count > 0)
                    {
                        dcmlHistoryFtTotalAmount = (decimal)dsHistroyData.Tables[0].Compute("sum(System_Amount)", "");
                        dcmlHistoryFtTotalNetAmount = (decimal)dsHistroyData.Tables[0].Compute("sum(Net_Amount)", "");

                        gvCounterDetails.DataSource = dsHistroyData.Tables[0];
                        gvCounterDetails.DataBind();

                    }
                    else
                    {
                        gvCounterDetails.DataSource = null;
                        gvCounterDetails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindHostoryOfCounterCloseGridByRowFilter()
        {
            try
            {

                int? rowFilter = null;
                if (txtRow.Text.Trim() != "")
                    rowFilter = Convert.ToInt32(txtRow.Text.Trim());

                DataSet dsHistroyData = CountersBLL.GetCounterCloseSummaryData(rowFilter, clsSession.DefaultCounterID, null);

                if (dsHistroyData.Tables.Count > 0 && dsHistroyData.Tables[0].Rows.Count > 0)
                {
                    gvCloseCounterList.DataSource = dsHistroyData.Tables[0];
                    gvCloseCounterList.DataBind();

                    this.CloseID = new Guid(gvCloseCounterList.DataKeys[0]["CloseID"].ToString());
                    BindCountersHistoryGird();
                }
                else
                {
                    gvCloseCounterList.DataSource = null;
                    gvCloseCounterList.DataBind();

                    gvCounterDetails.DataSource = null;
                    gvCounterDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Grid Event

        protected void gvCounterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvHistoryAmount = (Label)e.Row.FindControl("lblGvHistoryAmount");
                    Label lblGvHistoryNetAmount = (Label)e.Row.FindControl("lblGvHistoryNetAmount");

                    decimal dcmlAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "System_Amount"));
                    lblGvHistoryAmount.Text = dcmlAmount.ToString().Substring(0, dcmlAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    decimal dcmlNetAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Net_Amount"));
                    lblGvHistoryNetAmount.Text = dcmlNetAmount.ToString().Substring(0, dcmlNetAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFooterAmount = (Label)e.Row.FindControl("lblGvFooterAmount");
                    lblGvFooterAmount.Text = dcmlHistoryFtTotalAmount.ToString().Substring(0, dcmlHistoryFtTotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvFooterNetAmount = (Label)e.Row.FindControl("lblGvFooterNetAmount");
                    lblGvFooterNetAmount.Text = dcmlHistoryFtTotalNetAmount.ToString().Substring(0, dcmlHistoryFtTotalNetAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCounterDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCounterDetails.PageIndex = e.NewPageIndex;
            BindCountersHistoryGird();
        }

        protected void gvCloseCounterList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvCounterDate = (Label)e.Row.FindControl("lblGvCounterDate");

                    string strDate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Last_Closed_DateTime"));

                    if (strDate != "")
                    {
                        DateTime dtCounterCloseDate = Convert.ToDateTime(strDate);
                        lblGvCounterDate.Text = Convert.ToString(dtCounterCloseDate.ToString(clsSession.DateFormat));
                    }
                    else
                        lblGvCounterDate.Text = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCloseCounterList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("SHOWDATA"))
                {
                    this.CloseID = new Guid(Convert.ToString(e.CommandArgument));
                    BindCountersHistoryGird();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Control Event

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandler temp = btnCounterCloseHistoryOnThisMachineCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("ReportName", "Counter Close History");
                this.IsPreview = false;
                Session.Add("ExportMode", null);
                DataTable dtAccounts = new DataTable();
                dtAccounts.Columns.Add("NO", typeof(int));
                dtAccounts.Columns.Add("Code");
                //dtAccounts.Columns.Add("AcctID");
                dtAccounts.Columns.Add("PayType");
                dtAccounts.Columns.Add("System_Amount", typeof(decimal));
                dtAccounts.Columns.Add("Net_Amount", typeof(decimal));
                dtAccounts.Columns.Add("Difference",typeof(decimal));

                for (int i = 0; i < gvCounterDetails.Rows.Count; i++)
                {
                    //dtAccounts.Rows.Add();
                    DataRow drAccounts = dtAccounts.NewRow();
                    drAccounts["NO"] = i + 1;
                    drAccounts["Code"] = Convert.ToString(gvCounterDetails.DataKeys[i]["Code"]);
                    drAccounts["PayType"] = Convert.ToString(gvCounterDetails.DataKeys[i]["PayType"]);
                    drAccounts["System_Amount"] = ((Label)(gvCounterDetails.Rows[i].FindControl("lblGvHistoryAmount"))).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)(gvCounterDetails.Rows[i].FindControl("lblGvHistoryAmount"))).Text);
                    drAccounts["Net_Amount"] = ((Label)gvCounterDetails.Rows[i].FindControl("lblGvHistoryNetAmount")).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)gvCounterDetails.Rows[i].FindControl("lblGvHistoryNetAmount")).Text);
                    decimal sys = ((Label)(gvCounterDetails.Rows[i].FindControl("lblGvHistoryAmount"))).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)(gvCounterDetails.Rows[i].FindControl("lblGvHistoryAmount"))).Text);
                    decimal net = ((Label)gvCounterDetails.Rows[i].FindControl("lblGvHistoryNetAmount")).Text.Equals("") ? 0 : Convert.ToDecimal(((Label)gvCounterDetails.Rows[i].FindControl("lblGvHistoryNetAmount")).Text);
                    drAccounts["Difference"] = sys - net;
                    dtAccounts.Rows.Add(drAccounts);
                }

                Counters objCnt = CountersBLL.GetByPrimaryKey(this.CloseID);
                Session.Add("RptCounter", objCnt!= null ? objCnt.CounterNo : null);
                Session.Add("Date", System.DateTime.Now);

                DataSet dsGeneralInfo = Counter_Close_DetailBLL.GetCloseCounter_GeneralInformatiom(this.CloseID);
                if (dsGeneralInfo.Tables[0].Rows.Count > 0)
                {                    
                    Session.Add("RptOpening", dsGeneralInfo.Tables[0].Rows[0]["BeignningAmount"]);
                    Session.Add("RptSuggested", dsGeneralInfo.Tables[0].Rows[0]["SuggestedAmount"]);
                    Session.Add("RptShortOver", dsGeneralInfo.Tables[0].Rows[0]["Short_Amount"]);
                    Session.Add("RptActual", dsGeneralInfo.Tables[0].Rows[0]["NewDrawerAmount"]);
                    Session.Add("RptReason", dsGeneralInfo.Tables[0].Rows[0]["Reason"]);
                    Session.Add("RptDropped", dsGeneralInfo.Tables[0].Rows[0]["AmountDropped"]);
                }

                DataSet dsDenomination = Counter_Close_DetailBLL.GetCloseCounter_Denomination(clsSession.PropertyID, this.CloseID);
                DataTable dt = dtAccounts.Copy();
                dt.Merge(dsDenomination.Tables[0], true);
                DataSet finalDS = new DataSet();
                finalDS.Tables.Add(dt);
                Session["DataSource"] = finalDS;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvCounterDetails.PageIndex = 0;
            BindHostoryOfCounterCloseGridByRowFilter();
        }

        #endregion Control Event
    }
}