using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlSearchServices : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;

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

        public string strClearDateTooltip
        {
            get
            {
                return ViewState["strClearDateTooltip"] != null ? Convert.ToString(ViewState["strClearDateTooltip"]) : string.Empty;
            }
            set
            {
                ViewState["strClearDateTooltip"] = value;
            }
        }

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
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

        #endregion Variable and Property

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
            if (!IsPostBack)
            {
                BindddlSearchServices();
                calStartDate.Format = clsSession.DateFormat;
                calExpiryDate.Format = clsSession.DateFormat;
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Private Method

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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Cashier";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "AddOn Services";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControl()
        {
            ddlSearchServices.SelectedIndex = 0;
            txtStartDate.Text = txtExpiryDate.Text = "";
        }

        public void BindddlSearchServices()
        {
            try
            {
                DataSet dstItemTypeTermID = ResAddOnServiceListBLL.GetResAddOnServiceListItemTypeTermIDServiceName(clsSession.CompanyID, clsSession.PropertyID);

                if (dstItemTypeTermID != null && dstItemTypeTermID.Tables[0].Rows.Count > 0)
                {
                    ddlSearchServices.DataSource = dstItemTypeTermID.Tables[0];
                    ddlSearchServices.DataTextField = "ItemName";
                    ddlSearchServices.DataValueField = "ItemID";
                    ddlSearchServices.DataBind();
                    ddlSearchServices.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                {
                    ddlSearchServices.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? StartDate = null;
                DateTime? ExpiryDate = null;
                Guid? ItemID = null;

                if (txtStartDate.Text.Trim() != "")
                    StartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (txtExpiryDate.Text.Trim() != "")
                    ExpiryDate = DateTime.ParseExact(txtExpiryDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (ddlSearchServices.SelectedIndex != 0)
                    ItemID = new Guid(ddlSearchServices.SelectedValue);

                DataSet dsSearchServises = ResAddOnServiceListBLL.GetResAddOnServiceListSelectAllSearchServices(StartDate, ExpiryDate, ItemID, clsSession.PropertyID, clsSession.CompanyID);
                if (dsSearchServises != null && dsSearchServises.Tables.Count > 0 && dsSearchServises.Tables[0].Rows.Count > 0)
                {
                    gvSearchServicesList.DataSource = dsSearchServises.Tables[0];
                    gvSearchServicesList.DataBind();
                }
                else
                {
                    gvSearchServicesList.DataSource = null;
                    gvSearchServicesList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }

        #endregion Private Method

        #region Button Method

        protected void imtbtnSearchClearSearchServices_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearControl();
                gvSearchServicesList .PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imtbtnSearchServices_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvSearchServicesList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Guest/AddOnServices.aspx");
        }

        #endregion Button Method

        #region Grid Event

        protected void gvSearchServicesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvStatus = (Label)e.Row.FindControl("lblGvStatus");
                    if (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExpiryDate")).Date < System.DateTime.Now.Date)
                    {
                        lblGvStatus.Text = "Expired";
                        if (lblGvStatus.Text == "Expired")
                        {
                            e.Row.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblGvStatus.Text = "Active";
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}