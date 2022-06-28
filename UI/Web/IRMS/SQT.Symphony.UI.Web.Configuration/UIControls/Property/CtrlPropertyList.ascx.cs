using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;


namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlPropertyList : System.Web.UI.UserControl
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

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                if (clsSession.UserType.ToUpper() == "ADMIN")
                {
                    clsSession.ToEditItemType = "PROPERTYSETUP";
                    clsSession.ToEditItemID = clsSession.PropertyID;
                    Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                }
                else if (clsSession.UserType.ToUpper() == "SUPERADMIN" || clsSession.UserType.ToUpper() == "ADMINISTRATOR")
                    btnAdd.Visible = btnAddTop.Visible = true;
                else
                    Response.Redirect("~/GUI/AccessDenied.aspx");

                LoadDefaultValue();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "PROPERTYSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAdd.Visible = btnAddTop.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("PropertyList", "lblMainHeader", "PROPERTY SETUP");
            ltrPropertyName.Text = clsCommon.GetGlobalResourceText("PropertyList", "lblPropertyName", "Property Name");
            ltrLocation.Text = clsCommon.GetGlobalResourceText("PropertyList", "lblLocation", "City");
            ltrPropertyType.Text = clsCommon.GetGlobalResourceText("PropertyList", "lblPropertyType", "Property Type");
            litPropertyList.Text = clsCommon.GetGlobalResourceText("PropertyList", "litPropertyList", "Property List");
            btnAdd.Text = btnAddTop.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litPropertyDataMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            litPropertyDataHeader.Text = clsCommon.GetGlobalResourceText("PropertyList", "litPropertyDataHeader", "Property Setup");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyList", "Property List") ;
            dr1["Link"] = "";
            dt.Rows.Add(dr1);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                this.CompanyID = clsSession.CompanyID;
                SetPageLables();
                BindDDL();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            string PropertyName = null;
            string Location = null;
            Guid? PropertyType = null;
            if (!(txtPropertyName.Text.Trim().Equals(string.Empty)))
                PropertyName = txtPropertyName.Text.Trim();

            if (!(txtLocation.Text.Trim().Equals(string.Empty)))
                Location = txtLocation.Text.Trim();

            if (ddlPropertyType.SelectedValue != Guid.Empty.ToString())
                PropertyType = new Guid(ddlPropertyType.SelectedValue.ToString());
            DataSet ds = PropertyBLL.GetPropertyData(null, clsSession.CompanyID, PropertyName, Location, PropertyType);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPropertyList.DataSource = dv;
            grdPropertyList.DataBind();
        }
        /// <summary>
        /// Bind Property Type
        /// </summary>
        private void BindDDL()
        {
            List<ProjectTerm> lstProjectTermPT = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PROPERTYTYPE";
            objProjectTermPT.CompanyID = this.CompanyID;

            lstProjectTermPT = ProjectTermBLL.GetAll(objProjectTermPT);

            if (lstProjectTermPT.Count != 0)
            {
                ddlPropertyType.DataSource = lstProjectTermPT;
                ddlPropertyType.DataTextField = "Term";
                ddlPropertyType.DataValueField = "TermID";
                ddlPropertyType.DataBind();
                ddlPropertyType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
            else
                ddlPropertyType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
        }

        /// <summary>
        /// ClearControl Event
        /// </summary>
        private void ClearControl()
        {
            txtPropertyName.Text = txtLocation.Text = "";
            ddlPropertyType.SelectedIndex = 0;
            this.PropertyID = Guid.Empty;
            BindGrid();
        }

        private void ClearSearchControl()
        {
            txtPropertyName.Text = txtLocation.Text = string.Empty;
            ddlPropertyType.SelectedIndex = 0;
        }

        private void BindPropertyName()
        {
            if (clsSession.PropertyID != Guid.Empty)
            {
                SQT.Symphony.BusinessLogic.Configuration.DTO.Property objProperty = new SQT.Symphony.BusinessLogic.Configuration.DTO.Property();
                objProperty = PropertyBLL.GetByPrimaryKey(clsSession.PropertyID);

                if (objProperty != null)
                {
                    clsSession.PropertyName = Convert.ToString(objProperty.PropertyName);
                }
                else
                {
                    clsSession.PropertyName = string.Empty;
                    
                    Label lblPropertyName = (Label)this.Page.Master.FindControl("lblPropertyName");
                    lblPropertyName.Text = string.Empty;
                    UpdatePanel uPnlMasterPropertyName = (UpdatePanel)this.Page.Master.FindControl("uPnlMasterPropertyName");
                    uPnlMasterPropertyName.Update();
                }
            }
            else
            {
                clsSession.PropertyName = string.Empty;
                Label lblPropertyName = (Label)this.Page.Master.FindControl("lblPropertyName");
                lblPropertyName.Text = string.Empty;
                UpdatePanel uPnlMasterPropertyName = (UpdatePanel)this.Page.Master.FindControl("uPnlMasterPropertyName");
                uPnlMasterPropertyName.Update();

            }
        }
        #endregion Private Method

        #region Add New Property
        /// <summary>
        /// Add New Property List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                clsSession.ToEditItemType = string.Empty;
                clsSession.ToEditItemID = Guid.Empty;
                Response.Redirect("~/GUI/Property/PropertySetup.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Add New Property

        #region Control Event

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event
        /// <summary>
        /// Grid Row Data BoundEvent
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void grdPropertyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    ((ImageButton)e.Row.FindControl("btnDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    ((ImageButton)e.Row.FindControl("btnDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PropertyID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvfNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblHdrPropertyName")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrPropertyName", "Property Name");
                    ((Label)e.Row.FindControl("lblHdrPropertyType")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrPropertyType", "Property Type");
                    ((Label)e.Row.FindControl("lblHdrLocation")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrLocation", "City");
                    ((Label)e.Row.FindControl("lblHdrSBA")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrSBA", "SBA");
                    ((Label)e.Row.FindControl("lblHdrBlocks")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrBlocks", "Blocks");
                    ((Label)e.Row.FindControl("lblHdrFloors")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrFloors", "Floors");
                    ((Label)e.Row.FindControl("lblHdrUnitTypes")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrUnitTypes", "Unit Types");
                    ((Label)e.Row.FindControl("lblHdrUnits")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrUnits", "Units");
                    ((Label)e.Row.FindControl("lblHdrHotelLicenceNumber")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrHotelLicenceNumber", "Licence No.");
                    ((Label)e.Row.FindControl("lblHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void grdPropertyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemType = "PROPERTYSETUP";
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));                    
                    Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    DeletePropertyData.Show();
                }
                else if (e.CommandName.Equals("TOTALWING"))
                {
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    BindPropertyName();
                    Response.Redirect("~/GUI/Configurations/BlockFloorSetup.aspx");
                }
                else if (e.CommandName.Equals("TOTALUNITTYPES"))
                {
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    BindPropertyName();
                    Response.Redirect("~/GUI/Configurations/RoomTypeList.aspx");
                }
                else if (e.CommandName.Equals("TOTALUNIT"))
                {
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    BindPropertyName();
                    Response.Redirect("~/GUI/Configurations/RoomList.aspx");
                }
                else if (e.CommandName.Equals("TOTALFLOOR"))
                {
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    BindPropertyName();
                    Response.Redirect("~/GUI/Configurations/BlockFloorSetup.aspx");
                }
                else if (e.CommandName.Equals("UNITINFO"))
                {
                    clsSession.ToEditItemType = "PROPERTYSETUP";
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    BindPropertyName();
                    Response.Redirect("~/GUI/Property/PropertySetup.aspx");
                }
                else if (e.CommandName.Equals("VIEWPROPERTYDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    BindPropertyName();
                    Response.Redirect("~/GUI/Property/PropertyInformation.aspx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Grid Page Index Changing Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewPageEventArgs</param>
        protected void grdPropertyList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPropertyList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Popup Button Event

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
                    SQT.Symphony.BusinessLogic.Configuration.DTO.Property objDelete = PropertyBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnPropertyData.Value)));
                    PropertyBLL.Delete(new Guid(Convert.ToString(hdnPropertyData.Value)));
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Property");
                    IsMessage = true;
                    lblErrorMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    DeletePropertyData.Hide();

                    string path = Server.MapPath("~/App_GlobalResources");

                    string strPropertyCode = Convert.ToString(objDelete.LicenceNo) + "_*.*";
                    string[] files = System.IO.Directory.GetFiles(path, strPropertyCode, System.IO.SearchOption.AllDirectories);

                    for (int i = 0; i < files.Length; i++)
                    {
                        File.Delete(files[i]);
                    }

                    if (new Guid(Convert.ToString(hdnPropertyData.Value)) == clsSession.PropertyID)
                    {
                        clsSession.PropertyID = Guid.Empty;
                        BindPropertyName();
                    }
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Button Event
    }
}