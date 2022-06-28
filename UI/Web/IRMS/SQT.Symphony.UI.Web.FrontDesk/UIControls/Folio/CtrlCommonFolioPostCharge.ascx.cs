using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlCommonFolioPostCharge : System.Web.UI.UserControl
    {
        #region Property and Variable

        public Guid Folio_ID
        {
            get
            {
                return ViewState["Folio_ID"] != null ? new Guid(Convert.ToString(ViewState["Folio_ID"])) : Guid.Empty;
            }
            set
            {
                ViewState["Folio_ID"] = value;
            }
        }

        public Guid Reservation_ID
        {
            get
            {
                return ViewState["Reservation_ID"] != null ? new Guid(Convert.ToString(ViewState["Reservation_ID"])) : Guid.Empty;
            }
            set
            {
                ViewState["Reservation_ID"] = value;
            }
        }

        public string Folio_No
        {
            get
            {
                return ViewState["Folio_No"] != null ? Convert.ToString(ViewState["Folio_No"]) : string.Empty;
            }
            set
            {
                ViewState["Folio_No"] = value;
            }
        }

        public ModalPopupExtender ucMpeAddFolioPostCharge
        {
            get { return this.mpeOpenPostCharge; }
        }

        public TextBox uctxtPostChargeAmount
        {
            get { return this.txtPostChargeAmount; }
        }

        public TextBox uctxtPostChargeNote
        {
            get { return this.txtPostChargeNote; }
        }

        public DropDownList ucddlPostChargeLedger
        {
            get { return this.ddlPostChargeLedger; }
        }

        public event EventHandler btnCommonFolioPostChargeCallParent_Click;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Page Load

        #region Private Method

        public void SetPageLable()
        {
            revtxtPostChargeAmount.ValidationExpression = "\\d{0,12}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revtxtPostChargeAmount.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + "digits allowed after decimal point.";
        }

        public void BindPostChargeLedger()
        {
            try
            {
                string strLedger = "select AcctID,AcctName from acc_Account where SymphonyAcctGroupID = 1 and RefAcctID is null and IsActive = 1 and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and IsEnable = 1 order by AcctName";
                DataSet dsData = RoomBLL.GetUnitNo(strLedger);

                ddlPostChargeLedger.Items.Clear();
                if (dsData != null && dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    ddlPostChargeLedger.DataSource = dsData.Tables[0];
                    ddlPostChargeLedger.DataTextField = "AcctName";
                    ddlPostChargeLedger.DataValueField = "AcctID";
                    ddlPostChargeLedger.DataBind();

                    ddlPostChargeLedger.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlPostChargeLedger.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Button Event

        protected void btnOpenPostCharge_Click(object sender, EventArgs e)
        {
            mpeOpenPostCharge.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    if (this.Reservation_ID != Guid.Empty && this.Folio_ID != Guid.Empty)
                    {
                        Guid returnID = Guid.Empty;

                        returnID = FolioBLL.FolioQuickPostInAccountNew(new Guid(ddlPostChargeLedger.SelectedValue), null, Convert.ToDecimal(txtPostChargeAmount.Text.Trim()), 1, this.Reservation_ID, this.Folio_ID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, null, null, Convert.ToDecimal(txtPostChargeAmount.Text.Trim()), clsSession.CompanyID);

                        string strDescription = "Post Charge " + Convert.ToString(ddlPostChargeLedger.SelectedItem.Text) + " on FolioNo:- " + Convert.ToString(this.Folio_No) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Post Charge", null, null, "tra_BookKeeping", strDescription);

                        this.Reservation_ID = this.Folio_ID = Guid.Empty;
                        this.Folio_No = string.Empty;

                        if (Convert.ToString(txtPostChargeNote.Text.Trim()) != "")
                        {
                            if (returnID != Guid.Empty)
                            {
                                BookKeeping objBookKeeping = new BookKeeping();
                                objBookKeeping = BookKeepingBLL.GetByPrimaryKey(returnID);

                                if (objBookKeeping != null)
                                {
                                    objBookKeeping.Narration = Convert.ToString(txtPostChargeNote.Text.Trim());
                                    BookKeepingBLL.Update(objBookKeeping);
                                }
                            }
                        }
                    }

                    mpeOpenPostCharge.Hide();
                    EventHandler temp = btnCommonFolioPostChargeCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Button Event
    }
}