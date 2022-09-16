using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlVendorConfigurationInformation : System.Web.UI.UserControl
    {
        public bool IsInsert = false;
        public bool IsUpdate = false;
        public bool IsMessage = false;
        public Guid VendorID
        {
            get
            {
                return ViewState["VendorID"] != null ? new Guid(Convert.ToString(ViewState["VendorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["VendorID"] = value;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationVendor.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                    LoadAccess();
                
                if (!IsPostBack)
                {
                    LoadDefaultValue();
                    if (Session["VendorID"] != null)
                    {
                        this.VendorID = new Guid(Convert.ToString(Session["VendorID"]));
                        LoadData();
                        Session["VendorID"] = null;
                    }
                    else
                        btnSave.Visible = true;
                }
            }

        }
        private void LoadData()
        {
            DataSet ds = new DataSet();
            ds = VendorBLL.GetByIdWise_VendorData(this.VendorID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtContactName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactName"]);
                txtVendorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["VendorName"]);
                //txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                //txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                ddlTypeID.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TypeID"]);
                txtVendorDetail.Text = Convert.ToString(ds.Tables[0].Rows[0]["VendorDetail"]);
                txtMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
               
            }
        }
        protected void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationVendor.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        private void LoadDefaultValue()
        {
            try
            {
                VendorType();
                BindGrid();
                
                //BindSystemSetupData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void VendorType()
        {
            List<Vendor> lstVendor = null;
            Vendor objVendor = new Vendor();

            objVendor.category = "VENDORTYPE_TERM";
            lstVendor = VendorBLL.GetAll(objVendor);
            if (lstVendor.Count != 0)
            {
                lstVendor.Sort((Vendor p1, Vendor p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));

                ddlTypeID.DataSource = lstVendor;
                ddlTypeID.DataTextField = "DisplayTerm";
                ddlTypeID.DataValueField = "TermID";
                ddlTypeID.DataBind();
                ddlTypeID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlTypeID.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlTypeID.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
        }
        private void BindGrid()
        {
            string VendorName = null;
            string MobileNo = null;

            DataSet ds = VendorBLL.GetVenderData(VendorName, MobileNo);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "VendorName Asc";
            grdVendorList.DataSource = dv;
            grdVendorList.DataBind();
        }
        //private void BindSystemSetupData()
        //{
        //    List<Vendor> lstLoadVendor = null;
        //    Vendor objVendorConfiguration = new Vendor();

        //    lstLoadVendor = SalerPartnerBLL.GetAll(objVendorConfiguration);

        //    if (lstLoadSalerConfigurationData.Count != 0)
        //    {
        //        BusinessLogic.Configuration.DTO.SalerPartner objLoadPCData = new BusinessLogic.Configuration.DTO.SalerPartner();
        //        objLoadPCData = lstLoadSalerConfigurationData[0];

        //        txtFirstName.Text = Convert.ToString(objLoadPCData.FirstName);
        //        txtLastName.Text = Convert.ToString(objLoadPCData.MiddleName);
        //        txtMiddleName.Text = Convert.ToString(objLoadPCData.LastName);
        //        txtMobileNo.Text = Convert.ToString(objLoadPCData.MobileNo);
        //    }
        //}
        protected void Save_Vendor(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                try{
                    if (this.VendorID != Guid.Empty)
                    {
                        Vendor objVender = new Vendor();
                        objVender.VendorName = txtVendorName.Text.Trim();
                        objVender.ContactName = txtContactName.Text.Trim();
                        //objVender.Emaill = txtEmail.Text.Trim();
                        objVender.MobileNo = txtMobileNo.Text.Trim();
                        objVender.VendorDetail = txtVendorDetail.Text.Trim();
                        objVender.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                        objVender.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objVender.VendorID = this.VendorID;
                        objVender.TypeID = new Guid(ddlTypeID.SelectedValue);
                        VendorBLL.Update(objVender);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objVender.ToString(), objVender.ToString(), "mst_Vendor");

                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.VendorID = objVender.VendorID;
                        Session["ConfigurationVendor"] = objVender;
                        LoadData();
                        BindGrid();
                    }
                    else
                    {
                        Vendor objVender = new Vendor();
                        objVender.VendorName = txtVendorName.Text.Trim();
                        objVender.ContactName = txtContactName.Text.Trim();
                        //objVender.Emaill = txtEmail.Text.Trim();
                        objVender.MobileNo = txtMobileNo.Text.Trim();
                        objVender.VendorDetail = txtVendorDetail.Text.Trim();
                        objVender.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                        objVender.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objVender.TypeID = new Guid(ddlTypeID.SelectedValue);
                        VendorBLL.Insert(objVender);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objVender.ToString(), objVender.ToString(), "mst_Vendor");

                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.VendorID = objVender.VendorID;
                        Session["ConfigurationVendor"] = objVender;
                        LoadData();
                        BindGrid();
                    }
                    
                }
                catch(Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
        protected void grdVendorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.VendorID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label4.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.VendorID = new Guid(Convert.ToString(e.CommandArgument));
                    Deletemsgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void grdVendorList_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session.Remove("VendorID");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        private void ClearControl()
        {
            txtContactName.Text = "";
            txtVendorName.Text = "";
            //txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtVendorDetail.Text = "";
            BindGrid();
            this.VendorID = Guid.Empty;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("VendorID");
                Response.Redirect("~/Applications/SetUp/Vendor.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnVendorYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VendorID != Guid.Empty)
                {
                    Deletemsgbx.Hide();
                    VendorBLL.Delete(this.VendorID);
                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnVendorNo_Click(object sender, EventArgs e)
        {
            try
            {
                Deletemsgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}