using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlHouseKeeping : System.Web.UI.UserControl
    {
        #region Variable & Property

        public bool IsMessage = false;
        //Property to save CompanyID
        public Guid HKPConfigID
        {
            get
            {
                return ViewState["HKPConfigID"] != null ? new Guid(Convert.ToString(ViewState["HKPConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["HKPConfigID"] = value;
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
        #endregion Variable & Property

        #region Form Load
        /// <summary>
        /// Form Load
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
                LoadDefaultValue();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "HOUSEKEEPING.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                SetPageLables();
                BindHKPType();
                BindConfiguration();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Configuration 
        /// </summary>
        private void BindConfiguration()
        {
            HousekeepingConfig Get = new HousekeepingConfig();
            Get.CompanyID = clsSession.CompanyID;
            Get.PropertyID = clsSession.PropertyID;
            Get.IsActive = true;
            List<HousekeepingConfig> LstHKP = HousekeepingConfigBLL.GetAll(Get);
            if (LstHKP.Count > 0)
            {
                this.HKPConfigID = LstHKP[0].HKPConfigID;
                ddlHKPType.SelectedIndex = ddlHKPType.Items.FindByValue(Convert.ToString(LstHKP[0].HKPType_TermID)) != null ? ddlHKPType.Items.IndexOf(ddlHKPType.Items.FindByValue(Convert.ToString(LstHKP[0].HKPType_TermID))) : 0;
                txtDefaultTimeForFullHKP.Text = Convert.ToDateTime(LstHKP[0].DefaultTimeForFullHKP).ToString("HH:mm");
                txtDefaultTimeForMinHKP.Text = Convert.ToDateTime(LstHKP[0].DefaultTimeForMinimalHKP).ToString("HH:mm");
                txtHKPInterval.Text = Convert.ToString(LstHKP[0].HKPInterval);
                chkSetAlternetDayHKP.Checked = Convert.ToBoolean(LstHKP[0].IsAlternetDayHKP);
                chkSetDefaultHKP.Checked = Convert.ToBoolean(LstHKP[0].IsSetDefaultHKP);
            }
            else
            {
                ddlHKPType.SelectedIndex = 0;
                txtDefaultTimeForFullHKP.Text = "00:00";
                txtDefaultTimeForMinHKP.Text = "00:00";
                txtHKPInterval.Text = "0";
                chkSetAlternetDayHKP.Checked = false;
                chkSetDefaultHKP.Checked = false;
            }
        }
        /// <summary>
        /// Bind HKP Type
        /// </summary>
        private void BindHKPType()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "HKPType");
            ddlHKPType.Items.Clear();
            if (lstProjectTermTitle.Count != 0) 
            {
                ddlHKPType.DataSource = lstProjectTermTitle;
                ddlHKPType.DataTextField = "DisplayTerm";
                ddlHKPType.DataValueField = "TermID";
                ddlHKPType.DataBind();
                ddlHKPType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlHKPType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }
        /// <summary>
        /// Set Defautl Label
        /// </summary>
        private void SetPageLables()
        {
            litHouseKeepingHeading.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblHouseKeepingHeading", "HOUSEKEEPING SECTION");
            litHKPType.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblHKPType", "HKP Type");
            litDefaultTimeForFullHKP.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblDefaultTimeForFullHKP", "Time For Full HKP");
            litDefaultTimeForMinHKP.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblDefaultTimeForMinHKP", "Time For Min HKP");
            litHKPInterval.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblHKPInterval", "HKP Interval");
            litSetDefaultHKP.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblSetDefaultHKP", "Set Default HKP");
            litSetAlterNetDayHKP.Text = clsCommon.GetGlobalResourceText("HouseKeepingConfiguration", "lblSetAlterNetDayHKP", "Set Alternate Day HKP");

            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblHouseKeeping", "House Keeping");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblHouseKeepingSection", "House Keeping Section") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/GUI/Index.aspx");
        }
        /// <summary>
        /// Save Housekeeping Configuration
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HKPConfigID != Guid.Empty)
                {
                    //Update HouseKeeping Information
                    HousekeepingConfig Updt = HousekeepingConfigBLL.GetByPrimaryKey(this.HKPConfigID);
                    HousekeepingConfig OldUpdt = HousekeepingConfigBLL.GetByPrimaryKey(this.HKPConfigID);
                    Updt.HKPType_TermID = new Guid(Convert.ToString(ddlHKPType.SelectedValue));
                    Updt.IsAlternetDayHKP = chkSetAlternetDayHKP.Checked;
                    Updt.IsSetDefaultHKP = chkSetDefaultHKP.Checked;
                    Updt.DefaultTimeForFullHKP = txtDefaultTimeForFullHKP.Text.Equals("") ? Convert.ToDateTime("00:00") : Convert.ToDateTime(txtDefaultTimeForFullHKP.Text.Trim());
                    Updt.DefaultTimeForMinimalHKP = txtDefaultTimeForMinHKP.Text.Equals("") ? Convert.ToDateTime("00:00") : Convert.ToDateTime(txtDefaultTimeForMinHKP.Text.Trim());
                    Updt.HKPInterval = txtHKPInterval.Text.Equals("") ? Convert.ToInt32("0") : Convert.ToInt32(txtHKPInterval.Text);
                    Updt.UpdatedOn = DateTime.Now.Date;
                    Updt.UpdatedBy = clsSession.UserID;
                    HousekeepingConfigBLL.Update(Updt);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString(), Updt.ToString(), "hkp_HousekeepingConfig");
                    IsMessage = true;
                    ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                }
                else
                {
                    //Insert HouseKeeping Information
                    HousekeepingConfig Ins = new HousekeepingConfig();
                    Ins.HKPType_TermID = new Guid(Convert.ToString(ddlHKPType.SelectedValue));
                    Ins.IsAlternetDayHKP = chkSetAlternetDayHKP.Checked;
                    Ins.IsSetDefaultHKP = chkSetDefaultHKP.Checked;
                    Ins.DefaultTimeForFullHKP = txtDefaultTimeForFullHKP.Text.Equals("") ? Convert.ToDateTime("00:00") : Convert.ToDateTime(txtDefaultTimeForFullHKP.Text.Trim());
                    Ins.DefaultTimeForMinimalHKP = txtDefaultTimeForMinHKP.Text.Equals("") ? Convert.ToDateTime("00:00"): Convert.ToDateTime(txtDefaultTimeForMinHKP.Text.Trim());
                    Ins.HKPInterval = txtHKPInterval.Text.Equals("") ? Convert.ToInt32("0") : Convert.ToInt32(txtHKPInterval.Text);
                    Ins.CompanyID = clsSession.CompanyID; 
                    Ins.UpdatedOn = DateTime.Now.Date;
                    Ins.UpdatedBy = clsSession.UserID;
                    Ins.IsActive = true;
                    HousekeepingConfigBLL.Save(Ins);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", Ins.ToString(), Ins.ToString(), "hkp_HousekeepingConfig");
                    IsMessage = true;
                    ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                }
                BindConfiguration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Button Event
    } 
}