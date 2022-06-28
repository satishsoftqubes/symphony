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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlLedgerReport : System.Web.UI.UserControl
    {
        #region Property and Variable

        DataSet dsData = null;

        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultValue();
                BindGrid();
            }
        }

        #endregion Page Load

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                calSearchFromDate.Format = calSearchToDate.Format = hfDateFormat.Value = clsSession.DateFormat;

                DataSet ds = TransactionBLL.SelectGeneralData_ForLedgerReport(clsSession.PropertyID, clsSession.CompanyID);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlSearchCounterNo.DataSource = ds.Tables[0];
                    ddlSearchCounterNo.DataTextField = "CounterNo";
                    ddlSearchCounterNo.DataValueField = "CounterID";
                    ddlSearchCounterNo.DataBind();
                    ddlSearchCounterNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchCounterNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ddlSearchResNo.DataSource = ds.Tables[1];
                    ddlSearchResNo.DataTextField = "ReservationNo";
                    ddlSearchResNo.DataValueField = "ReservationID";
                    ddlSearchResNo.DataBind();
                    ddlSearchResNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchResNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ddlSearchAgent.DataSource = ds.Tables[2];
                    ddlSearchAgent.DataTextField = "CompanyName";
                    ddlSearchAgent.DataValueField = "CompanyID";
                    ddlSearchAgent.DataBind();
                    ddlSearchAgent.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchAgent.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    ddlSearchAccount.DataSource = ds.Tables[3];
                    ddlSearchAccount.DataTextField = "AcctName";
                    ddlSearchAccount.DataValueField = "AcctID";
                    ddlSearchAccount.DataBind();
                    ddlSearchAccount.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchAccount.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    ddlSearchFolioNo.DataSource = ds.Tables[4];
                    ddlSearchFolioNo.DataTextField = "FolioNo";
                    ddlSearchFolioNo.DataValueField = "FolioID";
                    ddlSearchFolioNo.DataBind();
                    ddlSearchFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchFolioNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    ddlSearchItem.DataSource = ds.Tables[5];
                    ddlSearchItem.DataTextField = "ItemName";
                    ddlSearchItem.DataValueField = "ItemID";
                    ddlSearchItem.DataBind();
                    ddlSearchItem.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchItem.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                if (ds != null && ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
                {
                    ddlSearchUser.DataSource = ds.Tables[6];
                    ddlSearchUser.DataTextField = "UserDisplayName";
                    ddlSearchUser.DataValueField = "UsearID";
                    ddlSearchUser.DataBind();
                    ddlSearchUser.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchUser.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
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
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                Guid? CounterID = null;
                Guid? ResID = null;
                Guid? AgentID = null;
                Guid? AccountID = null;
                Guid? UserID = null;
                Guid? FolioID = null;
                Guid? ItemID = null;
                DateTime? dtStartDate = null;
                DateTime? dtEndDate = null;
                string strBookNo = null;

                if (ddlSearchCounterNo.SelectedIndex != 0)
                    CounterID = new Guid(ddlSearchCounterNo.SelectedValue);

                if (ddlSearchResNo.SelectedIndex != 0)
                    ResID = new Guid(ddlSearchResNo.SelectedValue);

                if (ddlSearchAgent.SelectedIndex != 0)
                    AgentID = new Guid(ddlSearchAgent.SelectedValue);

                if (ddlSearchAccount.SelectedIndex != 0)
                    AccountID = new Guid(ddlSearchAccount.SelectedValue);

                if (ddlSearchUser.SelectedIndex != 0)
                    UserID = new Guid(ddlSearchUser.SelectedValue);

                if (ddlSearchFolioNo.SelectedIndex != 0)
                    FolioID = new Guid(ddlSearchFolioNo.SelectedValue);

                if (ddlSearchItem.SelectedIndex != 0)
                    ItemID = new Guid(ddlSearchItem.SelectedValue);

                if (Convert.ToString(txtSearchToDate.Text.Trim()) != "")
                    dtStartDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (Convert.ToString(txtSearchToDate.Text.Trim()) != "")
                    dtEndDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (Convert.ToString(txtSearchBookNo.Text.Trim()) != "")
                    strBookNo = Convert.ToString(txtSearchBookNo.Text.Trim());

                dsData = new DataSet();
                dsData = TransactionBLL.GenerateLedgerReports(CounterID, UserID, false, ResID, FolioID, dtStartDate, AccountID, null, AgentID, ItemID, dtEndDate, null, null, strBookNo);

                if (dsData != null && dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    DataTable dtData = new DataTable();
                    dtData = dsData.Tables[0].Copy();

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //if (dtData.Rows.Count > i)
                        //{
                        //    if (Convert.ToString(dtData.Rows[i]["BookNo"]) == Convert.ToString(dtData.Rows[i + 1]["BookNo"]))
                        //    {
                        //        dtData.Rows.RemoveAt(i + 1);
                        //        i--;
                        //    }
                        //}
                        string str = Convert.ToString(dtData.Rows[i]["BookNo"]);
                        DataRow[] dr = dtData.Select("BookNo = '" + str + "'");
                        if (dr.Length > 1)
                        {
                            for (int j = 1; j < dr.Length; j++)
                            {
                                dr[j].Delete();
                                dtData.AcceptChanges();
                            }
                        }
                    }

                    //DataTable dtTemp = dtData;

                    if (dtData.Rows.Count > 0)
                    {
                        gvLedgerReport.DataSource = dtData;
                        gvLedgerReport.DataBind();
                    }
                    else
                    {
                        gvLedgerReport.DataSource = null;
                        gvLedgerReport.DataBind();
                    }
                }
                else
                {
                    gvLedgerReport.DataSource = null;
                    gvLedgerReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSearchControl()
        {
            ddlSearchCounterNo.SelectedIndex = ddlSearchResNo.SelectedIndex = ddlSearchAgent.SelectedIndex = ddlSearchFolioNo.SelectedIndex = ddlSearchItem.SelectedIndex = ddlSearchUser.SelectedIndex = ddlSearchAccount.SelectedIndex = 0;
            txtSearchBookNo.Text = txtSearchFromDate.Text = txtSearchToDate.Text = "";
        }

        #endregion Private Method

        #region Grid Event

        protected void gvLedgerReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal lblParentCR = (Literal)e.Row.FindControl("lblParentCR");
                    Literal lblParentDB = (Literal)e.Row.FindControl("lblParentDB");

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CR")) != "" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CR")) != null)
                        lblParentCR.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CR"));
                    else
                        lblParentCR.Text = "";

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DB")) != "" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DB")) != null)
                        lblParentDB.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DB"));
                    else
                        lblParentDB.Text = "";

                    if (dsData != null && dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                    {
                        GridView InnerGridGRList = (GridView)e.Row.FindControl("InnerGridGRList");

                        Int32 orderseqno = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OrderSeqNo")));
                        DataView dv = new DataView(dsData.Tables[0]);
                        ////dv.RowFilter = "BookNo = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BookNo")) + "'";
                        dv.RowFilter = "BookNo = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BookNo")) + "' and OrderSeqNo <> '" + orderseqno + "'";
                        ////dv.Sort = "OrderSeqNo asc";

                        if (dv.Count > 0)
                        {
                            ////dv.Delete(0);

                            if (dv.Count > 0)
                            {
                                InnerGridGRList.DataSource = dv;
                                InnerGridGRList.DataBind();
                            }
                            else
                            {
                                InnerGridGRList.DataSource = null;
                                InnerGridGRList.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void InnerGridGRList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal lblChildGvCR = (Literal)e.Row.FindControl("lblChildGvCR");
                    Literal lblChildGvDB = (Literal)e.Row.FindControl("lblChildGvDB");

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CR")) != "" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CR")) != null)
                        lblChildGvCR.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CR"));
                    else
                        lblChildGvCR.Text = "";

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DB")) != "" && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DB")) != null)
                        lblChildGvDB.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DB"));
                    else
                        lblChildGvDB.Text = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvLedgerReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLedgerReport.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Button Event

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvLedgerReport.PageIndex = 0;
            BindGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            ClearSearchControl();
            gvLedgerReport.PageIndex = 0;
            BindGrid();
        }

        #endregion Button Event
    }
}