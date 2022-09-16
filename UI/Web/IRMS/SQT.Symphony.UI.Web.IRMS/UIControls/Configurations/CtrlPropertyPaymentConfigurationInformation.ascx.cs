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
    public partial class CtrlPropertyPaymentConfigurationInformation : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid PropertyPaymentID
        {
            get
            {
                return ViewState["PropertyPaymentID"] != null ? new Guid(Convert.ToString(ViewState["PropertyPaymentID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyPaymentID"] = value;
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
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPropertyPaymentInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                    if (Session["PropertyPaymentID"] != null)
                    {
                        this.PropertyPaymentID = new Guid(Convert.ToString(Session["PropertyPaymentID"]));
                        LoadData(sender, e);
                        Session["PropertyPaymentID"] = null;
                    }
                    else
                        btnSave.Visible = true;
                }
            }
        }

        private void LoadDefaultValue()
        {
            BindDDL();
            BindInstallment();
            BindPaymentMode();
            BindGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.PropertyPaymentID != Guid.Empty)
                    {
                        PropertyPayment objUpdPropertyPayment = new PropertyPayment();
                        PropertyPayment objOldPropertyPaymentData = new PropertyPayment();

                        objUpdPropertyPayment = PropertyPaymentBLL.GetByPrimaryKey(this.PropertyPaymentID);
                        objOldPropertyPaymentData = PropertyPaymentBLL.GetByPrimaryKey(this.PropertyPaymentID);

                        // property id
                        objUpdPropertyPayment.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                        // installment 
                        objUpdPropertyPayment.PropertyScheduleID = new Guid(ddlPurchaseSchedule.SelectedValue);

                        // Amount
                        if (!(txtAmount.Text.Trim().Equals("")))
                            objUpdPropertyPayment.AmountPaid = Convert.ToDecimal(txtAmount.Text.Trim());
                        else
                            objUpdPropertyPayment.AmountPaid = null;

                        // Payment Mode
                        if (ddlPaymentMode.SelectedValue != Guid.Empty.ToString())
                            objUpdPropertyPayment.MOPTerm = ddlPaymentMode.SelectedValue;
                        else
                            objUpdPropertyPayment.MOPTerm = null;

                        // Description
                        if (!(txtDescription.Text.Trim().Equals("")))
                            objUpdPropertyPayment.Description = txtDescription.Text.Trim();
                        else
                            objUpdPropertyPayment.Description = null;

                        PropertyPaymentBLL.Update(objUpdPropertyPayment);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPropertyPaymentData.ToString(), objUpdPropertyPayment.ToString(), "tra_propertypayment");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.PropertyPaymentID = objUpdPropertyPayment.PropertyPaymentID;
                    }
                    else
                    {
                        PropertyPayment objPropertyPayment = new PropertyPayment();
                        DataSet ds = new DataSet();

                        // property id
                        objPropertyPayment.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                        // installment 
                        objPropertyPayment.PropertyScheduleID = new Guid(ddlPurchaseSchedule.SelectedValue);

                        // Amount
                        if (!(txtAmount.Text.Trim().Equals("")))
                            objPropertyPayment.AmountPaid = Convert.ToDecimal(txtAmount.Text.Trim());
                        else
                            objPropertyPayment.AmountPaid = null;

                        // Payment Mode
                        if (ddlPaymentMode.SelectedValue != Guid.Empty.ToString())
                            objPropertyPayment.MOPTerm = ddlPaymentMode.SelectedValue;
                        else
                            objPropertyPayment.MOPTerm = null;

                        // Description
                        if (!(txtDescription.Text.Trim().Equals("")))
                            objPropertyPayment.Description = txtDescription.Text.Trim();
                        else
                            objPropertyPayment.Description = null;

                        PropertyPaymentBLL.Save(objPropertyPayment);
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.PropertyPaymentID = objPropertyPayment.PropertyPaymentID;
                    }
                    LoadData(sender, e);
                    BindGrid();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void fnPurchaseScheduleInstallment(object sender, EventArgs e)
        {
            string propertyID = string.Empty;
            if (ViewState["PropertyID"] != null)
            {
                propertyID = ViewState["PropertyID"].ToString();
            }
            else
            {
                propertyID = ddlPropertyName.SelectedValue;
            }

            DataSet ds = new DataSet();
            ds = PurchaseScheduleBLL.GetPurchaseScheduleData(new Guid(propertyID), this.CompanyID, null);
            DataView Dv = new DataView(ds.Tables[0]);

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Installment"] != DBNull.Value)
                {
                    ddlPurchaseSchedule.DataSource = Dv;
                    ddlPurchaseSchedule.DataTextField = "Installment";
                    ddlPurchaseSchedule.DataValueField = "PurchaseScheduleID";
                    ddlPurchaseSchedule.DataBind();
                    ddlPurchaseSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            else
            {
                ddlPurchaseSchedule.Items.Clear();
                BindInstallment();
            }
        }

        private void LoadData(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = PropertyPaymentBLL.GetPropertyPaymentData(this.PropertyPaymentID, this.PropertyID, this.PropertyPurchaseScheduleID, null);

            if (ds.Tables[0].Rows.Count != 0)
            {
                BindDDL();
                // property name
                if (Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != null)
                    ddlPropertyName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyID"]);

                ViewState["PropertyID"] = ddlPropertyName.SelectedValue;
                fnPurchaseScheduleInstallment(sender, e);

                // Installment
                if (Convert.ToString(ds.Tables[0].Rows[0]["Installment"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["Installment"]) != null)
                    ddlPurchaseSchedule.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PurchaseScheduleID"]);

                // Amount
                txtAmount.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();

                // Payment mode
                if (Convert.ToString(ds.Tables[0].Rows[0]["MOPTerm"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["MOPTerm"]) != null)
                    ddlPaymentMode.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["MOPTerm"]);

                // Description
                txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            string PropertyName = null;

            if (!(txtSPropertyName.Text.Trim().Equals("")))
                PropertyName = txtSPropertyName.Text.Trim();
            else
                PropertyName = null;

            PropertyPayment objUpdPropertyPartner = new PropertyPayment();
            DataSet ds = PropertyPaymentBLL.GetPropertyPaymentData(null, null, null,  PropertyName);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPropertyPaymentList.DataSource = dv;
            grdPropertyPaymentList.DataBind();
        }

        protected void grdPropertyPaymentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.PropertyPaymentID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData(sender, e);
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PropertyPaymentID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
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

        public void BindPaymentMode()
        {
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
        }

        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyPaymentInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
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
            Session.Remove("PropertyPaymentID");
            ClearControl();
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

        protected void btnPropertyPartnerYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PropertyPaymentID != Guid.Empty)
                {
                    msgbx.Hide();
                    PropertyPayment objDelete = PropertyPaymentBLL.GetByPrimaryKey(this.PropertyPaymentID);
                    PropertyPayment objOldPropertyPaymentDeleteData = PropertyPaymentBLL.GetByPrimaryKey(this.PropertyPaymentID);

                    PropertyPaymentBLL.Delete(objDelete.PropertyPaymentID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objOldPropertyPaymentDeleteData.ToString(), null, "tra_propertypayment");

                    IsMessage = true;
                    lblErrorMessage.Text = "Delete Success.";
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPropertyPartnerNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("PropertyPaymentID");
                Response.Redirect("~/Applications/SetUp/PropertyPaymentList.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            BindDDL();
            BindInstallment();
            txtAmount.Text = "";
            BindPaymentMode();
            txtDescription.Text = "";
            this.PropertyPaymentID = Guid.Empty;
            BindGrid();
        }

        public void BindInstallment()
        {
            ddlPurchaseSchedule.Items.Clear();
            ddlPurchaseSchedule.DataBind();
            ddlPurchaseSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

    }
}