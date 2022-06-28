using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardBasicInfo : System.Web.UI.UserControl
    {
        #region Property And Variables
        public string ParentType
        {
            get
            {
                return ViewState["ParentType"] != null ? Convert.ToString(ViewState["ParentType"]) : string.Empty;
            }
            set
            {
                ViewState["ParentType"] = value;
            }
        }

        public string ucTxtRateCardCode
        {
            get { return txtRateCardCode.Text.Trim(); }
            set { txtRateCardCode.Text = value; }
        }

        public string ucTxtRateCardName
        {
            get { return txtRateCardName.Text.Trim(); }
            set { txtRateCardName.Text = value; }
        }

        public string ucTxtStayDuration
        {
            get { return txtStayDuration.Text.Trim(); }
            set { txtStayDuration.Text = value; }
        }

        public string ucTxtDateFrom
        {
            get { return txtDateFrom.Text.Trim(); }
            set { txtDateFrom.Text = value; }
        }

        public string ucTxtDateTo
        {
            get { return txtDateTo.Text.Trim(); }
            set { txtDateTo.Text = value; }
        }

        public string ucTxtNoOfNights
        {
            get { return txtNoOfNights.Text.Trim(); }
            set { txtNoOfNights.Text = value; }
        }

        public string ucTxtAllowedAdults
        {
            get { return txtAllowedAdults.Text.Trim(); }
            set { txtAllowedAdults.Text = value; }
        }

        public string ucTxtAllowedChild
        {
            get { return txtAllowedChild.Text.Trim(); }
            set { txtAllowedChild.Text = value; }
        }

        public bool ucChkIsEnable
        {
            get { return chkIsEnable.Checked; }
            set { chkIsEnable.Checked = value; }
        }

        public DropDownList ddlucPostingFrequency
        {
            get { return this.ddlPostingFrequency; }
        }

        //public string ucDdlStayType
        //{
        //    get { return ddlStayType.SelectedValue.ToString(); }
        //    set { ddlStayType.SelectedIndex = ddlStayType.Items.FindByValue(Convert.ToString(value)) != null ? ddlStayType.Items.IndexOf(ddlStayType.Items.FindByValue(Convert.ToString(value))) : 0; }
        //}

        public DropDownList ddlucStayType
        {
            get { return this.ddlStayType; }
        }


        public string rdblucRateCardType
        {
            get { return rdblRateCardType.SelectedValue; }
            set { rdblRateCardType.SelectedValue = value; }
        }

        public string strClearDateTooltip
        {
            get
            {
                return ViewState["strClearDateTooltip"] != null ? Convert.ToString(ViewState["strClearDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strClearDateTooltip"] = value;
            }
        }

        public DropDownList ddlucCancellationPolicy
        {
            get { return this.ddlCancelationPolicy; }
        }
        public string ucTxtRateCardDispName
        {
            get { return txtRateCardDispNameForRateCard.Text.Trim(); }
            set { txtRateCardDispNameForRateCard.Text = value; }
        }
        public bool ucChkIsPerRoom
        {
            get { return chkIsPerRoom.Checked; }
            set { chkIsPerRoom.Checked = value; }
        }

        public string ucTxtRetentionCharge
        {
            get { return txtRetentionCharge.Text.Trim(); }
            set { txtRetentionCharge.Text = value; }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
                SetControlVisibility();
                calExtDateFrom.Format = calExtDateTo.Format = clsSession.DateFormat;
            }
        }
        #endregion

        #region Methods
        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            litStayType.Text = clsCommon.GetGlobalResourceText("RateCard", "lblStayType", "Stay Type");
            litRateCardCode.Text = "Rate Card Code"; //clsCommon.GetGlobalResourceText("RateCard", "lblRateCardCode", "Code");
            litRateCardName.Text = "Rate Card Name"; //clsCommon.GetGlobalResourceText("RateCard", "lblRateCardName", "Name");
            litDateFrom.Text = "Effective Date";//// clsCommon.GetGlobalResourceText("RateCard", "lblDateFrom", "Date From");
            litDateTo.Text = "Valid upto";//// clsCommon.GetGlobalResourceText("RateCard", "lblDateTo", "Date To");
            litPostingFrequency.Text = clsCommon.GetGlobalResourceText("RateCard", "lblPostingFrequency", "Posting Freq.");
            litNoOfNights.Text = clsCommon.GetGlobalResourceText("RateCard", "lblNumberOfNights", "No. of Nights");
            litAllowedAdults.Text = clsCommon.GetGlobalResourceText("RateCard", "lblAllowedAdults", "Allowed Adults");
            litAllowedChild.Text = clsCommon.GetGlobalResourceText("RateCard", "lblAllowedChild", "Allowed Child");
            chkIsEnable.Text = clsCommon.GetGlobalResourceText("RateCard", "lblEnable", "Is RateCard Enable");
            this.strClearDateTooltip = clsCommon.GetGlobalResourceText("Common", "lblTltpClearDate", "Clear Date");
            imgDateFrom.ToolTip = imgDateTo.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpChooseDate", "Choose Date");
            ////chkIsStandardRateCard.Text = clsCommon.GetGlobalResourceText("RateCard", "lblStandardRateCard", "Is Standard");
        }

        private void SetControlVisibility()
        {
            if (this.ParentType == "CONFERENCERATECARD")
            {
                trAllowedAdults.Visible = true;
            }
            else if (this.ParentType == "PACKAGERATECARD")
            {
                trAllowedAdults.Visible = trNoOfNights.Visible = true;
            }

        }

        //public void ClearControls()
        //{
        //    ucTxtRateCardCode = ucTxtRateCardName = ucTxtDateFrom = ucTxtDateTo = string.Empty;
        //    ucTxtNoOfNights = ucTxtAllowedAdults = ucTxtAllowedChild = string.Empty;
        //    ucChkIsEnable = false;
        //    ddlucPostingFrequency.SelectedIndex = ddlucStayType.SelectedIndex = 0;
        //}
        #endregion

        protected void txtStayDuration_textChanged(object sender, EventArgs e)
        {
            if (txtStayDuration.Text.Trim() != "")
            {
                Session["MinDaysRequired"] = txtStayDuration.Text.Trim();
                this.Page.GetType().InvokeMember("DisplayRackRate", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { txtStayDuration.Text.Trim() });
            }
            else
            {
                Session["MinDaysRequired"] = null;
                this.Page.GetType().InvokeMember("DisplayRackRate", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { txtStayDuration.Text.Trim() });
            }

            txtDateFrom.Focus();
        }
    }
}