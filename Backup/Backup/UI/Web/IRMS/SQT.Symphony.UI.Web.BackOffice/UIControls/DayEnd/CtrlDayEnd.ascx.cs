using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.DayEnd
{
    public partial class CtrlDayEnd : System.Web.UI.UserControl
    {
        #region Property and Variable

        public bool IsMessage = false;

        public string strAction
        {
            get
            {
                return ViewState["strAction"] != null ? Convert.ToString(ViewState["strAction"]) : string.Empty;
            }
            set
            {
                ViewState["strAction"] = value;
            }
        }

        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                {
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");
                }
                else
                {
                    //BindGrid();
                    clsSession.DefaultCounterID = new Guid("ACADEE48-26EC-4A92-8AAE-BC2F8C4E8037");
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                    Session["DayEndData"] = null;
                    litDayEndDetails.Text = "";
                    btnPost.Visible = false;
                    BindBreadCrumb();
                }
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBackOfficeSetup", "BackOffice Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Day End";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void CheckAvailabilityForDayEnd()
        {
            try
            {
                litDayEndDetails.Text = "";
                gvDayEndDetails.DataSource = null;
                gvDayEndDetails.DataBind();

                Session["DayEndData"] = null;
                btnPost.Visible = false;
                int cnt = 0;

                DataSet dsPreCheckData = DayEndBLL.Get_DayEnd_PreCheckReport(null, clsSession.PropertyID,clsSession.CompanyID);

                if (dsPreCheckData.Tables.Count > 0 && dsPreCheckData.Tables[0].Rows.Count > 0)
                {
                    Session["DayEndData"] = dsPreCheckData;

                    DataView dvCheckIn = new DataView(dsPreCheckData.Tables[0]);
                    dvCheckIn.RowFilter = "Opeartion Like 'ARRIVAL'";

                    if (dvCheckIn.Count == 1)
                    {
                        //temperory off
                        //cnt++;
                        lnkCheckIn.Enabled = false;
                        imgCheckIn.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkCheckIn.Enabled = true;
                        imgCheckIn.ImageUrl = "~/images/24_x_false.png";
                    }


                    DataView dvCheckOut = new DataView(dsPreCheckData.Tables[0]);
                    dvCheckOut.RowFilter = "Opeartion Like 'DEPARTURE'";

                    if (dvCheckOut.Count == 1)
                    {
                        //temperory off
                        //cnt++;
                        lnkCheckOut.Enabled = false;
                        imgCheckOut.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkCheckOut.Enabled = true;
                        imgCheckOut.ImageUrl = "~/images/24_x_false.png";
                    }

                    DataView dvDepositTransfer = new DataView(dsPreCheckData.Tables[0]);
                    dvDepositTransfer.RowFilter = "Opeartion Like 'DEPOSIT'";

                    if (dvDepositTransfer.Count == 1)
                    {
                        //temperory off
                        //cnt++;
                        lnkDepositTranferred.Enabled = false;
                        imgDepositTranferred.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkDepositTranferred.Enabled = true;
                        imgDepositTranferred.ImageUrl = "~/images/24_x_false.png";
                    }

                    DataView dvAccomodation = new DataView(dsPreCheckData.Tables[0]);
                    dvAccomodation.RowFilter = "Opeartion Like 'ROOM_POSTING'";

                    if (dvAccomodation.Count == 1)
                    {
                        cnt++;
                        lnkPOSTAccomodationCharges.Enabled = false;
                        imgPOSTAccomodationCharges.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkPOSTAccomodationCharges.Enabled = true;
                        imgPOSTAccomodationCharges.ImageUrl = "~/images/24_x_false.png";
                    }

                    DataView dvService = new DataView(dsPreCheckData.Tables[0]);
                    dvService.RowFilter = "Opeartion Like 'ROOM_SERVICE_POSTING'";

                    if (dvService.Count == 1)
                    {
                        cnt++;
                        lnkPOSTServiceCharges.Enabled = false;
                        imgPOSTServiceCharges.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkPOSTServiceCharges.Enabled = true;
                        imgPOSTServiceCharges.ImageUrl = "~/images/24_x_false.png";
                    }

                    DataView dvBalanceSheet = new DataView(dsPreCheckData.Tables[0]);
                    dvBalanceSheet.RowFilter = "Opeartion Like 'CR_DB_BALANCE'";

                    if (dvBalanceSheet.Count == 1)
                    {
                        cnt++;
                        lnkACBalanceSheet.Enabled = false;
                        imgACBalanceSheet.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkACBalanceSheet.Enabled = true;
                        imgACBalanceSheet.ImageUrl = "~/images/24_x_false.png";
                    }

                    DataView dvCounter = new DataView(dsPreCheckData.Tables[0]);
                    dvCounter.RowFilter = "Opeartion Like 'CLOSE_COUNTER'";

                    if (dvCounter.Count == 1)
                    {
                        //temperory off
                        //cnt++;
                        lnkCloseCounter.Enabled = false;
                        imgCloseCounter.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkCloseCounter.Enabled = true;
                        imgCloseCounter.ImageUrl = "~/images/24_x_false.png";
                    }

                    //temperory change
                    //if (Convert.ToString(cnt) == "7")
                    if (Convert.ToString(cnt) == "3")
                        btnDayEnd.Visible = true;
                    else
                        btnDayEnd.Visible = false;

                }
                else
                {
                    lnkCheckIn.Enabled = lnkCheckOut.Enabled = lnkDepositTranferred.Enabled = lnkPOSTAccomodationCharges.Enabled = lnkPOSTServiceCharges.Enabled = lnkACBalanceSheet.Enabled = lnkCloseCounter.Enabled = true;
                    imgCheckIn.ImageUrl = imgCheckOut.ImageUrl = imgDepositTranferred.ImageUrl = imgPOSTAccomodationCharges.ImageUrl = imgPOSTServiceCharges.ImageUrl = imgACBalanceSheet.ImageUrl = imgCloseCounter.ImageUrl = "~/images/24_x_false.png";
                    btnDayEnd.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Control Event

        protected void lnkCheckOut_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Checkout Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsCheckOutData = (DataSet)Session["DayEndData"];
                    DataView dvCheckOutData = new DataView(dsCheckOutData.Tables[0]);
                    dvCheckOutData.RowFilter = "Opeartion Like 'DEPARTURE' and CodeID <> '0'";

                    if (dvCheckOutData.Count > 0)
                    {
                        this.strAction = "CHECKOUT";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvCheckOutData;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkCheckIn_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Checkin Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsCheckInData = (DataSet)Session["DayEndData"];
                    DataView dvCheckInData = new DataView(dsCheckInData.Tables[0]);
                    dvCheckInData.RowFilter = "Opeartion Like 'ARRIVAL' and CodeID <> '0'";

                    if (dvCheckInData.Count > 0)
                    {
                        this.strAction = "CHECKIN";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvCheckInData;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkDepositTranferred_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Deposit Tranferred Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsDepositTranferred = (DataSet)Session["DayEndData"];
                    DataView dvDepositTranferred = new DataView(dsDepositTranferred.Tables[0]);
                    dvDepositTranferred.RowFilter = "Opeartion Like 'DEPOSIT' and CodeID <> '0'";

                    if (dvDepositTranferred.Count > 0)
                    {
                        this.strAction = "DEPOSTITRANSFERRED";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvDepositTranferred;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkPOSTAccomodationCharges_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "POST Accomodation Charges Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsAccomodationCharges = (DataSet)Session["DayEndData"];
                    DataView dvAccomodationCharges = new DataView(dsAccomodationCharges.Tables[0]);
                    dvAccomodationCharges.RowFilter = "Opeartion Like 'ROOM_POSTING' and CodeID <> '0'";

                    if (dvAccomodationCharges.Count > 0)
                    {
                        this.strAction = "ACCOMODATIONCHARGES";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvAccomodationCharges;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkPOSTServiceCharges_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "POST Service Charges Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsService = (DataSet)Session["DayEndData"];
                    DataView dvService = new DataView(dsService.Tables[0]);
                    dvService.RowFilter = "Opeartion Like 'ROOM_POSTING' and CodeID <> '0'";

                    if (dvService.Count > 0)
                    {
                        this.strAction = "POSTSERVICE";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvService;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkACBalanceSheet_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "A/C Balance Sheet Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsBalanceSheet = (DataSet)Session["DayEndData"];
                    DataView dvBalanceSheet = new DataView(dsBalanceSheet.Tables[0]);
                    dvBalanceSheet.RowFilter = "Opeartion Like 'CR_DB_BALANCE' and CodeID <> '0'";

                    if (dvBalanceSheet.Count > 0)
                    {
                        this.strAction = "BALANCESHEET";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvBalanceSheet;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkCloseCounter_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Close Counter Detail List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsCounter = (DataSet)Session["DayEndData"];
                    DataView dvCounter = new DataView(dsCounter.Tables[0]);
                    dvCounter.RowFilter = "Opeartion Like 'CLOSE_COUNTER' and CodeID <> '0'";

                    if (dvCounter.Count > 0)
                    {
                        this.strAction = "COUNTERCLOSE";
                        btnPost.Visible = true;
                        gvDayEndDetails.DataSource = dvCounter;
                        gvDayEndDetails.DataBind();
                    }
                    else
                    {
                        btnPost.Visible = false;
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPreChecks_OnClick(object sender, EventArgs e)
        {
            CheckAvailabilityForDayEnd();
        }

        protected void btnDayEnd_Click(object sender, EventArgs e)
        {
            try
            {
                txtConfirmMessage.Text = "";
                mpeConfirmMessage.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnConfirmMessageOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtConfirmMessage.Text.Trim()) != "")
                {
                    if (Convert.ToString(txtConfirmMessage.Text.Trim()) == "YES")
                    {
                        bool blreturnIsSuccess = false;
                        blreturnIsSuccess = DayEndBLL.DayEnd_Save(clsSession.UserID, txtConfirmMessage.Text.Trim(), null, clsSession.CompanyID, clsSession.PropertyID);

                        if (blreturnIsSuccess)
                        {
                            if (clsSession.LogInLogID != Guid.Empty)
                            {
                                LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                                objToUpdate.Logout = DateTime.Now;
                                LoginLogBLL.Update(objToUpdate);

                                Session.Clear();
                                Response.Redirect("~/Index.aspx");
                            }

                            //IsMessage = true;
                            //lblCommonMsg.Text = "Day End Successfully.";
                            //CheckAvailabilityForDayEnd();
                        }
                    }
                    else
                    {
                        lblCustomePopupMsg.Text = "Day End Process Cancelled.";
                        mpeCustomePopup.Show();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strAction != string.Empty)
                {
                    DateTime dtStart;
                    if (this.strAction == "ACCOMODATIONCHARGES")
                    {
                        if (gvDayEndDetails.Rows.Count > 0)
                        {
                            BlockDateRate objBlockDateRate = new BlockDateRate();
                            objBlockDateRate = BlockDateRateBLL.GetByPrimaryKey(new Guid(gvDayEndDetails.DataKeys[0]["CodeID"].ToString()));

                            if (objBlockDateRate != null)
                            {
                                dtStart = Convert.ToDateTime(objBlockDateRate.BlockDate);

                                TimeSpan ts = DateTime.Now.Date.Subtract(dtStart.Date);
                                for (int i = 0; i <= ts.TotalDays; i++)
                                {
                                    DayEndBLL.Reservation_AutoPostRoomAndServiceCharge(dtStart.AddDays((double)i), clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "RESERVATION", clsSession.CompanyID);
                                }
                            }

                            CheckAvailabilityForDayEnd();
                            IsMessage = true;
                            lblCommonMsg.Text = "Service Posted Successfully.";
                        }
                    }
                    else if (this.strAction == "POSTSERVICE")
                    {
                        ResServiceList objResServiceList = new ResServiceList();
                        objResServiceList = ResServiceListBLL.GetByPrimaryKey(new Guid(gvDayEndDetails.DataKeys[0]["CodeID"].ToString()));

                        if (objResServiceList != null)
                        {
                            if (objResServiceList.PostingDate != null && Convert.ToString(objResServiceList.PostingDate) != "")
                            {
                                dtStart = Convert.ToDateTime(objResServiceList.PostingDate);

                                TimeSpan ts = DateTime.Now.Date.Subtract(dtStart.Date);
                                for (int i = 0; i <= ts.TotalDays; i++)
                                {
                                    DayEndBLL.Reservation_AutoPostRoomAndServiceCharge(dtStart.AddDays((double)i), clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "RESERVATION", clsSession.CompanyID);
                                }
                            }
                        }

                        CheckAvailabilityForDayEnd();
                        IsMessage = true;
                        lblCommonMsg.Text = "Service Posted Successfully.";
                    }
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

        protected void gvDayEndDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    //((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkSelectAll")).ClientID + "')");
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //LinkButton LinkButton = (LinkButton)e.Row.FindControl("lnkAction");

                    //if (litDayEndDetails.Text == "Checkout Detail List")
                    //{
                    //    LinkButton.CommandName = "CHECKOUT";
                    //    LinkButton.ToolTip = "Checkout";
                    //}
                    //else if (litDayEndDetails.Text == "Checkin Detail List")
                    //{
                    //    LinkButton.CommandName = "CHECKIN";
                    //    LinkButton.ToolTip = "Checkin";
                    //}
                    //else if (litDayEndDetails.Text == "Deposit Tranferred Detail List")
                    //{
                    //    LinkButton.CommandName = "DEPOSIT";
                    //    LinkButton.ToolTip = "Deposit Tranferred";
                    //}
                    //else if (litDayEndDetails.Text == "POST Accomodation Charges Detail List")
                    //{
                    //    LinkButton.CommandName = "ACCOMODATION";
                    //    LinkButton.ToolTip = "POST Accomodation Charges";
                    //}
                    //else if (litDayEndDetails.Text == "POST Service Charges Detail List")
                    //{
                    //    LinkButton.CommandName = "SERVICE";
                    //    LinkButton.ToolTip = "POST Service Charges";
                    //}
                    //else if (litDayEndDetails.Text == "A/C Balance Sheet Detail List")
                    //{
                    //    LinkButton.CommandName = "BALANCE";
                    //    LinkButton.ToolTip = "A/C Balance Sheet";
                    //}
                    //else if (litDayEndDetails.Text == "A/C Balance Sheet Detail List")
                    //{
                    //    LinkButton.CommandName = "COUNTER";
                    //    LinkButton.ToolTip = "Close Counter";
                    //}
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion        
    }
}