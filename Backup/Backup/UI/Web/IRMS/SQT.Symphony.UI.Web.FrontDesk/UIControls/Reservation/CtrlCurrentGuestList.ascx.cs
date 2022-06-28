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

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCurrentGuestList : System.Web.UI.UserControl
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

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
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

                mvGuestList.ActiveViewIndex = 0;
                BindBreadCrumb();
                BindBillingInstruction();
                BindGrid();
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindGrid()
        {
            string strName = null;
            string strMobileNo = null;
            string strReservationNo = null;
            string strRoomNo = null;
            Guid? BillingInstructionID = null;
            if (txtSearchName.Text.Trim() != "")
                strName = txtSearchName.Text.Trim();

            if (txtSearchMobileNo.Text.Trim() != "")
                strMobileNo = txtSearchMobileNo.Text.Trim();

            if (txtSearcReservationNo.Text.Trim() != "")
                strReservationNo = "RES#" + txtSearcReservationNo.Text.Trim();

            if (txtSearchUnitNo.Text.Trim() != "")
            {
                strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
                if (strRoomNo == "")
                    strRoomNo = null;
            }
            if (ddlbillinginstruction.SelectedIndex != 0)
                BillingInstructionID = new Guid(ddlbillinginstruction.SelectedValue);

            DataSet dsReservationData = GuestBLL.GetCurrentGuestListData(null, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, strRoomNo, BillingInstructionID);
            // Order By Logic
            DataView dvForGuestListOrderBy = null;
            if (dsReservationData != null && dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
            {
                dvForGuestListOrderBy = new DataView(dsReservationData.Tables[0]);
                string strOrderByName = string.Empty;
                if (ddlOrderByList.SelectedValue.Trim().Equals("Booking No"))
                    strOrderByName = "ReservationNo Desc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Room No"))
                    strOrderByName = "RoomNo Asc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Block name"))
                    strOrderByName = "WingName Asc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Arrival Date"))
                    strOrderByName = "CheckInDate Desc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Company Name"))
                    strOrderByName = "CompanyName Asc";

                dvForGuestListOrderBy.Sort = strOrderByName;
            }

            gvGuestList.DataSource = dvForGuestListOrderBy;
            gvGuestList.DataBind();
        }
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CurrentGuestList.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            // btnAddBottomEmployee.Visible = btnAddTopEmployee.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void BindBillingInstruction()
        {
            try
            {
                ddlbillinginstruction.Items.Clear();
                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "BILLINGINSTRUCTION");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlbillinginstruction.DataSource = lstProjectTermTitle;
                    ddlbillinginstruction.DataTextField = "DisplayTerm";
                    ddlbillinginstruction.DataValueField = "TermID";
                    ddlbillinginstruction.DataBind();
                    ddlbillinginstruction.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlbillinginstruction.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BinddllRecoveryItem()
        {
            try
            {

                string strSelect = clsCommon.GetUpperCaseText(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"));
                Recovery objRecovery = new Recovery();
                objRecovery.CompanyID = clsSession.CompanyID;
                objRecovery.PropertyID = clsSession.PropertyID;

                //Prj.Category = "RECOVERY ITEM";
                //Prj.CompanyID = clsSession.CompanyID;
                //Prj.PropertyID = clsSession.PropertyID;
                //Prj.IsActive = true;

                List<Recovery> LstRecovery = RecoveryBLL.GetAll(objRecovery);
                if (LstRecovery.Count > 0)
                {
                    var FinalDataSourceForRecoveryTtpe = from t in LstRecovery
                                                         select new
                                                         {
                                                             CombinedItemRecAndAcctID = t.RecoveryID + "|" + t.AcctID,
                                                             t.Title
                                                         };



                    ddlRecoveryType.DataSource = FinalDataSourceForRecoveryTtpe;
                    ddlRecoveryType.DataTextField = "Title";
                    ddlRecoveryType.DataValueField = "CombinedItemRecAndAcctID";
                    ddlRecoveryType.DataBind();
                    ddlRecoveryType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlRecoveryType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

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
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Guest List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindRecoveryList()
        {
            try
            {
                DataSet dsForRecoveryList = FolioBLL.GetAllRecoveryTransaction(this.ReservationID, this.FolioID, null, null, clsSession.PropertyID, clsSession.CompanyID);
                if (dsForRecoveryList != null && dsForRecoveryList.Tables.Count > 0 && dsForRecoveryList.Tables[0].Rows.Count > 0)
                {
                    gvRecoveryList.DataSource = dsForRecoveryList.Tables[0];
                    gvRecoveryList.DataBind();
                }
                else
                {
                    gvRecoveryList.DataSource = null;
                    gvRecoveryList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            txtSearchName.Text = "";
            txtSearchUnitNo.Text = "";
            txtSearcReservationNo.Text = "";
            txtSearchMobileNo.Text = "";
        }

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }

        //private void LoadQuickPostData()
        //{
        //    try
        //    {
        //        ctrlQuickPost.BindModeOfPayment();
        //        ctrlQuickPost.ClearControl();
        //        ctrlQuickPost.BindQuickPostGrid();

        //        LinkButton lnkGuestName = (LinkButton)gvGuestList.Rows[this.RowIndex].FindControl("lnkGuestName");
        //        Label lblGvRoomNo = (Label)gvGuestList.Rows[this.RowIndex].FindControl("lblGvRoomNo");

        //        //Label lblGvBalance = (Label)gvGuestList.Rows[row].FindControl("lblGvBalance");
        //        //LinkButton lnkFolioNo = (LinkButton)gvGuestList.Rows[row].FindControl("lnkFolioNo");

        //        ctrlQuickPost.litFolioNo.Text = Convert.ToString(gvGuestList.DataKeys[this.RowIndex]["FolioNo"]);
        //        ctrlQuickPost.litGuestName.Text = Convert.ToString(lnkGuestName.Text.Trim());
        //        ctrlQuickPost.litRoomNo.Text = Convert.ToString(lblGvRoomNo.Text.Trim());

        //        decimal dcmlBalance = Convert.ToDecimal(gvGuestList.DataKeys[this.RowIndex]["Balance"].ToString());
        //        ctrlQuickPost.litBalance.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

        //        ctrlQuickPost.FolioID = new Guid(Convert.ToString(gvGuestList.DataKeys[this.RowIndex]["FolioID"]));
        //        ctrlQuickPost.ReservationID = new Guid(Convert.ToString(gvGuestList.DataKeys[this.RowIndex]["ReservationID"]));
        //        ctrlQuickPost.GuestID = new Guid(Convert.ToString(gvGuestList.DataKeys[this.RowIndex]["GuestID"]));

        //        ctrlQuickPost.ucMpeAddEditQuickPost.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        private void SaveRecoveryData()
        {
            try
            {
                string[] strAcctIDRecID = ddlRecoveryType.SelectedValue.ToString().Split('|');
                Guid? AcctIDForRec = new Guid(Convert.ToString(strAcctIDRecID[1]));
                Guid? ReservationIDForRec = this.ReservationID; //new Guid(Convert.ToString(Session["GuestReservationIDForRecovery"]));
                Guid? FolioIDForRec = this.FolioID;// new Guid(Convert.ToString(Session["GuestFolioIDForRecovery"]));
                Guid BookIDRet = Guid.Empty;
                BookIDRet = FolioBLL.FolioQuickPostInAccountNew(AcctIDForRec, null, Convert.ToDecimal(txtRecoveryAmount.Text.Trim()), 1, ReservationIDForRec, FolioIDForRec, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, null, null, null, clsSession.CompanyID);
                string strDescription = "Recovery " + Convert.ToString(ddlRecoveryType.SelectedItem.ToString().Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Recovery", null, null, null, strDescription);
                BookKeeping objbkp = BookKeepingBLL.GetByPrimaryKey(BookIDRet);
                if (objbkp != null)
                {
                    objbkp.UnitID = new Guid(strAcctIDRecID[0].ToString());
                    objbkp.UnitType_Term = "ITEM";
                    objbkp.ItemID = new Guid(strAcctIDRecID[0].ToString());
                    objbkp.GeneralIDType_Term = "QUICK POST";
                    objbkp.Narration = clsCommon.GetUpperCaseText("Recovery charge post for " + ddlRecoveryType.SelectedItem.ToString());
                    if (txtDescription.Text != string.Empty)
                    {
                        objbkp.Description = clsCommon.GetUpperCaseText(txtDescription.Text.Trim().ToString());
                    }
                    else
                    {
                        objbkp.Description = objbkp.Narration;
                    }

                    BookKeepingBLL.Update(objbkp);
                }
                BindRecoveryList();

                ddlRecoveryType.SelectedIndex = ddlRecoveryMode.SelectedIndex = 0;
                txtRecoveryAmount.Text = txtDescription.Text = "";
                txtRecoveryAmount.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //private void LoadPaymentData()
        //{
        //    try
        //    {
        //        ctrlPayment.ucMpeAddEditPayment.Show();

        //        LinkButton lnkGuestName = (LinkButton)gvGuestList.Rows[this.RowIndex].FindControl("lnkGuestName");
        //        Label lblGvRoomNo = (Label)gvGuestList.Rows[this.RowIndex].FindControl("lblGvRoomNo");

        //        //Label lblGvBalance = (Label)gvGuestList.Rows[row].FindControl("lblGvBalance");
        //        //LinkButton lnkFolioNo = (LinkButton)gvGuestList.Rows[row].FindControl("lnkFolioNo");

        //        Label lblGvRoomTypeName = (Label)gvGuestList.Rows[this.RowIndex].FindControl("lblGvRoomTypeName");

        //        ctrlPayment.IsMessage = false;
        //        ctrlPayment.uclitDisplayPaymentFolioNo.Text = Convert.ToString(gvGuestList.DataKeys[this.RowIndex]["FolioNo"]);
        //        ctrlPayment.uclitDisplayPaymentGuestName.Text = Convert.ToString(lnkGuestName.Text.Trim());
        //        ctrlPayment.uclitDisplayRoomNoAndRoomType.Text = Convert.ToString(lblGvRoomNo.Text.Trim() + " - " + lblGvRoomTypeName.Text.Trim());

        //        decimal dcmlBalance = Convert.ToDecimal(gvGuestList.DataKeys[this.RowIndex]["Balance"].ToString());
        //        ctrlPayment.uclitDisplayPaymentBalance.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

        //        ctrlPayment.ReservationID = new Guid(gvGuestList.DataKeys[this.RowIndex]["ReservationID"].ToString());
        //        ctrlPayment.FolioID = new Guid(gvGuestList.DataKeys[this.RowIndex]["FolioID"].ToString());
        //        ctrlPayment.GuestID = new Guid(Convert.ToString(gvGuestList.DataKeys[this.RowIndex]["GuestID"]));

        //        ctrlPayment.BindPaymentMode();
        //        ctrlPayment.ClearPaymentControl();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}
        #endregion

        #region Grid Event

        protected void gvGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                this.RowIndex = 0;
                this.strIsValidate = this.strOpenModalDialog = string.Empty;

                if (e.CommandName.Equals("GUESTPROFILE"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "GUESTDETAILS";
                    Response.Redirect("~/GUI/Folio/GuestProfile.aspx");
                }
                else if (e.CommandName.Equals("PAYMENT"))
                {
                    //ctrlPayment.ucMpeAddEditPayment.Show();
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

                    //LoadPaymentData();
                }
                else if (e.CommandName.Equals("QUICKPOST"))
                {
                    ////ctrlQuickPost.BindModeOfPayment();
                    ////ctrlQuickPost.ClearControl();
                    ////ctrlQuickPost.BindQuickPostGrid();                
                    ////ctrlQuickPost.ucMpeAddEditQuickPost.Show();

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

                    //LoadQuickPostData();

                }
                else if (e.CommandName.Equals("VIEWFOLIO"))
                {
                    LinkButton lb = (LinkButton)e.CommandSource;

                    GridViewRow gvr = (GridViewRow)lb.NamingContainer;
                    Guid id = (Guid)(gvGuestList.DataKeys[gvr.RowIndex]["FolioID"]);
                    string strBalance = Convert.ToString((gvGuestList.DataKeys[gvr.RowIndex]["Balance"]));
                    if (strBalance != string.Empty)
                        strBalance = strBalance.ToString().Substring(0, strBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    else
                        strBalance = "0.00";

                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "FOLIODETAILS";
                    Session["FolioListFolioID"] = Convert.ToString(id);
                    Session["FolioListFolioBalance"] = strBalance;

                    Response.Redirect("~/GUI/Folio/FolioDetailsOld.aspx");
                }
                else if (e.CommandName.Equals("CHECKOUTNOTE"))
                {
                    //LinkButton lb = (LinkButton)e.CommandSource;

                    //GridViewRow gvr = (GridViewRow)lb.NamingContainer;
                    //Guid id = (Guid)(gvGuestList.DataKeys[gvr.RowIndex]["FolioID"]);
                    //11111111111111111111
                    DataSet ds = ReservationGuestBLL.GetAllByWithDataSet(ReservationGuest.ReservationGuestFields.ReservationID, e.CommandArgument.ToString());
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txtCheckOutNote.Text = Convert.ToString(ds.Tables[0].Rows[0]["CheckOutNote"]);
                        hfCheckOutNote.Value = Convert.ToString(ds.Tables[0].Rows[0]["ReservationGuestID"]);
                    }

                    mpeCheckOutNote.Show();

                }
                else if (e.CommandName.Equals("RECOVERY"))
                {
                    BinddllRecoveryItem();

                    LinkButton lb = (LinkButton)e.CommandSource;
                    GridViewRow gvr = (GridViewRow)lb.NamingContainer;

                    Guid FolioidForRecovery = (Guid)gvGuestList.DataKeys[gvr.RowIndex].Value;
                    this.FolioID = new Guid(Convert.ToString(FolioidForRecovery));
                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                    mvGuestList.ActiveViewIndex = 1;

                    lblRecoveryGuestName.Text = ((LinkButton)gvr.FindControl("lnkGuestName")).Text;
                    lblRecoveryBookingNo.Text = ((LinkButton)gvr.FindControl("lnkReservationNo")).Text;

                    ddlRecoveryMode.SelectedIndex = ddlRecoveryType.SelectedIndex = 0;
                    txtRecoveryAmount.Text = txtDescription.Text = "";
                    BindRecoveryList();
                }
                else if (e.CommandName.Equals("CHANGEWRONGROOMNUMBER"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "CHANGEWRONGROOMNUMBER";
                    Response.Redirect("~/GUI/Reservation/ChangeRoomNumOnly.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void gvGuestList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvRecoveryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecoveryList.PageIndex = e.NewPageIndex;
            BindRecoveryList();
        }

        protected void gvRecoveryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvCharges = (Label)e.Row.FindControl("lblRecoveryAmount");
                    if (DataBinder.Eval(e.Row.DataItem, "DisplayAmount") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DisplayAmount")) != "")
                    {
                        decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DisplayAmount"));
                        lblGvCharges.Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvCharges.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvGuestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));
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

        #endregion Grid Event

        #region Control Event

        protected void btnQuickPostCallParent_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ctrlQuickPost.Mode == "REFRESHFOLIOLIST")
                //    BindGrid();
                //else
                //{
                //    ctrlQuickPost.mvOpenQuickPost.ActiveViewIndex = 1;
                //    ctrlQuickPost.ucMpeAddEditQuickPost.Show();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnPaymentCallParent_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ctrlPayment.strMode != null && ctrlPayment.strMode == "REFRESHFOLIOLISTGRID")
                //{
                //    BindGrid();
                //}
                //else
                //{
                //    ctrlPayment.mvOpenPayment.ActiveViewIndex = 1;
                //    ctrlPayment.ucMpeAddEditPayment.Show();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnRecoveryCancel_Click(object sender, EventArgs e)
        {
            this.ReservationID = this.FolioID = Guid.Empty;
            mvGuestList.ActiveViewIndex = 0;
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            BindGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (ddlRecoveryType.SelectedIndex != 0)
                    {
                        this.strOpenModalDialog = "SAVERECOVERY";

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

                        SaveRecoveryData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

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

                    //if (this.strOpenModalDialog == "QUICKPOST")
                    //    LoadQuickPostData();
                    //else if (this.strOpenModalDialog == "PAYMENT")
                    //    LoadPaymentData();
                    //else if (this.strOpenModalDialog == "SAVERECOVERY")
                    //    SaveRecoveryData();
                    if (this.strOpenModalDialog == "SAVERECOVERY")
                        SaveRecoveryData();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPrintGuestList_OnClick(object sender, EventArgs e)
        {
            if (gvGuestList.Rows.Count > 0)
            {
                Session["GuestListPageIndex"] = gvGuestList.PageIndex.ToString();

                Session["GuestListSearchName"] = txtSearchName.Text.Trim();
                Session["GuestListSearchMobileNo"] = txtSearchMobileNo.Text.Trim();

                if (txtSearcReservationNo.Text.Trim() != "")
                    Session["GuestListSearcReservationNo"] = "RES#" + txtSearcReservationNo.Text.Trim();
                else
                    Session["GuestListSearcReservationNo"] = "";

                if (txtSearchUnitNo.Text.Trim() != "")
                    Session["GuestListSearchUnitNo"] = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
                else
                    Session["GuestListSearchUnitNo"] = "";

                if (ddlbillinginstruction.SelectedIndex != 0)
                    Session["GuestListBillingInstructionID"] = ddlbillinginstruction.SelectedValue.ToString();
                else
                    Session["GuestListBillingInstructionID"] = "";

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnGuestListPrint();", true);
            }
        }

        protected void btnExportToExcel_OnClick(object sender, EventArgs e)
        {
            string strName = null;
            string strMobileNo = null;
            string strReservationNo = null;
            string strRoomNo = null;
            Guid? BillingInstructionID = null;
            if (txtSearchName.Text.Trim() != "")
                strName = txtSearchName.Text.Trim();

            if (txtSearchMobileNo.Text.Trim() != "")
                strMobileNo = txtSearchMobileNo.Text.Trim();

            if (txtSearcReservationNo.Text.Trim() != "")
                strReservationNo = "RES#" + txtSearcReservationNo.Text.Trim();

            if (txtSearchUnitNo.Text.Trim() != "")
            {
                strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
                if (strRoomNo == "")
                    strRoomNo = null;
            }
            if (ddlbillinginstruction.SelectedIndex != 0)
                BillingInstructionID = new Guid(ddlbillinginstruction.SelectedValue);

            DataSet dsReservationData = GuestBLL.GetCurrentGuestListData(null, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, strRoomNo, BillingInstructionID);
            
            DataTable dt = dsReservationData.Tables[0];

            if (dsReservationData != null && dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
            {
                //dvForGuestListOrderBy = new DataView(dsReservationData.Tables[0]);
                string strOrderByName = string.Empty;
                if (ddlOrderByList.SelectedValue.Trim().Equals("Booking No"))
                    strOrderByName = "ReservationNo Desc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Room No"))
                    strOrderByName = "RoomNo Asc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Block name"))
                    strOrderByName = "WingName Asc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Arrival Date"))
                    strOrderByName = "CheckInDate Desc";
                else if (ddlOrderByList.SelectedValue.Trim().Equals("Company Name"))
                    strOrderByName = "CompanyName Asc";

                dt.DefaultView.Sort = strOrderByName;
            } 

            if (dt.Rows.Count > 0)
            {
                string filename = "GuestList_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }

        protected void btnUpdateCheckOutNote_OnClick(object sender, EventArgs e)
        {
            if (hfCheckOutNote.Value.ToString() != string.Empty)
            {
                ReservationGuest resGst = ReservationGuestBLL.GetByPrimaryKey(new Guid(hfCheckOutNote.Value.ToString()));
                resGst.CheckOutNote = txtCheckOutNote.Text.Trim();
                ReservationGuestBLL.Update(resGst);
                mpeCheckOutNote.Hide();

                MessageBox.Show("Check Out Note updated successfully.");
            }
        }

        #endregion Control Event

        #region Dropdown Event

        protected void ddlRecoveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRecoveryType.SelectedIndex != 0)
                {
                    string[] strAcctIDRecID = ddlRecoveryType.SelectedValue.ToString().Split('|');
                    Recovery objRecovery = RecoveryBLL.GetByPrimaryKey(new Guid(Convert.ToString(strAcctIDRecID[0])));

                    if (objRecovery != null)
                    {
                        txtRecoveryAmount.Enabled = false;
                        txtRecoveryAmount.Text = Convert.ToString(objRecovery.Amount);

                        if (objRecovery.Amount == null || Convert.ToString(objRecovery.Amount) == "")
                        {
                            txtRecoveryAmount.Enabled = true;
                            txtRecoveryAmount.Text = "";
                        }
                    }
                }
                else
                {
                    txtRecoveryAmount.Enabled = false;
                    txtRecoveryAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Dropdown Event
    }
}