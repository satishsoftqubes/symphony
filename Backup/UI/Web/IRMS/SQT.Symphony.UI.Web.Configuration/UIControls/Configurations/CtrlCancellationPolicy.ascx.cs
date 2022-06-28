using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Collections;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlCancellationPolicy : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsCancellationPolicy = false;
        public bool IsMessage = false;
        public bool IsMessagePolicy = false;
        public Guid ResCancellationPolicyID
        {
            get
            {
                return ViewState["ResCancellationPolicyID"] != null ? new Guid(Convert.ToString(ViewState["ResCancellationPolicyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResCancellationPolicyID"] = value;
            }
        }
        public bool IsCancellationPolicyMsg = false;
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

        public Guid ResConfigID
        {
            get
            {
                return ViewState["ResConfigID"] != null ? new Guid(Convert.ToString(ViewState["ResConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResConfigID"] = value;
            }
        }

        public Guid ResPolicyID
        {
            get
            {
                return ViewState["ResPolicyID"] != null ? new Guid(Convert.ToString(ViewState["ResPolicyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResPolicyID"] = value;
            }
        }        
        #endregion Variable and Property

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                //    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                mvCancellationPolicy.ActiveViewIndex = 0;


                ////Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                LoadDefaultValue();

            }
        }

        #endregion Page Load

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                GetDataVerificationCriteria();
                BindBreadCrumb();
                SetPageLabels();
                SetNewSPolicyLabels();
                ////BindCPReservationType();
                ////BindChargesOn();
                ////BindCancellationPolicyGrid();
                //GetPolicyData();
                BindNewSettingCancellationPolicyGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblFrontOfficeSetup", "Policy & Configuration");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCancellation", "Cancellation");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        ////private void BindCancellationPolicyGrid()
        ////{
        ////    try
        ////    {
        ////        DataSet dsCancellationPolicy = ResCancellationPolicyBLL.SearchCancellationPoliycData(clsSession.CompanyID, clsSession.PropertyID, null, null);

        ////        if (dsCancellationPolicy.Tables[0] != null && dsCancellationPolicy.Tables[0].Rows.Count > 0)
        ////        {
        ////            gvReservationCancellationPolicyList.DataSource = dsCancellationPolicy.Tables[0];
        ////            gvReservationCancellationPolicyList.DataBind();
        ////        }
        ////        else
        ////        {
        ////            gvReservationCancellationPolicyList.DataSource = null;
        ////            gvReservationCancellationPolicyList.DataBind();
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        ////        MessageBox.Show(ex.Message.ToString());
        ////    }
        ////}

        ////private void BindCPReservationType()
        ////{
        ////    string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

        ////    List<ProjectTerm> lstProjectTerm = null;
        ////    ProjectTerm objProjectTerm = new ProjectTerm();
        ////    objProjectTerm.IsActive = true;
        ////    objProjectTerm.CompanyID = clsSession.CompanyID;
        ////    objProjectTerm.PropertyID = clsSession.PropertyID;
        ////    objProjectTerm.Category = "RESERVATIONTYPE";
        ////    lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
        ////    if (lstProjectTerm.Count != 0)
        ////    {
        ////        ddlCPResType.DataSource = lstProjectTerm;
        ////        ddlCPResType.DataTextField = "DisplayTerm";
        ////        ddlCPResType.DataValueField = "TermID";
        ////        ddlCPResType.DataBind();
        ////        ddlCPResType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////    }
        ////    else
        ////        ddlCPResType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////}

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblMainHeader", "Cancellation");

            ////litCPResType.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblReservationType", "Reservation Type");
            ////litCPMinHrs.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblMinimumHours", "Min. Hours");
            ////litCPMaxHrs.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblMaximumHours", "Max. Hours");
            ////litCPCancellationCharges.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationCharges", "Cancellation Charges");
            ////litCPChargeOn.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblChargeOn", "Charge On");

            ////revCancellationCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            ////revCancellationCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            ////rvCancellationCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            ////cmpHours.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. hours");

            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblHeaderConfirmDeletePopup", "Cancellation Policy");
            ////litHeadingCancellationPolicyList.Text = litCancellationPolicyList.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblancellationPolicyList", "Cancellation Policy List");

            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            ////btnCPCancel.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            ////ddlCPCancellationCharges.Items.Clear();
            ////ddlCPCancellationCharges.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ////ddlCPCancellationCharges.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

            ////lithdrCancellationPolicy.Text = litCancellationPolicyList.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblhdrCancellationPolicy", "Cancellation Policy");
            lithdrCancellationPolicy.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblhdrCancellationPolicy", "Policy Note");
            //litTabCancellationPolicyConfiguration.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblTabCancellationPolicyConfiguration", "Settings");
            //litTabCancellationPolicy.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblTabCancellationPolicy", "Policy Note");
        }

        private void SetNewSPolicyLabels()
        {
            revFirstCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revFirstCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvFirstCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvFirstMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");


            revSecondCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revSecondCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvSecondCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvSecondMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");



            revThirdCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revThirdCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvThirdCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvThirdMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revFourthCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revFourthCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvFourthCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvFourthMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revFifthCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revFifthCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvFifthCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvFifthMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revSixCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revSixCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvSixCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvSixMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revSevenCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revSevenCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvSevenCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvSevenMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revEighthCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revEighthCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvEighthCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvEighthMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revNineCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revNineCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvNineCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvNineMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");

            revTenCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revTenCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            rvTenCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            cvTenMaxdays.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. Day");
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CANCELLATIONPOLICY.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            //// btnCPSave.Visible = this.UserRights.Substring(2, 1) == "1";
            btnNewSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }

        private void ClearControl()
        {
            //ddlCPCancellationCharges.SelectedIndex = ddlCPResType.SelectedIndex = ddlCPChargeOn.SelectedIndex = 0;
            //txtCPCancellationCharges.Text = txtCPMaxHrs.Text = txtCPMinHrs.Text = "";
            this.ResCancellationPolicyID = Guid.Empty;
            ////ddlCPCancellationCharges_SelectedIndexChanged(null, null);
        }

        ////private void BindChargesOn()
        ////{
        ////    string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

        ////    List<ProjectTerm> lstProjectTerm = null;
        ////    ProjectTerm objProjectTerm = new ProjectTerm();
        ////    objProjectTerm.IsActive = true;
        ////    objProjectTerm.CompanyID = clsSession.CompanyID;
        ////    objProjectTerm.PropertyID = clsSession.PropertyID;
        ////    objProjectTerm.Category = "DISCOUNTTYPE";
        ////    lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
        ////    if (lstProjectTerm.Count != 0)
        ////    {
        ////        ddlCPChargeOn.DataSource = lstProjectTerm;
        ////        ddlCPChargeOn.DataTextField = "DisplayTerm";
        ////        ddlCPChargeOn.DataValueField = "TermID";
        ////        ddlCPChargeOn.DataBind();
        ////        ddlCPChargeOn.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////    }
        ////    else
        ////        ddlCPChargeOn.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////}

        ////private void BindCancellationPolicyData()
        ////{
        ////    if (this.ResCancellationPolicyID != Guid.Empty)
        ////    {
        ////        ResCancellationPolicy GetCancellationPolicyData = ResCancellationPolicyBLL.GetByPrimaryKey(this.ResCancellationPolicyID);

        ////        if (GetCancellationPolicyData != null)
        ////        {

        ////            ddlCPResType.SelectedIndex = ddlCPResType.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ResType_TermID)) != null ? ddlCPResType.Items.IndexOf(ddlCPResType.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ResType_TermID))) : 0;
        ////            ddlCPChargeOn.SelectedIndex = ddlCPChargeOn.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ChargesApply_TermID)) != null ? ddlCPChargeOn.Items.IndexOf(ddlCPChargeOn.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ChargesApply_TermID))) : 0;

        ////            if (Convert.ToString(GetCancellationPolicyData.MinHrs) != "")
        ////                txtCPMinHrs.Text = Convert.ToString(GetCancellationPolicyData.MinHrs);
        ////            else
        ////                txtCPMinHrs.Text = "";

        ////            if (Convert.ToString(GetCancellationPolicyData.MaxHrs) != "")
        ////                txtCPMaxHrs.Text = Convert.ToString(GetCancellationPolicyData.MaxHrs);
        ////            else
        ////                txtCPMaxHrs.Text = "";

        ////            if (Convert.ToString(GetCancellationPolicyData.CancellationCharges) != "")
        ////                txtCPCancellationCharges.Text = Convert.ToString(GetCancellationPolicyData.CancellationCharges.ToString().Substring(0, GetCancellationPolicyData.CancellationCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
        ////            else
        ////                txtCPCancellationCharges.Text = "";

        ////            if (Convert.ToBoolean(GetCancellationPolicyData.IsFlatCharge) == true)
        ////                ddlCPCancellationCharges.SelectedIndex = 1;
        ////            else
        ////                ddlCPCancellationCharges.SelectedIndex = 0;

        ////            ddlCPCancellationCharges_SelectedIndexChanged(null, null);
        ////        }
        ////    }
        ////}

        private void GetPolicyData()
        {
            //List<ReservationConfig> lstReservation = null;
            //ReservationConfig objReservationConfig = new ReservationConfig();
            //objReservationConfig = new ReservationConfig();
            //objReservationConfig.IsActive = true;
            //objReservationConfig.CompanyID = clsSession.CompanyID;
            //objReservationConfig.PropertyID = clsSession.PropertyID;
            //lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

            //if (lstReservation.Count != 0)
            //{
            //    this.ResConfigID = lstReservation[0].ResConfigID;

            //    txtCancellationPolicy.Text = Convert.ToString(lstReservation[0].CancellationPolicy);
            //}
        }

        private void BindNewSettingCancellationPolicyGrid()
        {

            List<CancellationPolicyMaster> lisCancelMaster = CancellationPolicyMasterBLL.GetAll();
            gvCancellationPolicy.DataSource = lisCancelMaster;
            gvCancellationPolicy.DataBind();
        }

        private void ClearControlOfCancellationPolicy()
        {
            txtTitle.Text = txtFirstCharges.Text = txtFirstMaxdays.Text = txtFirstMindays.Text = txtSecondCharges.Text = txtSecondMaxdays.Text = txtSecondMindays.Text = txtThirdCharges.Text = txtThirdMaxdays.Text = txtThirdMindays.Text = txtFourthCharges.Text = txtFourthMaxdays.Text = txtFourthMindays.Text = txtFifthCharges.Text = txtFifthMaxdays.Text = txtFifthMindays.Text = txtSixCharges.Text = txtSixMaxdays.Text = txtSixMindays.Text = txtSevenCharges.Text = txtSevenMaxdays.Text = txtSevenMindays.Text = txtEighthCharges.Text = txtEighthMaxdays.Text = txtEighthMindays.Text = txtNineCharges.Text = txtNineMaxdays.Text = txtNineMindays.Text = txtTenCharges.Text = txtTenMaxdays.Text = txtTenMindays.Text = "";

            ddlFirstChargesType.SelectedIndex = ddlFifthChargesType.SelectedIndex = ddlSecondChargesType.SelectedIndex = ddlThirdChargesType.SelectedIndex = ddlFourthChargesType.SelectedIndex = ddlSixChargesType.SelectedIndex = ddlSevenChargesType.SelectedIndex = ddlEighthChargesType.SelectedIndex = ddlNineChargesType.SelectedIndex = ddlTenChargesType.SelectedIndex = 0;


            chkFirst.Checked = chkSecond.Checked = chkThird.Checked = chkFourth.Checked = chkFifth.Checked = chkSix.Checked = chkSeven.Checked = chkEighth.Checked = chkNine.Checked = chkTen.Checked = false;


            txtFirstCharges.Enabled = txtFirstMaxdays.Enabled = txtFirstMindays.Enabled = txtSecondCharges.Enabled = txtSecondMaxdays.Enabled = txtSecondMindays.Enabled = txtThirdCharges.Enabled = txtThirdMaxdays.Enabled = txtThirdMindays.Enabled = txtFourthCharges.Enabled = txtFourthMaxdays.Enabled = txtFourthMindays.Enabled = txtFifthCharges.Enabled = txtFifthMaxdays.Enabled = txtFifthMindays.Enabled = txtSixCharges.Enabled = txtSixMaxdays.Enabled = txtSixMindays.Enabled = txtSevenCharges.Enabled = txtSevenMaxdays.Enabled = txtSevenMindays.Enabled = txtEighthCharges.Enabled = txtEighthMaxdays.Enabled = txtEighthMindays.Enabled = txtNineCharges.Enabled = txtNineMaxdays.Enabled = txtNineMindays.Enabled = txtTenCharges.Enabled = txtTenMaxdays.Enabled = txtTenMindays.Enabled = ddlFifthChargesType.Enabled = ddlSecondChargesType.Enabled = ddlThirdChargesType.Enabled = ddlFourthChargesType.Enabled = ddlSixChargesType.Enabled = ddlSevenChargesType.Enabled = ddlEighthChargesType.Enabled = ddlNineChargesType.Enabled = ddlTenChargesType.Enabled = ddlFirstChargesType.Enabled = false;

            trPolicySix.Visible = trPolicySeven.Visible = trPolicyEighth.Visible = trPolicyNine.Visible = trPolicyTen.Visible = false;
            clearDropDownVluae();
            txtCancellationPolicy.Text = "";
            this.ResPolicyID = Guid.Empty;
        }

        private void clearDropDownVluae()
        {

            ddlFirstChargesType_SelectedIndexChanged(null, null);
            ddlSecondChargesType_SelectedIndexChanged(null, null);
            ddlThirdChargesType_SelectedIndexChanged(null, null);
            ddlFourthChargesType_SelectedIndexChanged(null, null);
            ddlFifthChargesType_SelectedIndexChanged(null, null);
            ddlSixChargesType_SelectedIndexChanged(null, null);
            ddlSevenChargesType_SelectedIndexChanged(null, null);
            ddlEighthChargesType_SelectedIndexChanged(null, null);
            ddlNineChargesType_SelectedIndexChanged(null, null);
            ddlTenChargesType_SelectedIndexChanged(null, null);
        }
        #endregion Private Method

        #region Button Event

        ////protected void btnCPSave_Click(object sender, EventArgs e)
        ////{
        ////    if (this.Page.IsValid)
        ////    {
        ////        try
        ////        {
        ////            if (this.ResCancellationPolicyID != Guid.Empty)
        ////            {
        ////                ResCancellationPolicy objOldData = ResCancellationPolicyBLL.GetByPrimaryKey(this.ResCancellationPolicyID);
        ////                ResCancellationPolicy objToUpd = ResCancellationPolicyBLL.GetByPrimaryKey(this.ResCancellationPolicyID);

        ////                objToUpd.CompanyID = clsSession.CompanyID;
        ////                objToUpd.PropertyID = clsSession.PropertyID;
        ////                if (ddlCPResType.SelectedIndex != 0)
        ////                    objToUpd.ResType_TermID = new Guid(ddlCPResType.SelectedValue);
        ////                else
        ////                    objToUpd.ResType_TermID = null;

        ////                if (txtCPMinHrs.Text.Trim() != "")
        ////                    objToUpd.MinHrs = Convert.ToInt32(txtCPMinHrs.Text.Trim());
        ////                else
        ////                    objToUpd.MinHrs = null;

        ////                if (txtCPMaxHrs.Text.Trim() != "")
        ////                    objToUpd.MaxHrs = Convert.ToInt32(txtCPMaxHrs.Text.Trim());
        ////                else
        ////                    objToUpd.MaxHrs = null;

        ////                if (ddlCPChargeOn.SelectedIndex != 0)
        ////                    objToUpd.ChargesApply_TermID = new Guid(ddlCPChargeOn.SelectedValue);
        ////                else
        ////                    objToUpd.ChargesApply_TermID = null;

        ////                if (ddlCPCancellationCharges.SelectedIndex == 0)
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToUpd.IsFlatCharge = false;
        ////                        objToUpd.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToUpd.IsFlatCharge = true;
        ////                        objToUpd.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }

        ////                objToUpd.UpdatedOn = DateTime.Now;
        ////                objToUpd.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

        ////                ResCancellationPolicyBLL.Update(objToUpd);

        ////                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objToUpd.ToString(), "res_ResCancellationPolicy");

        ////                IsCancellationPolicy = true;
        ////                litCancellationPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
        ////            }
        ////            else
        ////            {
        ////                ResCancellationPolicy objToIns = new ResCancellationPolicy();

        ////                objToIns.CompanyID = clsSession.CompanyID;
        ////                objToIns.PropertyID = clsSession.PropertyID;
        ////                if (ddlCPResType.SelectedIndex != 0)
        ////                    objToIns.ResType_TermID = new Guid(ddlCPResType.SelectedValue);
        ////                if (txtCPMinHrs.Text.Trim() != "")
        ////                    objToIns.MinHrs = Convert.ToInt32(txtCPMinHrs.Text.Trim());
        ////                if (txtCPMaxHrs.Text.Trim() != "")
        ////                    objToIns.MaxHrs = Convert.ToInt32(txtCPMaxHrs.Text.Trim());
        ////                if (ddlCPChargeOn.SelectedIndex != 0)
        ////                    objToIns.ChargesApply_TermID = new Guid(ddlCPChargeOn.SelectedValue);
        ////                if (ddlCPCancellationCharges.SelectedIndex == 0)
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToIns.IsFlatCharge = false;
        ////                        objToIns.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToIns.IsFlatCharge = true;
        ////                        objToIns.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }

        ////                objToIns.CreatedOn = DateTime.Now;
        ////                objToIns.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
        ////                objToIns.IsActive = true;

        ////                ResCancellationPolicyBLL.Save(objToIns);

        ////                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToIns.ToString(), objToIns.ToString(), "res_ResCancellationPolicy");

        ////                IsCancellationPolicy = true;
        ////                litCancellationPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
        ////            }

        ////            ClearControl();
        ////            BindCancellationPolicyGrid();

        ////            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);

        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        ////            MessageBox.Show(ex.Message.ToString());
        ////        }
        ////    }
        ////}

        protected void btnCPCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
        }

        //protected void btnSavePolicy_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.ResConfigID != Guid.Empty)
        //        {
        //            ReservationConfig objUpd = new ReservationConfig();
        //            ReservationConfig objOldDeptData = new ReservationConfig();
        //            objUpd = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);
        //            objOldDeptData = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);

        //            objUpd.CancellationPolicy = Convert.ToString(txtCancellationPolicy.Text.Trim());

        //            ReservationConfigBLL.Update(objUpd);
        //            ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldDeptData.ToString(), objUpd.ToString(), "res_ReservationConfig");
        //            IsMessage = true;
        //            litMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

        //            this.ResConfigID = objUpd.ResConfigID;

        //        }
        //        else
        //        {
        //            ReservationConfig objIns = new ReservationConfig();

        //            objIns.CompanyID = clsSession.CompanyID;
        //            objIns.PropertyID = clsSession.PropertyID;
        //            objIns.IsActive = true;
        //            objIns.UpdatedOn = DateTime.Now;
        //            objIns.UpdatedBy = clsSession.UserID;
        //            objIns.IsSynch = false;
        //            objIns.CancellationPolicy = Convert.ToString(txtCancellationPolicy.Text.Trim());

        //            ReservationConfigBLL.Save(objIns);
        //            ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "res_ReservationConfig");
        //            IsMessage = true;
        //            litMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

        //            this.ResConfigID = objIns.ResConfigID;

        //        }

        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);

        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        protected void btnNewSave_Click(object sender, EventArgs e)
        {

            List<CancellationPolicy> lstCancellationPolicy = new List<CancellationPolicy>();

            if (this.ResPolicyID != Guid.Empty)
            {
                CancellationPolicyMaster objToUpdate = new CancellationPolicyMaster();
                CancellationPolicyMaster objOldData = new CancellationPolicyMaster();


                objOldData = CancellationPolicyMasterBLL.GetByPrimaryKey(this.ResPolicyID);
                objToUpdate = CancellationPolicyMasterBLL.GetByPrimaryKey(this.ResPolicyID);
                //objToUpdate.ResPolicyID = Guid.NewGuid();
                objToUpdate.CompanyID = clsSession.CompanyID;
                objToUpdate.PropertyID = clsSession.PropertyID;
                objToUpdate.PolicyTitle = txtTitle.Text.Trim();
                objToUpdate.IsActive = true;
                objToUpdate.IsSynch = false;
                objToUpdate.CreatedOn = DateTime.Now;
                objToUpdate.CreatedBy = clsSession.UserID;
                objToUpdate.ResType_TermID = Guid.NewGuid();
                if (txtCancellationPolicy.Text != null)
                {
                    objToUpdate.PolicyNote = Convert.ToString(txtCancellationPolicy.Text.Trim());
                }
                else
                {
                    objToUpdate.PolicyNote = "";
                }
                if (chkFirst.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtFirstCharges.Text.Trim());
                    //if (ddlFirstChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlFirstChargesType.SelectedIndex == 0)
                    {
                        if (txtFirstCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFirstCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtFirstCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFirstCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtFirstMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtFirstMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }

                if (chkSecond.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtSecondCharges.Text.Trim());
                    //if (ddlSecondChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlSecondChargesType.SelectedIndex == 0)
                    {
                        if (txtSecondCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSecondCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtSecondCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSecondCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtSecondMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtSecondMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkThird.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtThirdCharges.Text.Trim());
                    //if (ddlThirdChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlThirdChargesType.SelectedIndex == 0)
                    {
                        if (txtThirdCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtThirdCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtThirdCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtThirdCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtThirdMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtThirdMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkFourth.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtFourthCharges.Text.Trim());
                    //if (ddlFourthChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlFourthChargesType.SelectedIndex == 0)
                    {
                        if (txtFourthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFourthCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtFourthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFourthCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtFourthMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtFourthMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkFifth.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtFifthCharges.Text.Trim());
                    //if (ddlFifthChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlFifthChargesType.SelectedIndex == 0)
                    {
                        if (txtFifthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFifthCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtFifthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFifthCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtFifthMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtFifthMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkSix.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtSixCharges.Text.Trim());
                    //if (ddlSixChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlSixChargesType.SelectedIndex == 0)
                    {
                        if (txtSixCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSixCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtSixCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSixCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtSixMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtSixMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }

                if (chkSeven.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtSevenCharges.Text.Trim());
                    //if (ddlSevenChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlSevenChargesType.SelectedIndex == 0)
                    {
                        if (txtSevenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSevenCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtSevenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSevenCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtSevenMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtSevenMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkEighth.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtEighthCharges.Text.Trim());
                    //if (ddlEighthChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlEighthChargesType.SelectedIndex == 0)
                    {
                        if (txtEighthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtEighthCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtEighthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtEighthCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtEighthMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtEighthMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkNine.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtNineCharges.Text.Trim());
                    //if (ddlNineChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlNineChargesType.SelectedIndex == 0)
                    {
                        if (txtNineCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtNineCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtNineCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtNineCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtNineMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtNineMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkTen.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtTenCharges.Text.Trim());
                    //if (ddlTenChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlTenChargesType.SelectedIndex == 0)
                    {
                        if (txtTenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtTenCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtTenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtTenCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtTenMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtTenMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }

                CancellationPolicyMasterBLL.Update(objToUpdate, lstCancellationPolicy);


                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objToUpdate.ToString(), "res_CancellationPolicyMaster");

                IsMessagePolicy = true;
                litNewCancelPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                BindNewSettingCancellationPolicyGrid();

            }
            else
            {
                CancellationPolicyMaster objToInsert = new CancellationPolicyMaster();

                objToInsert.ResPolicyID = Guid.NewGuid();
                objToInsert.CompanyID = clsSession.CompanyID;
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.PolicyTitle = txtTitle.Text.Trim();
                objToInsert.IsActive = true;
                objToInsert.IsSynch = false;
                objToInsert.CreatedOn = DateTime.Now;
                objToInsert.CreatedBy = clsSession.UserID;
                objToInsert.ResType_TermID = Guid.NewGuid();
                if (txtCancellationPolicy.Text != null)
                {
                    objToInsert.PolicyNote = Convert.ToString(txtCancellationPolicy.Text.Trim());
                }
                else
                {
                    objToInsert.PolicyNote = "";
                }

                if (chkFirst.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtFirstCharges.Text.Trim());
                    //if (ddlFirstChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlFirstChargesType.SelectedIndex == 0)
                    {
                        if (txtFirstCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFirstCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtFirstCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFirstCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtFirstMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtFirstMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }

                if (chkSecond.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtSecondCharges.Text.Trim());
                    //if (ddlSecondChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlSecondChargesType.SelectedIndex == 0)
                    {
                        if (txtSecondCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSecondCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtSecondCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSecondCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtSecondMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtSecondMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkThird.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtThirdCharges.Text.Trim());
                    //if (ddlThirdChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlThirdChargesType.SelectedIndex == 0)
                    {
                        if (txtThirdCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtThirdCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtThirdCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtThirdCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtThirdMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtThirdMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkFourth.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtFourthCharges.Text.Trim());
                    //if (ddlFourthChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlFourthChargesType.SelectedIndex == 0)
                    {
                        if (txtFourthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFourthCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtFourthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFourthCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtFourthMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtFourthMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkFifth.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtFifthCharges.Text.Trim());
                    //if (ddlFifthChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlFifthChargesType.SelectedIndex == 0)
                    {
                        if (txtFifthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFifthCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtFifthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtFifthCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtFifthMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtFifthMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkSix.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtSixCharges.Text.Trim());
                    //if (ddlSixChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlSixChargesType.SelectedIndex == 0)
                    {
                        if (txtSixCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSixCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtSixCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSixCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtSixMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtSixMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }

                if (chkSeven.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtSevenCharges.Text.Trim());
                    //if (ddlSevenChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlSevenChargesType.SelectedIndex == 0)
                    {
                        if (txtSevenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSevenCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtSevenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtSevenCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtSevenMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtSevenMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkEighth.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtEighthCharges.Text.Trim());
                    //if (ddlEighthChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlEighthChargesType.SelectedIndex == 0)
                    {
                        if (txtEighthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtEighthCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtEighthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtEighthCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtEighthMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtEighthMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkNine.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtNineCharges.Text.Trim());
                    //if (ddlNineChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlNineChargesType.SelectedIndex == 0)
                    {
                        if (txtEighthCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtNineCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtNineCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtNineCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtNineMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtNineMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }
                if (chkTen.Checked)
                {
                    CancellationPolicy objTemp = new CancellationPolicy();
                    //objTemp.CancellationCharges = Convert.ToDecimal(txtTenCharges.Text.Trim());
                    //if (ddlTenChargesType.SelectedIndex == 0)
                    //{
                    //    objTemp.IsFlatCharge = true;
                    //}
                    //else
                    //{
                    //    objTemp.IsFlatCharge = false;
                    //}
                    if (ddlTenChargesType.SelectedIndex == 0)
                    {
                        if (txtTenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = false;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtTenCharges.Text.Trim());
                        }
                    }
                    else
                    {
                        if (txtTenCharges.Text.Trim() != "")
                        {
                            objTemp.IsFlatCharge = true;
                            objTemp.CancellationCharges = Convert.ToDecimal(txtTenCharges.Text.Trim());
                        }
                    }
                    objTemp.MinDays = Convert.ToInt32(txtTenMindays.Text.Trim());
                    objTemp.MaxDays = Convert.ToInt32(txtTenMaxdays.Text.Trim());
                    lstCancellationPolicy.Add(objTemp);
                }

                CancellationPolicyMasterBLL.Save(objToInsert, lstCancellationPolicy);

                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "res_CancellationPolicyMaster");

                IsMessagePolicy = true;
                litNewCancelPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                ClearControlOfCancellationPolicy();
                BindNewSettingCancellationPolicyGrid();
            }

            ClearControlOfCancellationPolicy();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);


        }

        protected void bntAddNewPolicy_Click(object sender, EventArgs e)
        {
            if (trPolicySix.Visible == false)
            {
                trPolicySix.Visible = true;
            }
            else if (trPolicySeven.Visible == false)
            {
                trPolicySeven.Visible = true;
            }
            else if (trPolicyEighth.Visible == false)
            {
                trPolicyEighth.Visible = true;
            }
            else if (trPolicyNine.Visible == false)
            {
                trPolicyNine.Visible = true;
            }
            else if (trPolicyTen.Visible == false)
            {
                trPolicyTen.Visible = true;
                bntAddNewPolicy.Visible = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        private void GetDataVerificationCriteria()
        {
            List<ReservationConfig> lstReservationConfig = null;
            ReservationConfig objReservationConfig = new ReservationConfig();
            objReservationConfig = new ReservationConfig();
            objReservationConfig.IsActive = true;
            objReservationConfig.CompanyID = clsSession.CompanyID;
            objReservationConfig.PropertyID = clsSession.PropertyID;
            lstReservationConfig = ReservationConfigBLL.GetAll(objReservationConfig);

            if (lstReservationConfig.Count != 0)
            {
                this.ResConfigID = lstReservationConfig[0].ResConfigID;

                if (lstReservationConfig[0].NoOfAmendmentCriteria != null && Convert.ToString(lstReservationConfig[0].NoOfAmendmentCriteria) != "")
                    txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text = Convert.ToString(lstReservationConfig[0].NoOfAmendmentCriteria);
                else
                    txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text = "";

                decimal dcmlRetentionCharge = Convert.ToDecimal("0.000000");
                if (lstReservationConfig[0].RetentionCharge != null && Convert.ToString(lstReservationConfig[0].RetentionCharge) != "")
                    dcmlRetentionCharge = Convert.ToDecimal(lstReservationConfig[0].RetentionCharge);

                txtRetentionCharge.Text = dcmlRetentionCharge.ToString().Substring(0, dcmlRetentionCharge.ToString().LastIndexOf(".") + 1 + 2);
            }
        }


        protected void btnSaveTop_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ResConfigID != Guid.Empty)
                {
                    ReservationConfig objUpd = new ReservationConfig();
                    ReservationConfig objOldDeptData = new ReservationConfig();
                    objUpd = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);
                    objOldDeptData = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);

                    if (txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim() != string.Empty)
                        objUpd.NoOfAmendmentCriteria = Convert.ToInt32(txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim());
                    else
                        objUpd.NoOfAmendmentCriteria = null;

                    if (txtRetentionCharge.Text.Trim() != string.Empty)
                        objUpd.RetentionCharge = Convert.ToDecimal(txtRetentionCharge.Text.Trim());
                    else
                        objUpd.RetentionCharge = 0;

                    ReservationConfigBLL.Update(objUpd);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldDeptData.ToString(), objUpd.ToString(), "res_ReservationConfig");
                    IsCancellationPolicyMsg = true;
                    litNewCancelPolicyMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                    this.ResConfigID = objUpd.ResConfigID;
                }
                else
                {
                    ReservationConfig objIns = new ReservationConfig();

                    objIns.CompanyID = clsSession.CompanyID;
                    objIns.PropertyID = clsSession.PropertyID;

                    if (txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim() != string.Empty)
                        objIns.NoOfAmendmentCriteria = Convert.ToInt32(txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim());
                    else
                        objIns.NoOfAmendmentCriteria = null;

                    if (txtRetentionCharge.Text.Trim() != string.Empty)
                        objIns.RetentionCharge = Convert.ToDecimal(txtRetentionCharge.Text.Trim());
                    else
                        objIns.RetentionCharge = 0;

                    ReservationConfigBLL.Save(objIns);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "res_ReservationConfig");
                    IsCancellationPolicyMsg = true;
                    litNewCancelPolicyMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    this.ResConfigID = objIns.ResConfigID;
                }

                // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Dropdown Event

        protected void ddlCPCancellationCharges_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////if (ddlCPCancellationCharges.SelectedIndex == 0)
            ////    rvCancellationCharges.Enabled = true;
            ////else
            ////    rvCancellationCharges.Enabled = false;
        }




        protected void ddlFirstChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFirstChargesType.SelectedIndex == 0)
                rvFirstCharges.Enabled = true;
            else
                rvFirstCharges.Enabled = false;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }


        protected void ddlSecondChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSecondChargesType.SelectedIndex == 0)
                rvSecondCharges.Enabled = true;
            else
                rvSecondCharges.Enabled = false;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void ddlThirdChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlThirdChargesType.SelectedIndex == 0)
                rvThirdCharges.Enabled = true;
            else
                rvThirdCharges.Enabled = false;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void ddlFourthChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFourthChargesType.SelectedIndex == 0)
                rvFourthCharges.Enabled = true;
            else
                rvFourthCharges.Enabled = false;
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void ddlFifthChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFifthChargesType.SelectedIndex == 0)
                rvFifthCharges.Enabled = true;
            else
                rvFifthCharges.Enabled = false;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }


        protected void ddlSixChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSixChargesType.SelectedIndex == 0)
                rvSixCharges.Enabled = true;
            else
                rvSixCharges.Enabled = false;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void ddlSevenChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSevenChargesType.SelectedIndex == 0)
                rvSevenCharges.Enabled = true;
            else
                rvSevenCharges.Enabled = false;
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void ddlEighthChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEighthChargesType.SelectedIndex == 0)
                rvEighthCharges.Enabled = true;
            else
                rvEighthCharges.Enabled = false;
            //  Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }
        protected void ddlNineChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNineChargesType.SelectedIndex == 0)
                rvNineCharges.Enabled = true;
            else
                rvNineCharges.Enabled = false;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void ddlTenChargesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTenChargesType.SelectedIndex == 0)
                rvTenCharges.Enabled = true;
            else
                rvTenCharges.Enabled = false;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        #endregion Dropdown Event

        #region Grid Event

        protected void gvReservationCancellationPolicyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvCancellationCharges = (Label)e.Row.FindControl("lblGvCancellationCharges");
                    string strCancellationCharges = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));

                    if (lblGvCancellationCharges != null)
                    {
                        if (strCancellationCharges != string.Empty)
                            lblGvCancellationCharges.Text = strCancellationCharges.Substring(0, strCancellationCharges.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                    }

                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResPolicyID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrReservationType")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrReservationType", "Reservation Type");
                    ((Label)e.Row.FindControl("lblGvHdrChargesOn")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrChargesOn", "Charge On");
                    ((Label)e.Row.FindControl("lblGvHdrMinHrs")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrMinHrs", "Min. Hours");
                    ((Label)e.Row.FindControl("lblGvHdrMaxHrs")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrMaxHrs", "Max. Hours");
                    ((Label)e.Row.FindControl("lblGvHdrCancellationCharges")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrCancellationCharges", "Cancellation Charges");
                    ((Label)e.Row.FindControl("lblGvHdrType")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrType", "Type");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
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

        ////protected void gvReservationCancellationPolicyList_RowCommand(object sender, GridViewCommandEventArgs e)
        ////{
        ////    try
        ////    {
        ////        if (e.CommandName.Equals("EDITDATA"))
        ////        {
        ////            this.ResCancellationPolicyID = new Guid(Convert.ToString(e.CommandArgument));
        ////            BindCancellationPolicyData();
        ////        }
        ////        else if (e.CommandName.Equals("DELETEDATA"))
        ////        {
        ////            mpeConfirmDelete.Show();
        ////            this.ResCancellationPolicyID = new Guid(Convert.ToString(e.CommandArgument));
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        MessageBox.Show(ex.Message.ToString());
        ////    }
        ////}

        ////protected void gvReservationCancellationPolicyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        ////{
        ////    gvReservationCancellationPolicyList.PageIndex = e.NewPageIndex;
        ////    BindCancellationPolicyGrid();
        ////}

        #endregion Grid Event

        #region New Cancellation Policy Grid Event

        protected void gvCancellationPolicy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName.Equals("EDITDATA"))
                {

                    ClearControlOfCancellationPolicy();
                    this.ResPolicyID = new Guid(Convert.ToString(e.CommandArgument));

                    CancellationPolicyMaster CancellationPolicyMaster = CancellationPolicyMasterBLL.GetByPrimaryKey(this.ResPolicyID);
                    if (mvCancellationPolicy != null)
                    {
                        txtTitle.Text = Convert.ToString(CancellationPolicyMaster.PolicyTitle);
                        if (CancellationPolicyMaster.PolicyNote != null)
                        {
                            txtCancellationPolicy.Text = Convert.ToString(CancellationPolicyMaster.PolicyNote);
                        }
                        else
                        {
                            txtCancellationPolicy.Text = "";
                        }
                    }
                    DataSet dsCancellationPolicy = CancellationPolicyBLL.GetAllByWithDataSet(CancellationPolicy.CancellationPolicyFields.ResPolicyID, Convert.ToString(this.ResPolicyID));
                    if (dsCancellationPolicy != null)
                    {
                        for (int i = 0; i < dsCancellationPolicy.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                chkFirst.Checked = true;
                                //txtFirstCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();

                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtFirstCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtFirstCharges.Text = "";


                                txtFirstMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtFirstMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlFirstChargesType.SelectedIndex = 1;
                                else
                                    ddlFirstChargesType.SelectedIndex = 0;


                                txtFirstCharges.Enabled = txtFirstMaxdays.Enabled = txtFirstMindays.Enabled = ddlFirstChargesType.Enabled = true;
                            }

                            if (i == 1)
                            {
                                chkSecond.Checked = true;
                                //txtSecondCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();

                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtSecondCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtSecondCharges.Text = "";
                                txtSecondMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtSecondMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlSecondChargesType.SelectedIndex = 1;
                                else
                                    ddlSecondChargesType.SelectedIndex = 0;

                                txtSecondCharges.Enabled = txtSecondMaxdays.Enabled = txtSecondMindays.Enabled = ddlSecondChargesType.Enabled = true;
                            }
                            if (i == 2)
                            {
                                chkThird.Checked = true;
                                //txtThirdCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();

                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtThirdCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtThirdCharges.Text = "";
                                txtThirdMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtThirdMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlThirdChargesType.SelectedIndex = 1;
                                else
                                    ddlThirdChargesType.SelectedIndex = 0;

                                txtThirdCharges.Enabled = txtThirdMaxdays.Enabled = txtThirdMindays.Enabled = ddlThirdChargesType.Enabled = true;
                            }
                            if (i == 3)
                            {
                                chkFourth.Checked = true;
                                //txtFourthCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();

                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtFourthCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtFourthCharges.Text = "";
                                txtFourthMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtFourthMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlFourthChargesType.SelectedIndex = 1;
                                else
                                    ddlFourthChargesType.SelectedIndex = 0;

                                txtFourthCharges.Enabled = txtFourthMaxdays.Enabled = txtFourthMindays.Enabled = ddlFourthChargesType.Enabled = true;
                            }
                            if (i == 4)
                            {
                                chkFifth.Checked = true;
                                //txtFifthCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();
                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtFifthCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtFifthCharges.Text = "";
                                txtFifthMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtFifthMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlFifthChargesType.SelectedIndex = 1;
                                else
                                    ddlFifthChargesType.SelectedIndex = 0;

                                txtFifthCharges.Enabled = txtFifthMaxdays.Enabled = txtFifthMindays.Enabled = ddlFifthChargesType.Enabled = true;
                            }
                            if (i == 5)
                            {
                                chkSix.Checked = true;
                                trPolicySix.Visible = true;

                                //txtSixCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();
                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtSixCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtSixCharges.Text = "";
                                txtSixMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtSixMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlSixChargesType.SelectedIndex = 1;
                                else
                                    ddlSixChargesType.SelectedIndex = 0;

                                txtSixCharges.Enabled = txtSixMaxdays.Enabled = txtSixMindays.Enabled = ddlSixChargesType.Enabled = true;
                            }
                            if (i == 6)
                            {
                                chkSeven.Checked = true;
                                trPolicySeven.Visible = true;
                                //txtSevenCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();
                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtSevenCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtSevenCharges.Text = "";
                                txtSevenMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtSevenMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlSevenChargesType.SelectedIndex = 1;
                                else
                                    ddlSevenChargesType.SelectedIndex = 0;

                                txtSevenCharges.Enabled = txtSevenMaxdays.Enabled = txtSevenMindays.Enabled = ddlSevenChargesType.Enabled = true;
                            }
                            if (i == 7)
                            {
                                chkEighth.Checked = true;
                                trPolicyEighth.Visible = true;
                                //txtEighthCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();
                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtEighthCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtEighthCharges.Text = "";
                                txtEighthMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtEighthMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlEighthChargesType.SelectedIndex = 1;
                                else
                                    ddlEighthChargesType.SelectedIndex = 0;

                                txtEighthCharges.Enabled = txtEighthMaxdays.Enabled = txtEighthMindays.Enabled = ddlEighthChargesType.Enabled = true;
                            }
                            if (i == 8)
                            {
                                chkNine.Checked = true;
                                trPolicyNine.Visible = true;
                                // txtNineCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();
                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtNineCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtNineCharges.Text = "";
                                txtNineMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtNineMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlNineChargesType.SelectedIndex = 1;
                                else

                                    txtNineCharges.Enabled = txtNineMaxdays.Enabled = txtNineMindays.Enabled = ddlNineChargesType.Enabled = true;
                            }
                            if (i == 9)
                            {
                                chkTen.Checked = true;
                                trPolicyTen.Visible = true;
                                //txtTenCharges.Text = dsCancellationPolicy.Tables[0].Rows[i][2].ToString();
                                if (Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2]) != "")
                                    txtTenCharges.Text = Convert.ToString(dsCancellationPolicy.Tables[0].Rows[i][2].ToString().Substring(0, dsCancellationPolicy.Tables[0].Rows[i][2].ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                else
                                    txtTenCharges.Text = "";
                                txtTenMindays.Text = dsCancellationPolicy.Tables[0].Rows[i][4].ToString();
                                txtTenMaxdays.Text = dsCancellationPolicy.Tables[0].Rows[i][5].ToString();
                                if (Convert.ToBoolean(dsCancellationPolicy.Tables[0].Rows[i][3]) == true)
                                    ddlTenChargesType.SelectedIndex = 1;
                                else
                                    ddlTenChargesType.SelectedIndex = 0;

                                txtTenCharges.Enabled = txtTenMaxdays.Enabled = txtTenMindays.Enabled = ddlTenChargesType.Enabled = true;
                            }
                        }
                    }
                    clearDropDownVluae();
                    mvCancellationPolicy.ActiveViewIndex = 1;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);

                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.ResPolicyID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDeletePolicy.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCancellationPolicy_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCancellationPolicy.PageIndex = e.NewPageIndex;
            BindNewSettingCancellationPolicyGrid();
        }

        protected void gvCancellationPolicy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    Label lblRateCardsToDisplay = (Label)e.Row.FindControl("lblRateCards");
                    string strQueryForRateCard = "DECLARE @RateCardName as varchar(Max) SELECT @RateCardName = COALESCE(@RateCardName+',' ,'') + mst_RateCard.RateCardName FROM mst_RateCard Where CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "' and PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and CancellationPolicyID = '" + Convert.ToString(gvCancellationPolicy.DataKeys[e.Row.RowIndex]["ResPolicyID"]) + "' select @RateCardName as RateCardName";
                    DataSet dsForRateCard = RoomBLL.GetUnitNo(strQueryForRateCard);
                    if (dsForRateCard != null && dsForRateCard.Tables.Count > 0 && dsForRateCard.Tables[0].Rows.Count > 0)
                    {
                        lblRateCardsToDisplay.Text = Convert.ToString(dsForRateCard.Tables[0].Rows[0]["RateCardName"]);
                    }
                    else
                    {
                        lblRateCardsToDisplay.Text = "";
                    }
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDeletePolicy('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResPolicyID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrPolicyTitle")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrPolicyTitle", "Policy Title");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
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
                    ResCancellationPolicy objDelete = new ResCancellationPolicy();
                    objDelete = ResCancellationPolicyBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    ResCancellationPolicyBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Room");
                    IsCancellationPolicy = true;
                    ////litCancellationPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                //// BindCancellationPolicyGrid();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region CheckBox Event
        protected void ckhFirst_Changed(object sender, EventArgs e)
        {
            if (chkFirst.Checked)
            {
                txtFirstCharges.Enabled = txtFirstMaxdays.Enabled = txtFirstMindays.Enabled = ddlFirstChargesType.Enabled = true;
                rfvFirstCharges.Enabled = rfvFirstMaxdays.Enabled = rfvFirstMindays.Enabled = true;
            }
            else
            {
                txtFirstCharges.Enabled = txtFirstMaxdays.Enabled = txtFirstMindays.Enabled = ddlFirstChargesType.Enabled = false;
                chkSecond.Checked = chkThird.Checked = chkFourth.Checked = chkFifth.Checked = chkSix.Checked = chkSeven.Checked = chkEighth.Checked = chkNine.Checked = chkTen.Checked = false;

                txtSecondCharges.Enabled = txtSecondMaxdays.Enabled = txtSecondMindays.Enabled = ddlSecondChargesType.Enabled = false;
                txtThirdCharges.Enabled = txtThirdMaxdays.Enabled = txtThirdMindays.Enabled = ddlThirdChargesType.Enabled = false;
                txtFourthCharges.Enabled = txtFourthMaxdays.Enabled = txtFourthMindays.Enabled = ddlFourthChargesType.Enabled = false;
                txtFifthCharges.Enabled = txtFifthMaxdays.Enabled = txtFifthMindays.Enabled = ddlFifthChargesType.Enabled = false;
                txtSixCharges.Enabled = txtSixMaxdays.Enabled = txtSixMindays.Enabled = ddlSixChargesType.Enabled = false;
                txtSevenCharges.Enabled = txtSevenMaxdays.Enabled = txtSevenMindays.Enabled = ddlSevenChargesType.Enabled = false;
                txtEighthCharges.Enabled = txtEighthMaxdays.Enabled = txtEighthMindays.Enabled = ddlEighthChargesType.Enabled = false;
                txtNineCharges.Enabled = txtNineMaxdays.Enabled = txtNineMindays.Enabled = ddlNineChargesType.Enabled = false;
                txtTenCharges.Enabled = txtTenMaxdays.Enabled = txtTenMindays.Enabled = ddlTenChargesType.Enabled = false;

                rfvFirstCharges.Enabled = rfvFirstMaxdays.Enabled = rfvFirstMindays.Enabled = false;
                rfvTenCharges.Enabled = rfvTenMaxdays.Enabled = rfvTenMindays.Enabled = false;
                rfvSecondCharges.Enabled = rfvSecondMaxdays.Enabled = rfvSecondMindays.Enabled = false;
                rfvThirdCharges.Enabled = rfvThirdMaxdays.Enabled = rfvThirdMindays.Enabled = false;
                rfvFourthCharges.Enabled = rfvFourthMaxdays.Enabled = rfvFourthMindays.Enabled = false;
                rfvFifthCharges.Enabled = rfvFifthMaxdays.Enabled = rfvFifthMindays.Enabled = false;
                rfvSixCharges.Enabled = rfvSixMaxdays.Enabled = rfvSixMindays.Enabled = false;
                rfvSevenCharges.Enabled = rfvSevenMaxdays.Enabled = rfvSevenMindays.Enabled = false;
                rfvEighthCharges.Enabled = rfvEighthMaxdays.Enabled = rfvEighthMindays.Enabled = false;
                rfvNineCharges.Enabled = rfvNineMaxdays.Enabled = rfvNineMindays.Enabled = false;
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkSecond_Changed(object sender, EventArgs e)
        {
            if (chkFirst.Checked)
            {
                if (chkSecond.Checked)
                {
                    txtSecondCharges.Enabled = txtSecondMaxdays.Enabled = txtSecondMindays.Enabled = ddlSecondChargesType.Enabled = true;
                    rfvSecondCharges.Enabled = rfvSecondMaxdays.Enabled = rfvSecondMindays.Enabled = true;
                }
                else
                {
                    txtSecondCharges.Enabled = txtSecondMaxdays.Enabled = txtSecondMindays.Enabled = ddlSecondChargesType.Enabled = false;
                    rfvSecondCharges.Enabled = rfvSecondMaxdays.Enabled = rfvSecondMindays.Enabled = false;
                }
            }
            else
            {
                chkSecond.Checked = false;
                txtSecondCharges.Enabled = txtSecondMaxdays.Enabled = txtSecondMindays.Enabled = ddlSecondChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkThird_Changed(object sender, EventArgs e)
        {
            if (chkSecond.Checked)
            {
                if (chkThird.Checked)
                {
                    txtThirdCharges.Enabled = txtThirdMaxdays.Enabled = txtThirdMindays.Enabled = ddlThirdChargesType.Enabled = true;
                    rfvThirdCharges.Enabled = rfvThirdMaxdays.Enabled = rfvThirdMindays.Enabled = true;
                }
                else
                {
                    txtThirdCharges.Enabled = txtThirdMaxdays.Enabled = txtThirdMindays.Enabled = ddlThirdChargesType.Enabled = false;
                    rfvThirdCharges.Enabled = rfvThirdMaxdays.Enabled = rfvThirdMindays.Enabled = false;
                }
            }
            else
            {
                chkThird.Checked = false;
                txtThirdCharges.Enabled = txtThirdMaxdays.Enabled = txtThirdMindays.Enabled = ddlThirdChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkFourth_Changed(object sender, EventArgs e)
        {
            if (chkThird.Checked)
            {
                if (chkFourth.Checked)
                {
                    txtFourthCharges.Enabled = txtFourthMaxdays.Enabled = txtFourthMindays.Enabled = ddlFourthChargesType.Enabled = true;
                    rfvFourthCharges.Enabled = rfvFourthMaxdays.Enabled = rfvFourthMindays.Enabled = true;
                }
                else
                {
                    txtFourthCharges.Enabled = txtFourthMaxdays.Enabled = txtFourthMindays.Enabled = ddlFourthChargesType.Enabled = false;
                    rfvFourthCharges.Enabled = rfvFourthMaxdays.Enabled = rfvFourthMindays.Enabled = false;
                }
            }
            else
            {
                chkFourth.Checked = false;
                txtFourthCharges.Enabled = txtFourthMaxdays.Enabled = txtFourthMindays.Enabled = ddlFourthChargesType.Enabled = false;
            }
            //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkFifth_Changed(object sender, EventArgs e)
        {
            if (chkFourth.Checked)
            {
                if (chkFifth.Checked)
                {
                    txtFifthCharges.Enabled = txtFifthMaxdays.Enabled = txtFifthMindays.Enabled = ddlFifthChargesType.Enabled = true;
                    rfvFifthCharges.Enabled = rfvFifthMaxdays.Enabled = rfvFifthMindays.Enabled = true;
                }
                else
                {
                    txtFifthCharges.Enabled = txtFifthMaxdays.Enabled = txtFifthMindays.Enabled = ddlFifthChargesType.Enabled = false;
                    rfvFifthCharges.Enabled = rfvFifthMaxdays.Enabled = rfvFifthMindays.Enabled = false;
                }
            }
            else
            {
                chkFifth.Checked = false;
                txtFifthCharges.Enabled = txtFifthMaxdays.Enabled = txtFifthMindays.Enabled = ddlFifthChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkSix_Changed(object sender, EventArgs e)
        {
            if (chkFifth.Checked)
            {
                if (chkSix.Checked)
                {
                    txtSixCharges.Enabled = txtSixMaxdays.Enabled = txtSixMindays.Enabled = ddlSixChargesType.Enabled = true;
                    rfvSixCharges.Enabled = rfvSixMaxdays.Enabled = rfvSixMindays.Enabled = true;
                }
                else
                {
                    txtSixCharges.Enabled = txtSixMaxdays.Enabled = txtSixMindays.Enabled = ddlSixChargesType.Enabled = false;
                    rfvSixCharges.Enabled = rfvSixMaxdays.Enabled = rfvSixMindays.Enabled = false;
                }
            }
            else
            {
                chkSix.Checked = false;
                txtSixCharges.Enabled = txtSixMaxdays.Enabled = txtSixMindays.Enabled = ddlSixChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkSeven_Changed(object sender, EventArgs e)
        {
            if (chkSix.Checked)
            {
                if (chkSeven.Checked)
                {
                    txtSevenCharges.Enabled = txtSevenMaxdays.Enabled = txtSevenMindays.Enabled = ddlSevenChargesType.Enabled = true;
                    rfvSevenCharges.Enabled = rfvSevenMaxdays.Enabled = rfvSevenMindays.Enabled = true;
                }
                else
                {
                    txtSevenCharges.Enabled = txtSevenMaxdays.Enabled = txtSevenMindays.Enabled = ddlSevenChargesType.Enabled = false;
                    rfvSevenCharges.Enabled = rfvSevenMaxdays.Enabled = rfvSevenMindays.Enabled = false;
                }
            }
            else
            {
                chkSeven.Checked = false;
                txtSevenCharges.Enabled = txtSevenMaxdays.Enabled = txtSevenMindays.Enabled = ddlSevenChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkEighth_Changed(object sender, EventArgs e)
        {
            if (chkSeven.Checked)
            {
                if (chkEighth.Checked)
                {
                    txtEighthCharges.Enabled = txtEighthMaxdays.Enabled = txtEighthMindays.Enabled = ddlEighthChargesType.Enabled = true;
                    rfvEighthCharges.Enabled = rfvEighthMaxdays.Enabled = rfvEighthMindays.Enabled = true;
                }
                else
                {
                    txtEighthCharges.Enabled = txtEighthMaxdays.Enabled = txtEighthMindays.Enabled = ddlEighthChargesType.Enabled = false;
                    rfvEighthCharges.Enabled = rfvEighthMaxdays.Enabled = rfvEighthMindays.Enabled = false;
                }
            }
            else
            {
                chkEighth.Checked = false;
                txtEighthCharges.Enabled = txtEighthMaxdays.Enabled = txtEighthMindays.Enabled = ddlEighthChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkNine_Changed(object sender, EventArgs e)
        {
            if (chkEighth.Checked)
            {
                if (chkNine.Checked)
                {
                    txtNineCharges.Enabled = txtNineMaxdays.Enabled = txtNineMindays.Enabled = ddlNineChargesType.Enabled = true;
                    rfvNineCharges.Enabled = rfvNineMaxdays.Enabled = rfvNineMindays.Enabled = true;
                }
                else
                {
                    txtNineCharges.Enabled = txtNineMaxdays.Enabled = txtNineMindays.Enabled = ddlNineChargesType.Enabled = false;
                    rfvNineCharges.Enabled = rfvNineMaxdays.Enabled = rfvNineMindays.Enabled = false;

                }
            }
            else
            {
                chkNine.Checked = false;
                txtNineCharges.Enabled = txtNineMaxdays.Enabled = txtNineMindays.Enabled = ddlNineChargesType.Enabled = false;
            }
            //   Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void chkTen_Changed(object sender, EventArgs e)
        {
            if (chkNine.Checked)
            {
                if (chkTen.Checked)
                {
                    txtTenCharges.Enabled = txtTenMaxdays.Enabled = txtTenMindays.Enabled = ddlTenChargesType.Enabled = true;
                    rfvTenCharges.Enabled = rfvTenMaxdays.Enabled = rfvTenMindays.Enabled = true;
                }
                else
                {
                    txtTenCharges.Enabled = txtTenMaxdays.Enabled = txtTenMindays.Enabled = ddlTenChargesType.Enabled = false;
                    rfvTenCharges.Enabled = rfvTenMaxdays.Enabled = rfvTenMindays.Enabled = false;
                }
            }
            else
            {
                chkTen.Checked = false;
                txtTenCharges.Enabled = txtTenMaxdays.Enabled = txtTenMindays.Enabled = ddlTenChargesType.Enabled = false;
            }
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }
        #endregion

        #region Popup Button Event New Cancellation

        protected void btnYesPolicy_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDeletePolicy.Value) != string.Empty)
                {

                    mpeConfirmDeletePolicy.Hide();
                    CancellationPolicyMaster objDelete = new CancellationPolicyMaster();
                    objDelete = CancellationPolicyMasterBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDeletePolicy.Value)));

                    CancellationPolicyMasterBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "res_CancellationPolicyMaster");


                    CancellationPolicyBLL.Delete(CancellationPolicy.CancellationPolicyFields.ResPolicyID, Convert.ToString(objDelete.ResPolicyID));
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "res_CancellationPolicyMaster");


                }
                ClearControlOfCancellationPolicy();
                BindNewSettingCancellationPolicyGrid();

                IsCancellationPolicyMsg = true;
                litNewCancelPolicyMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnNoPolicy_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlOfCancellationPolicy();
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        protected void btnAddCancellationPolicy_Click(object sender, EventArgs e)
        {
            mvCancellationPolicy.ActiveViewIndex = 1;
            ClearControlOfCancellationPolicy();
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

        protected void btnNewCancel_Click(object sender, EventArgs e)
        {
            mvCancellationPolicy.ActiveViewIndex = 0;
            // Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }

    }
}