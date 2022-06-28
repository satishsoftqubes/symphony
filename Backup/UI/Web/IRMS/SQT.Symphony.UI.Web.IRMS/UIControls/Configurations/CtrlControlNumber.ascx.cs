using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlControlNumber : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("ControlNumberSetup.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            if (!IsPostBack)
                LoadDefaultValue();
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ControlNumberSetup.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                if (Convert.ToBoolean(DV[0]["IsUpdate"]) == true)
                    btnSave.Visible = true;
                else
                    btnSave.Visible = false;
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Data Here
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
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
            ControlNumber objControlNumber = new ControlNumber();
            objControlNumber.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
            List<ControlNumber> LstGetAll = ControlNumberBLL.GetAll(objControlNumber);
            if (LstGetAll.Count > 0)
            {
                LstGetAll.Sort((ControlNumber Ctrl1, ControlNumber Ctrl2) => Ctrl1.IdentifyName.CompareTo(Ctrl2.IdentifyName));
                gvControlNo.DataSource = LstGetAll;
                gvControlNo.DataBind();
                MsgRecFnd.Visible = false;
            }
            else
            {
                gvControlNo.DataSource = null;
                gvControlNo.DataBind();
                MsgRecFnd.Visible = true;
            }
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
            Response.Redirect("~/Applications/Index.aspx");
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvControlNo.Rows.Count; i++)
                {
                    Label lblControlNumberID = (Label)gvControlNo.Rows[i].FindControl("lblControlNumberID");
                    Label lblPropertyID = (Label)gvControlNo.Rows[i].FindControl("lblPropertyID");
                    Label lblIdentityName = (Label)gvControlNo.Rows[i].FindControl("lblIdentityName");
                    TextBox txtPrefix = (TextBox)gvControlNo.Rows[i].FindControl("txtPreFix");
                    TextBox txtControlNumberName = (TextBox)gvControlNo.Rows[i].FindControl("txtControlNo");
                    TextBox txtPostfix = (TextBox)gvControlNo.Rows[i].FindControl("txtPostFix");

                    ControlNumber oldUpdt = ControlNumberBLL.GetByPrimaryKey(new Guid(lblControlNumberID.Text.Trim()));
                    ControlNumber Updt = ControlNumberBLL.GetByPrimaryKey(new Guid(lblControlNumberID.Text.Trim()));
                    Updt.ControlNumberID = lblControlNumberID.Text == string.Empty ? Guid.Empty : new Guid(lblControlNumberID.Text);
                    Updt.PropertyID = lblPropertyID.Text == string.Empty ? Guid.Empty : new Guid(lblPropertyID.Text);
                    Updt.IdentifyName = lblIdentityName.Text;
                    Updt.Prefix = txtPrefix.Text == string.Empty ? null : txtPrefix.Text.Trim();
                    Updt.ControlNumbers = txtControlNumberName.Text == string.Empty ? null : txtControlNumberName.Text.Trim();
                    Updt.Postfix = txtPostfix.Text == string.Empty ? null : txtPostfix.Text.Trim();
                    Updt.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    ControlNumberBLL.Update(Updt);

                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", oldUpdt.ToString(), Updt.ToString(), "con_ControlNumber");
                }
                IsInsert = true;
                lblErrorMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event
    }
}