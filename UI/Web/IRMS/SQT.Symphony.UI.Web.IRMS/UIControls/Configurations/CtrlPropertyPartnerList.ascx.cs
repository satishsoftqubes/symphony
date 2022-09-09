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
    public partial class CtrlPropertyPartnerList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

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

        public Guid PropertyID
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
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPropertyPartnerInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                }

                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                {
                    btnAdd.Visible = btnAddTop.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }

        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyPartnerInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                btnAdd.Visible = btnAddTop.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        private void LoadDefaultValue()
        {
            try
            {
                BindDDL();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDDL()
        {

            string PropertyNameQuery = "Select Distinct(PropertyName), PropertyID From mst_Property Where IsActive = 1";
            DataSet Dst = InvestorBLL.GetSearchData(PropertyNameQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                ddlPropertyName.DataSource = Dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrid()
        {
            string PropertyName = null;

            if (!(ddlPropertyName.SelectedValue.Equals(Guid.Empty.ToString())))
                PropertyName = Convert.ToString(ddlPropertyName.SelectedItem.Text);

            DataSet ds = PropertyPartnerBLL.GetPropertyPartnerData(null, PropertyName, this.CompanyID);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPropertyPartnerList.DataSource = dv;
            grdPropertyPartnerList.DataBind();
        }

        protected void grdPropertyPartnerList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPropertyPartnerList.PageIndex = e.NewPageIndex;
            BindGrid();
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

        protected void grdPropertyPartnerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    Session.Add("PropertyPartnerID", new Guid(Convert.ToString(e.CommandArgument)));
                    Response.Redirect("~/Applications/SetUp/ConfigurationPropertyPartnerInfo.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
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

        //protected void btnSalerYes_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.PartnerID != Guid.Empty)
        //        {
        //            Deletemsgbx.Hide();
        //            SalerPartnerBLL.Delete(this.PartnerID);
        //            IsMessage = true;
        //            //lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
        //        }
        //        ClearControl();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //protected void btnSalerNo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Deletemsgbx.Hide();
        //        ClearControl();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        private void ClearControl()
        {
            this.PartnerID = Guid.Empty;
            Session.Remove("PartnerID");
            BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/SetUp/ConfigurationPropertyPartnerInfo.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}