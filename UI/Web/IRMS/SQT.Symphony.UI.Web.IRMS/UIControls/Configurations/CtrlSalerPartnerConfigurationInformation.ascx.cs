using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlSalerPartnerConfigurationInformation : System.Web.UI.UserControl
    {
        public bool IsInsert = false;
        public bool IsUpdate = false;
        public bool IsMessage = false;
        public Guid PartnerID
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationSalerPartner.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();


                if (!IsPostBack)
                {
                    LoadDefaultValue();
                    if (Session["PartnerID"] != null)
                    {
                        this.PartnerID = new Guid(Convert.ToString(Session["PartnerID"]));
                        LoadData();
                        Session["PartnerID"] = null;
                    }
                    else
                        btnSave.Visible = true;
                }
            }
        }
        private void LoadData()
        {
            DataSet ds = new DataSet();
            ds = SalerPartnerBLL.GetByIdWise_SalePartnerData(this.PartnerID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                txtMiddleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["MiddleName"]);
                txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                txtMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
            }
        }
        private void BindGrid()
        {

            string FirstName = null;
            string MobileNo = null;
            
            DataSet ds = SalerPartnerBLL.GetSalerPartnerData(FirstName, MobileNo);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "FirstName Asc";
            grdSalerList.DataSource = dv;
            grdSalerList.DataBind();

        }
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationSalerPartner.aspx", new Guid(Convert.ToString(Session["UserID"])));
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
                BindGrid();
                BindSystemSetupData();

            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session.Remove("PartnerID");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        private void BindSystemSetupData()
        {
            List<BusinessLogic.Configuration.DTO.SalerPartner> lstLoadSalerConfigurationData = null;
            BusinessLogic.Configuration.DTO.SalerPartner objSalerConfiguration = new BusinessLogic.Configuration.DTO.SalerPartner();

            lstLoadSalerConfigurationData = SalerPartnerBLL.GetAll(objSalerConfiguration);

            if (lstLoadSalerConfigurationData.Count != 0)
            {
                BusinessLogic.Configuration.DTO.SalerPartner objLoadPCData = new BusinessLogic.Configuration.DTO.SalerPartner();
                objLoadPCData = lstLoadSalerConfigurationData[0];

                txtFirstName.Text = Convert.ToString(objLoadPCData.FirstName);
                txtLastName.Text = Convert.ToString(objLoadPCData.MiddleName);
                txtMiddleName.Text = Convert.ToString(objLoadPCData.LastName);
                txtMobileNo.Text = Convert.ToString(objLoadPCData.MobileNo);
            }
        }
        protected void btnSave_SalerPartner(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //BusinessLogic.Configuration.DTO.SalerPartner DuplicateobjSP = new BusinessLogic.Configuration.DTO.SalerPartner();
                    //List<BusinessLogic.Configuration.DTO.SalerPartner> DuplicateSalerList = SalerPartnerBLL.GetAll(DuplicateobjSP);
                    //if (DuplicateSalerList.Count > 0)
                    //{
                    //    if (this.PartnerID != Guid.Empty)
                    //    {
                    //        if (Convert.ToString((DuplicateSalerList[0].PartnerID)) != Convert.ToString(this.PartnerID.ToString()))
                    //        {
                    //            IsMessage = true;
                    //            lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        IsMessage = true;
                    //        lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                    //        return;
                    //    }
                    //}
                    if (this.PartnerID != Guid.Empty)
                    {
                        BusinessLogic.Configuration.DTO.SalerPartner objSP = new BusinessLogic.Configuration.DTO.SalerPartner();
                        objSP.FirstName = txtFirstName.Text.Trim();
                        objSP.MiddleName = txtMiddleName.Text.Trim();
                        objSP.LastName = txtLastName.Text.Trim();
                        objSP.MobileNo = txtMobileNo.Text.Trim();
                        objSP.PartnerID = this.PartnerID;
                        objSP.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        SalerPartnerBLL.Update(objSP);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objSP.ToString(), objSP.ToString(), "mst_SalerPartner");

                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.PartnerID = objSP.PartnerID;
                        Session["ConfigurationSalerPartner"] = objSP;
                        LoadData();
                        BindGrid();
                    }
                    else {
                        BusinessLogic.Configuration.DTO.SalerPartner objSP = new BusinessLogic.Configuration.DTO.SalerPartner();
                        objSP.FirstName = txtFirstName.Text.Trim();
                        objSP.MiddleName = txtMiddleName.Text.Trim();
                        objSP.LastName = txtLastName.Text.Trim();
                        objSP.MobileNo = txtMobileNo.Text.Trim();
                        objSP.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        SalerPartnerBLL.Save(objSP);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objSP.ToString(), objSP.ToString(), "mst_SalerPartner");

                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.PartnerID = objSP.PartnerID;
                        Session["ConfigurationSalerPartner"] = objSP;
                        LoadData();
                        BindGrid();
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("SalerPartner");
                Response.Redirect("~/Applications/SetUp/SalerPartner.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void grdSalerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.PartnerID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label4.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PartnerID = new Guid(Convert.ToString(e.CommandArgument));
                    Deletemsgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void grdSalerList_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void btnSalerYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PartnerID != Guid.Empty)
                {
                    Deletemsgbx.Hide();
                    SalerPartnerBLL.Delete(this.PartnerID);
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
        protected void btnSalerNo_Click(object sender, EventArgs e)
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
        private void ClearControl()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtMobileNo.Text = "";
            BindGrid();
            this.PartnerID = Guid.Empty;  
        }
    }
}