using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.CommonControls
{
    public partial class CtrlAccessDenied : System.Web.UI.UserControl
    {
        #region Property and Variables

        public string ReturnURL
        {
            get
            {
                return ViewState["ReturnURL"] != null ? Convert.ToString(ViewState["ReturnURL"]) : string.Empty;
            }
            set
            {
                ViewState["ReturnURL"] = value;
            }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
                BindBreadCrumb();
                SetAccessDeniedView();
            }
        }
        #endregion

        #region Methods
        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {            
            litHeaderAccessDenied.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblHeaderAccessDenied", "Access Denied");

            if (clsSession.CompanyID == Guid.Empty)
            {
                litMainHeader.Text = "COMPANY SELECTION";
                ltrCompanyListMessage.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMsgNoCompanySelected", "No any company selected, please select any company.");
            }
            else if (clsSession.PropertyID == Guid.Empty)
            {
                litMainHeader.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblPropertySelection", "PROPERTY SELECTION");
                ltrPropertyListMessage.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMsgNoPropertySelected", "No any Property selected, please select any property from below list.");
            }
            else
            {
                litMainHeader.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMainHeader", "ACCESS DEINED");
                litMsgAccessDeniedM.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMsgNoPermissionToAccessPage", "You don't have the required permission to access this page.");
            }
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

            if (clsSession.CompanyID != Guid.Empty)
            {
                if (clsSession.UserType.ToUpper() == "SUPERADMIN")
                {
                    DataRow dr = dt.NewRow();
                    dr["NameColumn"] = clsSession.CompanyName;
                    dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                    dt.Rows.Add(dr);
                }

                if (clsSession.PropertyID != Guid.Empty)
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["NameColumn"] = clsSession.PropertyName;
                    dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
                    dt.Rows.Add(dr1);

                    DataRow dr3 = dt.NewRow();
                    dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccessDenied", "Access Denied");
                    dr3["Link"] = "";
                    dt.Rows.Add(dr3);
                }
                else
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyList", "Property List");
                    dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
                    dt.Rows.Add(dr1);
                }
            }
            else
            {
                if (clsSession.UserType.ToUpper() == "SUPERADMIN")
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["NameColumn"] = "Company List";
                    dr1["Link"] = "~/GUI/Property/CompanyList.aspx";
                    dt.Rows.Add(dr1);
                }
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetAccessDeniedView()
        {
            if (Request["returnurl"] != null)
            {
                this.ReturnURL = Convert.ToString(Request["returnurl"]);
                if (clsSession.CompanyID == Guid.Empty)
                {
                    BindCompanyGrid();
                    mvAccessDenied.ActiveViewIndex = 1;
                }
                else if (clsSession.PropertyID == Guid.Empty)
                {
                    BindPropertyGrid();
                    mvAccessDenied.ActiveViewIndex = 2;
                }
                else
                    mvAccessDenied.ActiveViewIndex = 0;
            }
            else
                mvAccessDenied.ActiveViewIndex = 0;
        }

        private void BindCompanyGrid()
        {
            try
            {
                DataSet dsCompany = CompanyBLL.GetAllCompanyData(null, null, null, null, null);
                gvCompanyList.DataSource = dsCompany.Tables[0];
                gvCompanyList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindPropertyGrid()
        {
            DataSet ds = PropertyBLL.GetPropertyData(null, clsSession.CompanyID, null, null, null);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPropertyList.DataSource = dv;
            grdPropertyList.DataBind();
        }
        #endregion

        #region Grid Event
        protected void gvCompanyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyCode")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrCompanyCode", "Company Code");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyName")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrCompanyName", "Company Name");
                    ((Label)e.Row.FindControl("lblGvHdrDisplayName")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrDisplayName", "Display Name");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyType")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrCompanyType", "Company Type");
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

        protected void gvCompanyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.CompanyID = new Guid(Convert.ToString(e.CommandArgument));

                    Company objCompany = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
                    clsSession.CompanyName = objCompany.CompanyName;

                    litMainHeader.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblPropertySelection", "PROPERTY SELECTION");
                    mvAccessDenied.ActiveViewIndex = 2;
                    ltrPropertyListMessage.Text = "Please select any property.";
                    BindPropertyGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCompanyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCompanyList.PageIndex = e.NewPageIndex;
                BindCompanyGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvfNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblHdrPropertyName")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrPropertyName", "Property Name");
                    ((Label)e.Row.FindControl("lblHdrPropertyType")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrPropertyType", "Property Type");
                    ((Label)e.Row.FindControl("lblHdrLocation")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrLocation", "City");
                    ((Label)e.Row.FindControl("lblHdrHotelLicenceNumber")).Text = clsCommon.GetGlobalResourceText("PropertyList", "lblGvHdrHotelLicenceNumber", "Licence No.");
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
                    clsSession.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    SQT.Symphony.BusinessLogic.Configuration.DTO.Property objProperty = PropertyBLL.GetByPrimaryKey(clsSession.PropertyID);

                    clsSession.PropertyName = Convert.ToString(objProperty.PropertyName);
                    clsSession.HotelCode = Convert.ToString(objProperty.LicenceNo);

                    if (this.ReturnURL != string.Empty)
                        Response.Redirect("~" + this.ReturnURL);
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
            BindPropertyGrid();
        }
        #endregion
    }
}