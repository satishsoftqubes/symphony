using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlUnitResell : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;
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
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvResellUnit.ActiveViewIndex = 1;
                BindControls();
            }
        }
        #endregion

        #region Control Events
        protected void rdblResellTo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdblResellTo.SelectedValue.ToString() == "1")
            {
                mvResellUnit.ActiveViewIndex = 1;
            }
        }

        protected void ddlInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInvestor.SelectedValue != Guid.Empty.ToString())
            {
                BindInvestorsUnit();
            }
            else
            {
                ddlUnitNo.Items.Clear();
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        { 
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                DateTime sellDate = DateTime.Today;

                if (txtSellDate.Text.Trim() != "")
                    sellDate = DateTime.ParseExact(txtSellDate.Text.Trim(), this.DateFormat, objCultureInfo);

                InvestorsUnitBLL.SaveResell("SELLTOCOMPANY", new Guid(ddlUnitNo.SelectedValue.ToString()), null, DateTime.Now, new Guid(Convert.ToString(Session["UserID"])), sellDate);

                IsMessage = true;
                lblErrorMessage.Text = "Unit resell to Company successfully.";

                ddlUnitNo.Items.Clear();
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlInvestor.SelectedIndex = 0;
                txtSellDate.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            //mvResellUnit.ActiveViewIndex = 0;
            ddlUnitNo.Items.Clear();
            ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddlInvestor.SelectedIndex = 0;
            txtSellDate.Text = string.Empty;
        }
        #endregion

        #region Private Methods
        private void BindControls()
        {
            this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
            if (Session["PropertyConfigurationInfo"] != null)
            {
                PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];

                string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                }
                else
                {
                    this.DateFormat = "dd/MM/yyyy";
                }
            }
            else
            {
                this.DateFormat = "dd/MM/yyyy";
            }

            calSellDate.Format = this.DateFormat;

            string InvestorQuery = "Select InvestorID, FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "' order by FName asc");
            DataSet dsInvestor = InvestorBLL.GetSearchData(InvestorQuery);
            if (dsInvestor.Tables[0].Rows.Count != 0)
            {
                DataView dvInvestor = new DataView(dsInvestor.Tables[0]);
                dvInvestor.Sort = "FullName Asc";
                ddlInvestor.DataSource = dvInvestor;
                ddlInvestor.DataTextField = "FullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlInvestor.SelectedValue = Convert.ToString(Session["InvID"]);
            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void BindInvestorsUnit()
        {
            if (ddlInvestor.SelectedIndex != 0)
            {
                ddlUnitNo.Items.Clear();
                DataSet ds = InvestorsUnitBLL.SelectInvestorsUnitForResell(new Guid(ddlInvestor.SelectedValue.ToString()));
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ddlUnitNo.DataSource = ds.Tables[0];
                    ddlUnitNo.DataTextField = "RoomNo";
                    ddlUnitNo.DataValueField = "InvestorRoomID";
                    ddlUnitNo.DataBind();
                    ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        protected void vFinalPaymentDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1900/12/01");
            DateTime maxDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
        #endregion
    }
}