using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlAddOnsServices : System.Web.UI.UserControl
    {
        #region Property and Variables

        public Guid AddOnID
        {
            get
            {
                return ViewState["AddOnID"] != null ? new Guid(Convert.ToString(ViewState["AddOnID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AddOnID"] = value;
            }
        }

        public Guid ItemID
        {
            get
            {
                return ViewState["ItemID"] != null ? new Guid(Convert.ToString(ViewState["ItemID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ItemID"] = value;
            }
        }

        public Guid TermID
        {
            get
            {
                return ViewState["TermID"] != null ? new Guid(Convert.ToString(ViewState["TermID"])) : Guid.Empty;
            }
            set
            {
                ViewState["TermID"] = value;
            }
        }

        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }

        public bool IsInsert = false;

        public bool IsListMessage = false;

        public bool IsAddEditMessage = false;

        public DataTable dtExistingDetails = null;

        #endregion Property and Variables

        #region Form Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();

                BindBreadCrumb();
                BindGrid();
            }
        }

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ADDONSSERVICES.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.AddOnID != Guid.Empty)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAddOnsServices", "Add On Services");
                dr3["Link"] = "~/GUI/PriceManager/AddOnsServices.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewAddonsService", "New Add On Service");
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAddOnsServices", "Add On Services");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControl()
        {
            txtServiceName.Text = "";
        }

        private void BindGrid()
        {
            try
            {
                DataSet dsServices = ResAddOnServiceListBLL.GetResAddOnServiceListItemTypeTermIDServiceName(clsSession.CompanyID, clsSession.PropertyID);

                if (dsServices.Tables[1].Rows.Count > 0)
                {
                    this.TermID = new Guid(Convert.ToString(dsServices.Tables[1].Rows[0]["TermID"]));
                }
                if (dsServices != null && dsServices.Tables.Count > 0 && dsServices.Tables[0].Rows.Count > 0)
                {
                    gvAddOnsServicesList.DataSource = dsServices.Tables[0];
                    gvAddOnsServicesList.DataBind();
                }
                else
                {
                    gvAddOnsServicesList.DataSource = null;
                    gvAddOnsServicesList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Grid Event

        protected void gvAddOnsServicesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddOnsServicesList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvAddOnsServicesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemID")));
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            }
        }

        protected void gvAddOnsServicesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EDITDATA"))
                {
                    mpeOpenAddServices.Show();

                    this.ItemID = new Guid(Convert.ToString(e.CommandArgument));

                    Item objAddOnServiceEdit = new Item();
                    objAddOnServiceEdit = ItemBLL.GetByPrimaryKey(this.ItemID);
                    if (objAddOnServiceEdit != null)
                    {
                        txtServiceName.Text = Convert.ToString(objAddOnServiceEdit.ItemName);                      
                    }
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    ClearControl();
                    this.ItemID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Button Event

        protected void btnAddTop_Click(object sender, EventArgs e)
        {
            ClearControl();
            mpeOpenAddServices.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Page.IsValid)
                {
                    if (this.ItemID != Guid.Empty)
                    {
                        Item objItemUpdate = new Item();
                        objItemUpdate = ItemBLL.GetByPrimaryKey(this.ItemID);
                        objItemUpdate.PropertyID = clsSession.PropertyID;
                        objItemUpdate.CompanyID = clsSession.CompanyID;
                        objItemUpdate.UpdatedOn = DateTime.Now;
                        objItemUpdate.UpdatedBy = clsSession.UserID;
                        objItemUpdate.ItemName = Convert.ToString(txtServiceName.Text);

                        ItemBLL.Update(objItemUpdate);
                        BindGrid();
                        MessageBox.Show("Services Updated Successfully.");
                        ClearControl();
                    }
                    else
                    {
                        Item objItemInsert = new Item();
                        objItemInsert.PropertyID = clsSession.PropertyID;
                        objItemInsert.CompanyID = clsSession.CompanyID;
                        objItemInsert.IsActive = true;
                        objItemInsert.ItemName = Convert.ToString(txtServiceName.Text);
                        objItemInsert.ItemType_TermID = this.TermID;

                        ItemBLL.Save(objItemInsert);
                        BindGrid();
                        MessageBox.Show("Services addes Successfully.");
                        ClearControl();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event        

        #region Pop Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    Item objDelete = new Item();
                    objDelete = ItemBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    objDelete.IsDelete = true;
                    objDelete.UpdatedBy = clsSession.UserID;
                    objDelete.UpdatedOn = DateTime.Now;

                    ItemBLL.Update(objDelete);

                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_ITem");
                    IsListMessage = true;
                    MessageBox.Show("Record deleted successfully.");
                    BindGrid();

                    ClearControl();
                }
                //BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Pop Button Event
    }
}