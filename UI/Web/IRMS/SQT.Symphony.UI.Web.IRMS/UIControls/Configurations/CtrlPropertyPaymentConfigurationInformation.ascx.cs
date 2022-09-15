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
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPartnerPaymentInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                    if (Session["PartnerPaymentID"] != null)
                    {
                        this.PropertyPaymentID = new Guid(Convert.ToString(Session["PartnerPaymentID"]));
                        LoadData();
                        Session["PartnerPaymentID"] = null;
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    PropertyPayment objPropertyPayment = new PropertyPayment();
                    DataSet ds = new DataSet();
                    // property id
                    objPropertyPayment.PropertyID = new Guid(ddlPropertyName.SelectedValue);

                    // installment 
                    objPropertyPayment.PropertyScheduleID = new Guid(ddlPurchaseSchedule.SelectedValue);
                    //objPartnerPayment.Installment = ddlPurchaseSchedule.SelectedItem.Text;

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
                    LoadData();

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
            ds = PropertyPaymentBLL.GetPropertyPaymentData(this.PropertyPaymentID, this.PropertyID, this.PropertyPurchaseScheduleID, null);

            if (ds.Tables[0].Rows.Count != 0)
            {
                BindDDL();
                BindInstallment();


                // property name
                if (Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != null)
                    ddlPropertyName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyID"]);

                // Installment
                if (Convert.ToString(ds.Tables[0].Rows[0]["Installment"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["Installment"]) != null)
                    ddlPurchaseSchedule.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PurchaseScheduleID"]);

                // Amount
                txtAmount.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();

                // Payment mode
                if (Convert.ToString(ds.Tables[0].Rows[0]["MOPTerm"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["MOPTerm"]) != null)
                    ddlPaymentMode.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["MOPTerm"]));

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

            PropertyPartner objUpdPropertyPartner = new PropertyPartner();
            DataSet ds = PropertyPartnerBLL.GetPropertyPartnerData(null, PropertyName, this.CompanyID);
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
                    LoadData();
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
        }

        public void BindInstallment()
        {
            ddlPurchaseSchedule.Items.Clear();
            ddlPurchaseSchedule.DataBind();
            ddlPurchaseSchedule.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        public void fnPurchaseScheduleInstallment(object sender, EventArgs e)
        {
            string propertyID = ddlPropertyName.SelectedValue;

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
    }
}