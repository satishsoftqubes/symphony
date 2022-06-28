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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing
{
    public partial class CtrlUnsettledCheckOut : System.Web.UI.UserControl
    {
        #region Property and Variable
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
        public int RowIndex
        {
            get
            {
                return ViewState["RowIndex"] != null ? Convert.ToInt32(ViewState["RowIndex"]) : 0;
            }
            set
            {
                ViewState["RowIndex"] = value;
            }
        }

        public string strIsValidate
        {
            get
            {
                return ViewState["strIsValidate"] != null ? Convert.ToString(ViewState["strIsValidate"]) : string.Empty;
            }
            set
            {
                ViewState["strIsValidate"] = value;
            }
        }

        public string strOpenModalDialog
        {
            get
            {
                return ViewState["strOpenModalDialog"] != null ? Convert.ToString(ViewState["strOpenModalDialog"]) : string.Empty;
            }
            set
            {
                ViewState["strOpenModalDialog"] = value;
            }
        }

        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                LoadDefaultvalue();
            }
        }

        #endregion

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UnsettledCheckOut.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void LoadDefaultvalue()
        {
            try
            {
                //BindRoomType();
                BindBreadCrumb();
                BindFolioGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindFolioGrid()
        {
            try
            {
                //Guid? RoomTypeID = null;
                //string strCompanyName = null;

                //if (txtSearchCompany.Text.Trim() != "")
                //    strCompanyName = Convert.ToString(txtSearchCompany.Text.Trim());

                //if (ddlSearchUnitType.SelectedIndex != 0)
                //    RoomTypeID = new Guid(ddlSearchUnitType.SelectedValue);

                string strFolioNo = null;
                string strRoomNo = null;
                string strGuestName = null;

                if (txtSearchFolioNo.Text.Trim() != "")
                    strFolioNo = Convert.ToString(txtSearchFolioNo.Text.Trim());

                if (txtSearchRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                if (txtSearchGuestName.Text.Trim() != "")
                    strGuestName = Convert.ToString(txtSearchGuestName.Text.Trim());

                DataSet dsFolioList = FolioBLL.SelectAllCheckOutOpenFolios(strFolioNo, strRoomNo, strGuestName, clsSession.CompanyID, clsSession.PropertyID);

                if (dsFolioList.Tables.Count > 0 && dsFolioList.Tables[0].Rows.Count > 0)
                {
                    decimal dcmlftBalance = Convert.ToDecimal("0.000000");
                    dcmlftBalance = (decimal)dsFolioList.Tables[0].Compute("sum(BALANCE) * (-1)", "");

                    lblDispalyTotalFolioBalance.Text = dcmlftBalance.ToString().Substring(0, dcmlftBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    gvFolioList.DataSource = dsFolioList.Tables[0];
                    gvFolioList.DataBind();
                }
                else
                {
                    lblDispalyTotalFolioBalance.Text = "0.00";
                    gvFolioList.DataSource = null;
                    gvFolioList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSearchControl()
        {
            //ddlSearchUnitType.SelectedIndex = 0;
            //txtSearchCompany.Text = "";
            txtSearchFolioNo.Text = txtSearchGuestName.Text = txtSearchRoomNo.Text = "";
        }

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
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

           

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Billing";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Unsettled Check Out ";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Control Event
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvFolioList.PageIndex = 0;
            BindFolioGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            gvFolioList.PageIndex = 0;
            ClearSearchControl();
            BindFolioGrid();
        }

        #endregion

        #region Grid Event

        protected void gvFolioList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RowIndex = 0;
                this.strIsValidate = this.strOpenModalDialog = string.Empty;

                if (e.CommandName.Equals("CHECKOUT"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "CHECKOUT RESERVATION";
                    Response.Redirect("~/GUI/Billing/CheckOut.aspx");
                }
                else if (e.CommandName.ToUpper().Equals("FOLIODETAILS_NEW"))
                {
                    LinkButton lb = (LinkButton)e.CommandSource;

                    GridViewRow gvr = (GridViewRow)lb.NamingContainer;
                    Guid id = (Guid)(gvFolioList.DataKeys[gvr.RowIndex]["FolioID"]);

                    Label lblGvBalance = (Label)gvFolioList.Rows[gvr.RowIndex].FindControl("lblGvBalance");

                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "FOLIODETAILS";
                    Session["FolioListFolioID"] = Convert.ToString(id);
                    Session["FolioListFolioBalance"] = Convert.ToString(lblGvBalance.Text.Trim());

                    Response.Redirect("~/GUI/Folio/FolioDetailsOld.aspx");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void gvFolioList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label lblGvRoomNo = (Label)e.Row.FindControl("lblGvRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    Label lblGvBalance = (Label)e.Row.FindControl("lblGvBalance");
                    decimal dcmlBalance = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BALANCE"));
                    dcmlBalance = dcmlBalance * (-1);
                    lblGvBalance.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvFolioList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFolioList.PageIndex = e.NewPageIndex;
            BindFolioGrid();
        }

        #endregion

        protected void btnSaveCounterData_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strIsValidate == "YES")
                {
                    mpeOpenCounter.Show();

                    if (ucCommonCounterLogin.ucddlCounter.SelectedIndex != 0)
                        ucCommonCounterLogin.SaveDataInCounter();
                    else
                    {
                        mpeCounterErrorMessage.Show();
                        return;
                    }
                }

                mpeOpenCounter.Hide();

                if (ucCommonCounterLogin.DefaultCounterID != Guid.Empty && ucCommonCounterLogin.CounterLoginLogID != Guid.Empty)
                {
                    clsSession.DefaultCounterID = ucCommonCounterLogin.DefaultCounterID;
                    clsSession.CounterLoginLogID = ucCommonCounterLogin.CounterLoginLogID;
                    clsSession.CounterName = Convert.ToString(ucCommonCounterLogin.CounterName);
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}