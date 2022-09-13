using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPartnerPaymentConfigurationInformation : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid PartnerPaymentID
        {
            get
            {
                return ViewState["PartnerPaymentID"] != null ? new Guid(Convert.ToString(ViewState["PartnerPaymentID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PartnerPaymentID"] = value;
            }
        }
        public string PropertyName
        {
            get
            {
                return ViewState["PropertyName"] != null ? Convert.ToString(ViewState["PropertyName"]) : string.Empty;
            }
            set
            {
                ViewState["PropertyName"] = value;
            }
        }
        public Guid? PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
            }
        }
        
        public Guid? PropertyPurchaseScheduleID
        {
            get
            {
                return ViewState["PropertyPurchaseScheduleID"] != null ? new Guid(Convert.ToString(ViewState["PropertyPurchaseScheduleID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyPurchaseScheduleID"] = value;
            }
        }
        public Guid? PartnerID
        {
            get
            {
                return ViewState["PartnerID"] != null ? new Guid(Convert.ToString(ViewState["PartnerID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PartnerID"] = value;
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPartnerPaymentInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    //LoadDefaultValue();
                    if (Session["PartnerPaymentID"] != null)
                    {
                        this.PartnerPaymentID = new Guid(Convert.ToString(Session["PartnerPaymentID"]));
                        LoadData();
                        Session["PartnerPaymentID"] = null;
                    }
                    else
                    {
                        LoadDefaultValue();
                    }
                }
            }
        }

        private void LoadDefaultValue()
        {
            BindDDL();
            BindPartner();
            BindPurchaseSchedule();
            BindPartnerPaymentGrid();
        }

        private void BindPartnerPaymentGrid()
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
            dt.Columns.Add(new DataColumn("PartnerPaymentID", typeof(string)));
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PaymentAmount", typeof(string))); // Installment amount
            dt.Columns.Add(new DataColumn("MOPTerm", typeof(string))); // Payment mode
            dt.Columns.Add(new DataColumn("Description", typeof(string))); //Description

            ViewState["CurrentTable"] = dt;
            dsPropertyInstallmentDocumentList.Tables.Clear();

            // DataTable to DataSet
            dsPropertyInstallmentDocumentList.Tables.Add(dt);
            grdPartnerPayments.DataSource = dsPropertyInstallmentDocumentList;
            grdPartnerPayments.DataBind();

        }

        public void BindPurchaseSchedule()
        {
            string PurchaseScheduleQuery = string.Empty;
            PurchaseScheduleQuery = "Select PurchaseScheduleID From propertypurchase_schedule Where IsActive = 1";
            DataSet Dst = InvestorBLL.GetSearchData(PurchaseScheduleQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlPurchaseSchedule.DataSource = Dv;
                ddlPurchaseSchedule.DataTextField = "PurchaseScheduleID";
                ddlPurchaseSchedule.DataValueField = "PurchaseScheduleID";
                ddlPurchaseSchedule.DataBind();
                ddlPurchaseSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        public void BindPartner()
        {
            string PartnerQuery = string.Empty;
            PartnerQuery = "Select Distinct(DisplayName), PartnerID From mst_partner Where IsActive = 1";
            DataSet Dst = InvestorBLL.GetSearchData(PartnerQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlPartnerName.DataSource = Dv;
                ddlPartnerName.DataTextField = "DisplayName";
                ddlPartnerName.DataValueField = "PartnerID";
                ddlPartnerName.DataBind();
                ddlPartnerName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyPartnerInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
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

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session.Remove("PartnerPaymentID");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    PartnerPayment objPartnerPayment = new PartnerPayment();
                    //DataSet ds = new DataSet();
                    //ds = PartnerPaymentBLL.GetPartnerPaymentData(objPartnerPayment.PropertyID, objPartnerPayment.PartnerID, objPartnerPayment.PropertyPurchaseScheduleID, this.CompanyID);

                    if (this.PartnerPaymentID != Guid.Empty)
                    {
                        objPartnerPayment.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        objPartnerPayment.PartnerID = new Guid(ddlPartnerName.SelectedValue);
                        objPartnerPayment.PropertyPurchaseScheduleID = new Guid(ddlPurchaseSchedule.SelectedValue);

                        for (int i = 0; i < grdPartnerPayments.Rows.Count; i++)
                        {
                            // Amount
                            TextBox txtAmount = (TextBox)grdPartnerPayments.Rows[i].FindControl("txtInstallmentAmount");
                            objPartnerPayment.PaymentAmount = Convert.ToDecimal(txtAmount.Text);

                            // Payment Mode
                            DropDownList ddlPaymentMode = (DropDownList)grdPartnerPayments.Rows[i].FindControl("ddlPaymentMode");
                            objPartnerPayment.MOPTerm = ddlPaymentMode.SelectedItem.Text;

                            // Description
                            TextBox txtDescription = (TextBox)grdPartnerPayments.Rows[i].FindControl("txtDescription");
                            objPartnerPayment.Description = txtDescription.Text;

                            PartnerPaymentBLL.Save(objPartnerPayment);
                            IsMessage = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        }
                    }

                    //if (ds.Tables[0].Rows.Count == 0)
                    //{
                       
                    //}
                    //else
                    //{

                    //}

                    LoadData();
                    //BindGrid();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        private void LoadData()
        {
            DataSet ds = new DataSet();
            ds = PartnerPaymentBLL.GetPartnerPaymentData(this.PropertyID, this.PartnerID, this.PropertyPurchaseScheduleID, null);

            if (ds.Tables[0].Rows.Count != 0)
            {
                BindDDL();
                BindPartner();
                BindPurchaseSchedule();

                // property name
                if (Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != null)
                    ddlPropertyName.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PropertyID"]));

                // partner name
                if (Convert.ToString(ds.Tables[0].Rows[0]["PartnerName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PartnerName"]) != null)
                    ddlPartnerName.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PartnerID"]));

                // purchase schedule 
                //if (Convert.ToString(ds.Tables[0].Rows[0]["PartnerName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PartnerName"]) != null)
                //    ddlPartnerName.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PartnerID"]));

                BindPartnerPaymentGrid();
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("PartnerPaymentID");
                Response.Redirect("~/Applications/SetUp/PartnerPaymentList.aspx");
                //ClearControl();
                //btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindDDL()
        {
            string PropertyNameQuery = string.Empty;
            PropertyNameQuery = "Select Distinct(PropertyName), PropertyID From mst_Property Where IsActive = 1";
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

        protected void btnPropertyYes_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.PropertyID != Guid.Empty)
            //    {
            //        msgbx.Hide();
            //        List<Documents> lstDocuments = new List<Documents>();
            //        Property objDelete = PropertyBLL.GetByPrimaryKey(this.PropertyID);
            //        Property objOldPropertyDeleteData = PropertyBLL.GetByPrimaryKey(this.PropertyID);

            //        objDelete.IsActive = false;

            //        Guid AddressID = (Guid)(objDelete.AddressID);
            //        Address objDelAddress = new Address();
            //        objDelAddress = AddressBLL.GetByPrimaryKey(AddressID);
            //        objDelAddress.IsActive = false;

            //        //PropertyBLL.Update(objDelete, objDelAddress, lstDocuments);
            //        PropertyBLL.Delete(objDelete);
            //        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objOldPropertyDeleteData.ToString(), null, "mst_Property");

            //        IsMessage = true;
            //        lblErrorMessage.Text = "Delete Success.";
            //    }
            //    ClearControl();
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }
        
        protected void btnPropertyNo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    msgbx.Hide();
            //    ClearControl();
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            //    MessageBox.Show(ex.Message.ToString());
            //}

        }

        protected void gvPartnerPaymentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.PartnerPaymentID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PartnerPaymentID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPartnerPaymentList_RowCommand(object sender, GridViewCommandEventArgs e)
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
                BindPartnerPaymentGrid();
            }
        }

        protected void grdPartnerPaymentRowCreated(object sender, GridViewRowEventArgs e)
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

        protected void gvPartnerPaymentRowCreated(object sender, GridViewRowEventArgs e)
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

        protected void grdPartnerPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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
            }
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
                        HiddenField h1 = (HiddenField)grdPartnerPayments.Rows[i].Cells[1].FindControl("hdnPartnerPaymentID");
                        dtCurrentTable.Rows[i]["PartnerPaymentID"] = h1.Value;

                        // Payment Amount
                        TextBox amount = (TextBox)grdPartnerPayments.Rows[i].Cells[1].FindControl("txtInstallmentAmount");
                        dtCurrentTable.Rows[i]["InstallmentAmount"] = amount.Text;

                        // Payment Period
                        DropDownList ddlPaymentMode = (grdPartnerPayments.Rows[i].Cells[1].FindControl("ddlPaymentMode") as DropDownList);
                        dtCurrentTable.Rows[i]["MOPTerm"] = ddlPaymentMode.Text;

                        // Description
                        TextBox description = (TextBox)grdPartnerPayments.Rows[i].Cells[1].FindControl("txtDescription");
                        dtCurrentTable.Rows[i]["Description"] = description.Text;
                    }
                    //Rebind the Grid with the current data to reflect changes   
                    grdPartnerPayments.DataSource = dtCurrentTable;
                    grdPartnerPayments.DataBind();
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
                        HiddenField h1 = (HiddenField)grdPartnerPayments.Rows[i].Cells[1].FindControl("hdnPartnerPaymentID");
                        TextBox amount = (TextBox)grdPartnerPayments.Rows[i].Cells[1].FindControl("txtInstallmentAmount");
                        DropDownList ddlPaymentMode = (grdPartnerPayments.Rows[i].Cells[1].FindControl("ddlPaymentMode") as DropDownList);
                        TextBox description = (TextBox)grdPartnerPayments.Rows[i].Cells[1].FindControl("txtDescription");

                        if (i < dt.Rows.Count - 1)
                        {
                            h1.Value = dt.Rows[i]["PartnerPaymentID"].ToString();
                            amount.Text = dt.Rows[i]["InstallmentAmount"].ToString();
                            ddlPaymentMode.SelectedValue = dt.Rows[i]["MOPTerm"].ToString();
                            description.Text = dt.Rows[i]["Description"].ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }

        protected void btnPartnerPaymentNo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    msgbx.Hide();
            //    ClearControl();
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            //    MessageBox.Show(ex.Message.ToString());
            //}

        }

        private void ClearControl()
        {
            BindDDL();
            BindPartner();
            BindPurchaseSchedule();
            BindPartnerPaymentGrid();
            //txtTotalToInvest.Text = txtTotalToInvest.Text = "";
            //txtDescription.Text = txtDescription.Text = "";
            this.PartnerPaymentID = Guid.Empty;
        }


    }
}