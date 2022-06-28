using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorPaymentReceipt : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;

        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
        public Guid InvestorPaymentReceiptID
        {
            get
            {
                return ViewState["InvestorPaymentReceiptID"] != null ? new Guid(Convert.ToString(ViewState["InvestorPaymentReceiptID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InvestorPaymentReceiptID"] = value;
            }
        }
        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("InvestorPaymentReceiptSetUP.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            //txtReconciledOn.Attributes.Add("autocomplete", "off");
            if (!IsPostBack)
            {
                LoadDefaultValue();
                if (Request.QueryString["IPRID"] != null)
                {
                    this.InvestorPaymentReceiptID = new Guid(Convert.ToString(Request.QueryString["IPRID"]));
                    if (this.InvestorPaymentReceiptID != Guid.Empty)
                        LoadPaymentReceiptData();
                }
                if (Request.QueryString["Val"] == null)
                {
                    ////ddlInvestor.Enabled = ddlRoomName.Enabled = true;
                    ddlInvestor.Enabled = true;
                    Session["InvRm"] = null;
                }
                else
                {
                    ////ddlInvestor.Enabled = ddlRoomName.Enabled = ddlPropertyName.Enabled = txtSUnitNumber.Enabled = txtSInvestorName.Enabled = false;
                    ////txtSUnitNumber.Text = ddlRoomName.SelectedItem.Text;
                    ddlInvestor.Enabled = ddlPropertyName.Enabled = txtSInvestorName.Enabled = false;

                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                        ddlPropertyName.Enabled = true;

                    txtSInvestorName.Text = ddlInvestor.SelectedItem.Text;
                    btnSearch.Enabled = false;
                    BindGrid();
                }
            }
            // }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorPaymentReceiptSetUP.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.InvestorPaymentReceiptID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);

            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        private void LoadDefaultValue()
        {
            try
            {
                if (Session["CompanyID"] != null)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    if (Session["PropertyConfigurationInfo"] != null)
                    {
                        PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                        ProjectTerm objProjectTerm = new ProjectTerm();
                        Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                        objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                        if (objProjectTerm != null)
                            this.DateFormat = objProjectTerm.Term;
                        else
                            this.DateFormat = "dd/MM/yyyy";
                    }
                    else
                        this.DateFormat = "dd/MM/yyyy";

                    calDate.Format = this.DateFormat;
                    ClearControlValue();
                    BindGrid();
                    ////BindPyamentSchedule();
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Control Value
        /// </summary>
        private void ClearControlValue()
        {
            LoadComboControl();

            txtPaidAmount.Text = txtBankName.Text = txtChecqueNo.Text = "";
            // "";
            //txtBankReceiptNo.Text = "";
            //txtReconciledOn.Text = "";
            //txtDepostiToBank.Text = "";
            txtSInvestorName.Text = "";
            txtReceiptNo.Text = "";
            ddlInvestor.Focus();
            //chkIsReconciled.Checked = false;
            //chkIsReconciled_CheckedChanged(null, null);
            this.InvestorPaymentReceiptID = Guid.Empty;
            //LoadPaymentMode();
            ////lblPaidAmount.Text = lblTotalSlabAmount.Text = lblDisplayBalanceAmount.Text = "0.0";
            hdnPaymentSlab.Value = "";
            aLicenseNo.Visible = false;
            imgDelete.Visible = false;
            ////lblPaidAmountErrorMessage.Text = "";
            //rvftxtBankName.Enabled = false;
            txtDate.Text = Convert.ToString(DateTime.Now.ToString(this.DateFormat));
            ////ddlRoomName_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Load Combo Control
        /// </summary>        
        private void LoadComboControl()
        {
            try
            {
                LoadInvestor();
                BindProperty();
                ////ddlPropertyName_SelectedIndexChanged(null, null);
                LoadPaymentMode();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Payment Mode
        /// </summary>       
        private void LoadPaymentMode()
        {
            ProjectTerm PaymentTerm = new ProjectTerm();
            PaymentTerm.CompanyID = this.CompanyID;
            PaymentTerm.Category = "PAYMENTMODE";
            PaymentTerm.IsActive = true;

            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(PaymentTerm);
            if (Lst.Count > 0)
            {
                ddlModeOfPayment.DataSource = Lst;
                ddlModeOfPayment.DataTextField = "DisplayTerm";
                ddlModeOfPayment.DataValueField = "TermID";
                ddlModeOfPayment.DataBind();
                ddlModeOfPayment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlModeOfPayment.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


        }
        /// <summary>
        /// Load Investor
        /// </summary>        
        private void LoadInvestor()
        {
            Guid? RelationShipManagerID = null;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN" || UserType.ToUpper() == "INVESTOR")
                RelationShipManagerID = null;
            else
                RelationShipManagerID = new Guid(Convert.ToString(Session["UserTypeID"]));
            DataSet ds = InvestorBLL.SearchInfo(null, null, null, null, null, null, RelationShipManagerID, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlInvestor.DataSource = ds;
                ddlInvestor.DataTextField = "InvestorName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
            }
            ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            if (Convert.ToString(Session["InvID"]) != Guid.Empty.ToString() && Session["InvID"] != null)
                ddlInvestor.SelectedValue = Convert.ToString(Session["InvID"]);
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string fullName = null;
            //string unitNo = null;
            Guid? CreatedBy = null;
            if (!txtSInvestorName.Text.Equals(""))
                fullName = txtSInvestorName.Text.Trim();

            //if (!txtSUnitNumber.Text.Equals(""))
            //    unitNo = txtSUnitNumber.Text.Trim();

            ////Guid? InvestorID;
            ////if (ddlInvestor.SelectedValue != Guid.Empty.ToString())
            ////    InvestorID = new Guid(ddlInvestor.SelectedValue);
            ////else
            ////    InvestorID = null;

            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN" || UserType.ToUpper() == "INVESTOR" || UserType.ToUpper() == "CHANNELPARTNER")
                CreatedBy = null;
            else
                CreatedBy = new Guid(Convert.ToString(Session["UserTypeID"]));
            //DataSet ds = InvestorPaymentReceiptBLL.SelectAllWithSearchDataSetForTax(null, InvestorID, fullName, this.CompanyID, new Guid(Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["ReceiptTypeTermIDRoom"])), CreatedBy, null, unitNo, null, null);
            DataSet dsSearch = InvestorPaymentReceiptBLL.SearchPaymentReceiptData(null, fullName, new Guid(Convert.ToString(Session["CompanyID"])), new Guid(Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["ReceiptTypeTermIDRoom"])), CreatedBy, null);

            if (dsSearch.Tables[0].Rows.Count > 0)
            {
                grdInvRecptList.DataSource = dsSearch.Tables[0];
                grdInvRecptList.DataBind();
            }
            else
            {
                grdInvRecptList.DataSource = null;
                grdInvRecptList.DataBind();
            }
        }

        /// <summary>
        /// Load PaymentReceipt Data
        /// </summary>
        private void LoadPaymentReceiptData()
        {
            try
            {
                LoadAccess();
                InvestorPaymentReceipt GetData = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);

                ddlInvestor.SelectedIndex = ddlInvestor.Items.FindByValue(Convert.ToString(GetData.InvestorID)) != null ? ddlInvestor.Items.IndexOf(ddlInvestor.Items.FindByValue(Convert.ToString(GetData.InvestorID))) : 0;

                BindProperty();

                ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(GetData.PropertyID)) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(GetData.PropertyID))) : 0;


                //if (Convert.ToString(GetData.UnitID) != "" && Convert.ToString(GetData.UnitID) != null)
                //{
                //    DataSet dsLoadProperty = InvestorPaymentReceiptBLL.SelectInvestorPropertyName(GetData.UnitID);
                //    if (dsLoadProperty != null && dsLoadProperty.Tables[0].Rows.Count > 0)
                //        ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(dsLoadProperty.Tables[0].Rows[0]["PropertyID"])) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(dsLoadProperty.Tables[0].Rows[0]["PropertyID"]))) : 0;
                //    else
                //        ddlPropertyName.SelectedIndex = 0;
                //}
                //else
                //    ddlPropertyName.SelectedIndex = 0;

                ////ddlPropertyName_SelectedIndexChanged(null, null);

                ////if (Convert.ToString(GetData.UnitID) != "")
                ////    ddlRoomName.SelectedIndex = ddlRoomName.Items.FindByValue(Convert.ToString(GetData.UnitID)) != null ? ddlRoomName.Items.IndexOf(ddlRoomName.Items.FindByValue(Convert.ToString(GetData.UnitID))) : 0;
                txtReceiptNo.Text = Convert.ToString(GetData.ReceiptNo);
                ////BindPyamentSchedule();
                ////if (Convert.ToString(GetData.PaymentScheduleID) != null && Convert.ToString(GetData.PaymentScheduleID) != "")
                ////    ddlPaymentSchedule.SelectedIndex = ddlPaymentSchedule.Items.FindByValue(Convert.ToString(GetData.PaymentScheduleID)) != null ? ddlPaymentSchedule.Items.IndexOf(ddlPaymentSchedule.Items.FindByValue(Convert.ToString(GetData.PaymentScheduleID))) : 0;
                hdnTotal.Value = "";

                ////PaymentSchedule objPS = PaymentScheduleBLL.GetByPrimaryKey(new Guid(Convert.ToString(ddlPaymentSchedule.SelectedValue)));

                ////double MaxValue = 0;

                ////if (objPS != null)
                ////{
                ////    hdnPaymentSlab.Value = lblTotalSlabAmount.Text = Convert.ToString(objPS.AmountPayable) != string.Empty ? Convert.ToString(objPS.AmountPayable) : "0.0";
                ////    decimal dblEditTotalReceived = 0;
                ////    decimal dblEditAmountPayable = 0;
                ////    decimal dblEditPaidAmount = 0;

                ////    if (Convert.ToString(objPS.TotalReceived) != "")
                ////        dblEditTotalReceived = Convert.ToDecimal(objPS.TotalReceived);

                ////    if (Convert.ToString(objPS.AmountPayable) != "")
                ////        dblEditAmountPayable = Convert.ToDecimal(objPS.AmountPayable);

                ////    if (Convert.ToString(GetData.PaidAmount) != "")
                ////        dblEditPaidAmount = Convert.ToDecimal(GetData.PaidAmount);

                ////    lblPaidAmount.Text = Convert.ToString(dblEditTotalReceived);

                ////    MaxValue = Convert.ToDouble(dblEditAmountPayable - dblEditTotalReceived + dblEditPaidAmount);
                ////    rvAmt.MaximumValue = Convert.ToString(MaxValue);
                ////}
                ////else
                ////{
                ////    hdnPaymentSlab.Value = "";
                ////    lblTotalSlabAmount.Text = lblPaidAmount.Text = "0.0";
                ////    rvAmt.MaximumValue = "0";
                ////}

                ////rvAmt.MinimumValue = "0";

                //hdnPaymentSlab.Value = Convert.ToString(objPS.AmountPayable);

                ////string TotalAmtQuery = "Select sum(PaidAmount)'TotalReceived' from irm_InvestorPaymentReceipt where InvestorID like '" + ddlInvestor.SelectedValue.ToString() + "' and PaymentScheduleID like '" + ddlRoomName.SelectedValue + "' And BookID = '" + ddlRoomName.SelectedValue.ToString() + "' And IsActive = 1 group by PaymentScheduleID";
                ////DataSet dsnew = InvestorPaymentReceiptBLL.GetTotalAmount(TotalAmtQuery);
                ////if (dsnew.Tables[0].Rows.Count != 0)
                ////    hdnTotal.Value = Convert.ToString(dsnew.Tables[0].Rows[0]["TotalReceived"]);
                ////else
                ////    hdnTotal.Value = "";

                txtPaidAmount.Text = Convert.ToString(GetData.PaidAmount.Value);

                ////if (lblTotalSlabAmount.Text.Trim() != string.Empty && lblPaidAmount.Text.Trim() != string.Empty)
                ////{
                ////    double balanceamount = Convert.ToDouble(lblTotalSlabAmount.Text.Trim()) - Convert.ToDouble(lblPaidAmount.Text.Trim());
                ////    lblDisplayBalanceAmount.Text = Convert.ToString(balanceamount);
                ////}
                ////else
                ////    lblDisplayBalanceAmount.Text = "0.0";

                DateTime dtDateToPay = Convert.ToDateTime(GetData.DateToPay);
                txtDate.Text = Convert.ToString(dtDateToPay.ToString(this.DateFormat));

                ddlModeOfPayment.SelectedIndex = ddlModeOfPayment.Items.FindByValue(Convert.ToString(GetData.ModeOfPaymentTermID)) != null ? ddlModeOfPayment.Items.IndexOf(ddlModeOfPayment.Items.FindByValue(Convert.ToString(GetData.ModeOfPaymentTermID))) : 0;

                //if (ddlModeOfPayment.SelectedValue.ToUpper().Equals("C86F49A9-16AA-4EAB-B352-C9400C32AA3D"))
                //    rvftxtBankName.Enabled = false;
                //else
                //    rvftxtBankName.Enabled = true;

                txtBankName.Text = Convert.ToString(GetData.BankName);
                txtChecqueNo.Text = Convert.ToString(GetData.PayRefNo);

                //if (Convert.ToString(GetData.ReconciledOn) != "")
                //{
                //    chkIsReconciled.Checked = true;
                //    imgRegiDate.Enabled = true;
                //    txtReconciledOn.Text = GetData.ReconciledOn.Value.ToString(this.DateFormat);
                //}
                //else
                //{
                //    chkIsReconciled.Checked = false;
                //    imgRegiDate.Enabled = false;
                //    txtReconciledOn.Text = "";
                //}
                //txtDepostiToBank.Text = GetData.DepositToBank;

                List<Documents> Lst = DocumentsBLL.GetAllBy(Documents.DocumentsFields.AssociationID, GetData.InvestorPaymentReceiptID.ToString());
                if (Lst.Count > 0)
                {
                    string str = "~/Document/" + Lst[0].DocumentName;
                    aLicenseNo.Visible = true;
                    aLicenseNo.HRef = str;
                    //imgDelete.Visible = true;
                    imgDelete.CommandArgument = Convert.ToString(Lst[0].DocumentID);
                    if (Convert.ToBoolean(ViewState["Edit"]))
                        imgDelete.Visible = true;
                    else
                        imgDelete.Visible = false;
                }
                else
                {
                    aLicenseNo.Visible = false;
                    imgDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        ////private void BindPyamentSchedule()
        ////{
        ////    txtPaidAmount.Text = "";
        ////    ddlPaymentSchedule.Items.Clear();
        ////    //string TotalAmtQuery = "Select irm_InvestorPaymentSchedule.* from irm_InvestorPaymentSchedule inner join irm_InvestorsUnit on irm_InvestorsUnit.InvestorRoomID like irm_InvestorPaymentSchedule.InvestorRoomID where AmountPayable > TotalReceived and irm_InvestorPaymentSchedule.InvestorID like '" + ddlInvestor.SelectedValue.ToString() + "' and irm_InvestorsUnit.RoomID like '" + ddlRoomName.SelectedValue.ToString() + "' And irm_InvestorPaymentSchedule.IsActive = 1";
        ////    //string TotalAmtQuery = "Select * from irm_InvestorPaymentSchedule where AmountPayable > TotalReceived and irm_InvestorPaymentSchedule.InvestorID like '" + ddlInvestor.SelectedValue.ToString() + "' and irm_InvestorPaymentSchedule.InvestorRoomID like '" + ddlRoomName.SelectedValue + "' And irm_InvestorPaymentSchedule.IsActive = 1";
        ////    string TotalAmtQuery = "Select * from irm_InvestorPaymentSchedule where irm_InvestorPaymentSchedule.InvestorID like '" + ddlInvestor.SelectedValue.ToString() + "' and irm_InvestorPaymentSchedule.InvestorRoomID like '" + ddlRoomName.SelectedValue + "' And irm_InvestorPaymentSchedule.IsActive = 1";
        ////    DataSet ds = InvestorPaymentReceiptBLL.GetTotalAmount(TotalAmtQuery);
        ////    if (ds.Tables[0].Rows.Count != 0)
        ////    {
        ////        DataView dvPayment = new DataView(ds.Tables[0]);
        ////        dvPayment.Sort = "ProjectMilestone";
        ////        ddlPaymentSchedule.DataSource = dvPayment;
        ////        ddlPaymentSchedule.DataTextField = "ProjectMilestone";
        ////        ddlPaymentSchedule.DataValueField = "PaymentScheduleID";
        ////        ddlPaymentSchedule.DataBind();
        ////        ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////    }
        ////    else
        ////        ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////}

        /// <summary>
        /// Bind Property
        /// </summary>
        private void BindProperty()
        {
            ddlPropertyName.Items.Clear();

            if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
            {
                DataSet dsProperty = SQT.Symphony.BusinessLogic.IRMS.BLL.InvestorsUnitBLL.SelectPropertyName(new Guid(Convert.ToString(ddlInvestor.SelectedValue)), this.CompanyID);

                if (dsProperty.Tables[0].Rows.Count != 0)
                {
                    ddlPropertyName.DataSource = dsProperty.Tables[0];
                    ddlPropertyName.DataTextField = "PropertyName";
                    ddlPropertyName.DataValueField = "PropertyID";
                    ddlPropertyName.DataBind();
                    ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    if (Request.QueryString["PRID"] != null)
                        ddlPropertyName.SelectedValue = Convert.ToString(Request.QueryString["PRID"]);
                }
                else
                    ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        ////private void LoadInvestorUnit()
        ////{
        ////    try
        ////    {
        ////        lblPaidAmount.Text = lblTotalSlabAmount.Text = lblDisplayBalanceAmount.Text = "0.0";
        ////        txtPaidAmount.Text = "";
        ////        //btnSave.Visible = true;
        ////        if (ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()))
        ////        {
        ////            ddlRoomName.Items.Clear();
        ////            ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        ////            DataSet dsPaymentSchedule = PaymentScheduleBLL.SearchPaymentScheduleData(null, null, this.CompanyID, null, null, null, null, null);
        ////            if (dsPaymentSchedule.Tables[0].Rows.Count > 0)
        ////            {
        ////                ddlPaymentSchedule.DataSource = dsPaymentSchedule;
        ////                ddlPaymentSchedule.DataTextField = "ProjectMilestone";
        ////                ddlPaymentSchedule.DataValueField = "PaymentScheduleID";
        ////                ddlPaymentSchedule.DataBind();
        ////                ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////            }
        ////            else
        ////                ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////        }
        ////        else if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()) && !ddlPropertyName.SelectedValue.Equals(Guid.Empty.ToString()))
        ////        {
        ////            ddlRoomName.Items.Clear();

        ////            DataSet ds = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, new Guid(ddlInvestor.SelectedValue), new Guid(ddlPropertyName.SelectedValue), null, null);
        ////            ddlRoomName.DataSource = ds;
        ////            ddlRoomName.DataTextField = "RoomNo";
        ////            ddlRoomName.DataValueField = "InvestorRoomID";
        ////            ddlRoomName.DataBind();
        ////            ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////            //if (Request.QueryString["InvRm"] != null)
        ////            //{
        ////            if (Session["InvRm"] != null)
        ////                ddlRoomName.SelectedValue = Convert.ToString(Session["InvRm"]);
        ////            //}

        ////            ddlPaymentSchedule.Items.Clear();
        ////            DataSet dsPaymentSchedule = PaymentScheduleBLL.SearchPaymentScheduleData(null, null, this.CompanyID, new Guid(ddlInvestor.SelectedValue), new Guid(ddlRoomName.SelectedValue), null, false, null);
        ////            if (dsPaymentSchedule.Tables[0].Rows.Count > 0)
        ////            {
        ////                ddlPaymentSchedule.DataSource = dsPaymentSchedule;
        ////                ddlPaymentSchedule.DataTextField = "ProjectMilestone";
        ////                ddlPaymentSchedule.DataValueField = "PaymentScheduleID";
        ////                ddlPaymentSchedule.DataBind();
        ////                ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////            }
        ////            else
        ////                ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        ////            //ddlPaymentSchedule.SelectedValue = Guid.Empty.ToString();
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        ////        MessageBox.Show(ex.Message.ToString());
        ////    }
        ////}

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ClearControlValue();
        //    LoadAccess();
        //}

        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                //if (txtPaidAmount.Text.Trim() != string.Empty && Convert.ToDouble(txtPaidAmount.Text.Trim()) == Convert.ToDouble(0))
                //{
                //    //MessageBox.Show("Invalid paid amount.");
                //    lblPaidAmountErrorMessage.Text = "Invalid Received Amount.";
                //    return;
                //}
                //else
                //    lblPaidAmountErrorMessage.Text = "";

                if (this.InvestorPaymentReceiptID != Guid.Empty)
                {
                    //Update PaymentReceipt 

                    InvestorPaymentReceipt objPaymentReceipt = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);
                    InvestorPaymentReceipt objOldPaymentReceipt = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);

                    objPaymentReceipt.InvestorID = new Guid(Convert.ToString(ddlInvestor.SelectedValue));

                    ////objPaymentReceipt.PaymentScheduleID = new Guid(Convert.ToString(ddlPaymentSchedule.SelectedValue));
                    ////objPaymentReceipt.UnitID = new Guid(Convert.ToString(ddlRoomName.SelectedValue));

                    objPaymentReceipt.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text.Trim());
                    objPaymentReceipt.DateToPay = DateTime.ParseExact(txtDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    objPaymentReceipt.ReceiptNo = txtReceiptNo.Text;

                    objPaymentReceipt.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                    if (ddlModeOfPayment.SelectedValue != Guid.Empty.ToString())
                        objPaymentReceipt.ModeOfPaymentTermID = new Guid(Convert.ToString(ddlModeOfPayment.SelectedValue));
                    else
                        objPaymentReceipt.ModeOfPaymentTermID = null;

                    objPaymentReceipt.BankName = Convert.ToString(txtBankName.Text.Trim());
                    objPaymentReceipt.PayRefNo = Convert.ToString(txtChecqueNo.Text.Trim());

                    //objPaymentReceipt.PayRefNo = txtBankReceiptNo.Text;
                    //objPaymentReceipt.IsReconciled = chkIsReconciled.Checked;
                    //if (chkIsReconciled.Checked)
                    //{
                    //    if (!txtReconciledOn.Text.Equals(""))
                    //    {
                    //        objPaymentReceipt.ReconciledOn = DateTime.ParseExact(txtReconciledOn.Text.Trim(), this.DateFormat, objCultureInfo);
                    //    }

                    //}
                    //else
                    //    objPaymentReceipt.ReconciledOn = null;
                    //objPaymentReceipt.DepositToBank = txtDepostiToBank.Text.Trim();
                    objPaymentReceipt.UpdatedOn = System.DateTime.Now.Date;
                    objPaymentReceipt.IsActive = true;
                    objPaymentReceipt.CompanyID = this.CompanyID;
                    objPaymentReceipt.ReceiptType_TermID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["ReceiptTypeTermIDRoom"].ToString());
                    objPaymentReceipt.CreatedBy = new Guid(Convert.ToString(Session["UserTypeID"]));
                    if (fuLicenseNo.FileName != "")
                    {
                        List<Documents> Lst = DocumentsBLL.GetAllBy(Documents.DocumentsFields.AssociationID, objPaymentReceipt.InvestorPaymentReceiptID.ToString());
                        if (Lst.Count > 0)
                            DocumentsBLL.Delete(Lst[0].DocumentID);

                        string FileConstructionAgreement = "PaymentReceipt$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuLicenseNo.FileName.Replace(" ", "_");
                        string path1 = Server.MapPath("~/Document/" + FileConstructionAgreement);
                        fuLicenseNo.SaveAs(path1);
                        Documents d1 = new Documents();
                        d1.DocumentName = FileConstructionAgreement;
                        d1.Extension = System.IO.Path.GetExtension(fuLicenseNo.FileName);
                        d1.DateOfSubmission = DateTime.Now;
                        d1.CreatedOn = DateTime.Now;
                        d1.IsActive = true;
                        d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                       
                        ProjectTerm objProjectTerm = new ProjectTerm();
                        objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid("823A63BC-0923-4EE5-95F3-5E161F886603"));
                        d1.TypeID = new Guid("823A63BC-0923-4EE5-95F3-5E161F886603");
                        if(objProjectTerm != null)
                            d1.AssociationType = Convert.ToString(objProjectTerm.Term);
                        else
                            d1.AssociationType = "Receipt";

                        d1.AssociationID = objPaymentReceipt.InvestorPaymentReceiptID;
                        d1.IsSynch = false;
                        d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                        d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        DocumentsBLL.Save(d1);
                    }

                    InvestorPaymentReceiptBLL.Update(objPaymentReceipt);
                    this.InvestorPaymentReceiptID = objPaymentReceipt.InvestorPaymentReceiptID;

                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPaymentReceipt.ToString(), objPaymentReceipt.ToString(), "irm_InvestorPaymentReceipt");
                    IsInsert = true;
                    lblPaymentReceiptMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    ViewState["EmployeeID"] = null;
                }
                else
                {
                    //Insert PaymentReceipt

                    InvestorPaymentReceipt objPaymentReceipt = new InvestorPaymentReceipt();
                    //objPaymentReceipt.InvestorPaymentReceiptID = Guid.NewGuid();
                    objPaymentReceipt.InvestorID = new Guid(Convert.ToString(ddlInvestor.SelectedValue));

                    ////objPaymentReceipt.PaymentScheduleID = new Guid(Convert.ToString(ddlPaymentSchedule.SelectedValue));
                    ////objPaymentReceipt.UnitID = new Guid(Convert.ToString(ddlRoomName.SelectedValue));

                    objPaymentReceipt.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text.Trim());
                    objPaymentReceipt.DateToPay = DateTime.ParseExact(txtDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    objPaymentReceipt.ReceiptNo = txtReceiptNo.Text.Trim();
                    objPaymentReceipt.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                    if (ddlModeOfPayment.SelectedValue != Guid.Empty.ToString())
                        objPaymentReceipt.ModeOfPaymentTermID = new Guid(Convert.ToString(ddlModeOfPayment.SelectedValue));

                    objPaymentReceipt.BankName = Convert.ToString(txtBankName.Text.Trim());
                    objPaymentReceipt.PayRefNo = Convert.ToString(txtChecqueNo.Text.Trim());

                    //objPaymentReceipt.PayRefNo = txtBankReceiptNo.Text;
                    //objPaymentReceipt.IsReconciled = chkIsReconciled.Checked;
                    //if (chkIsReconciled.Checked)
                    //{
                    //    if (!txtReconciledOn.Text.Equals(""))
                    //        objPaymentReceipt.ReconciledOn = DateTime.ParseExact(txtReconciledOn.Text.Trim(), this.DateFormat, objCultureInfo);
                    //}
                    //else
                    //    objPaymentReceipt.ReconciledOn = null;
                    //objPaymentReceipt.DepositToBank = txtDepostiToBank.Text.Trim();
                    objPaymentReceipt.CreatedOn = System.DateTime.Now.Date;
                    objPaymentReceipt.IsActive = true;
                    objPaymentReceipt.CompanyID = this.CompanyID;
                    objPaymentReceipt.ReceiptType_TermID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["ReceiptTypeTermIDRoom"].ToString());
                    objPaymentReceipt.CreatedBy = new Guid(Convert.ToString(Session["UserTypeID"]));
                    string path1 = string.Empty;

                    objPaymentReceipt.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text.Trim());


                    InvestorPaymentReceiptBLL.Save(objPaymentReceipt);
                    this.InvestorPaymentReceiptID = objPaymentReceipt.InvestorPaymentReceiptID;
                    Documents d1 = new Documents();
                    if (fuLicenseNo.FileName != "")
                    {
                        string FileConstructionAgreement = "PaymentReceipt$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuLicenseNo.FileName.Replace(" ", "_");
                        path1 = Server.MapPath("~/Document/" + FileConstructionAgreement);
                        fuLicenseNo.SaveAs(path1);
                        d1.DocumentName = FileConstructionAgreement;
                        d1.Extension = System.IO.Path.GetExtension(fuLicenseNo.FileName);
                        d1.DateOfSubmission = DateTime.Now;
                        d1.CreatedOn = DateTime.Now;
                        d1.IsActive = true;
                        d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        
                        ProjectTerm objProjectTerm = new ProjectTerm();
                        objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid("823A63BC-0923-4EE5-95F3-5E161F886603"));
                        d1.TypeID = new Guid("823A63BC-0923-4EE5-95F3-5E161F886603");
                        if (objProjectTerm != null)
                            d1.AssociationType = Convert.ToString(objProjectTerm.Term);
                        else
                            d1.AssociationType = "Receipt";    
                    
                        d1.IsSynch = false;
                        d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                        d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        d1.AssociationID = objPaymentReceipt.InvestorPaymentReceiptID;
                        DocumentsBLL.Save(d1);
                    }

                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objPaymentReceipt.ToString(), objPaymentReceipt.ToString(), "irm_InvestorPaymentReceipt");
                    IsInsert = true;
                    lblPaymentReceiptMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();

                    string PAYMENTMODERELATEDNO = "-";
                    if (txtChecqueNo.Text.Trim() != "")
                        PAYMENTMODERELATEDNO = Convert.ToString(txtChecqueNo.Text.Trim());

                    string BANKNAME = "-";
                    if (txtBankName.Text.Trim() != "")
                        BANKNAME = Convert.ToString(txtBankName.Text.Trim());


                    //string strMail = "This is to confirm that we have received Rs. " + Convert.ToString(txtPaidAmount.Text.Trim()) + " vide " + Convert.ToString(ddlModeOfPayment.SelectedItem.Text) + " " + PAYMENTMODERELATEDNO + " of " +BANKNAME+ " bank against " + Convert.ToString(ddlPropertyName.SelectedItem.Text) + ".";

                    //Send notification mail.
                    //if (File.Exists(Server.MapPath("~/EmailTemplates/InvestorPaymentReceipt.htm")))
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Payment Receipt");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        Investor objInvestor = InvestorBLL.GetByPrimaryKey(new Guid(ddlInvestor.SelectedValue.ToString()));

                        //List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, Convert.ToString(Session["CompanyID"]));
                        if (Session["PropertyConfigurationInfo"] != null)
                        {
                            if (objInvestor.EMail != string.Empty)
                            {
                                PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                                string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/InvestorPaymentReceipt.htm"));
                                strHTML = strHTML.Replace("$FULLNAME$", Convert.ToString(objInvestor.FName + objInvestor.LName));
                                strHTML = strHTML.Replace("$PAIDAMOUNT$", Convert.ToString(txtPaidAmount.Text.Trim()));
                                strHTML = strHTML.Replace("$MODEOFPAYMENT$", Convert.ToString(ddlModeOfPayment.SelectedItem.Text));
                                strHTML = strHTML.Replace("$PAYMENTMODERELATEDNO$", Convert.ToString(PAYMENTMODERELATEDNO));
                                strHTML = strHTML.Replace("$BANKNAME$", Convert.ToString(BANKNAME));
                                strHTML = strHTML.Replace("$PROPERTYNAME$", Convert.ToString(ddlPropertyName.SelectedItem.Text));
                                strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));

                                //Don't send email until give instruction from uniworld investor team.
                                ////SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), objInvestor.EMail, "Payment Receipt", strHTML, path1);
                            }
                            else
                                MessageBox.Show("No email found for selected investor to send mail.");
                        }
                    }
                    else
                        MessageBox.Show("System can't send mail to your email, Sorry for inconvenience.");
                }
                LoadPaymentReceiptData();
                BindGrid();
            }
        }

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
            //ClearControlValue();
        }

        protected void imgDelete_OnClick(object sender, ImageClickEventArgs e)
        {
            string str = Convert.ToString(imgDelete.CommandArgument);
            DocumentsBLL.Delete(new Guid(Convert.ToString(str)));
            imgDelete.Visible = false;
            aLicenseNo.Visible = false;
            IsInsert = true;
            lblPaymentReceiptMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();

        }
        #endregion Button Event

        #region Popup Button
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            if (this.InvestorPaymentReceiptID != Guid.Empty)
            {
                InvestorPaymentReceipt GetData = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);
                InvestorPaymentReceiptBLL.Delete(this.InvestorPaymentReceiptID);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetData.ToString(), null, "irm_InvestorPaymentReceipt");
                IsInsert = true;
                this.InvestorPaymentReceiptID = Guid.Empty;
                lblPaymentReceiptMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                ClearControlValue();
                BindGrid();
            }
            msgbx.Hide();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            this.InvestorPaymentReceiptID = Guid.Empty;
            msgbx.Hide();
        }
        #endregion Popup Button

        #region Grid Event
        protected void grdInvRecptList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITCMD"))
            {
                this.InvestorPaymentReceiptID = new Guid(Convert.ToString(e.CommandArgument));
                //LoadAccess();
                LoadPaymentReceiptData();
            }
            else if (e.CommandName.Equals("DELETECMD"))
            {
                lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                this.InvestorPaymentReceiptID = new Guid(Convert.ToString(e.CommandArgument));
                msgbx.Show();
            }
        }

        protected void grdInvRecptList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);


                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";

            }
        }

        #endregion Grid Event

        #region DropDown Event

        //protected void ddlModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlModeOfPayment.SelectedValue.ToUpper().Equals("C86F49A9-16AA-4EAB-B352-C9400C32AA3D"))
        //    {
        //        //Visible False
        //        rvftxtBankName.Enabled = false;
        //    }
        //    else
        //    {
        //        //Visible True
        //        rvftxtBankName.Enabled = true;
        //    }
        //}

        ////protected void ddlPaymentSchedule_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    //btnSave.Visible = true;
        ////    if (!ddlPaymentSchedule.SelectedValue.Equals(Guid.Empty.ToString()))
        ////    {
        ////        hdnPaymentSlab.Value = "";
        ////        //txtBankReceiptNo.Text = "";
        ////        //txtDepostiToBank.Text = "";
        ////        //chkIsReconciled.Checked = false;
        ////        //txtBankName.Text = "";
        ////        // LoadPaymentMode();
        ////        txtPaidAmount.Text = "";
        ////        hdnTotal.Value = "";
        ////        lblTotalSlabAmount.Text = "0.0";
        ////        PaymentSchedule objPS = PaymentScheduleBLL.GetByPrimaryKey(new Guid(Convert.ToString(ddlPaymentSchedule.SelectedValue)));
        ////        double dblTotalReceived = 0;
        ////        double dblAmountPayable = 0;
        ////        if (Convert.ToString(objPS.AmountPayable) != "")
        ////            dblAmountPayable = Convert.ToDouble(objPS.AmountPayable);
        ////        if (Convert.ToString(objPS.TotalReceived) != "")
        ////            dblTotalReceived = Convert.ToDouble(objPS.TotalReceived);
        ////        txtPaidAmount.Text = lblDisplayBalanceAmount.Text = Convert.ToString(dblAmountPayable - dblTotalReceived);
        ////        lblTotalSlabAmount.Text = Convert.ToString(objPS.AmountPayable);
        ////        rvAmt.MinimumValue = "0";
        ////        rvAmt.MaximumValue = Convert.ToString(dblAmountPayable - dblTotalReceived);
        ////        hdnPaymentSlab.Value = Convert.ToString(dblAmountPayable);
        ////        lblPaidAmount.Text = Convert.ToString(dblTotalReceived);
        ////    }
        ////    else
        ////    {
        ////        //txtBankReceiptNo.Text = "";
        ////        //txtDepostiToBank.Text = "";
        ////        //chkIsReconciled.Checked = false;
        ////        //txtBankName.Text = "";
        ////        //LoadPaymentMode();
        ////        txtPaidAmount.Text = hdnPaymentSlab.Value = "";
        ////        lblPaidAmount.Text = lblTotalSlabAmount.Text = lblDisplayBalanceAmount.Text = "0.0";
        ////    }
        ////}

        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////ddlPropertyName.SelectedIndex = 0;
            ////ddlRoomName.Items.Clear();
            ////ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ////ddlPaymentSchedule.Items.Clear();
            ////ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ////lblPaidAmount.Text = lblTotalSlabAmount.Text = lblDisplayBalanceAmount.Text = "0.0";

            BindProperty();
            txtPaidAmount.Text = "";
        }

        ////protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    ddlRoomName.Items.Clear();
        ////    ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////    ddlPaymentSchedule.Items.Clear();
        ////    ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////    LoadInvestorUnit();
        ////}

        ////protected void ddlRoomName_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    //btnSave.Visible = true;
        ////    ddlPaymentSchedule.Items.Clear();
        ////    lblPaidAmount.Text = lblTotalSlabAmount.Text = lblDisplayBalanceAmount.Text = "0.0";
        ////    if (ddlRoomName.SelectedValue != Guid.Empty.ToString())
        ////    {
        ////        BindPyamentSchedule();
        ////        txtPaidAmount.Text = "";
        ////    }
        ////    else
        ////    {
        ////        ddlPaymentSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        ////        txtPaidAmount.Text = "";
        ////    }
        ////}

        #endregion DropDown Event
    }
}