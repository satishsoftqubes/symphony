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
                    if (Session["PropertyPartnerID"] != null)
                    {
                        this.PropertyPartnerID = new Guid(Convert.ToString(Session["PropertyPartnerID"]));
                        LoadData();
                        Session["PropertyPartnerID"] = null;
                        Session["PropertyName"] = null;
                    }
                    else
                        btnSave.Visible = true;
                }
            }
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
            grdPropertyPartnerList.DataSource = dv;
            grdPropertyPartnerList.DataBind();
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
            BindGrid();
           // LoadData();
        }

        private void LoadData()
        {
            DataSet ds = new DataSet();
            ds = PropertyPartnerBLL.GetPropertyPartnerData(this.PropertyPartnerID,  null, this.CompanyID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                BindDDL();
                BindPartner();

                // property name
                if (Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]) != null)
                    ddlPropertyName.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PropertyID"]));

                // partner name
                if (Convert.ToString(ds.Tables[0].Rows[0]["PartnerName"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PartnerName"]) != null)
                    ddlPartnerName.SelectedValue = Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["PartnerID"]));

                txtPartnershipInPercentage.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartnershipInPercentage"]);
                txtTotalToInvest.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalToInvest"]);
                txtTotalDue.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalDue"]);
                txtTotalInvested.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalInvested"]);
                txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
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

        protected void grdPropertyPartnerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.PropertyPartnerID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PropertyPartnerID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyPartnerList_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnPropertyPartnerYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PropertyPartnerID != Guid.Empty)
                {
                    msgbx.Hide();
                    PropertyPartner objDelete = PropertyPartnerBLL.GetByPrimaryKey(this.PropertyPartnerID);
                    PropertyPartner objOldPropertyDeleteData = PropertyPartnerBLL.GetByPrimaryKey(this.PropertyPartnerID);

                    objDelete.IsActive = false;

                    PropertyPartnerBLL.Delete(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objOldPropertyDeleteData.ToString(), null, "mst_PropertyPartner");

                    IsMessage = true;
                    lblErrorMessage.Text = "Delete Success.";
                }
                ClearControl();
                BindGrid();
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

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
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
            txtPartnershipInPercentage.Text = txtPartnershipInPercentage.Text = "";
            txtTotalToInvest.Text = txtTotalToInvest.Text = "";
            txtTotalDue.Text = txtTotalDue.Text = "";
            txtTotalInvested.Text = txtTotalInvested.Text = "";
            txtDescription.Text = txtDescription.Text = "";
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
                        PropertyPartner objOldPropertyPartnerData = new PropertyPartner();

                        objUpdPropertyPartner = PropertyPartnerBLL.GetByPrimaryKey(this.PropertyPartnerID);
                        objOldPropertyPartnerData = PropertyPartnerBLL.GetByPrimaryKey(this.PropertyPartnerID);

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
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldPropertyPartnerData.ToString(), objUpdPropertyPartner.ToString(), "mst_PropertyPartner");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.PropertyPartnerID = objUpdPropertyPartner.PropertyPartnerID;

                    }
                    else
                    {
                        PropertyPartner objInsPropertyPartner = new PropertyPartner();

                        // property name
                        if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
                        {
                            objInsPropertyPartner.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            this.PropertyName = ddlPropertyName.SelectedItem.Text;
                        }
                        else
                            objInsPropertyPartner.PropertyID = null;

                        // Partner name
                        if (ddlPartnerName.SelectedValue != Guid.Empty.ToString())
                            objInsPropertyPartner.PartnerID = new Guid(ddlPartnerName.SelectedValue);
                        else
                            objInsPropertyPartner.PartnerID = null;

                        // Partnership In Percentage                        
                        if (!(txtPartnershipInPercentage.Text.Trim().Equals("")))
                            objInsPropertyPartner.PartnershipInPercentage = Convert.ToDecimal(txtPartnershipInPercentage.Text.Trim());
                        else
                            objInsPropertyPartner.PartnershipInPercentage = null;

                        // Total to invest 
                        if (!(txtTotalToInvest.Text.Trim().Equals("")))
                            objInsPropertyPartner.TotalToInvest = Convert.ToDecimal(txtTotalToInvest.Text.Trim());
                        else
                            objInsPropertyPartner.TotalToInvest = null;

                        // total due
                        if (!(txtTotalDue.Text.Trim().Equals("")))
                            objInsPropertyPartner.TotalDue = Convert.ToDecimal(txtTotalDue.Text.Trim());
                        else
                            objInsPropertyPartner.TotalDue = null;

                        //total invested
                        if (!(txtTotalInvested.Text.Trim().Equals("")))
                            objInsPropertyPartner.TotalInvested = Convert.ToDecimal(txtTotalInvested.Text.Trim());
                        else
                            objInsPropertyPartner.TotalInvested = null;

                        //total invested
                        if (!(txtDescription.Text.Trim().Equals("")))
                            objInsPropertyPartner.Description = txtDescription.Text.Trim();
                        else
                            objInsPropertyPartner.Description = null;

                        PropertyPartnerBLL.Save(objInsPropertyPartner);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objInsPropertyPartner.ToString(), objInsPropertyPartner.ToString(), "mst_PropertyPartner");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.PropertyPartnerID = objInsPropertyPartner.PropertyPartnerID;
                        this.PropertyID = objInsPropertyPartner.PropertyID;
                    }
                    LoadData();
                    BindGrid();

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