using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlPropertyInsurance : System.Web.UI.UserControl
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
            if (RoleRightJoinBLL.GetAccessString("PropertyInsuranceReceipt.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            lblPaidAmountErrorMessage.Text = "";

            if (!IsPostBack)
            {
                LoadDefaultData();
                calExtDateTo.Format = calDateFrom.Format = this.DateFormat;
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("PropertyInsuranceReceipt.aspx", new Guid(Convert.ToString(Session["UserID"])));
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
        /// <summary>
        /// Load Property Tax Receipt Data
        /// </summary>
        private void LoadPaymentReceiptData()
        {
            InvestorPaymentReceipt GetData = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);

            ddlInvestor.SelectedIndex = ddlInvestor.Items.FindByValue(Convert.ToString(GetData.InvestorID)) != null ? ddlInvestor.Items.IndexOf(ddlInvestor.Items.FindByValue(Convert.ToString(GetData.InvestorID))) : 0;

            if (Convert.ToString(GetData.UnitID) != "" && Convert.ToString(GetData.UnitID) != null)
            {
                DataSet dsLoadProperty = InvestorPaymentReceiptBLL.SelectInvestorPropertyName(GetData.UnitID);
                if (dsLoadProperty != null && dsLoadProperty.Tables[0].Rows.Count > 0)
                    ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(dsLoadProperty.Tables[0].Rows[0]["PropertyID"])) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(dsLoadProperty.Tables[0].Rows[0]["PropertyID"]))) : 0;
                else
                    ddlPropertyName.SelectedIndex = 0;
            }
            else
                ddlPropertyName.SelectedIndex = 0;

            LoadUnitInformation();

            ddlRoomName.SelectedIndex = ddlRoomName.Items.FindByValue(Convert.ToString(GetData.UnitID)) != null ? ddlRoomName.Items.IndexOf(ddlRoomName.Items.FindByValue(Convert.ToString(GetData.UnitID))) : 0;

            txtPaidAmount.Text = Convert.ToString(GetData.PaidAmount);

            ddlModeOfPayment.SelectedIndex = ddlModeOfPayment.Items.FindByValue(Convert.ToString(GetData.ModeOfPaymentTermID)) != null ? ddlModeOfPayment.Items.IndexOf(ddlModeOfPayment.Items.FindByValue(Convert.ToString(GetData.ModeOfPaymentTermID))) : 0;
            //ddlModeOfPayment_SelectedIndexChanged(null, null);
            txtBankName.Text = GetData.BankName == null ? "" : GetData.BankName;
            txtVendorName.Text = GetData.InsuranceVendor == null ? "" : GetData.InsuranceVendor;

            txtPaymentRefNo.Text = GetData.PayRefNo == null ? "" : GetData.PayRefNo;
            txtChqTranNo.Text = GetData.RefPayReceiptNo == null ? "" : GetData.RefPayReceiptNo;

            //Load From Date
            ddlDate.SelectedValue = GetData.FromDate == null ? Guid.Empty.ToString() : GetData.FromDate.Value.Day.ToString().Length == 2 ? GetData.FromDate.Value.Day.ToString() : "0" + GetData.FromDate.Value.Day.ToString();
            ddlMonth.SelectedValue = GetData.FromDate == null ? Guid.Empty.ToString() : GetData.FromDate.Value.Month.ToString();
            ddlYear.SelectedValue = GetData.FromDate == null ? Guid.Empty.ToString() : GetData.FromDate.Value.Year.ToString();


            //Load To Date
            ddlToDate.SelectedValue = GetData.ToDate == null ? Guid.Empty.ToString() : GetData.ToDate.Value.Day.ToString().Length == 2 ? GetData.ToDate.Value.Day.ToString() : "0" + GetData.ToDate.Value.Day.ToString();
            ddlToMonth.SelectedValue = GetData.ToDate == null ? Guid.Empty.ToString() : GetData.ToDate.Value.Month.ToString();
            ddlToYear.SelectedValue = GetData.ToDate == null ? Guid.Empty.ToString() : GetData.ToDate.Value.Year.ToString();


            txtDepostiToBank.Text = GetData.DepositToBank == null ? "" : GetData.DepositToBank;
            txtNotes.Text = GetData.Note == null ? "" : GetData.Note;

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
        /// <summary>
        /// Load Default Data Here
        /// </summary>
        private void LoadDefaultData()
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
                        {
                            this.DateFormat = objProjectTerm.Term;
                        }
                        else
                        {
                            this.DateFormat = "dd/MM/yyyy";
                        }
                    }
                    else
                    {
                        this.DateFormat = "dd/MM/yyyy";
                    }

                    ClearControlValue();
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
            LoadInvestor();
            BindProperty();
            ddlInvestor.SelectedValue = Guid.Empty.ToString();
            LoadUnitInformation();
            ddlRoomName.SelectedValue = Guid.Empty.ToString();
            LoadModeOfPayment();
            ddlModeOfPayment.SelectedValue = Guid.Empty.ToString();
            // txtBankName.Enabled = false;
            // txtChqTranNo.Enabled = false;
            //rvftxtBankName.Enabled = false;
            //rvftxtChqTranNo.Enabled = false;
            aLicenseNo.Visible = false;
            imgDelete.Visible = false;
            txtVendorName.Text = "";
            txtBankName.Text = "";
            txtChqTranNo.Text = "";
            txtDepostiToBank.Text = "";
            txtNotes.Text = "";
            txtPaidAmount.Text = "";
            txtPaymentRefNo.Text = "";
            txtSInvestorName.Text = "";
            lblPaidAmountErrorMessage.Text = "";
            LoadFinancialYearDate();
            ddlInvestor.Focus();
            BindGrid();
            this.InvestorPaymentReceiptID = Guid.Empty;
            ddlDate.SelectedValue = Guid.Empty.ToString();
            ddlMonth.SelectedValue = Guid.Empty.ToString();
            ddlYear.SelectedValue = Guid.Empty.ToString();
            ddlToDate.SelectedValue = Guid.Empty.ToString();
            ddlToYear.SelectedValue = Guid.Empty.ToString();
            ddlToMonth.SelectedValue = Guid.Empty.ToString();
            FromValidDate.Visible = ToValidDate.Visible = false;
        }
        /// <summary>
        /// Load Financial Year
        /// </summary>
        private void LoadFinancialYearDate()
        {
            ddlDate.Items.Clear();
            ddlYear.Items.Clear();
            ddlToDate.Items.Clear();
            ddlToYear.Items.Clear();
            //Load Date Based On Month
            ddlDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
            }

            //Load To Date
            ddlToDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int k = 1; k < 32; k++)
            {
                if (k < 10)
                {
                    ddlToDate.Items.Insert(k, new ListItem(k.ToString(), "0" + k.ToString()));
                }
                else
                {
                    ddlToDate.Items.Insert(k, new ListItem(k.ToString(), k.ToString()));
                }
            }

            //Load Year
            int j = 1;
            ddlYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = Convert.ToInt32(DateTime.Now.Year) + 15; i >= 1970; i--)
            {
                ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                j++;
            }

            int l = 1;
            ddlToYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = Convert.ToInt32(DateTime.Now.Year) + 15; i >= 1970; i--)
            {
                ddlToYear.Items.Insert(l, new ListItem(i.ToString(), i.ToString()));
                l++;
            }

        }
        /// <summary>
        /// Mode Of Payment
        /// </summary>
        private void LoadModeOfPayment()
        {
            ddlModeOfPayment.Items.Clear();
            ProjectTerm PaymentMode = new ProjectTerm();
            PaymentMode.Category = "PAYMENTMODE";
            PaymentMode.IsActive = true;
            List<ProjectTerm> PayLst = ProjectTermBLL.GetAll(PaymentMode);
            if (PayLst.Count > 0)
            {
                ddlModeOfPayment.DataSource = PayLst;
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
            ddlInvestor.Items.Clear();
            Guid? CreatedBy = null;
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN")
                CreatedBy = null;
            else
                CreatedBy = new Guid(Convert.ToString(Session["UserTypeID"]));


            DataSet ds = InvestorBLL.SearchInfo(null, null, null, null, null, this.CompanyID, CreatedBy, null);
            DataView Dv = new DataView(ds.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlInvestor.DataSource = Dv;
                ddlInvestor.DataTextField = "FullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Load User Information Related Investor
        /// </summary>
        private void LoadUnitInformation()
        {
            ddlRoomName.Items.Clear();
            if (!ddlInvestor.SelectedValue.Equals(Guid.Empty.ToString()) && !ddlPropertyName.SelectedValue.Equals(Guid.Empty.ToString()))
            {
                DataSet Dst = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, new Guid(ddlInvestor.SelectedValue), new Guid(ddlPropertyName.SelectedValue), null, null);
                if (Dst.Tables[0].Rows.Count > 0)
                {
                    ddlRoomName.DataSource = Dst;
                    ddlRoomName.DataTextField = "RoomNo";
                    ddlRoomName.DataValueField = "InvestorRoomID";
                    ddlRoomName.DataBind();
                    ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            string fullName = null;
            DateTime? dateFrom = null, dateTo = null;

            Guid? CreatedBy = null;
            if (!txtSInvestorName.Text.Equals(""))
                fullName = txtSInvestorName.Text.Trim();
            string UserType = Convert.ToString(Session["UserType"]);
            if (UserType.ToUpper() == "ADMIN")
                CreatedBy = null;
            else
                CreatedBy = new Guid(Convert.ToString(Session["UserTypeID"]));

            if (txtDateFrom.Text.Trim() != string.Empty)
                dateFrom = DateTime.ParseExact(txtDateFrom.Text.Trim(), this.DateFormat, objCultureInfo);

            if (txtDateTo.Text.Trim() != string.Empty)
                dateTo = DateTime.ParseExact(txtDateTo.Text.Trim(), this.DateFormat, objCultureInfo);

            DataSet ds = InvestorPaymentReceiptBLL.SelectAllWithSearchDataSetForTax(null, null, fullName, this.CompanyID, new Guid(System.Configuration.ConfigurationSettings.AppSettings["InsurnaceTypeTermID"].ToString()), CreatedBy, null, null, dateFrom, dateTo);
            grdInsurnaceList.DataSource = ds;
            grdInsurnaceList.DataBind();
        }

        /// <summary>
        /// Bind Property
        /// </summary>
        private void BindProperty()
        {
            DataSet ds = PropertyBLL.SelectData(this.CompanyID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlPropertyName.DataSource = dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add New Insurance Receipt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string FromDate = Convert.ToString(ddlDate.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                    string ToDate = Convert.ToString(ddlToDate.SelectedValue.ToString().Trim() + "-" + ddlToMonth.SelectedItem.Text.Trim() + "-" + ddlToYear.SelectedValue.ToString().Trim());
                    try
                    {
                        FromValidDate.Visible = false;
                        DateTime FrmDate = Convert.ToDateTime(FromDate);
                    }
                    catch
                    {
                        litFromValidDate.Text = "Enter Valid From Date";
                        FromValidDate.Visible = true;
                        return;
                    }

                    try
                    {
                        ToValidDate.Visible = false;
                        DateTime UpToDate = Convert.ToDateTime(ToDate);
                    }
                    catch
                    {
                        litToValidDate.Text = "Enter Valid To Date";
                        ToValidDate.Visible = true;
                        return;
                    }
                    if (Convert.ToDateTime(FromDate) >= Convert.ToDateTime(ToDate))
                    {
                        litToValidDate.Text = "From Date greate than To date";
                        ToValidDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ToValidDate.Visible = false;
                    }

                    if (txtPaidAmount.Text.Trim() != string.Empty && Convert.ToDouble(txtPaidAmount.Text.Trim()) == Convert.ToDouble(0))
                    {
                        lblPaidAmountErrorMessage.Text = "Invalid Premium Amount.";
                        return;
                    }
                    else
                        lblPaidAmountErrorMessage.Text = "";

                    if (this.InvestorPaymentReceiptID != Guid.Empty)
                    {
                        //Update
                        InvestorPaymentReceipt Updt = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);
                        InvestorPaymentReceipt OldUpdt = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);
                        Updt.InvestorID = new Guid(ddlInvestor.SelectedValue.ToString());
                        Updt.UnitID = new Guid(ddlRoomName.SelectedValue.ToString());
                        Updt.PaidAmount = txtPaidAmount.Text.Trim().Equals("") ? Convert.ToDecimal("0.00") : Convert.ToDecimal(txtPaidAmount.Text);
                        Updt.ModeOfPaymentTermID = ddlModeOfPayment.SelectedValue.Equals(Guid.Empty.ToString()) ? null : (Guid?)new Guid(ddlModeOfPayment.SelectedValue.ToString());
                        Updt.BankName = txtBankName.Text.Trim().Equals("") ? null : txtBankName.Text.Trim();


                        Updt.PayRefNo = txtPaymentRefNo.Text.Trim();
                        Updt.RefPayReceiptNo = txtChqTranNo.Text.Trim().Equals("") ? null : txtChqTranNo.Text.Trim();


                        Updt.DepositToBank = txtDepostiToBank.Text.Equals("") ? null : txtDepostiToBank.Text.Trim();
                        Updt.Note = txtNotes.Text;
                        Updt.CompanyID = this.CompanyID;
                        Updt.InsuranceVendor = txtVendorName.Text.Trim().Equals("") ? null : txtVendorName.Text.Trim();
                        Updt.IsActive = true;
                        Updt.ReceiptType_TermID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["InsurnaceTypeTermID"].ToString());
                        Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Updt.UpdatedOn = DateTime.Now.Date;
                        Updt.FromDate = Convert.ToDateTime(FromDate);
                        Updt.ToDate = Convert.ToDateTime(ToDate);
                        InvestorPaymentReceiptBLL.Update(Updt);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldUpdt.ToString(), Updt.ToString(), "irm_InvestorPaymentReceipt");
                        this.InvestorPaymentReceiptID = Updt.InvestorPaymentReceiptID;
                        IsInsert = true;
                        lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        if (fuLicenseNo.FileName != "")
                        {
                            List<Documents> Lst = DocumentsBLL.GetAllBy(Documents.DocumentsFields.AssociationID, Updt.InvestorPaymentReceiptID.ToString());
                            if (Lst.Count > 0)
                                DocumentsBLL.Delete(Lst[0].DocumentID);

                            string FileConstructionAgreement = "Insurance$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuLicenseNo.FileName.Replace(" ", "_");
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
                            objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid("DF3876FD-6AA1-45BD-A815-1A6F015A7E2D"));
                            d1.TypeID = new Guid("DF3876FD-6AA1-45BD-A815-1A6F015A7E2D");
                            if (objProjectTerm != null)
                                d1.AssociationType = Convert.ToString(objProjectTerm.Term);
                            else
                                d1.AssociationType = "Property Insurance";

                            d1.AssociationID = Updt.InvestorPaymentReceiptID;
                            d1.IsSynch = false;
                            d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            DocumentsBLL.Save(d1);
                        }
                    }
                    else
                    {
                        //Insert
                        InvestorPaymentReceipt Ins = new InvestorPaymentReceipt();
                        Ins.InvestorID = new Guid(ddlInvestor.SelectedValue.ToString());
                        Ins.UnitID = new Guid(ddlRoomName.SelectedValue.ToString());
                        Ins.PaidAmount = txtPaidAmount.Text.Trim().Equals("") ? Convert.ToDecimal("0.00") : Convert.ToDecimal(txtPaidAmount.Text);
                        Ins.ModeOfPaymentTermID = ddlModeOfPayment.SelectedValue.Equals(Guid.Empty.ToString()) ? null : (Guid?)new Guid(ddlModeOfPayment.SelectedValue.ToString());
                        Ins.BankName = txtBankName.Text.Trim().Equals("") ? null : txtBankName.Text.Trim();


                        Ins.PayRefNo = txtPaymentRefNo.Text.Trim();
                        Ins.RefPayReceiptNo = txtChqTranNo.Text.Trim().Equals("") ? null : txtChqTranNo.Text.Trim();


                        Ins.DepositToBank = txtDepostiToBank.Text.Equals("") ? null : txtDepostiToBank.Text.Trim();
                        Ins.Note = txtNotes.Text;
                        Ins.DateToPay = DateTime.Now.Date;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.IsActive = true;
                        Ins.InsuranceVendor = txtVendorName.Text.Trim().Equals("") ? null : txtVendorName.Text.Trim();
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.CompanyID = this.CompanyID;
                        Ins.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.UpdatedOn = DateTime.Now.Date;
                        Ins.FromDate = Convert.ToDateTime(FromDate);
                        Ins.ToDate = Convert.ToDateTime(ToDate);
                        Ins.ReceiptType_TermID = new Guid(System.Configuration.ConfigurationSettings.AppSettings["InsurnaceTypeTermID"].ToString());
                        InvestorPaymentReceiptBLL.Save(Ins);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "irm_InvestorPaymentReceipt");
                        IsInsert = true;
                        lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.InvestorPaymentReceiptID = Ins.InvestorPaymentReceiptID;
                        string path1 = string.Empty;
                        if (fuLicenseNo.FileName != "")
                        {
                            string FileConstructionAgreement = "Insurance$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuLicenseNo.FileName.Replace(" ", "_");
                            path1 = Server.MapPath("~/Document/" + FileConstructionAgreement);
                            fuLicenseNo.SaveAs(path1);
                            Documents d1 = new Documents();
                            d1.DocumentName = FileConstructionAgreement;
                            d1.Extension = System.IO.Path.GetExtension(fuLicenseNo.FileName);
                            d1.DateOfSubmission = DateTime.Now;
                            d1.CreatedOn = DateTime.Now;
                            d1.IsActive = true;
                            d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                            ProjectTerm objProjectTerm = new ProjectTerm();
                            objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid("DF3876FD-6AA1-45BD-A815-1A6F015A7E2D"));
                            d1.TypeID = new Guid("DF3876FD-6AA1-45BD-A815-1A6F015A7E2D");
                            if (objProjectTerm != null)
                                d1.AssociationType = Convert.ToString(objProjectTerm.Term);
                            else
                                d1.AssociationType = "Property Insurance";

                            d1.AssociationID = Ins.InvestorPaymentReceiptID;
                            d1.IsSynch = false;
                            d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            DocumentsBLL.Save(d1);
                        }

                        //////Send notification mail.
                        ////if (File.Exists(Server.MapPath("~/EmailTemplates/UnitPaymentReceipt.htm")))
                        ////{
                        ////    Investor objInvestor = InvestorBLL.GetByPrimaryKey(new Guid(ddlInvestor.SelectedValue.ToString()));

                        ////    //List<PropertyConfiguration> LstPrtConfig = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, Convert.ToString(Session["CompanyID"]));
                        ////    if (Session["PropertyConfigurationInfo"] != null)
                        ////    {
                        ////        if (objInvestor.EMail != string.Empty)
                        ////        {
                        ////            PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                        ////            string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/UnitInsuranceReceipt.htm"));
                        ////            strHTML = strHTML.Replace("$FULLNAME$", Convert.ToString(objInvestor.FName + objInvestor.LName));
                        ////            strHTML = strHTML.Replace("$UNITNO$", ddlRoomName.SelectedItem.Text);
                        ////            strHTML = strHTML.Replace("$TAXYEAR$", "From Date : " + FromDate.ToString() + " To Date : " + ToDate.ToString());
                        ////            strHTML = strHTML.Replace("$PAIDAMOUNT$", txtPaidAmount.Text.Trim());
                        ////            strHTML = strHTML.Replace("$PAYMENTMODE$", ddlModeOfPayment.SelectedItem.Text);
                        ////            strHTML = strHTML.Replace("$PAYMENTDATE$", DateTime.Today.ToString(this.DateFormat));
                        ////            strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        ////            SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), objInvestor.EMail, "mail notification of your insurance payment.", strHTML, path1);
                        ////        }
                        ////        else
                        ////            MessageBox.Show("No email found for selected investor to send mail.");
                        ////    }
                        ////}
                        ////else
                        ////    MessageBox.Show("System can't send mail to your email, Sorry for inconvenience.");
                    }
                    LoadPaymentReceiptData();
                    BindGrid();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void imgDelete_OnClick(object sender, ImageClickEventArgs e)
        {
            string str = Convert.ToString(imgDelete.CommandArgument);
            DocumentsBLL.Delete(new Guid(Convert.ToString(str)));
            imgDelete.Visible = false;
            aLicenseNo.Visible = false;
            IsInsert = true;
            lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();

        }
        #endregion Button Event

        #region DropDown Event
        /// <summary>
        /// Investor DropDown List Selection Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPropertyName.SelectedIndex = 0;
            ddlRoomName.Items.Clear();
            ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            //LoadUnitInformation();
        }

        protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUnitInformation();
        }

        protected void ddlRoomName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(ddlRoomName.SelectedValue.Equals(Guid.Empty.ToString())))
            {
                try
                {
                    InvestorPaymentReceipt GetData = new InvestorPaymentReceipt();
                    GetData.UnitID = new Guid(ddlRoomName.SelectedValue.ToString());
                    GetData.IsActive = true;
                    List<InvestorPaymentReceipt> LstGet = InvestorPaymentReceiptBLL.GetAll(GetData);
                    if (LstGet.Count == 1)
                    {
                        txtPaidAmount.Text = LstGet[0].PaidAmount == null ? "" : Convert.ToString(LstGet[0].PaidAmount);
                        ddlModeOfPayment.SelectedValue = LstGet[0].ModeOfPaymentTermID == null ? Guid.Empty.ToString() : Convert.ToString(LstGet[0].ModeOfPaymentTermID);
                        txtBankName.Text = LstGet[0].BankName == null ? "" : LstGet[0].BankName;
                        txtVendorName.Text = LstGet[0].InsuranceVendor == null ? "" : LstGet[0].InsuranceVendor;
                        txtChqTranNo.Text = LstGet[0].ReceiptNo == null ? "" : LstGet[0].ReceiptNo;
                        txtDepostiToBank.Text = LstGet[0].DepositToBank;
                        txtNotes.Text = LstGet[0].Note;
                        this.InvestorPaymentReceiptID = LstGet[0].InvestorPaymentReceiptID;
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                txtPaidAmount.Text = "";
                ddlModeOfPayment.SelectedValue = Guid.Empty.ToString();
                txtBankName.Text = "";
                txtVendorName.Text = "";
                txtChqTranNo.Text = "";
                txtDepostiToBank.Text = "";
                txtNotes.Text = "";
                this.InvestorPaymentReceiptID = Guid.Empty;
            }
        }

        #endregion DropDown Event

        #region PaymentMode Selection
        /// <summary>
        /// Payment Mode Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //protected void ddlModeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlModeOfPayment.SelectedValue.ToUpper().Equals("C86F49A9-16AA-4EAB-B352-C9400C32AA3D") || ddlModeOfPayment.SelectedValue.Equals(Guid.Empty.ToString()))
        //    {
        //        //Visible False
        //        txtBankName.Enabled = false;
        //        txtChqTranNo.Enabled = false;
        //        txtBankName.Text = txtChqTranNo.Text = "";                 
        //        rvftxtBankName.Enabled = false;
        //        rvftxtChqTranNo.Enabled = false;
        //    }
        //    else
        //    {
        //        //Visible True
        //        txtBankName.Enabled = true;
        //        txtChqTranNo.Enabled = true;
        //        rvftxtBankName.Enabled = true;
        //        rvftxtChqTranNo.Enabled = true;
        //    }
        //}

        #endregion Payment Mode Selection

        #region Grid Row Data Event
        /// <summary>
        /// Row Data Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdInsurnaceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITCMD"))
            {
                try
                {
                    FromValidDate.Visible = ToValidDate.Visible = false;
                    this.InvestorPaymentReceiptID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadPaymentReceiptData();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (e.CommandName.Equals("DELETECMD"))
            {
                FromValidDate.Visible = ToValidDate.Visible = false;
                lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                this.InvestorPaymentReceiptID = new Guid(Convert.ToString(e.CommandArgument));
                msgbx.Show();
            }
        }

        #endregion Grid Row Data Event

        #region Popup Button Event
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPopCancel_Click(object sender, EventArgs e)
        {
            this.InvestorPaymentReceiptID = Guid.Empty;
            msgbx.Hide();
        }
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPopOk_Click(object sender, EventArgs e)
        {
            if (this.InvestorPaymentReceiptID != Guid.Empty)
            {
                InvestorPaymentReceipt GetData = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);
                InvestorPaymentReceiptBLL.Delete(this.InvestorPaymentReceiptID);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", GetData.ToString(), null, "irm_InvestorPaymentReceipt");
                IsInsert = true;
                lblInsurnaceReceiptMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
            }
            ClearControlValue();
            this.InvestorPaymentReceiptID = Guid.Empty;
            msgbx.Hide();
        }
        #endregion Popup Button Event

        #region Row Data Bound Event
        /// <summary>
        /// Grid View Row Data Bound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdInsurnaceList_RowDataBound(object sender, GridViewRowEventArgs e)
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

        #endregion Row Data Bound Event
    }
}