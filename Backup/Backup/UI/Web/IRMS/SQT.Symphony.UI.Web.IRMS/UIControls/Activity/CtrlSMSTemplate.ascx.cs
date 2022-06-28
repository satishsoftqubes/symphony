using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlSMSTemplate : System.Web.UI.UserControl
    {

        #region Variable

        public bool IsInsert = false;
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
        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("SMSTemplateSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            if (!IsPostBack)
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("SMSTemplateSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);                                
                if (ViewState["SMSID"] == null)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);                
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                ClearControlValue();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Clear Control Value
        /// </summary>
        private void ClearControlValue()
        {
            ViewState["SMSID"] = null;
            txtTitle.Text = "";
            txtSTitle.Text = "";
            txtDetails.Text = "";
            rdoIsOnInvestorCreation.Checked = false;
            rdoIsOnUnitBooking.Checked = false;
            rdoIsOnUnitInsuranceReceived.Checked = false;
            rdoIsOnUnitPaymentReceived.Checked = false;
            rdoIsOnUnitTaxReceived.Checked = false;
            rdoIsOther.Checked = false;
            txtTitle.Focus();
            BindGrid();
            rdoIsOnInvestorCreation.Enabled = rdoIsOnUnitBooking.Enabled = rdoIsOnUnitInsuranceReceived.Enabled = rdoIsOnUnitPaymentReceived.Enabled = rdoIsOnUnitTaxReceived.Enabled = rdoIsOther.Enabled = true;
        }
        /// <summary>
        /// Bind Grid Data
        /// </summary>
        private void BindGrid()
        {
            string Title = null;
            if (!txtSTitle.Text.Equals(""))
                Title = txtSTitle.Text;
            DataSet Dst = SMSTemplatesBLL.SearchData(Title);
            DataView DV = new DataView(Dst.Tables[0]);
            DV.Sort = "Title ASC";
            grdSMSList.DataSource = DV;
            grdSMSList.DataBind();
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControlValue();
            LoadAccess();
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SMSTemplates Dup = new SMSTemplates();
                    Dup.Title = txtTitle.Text.Trim();
                    Dup.IsActive = true;
                    List<SMSTemplates> DupLst = SMSTemplatesBLL.GetAll(Dup);
                    if (DupLst.Count > 0)
                    {
                        if (ViewState["SMSID"] != null)
                        {
                            if (Convert.ToString((DupLst[0].SMSTemplateID)) != Convert.ToString(ViewState["SMSID"]))
                            {
                                IsInsert = true;
                                lblNewsMsg.Text = "Record already exit !";
                                return;
                            }
                        }
                        else
                        {
                            IsInsert = true;
                            lblNewsMsg.Text = "Record already exit !";
                            return;
                        }
                    }

                    if (ViewState["SMSID"] != null)
                    {
                        //Update Record
                        SMSTemplates OldSMSUpdt = SMSTemplatesBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["SMSID"])));
                        SMSTemplates SMSUpdt = SMSTemplatesBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["SMSID"])));
                        SMSUpdt.Title = txtTitle.Text;
                        SMSUpdt.SMSDetails = txtDetails.Text;
                        SMSUpdt.IsOnInvestorCreation = rdoIsOnInvestorCreation.Checked;
                        SMSUpdt.IsOnUnitBooking = rdoIsOnUnitBooking.Checked;
                        SMSUpdt.IsOnUnitInsuranceReceived = rdoIsOnUnitInsuranceReceived.Checked;
                        SMSUpdt.IsOnUnitPaymentReceived = rdoIsOnUnitPaymentReceived.Checked;
                        SMSUpdt.IsOnUnitTaxReceived = rdoIsOnUnitTaxReceived.Checked;
                        SMSUpdt.IsOther = rdoIsOther.Checked;
                        SMSUpdt.CompanyID = this.CompanyID;
                        SMSUpdt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        SMSUpdt.UpdatedOn = DateTime.Now.Date;
                        SMSUpdt.IsActive = true;
                        SMSTemplatesBLL.Update(SMSUpdt);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldSMSUpdt.ToString(), SMSUpdt.ToString(), "mst_NewsLetters");
                        IsInsert = true;
                        ViewState["SMSID"] = null;
                        lblNewsMsg.Text = "Update Successfully";
                    }
                    ClearControlValue();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        #endregion Button Event

        #region Grid Row Data Command
        /// <summary>
        /// Grid Row Data Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdSMSList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                try
                {
                    ViewState["SMSID"] = e.CommandArgument.ToString();
                    LoadAccess();
                    SMSTemplates GetForUpdt = SMSTemplatesBLL.GetByPrimaryKey(new Guid(Convert.ToString(ViewState["SMSID"])));
                    txtTitle.Text = GetForUpdt.Title;
                    txtDetails.Text = GetForUpdt.SMSDetails;
                    rdoIsOnInvestorCreation.Checked = Convert.ToBoolean(GetForUpdt.IsOnInvestorCreation);
                    rdoIsOnUnitBooking.Checked = Convert.ToBoolean(GetForUpdt.IsOnUnitBooking);
                    rdoIsOnUnitInsuranceReceived.Checked = Convert.ToBoolean(GetForUpdt.IsOnUnitInsuranceReceived);
                    rdoIsOnUnitPaymentReceived.Checked = Convert.ToBoolean(GetForUpdt.IsOnUnitPaymentReceived);
                    rdoIsOnUnitTaxReceived.Checked = Convert.ToBoolean(GetForUpdt.IsOnUnitTaxReceived);
                    rdoIsOther.Checked = Convert.ToBoolean(GetForUpdt.IsOther);
                    rdoIsOnInvestorCreation.Enabled = rdoIsOnUnitBooking.Enabled = rdoIsOnUnitInsuranceReceived.Enabled = rdoIsOnUnitPaymentReceived.Enabled = rdoIsOnUnitTaxReceived.Enabled = rdoIsOther.Enabled = false;
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion Grid Row Data Command

        #region Grid Data Row Bound Event
        /// <summary>
        /// Data Row Bound Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdSMSList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");                

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }

        #endregion Grid Data Row Bound Event
    }
}