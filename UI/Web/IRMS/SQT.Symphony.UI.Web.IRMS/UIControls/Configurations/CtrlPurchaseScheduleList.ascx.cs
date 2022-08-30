using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPurchaseScheduleList : System.Web.UI.UserControl
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
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();
                SetPageLables();

                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                }

                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                {
                    btnAddPurchaseSchedule.Visible = btnAddPurchaseScheduleTop.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }

        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                btnAddPurchaseSchedule.Visible = btnAddPurchaseScheduleTop.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
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

        protected void grdPurchaseScheduleList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[1].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[1].Text = "View";
                    e.Row.Cells[1].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[2].Visible = Convert.ToBoolean(ViewState["Delete"]);
                    //e.Row.Cells[2].Visible = Convert.ToBoolean(ViewState["Delete"]);
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        e.Row.Cells[1].Visible = false;
                        //e.Row.Cells[2].Visible = false;
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");
                    ((ImageButton)e.Row.FindControl("btnDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PropertyID")));


                    //Label lbl = (Label)e.Row.FindControl("lblCarpetArea");
                    //lbl.Text = lbl.Text.Substring(0, lbl.Text.Length - 3).ToString();

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    //DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                    e.Row.Cells[1].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[2].Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                {
                    e.Row.Cells[1].Visible = false;
                    //e.Row.Cells[2].Visible = false;
                }

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[1].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        //e.Row.Cells[2].Text = "View";
                    e.Row.Cells[1].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[2].Visible = Convert.ToBoolean(ViewState["Delete"]);
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        e.Row.Cells[1].Visible = false;
                        //e.Row.Cells[2].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPurchaseScheduleList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    Session.Add("PropertyID", new Guid(Convert.ToString(e.CommandArgument)));
                    Response.Redirect("~/Applications/SetUp/ConfigurationPurchaseScheduleInfo.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    DeletePropertyData.Show();                   
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetPageLables()
        {
            btnYes.Text = "Yes";
            btnNo.Text = "Cancel";
            litPropertyDataMsg.Text = "Sure you want to delete?";
        }

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnPropertyData.Value) != string.Empty)
                {
                    //SQT.Symphony.BusinessLogic.Configuration.DTO.Property objDelete = PurchaseScheduleBLL.GetPurchaseScheduleData(new Guid(Convert.ToString(hdnPropertyData.Value)));
                    PurchaseScheduleBLL.Delete(new Guid(Convert.ToString(hdnPropertyData.Value)));
                    //ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Property");
                    IsMessage = true;
                    lblErrorMessage.Text = "Record deleted successfully.";
                    DeletePropertyData.Hide();
                    BindGrid();
                    //if (new Guid(Convert.ToString(hdnPropertyData.Value)) == clsSession.PropertyID)
                    //{
                    //    clsSession.PropertyID = Guid.Empty;
                    //    BindPropertyName();
                    //}
                }
                //ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPurchaseScheduleList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPurchaseScheduleList.PageIndex = e.NewPageIndex;
            BindGrid();
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
                txtPropertyName.DataSource = Dv;
                txtPropertyName.DataTextField = "PropertyName";
                txtPropertyName.DataValueField = "PropertyID";
                txtPropertyName.DataBind();
                txtPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        private void BindGrid()
        {
            string PropertyName = null;
            Guid PropertyID = new Guid();

            if (!(txtPropertyName.SelectedValue.Equals(Guid.Empty.ToString())))
            {
                PropertyName = Convert.ToString(txtPropertyName.SelectedItem.Text);
                PropertyID = new Guid(txtPropertyName.SelectedValue);
            }

            DataSet ds = PurchaseScheduleBLL.GetPropertyListForPurchaseSchedule(PropertyID, this.CompanyID, PropertyName);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPurchaseScheduleList.DataSource = dv;
            grdPurchaseScheduleList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/SetUp/ConfigurationPurchaseScheduleInfo.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}