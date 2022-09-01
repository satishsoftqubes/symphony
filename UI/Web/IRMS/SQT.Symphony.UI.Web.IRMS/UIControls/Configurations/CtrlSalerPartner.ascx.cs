using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class SalerPartner : System.Web.UI.UserControl
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

        #endregion Property and Variables
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
                LoadAccess();
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationSalerPartner.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                 

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                }
                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                {
                    //btnAdd.Visible = btnAddTop.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationSalerPartner.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //btnAdd.Visible = btnAddTop.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
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
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindGrid()
        {
            string FirstName = string.Empty;
            string MobileNo = string.Empty;

            MobileNo = txtSearchMobileNo.Text.Trim() == "" ? null : txtSearchMobileNo.Text.Trim();
            FirstName = txtSearchFirstName.Text.Trim() == "" ? null : txtSearchFirstName.Text.Trim();
            DataSet ds = SalerPartnerBLL.GetSalerPartnerData(FirstName,MobileNo);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "FirstName Asc";
            grdSalerList.DataSource = dv;
            grdSalerList.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/SetUp/ConfigurationSalerPartner.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
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
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
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
        protected void grdSalerList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSalerList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        //protected void grdSalerList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                e.Row.Cells[5].Text = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                e.Row.Cells[5].Text = "View";
        //            e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
        //            //e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);
        //            if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
        //            {
        //                e.Row.Cells[5].Visible = false;
        //                //e.Row.Cells[6].Visible = false;
        //            }
        //        }

        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
        //            ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

        //            //Label lbl = (Label)e.Row.FindControl("lblCarpetArea");
        //            //lbl.Text = lbl.Text.Substring(0, lbl.Text.Length - 3).ToString();

        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                EditImg.ToolTip = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                EditImg.ToolTip = "View";

        //            EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
        //            //DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

        //            LinkButton lnkbtnfirstName = (LinkButton)e.Row.FindControl("lnkbtnfirstName");
        //            LinkButton lnkbtnmiddleName = (LinkButton)e.Row.FindControl("lnkbtnmiddleName");
        //            LinkButton lnkbtnlastName = (LinkButton)e.Row.FindControl("lnkbtnlastName");
        //            LinkButton lnkbtnmobileNo = (LinkButton)e.Row.FindControl("lnkbtnmobileNo");
        //            e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
        //            //e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);

        //            if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
        //            {
        //                e.Row.Cells[5].Visible = false;
        //                //e.Row.Cells[6].Visible = false;
        //                lnkbtnfirstName.Enabled = false;
        //                lnkbtnmiddleName.Enabled = false;
        //                lnkbtnlastName.Enabled = false;
        //                lnkbtnmobileNo.Enabled = false;
        //            }

        //        }
        //        if (e.Row.RowType == DataControlRowType.Footer)
        //        {
        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                e.Row.Cells[5].Text = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                e.Row.Cells[5].Text = "View";
        //            e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
        //            //e.Row.Cells[6].Visible = Convert.ToBoolean(ViewState["Delete"]);
        //            if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
        //            {
        //                e.Row.Cells[5].Visible = false;
        //                //e.Row.Cells[6].Visible = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}
        protected void btnSalerYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PartnerID != Guid.Empty)
                {
                    Deletemsgbx.Hide();
                    SalerPartnerBLL.Delete(this.PartnerID);
                    IsMessage = true;
                    //lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
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
            this.PartnerID = Guid.Empty;
            Session.Remove("PartnerID");
            BindGrid();
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
        protected void btnclear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                txtSearchFirstName.Text = "";
                txtSearchMobileNo.Text = "";
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