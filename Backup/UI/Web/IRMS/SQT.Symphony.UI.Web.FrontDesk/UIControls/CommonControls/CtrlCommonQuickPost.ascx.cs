using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonQuickPost : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditQuickPost
        {
            get { return this.mpeAddQuickPost; }
        }

        public MultiView mvOpenQuickPost
        {
            get { return this.mvQuickPost; }
        }

        public Literal litFolioNo
        {
            get { return this.litDisplayQuickPostFolioNo; }
        }

        public Literal litRoomNo
        {
            get { return this.litDisplayQuickPostUnitNo; }
        }

        public Literal litGuestName
        {
            get { return this.litDisplayQuickPostName; }
        }

        public Literal litBalance
        {
            get { return this.litDisplayQuickPostCreditLimit; }
        }

        public event EventHandler btnQuickPostCallParent_Click;

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

        public string Mode
        {
            get
            {
                return ViewState["Mode"] != null ? Convert.ToString(ViewState["Mode"]) : string.Empty;
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        public Guid ResPayID
        {
            get
            {
                return ViewState["ResPayID"] != null ? new Guid(Convert.ToString(ViewState["ResPayID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResPayID"] = value;
            }
        }

        public bool IsMessage = false;

        public bool IsMessageForPayment = false;

        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvQuickPost.ActiveViewIndex = 0;
                BindQuickPostGrid();
            }
        }

        #endregion

        #region Radio Button Event

        protected void rbtQuickPostAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlQuickPostCharge.Items.Clear();
            txtQuickPostAmount.Text = "";
            mpeAddQuickPost.Show();
            if (rbtQuickPostAccount.SelectedValue == "Account")
            {
                BindAccountData();
                trQty.Visible = false;
            }
            else
            {
                trQty.Visible = true;
                BindItemData();
            }
        }

        #endregion

        #region Private Method

        public void BindQuickPostGrid()
        {
            gvQuickPostList.DataSource = null;
            gvQuickPostList.DataBind();
        }

        public void BindCardListGrid()
        {
            try
            {
                DataSet dsData = ResGuestPaymentInfoBLL.GetCreditCardListData(this.GuestID, clsSession.PropertyID, clsSession.CompanyID, "CREDITCARDTYPE");

                if (dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    gvCardList.DataSource = dsData.Tables[0];
                    gvCardList.DataBind();
                }
                else
                {
                    gvCardList.DataSource = null;
                    gvCardList.DataBind();
                }

                ddlCreditCardType.Items.Clear();
                if (dsData.Tables.Count > 1 && dsData.Tables[1].Rows.Count > 0)
                {
                    ddlCreditCardType.DataSource = dsData.Tables[1];
                    ddlCreditCardType.DataTextField = "DisplayTerm";
                    ddlCreditCardType.DataValueField = "TermID";
                    ddlCreditCardType.DataBind();
                    ddlCreditCardType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                {
                    ddlCreditCardType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindModeOfPayment()
        {
            try
            {
                ddlQuickPostPayment.Items.Clear();
                List<ProjectTerm> lstModeOfPayment = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "PAYMENTMODE");
                if (lstModeOfPayment.Count != 0)
                {
                    ddlQuickPostPayment.DataSource = lstModeOfPayment;
                    ddlQuickPostPayment.DataTextField = "DisplayTerm";
                    ddlQuickPostPayment.DataValueField = "TermID";
                    ddlQuickPostPayment.DataBind();
                    ddlQuickPostPayment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlQuickPostPayment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindAccountData()
        {
            try
            {
                string strAccountData = "select AcctName,AcctID from acc_Account where SymphonyAcctGroupID =  1 and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID ='" + Convert.ToString(clsSession.CompanyID) + "' and IsActive = 1 order by AcctName asc";
                ddlQuickPostCharge.Items.Clear();
                DataSet dsAccountData = RoomTypeBLL.GetUnitType(strAccountData);

                if (dsAccountData.Tables.Count > 0 && dsAccountData.Tables[0].Rows.Count > 0)
                {
                    ddlQuickPostCharge.DataSource = dsAccountData.Tables[0];
                    ddlQuickPostCharge.DataTextField = "AcctName";
                    ddlQuickPostCharge.DataValueField = "AcctID";
                    ddlQuickPostCharge.DataBind();

                    ddlQuickPostCharge.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlQuickPostCharge.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindItemData()
        {
            try
            {
                DataSet dsItemData = ItemAvailabilityBLL.GetAllItems(clsSession.Location_TermID, null, null, clsSession.CompanyID, clsSession.PropertyID);

                if (dsItemData.Tables.Count > 0 && dsItemData.Tables[0].Rows.Count > 0)
                {
                    ddlQuickPostCharge.DataSource = dsItemData.Tables[0];
                    ddlQuickPostCharge.DataTextField = "ItemName";
                    ddlQuickPostCharge.DataValueField = "ItemID";
                    ddlQuickPostCharge.DataBind();

                    ddlQuickPostCharge.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlQuickPostCharge.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearControl()
        {
            txtQuickPostAmount.Text = txtQuickPostVoucherNo.Text = txtQuickPostNotes.Text = lblDisplayQuickPostAmount.Text = "";
            txtQuickPostQty.Text = "1";
            rbtQuickPostAccount.SelectedIndex = 0;
            BindAccountData();
            BindQuickPostGrid();
            ddlQuickPostCharge.SelectedIndex = ddlQuickPostPayment.SelectedIndex = 0;
            ddlQuickPostPayment_OnSelectedIndexChanged(null, null);
            trQty.Visible = false;
            this.Mode = "";
        }

        public void ClearControlCardInfo()
        {
            txtCardNo.Text = txtCardHolderName.Text = txtSecurityCode.Text = "";
            ddlCreditCardType.SelectedIndex = rdbPaymentOrBlock.SelectedIndex = ddlCardExpirationYear.SelectedIndex = ddlCardExpirationMonth.SelectedIndex = 0;
            this.ResPayID = Guid.Empty;
        }

        private string GetCardNo(string strCardNo)
        {
            string strReturn = "";
            if (strCardNo.Length == 16)
            {
                strReturn = "************" + strCardNo.Substring(12, 4);
            }
            return strReturn;
        }

        private void BindAddModeExpiryDate()
        {
            try
            {
                ddlCardExpirationYear.Items.Clear();
                int j = 1;
                ddlCardExpirationYear.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                {
                    ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                    j++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region Control Event

        protected void btnQuickPostCardInfo_Click(object sender, EventArgs e)
        {
            try
            {
                mvQuickPost.ActiveViewIndex = 1;
                mpeAddQuickPost.Show();
                litDisplayCardHolderName.Text = txtCardHolderName.Text = Convert.ToString(litDisplayQuickPostName.Text.Trim());
                BindCardListGrid();
                BindAddModeExpiryDate();
                ClearControlCardInfo();
                
                EventHandler temp = btnQuickPostCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void btnCancelCardDetails_Click(object sender, EventArgs e)
        {
            mpeAddQuickPost.Show();
            mvQuickPost.ActiveViewIndex = 0;
        }

        protected void btnQuickPostSave_Click(object sender, EventArgs e)
        {
            try
            {
                mpeAddQuickPost.Show();
                if (this.Page.IsValid)
                {
                    int cnt = Convert.ToInt32(gvQuickPostList.Rows.Count);

                    if (cnt == 0)
                    {
                        lblErrorMessage.Text = "You can't post. Please add Item.";
                        mpeErrorMessage.Show();
                        return;
                    }

                    if (ddlQuickPostPayment.SelectedIndex != 0)
                    {
                        if (hdnPaymentType.Value != "" && Convert.ToString(hdnPaymentType.Value) == "CREDITCARD")
                        {
                            if (hdnResPayID.Value == "")
                            {
                                mpeCreditCardInfoMsg.Show();
                                return;
                            }
                        }

                        for (int i = 0; i < gvQuickPostList.Rows.Count; i++)
                        {
                            Label lblGvAmount = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAmount");
                            Label lblGvQty = (Label)gvQuickPostList.Rows[i].FindControl("lblGvQty");
                            Label lblGvAccItem = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAccItem");

                            Guid? ChargeAcctID = new Guid(Convert.ToString(gvQuickPostList.DataKeys[i]["ID"]));
                            string RefNo = Convert.ToString(gvQuickPostList.DataKeys[i]["RefNo"]);

                            if (Convert.ToString(gvQuickPostList.DataKeys[i]["ForPostCharge"]) == "Account")
                            {
                                if (Convert.ToString(hdnPaymentType.Value) == "CREDITCARD" && hdnResPayID.Value != "")
                                {
                                    FolioBLL.FolioQuickPostInAccount(ChargeAcctID, new Guid(ddlLedgerAccount.SelectedValue), Convert.ToDecimal(lblGvAmount.Text.Trim()), 1, this.ReservationID, this.FolioID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, new Guid(hdnResPayID.Value), RefNo, Convert.ToDecimal(lblGvAmount.Text.Trim()), clsSession.CompanyID);
                                }
                                else
                                {
                                    FolioBLL.FolioQuickPostInAccount(ChargeAcctID, new Guid(ddlLedgerAccount.SelectedValue), Convert.ToDecimal(lblGvAmount.Text.Trim()), 1, this.ReservationID, this.FolioID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, null, RefNo, Convert.ToDecimal(lblGvAmount.Text.Trim()), clsSession.CompanyID);
                                }

                                string strDescription = "Quick Post " + Convert.ToString(lblGvAccItem.Text.Trim()) + " on FolioNo:- " + Convert.ToString(litDisplayQuickPostFolioNo.Text.Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + " of " + Convert.ToString(lblGvAmount.Text.Trim()) + " Rs. - with Payment.";
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Quick Post", null, null, "tra_BookKeeping", strDescription);
                            }
                            else
                            {
                                Guid returnID = Guid.Empty;
                                int qty = 0;
                                if (lblGvAmount.Text.Trim() != "")
                                    qty = Convert.ToInt32(lblGvQty.Text.Trim());

                                returnID = TransactionBLL.ItemPosting(ChargeAcctID, Convert.ToDecimal(lblGvAmount.Text.Trim()), qty, this.ReservationID, this.FolioID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", 141, RefNo, null, null, null, Convert.ToDecimal(lblGvAmount.Text.Trim()), clsSession.CompanyID);

                                ResServiceList objToInsert = new ResServiceList();
                                objToInsert.ReservationID = this.ReservationID;
                                objToInsert.ItemID = ChargeAcctID;
                                objToInsert.FolioID = this.FolioID;
                                objToInsert.Amount = Convert.ToDecimal(lblGvAmount.Text.Trim()) / Convert.ToDecimal(qty);
                                objToInsert.Qty = qty;
                                objToInsert.Total = Convert.ToDecimal(lblGvAmount.Text.Trim());
                                objToInsert.ServiceDate = DateTime.Now;
                                objToInsert.ServiceStatus_Term = clsCommon.GetUpperCaseText("Delivered");
                                objToInsert.BookID = returnID;

                                ResServiceListBLL.Save(objToInsert);

                                BookKeepingBLL.ReceivePayment(new Guid(ddlLedgerAccount.SelectedValue), Convert.ToDecimal(lblGvAmount.Text.Trim()), this.ReservationID, this.FolioID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.CompanyID, "FRONT DESK", null, false);

                                string strDescription = "Quick Post " + Convert.ToString(lblGvAccItem.Text.Trim()) + " qty " + Convert.ToString(qty) + " on FolioNo:- " + Convert.ToString(litDisplayQuickPostFolioNo.Text.Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + " of " + Convert.ToString(lblGvAmount.Text.Trim()) + " Rs. - with Payment.";
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Quick Post", null, null, "tra_BookKeeping", strDescription);
                            }

                        }
                    }
                    else
                    {
                        for (int i = 0; i < gvQuickPostList.Rows.Count; i++)
                        {
                            Label lblGvAmount = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAmount");
                            Label lblGvQty = (Label)gvQuickPostList.Rows[i].FindControl("lblGvQty");
                            Label lblGvAccItem = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAccItem");

                            Guid? ChargeAcctID = new Guid(Convert.ToString(gvQuickPostList.DataKeys[i]["ID"]));
                            string RefNo = Convert.ToString(gvQuickPostList.DataKeys[i]["RefNo"]);

                            if (Convert.ToString(gvQuickPostList.DataKeys[i]["ForPostCharge"]) == "Account")
                            {
                                FolioBLL.FolioQuickPostInAccount(ChargeAcctID, null, Convert.ToDecimal(lblGvAmount.Text.Trim()), 1, this.ReservationID, this.FolioID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, null, RefNo, Convert.ToDecimal(lblGvAmount.Text.Trim()), clsSession.CompanyID);

                                string strDescription = "Quick Post " + Convert.ToString(lblGvAccItem.Text.Trim()) + " on FolioNo:- " + Convert.ToString(litDisplayQuickPostFolioNo.Text.Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Quick Post", null, null, "tra_BookKeeping", strDescription);
                            }
                            else
                            {
                                Guid returnID = Guid.Empty;
                                int qty = 0;
                                if (lblGvAmount.Text.Trim() != "")
                                    qty = Convert.ToInt32(lblGvQty.Text.Trim());

                                returnID = TransactionBLL.ItemPosting(ChargeAcctID, Convert.ToDecimal(lblGvAmount.Text.Trim()), qty, this.ReservationID, this.FolioID, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", 141, RefNo, null, null, null, Convert.ToDecimal(lblGvAmount.Text.Trim()), clsSession.CompanyID);

                                ResServiceList objToInsert = new ResServiceList();
                                objToInsert.ReservationID = this.ReservationID;
                                objToInsert.ItemID = ChargeAcctID;
                                objToInsert.FolioID = this.FolioID;
                                objToInsert.Amount = Convert.ToDecimal(lblGvAmount.Text.Trim()) / Convert.ToDecimal(qty);
                                objToInsert.Qty = qty;
                                objToInsert.Total = Convert.ToDecimal(lblGvAmount.Text.Trim());
                                objToInsert.ServiceDate = DateTime.Now;
                                objToInsert.ServiceStatus_Term = clsCommon.GetUpperCaseText("Delivered");
                                objToInsert.BookID = returnID;

                                ResServiceListBLL.Save(objToInsert);

                                string strDescription = "Quick Post " + Convert.ToString(lblGvAccItem.Text.Trim()) + " qty " + Convert.ToString(qty) + " on FolioNo:- " + Convert.ToString(litDisplayQuickPostFolioNo.Text.Trim()) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Quick Post", null, null, "tra_BookKeeping", strDescription);
                            }
                        }
                    }

                    mpeAddQuickPost.Hide();
                    EventHandler temp = btnQuickPostCallParent_Click;
                    if (temp != null)
                    {
                        this.Mode = "REFRESHFOLIOLIST";
                        temp(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                mpeAddQuickPost.Show();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnQuickPostAdd_Click(object sender, EventArgs e)
        {
            try
            {
                mpeAddQuickPost.Show();

                if (this.Page.IsValid)
                {
                    decimal dcmlTotal = Convert.ToDecimal("0.00");

                    DataTable dt = new DataTable();

                    DataColumn dc1 = new DataColumn("ID");
                    DataColumn dc2 = new DataColumn("AccItem");
                    DataColumn dc3 = new DataColumn("Qty");
                    DataColumn dc4 = new DataColumn("Amount");
                    DataColumn dc5 = new DataColumn("No");
                    DataColumn dc6 = new DataColumn("ForPostCharge");
                    DataColumn dc7 = new DataColumn("RefNo");

                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);
                    dt.Columns.Add(dc3);
                    dt.Columns.Add(dc4);
                    dt.Columns.Add(dc5);
                    dt.Columns.Add(dc6);
                    dt.Columns.Add(dc7);

                    DataRow dr = dt.NewRow();

                    int qty = 0;

                    dr["ID"] = Convert.ToString(ddlQuickPostCharge.SelectedValue);
                    dr["AccItem"] = Convert.ToString(ddlQuickPostCharge.SelectedItem.Text);
                    if (rbtQuickPostAccount.SelectedValue == "Item")
                    {
                        if (txtQuickPostQty.Text.Trim() != "")
                        {
                            dr["Qty"] = Convert.ToString(txtQuickPostQty.Text.Trim());
                        }
                        else
                            dr["Qty"] = Convert.ToString(qty);
                    }
                    else
                        dr["Qty"] = "";

                    dr["Amount"] = Convert.ToString(Convert.ToDecimal(txtQuickPostQty.Text.Trim()) * Convert.ToDecimal(txtQuickPostAmount.Text.Trim()));
                    dr["No"] = "-1";
                    dr["ForPostCharge"] = Convert.ToString(rbtQuickPostAccount.SelectedValue);
                    dr["RefNo"] = Convert.ToString(txtQuickPostVoucherNo.Text.Trim());

                    dt.Rows.Add(dr);

                    dcmlTotal += Convert.ToDecimal(Convert.ToDecimal(txtQuickPostQty.Text.Trim()) * Convert.ToDecimal(txtQuickPostAmount.Text.Trim()));


                    for (int i = 0; i < gvQuickPostList.Rows.Count; i++)
                    {
                        DataRow dr1 = dt.NewRow();

                        Label lblGvAccItem = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAccItem");
                        Label lblGvQty = (Label)gvQuickPostList.Rows[i].FindControl("lblGvQty");
                        Label lblGvAmount = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAmount");
                        string strID = Convert.ToString(gvQuickPostList.DataKeys[i]["ID"].ToString());

                        dr1["ID"] = Convert.ToString(strID);
                        dr1["AccItem"] = Convert.ToString(lblGvAccItem.Text.Trim());
                        if (Convert.ToString(gvQuickPostList.DataKeys[i]["ForPostCharge"]) == "Item")
                        {
                            if (lblGvQty.Text.Trim() != "")
                            {
                                dr1["Qty"] = Convert.ToString(lblGvQty.Text.Trim());
                            }
                            else
                                dr1["Qty"] = Convert.ToString(0);
                        }
                        else
                            dr1["Qty"] = "";
                        dr1["Amount"] = Convert.ToString(lblGvAmount.Text.Trim());
                        dr1["No"] = Convert.ToString(i.ToString());
                        dr1["ForPostCharge"] = Convert.ToString(gvQuickPostList.DataKeys[i]["ForPostCharge"]);
                        dr1["RefNo"] = Convert.ToString(gvQuickPostList.DataKeys[i]["RefNo"]);

                        dt.Rows.Add(dr1);

                        dcmlTotal += Convert.ToDecimal(lblGvAmount.Text.Trim());
                    }

                    if (dt.Rows.Count > 0)
                    {
                        gvQuickPostList.DataSource = dt;
                        gvQuickPostList.DataBind();
                    }
                    else
                    {
                        gvQuickPostList.DataSource = null;
                        gvQuickPostList.DataBind();
                    }

                    lblDisplayQuickPostAmount.Text = Convert.ToString(dcmlTotal);

                    txtQuickPostAmount.Text = txtQuickPostVoucherNo.Text = txtQuickPostNotes.Text = "";
                    txtQuickPostQty.Text = "1";
                    rbtQuickPostAccount.SelectedIndex = 0;
                    BindAccountData();
                    ddlQuickPostCharge.SelectedIndex = ddlQuickPostPayment.SelectedIndex = 0;
                    ddlQuickPostPayment_OnSelectedIndexChanged(null, null);
                    trQty.Visible = false;
                }
            }
            catch (Exception ex)
            {
                mpeAddQuickPost.Show();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveCardDetails_Click(object sender, EventArgs e)
        {
            mpeAddQuickPost.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    ResGuestPaymentInfo IsCardInfo = new ResGuestPaymentInfo();
                    IsCardInfo.CompanyID = clsSession.CompanyID;
                    IsCardInfo.PropertyID = clsSession.PropertyID;
                    IsCardInfo.IsActive = true;
                    IsCardInfo.CardNo = Convert.ToString(txtCardNo.Text.Trim());

                    List<ResGuestPaymentInfo> LstDupCardInfo = null;
                    LstDupCardInfo = ResGuestPaymentInfoBLL.GetAll(IsCardInfo);

                    if (LstDupCardInfo.Count > 0)
                    {
                        if (this.ResPayID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupCardInfo[0].ResPayID)) != Convert.ToString(this.ResPayID.ToString()))
                            {
                                IsMessage = true;
                                ltrMsgList.Text = "Recored Already Exist.";
                                mpeAddQuickPost.Show();
                                return;
                            }
                        }
                        else
                        {
                            IsMessage = true;
                            ltrMsgList.Text = "Recored Already Exist.";
                            mpeAddQuickPost.Show();
                            return;
                        }
                    }


                    if (this.ResPayID != Guid.Empty)
                    {
                        //// if payment mode is Credit card, then check Credit Card's Expiretion date Start
                        String strPaymentMode = string.Empty;//// It will use to save Credit Card info. in ResPyamentGuest object
                        ResGuestPaymentInfo objUpdPaymentInfo = null;
                        if (ddlQuickPostPayment.SelectedIndex != 0)
                        {
                            ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlQuickPostPayment.SelectedValue));
                            if (pTermPaymentInfo != null)
                            {
                                strPaymentMode = Convert.ToString(pTermPaymentInfo.Term).ToUpper();
                                if (strPaymentMode == "CREDIT CARD")
                                {
                                    ////Check Credit Card's Expiration Date
                                    bool isCreditCardValid = true;
                                    if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) < DateTime.Today.Year)
                                    {
                                        isCreditCardValid = false;
                                    }
                                    else if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) == DateTime.Today.Year)
                                    {
                                        if (Convert.ToInt32(ddlCardExpirationMonth.SelectedValue) < DateTime.Today.Month)
                                        {
                                            isCreditCardValid = false;
                                        }
                                    }

                                    if (!isCreditCardValid)
                                    {
                                        MessageBox.Show("Please enter valid Expiration Date of Credit Card.");
                                        return;
                                    }

                                    if (txtCardNo.Text.Trim().Length < 16)
                                    {
                                        MessageBox.Show("Invalid card number, it must be 16 digits.");
                                        return;
                                    }

                                    if (txtSecurityCode.Text.Trim().Length < 3)
                                    {
                                        MessageBox.Show("Invalid CVV No., it must have atleast 3 digit.");
                                        return;
                                    }
                                }
                            }

                            //// If Payment is done throubh creditcard, then save its information Start
                            if (strPaymentMode == "CREDIT CARD")
                            {
                                objUpdPaymentInfo = new ResGuestPaymentInfo();

                                ResGuestPaymentInfo objOldData = new ResGuestPaymentInfo();
                                objUpdPaymentInfo = ResGuestPaymentInfoBLL.GetByPrimaryKey(this.ResPayID);
                                objOldData = ResGuestPaymentInfoBLL.GetByPrimaryKey(this.ResPayID);

                                objUpdPaymentInfo.MOP_TermID = new Guid(ddlQuickPostPayment.SelectedValue);
                                objUpdPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                                objUpdPaymentInfo.CardNo = clsCommon.GetUpperCaseText(txtCardNo.Text.Trim());
                                objUpdPaymentInfo.CardHolderName = clsCommon.GetUpperCaseText(txtCardHolderName.Text.Trim());
                                objUpdPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);

                                if (rdbPaymentOrBlock.SelectedValue.ToUpper() == "CHARGE")
                                    objUpdPaymentInfo.IsCreditCardCharged = true;
                                else
                                    objUpdPaymentInfo.IsCreditCardCharged = false;

                                objUpdPaymentInfo.CVVNo = clsCommon.GetUpperCaseText(txtSecurityCode.Text.Trim());
                                objUpdPaymentInfo.PropertyID = clsSession.PropertyID;
                                objUpdPaymentInfo.CompanyID = clsSession.CompanyID;
                                objUpdPaymentInfo.ReservationID = this.ReservationID;
                                objUpdPaymentInfo.FolioID = this.FolioID;
                                objUpdPaymentInfo.IsActive = true;
                                objUpdPaymentInfo.GuestID = this.GuestID;

                                ResGuestPaymentInfoBLL.Update(objUpdPaymentInfo);
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldData.ToString(), objUpdPaymentInfo.ToString(), "res_ResGuestPaymentInfo", null);
                                IsMessage = true;
                                ltrMsgList.Text = "Record Update Successfully.";
                            }
                            //// If Payment is done throubh creditcard, then save its information End
                        }
                    }
                    else
                    {
                        //// if payment mode is Credit card, then check Credit Card's Expiretion date Start
                        String strPaymentMode = string.Empty;//// It will use to save Credit Card info. in ResPyamentGuest object
                        ResGuestPaymentInfo objPaymentInfo = null;
                        if (ddlQuickPostPayment.SelectedIndex != 0)
                        {
                            ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlQuickPostPayment.SelectedValue));
                            if (pTermPaymentInfo != null)
                            {
                                strPaymentMode = Convert.ToString(pTermPaymentInfo.Term).ToUpper();
                                if (strPaymentMode == "CREDIT CARD")
                                {
                                    ////Check Credit Card's Expiration Date
                                    bool isCreditCardValid = true;
                                    if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) < DateTime.Today.Year)
                                    {
                                        isCreditCardValid = false;
                                    }
                                    else if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) == DateTime.Today.Year)
                                    {
                                        if (Convert.ToInt32(ddlCardExpirationMonth.SelectedValue) < DateTime.Today.Month)
                                        {
                                            isCreditCardValid = false;
                                        }
                                    }

                                    if (!isCreditCardValid)
                                    {
                                        MessageBox.Show("Please enter valid Expiration Date of Credit Card.");
                                        return;
                                    }

                                    if (txtCardNo.Text.Trim().Length < 16)
                                    {
                                        MessageBox.Show("Invalid card number, it must be 16 digits.");
                                        return;
                                    }

                                    if (txtSecurityCode.Text.Trim().Length < 3)
                                    {
                                        MessageBox.Show("Invalid CVV No., it must have atleast 3 digit.");
                                        return;
                                    }
                                }
                            }

                            //// If Payment is done throubh creditcard, then save its information Start
                            if (strPaymentMode == "CREDIT CARD")
                            {
                                objPaymentInfo = new ResGuestPaymentInfo();
                                objPaymentInfo.MOP_TermID = new Guid(ddlQuickPostPayment.SelectedValue);
                                objPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                                objPaymentInfo.CardNo = clsCommon.GetUpperCaseText(txtCardNo.Text.Trim());
                                objPaymentInfo.CardHolderName = clsCommon.GetUpperCaseText(txtCardHolderName.Text.Trim());
                                objPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);

                                if (rdbPaymentOrBlock.SelectedValue.ToUpper() == "CHARGE")
                                    objPaymentInfo.IsCreditCardCharged = true;
                                else
                                    objPaymentInfo.IsCreditCardCharged = false;

                                objPaymentInfo.CVVNo = clsCommon.GetUpperCaseText(txtSecurityCode.Text.Trim());
                                objPaymentInfo.PropertyID = clsSession.PropertyID;
                                objPaymentInfo.CompanyID = clsSession.CompanyID;
                                objPaymentInfo.ReservationID = this.ReservationID;
                                objPaymentInfo.FolioID = this.FolioID;
                                objPaymentInfo.IsActive = true;
                                objPaymentInfo.GuestID = this.GuestID;

                                ResGuestPaymentInfoBLL.Save(objPaymentInfo);
                                ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objPaymentInfo.ToString(), objPaymentInfo.ToString(), "res_ResGuestPaymentInfo", null);
                                IsMessage = true;
                                ltrMsgList.Text = "Record Save Successfully.";
                            }
                            //// If Payment is done throubh creditcard, then save its information End
                        }
                    }

                    BindCardListGrid();
                    ClearControlCardInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        protected void btnCancelCardDetailsForPayment_Click(object sender, EventArgs e)
        {
            mpeAddQuickPost.Show();
            mvQuickPost.ActiveViewIndex = 0;
        }

        #endregion

        #region Grid Event

        protected void gvQuickPostList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                mpeAddQuickPost.Show();

                if (e.CommandName.Equals("DELETEDATA"))
                {
                    decimal dcmlTotal = Convert.ToDecimal("0.00");

                    DataTable dt = new DataTable();

                    DataColumn dc1 = new DataColumn("ID");
                    DataColumn dc2 = new DataColumn("AccItem");
                    DataColumn dc3 = new DataColumn("Qty");
                    DataColumn dc4 = new DataColumn("Amount");
                    DataColumn dc5 = new DataColumn("No");
                    DataColumn dc6 = new DataColumn("ForPostCharge");
                    DataColumn dc7 = new DataColumn("RefNo");

                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);
                    dt.Columns.Add(dc3);
                    dt.Columns.Add(dc4);
                    dt.Columns.Add(dc5);
                    dt.Columns.Add(dc6);
                    dt.Columns.Add(dc7);

                    for (int i = 0; i < gvQuickPostList.Rows.Count; i++)
                    {
                        if (Convert.ToString(e.CommandArgument) != Convert.ToString(i.ToString()))
                        {
                            DataRow dr1 = dt.NewRow();

                            Label lblGvAccItem = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAccItem");
                            Label lblGvQty = (Label)gvQuickPostList.Rows[i].FindControl("lblGvQty");
                            Label lblGvAmount = (Label)gvQuickPostList.Rows[i].FindControl("lblGvAmount");
                            string strID = Convert.ToString(gvQuickPostList.DataKeys[i]["ID"].ToString());

                            dr1["ID"] = Convert.ToString(strID);
                            dr1["AccItem"] = Convert.ToString(lblGvAccItem.Text.Trim());
                            if (Convert.ToString(gvQuickPostList.DataKeys[i]["ForPostCharge"]) == "Item")
                            {
                                if (lblGvQty.Text.Trim() != "")
                                {
                                    dr1["Qty"] = Convert.ToString(lblGvQty.Text.Trim());
                                }
                                else
                                    dr1["Qty"] = Convert.ToString(0);
                            }
                            else
                                dr1["Qty"] = "";
                            dr1["Amount"] = Convert.ToString(lblGvAmount.Text.Trim());
                            dr1["No"] = Convert.ToString(i.ToString());
                            dr1["ForPostCharge"] = Convert.ToString(gvQuickPostList.DataKeys[i]["ForPostCharge"]);
                            dr1["RefNo"] = Convert.ToString(gvQuickPostList.DataKeys[i]["RefNo"]);

                            dt.Rows.Add(dr1);

                            dcmlTotal += Convert.ToDecimal(lblGvAmount.Text.Trim());
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        gvQuickPostList.DataSource = dt;
                        gvQuickPostList.DataBind();
                    }
                    else
                    {
                        gvQuickPostList.DataSource = null;
                        gvQuickPostList.DataBind();
                    }

                    lblDisplayQuickPostAmount.Text = Convert.ToString(dcmlTotal);
                }
            }
            catch (Exception ex)
            {
                mpeAddQuickPost.Show();
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCardList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mpeAddQuickPost.Show();
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    ClearControlCardInfo();

                    this.ResPayID = new Guid(Convert.ToString(e.CommandArgument));
                    ResGuestPaymentInfo objResGuestPaymentInfo = new ResGuestPaymentInfo();
                    objResGuestPaymentInfo = ResGuestPaymentInfoBLL.GetByPrimaryKey(this.ResPayID);

                    if (objResGuestPaymentInfo != null)
                    {
                        ddlCreditCardType.SelectedIndex = ddlCreditCardType.Items.FindByValue(Convert.ToString(objResGuestPaymentInfo.CardType_TermID)) != null ? ddlCreditCardType.Items.IndexOf(ddlCreditCardType.Items.FindByValue(Convert.ToString(objResGuestPaymentInfo.CardType_TermID))) : 0;
                        txtCardNo.Text = Convert.ToString(objResGuestPaymentInfo.CardNo);
                        txtCardHolderName.Text = Convert.ToString(objResGuestPaymentInfo.CardHolderName);

                        DateTime dtDBDateOfExpiry = Convert.ToDateTime(objResGuestPaymentInfo.DateOfExpiry);
                        ddlCardExpirationYear.Items.Clear();
                        int j = 1;
                        ddlCardExpirationYear.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

                        if (dtDBDateOfExpiry.Year >= DateTime.Now.Year)
                        {
                            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                            {
                                ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                                j++;
                            }
                        }
                        else
                        {
                            for (int i = dtDBDateOfExpiry.Year; i < DateTime.Now.Year + 20; i++)
                            {
                                ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                                j++;
                            }
                        }

                        ddlCardExpirationMonth.SelectedIndex = ddlCardExpirationMonth.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Month)) != null ? ddlCardExpirationMonth.Items.IndexOf(ddlCardExpirationMonth.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Month))) : 0;
                        ddlCardExpirationYear.SelectedIndex = ddlCardExpirationYear.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Year)) != null ? ddlCardExpirationYear.Items.IndexOf(ddlCardExpirationYear.Items.FindByValue(Convert.ToString(dtDBDateOfExpiry.Year))) : 0;

                        txtSecurityCode.Text = Convert.ToString(objResGuestPaymentInfo.CVVNo);

                        if (objResGuestPaymentInfo.IsCreditCardCharged != null && Convert.ToString(objResGuestPaymentInfo.IsCreditCardCharged) != "")
                        {
                            bool isCreditCardCharge = Convert.ToBoolean(objResGuestPaymentInfo.IsCreditCardCharged);
                            if (isCreditCardCharge)
                                rdbPaymentOrBlock.SelectedIndex = 0;
                            else
                                rdbPaymentOrBlock.SelectedIndex = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected void gvCardList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    Label lblGvCardNo = (Label)e.Row.FindControl("lblGvCardNo");
                    string strCardNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CardNo"));
                    lblGvCardNo.Text = Convert.ToString(GetCardNo(strCardNo));

                    lnkDelete.ToolTip = "Delete";
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDeleteQPCardInfoData('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResPayID")));

                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event

        #region DropDown Event

        protected void ddlQuickPostCharge_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            mpeAddQuickPost.Show();
            try
            {
                if (ddlQuickPostCharge.SelectedIndex != 0)
                {
                    if (rbtQuickPostAccount.SelectedValue == "Item")
                    {
                        string strItemQuery = "select IsNull(DefSalesPrice,0.000000) 'DefSalesPrice' from mst_Item where ItemID = '" + Convert.ToString(ddlQuickPostCharge.SelectedValue) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' ";
                        DataSet dsItem = RoomBLL.GetUnitNo(strItemQuery);
                        if (dsItem.Tables.Count > 0 && dsItem.Tables[0].Rows.Count > 0)
                        {
                            decimal dcSalesPrice = Convert.ToDecimal(Convert.ToString(dsItem.Tables[0].Rows[0]["DefSalesPrice"]));
                            txtQuickPostAmount.Text = dcSalesPrice.ToString().Substring(0, dcSalesPrice.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                    }
                    else
                        txtQuickPostAmount.Text = "0.00";
                }
                else
                    txtQuickPostAmount.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlQuickPostPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hdnPaymentType.Value = "";
            mpeAddQuickPost.Show();
            btnQuickPostCardInfo.Visible = false;
            try
            {
                if (ddlQuickPostPayment.SelectedIndex != 0)
                {
                    ddlLedgerAccount.Items.Clear();

                    DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlQuickPostPayment.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
                    if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
                    {
                        ddlLedgerAccount.DataSource = dstLedgerAccounts.Tables[0];
                        ddlLedgerAccount.DataTextField = "AcctName";
                        ddlLedgerAccount.DataValueField = "AcctID";
                        ddlLedgerAccount.DataBind();
                    }

                    trLedgerAccount.Visible = true;
                }
                else
                {
                    ddlLedgerAccount.Items.Clear();
                    btnQuickPostCardInfo.Visible = trLedgerAccount.Visible = false;
                }
                trChequeDD1.Visible = trChequeDD2.Visible = false;
                if (ddlQuickPostPayment.SelectedIndex != 0)
                {
                    ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlQuickPostPayment.SelectedValue));

                    if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                    {
                        trChequeDD1.Visible = trChequeDD2.Visible = true;
                    }
                    else if (objProjectTerm.Term.Trim().ToUpper() == "CREDIT CARD")
                    {
                        btnQuickPostCardInfo.Visible = true;
                        hdnPaymentType.Value = "CREDITCARD";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion DropDown Event

        #region Popup Button Event

        protected void btnYesQPCardInfo_Click(object sender, EventArgs e)
        {
            mpeAddQuickPost.Show();
            try
            {
                if (Convert.ToString(hdnConfirmDeleteQPCardInfo.Value) != string.Empty)
                {

                    mpeConfirmDeleteQPCardInfo.Hide();

                    ResGuestPaymentInfo objDelete = new ResGuestPaymentInfo();
                    objDelete = ResGuestPaymentInfoBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDeleteQPCardInfo.Value)));

                    ResGuestPaymentInfoBLL.Delete(new Guid(hdnConfirmDeleteQPCardInfo.Value));
                    IsMessage = true;
                    ltrMsgList.Text = "Record deleted successfully.";
                    ClearControlCardInfo();

                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "res_ResGuestPaymentInfo", null);
                }
                BindCardListGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Button Event

        #region Checkbox Event

        protected void chkSelectCardDetails_CheckedChanged(object sender, EventArgs e)
        {
            mpeAddQuickPost.Show();
            hdnResPayID.Value = "";
            try
            {
                CheckBox chkSelectCardDetails = (CheckBox)sender;
                GridViewRow row = (GridViewRow)chkSelectCardDetails.NamingContainer;

                Guid resPayID = new Guid(gvCardList.DataKeys[row.RowIndex]["ResPayID"].ToString());

                hdnResPayID.Value = Convert.ToString(resPayID);
                mvQuickPost.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Checkbox Event
    }
}