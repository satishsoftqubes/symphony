using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlAutoNo : System.Web.UI.UserControl
    {

        #region Variable & Property

        public bool IsMessage = false;
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
        /// <param name="sender">sender as Obejct</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AUTONUMBER.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblAutonumberSetup", "Autonumber Setup");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

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
                CheckUserAuthorization();
                SetPageLabel();
                BindAutoNumberInformation();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Set Page Lable Information
        /// </summary>
        private void SetPageLabel()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("AutoNumber", "ltrMainHeader", "AUTO NUMBER SETUP");
            ltrStatutoryList.Text = clsCommon.GetGlobalResourceText("AutoNumber", "ltrStatutoryList", "AutoNumber List");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
        }

        /// <summary>
        /// Bind Auto Number Information
        /// </summary>
        private void BindAutoNumberInformation()
        {
            ControlNumber CntNo = new ControlNumber();
            CntNo.CompanyID = clsSession.CompanyID;
            CntNo.PropertyID = clsSession.PropertyID;
            CntNo.IsActive = true;
            List<ControlNumber> LstCntNo = ControlNumberBLL.GetAll(CntNo);
            gvAutolNo.DataSource = LstCntNo;
            gvAutolNo.DataBind();
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvAutolNo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Literal)e.Row.FindControl("ltrItemHeader")).Text = clsCommon.GetGlobalResourceText("AutoNumber", "ltrItemHeader", "Identify Name");
                    ((Literal)e.Row.FindControl("ltrPrefixHeader")).Text = clsCommon.GetGlobalResourceText("AutoNumber", "ltrPrefixHeader", "Prefix");
                    ((Literal)e.Row.FindControl("ltrControlNoHeader")).Text = clsCommon.GetGlobalResourceText("AutoNumber", "ltrControlNoHeader", "Control No");
                    ((Literal)e.Row.FindControl("ltrpostFixHeader")).Text = clsCommon.GetGlobalResourceText("AutoNumber", "ltrpostFixHeader", "Postfix");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
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
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/GUI/Index.aspx");
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    for (int j = 0; j < gvAutolNo.Rows.Count; j++)
                    {
                        HiddenField hdnControlNo = (HiddenField)gvAutolNo.Rows[j].FindControl("hdnControlNo");

                        if (hdnControlNo != null && Convert.ToString(hdnControlNo.Value) != "")
                        {
                            TextBox txtControlNo = (TextBox)gvAutolNo.Rows[j].FindControl("txtControlNo");
                            Label lblErrorMessage = (Label)gvAutolNo.Rows[j].FindControl("lblErrorMessage");

                            if (txtControlNo != null && Convert.ToString(txtControlNo.Text) != "")
                            {
                                int newControlNo = Convert.ToInt32(txtControlNo.Text.Trim());
                                int oldControlNo = Convert.ToInt32(hdnControlNo.Value);

                                if (oldControlNo > newControlNo)
                                {
                                    string strIdentifyName = Convert.ToString(gvAutolNo.DataKeys[j]["IdentifyName"]);
                                    lblErrorMessage.Text = "(You can't decrease " + Convert.ToString(strIdentifyName)+ " less it's current value.)";
                                    return;
                                }
                                else
                                    lblErrorMessage.Text = "";
                            }
                        }
                    }

                    bool isAnyUpdate = false;
                    for (int i = 0; i < gvAutolNo.Rows.Count; i++)
                    {
                        isAnyUpdate = true;

                        TextBox txtPrefix = (TextBox)gvAutolNo.Rows[i].FindControl("txtPreFix");
                        TextBox txtControlNumberName = (TextBox)gvAutolNo.Rows[i].FindControl("txtControlNo");
                        TextBox txtPostfix = (TextBox)gvAutolNo.Rows[i].FindControl("txtPostfix");

                        ControlNumber oldUpdt = ControlNumberBLL.GetByPrimaryKey(new Guid(Convert.ToString(gvAutolNo.DataKeys[i]["ControlNumberID"])));
                        ControlNumber Updt = ControlNumberBLL.GetByPrimaryKey(new Guid(Convert.ToString(gvAutolNo.DataKeys[i]["ControlNumberID"])));

                        Updt.ControlNumberID = new Guid(Convert.ToString(gvAutolNo.DataKeys[i]["ControlNumberID"]));                        
                        Updt.Prefix = txtPrefix.Text == string.Empty ? null : txtPrefix.Text.Trim();
                        Updt.ControlNumbers = txtControlNumberName.Text == string.Empty ? null : txtControlNumberName.Text.Trim();
                        Updt.Postfix = txtPostfix.Text == string.Empty ? null : txtPostfix.Text.Trim();
                        
                        ControlNumberBLL.Update(Updt);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", oldUpdt.ToString(), Updt.ToString(), "con_ControlNumber");
                    }

                    IsMessage = isAnyUpdate;
                    lblErrorMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    if(isAnyUpdate == true)
                        BindAutoNumberInformation();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Button Event
    }
}