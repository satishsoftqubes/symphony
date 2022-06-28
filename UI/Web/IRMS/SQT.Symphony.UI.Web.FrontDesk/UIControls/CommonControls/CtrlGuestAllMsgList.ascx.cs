using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlGuestAllMsgList : System.Web.UI.UserControl
    {

        #region Property and Variables

        public bool IsMessage = false;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPageData();
            }
        }

        private void BindAlertsAndMessages()
        {
            try
            {
                string strMsgFrom = null;

                if (txtSearchMessageFrom.Text.Trim() != "")
                    strMsgFrom = txtSearchMessageFrom.Text.Trim();

                DataSet dsUnreadMsg = GuestMsgJoinBLL.GetGuestMsgJoinSelectUnreadMsgList(clsSession.PropertyID, clsSession.CompanyID, strMsgFrom);
                gvGuestMsgList.DataSource = dsUnreadMsg;
                gvGuestMsgList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

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
            dr3["NameColumn"] = "Guest Messages";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindPageData()
        {
            BindBreadCrumb();
            BindAlertsAndMessages();
        }

        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }

        public void ClearControle()
        {
            txtSearchMessageFrom.Text = "";
        }

        #region Grid Event
        protected void gvGuestMsgList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("MESSAGEDELETE"))
                {
                    mpeConfirmDelete.Show();
                    //GuestMsgJoin objToDetele = GuestMsgJoinBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    //GuestMsgJoinBLL.Delete(objToDetele);
                    //BindAlertsAndMessages();
                }
            }
            catch
            {

            }
        }

        protected void gvGuestMsgList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestMsgList.PageIndex = e.NewPageIndex;
            BindAlertsAndMessages();
        }

        protected void gvGuestMsgList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDeleteMsgMst");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GuestMessageID")));
                }

                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    GuestMsgJoin objToDetele = GuestMsgJoinBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    GuestMsgJoinBLL.Delete(objToDetele);
                    IsMessage = true;
                    lblCommonMsg.Text = "Record Delete successfully.";
                    BindAlertsAndMessages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Controle Events
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            BindAlertsAndMessages();
        }

        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            ClearControle();
            BindAlertsAndMessages();
        }

        #endregion
    }
}