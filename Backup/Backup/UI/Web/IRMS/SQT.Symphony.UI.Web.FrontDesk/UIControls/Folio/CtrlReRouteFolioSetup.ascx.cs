using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlReRouteFolioSetup : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlOperationAccommodationCharges.Enabled = ddlRestaurantCharges.Enabled = ddlPhoneCharges.Enabled = ddlOperationMiscellaneousCharges.Enabled = ddlOperationPOS.Enabled = false;
                mvReRouteFolio.ActiveViewIndex = 0;
                BindBreadCrumb();
            }
        }

        #endregion

        #region Control Event

        protected void btnAddSubFolio_Click(object sender, EventArgs e)
        {
            ctrlCommonSubFolioConfiguration.ClearControlSubFolio();
            mvReRouteFolio.ActiveViewIndex = 1;            
        }

        protected void btnReRouteCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["RoomReservation"] != null)
                Response.Redirect("~/GUI/Reservation/RoomReservation.aspx");
            else if (Request.QueryString["FolioDetails"] != null)
                Response.Redirect("~/GUI/Folio/FolioDetails.aspx");
            else if (Request.QueryString["Investor"] != null)
                Response.Redirect("~/GUI/Reservation/RoomReservation.aspx");
            else if (Request.QueryString["AD"] != null)
                Response.Redirect("~/GUI/Reservation/ArrivalAndDeparture.aspx");
            else if (Request.QueryString["CheckIn"] != null)
                Response.Redirect("~/GUI/Reservation/CheckIn.aspx");
            else if (Request.QueryString["GroupReservation"] != null)
                Response.Redirect("~/GUI/Reservation/GroupReservation.aspx?GroupReservation=true");
            

        }

        protected void btnSubFolioConfigurationCallParent_Click(object sender, EventArgs e)
        {
            mvReRouteFolio.ActiveViewIndex = 0;
            
        }
        #endregion

        #region Private Method

         /// <summary>
        /// Bind BreadCrumb
        /// </summary>
        private void BindBreadCrumb()
        {
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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Billing";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Folio ReRoute";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion
    }
}