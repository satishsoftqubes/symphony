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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlFolioList : System.Web.UI.UserControl
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
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "FolioList.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void LoadDefaultvalue()
        {
            try
            {
                if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["IsUpperCase"]) != string.Empty && Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["IsUpperCase"]) == "1")
                {
                    txtSearchFolioNo.Style.Add("text-transform","uppercase");
                    txtSearchGuestName.Style.Add("text-transform", "uppercase");
                    txtSearchRoomNo.Style.Add("text-transform", "uppercase");
                }
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

                DataSet dsFolioList = FolioBLL.GetAllFolio(1, false, clsSession.CompanyID, clsSession.PropertyID, null, null, strGuestName, strRoomNo, strFolioNo);

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

        //private void BindRoomType()
        //{
        //    string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";

        //    ddlSearchUnitType.Items.Clear();
        //    DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
        //    if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
        //    {
        //        ddlSearchUnitType.DataSource = dsRoomType.Tables[0];
        //        ddlSearchUnitType.DataTextField = "RoomTypeName";
        //        ddlSearchUnitType.DataValueField = "RoomTypeID";
        //        ddlSearchUnitType.DataBind();

        //        ddlSearchUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlSearchUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Billing";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Folio List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Control Event

        protected void btnMoveUnitCallParent_Click(object sender, EventArgs e)
        {
            string strOpenView = CtrlCommonMoveUnitSetup.strMode;

            if (strOpenView.ToUpper() == "OPENCHANGEROOMHISTORY")
                CtrlCommonMoveUnitSetup.mvOpenMoveUnitHistory.ActiveViewIndex = 1;
            else
                CtrlCommonMoveUnitSetup.mvOpenMoveUnitHistory.ActiveViewIndex = 0;
            ////CtrlCommonMoveUnitSetup.ucMpeAddEditMoveUnit.Show();
            mpeMoveUnit.Show();
        }

        protected void btnQuickPostCallParent_Click(object sender, EventArgs e)
        {
            if (ctrlCommonQuickPost.Mode == "REFRESHFOLIOLIST")
                BindFolioGrid();
            else
            {
                ctrlCommonQuickPost.mvOpenQuickPost.ActiveViewIndex = 1;
                ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
            }
        }

        protected void btnCommonFolioPostChargeCallParent_Click(object sender, EventArgs e)
        {
            BindFolioGrid();
        }

        protected void btnCommonFolioPostCreditCallParent_Click(object sender, EventArgs e)
        {
            BindFolioGrid();
        }

        protected void btnPaymentCallParent_Click(object sender, EventArgs e)
        {
            if (ctrlCommonPayment.strMode != null && ctrlCommonPayment.strMode == "REFRESHFOLIOLISTGRID")
            {
                BindFolioGrid();
            }
            else
            {
                ctrlCommonPayment.mvOpenPayment.ActiveViewIndex = 1;
                ctrlCommonPayment.ucMpeAddEditPayment.Show();
            }
        }

        protected void btnPostUnitChargesParent_Click(object sender, EventArgs e)
        {
            if (CtrlCommonPostUnitCharges.strMode != null && CtrlCommonPostUnitCharges.strMode == "REFRESHFOLIOLISTGRID")
            {
                BindFolioGrid();
            }
        }

        //protected void lnkFolioListQuickPost_Click(object sender, EventArgs e)
        //{            
        //    ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
        //}

        //protected void lnkFolioListGuestMessage_Click(object sender, EventArgs e)
        //{
        //    ////ctrlCommonMessage.ucMpeMessage.Show();
        //    mpeMessage.Show();
        //}

        //protected void lnkFolioListPaymentInfo_Click(object sender, EventArgs e)
        //{
        //    ctrlCommonCardInfo.uclitDisplayCardHolderName.Text = ctrlCommonCardInfo.uctxtCardHolderName.Text = "Mr. Prakash Patel";
        //    ctrlCommonCardInfo.ucMpeAddEditCardInfo.Show();
        //}

        //protected void CheckIn_Click(object sender, EventArgs e)
        //{
        //    //ctrlCommonCheckIn.ucMpeCheckIn.Show();
        //    mpeCheckIn.Show();
        //    ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;

        //}

        protected void btnCheckInCallParent_Click(object sender, EventArgs e)
        {
            string strOperation = ctrlCommonCheckIn.strMode;

            if (strOperation == "OPENADDSERVICEPOPUP")
            {
                mpeCheckIn.Show();
                ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 1;
            }
            else if (strOperation == "CLOSEADDSERVICEPOPUP")
            {
                mpeCheckIn.Show();
                ctrlCommonCheckIn.ucmvCheckIn.ActiveViewIndex = 0;
            }
        }

        protected void btnExtendReservationCallParent_Click(object sender, EventArgs e)
        {
            mpeExtendReservation.Show();
        }

        protected void btnMessageCallParent_Click(object sender, EventArgs e)
        {
            mpeMessage.Show();
            ////if(ctrlCommonMessage.strView == "1")
            ////    ctrlCommonMessage.mvOpenMessage.ActiveViewIndex = 1;
            ////else
            ////    ctrlCommonMessage.mvOpenMessage.ActiveViewIndex = 0;
        }

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

                if (e.CommandName.ToUpper().Equals("MOVEUNIT"))
                {
                    ////CtrlCommonMoveUnitSetup.ucMpeAddEditMoveUnit.Show();
                    mpeMoveUnit.Show();
                }
                else if (e.CommandName.Equals("QUICKPOST"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "QUICKPOST";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                        ucCommonCounterLogin.CounterName = string.Empty;

                        ucCommonCounterLogin.CheckAuthentication();

                        if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                        {
                            mpeOpenCounter.Show();
                        }
                        else
                        {
                            lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                            mpeCounterErrorMessage.Show();
                            return;
                        }

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    LoadQuickPostData();
                }
                else if (e.CommandName.Equals("UNITCHARGES"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    CtrlCommonPostUnitCharges.FolioID = new Guid(Convert.ToString(gvFolioList.DataKeys[row.RowIndex]["FolioID"]));
                    CtrlCommonPostUnitCharges.ReservationID = new Guid(Convert.ToString(gvFolioList.DataKeys[row.RowIndex]["ReservationID"]));
                    CtrlCommonPostUnitCharges.BindFolioDetail();
                    CtrlCommonPostUnitCharges.ucMpeAddEditPostUnitCharges.Show();

                }
                else if (e.CommandName.Equals("PAYMENT"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "PAYMENT";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        //Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx?IsCounter=0");

                        ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                        ucCommonCounterLogin.CounterName = string.Empty;

                        ucCommonCounterLogin.CheckAuthentication();

                        if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                        {
                            mpeOpenCounter.Show();
                        }
                        else
                        {
                            lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                            mpeCounterErrorMessage.Show();
                            return;
                        }

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    LoadPaymentData();
                }
                else if (e.CommandName.Equals("PAYMENTINFORMATION"))
                {
                    ctrlCommonCardInfo.uclitDisplayCardHolderName.Text = ctrlCommonCardInfo.uctxtCardHolderName.Text = "Mr. Prakash Patel";
                    ctrlCommonCardInfo.ucMpeAddEditCardInfo.Show();
                }
                else if (e.CommandName.Equals("EXTENDRESERVATION"))
                {
                    ////CtrlCommonExtendReservation.ucMpeAddEditExtendReservation.Show();
                    mpeExtendReservation.Show();
                }
                else if (e.CommandName.ToUpper().Equals("FOLIODETAILS"))
                {
                    LinkButton lb = (LinkButton)e.CommandSource;
                    GridViewRow gvr = (GridViewRow)lb.NamingContainer;
                    Guid id = (Guid)(gvFolioList.DataKeys[gvr.RowIndex]["FolioID"]);

                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "FOLIODETAILS";
                    Session["GuestFolioID"] = Convert.ToString(id);
                    Response.Redirect("~/GUI/Folio/FolioDetails.aspx");
                }
                else if (e.CommandName.ToUpper().Equals("CHECKOUT"))
                {
                    Response.Redirect("~/GUI/Billing/CheckOut.aspx?PostCharges=true");
                }
                else if (e.CommandName.ToUpper().Equals("TRANSFERTRANSACTION"))
                {
                    LinkButton lb = (LinkButton)e.CommandSource;
                    GridViewRow gvr = (GridViewRow)lb.NamingContainer;

                    Guid id = (Guid)(gvFolioList.DataKeys[gvr.RowIndex]["ReservationID"]);
                    Label lblGvBalance = (Label)gvFolioList.Rows[gvr.RowIndex].FindControl("lblGvBalance");

                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "TRANSFERTRANSACTION";
                    Session["FolioListReservationID"] = Convert.ToString(id);
                    Session["FolioListBalance"] = Convert.ToString(lblGvBalance.Text.Trim());
                    Response.Redirect("~/GUI/Folio/TransferTransactionFolio.aspx");
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
                else if (e.CommandName.ToUpper().Equals("POSTCHARGE"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "POSTCHARGE";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                        ucCommonCounterLogin.CounterName = string.Empty;

                        ucCommonCounterLogin.CheckAuthentication();

                        if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                        {
                            mpeOpenCounter.Show();
                        }
                        else
                        {
                            lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                            mpeCounterErrorMessage.Show();
                            return;
                        }

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    LoadPostChargeData();
                }
                else if (e.CommandName.ToUpper().Equals("POSTCREDIT"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.RowIndex = Convert.ToInt32(row.RowIndex);
                    this.strOpenModalDialog = "POSTCREDIT";

                    if (clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null)
                    {
                        ucCommonCounterLogin.CounterLoginLogID = ucCommonCounterLogin.DefaultCounterID = Guid.Empty;
                        ucCommonCounterLogin.CounterName = string.Empty;

                        ucCommonCounterLogin.CheckAuthentication();

                        if (ucCommonCounterLogin.strRights == "ALLOWOPEN")
                        {
                            mpeOpenCounter.Show();
                        }
                        else
                        {
                            lblCounterErrorMessage.Text = "You have not permission to do this operation.";
                            mpeCounterErrorMessage.Show();
                            return;
                        }

                        this.strIsValidate = Convert.ToString(ucCommonCounterLogin.strValidate);
                        return;
                    }

                    LoadPostCreditData();
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

                    if (this.strOpenModalDialog == "QUICKPOST")
                        LoadQuickPostData();
                    else if (this.strOpenModalDialog == "PAYMENT")
                        LoadPaymentData();
                    else if (this.strOpenModalDialog == "POSTCHARGE")
                        LoadPostChargeData();
                    else if (this.strOpenModalDialog == "POSTCREDIT")
                        LoadPostCreditData();
                    
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadQuickPostData()
        {
            try
            {
                ctrlCommonQuickPost.BindModeOfPayment();
                ctrlCommonQuickPost.ClearControl();
                ctrlCommonQuickPost.BindQuickPostGrid();

                int row = this.RowIndex;

                Label lblGvGuestName = (Label)gvFolioList.Rows[row].FindControl("lblGvGuestName");
                Label lblGvRoomNo = (Label)gvFolioList.Rows[row].FindControl("lblGvRoomNo");
                Label lblGvBalance = (Label)gvFolioList.Rows[row].FindControl("lblGvBalance");
                LinkButton lnkFolioNo = (LinkButton)gvFolioList.Rows[row].FindControl("lnkFolioNo");

                ctrlCommonQuickPost.litFolioNo.Text = Convert.ToString(lnkFolioNo.Text.Trim());
                ctrlCommonQuickPost.litGuestName.Text = Convert.ToString(lblGvGuestName.Text.Trim());
                ctrlCommonQuickPost.litRoomNo.Text = Convert.ToString(lblGvRoomNo.Text.Trim());
                ctrlCommonQuickPost.litBalance.Text = Convert.ToString(lblGvBalance.Text.Trim());

                ctrlCommonQuickPost.FolioID = new Guid(Convert.ToString(gvFolioList.DataKeys[row]["FolioID"]));
                ctrlCommonQuickPost.ReservationID = new Guid(Convert.ToString(gvFolioList.DataKeys[row]["ReservationID"]));
                ctrlCommonQuickPost.GuestID = new Guid(Convert.ToString(gvFolioList.DataKeys[row]["GuestID"]));

                ctrlCommonQuickPost.ucMpeAddEditQuickPost.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadPaymentData()
        {
            try
            {
                int row = this.RowIndex;

                ctrlCommonPayment.ucMpeAddEditPayment.Show();

                Label lblGvGuestName = (Label)gvFolioList.Rows[row].FindControl("lblGvGuestName");
                Label lblGvRoomNo = (Label)gvFolioList.Rows[row].FindControl("lblGvRoomNo");
                Label lblGvBalance = (Label)gvFolioList.Rows[row].FindControl("lblGvBalance");
                LinkButton lnkFolioNo = (LinkButton)gvFolioList.Rows[row].FindControl("lnkFolioNo");
                Label lblGvRoomTypeName = (Label)gvFolioList.Rows[row].FindControl("lblGvRoomTypeName");

                ctrlCommonPayment.IsMessage = false;
                ctrlCommonPayment.uclitDisplayPaymentFolioNo.Text = Convert.ToString(lnkFolioNo.Text.Trim());
                ctrlCommonPayment.uclitDisplayPaymentGuestName.Text = Convert.ToString(lblGvGuestName.Text.Trim());
                ctrlCommonPayment.uclitDisplayRoomNoAndRoomType.Text = Convert.ToString(lblGvRoomNo.Text.Trim() + " - " + lblGvRoomTypeName.Text.Trim());
                ctrlCommonPayment.uclitDisplayPaymentBalance.Text = Convert.ToString(lblGvBalance.Text.Trim());
                ctrlCommonPayment.ReservationID = new Guid(gvFolioList.DataKeys[row]["ReservationID"].ToString());
                ctrlCommonPayment.FolioID = new Guid(gvFolioList.DataKeys[row]["FolioID"].ToString());
                ctrlCommonPayment.GuestID = new Guid(Convert.ToString(gvFolioList.DataKeys[row]["GuestID"]));

                ctrlCommonPayment.BindPaymentMode();
                ctrlCommonPayment.ClearPaymentControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadPostChargeData()
        {
            try
            {
                LinkButton lnkFolioNo = (LinkButton)gvFolioList.Rows[this.RowIndex].FindControl("lnkFolioNo");
                ctrlFolioPostCharge.ucMpeAddFolioPostCharge.Show();
                ctrlFolioPostCharge.BindPostChargeLedger();
                ctrlFolioPostCharge.SetPageLable();
                ctrlFolioPostCharge.Reservation_ID = new Guid(gvFolioList.DataKeys[this.RowIndex]["ReservationID"].ToString());
                ctrlFolioPostCharge.Folio_ID = new Guid(gvFolioList.DataKeys[this.RowIndex]["FolioID"].ToString());
                ctrlFolioPostCharge.Folio_No = Convert.ToString(lnkFolioNo.Text.Trim());
                ctrlFolioPostCharge.uctxtPostChargeAmount.Text = ctrlFolioPostCharge.uctxtPostChargeNote.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LoadPostCreditData()
        {
            try
            {
                LinkButton lnkFolioNo = (LinkButton)gvFolioList.Rows[this.RowIndex].FindControl("lnkFolioNo");
                ctrlFolioPostCredit.ucMpeAddFolioPostCredit.Show();
                ctrlFolioPostCredit.BindPostChargeLedger();
                ctrlFolioPostCredit.SetPageLable();
                ctrlFolioPostCredit.Reservation_ID = new Guid(gvFolioList.DataKeys[this.RowIndex]["ReservationID"].ToString());
                ctrlFolioPostCredit.Folio_ID = new Guid(gvFolioList.DataKeys[this.RowIndex]["FolioID"].ToString());
                ctrlFolioPostCredit.Folio_No = Convert.ToString(lnkFolioNo.Text.Trim());
                ctrlFolioPostCredit.uctxtPostCreditAmount.Text = ctrlFolioPostCredit.uctxtPostCreditNote.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPostUnitChargesCallParent_Click(object sender, EventArgs e)
        {
            BindFolioGrid();
        }
    }
}