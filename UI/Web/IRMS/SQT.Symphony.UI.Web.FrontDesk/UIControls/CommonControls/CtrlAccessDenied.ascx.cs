using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlAccessDenied : System.Web.UI.UserControl
    {
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
            //litHeaderAccessDenied.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblHeaderAccessDenied", "Access Denied");

            //if (clsSession.CompanyID == Guid.Empty)
            //{
            //    litMainHeader.Text = "COMPANY SELECTION";
            //    ltrCompanyListMessage.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMsgNoCompanySelected", "No any company selected, please select any company.");
            //}
            //else if (clsSession.PropertyID == Guid.Empty)
            //{
            //    litMainHeader.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblPropertySelection", "PROPERTY SELECTION");
            //    ltrPropertyListMessage.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMsgNoPropertySelected", "No any Property selected, please select any property from below list.");
            //}
            //else
            //{
            //    litMainHeader.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMainHeader", "ACCESS DEINED");
            //    litMsgAccessDeniedM.Text = clsCommon.GetGlobalResourceText("AccessDenied", "lblMsgNoPermissionToAccessPage", "You don't have the required permission to access this page.");
            //}

            litMainHeader.Text = "ACCESS DEINED";

            if (Request.QueryString["IsCounter"] != null)
            {
                litMsgAccessDeniedM.Text = "Please Login in  Counter.";
            }
            else
                litMsgAccessDeniedM.Text = "You don't have the required permission to access this page.";
        }

        private void BindBreadCrumb()
        {
            //DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            //DataTable dt = new DataTable();
            //DataColumn cl = new DataColumn("NameColumn");
            //dt.Columns.Add(cl);

            //DataColumn cl1 = new DataColumn("Link");
            //dt.Columns.Add(cl1);

            ////DataRow dr2 = dt.NewRow();
            ////dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            ////dr2["Link"] = "";
            ////dt.Rows.Add(dr2);

            //if (clsSession.CompanyID != Guid.Empty)
            //{
            //    if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["NameColumn"] = clsSession.CompanyName;
            //        dr["Link"] = "~/GUI/Property/CompanyList.aspx";
            //        dt.Rows.Add(dr);
            //    }

            //    if (clsSession.PropertyID != Guid.Empty)
            //    {
            //        DataRow dr1 = dt.NewRow();
            //        dr1["NameColumn"] = clsSession.PropertyName;
            //        dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            //        dt.Rows.Add(dr1);

            //        DataRow dr3 = dt.NewRow();
            //        dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccessDenied", "Access Denied");
            //        dr3["Link"] = "";
            //        dt.Rows.Add(dr3);
            //    }
            //    else
            //    {
            //        DataRow dr1 = dt.NewRow();
            //        dr1["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyList", "Property List");
            //        dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            //        dt.Rows.Add(dr1);
            //    }
            //}
            //else
            //{
            //    if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            //    {
            //        DataRow dr1 = dt.NewRow();
            //        dr1["NameColumn"] = "Company List";
            //        dr1["Link"] = "~/GUI/Property/CompanyList.aspx";
            //        dt.Rows.Add(dr1);
            //    }
            //}

            //dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            //dlBreadCrumb.DataSource = dt;
            //dlBreadCrumb.DataBind();

            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Access Denied";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetAccessDeniedView()
        {
            //if (Request["returnurl"] != null)
            //{
            //    this.ReturnURL = Convert.ToString(Request["returnurl"]);
            //    if (clsSession.CompanyID == Guid.Empty)
            //    {
            //        BindCompanyGrid();
            //        mvAccessDenied.ActiveViewIndex = 1;
            //    }
            //    else if (clsSession.PropertyID == Guid.Empty)
            //    {
            //        BindPropertyGrid();
            //        mvAccessDenied.ActiveViewIndex = 2;
            //    }
            //    else
            //        mvAccessDenied.ActiveViewIndex = 0;
            //}
            //else
            //    mvAccessDenied.ActiveViewIndex = 0;

            mvAccessDenied.ActiveViewIndex = 0;
        }

        #endregion        
    }
}