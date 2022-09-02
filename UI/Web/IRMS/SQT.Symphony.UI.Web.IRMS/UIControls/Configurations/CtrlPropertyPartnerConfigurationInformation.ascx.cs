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
    public partial class CtrlPropertyPartnerConfigurationInformation : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid PropertyPartnerID
        {
            get
            {
                return ViewState["PropertyPartnerID"] != null ? new Guid(Convert.ToString(ViewState["PropertyPartnerID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyPartnerID"] = value;
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
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPropertyPartnerInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                    if (Session["Property"] != null)
                    {
                        this.PropertyPartnerID = new Guid(Convert.ToString(Session["PropertyPartnerID"]));
                        LoadData();
                        Session["Property"] = null;
                    }
                    else
                        btnSave.Visible = true;
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
                Session.Remove("PropertyPartnerID");
                Response.Redirect("~/Applications/SetUp/PropertyPartnerList.aspx");
                //ClearControl();
                //btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
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
        private void LoadDefaultValue()
        {
            BindDDL();
            BindPartner();
        }

        private void LoadData()
        {
            BindDDL();
            BindPartner();
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

        /// <summary>
        /// Reset value on new form
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Session.Remove("PropertyPartnerID");
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        /// <summary>
        /// Clear control
        /// </summary>
        private void ClearControl()
        {
            BindDDL();
            BindPartner();
            this.PropertyPartnerID = Guid.Empty;
        }

        /// <summary>
        /// Load Access
        /// </summary>
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

        /// <summary>
        /// Add New Property Partner Into the System 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Check duplication

                    if (this.PropertyPartnerID != Guid.Empty)
                    {
                        PropertyPartner objUpdPropertyPartner = new PropertyPartner();
                        objUpdPropertyPartner = PropertyPartnerBLL.GetByPrimaryKey(this.PropertyPartnerID);

                        // Property name
                        if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
                            objUpdPropertyPartner.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        else
                            objUpdPropertyPartner.PropertyID = null;

                        // Partner name
                        if (ddlPartnerName.SelectedValue != Guid.Empty.ToString())
                            objUpdPropertyPartner.PartnerID = new Guid(ddlPartnerName.SelectedValue);
                        else
                            objUpdPropertyPartner.PartnerID = null;

                        PropertyPartnerBLL.Update(objUpdPropertyPartner);

                    }
                    else
                    {
                        PropertyPartner objInsPropertyPartner = new PropertyPartner();

                        // property name
                        if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
                            objInsPropertyPartner.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                        else
                            objInsPropertyPartner.PropertyID = null;

                        // Partner name
                        if (ddlPartnerName.SelectedValue != Guid.Empty.ToString())
                            objInsPropertyPartner.PartnerID = new Guid(ddlPartnerName.SelectedValue);
                        else
                            objInsPropertyPartner.PartnerID = null;

                        PropertyPartnerBLL.Save(objInsPropertyPartner);

                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}