using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPurchaseScheduleConfigurationInformation : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid PurchaseScheduleID
        {
            get
            {
                return ViewState["PurchaseScheduleID"] != null ? new Guid(Convert.ToString(ViewState["PurchaseScheduleID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PurchaseScheduleID"] = value;
            }
        }

        public Guid PropertyID
        {
            get
            {
                return ViewState["Property"] != null ? new Guid(Convert.ToString(ViewState["Property"])) : Guid.Empty;
            }
            set
            {
                ViewState["Property"] = value;
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

        #endregion Property and Variables
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPurchaseScheduleInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                    if (Session["PropertyID"] != null)
                    {
                        this.PropertyID = new Guid(Convert.ToString(Session["PropertyID"]));
                        LoadData();
                        Session["PropertyID"] = null;
                    }
                    else
                    {
                        LoadDefaultValue();
                    }
                }

                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                {
                    //btnAddPurchaseSchedule.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }

        private void LoadDefaultValue()
        {
            try
            {
                BindDDL();
                BindPurchaseOption();
                LoadPropertyInstallmentGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadData()
        {
            try
            {
                BindDDL();
                LoadPropertyInstallmentGrid();
                BindPurchaseOption();

                DataSet ds = new DataSet();
                DataSet dsPropertyInstallment = new DataSet();
                DataTable dt = new DataTable();

                ds = PurchaseScheduleBLL.GetPurchaseScheduleData(this.PropertyID, this.CompanyID, null);
                dsPropertyInstallment = PurchaseScheduleBLL.GetPurchaseSchedulePropertyInstallmentData(this.PropertyID, this.CompanyID, null);
                dt = dsPropertyInstallment.Tables[0];

                if (dsPropertyInstallment.Tables[0].Rows.Count != 0)
                {
                    ddlPropertyName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyID"]);
                    ddlPurchaseOption.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PurchaseOptionID"]);
                    txtPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                    txtPurchaseArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["PurchaseArea"]);
                    txtTotalCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalCost"]);

                    // Bind property installment grid
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i != 0)
                        {
                            AddNewRowToGrid();
                        }
                        HiddenField hdnPurchaseScheduleID = (HiddenField)gvPropertyInstallments.Rows[i].Cells[1].FindControl("hdnPurchaseScheduleID");
                        hdnPurchaseScheduleID.Value = Convert.ToString(dsPropertyInstallment.Tables[0].Rows[i]["PurchaseScheduleID"]).Trim();

                        DropDownList ddlPaymentPeriod = (DropDownList)gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentPeriod");
                        ddlPaymentPeriod.Text = Convert.ToString(dsPropertyInstallment.Tables[0].Rows[i]["InstallmentTypeTermID"]);

                        TextBox percentage = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentPercent");
                        percentage.Text = Convert.ToString(dsPropertyInstallment.Tables[0].Rows[i]["InstallmentInPercentage"]);

                        DropDownList ddlPaymentMode = (DropDownList)gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentMode");
                        ddlPaymentMode.Text = Convert.ToString(dsPropertyInstallment.Tables[0].Rows[i]["MOPTermID"]);

                        TextBox amount = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentAmount");
                        amount.Text = Convert.ToString(dsPropertyInstallment.Tables[0].Rows[i]["InstallmentAmount"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDDL()
        {
            string PropertyNameQuery = string.Empty;
            string PurchaseScheduleQuery = string.Empty;
            string AllPurchaseScheduleQuery = string.Empty;

            AllPurchaseScheduleQuery = "Select COUNT(PurchaseScheduleID) AS PurchaseScheduleCount From propertypurchase_schedule Where IsActive = 1";
            DataSet allDsps = InvestorBLL.GetSearchData(AllPurchaseScheduleQuery);

            PurchaseScheduleQuery = "Select COUNT(PurchaseScheduleID) AS PurchaseScheduleCount From propertypurchase_schedule Where IsActive = 1 AND PropertyID='" + this.PropertyID + "'";
            DataSet Dsps = InvestorBLL.GetSearchData(PurchaseScheduleQuery);

            if (Convert.ToInt32(allDsps.Tables[0].Rows[0]["PurchaseScheduleCount"]) == 0)
            {
                PropertyNameQuery = "Select Distinct(PropertyName), PropertyID From mst_Property Where IsActive = 1";
            }
            else
            {
                if (Session["PropertyID"] == null)
                    PropertyNameQuery = "Select Distinct(PropertyName), p.PropertyID From mst_Property p inner join propertypurchase_schedule ps on ps.PropertyID != p.PropertyID Where p.IsActive = 1";
                else
                    PropertyNameQuery = "Select Distinct(PropertyName), PropertyID From mst_Property Where IsActive = 1 AND PropertyID='" + this.PropertyID + "'";
            }

            DataSet Dst = InvestorBLL.GetSearchData(PropertyNameQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlPropertyName.DataSource = Dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        private void BindPurchaseOption()
        {
            List<ProjectTerm> lstProjectTermPO = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PURCHASEOPTION";
            objProjectTermPT.CompanyID = this.CompanyID;

            lstProjectTermPO = ProjectTermBLL.GetAll(objProjectTermPT);

            if (lstProjectTermPO.Count != 0)
            {
                lstProjectTermPO.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlPurchaseOption.DataSource = lstProjectTermPO;
                ddlPurchaseOption.DataTextField = "DisplayTerm";
                ddlPurchaseOption.DataValueField = "TermID";
                ddlPurchaseOption.DataBind();
                ddlPurchaseOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPurchaseOption.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        public void fnCalculateTotalCost(object sender, EventArgs e)
        {
            string pattern = @"^\d+(\.\d+)*$";
            Regex rg = new Regex(pattern);

            if (txtPrice.Text != "" && txtPurchaseArea.Text != "")
            {
                if (rg.Matches(txtPrice.Text).Count > 0 && rg.Matches(txtPurchaseArea.Text).Count > 0)
                {
                    decimal price = Convert.ToDecimal(txtPrice.Text);
                    decimal purchaseArea = Convert.ToDecimal(txtPurchaseArea.Text);
                    decimal totalCost = Convert.ToDecimal(price * purchaseArea);
                    txtTotalCost.Text = Convert.ToString(totalCost);
                }
                else
                {
                    txtPrice.Text = "";
                    txtPurchaseArea.Text = "";
                    txtTotalCost.Text = "";
                }
            }
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        protected void fnAddNewInstallment(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        private void AddNewRowToGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();                    
                    drCurrentRow["RowNumber"] = "Installment " + Convert.ToInt32(dtCurrentTable.Rows.Count + 1);

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    //Store the current data to ViewState for future reference   
                    ViewState["CurrentTable"] = dtCurrentTable;

                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {
                        HiddenField h1 = (HiddenField)gvPropertyInstallments.Rows[i].Cells[1].FindControl("hdnPurchaseScheduleID");
                        dtCurrentTable.Rows[i]["PurchaseScheduleID"] = h1.Value;

                        // Payment Period
                        DropDownList ddlPaymentPeriod = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentPeriod") as DropDownList);
                        dtCurrentTable.Rows[i]["InstallmentTypeTerm"] = ddlPaymentPeriod.Text;

                        // Percentage
                        TextBox percentage = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentPercent");
                        dtCurrentTable.Rows[i]["InstallmentInPercentage"] = percentage.Text;

                        // Payment mode
                        DropDownList ddlPaymentMode = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentMode") as DropDownList);
                        dtCurrentTable.Rows[i]["MOPTerm"] = ddlPaymentMode.Text;

                        // Amount
                        TextBox amount = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentAmount");
                        dtCurrentTable.Rows[i]["InstallmentAmount"] = amount.Text;
                    }
                    //Rebind the Grid with the current data to reflect changes   
                    gvPropertyInstallments.DataSource = dtCurrentTable;
                    gvPropertyInstallments.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DropDownList ddlPaymentPeriod = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentPeriod") as DropDownList);
                        TextBox percentage = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentPercent");
                        DropDownList ddlPaymentMode = (gvPropertyInstallments.Rows[i].Cells[1].FindControl("ddlPaymentMode") as DropDownList);
                        TextBox amount = (TextBox)gvPropertyInstallments.Rows[i].Cells[1].FindControl("txtInstallmentAmount");
                        HiddenField h1 = (HiddenField)gvPropertyInstallments.Rows[i].Cells[1].FindControl("hdnPurchaseScheduleID");

                        if (i < dt.Rows.Count - 1)
                        {
                            h1.Value = dt.Rows[i]["PurchaseScheduleID"].ToString();
                            ddlPaymentPeriod.SelectedValue = dt.Rows[i]["InstallmentTypeTerm"].ToString();
                            percentage.Text = dt.Rows[i]["InstallmentInPercentage"].ToString();
                            ddlPaymentMode.SelectedValue = dt.Rows[i]["MOPTerm"].ToString();
                            amount.Text = dt.Rows[i]["InstallmentAmount"].ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }
        protected void gvPropertyInstallments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    #region Payment Mode

                    DropDownList ddlPaymentMode = (e.Row.FindControl("ddlPaymentMode") as DropDownList);
                    ProjectTerm PaymentTerm = new ProjectTerm();
                    PaymentTerm.CompanyID = this.CompanyID;
                    PaymentTerm.Category = "PAYMENTMODE";
                    PaymentTerm.IsActive = true;

                    List<ProjectTerm> LstPaymentTerm = ProjectTermBLL.GetAll(PaymentTerm);
                    if (LstPaymentTerm.Count > 0)
                    {
                        ddlPaymentMode.DataSource = LstPaymentTerm;
                        ddlPaymentMode.DataTextField = "DisplayTerm";
                        ddlPaymentMode.DataValueField = "TermID";
                        ddlPaymentMode.DataBind();
                        ddlPaymentMode.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlPaymentMode.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    #endregion

                    #region Payment period

                    DropDownList ddlPaymentPeriod = (e.Row.FindControl("ddlPaymentPeriod") as DropDownList);
                    ProjectTerm InstallmentType = new ProjectTerm();
                    InstallmentType.CompanyID = this.CompanyID;
                    InstallmentType.Category = "PAYMENTPERIOD";
                    InstallmentType.IsActive = true;

                    List<ProjectTerm> LstInstallmentType = ProjectTermBLL.GetAll(InstallmentType);
                    if (LstInstallmentType.Count > 0)
                    {
                        ddlPaymentPeriod.DataSource = LstInstallmentType;
                        ddlPaymentPeriod.DataTextField = "DisplayTerm";
                        ddlPaymentPeriod.DataValueField = "TermID";
                        ddlPaymentPeriod.DataBind();
                        ddlPaymentPeriod.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                    }
                    else
                        ddlPaymentPeriod.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPropertyInstallmentRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                ImageButton lb = (ImageButton)e.Row.FindControl("btnRemoveRow");
                if (lb != null && dt != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void gvPropertyInstallments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditData"))
            {
                this.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                LoadAccess();
                LoadData();
            }
            else if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                this.PropertyID = this.PropertyID;
                Session.Add("Property", this.PropertyID);
                LoadPropertyInstallmentGrid();
            }
        }

        private void LoadPropertyInstallmentGrid()
        {
            Guid? PropertyID;
            if (this.PropertyID != Guid.Empty)
                PropertyID = this.PropertyID;
            else
                PropertyID = null;

            DataTable dt = new DataTable();
            DataRow dr = null;

            DataSet dsPropertyInstallmentDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "PROPERTYINSTALLMENTS", PropertyID);
            if (dsPropertyInstallmentDocumentList.Tables[0].Rows.Count != 0)
            {
                Guid landIssueTypeID = (Guid)dsPropertyInstallmentDocumentList.Tables[0].Rows[0]["TermID"];
                ViewState["PropertyInstallmentID"] = landIssueTypeID;
            }

            dt = dsPropertyInstallmentDocumentList.Tables[0];
            dt.Columns.Add(new DataColumn("PurchaseScheduleID", typeof(string)));
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("InstallmentTypeTerm", typeof(string))); //Installment type
            dt.Columns.Add(new DataColumn("InstallmentInPercentage", typeof(string))); //installment percentage
            dt.Columns.Add(new DataColumn("MOPTerm", typeof(string))); // Payment mode
            dt.Columns.Add(new DataColumn("InstallmentAmount", typeof(string))); // Installment amount
            dt.Rows[0]["RowNumber"] = "Installment 1";
            ViewState["CurrentTable"] = dt;
            dsPropertyInstallmentDocumentList.Tables.Clear();

            // DataTable to DataSet
            dsPropertyInstallmentDocumentList.Tables.Add(dt);
            gvPropertyInstallments.DataSource = dsPropertyInstallmentDocumentList;
            gvPropertyInstallments.DataBind();


        }


        /// <summary>
        /// Save purchase schedule data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Property objProperty = new Property();
                    PurchaseSchedule objPurchaseSchedule = new PurchaseSchedule();
                    PurchasePartnerSchedule objPurchasePartnerSchedule = new PurchasePartnerSchedule();

                    // property name
                    //if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
                    //    objProperty.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                    // property id
                    objProperty.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                    // purchase option
                    if (ddlPurchaseOption.SelectedValue != Guid.Empty.ToString())
                        objProperty.PurchaseOptionID = new Guid(ddlPurchaseOption.SelectedValue);
                    else
                        objProperty.PurchaseOptionID = null;

                    // Price 
                    if (!(txtPrice.Text.Trim().Equals("")))
                        objProperty.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                    else
                        objProperty.Price = null;

                    // Purchase Area
                    if (!(txtPurchaseArea.Text.Trim().Equals("")))
                        objProperty.PurchaseArea = Convert.ToDecimal(txtPurchaseArea.Text.Trim());
                    else
                        objProperty.PurchaseArea = null;

                    // Total Cost
                    if (!(txtTotalCost.Text.Trim().Equals("")))
                        objProperty.TotalCost = Convert.ToDecimal(txtTotalCost.Text.Trim());
                    else
                        objProperty.TotalCost = null;

                    // Update price, purchase area, total cost in mst_property
                    PropertyBLL.UpdatePropertyPurchase(objProperty);

                    // property id for purchase schedule
                    objPurchaseSchedule.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                   
                    DataSet ds = new DataSet();
                    ds = PurchaseScheduleBLL.GetPurchaseScheduleData(objPurchaseSchedule.PropertyID, this.CompanyID, null);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        var partnerIdList = new ArrayList();
                        var totalToInvestList = new ArrayList();
                        var purchaseScheduleIDList = new ArrayList();
                        var installmentNoList = new ArrayList();
                        
                        DataSet dsPropertyPartner = new DataSet();
                        dsPropertyPartner = PropertyPartnerBLL.GetPropertyPartnerData(null, Convert.ToString(ddlPropertyName.SelectedItem.Text), this.CompanyID);

                        for (int i = 0; i < dsPropertyPartner.Tables[0].Rows.Count; i++)
                        {
                            Guid partnerID = new Guid(dsPropertyPartner.Tables[0].Rows[i]["PartnerID"].ToString());
                            decimal partnerPercentage = Convert.ToDecimal(dsPropertyPartner.Tables[0].Rows[i]["PartnershipInPercentage"]);
                            decimal totalToInvest = Convert.ToDecimal(objProperty.TotalCost * partnerPercentage / 100);
                            
                            partnerIdList.Add(partnerID);
                            totalToInvestList.Add(totalToInvest);
                        }

                        for (int i = 0; i < gvPropertyInstallments.Rows.Count; i++)
                        {
                            // Installment No.
                            string installmentNo = gvPropertyInstallments.Rows[i].Cells[1].Text;
                            objPurchaseSchedule.Installment = installmentNo;

                            // Payment period
                            DropDownList ddlPaymentPeriod = (DropDownList)gvPropertyInstallments.Rows[i].FindControl("ddlPaymentPeriod");
                            objPurchaseSchedule.InstallmentTypeTerm = Convert.ToString(ddlPaymentPeriod.SelectedItem.Text);

                            // Installment Percentage
                            TextBox txtInstallmentPercent = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentPercent");
                            objPurchaseSchedule.InstallmentInPercentage = Convert.ToDecimal(txtInstallmentPercent.Text);

                            // Payment Mode
                            DropDownList ddlPaymentMode = (DropDownList)gvPropertyInstallments.Rows[i].FindControl("ddlPaymentMode");
                            objPurchaseSchedule.MOPTerm = ddlPaymentMode.SelectedItem.Text;

                            // Installment Amount
                            TextBox txtAmount = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentAmount");
                            objPurchaseSchedule.InstallmentAmount = Convert.ToDecimal(txtAmount.Text);
                            
                            PurchaseScheduleBLL.Save(objPurchaseSchedule);
                        }

                        // purchasePartnerSchedule insert
                        for (int i = 0; i < gvPropertyInstallments.Rows.Count; i++)
                        {
                            // property id
                            objPurchasePartnerSchedule.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                            // Payment period
                            DropDownList ddlPaymentPeriod = (DropDownList)gvPropertyInstallments.Rows[i].FindControl("ddlPaymentPeriod");
                            objPurchasePartnerSchedule.InstallmentTypeTerm = Convert.ToString(ddlPaymentPeriod.SelectedItem.Text);

                            // Installment Percentage
                            TextBox txtInstallmentPercent = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentPercent");
                            objPurchasePartnerSchedule.InstallmentInPercentage = Convert.ToDecimal(txtInstallmentPercent.Text);

                            // Payment Mode
                            DropDownList ddlPaymentMode = (DropDownList)gvPropertyInstallments.Rows[i].FindControl("ddlPaymentMode");
                            objPurchasePartnerSchedule.MOPTerm = ddlPaymentMode.SelectedItem.Text;

                            // Installment Amount
                            TextBox txtAmount = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentAmount");
                            objPurchasePartnerSchedule.InstallmentAmount = Convert.ToDecimal(txtAmount.Text);

                            //purchaseScheduleID
                            ds = PurchaseScheduleBLL.GetPurchaseScheduleData(objPurchaseSchedule.PropertyID, this.CompanyID, null);
                            for (int j = 0; j < dsPropertyPartner.Tables[0].Rows.Count; j++)
                            {
                                string purchaseScheduleIDs = Convert.ToString(ds.Tables[0].Rows[j]["PurchaseScheduleID"]);
                                purchaseScheduleIDList.Add(purchaseScheduleIDs);

                                
                            }
                            
                            //purchase schedule id and installment
                            objPurchasePartnerSchedule.PurchaseScheduleID = new Guid(purchaseScheduleIDList[i].ToString());

                            string installmentNos = Convert.ToString(ds.Tables[0].Rows[i]["Installment"]);
                            installmentNoList.Add(installmentNos);
                            objPurchasePartnerSchedule.Installment = installmentNoList[i].ToString();

                            // partnerID, TotalToInvest for purchasepartner_schedule
                            for (int index = 0; index < partnerIdList.Count; index++)
                            {
                                objPurchasePartnerSchedule.PartnerID = new Guid(partnerIdList[index].ToString());
                                objPurchasePartnerSchedule.TotalToInvest = Convert.ToDecimal(totalToInvestList[index].ToString());
                                PurchasePartnerScheduleBLL.Save(objPurchasePartnerSchedule);
                            }
                            IsMessage = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        }
                        
                        //Response.Redirect("~/Applications/SetUp/PurchaseScheduleList.aspx");
                    }
                    else
                    {
                        for (int i = 0; i < gvPropertyInstallments.Rows.Count; i++)
                        {
                            HiddenField h1 = (HiddenField)gvPropertyInstallments.Rows[i].FindControl("hdnPurchaseScheduleID");

                            // Installment No.
                            string installmentNo = gvPropertyInstallments.Rows[i].Cells[1].Text;
                            objPurchaseSchedule.Installment = installmentNo;

                            // Payment period
                            DropDownList ddlPaymentPeriod = (DropDownList)gvPropertyInstallments.Rows[i].FindControl("ddlPaymentPeriod");
                            objPurchaseSchedule.InstallmentTypeTerm = ddlPaymentPeriod.SelectedItem.Text;

                            // Installment Percentage
                            TextBox txtInstallmentPercent = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentPercent");
                            objPurchaseSchedule.InstallmentInPercentage = Convert.ToDecimal(txtInstallmentPercent.Text);

                            // Payment Mode
                            DropDownList ddlPaymentMode = (DropDownList)gvPropertyInstallments.Rows[i].FindControl("ddlPaymentMode");
                            objPurchaseSchedule.MOPTerm = ddlPaymentMode.SelectedItem.Text;

                            // Installment Amount
                            TextBox txtAmount = (TextBox)gvPropertyInstallments.Rows[i].FindControl("txtInstallmentAmount");
                            objPurchaseSchedule.InstallmentAmount = Convert.ToDecimal(txtAmount.Text);

                            if (h1.Value == "")
                            {
                                PurchaseScheduleBLL.Save(objPurchaseSchedule);
                                IsMessage = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                            }
                            else
                            {
                                objPurchaseSchedule.PurchaseScheduleID = new Guid(h1.Value);
                                PurchaseScheduleBLL.Update(objPurchaseSchedule);
                                IsMessage = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("PurchaseSchedule");
                Response.Redirect("~/Applications/SetUp/PurchaseScheduleList.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Add New Property Into the System
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session.Remove("PropertyID");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        private void ClearControl()
        {
            BindDDL();
            BindPurchaseOption();
            txtPrice.Text = "";
            txtPurchaseArea.Text = "";
            txtTotalCost.Text = "";
            this.PropertyID = Guid.Empty;
            LoadPropertyInstallmentGrid();
        }
    }
}