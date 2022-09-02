using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
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
            Guid PropertyID = new Guid();

            if (!(ddlPropertyName.SelectedValue.Equals(Guid.Empty.ToString())))
            {
                PropertyName = Convert.ToString(ddlPropertyName.SelectedItem.Text);
                PropertyID = new Guid(ddlPropertyName.SelectedValue);
            }
            else
            {
                PropertyID = Guid.Empty;
            }

            //string FirstName = string.Empty;
            //string MobileNo = string.Empty;
            //DataSet ds = SalerPartnerBLL.GetSalerPartnerData(null, null);
            //DataView dv = new DataView(ds.Tables[0]);
            //dv.Sort = "FirstName Asc";
            //grdSalerList.DataSource = dv;
            //grdSalerList.DataBind();
        }

        protected void grdSalerList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSalerList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdSalerList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    Session.Add("PartnerID", new Guid(Convert.ToString(e.CommandArgument)));
                    Response.Redirect("~/Applications/SetUp/ConfigurationSalerPartner.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    //Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    //this.PartnerID = new Guid(Convert.ToString(e.CommandArgument));
                    //Deletemsgbx.Show();
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