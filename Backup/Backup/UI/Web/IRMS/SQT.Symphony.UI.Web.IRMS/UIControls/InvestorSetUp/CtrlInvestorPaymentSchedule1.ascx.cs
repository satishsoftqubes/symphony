using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Globalization;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorPaymentSchedule1 : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;
        public Guid PaymentScheduleID
        {
            get
            {
                return ViewState["PaymentScheduleID"] != null ? new Guid(Convert.ToString(ViewState["PaymentScheduleID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PaymentScheduleID"] = value;
            }
        }
        public Guid PaymentScheduleIDToDelete
        {
            get
            {
                return ViewState["PaymentScheduleIDToDelete"] != null ? new Guid(Convert.ToString(ViewState["PaymentScheduleIDToDelete"])) : Guid.Empty;
            }
            set
            {
                ViewState["PaymentScheduleIDToDelete"] = value;
            }
        }
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
        public string DeleteType
        {
            get
            {
                return ViewState["DeleteType"] != null ? Convert.ToString(ViewState["DeleteType"]) : string.Empty;
            }
            set
            {
                ViewState["DeleteType"] = value;
            }
        }

        public double totalGridAmount;
        public double totalDuePercentage;

        #endregion Property and Variables

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtDueDate.Attributes.Add("autocomplete", "off");
            if (Session["InvID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("InvestorPaymentSchedule.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");

                LoadAccess();

                if (!IsPostBack)
                {

                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                    if (Session["PropertyConfigurationInfo"] != null)
                    {
                        PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                        string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                        DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                        if (ds.Tables[0].Rows.Count != 0)
                            this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                        else
                            this.DateFormat = "dd/MM/yyyy";
                    }
                    else
                        this.DateFormat = "dd/MM/yyyy";

                    LoadDefaultValue();
                }
            }
        }
        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorPaymentSchedule.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.PaymentScheduleID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);

            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindInvestor();
                BindProperty();
                BindRoomNo(new Guid(Convert.ToString(Guid.Empty)));
                BindGrid();
                ////BindNullGrid();
                ////LoadFinancialYearDate();
                ////rngAmount.MinimumValue = rngAmount.MaximumValue = "0";
                /////rngAmount.ErrorMessage = "Amount Payable not more than 0";
                ////rdoCustomSchedule.Enabled = rdoStandradSchame.Enabled = rdoDownPayment.Enabled = rdoInstallmentScheme.Enabled = rdoCustomSchedule.Checked = rdoStandradSchame.Checked = rdoDownPayment.Checked = rdoInstallmentScheme.Checked = false;
                btnLoadStdSchedule.Visible = false;
                ////trPaymentInPer.Visible = regPaymentAmt.Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string unitNo = null;
            Guid? PropertyID = null;

            Guid? InvestorID = new Guid(ddlInvestor.SelectedValue);
            if (!txtSUnitNumber.Text.Equals(""))
                unitNo = '%' + txtSUnitNumber.Text.Trim() + '%';
            if (ddlSPropertyName.SelectedIndex != 0)
                PropertyID = new Guid(Convert.ToString(ddlSPropertyName.SelectedValue));

            DataSet dsInvestorUnits = PaymentScheduleBLL.SearchPaymentScheduleDataNew(this.CompanyID, InvestorID, unitNo, PropertyID);

            if (dsInvestorUnits.Tables.Count > 0)
                gvInvestorUnits.DataSource = dsInvestorUnits.Tables[0];
            else
                gvInvestorUnits.DataSource = null;

            gvInvestorUnits.DataBind();
        }

        /// <summary>
        /// Load Investor
        /// </summary>
        private void BindInvestor()
        {
            string InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            DataSet dsInvestor = InvestorBLL.GetSearchData(InvestorQuery);

            if (dsInvestor.Tables[0].Rows.Count != 0)
            {
                DataView dvInvestor = new DataView(dsInvestor.Tables[0]);
                dvInvestor.Sort = "FullName Asc";
                ddlInvestor.DataSource = dvInvestor;
                ddlInvestor.DataTextField = "FullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlInvestor.SelectedValue = Convert.ToString(Session["InvID"]);
            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Property Information
        /// </summary>
        private void BindProperty()
        {
            ddlProperty.Items.Clear();
            ddlSPropertyName.Items.Clear();
            Property Prt = new Property();
            Prt.IsActive = true;
            List<Property> LstProperty = PropertyBLL.GetAll(Prt);
            if (LstProperty.Count > 0)
            {
                ddlProperty.DataSource = LstProperty;
                ddlProperty.DataTextField = "PropertyName";
                ddlProperty.DataValueField = "PropertyID";
                ddlProperty.DataBind();
                ddlProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                ddlSPropertyName.DataSource = LstProperty;
                ddlSPropertyName.DataTextField = "PropertyName";
                ddlSPropertyName.DataValueField = "PropertyID";
                ddlSPropertyName.DataBind();
                ddlSPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Load RoomNo
        /// </summary>
        private void BindRoomNo(Guid PropertyID)
        {
            ddlInvestorRoom.Items.Clear();
            DataSet dsRoom = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, new Guid(Convert.ToString(Session["InvID"])), PropertyID, null, null);
            if (dsRoom.Tables[0].Rows.Count != 0)
            {
                DataView dvRoom = new DataView(dsRoom.Tables[0]);
                dvRoom.Sort = "RoomNo Asc";
                ddlInvestorRoom.DataSource = dvRoom;
                ddlInvestorRoom.DataTextField = "RoomNo";
                ddlInvestorRoom.DataValueField = "InvestorRoomID";
                ddlInvestorRoom.DataBind();
                ddlInvestorRoom.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlInvestorRoom.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            BindInvestor();
            Session["CurrentAmount"] = null;
            lblTotalPurchaseValue.Text = "0.00";
            ddlInvestorRoom.Enabled = true;
            ddlProperty.Enabled = true;
            btnLoadStdSchedule.Visible = false;
            BindGrid();
            this.PaymentScheduleID = Guid.Empty;
            btnAddNewRow.Visible = false;
            ddlInvestorRoom_SelectedIndexChanged(null, null);
        }
        /// <summary>
        /// Load Financial Year
        /// </summary>
        ////private void LoadFinancialYearDate()
        ////{
        ////    ddlDate.Items.Clear();
        ////    ddlYear.Items.Clear();
        ////    //Load Date Based On Month
        ////    ddlDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
        ////    for (int i = 1; i < 32; i++)
        ////    {
        ////        if (i < 10)
        ////        {
        ////            ddlDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
        ////        }
        ////        else
        ////        {
        ////            ddlDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
        ////        }
        ////    }

        ////    //Load Year
        ////    int j = 1;
        ////    ddlYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
        ////    for (int i = Convert.ToInt32(DateTime.Now.Year) + 15; i >= 1970; i--)
        ////    {
        ////        ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
        ////        j++;
        ////    }
        ////}
        #endregion Private Method

        #region Control Event
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //ClearControl();
                this.PaymentScheduleID = Guid.Empty;
                ddlProperty.SelectedIndex = 0;
                ddlInvestorRoom.Items.Clear();
                ddlInvestorRoom.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                lblTotalPurchaseValue.Text = "0.00";
                rdblstScheduleType.SelectedIndex = -1;
                rdblstScheduleType.Enabled = false;
                btnAddNewRow.Visible = false;
                gvPaymentSchedules.DataSource = null;
                gvPaymentSchedules.DataBind();
                btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();
                LoadAccess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    List<PaymentSchedule> lstPaymentSchedule = new List<PaymentSchedule>();

                    for (int i = 0; i < gvPaymentSchedules.Rows.Count; i++)
                    {
                        PaymentSchedule objPaymentSchedule = null;
                        TextBox txtMileStoneTitle = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtMileStoneTitle");
                        TextBox txtAmountPayable = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtAmountPayable");
                        TextBox txtDueDate = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDueDate");
                        Label lblScheduleType = (Label)gvPaymentSchedules.Rows[i].FindControl("lblScheduleType");

                        objPaymentSchedule = new PaymentSchedule();
                        objPaymentSchedule.PaymentScheduleID = new Guid(Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]));
                        objPaymentSchedule.ProjectMilestone = txtMileStoneTitle.Text.Trim();
                        objPaymentSchedule.AmountPayable = Convert.ToDecimal(txtAmountPayable.Text.Trim());

                        if (txtDueDate.Text.Trim() != string.Empty)
                            objPaymentSchedule.DueDate = DateTime.ParseExact(txtDueDate.Text.Trim(), this.DateFormat, objCultureInfo);

                        objPaymentSchedule.ScheduleType = lblScheduleType.Text;

                        if (objPaymentSchedule.ScheduleType.ToString().ToUpper() == "FULL")
                            objPaymentSchedule.IsDefaultSchedule = true;
                        else
                            objPaymentSchedule.IsDefaultSchedule = false;

                        objPaymentSchedule.IsReceiptCreated = Convert.ToString(gvPaymentSchedules.DataKeys[i]["IsReceiptGenerated"]) == "1";

                        objPaymentSchedule.CompanyID = this.CompanyID;
                        objPaymentSchedule.IsActive = true;
                        objPaymentSchedule.InvestorID = new Guid(ddlInvestor.SelectedValue);
                        objPaymentSchedule.InvestorRoomID = new Guid(ddlInvestorRoom.SelectedValue);

                        lstPaymentSchedule.Add(objPaymentSchedule);
                    }


                    InvestorsUnit objInvestorsUnit = InvestorsUnitBLL.GetByPrimaryKey(new Guid(ddlInvestorRoom.SelectedValue));

                    objInvestorsUnit.ScheduleType = rdblstScheduleType.SelectedValue.ToString().ToUpper();

                    ////PaymentScheduleBLL.SaveNew(lstPaymentSchedule, new Guid(ddlInvestorRoom.SelectedValue), objInvestorsUnit);

                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();

                    /*
                    if (this.PaymentScheduleID != Guid.Empty)
                    {
                        PaymentSchedule objUpd = new PaymentSchedule();
                        PaymentSchedule objOldPSData = new PaymentSchedule();
                        objUpd = PaymentScheduleBLL.GetByPrimaryKey(this.PaymentScheduleID);
                        objOldPSData = PaymentScheduleBLL.GetByPrimaryKey(this.PaymentScheduleID);

                        objUpd.InvestorID = new Guid(ddlInvestor.SelectedValue);
                        objUpd.InvestorRoomID = new Guid(ddlInvestorRoom.SelectedValue);
                        ////if (!(txtAmountPayable.Text.Trim().Equals("")))
                        ////    objUpd.AmountPayable = Convert.ToDecimal(txtAmountPayable.Text.Trim());
                        ////else
                        ////    objUpd.AmountPayable = null;
                        ////objUpd.DueDate = Convert.ToDateTime(ToDate);
                        ////objUpd.ProjectMilestone = txtProjectMileStone.Text.Trim();
                        ////if (rdoDownPayment.Checked == true)
                        ////{
                        ////    objUpd.IsDefaultSchedule = true;
                        ////    objUpd.ScheduleType = "FULL";
                        ////}
                        ////else
                        ////{
                        ////    objUpd.IsDefaultSchedule = false;
                        ////    //if (rdoCustomSchedule.Checked == true)
                        ////    //    objUpd.ScheduleType = "CUS";
                        ////    //if (rdoStandradSchame.Checked == true)
                        ////    //    objUpd.ScheduleType = "STD";
                        ////}

                        PaymentScheduleBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPSData.ToString(), objUpd.ToString(), "irm_InvestorPaymentSchedule");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        PaymentSchedule objIns = new PaymentSchedule();
                        objIns.InvestorID = new Guid(ddlInvestor.SelectedValue);
                        objIns.InvestorRoomID = new Guid(ddlInvestorRoom.SelectedValue);
                        //if (!(txtAmountPayable.Text.Trim().Equals("")))
                        //    objIns.AmountPayable = Convert.ToDecimal(txtAmountPayable.Text.Trim());
                        //else
                        //    objIns.AmountPayable = null;
                        objIns.TotalReceived = 0;
                        ////objIns.DueDate = Convert.ToDateTime(ToDate);
                        /////objIns.ProjectMilestone = txtProjectMileStone.Text.Trim();
                        objIns.IsActive = true;
                        objIns.CreatedOn = DateTime.Now;
                        objIns.CompanyID = this.CompanyID;
                        ////if (rdoDownPayment.Checked == true)
                        ////{
                        ////    objIns.IsDefaultSchedule = true;
                        ////    objIns.ScheduleType = "FULL";
                        ////}
                        ////else
                        ////{
                        ////    ////objIns.IsDefaultSchedule = false;
                        ////    ////if (rdoCustomSchedule.Checked == true)
                        ////    ////    objIns.ScheduleType = "CUS";
                        ////    ////if (rdoStandradSchame.Checked == true)
                        ////    ////    objIns.ScheduleType = "STD";
                        ////}

                        PaymentScheduleBLL.Save(objIns);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "irm_InvestorPaymentSchedule");

                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControl();
                    ////BindDefaultScheduleGrid();
                     * */
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnPaymentScheduleYes_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();

                if (this.DeleteType == "INVESTORUNIT" && this.PaymentScheduleID != Guid.Empty)
                {
                    InvestorsUnit objToDelete = InvestorsUnitBLL.GetByPrimaryKey(this.PaymentScheduleID);
                    InvestorsUnitBLL.Delete(this.PaymentScheduleID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objToDelete.ToString(), null, "irm_InvestorsUnit");

                    //Old code of delete.
                    //PaymentSchedule objDelete = PaymentScheduleBLL.GetByPrimaryKey(this.PaymentScheduleID);
                    //PaymentScheduleBLL.Delete(this.PaymentScheduleID);
                    //ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "irm_InvestorPaymentSchedule");

                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();

                    this.PaymentScheduleID = Guid.Empty;
                    ddlProperty.SelectedIndex = 0;
                    ddlInvestorRoom.Items.Clear();
                    ddlInvestorRoom.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    lblTotalPurchaseValue.Text = "0.00";
                    rdblstScheduleType.SelectedIndex = -1;
                    rdblstScheduleType.Enabled = false;
                    btnAddNewRow.Visible = false;
                    gvPaymentSchedules.DataSource = null;
                    gvPaymentSchedules.DataBind();
                    btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);

                    BindGrid();
                }
                else if (this.DeleteType == "UNITSCHEDULE" && this.PaymentScheduleIDToDelete != Guid.Empty)
                {
                    DataTable dtSchedules = new DataTable();

                    DataColumn clPaymentScheduleID = new DataColumn("PaymentScheduleID");
                    dtSchedules.Columns.Add(clPaymentScheduleID);
                    DataColumn clProjectMileStone = new DataColumn("ProjectMileStone");
                    dtSchedules.Columns.Add(clProjectMileStone);
                    DataColumn clDue = new DataColumn("Due");
                    dtSchedules.Columns.Add(clDue);
                    DataColumn clAmountPayable = new DataColumn("AmountPayable");
                    dtSchedules.Columns.Add(clAmountPayable);
                    DataColumn clDueDate = new DataColumn("DueDate");
                    dtSchedules.Columns.Add(clDueDate);
                    DataColumn clScheduleType = new DataColumn("ScheduleType");
                    dtSchedules.Columns.Add(clScheduleType);
                    DataColumn clIsReceiptGenerated = new DataColumn("IsReceiptGenerated");
                    dtSchedules.Columns.Add(clIsReceiptGenerated);


                    for (int i = 0; i < gvPaymentSchedules.Rows.Count; i++)
                    {
                        if (Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]).ToUpper() != Convert.ToString(this.PaymentScheduleIDToDelete).ToUpper())
                        {
                            TextBox txtMileStoneTitle = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtMileStoneTitle");
                            TextBox txtDue = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDue");
                            TextBox txtAmountPayable = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtAmountPayable");
                            TextBox txtDueDate = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDueDate");
                            Label lblScheduleType = (Label)gvPaymentSchedules.Rows[i].FindControl("lblScheduleType");

                            DataRow drRow = dtSchedules.NewRow();
                            drRow["PaymentScheduleID"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]);
                            drRow["ProjectMileStone"] = txtMileStoneTitle.Text.Trim();
                            drRow["Due"] = txtDue.Text.Trim();
                            drRow["AmountPayable"] = txtAmountPayable.Text.Trim();
                            drRow["DueDate"] = txtDueDate.Text.Trim();
                            drRow["ScheduleType"] = lblScheduleType.Text.Trim();
                            drRow["IsReceiptGenerated"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["IsReceiptGenerated"]);
                            dtSchedules.Rows.Add(drRow);
                        }
                    }

                    totalGridAmount = totalDuePercentage = 0;
                    for (int i = 0; i < dtSchedules.Rows.Count; i++)
                    {
                        totalGridAmount = totalGridAmount + Convert.ToDouble(dtSchedules.Rows[i]["AmountPayable"]);
                        totalDuePercentage = totalDuePercentage + Convert.ToDouble(dtSchedules.Rows[i]["Due"]);
                    }

                    gvPaymentSchedules.DataSource = dtSchedules;
                    gvPaymentSchedules.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPaymentScheduleNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                if (this.DeleteType == "INVESTORUNIT")
                {
                    ClearControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void ddlInvestorRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInvestorRoom.SelectedIndex != 0)
            {
                rdblstScheduleType.Enabled = true;
                DataSet dsSchedules = PaymentScheduleBLL.GetPaymentScheduleByInvestorRoomID(new Guid(ddlInvestorRoom.SelectedValue.ToString()));

                if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                {
                    gvPaymentSchedules.DataSource = dsSchedules.Tables[0];

                    totalGridAmount = totalDuePercentage = 0;
                    for (int i = 0; i < dsSchedules.Tables[0].Rows.Count; i++)
                    {
                        totalGridAmount = totalGridAmount + Convert.ToDouble(dsSchedules.Tables[0].Rows[i]["AmountPayable"]);
                        totalDuePercentage = totalDuePercentage + Convert.ToDouble(dsSchedules.Tables[0].Rows[i]["Due"]);
                    }
                }
                else
                {
                    gvPaymentSchedules.DataSource = null;
                }

                gvPaymentSchedules.DataBind();

                if (dsSchedules.Tables.Count > 1 && dsSchedules.Tables[1].Rows.Count > 0)
                {
                    lblTotalPurchaseValue.Text = Convert.ToString(dsSchedules.Tables[1].Rows[0]["TotalPrice"]);

                    if (Convert.ToString(dsSchedules.Tables[1].Rows[0]["ScheduleType"]) != string.Empty)
                        rdblstScheduleType.SelectedValue = Convert.ToString(dsSchedules.Tables[1].Rows[0]["ScheduleType"]);

                    btnAddNewRow.Visible = Convert.ToString(dsSchedules.Tables[1].Rows[0]["ScheduleType"]) == "CUSTOM";
                }
                else
                {
                    lblTotalPurchaseValue.Text = "0.00";
                }
            }
            else
            {
                rdblstScheduleType.SelectedIndex = -1;
                rdblstScheduleType.Enabled = false;
                gvPaymentSchedules.DataSource = null;
                gvPaymentSchedules.DataBind();
            }
        }

        protected void ddlProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProperty.SelectedIndex == 0)
                BindRoomNo(new Guid(Convert.ToString(Guid.Empty)));
            else
                BindRoomNo(new Guid(Convert.ToString(ddlProperty.SelectedValue)));

            rdblstScheduleType.SelectedIndex = -1;
            rdblstScheduleType.Enabled = false;
            btnAddNewRow.Visible = false;

            gvPaymentSchedules.DataSource = null;
            gvPaymentSchedules.DataBind();

            lblTotalPurchaseValue.Text = "0.00";
            btnLoadStdSchedule.Visible = false;
        }

        protected void rdblstScheduleType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnAddNewRow.Visible = rdblstScheduleType.SelectedValue.ToString().ToUpper() == "CUSTOM";

                DataTable dtSchedules = new DataTable();

                DataColumn clPaymentScheduleID = new DataColumn("PaymentScheduleID");
                dtSchedules.Columns.Add(clPaymentScheduleID);
                DataColumn clProjectMileStone = new DataColumn("ProjectMileStone");
                dtSchedules.Columns.Add(clProjectMileStone);
                DataColumn clDue = new DataColumn("Due");
                dtSchedules.Columns.Add(clDue);
                DataColumn clAmountPayable = new DataColumn("AmountPayable");
                dtSchedules.Columns.Add(clAmountPayable);
                DataColumn clDueDate = new DataColumn("DueDate");
                dtSchedules.Columns.Add(clDueDate);
                DataColumn clScheduleType = new DataColumn("ScheduleType");
                dtSchedules.Columns.Add(clScheduleType);
                DataColumn clIsReceiptGenerated = new DataColumn("IsReceiptGenerated");
                dtSchedules.Columns.Add(clIsReceiptGenerated);

                if (rdblstScheduleType.SelectedValue.ToString().ToUpper() == "FULL")
                {
                    double totalPercentage = 0;
                    double totalReceiptAmount = 0;

                    for (int i = 0; i < gvPaymentSchedules.Rows.Count; i++)
                    {
                        TextBox txtMileStoneTitle = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtMileStoneTitle");
                        TextBox txtDue = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDue");
                        TextBox txtAmountPayable = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtAmountPayable");
                        TextBox txtDueDate = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDueDate");
                        Label lblScheduleType = (Label)gvPaymentSchedules.Rows[i].FindControl("lblScheduleType");

                        //if receipt is generated, then keep it as it is...
                        if (Convert.ToString(gvPaymentSchedules.DataKeys[i]["IsReceiptGenerated"]) == "1")
                        {
                            DataRow drRow = dtSchedules.NewRow();
                            drRow["PaymentScheduleID"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]);
                            drRow["ProjectMileStone"] = txtMileStoneTitle.Text.Trim();
                            drRow["Due"] = txtDue.Text.Trim();
                            drRow["AmountPayable"] = txtAmountPayable.Text.Trim();

                            totalReceiptAmount = totalReceiptAmount + Convert.ToDouble(txtAmountPayable.Text.Trim());
                            totalPercentage = totalPercentage + Convert.ToDouble(txtDue.Text.Trim());

                            drRow["DueDate"] = txtDueDate.Text.Trim();
                            drRow["ScheduleType"] = lblScheduleType.Text.Trim();
                            drRow["IsReceiptGenerated"] = "1";
                            dtSchedules.Rows.Add(drRow);
                        }
                    }

                    DataRow drRowFullPayment = dtSchedules.NewRow();
                    drRowFullPayment["PaymentScheduleID"] = Guid.NewGuid().ToString();
                    drRowFullPayment["ProjectMileStone"] = "Full Schedule";
                    drRowFullPayment["AmountPayable"] = (Convert.ToDouble(lblTotalPurchaseValue.Text) - totalReceiptAmount).ToString();
                    drRowFullPayment["Due"] = (100 - totalPercentage).ToString();
                    drRowFullPayment["DueDate"] = DateTime.Today.ToString();
                    drRowFullPayment["ScheduleType"] = "FULL";
                    drRowFullPayment["IsReceiptGenerated"] = "0";
                    dtSchedules.Rows.Add(drRowFullPayment);



                    totalGridAmount = totalDuePercentage = 0;
                    for (int i = 0; i < dtSchedules.Rows.Count; i++)
                    {
                        totalGridAmount = totalGridAmount + Convert.ToDouble(dtSchedules.Rows[i]["AmountPayable"]);
                        totalDuePercentage = totalDuePercentage + Convert.ToDouble(dtSchedules.Rows[i]["Due"]);
                    }

                    gvPaymentSchedules.DataSource = dtSchedules;
                    gvPaymentSchedules.DataBind();
                }
                else
                {
                    for (int i = 0; i < gvPaymentSchedules.Rows.Count; i++)
                    {
                        TextBox txtMileStoneTitle = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtMileStoneTitle");
                        TextBox txtDue = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDue");
                        TextBox txtAmountPayable = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtAmountPayable");
                        TextBox txtDueDate = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDueDate");
                        Label lblScheduleType = (Label)gvPaymentSchedules.Rows[i].FindControl("lblScheduleType");

                        //if receipt is generated, then keep it as it is...
                        if (Convert.ToString(gvPaymentSchedules.DataKeys[i]["IsReceiptGenerated"]) == "1")
                        {
                            DataRow drRow = dtSchedules.NewRow();
                            drRow["PaymentScheduleID"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]);
                            drRow["ProjectMileStone"] = txtMileStoneTitle.Text.Trim();
                            drRow["Due"] = txtDue.Text.Trim();
                            drRow["AmountPayable"] = txtAmountPayable.Text.Trim();
                            drRow["DueDate"] = txtDueDate.Text.Trim();
                            drRow["ScheduleType"] = lblScheduleType.Text.Trim();
                            drRow["IsReceiptGenerated"] = "1";
                            dtSchedules.Rows.Add(drRow);
                        }
                        else
                        {
                            //receipt is not generated, then change it's schedule type.
                            DataRow drRow = dtSchedules.NewRow();
                            drRow["PaymentScheduleID"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]);
                            drRow["ProjectMileStone"] = txtMileStoneTitle.Text.Trim();
                            drRow["Due"] = txtDue.Text.Trim();
                            drRow["AmountPayable"] = txtAmountPayable.Text.Trim();
                            drRow["DueDate"] = txtDueDate.Text.Trim();

                            if (rdblstScheduleType.SelectedValue.ToString().ToUpper() == "STANDARD")
                                drRow["ScheduleType"] = "STD";
                            else
                                drRow["ScheduleType"] = "CST";

                            drRow["IsReceiptGenerated"] = "0";
                            dtSchedules.Rows.Add(drRow);
                        }
                    }

                    totalGridAmount = totalDuePercentage = 0;
                    for (int i = 0; i < dtSchedules.Rows.Count; i++)
                    {
                        totalGridAmount = totalGridAmount + Convert.ToDouble(dtSchedules.Rows[i]["AmountPayable"]);
                        totalDuePercentage = totalDuePercentage + Convert.ToDouble(dtSchedules.Rows[i]["Due"]);
                    }

                    gvPaymentSchedules.DataSource = dtSchedules;
                    gvPaymentSchedules.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSchedules = new DataTable();

                DataColumn clPaymentScheduleID = new DataColumn("PaymentScheduleID");
                dtSchedules.Columns.Add(clPaymentScheduleID);
                DataColumn clProjectMileStone = new DataColumn("ProjectMileStone");
                dtSchedules.Columns.Add(clProjectMileStone);
                DataColumn clDue = new DataColumn("Due");
                dtSchedules.Columns.Add(clDue);
                DataColumn clAmountPayable = new DataColumn("AmountPayable");
                dtSchedules.Columns.Add(clAmountPayable);
                DataColumn clDueDate = new DataColumn("DueDate");
                dtSchedules.Columns.Add(clDueDate);
                DataColumn clScheduleType = new DataColumn("ScheduleType");
                dtSchedules.Columns.Add(clScheduleType);
                DataColumn clIsReceiptGenerated = new DataColumn("IsReceiptGenerated");
                dtSchedules.Columns.Add(clIsReceiptGenerated);


                for (int i = 0; i < gvPaymentSchedules.Rows.Count; i++)
                {
                    TextBox txtMileStoneTitle = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtMileStoneTitle");
                    TextBox txtDue = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDue");
                    TextBox txtAmountPayable = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtAmountPayable");
                    TextBox txtDueDate = (TextBox)gvPaymentSchedules.Rows[i].FindControl("txtDueDate");
                    Label lblScheduleType = (Label)gvPaymentSchedules.Rows[i].FindControl("lblScheduleType");

                    DataRow drRow = dtSchedules.NewRow();
                    drRow["PaymentScheduleID"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["PaymentScheduleID"]);
                    drRow["ProjectMileStone"] = txtMileStoneTitle.Text.Trim();
                    drRow["Due"] = txtDue.Text.Trim();
                    drRow["AmountPayable"] = txtAmountPayable.Text.Trim();
                    drRow["DueDate"] = txtDueDate.Text.Trim();
                    drRow["ScheduleType"] = lblScheduleType.Text.Trim();
                    drRow["IsReceiptGenerated"] = Convert.ToString(gvPaymentSchedules.DataKeys[i]["IsReceiptGenerated"]);
                    dtSchedules.Rows.Add(drRow);
                }

                DataRow drRowToAdd = dtSchedules.NewRow();
                drRowToAdd["PaymentScheduleID"] = Guid.NewGuid().ToString();
                drRowToAdd["ProjectMileStone"] = "";
                drRowToAdd["Due"] = "0";
                drRowToAdd["AmountPayable"] = "0";
                drRowToAdd["DueDate"] = DateTime.Today;
                drRowToAdd["ScheduleType"] = "CST";
                drRowToAdd["IsReceiptGenerated"] = "0";
                dtSchedules.Rows.Add(drRowToAdd);

                totalGridAmount = totalDuePercentage = 0;
                for (int i = 0; i < dtSchedules.Rows.Count; i++)
                {
                    totalGridAmount = totalGridAmount + Convert.ToDouble(dtSchedules.Rows[i]["AmountPayable"]);
                    totalDuePercentage = totalDuePercentage + Convert.ToDouble(dtSchedules.Rows[i]["Due"]);
                }

                gvPaymentSchedules.DataSource = dtSchedules;
                gvPaymentSchedules.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnLoadStdSchedule_Click(object sender, EventArgs e)
        {
            if (ddlInvestor.SelectedValue != Guid.Empty.ToString() && ddlInvestorRoom.SelectedValue != Guid.Empty.ToString())
            {
                PaymentScheduleBLL.InvestorScheduleLoadStadScheduleAgain(new Guid(Convert.ToString(ddlInvestor.SelectedValue)), new Guid(Convert.ToString(ddlInvestorRoom.SelectedValue)));
                ////BindDefaultScheduleGrid();
                ddlInvestorRoom_SelectedIndexChanged(null, null);
            }
        }
        #endregion

        #region Grid Event
        protected void gvInvestorUnits_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    ////FromValidDate.Visible = false;
                    this.PaymentScheduleID = new Guid(Convert.ToString(e.CommandArgument));
                    DataSet DsScheduleData = PaymentScheduleBLL.PaymentScheduleGetAllByInvestorRoomID(this.PaymentScheduleID);

                    if (DsScheduleData != null && DsScheduleData.Tables[0].Rows.Count > 0)
                    {
                        ddlProperty.SelectedIndex = ddlProperty.Items.FindByValue(Convert.ToString(DsScheduleData.Tables[0].Rows[0]["PropertyID"])) != null ? ddlProperty.Items.IndexOf(ddlProperty.Items.FindByValue(Convert.ToString(DsScheduleData.Tables[0].Rows[0]["PropertyID"]))) : 0;

                        ddlInvestorRoom.Items.Clear();
                        if (DsScheduleData.Tables.Count > 1 && DsScheduleData.Tables[1].Rows.Count > 0)
                        {
                            ddlInvestorRoom.DataSource = DsScheduleData.Tables[1];
                            ddlInvestorRoom.DataTextField = "RoomNo";
                            ddlInvestorRoom.DataValueField = "InvestorRoomID";
                            ddlInvestorRoom.DataBind();
                            ddlInvestorRoom.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                        }
                        else
                            ddlInvestorRoom.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                        ddlInvestorRoom.SelectedIndex = ddlInvestorRoom.Items.FindByValue(Convert.ToString(e.CommandArgument)) != null ? ddlInvestorRoom.Items.IndexOf(ddlInvestorRoom.Items.FindByValue(Convert.ToString(e.CommandArgument))) : 0;

                        if (ddlInvestorRoom.SelectedIndex != 0)
                        {
                            rdblstScheduleType.Enabled = true;

                            if (DsScheduleData.Tables.Count > 2 && DsScheduleData.Tables[2].Rows.Count > 0)
                            {
                                gvPaymentSchedules.DataSource = DsScheduleData.Tables[2];

                                totalGridAmount = totalDuePercentage = 0;
                                for (int i = 0; i < DsScheduleData.Tables[2].Rows.Count; i++)
                                {
                                    totalGridAmount = totalGridAmount + Convert.ToDouble(DsScheduleData.Tables[2].Rows[i]["AmountPayable"]);
                                    totalDuePercentage = totalDuePercentage + Convert.ToDouble(DsScheduleData.Tables[2].Rows[i]["Due"]);
                                }
                            }
                            else
                            {
                                gvPaymentSchedules.DataSource = null;
                            }

                            gvPaymentSchedules.DataBind();

                            if (DsScheduleData.Tables.Count > 3 && DsScheduleData.Tables[3].Rows.Count > 0)
                            {
                                lblTotalPurchaseValue.Text = Convert.ToString(DsScheduleData.Tables[3].Rows[0]["TotalPrice"]);

                                if (Convert.ToString(DsScheduleData.Tables[3].Rows[0]["ScheduleType"]) != string.Empty)
                                    rdblstScheduleType.SelectedValue = Convert.ToString(DsScheduleData.Tables[3].Rows[0]["ScheduleType"]);

                                btnAddNewRow.Visible = Convert.ToString(DsScheduleData.Tables[3].Rows[0]["ScheduleType"]) == "CUSTOM";
                            }
                            else
                            {
                                lblTotalPurchaseValue.Text = "0.00";
                            }
                        }
                        else
                        {
                            rdblstScheduleType.SelectedIndex = -1;
                            rdblstScheduleType.Enabled = false;
                            gvPaymentSchedules.DataSource = null;
                            gvPaymentSchedules.DataBind();
                        }
                    }

                    //LoadAccess();

                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    this.DeleteType = "INVESTORUNIT";
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PaymentScheduleID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvInvestorUnits_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvPaymentSchedules_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ////if (Convert.ToBoolean(ViewState["Edit"]) == true)
                ////    e.Row.Cells[6].Text = "View/Edit";
                ////else if (Convert.ToBoolean(ViewState["View"]) == true)
                ////    e.Row.Cells[6].Text = "View";
                ////e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["View"]);
                ////e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (rdblstScheduleType.SelectedValue.ToString().ToUpper() != "CUSTOM")
                    e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AjaxControlToolkit.CalendarExtender calDueDate = (AjaxControlToolkit.CalendarExtender)e.Row.FindControl("calDueDate");
                calDueDate.Format = this.DateFormat;

                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsReceiptGenerated")) == "1" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ScheduleType")) == "FULL")
                {
                    ((TextBox)e.Row.FindControl("txtDue")).Enabled = false;
                    ((TextBox)e.Row.FindControl("txtAmountPayable")).Enabled = false;
                }

                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DueDate")) != string.Empty)
                    ((TextBox)e.Row.FindControl("txtDueDate")).Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DueDate")).ToString(this.DateFormat);

                if (rdblstScheduleType.SelectedValue.ToString().ToUpper() == "CUSTOM")
                {
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsReceiptGenerated")) != "1")
                        ((ImageButton)e.Row.FindControl("btnDelete")).Visible = true;
                    else
                        ((ImageButton)e.Row.FindControl("btnDelete")).Visible = false;
                }
                else
                    e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;

                /*
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["View"]);
                e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View";
                */
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalPercentage = (Label)e.Row.FindControl("lblTotalPercentage");
                Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");

                if (lblTotalPercentage != null && totalDuePercentage != 0)
                    lblTotalPercentage.Text = totalDuePercentage.ToString() + "%";

                if (lblTotalAmount != null)
                    lblTotalAmount.Text = totalGridAmount.ToString();

                if (rdblstScheduleType.SelectedValue.ToString().ToUpper() != "CUSTOM")
                    e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;

                ////if (Convert.ToBoolean(ViewState["Edit"]) == true)
                ////    e.Row.Cells[6].Text = "View/Edit";
                ////else if (Convert.ToBoolean(ViewState["View"]) == true)
                ////    e.Row.Cells[6].Text = "View";
                ////e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["View"]);
                ////e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["Delete"]);
            }
        }
        protected void gvPaymentSchedules_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETECMD"))
            {
                //lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                //this.PaymentScheduleID = new Guid(Convert.ToString(e.CommandArgument));
                //msgbx.Show();

                this.DeleteType = "UNITSCHEDULE";
                lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                this.PaymentScheduleIDToDelete = new Guid(Convert.ToString(e.CommandArgument));
                msgbx.Show();
            }
        }
        #endregion Grid Event
    }
}