using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlCommonPostCredit : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddFolioPostCredit
        {
            get { return this.mpeOpenPostCredit; }
        }

        public TextBox uctxtPostCreditAmount
        {
            get { return this.txtPostCreditAmount; }
        }

        public TextBox uctxtPostCreditNote
        {
            get { return this.txtPostCreditNote; }
        }

        public DropDownList ucddlPostCreditLedger
        {
            get { return this.ddlPostCreditLedger; }
        }

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

        public event EventHandler btnCommonFolioPostCreditCallParent_Click;

        #endregion

        #region Page Load
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Page Load

        #region Private Method

        public void SetPageLable()
        {
            revPostCreditAmount.ValidationExpression = "\\d{0,12}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revPostCreditAmount.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + "digits allowed after decimal point.";
        }

        public void BindPostChargeLedger()
        {
            try
            {
                string strLedger = "select AcctID,AcctName from acc_Account where SymphonyAcctGroupID = 2 and RefAcctID is null and IsActive = 1 and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and IsEnable = 1 order by AcctName";
                DataSet dsData = RoomBLL.GetUnitNo(strLedger);

                ddlPostCreditLedger.Items.Clear();
                if (dsData != null && dsData.Tables.Count > 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    ddlPostCreditLedger.DataSource = dsData.Tables[0];
                    ddlPostCreditLedger.DataTextField = "AcctName";
                    ddlPostCreditLedger.DataValueField = "AcctID";
                    ddlPostCreditLedger.DataBind();

                    ddlPostCreditLedger.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlPostCreditLedger.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Button Event

        protected void btnOpenPostCredit_Click(object sender, EventArgs e)
        {
            mpeOpenPostCredit.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    if (this.Reservation_ID != Guid.Empty && this.Folio_ID != Guid.Empty)
                    {
                        Guid returnID = Guid.Empty;

                        returnID = FolioBLL.FolioPostCreditInAccount(new Guid(ddlPostCreditLedger.SelectedValue), Convert.ToDecimal(txtPostCreditAmount.Text.Trim()), 44, this.Reservation_ID, this.Folio_ID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, Convert.ToString(txtPostCreditNote.Text.Trim()), clsSession.CompanyID);

                        string strDescription = "Post Credit " + Convert.ToString(ddlPostCreditLedger.SelectedItem.Text) + " on FolioNo:- " + Convert.ToString(this.Folio_No) + " at " + DateTime.Now.ToString() + " by " + Convert.ToString(clsSession.UserName) + "";
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Post Credit", null, null, "tra_BookKeeping", strDescription);

                        this.Reservation_ID = this.Folio_ID = Guid.Empty;
                        this.Folio_No = string.Empty;
                    }

                    mpeOpenPostCredit.Hide();
                    EventHandler temp = btnCommonFolioPostCreditCallParent_Click;
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