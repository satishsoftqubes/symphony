using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class RateCardPOSCharge : System.Web.UI.UserControl
    {
        #region Property and Variables
        public Guid RateCardID
        {
            get
            {
                return ViewState["RateCardID"] != null ? new Guid(Convert.ToString(ViewState["RateCardID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateCardID"] = value;
            }
        }
        public bool IsMessage = false;
        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                hfDateFormat.Value = clsSession.DateFormat;

                if (clsSession.ToEditItemType == "RATECARDPOS" && clsSession.ToEditItemID != Guid.Empty)
                {
                    this.RateCardID = clsSession.ToEditItemID;
                    BindData();
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = "";
                }

                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        
        //Method to Bind default data.
        private void BindData()
        {
            try
            {
                RateCard objRateCard = RateCardBLL.GetByPrimaryKey(this.RateCardID);
                if (objRateCard != null)
                {
                    lblRateCardName.Text = objRateCard.RateCardName;
                }

                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
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

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblRatecardList", "Ratecard Setup");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            //DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            //if (DV.Count > 0)
            //{
            //    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
            //    ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
            //    btnAdd.Enabled = btnAddTop.Enabled = Convert.ToBoolean(DV[0]["IsCreate"]);
            //    ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            //}
            //else
            //    Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            DataSet dsRateCardInfo = RateCardDetailsBLL.SelectRateCardDetailsForPOS(this.RateCardID);

            gvRateCardInfo.DataSource = dsRateCardInfo;
            gvRateCardInfo.DataBind();
        }
        #endregion Private Method

        #region Control Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                List<POSChargePerDay> lstPOSCharges = new List<POSChargePerDay>();
                for (int i = 0; i < gvRateCardInfo.Rows.Count; i++)
                {
                    TextBox txtRackRate = (TextBox)gvRateCardInfo.Rows[i].FindControl("txtPOSChargeAmount");
                    HiddenField hfRoomTypeID = (HiddenField)gvRateCardInfo.Rows[i].FindControl("hfRoomTypeID");

                    POSChargePerDay objPOSCharge = new POSChargePerDay();
                    objPOSCharge.RateCardID = this.RateCardID;
                    objPOSCharge.RoomTypeID = new Guid(hfRoomTypeID.Value);
                    objPOSCharge.ChargeAmount = Convert.ToDecimal(txtRackRate.Text.Trim());
                    objPOSCharge.CompanyID = clsSession.CompanyID;
                    objPOSCharge.CreatedBy = clsSession.UserID;
                    objPOSCharge.CreatedOn = DateTime.Now;
                    objPOSCharge.PropertyID = clsSession.PropertyID;

                    lstPOSCharges.Add(objPOSCharge);
                }

                POSChargePerDayBLL.Save(lstPOSCharges, this.RateCardID);
                lblMessage.Text = "POS Charges saved successfully.";
                IsMessage = true;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToList_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/PriceManager/RateCardList.aspx");
        }
        #endregion

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
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    RateCard objToDelete = RateCardBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    objToDelete.IsActive = false;

                    RateCardBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_RateCard");
                    IsMessage = true;
                    lblMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //msgbx.Hide();
                //ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event
    }
}