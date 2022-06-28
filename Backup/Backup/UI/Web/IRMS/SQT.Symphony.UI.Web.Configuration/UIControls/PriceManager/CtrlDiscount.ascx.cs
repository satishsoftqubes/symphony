using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlDiscount : System.Web.UI.UserControl
    {
        #region Property and Variables
        // Property to save StayTypeID;
        public Guid DiscountID
        {
            get
            {
                return ViewState["DiscountID"] != null ? new Guid(Convert.ToString(ViewState["DiscountID"])) : Guid.Empty;
            }
            set
            {
                ViewState["DiscountID"] = value;
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
        // To Give Message.
        public bool IsListMessage = false;

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                ucAddEditDiscount.UserRights = this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "DISCOUNT.ASPX");
            else
                ucAddEditDiscount.UserRights = this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottom.Visible = btnAddTop.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                BindDDL();
                SetPageLables();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            Discounts objToGetList = new Discounts();
            if (txtSrchDiscountName.Text.Trim() != string.Empty)
                objToGetList.DiscountName = txtSrchDiscountName.Text.Trim();

            if (ddlSearchDiscountType.SelectedIndex != 0)
                objToGetList.DiscountType_TermID = new Guid(ddlSearchDiscountType.SelectedValue);

            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.PropertyID = clsSession.PropertyID;

            DataSet dsDiscounts = DiscountsBLL.GetAllWithDataSet(objToGetList);

            gvDiscountList.DataSource = dsDiscounts;
            gvDiscountList.DataBind();
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDiscount", "Discount") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindDDL()
        {
            List<ProjectTerm> lstDiscountType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID,clsSession.PropertyID,"DISCOUNTTYPE");

            if (lstDiscountType.Count != 0)
            {
                ddlSearchDiscountType.DataSource = lstDiscountType;
                ddlSearchDiscountType.DataTextField = "DisplayTerm";
                ddlSearchDiscountType.DataValueField = "TermID";
                ddlSearchDiscountType.DataBind();
                ddlSearchDiscountType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlSearchDiscountType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Discount", "lblMainHeader", "Discount Setup");
            litSearchDiscountType.Text = clsCommon.GetGlobalResourceText("Discount", "lblSearchDiscountType", "Discount Type");
            litSearchDiscountName.Text = clsCommon.GetGlobalResourceText("Discount", "lblSearchDiscountName", "Discount Name");
            btnAddTop.Text = btnAddBottom.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litDiscountList.Text = clsCommon.GetGlobalResourceText("Discount", "lblDiscountList", "Discount List");

            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Discount", "lblHeaderConfirmDeletePopup", "Discount");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        private void ClearSearchControl()
        {
            txtSrchDiscountName.Text = "";
            ddlSearchDiscountType.SelectedIndex = 0;
        }

        /// <summary>
        /// Clear Control Method
        /// </summary>
        private void ClearControl()
        {
            ucAddEditDiscount.ucDiscountID = this.DiscountID = Guid.Empty;
            ucAddEditDiscount.ucTxtDiscountName = ucAddEditDiscount.ucTxtDiscountRate = ucAddEditDiscount.ucTxtDetails = "";
            ucAddEditDiscount.ucDdlRateType = 0;
            ucAddEditDiscount.ucDdlDiscountType = Guid.Empty.ToString();
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Command Evnet
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvDiscountList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                ClearControl();

                this.DiscountID = ucAddEditDiscount.ucDiscountID = new Guid(Convert.ToString(e.CommandArgument));
                Discounts objToLoad = DiscountsBLL.GetByPrimaryKey(this.DiscountID);
                if (objToLoad != null)
                {
                    //ucAddEditDiscount.UpdateLog = objToLoad.Updatelog;
                    ucAddEditDiscount.ucTxtDiscountName = Convert.ToString(objToLoad.DiscountName);

                    if (objToLoad.DiscountRate != null)
                        ucAddEditDiscount.ucTxtDiscountRate = objToLoad.DiscountRate.ToString().Substring(0, objToLoad.DiscountRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ucAddEditDiscount.ucTxtDetails = objToLoad.DiscountDetails;

                    if (Convert.ToBoolean(objToLoad.IsDiscFlat))
                        ucAddEditDiscount.ucDdlRateType = 1;
                    else
                        ucAddEditDiscount.ucDdlRateType = 0;

                    ucAddEditDiscount.ucDdlDiscountType = Convert.ToString(objToLoad.DiscountType_TermID);

                    ucAddEditDiscount.SetRateMaxValue();
                    ucAddEditDiscount.ucMpeAddEditRecord.Show();
                    ucAddEditDiscount.CheckUserAuthentication();
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.DiscountID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        /// <summary>
        /// Grid Row Data Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvDiscountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountRate")) != string.Empty)
                {
                    Label lblRate = (Label)e.Row.FindControl("lblRate");
                    string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountRate"));
                    if (strRate != string.Empty)
                    {
                        lblRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        if (!Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsDiscFlat")))
                            lblRate.Text = lblRate.Text + " %";
                    }
                }

                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountID")));

            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Literal)e.Row.FindControl("litGvHdrDiscountName")).Text = clsCommon.GetGlobalResourceText("Discount", "lblGvHdrDiscountName", "Discount Name");
                ((Literal)e.Row.FindControl("litGvHdrRate")).Text = clsCommon.GetGlobalResourceText("Discount", "lblGvHdrRate", "Rate");
                ((Literal)e.Row.FindControl("litGvHdrDiscountTypeName")).Text = clsCommon.GetGlobalResourceText("Discount", "lblGvHdrDiscountType", "Discount Type"); 
                ((Literal)e.Row.FindControl("litGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
            
        }

        /// <summary>
        /// Paging Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDiscountList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDiscountList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Department
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTop_Click(object sender, EventArgs e)
        {
            ClearControl();            
            ucAddEditDiscount.SetRateMaxValue();
            ucAddEditDiscount.ucMpeAddEditRecord.Show();
        }

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvDiscountList.PageIndex = 0;
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

        //Event which is called from AddEditRecord's userControl Opened in ModalPopup.
        protected void btnCallParent_Click(object sender, EventArgs e)
        {
            //Based on UserControl's strPopupAction condition, Take action in this(Parent) page.
            if (ucAddEditDiscount.strPopupAction.ToUpper() == "SAVE")
            {
                BindGrid();
                ucAddEditDiscount.ucMpeAddEditRecord.Show();
            }
            else if (ucAddEditDiscount.strPopupAction.ToUpper() == "LBLMSGRECORDUPDATEDSUCCESSFULLY")
            {
                BindGrid();
                IsListMessage = true;
                litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else if (ucAddEditDiscount.strPopupAction.ToUpper() == "LBLMSGRECORDSAVEDSUCCESSFULLY")
            {
                BindGrid();
                IsListMessage = true;
                litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            else if (ucAddEditDiscount.strPopupAction.ToUpper() == "DDLINDEXCHANGE")
            {
                ucAddEditDiscount.ucMpeAddEditRecord.Show();
            }                
            else if (ucAddEditDiscount.strPopupAction.ToUpper() == "EXCEPTION")
            {
                MessageBox.Show(ucAddEditDiscount.strExceptionMessage);
            }
        }
        #endregion Button Event

        #region Popup Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    Discounts objToDelete = DiscountsBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    objToDelete.IsActive = false;

                    DiscountsBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_Discounts");
                    IsListMessage = true;
                    litMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}