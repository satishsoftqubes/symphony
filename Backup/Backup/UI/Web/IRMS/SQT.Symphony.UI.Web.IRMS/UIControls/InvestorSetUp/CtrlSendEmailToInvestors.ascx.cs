using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.IO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlSendEmailToInvestors : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;
        public bool IsPreview = false;

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
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                hdnComapnyIDForSendEmail.Value = Convert.ToString(this.CompanyID);
                string strManagerType = Convert.ToString(Session["InvUserType"]);
                if (Convert.ToString(Session["UserType"]).ToUpper() != "ADMIN" && strManagerType.ToUpper() != "ADMIN")
                {
                    string strQuery = string.Empty;

                    if (strManagerType.ToUpper() == "SALES")
                    {
                        strQuery = "select UserID,DisplayName from irm_SalesTeam Where IsActive = 1 and UserID = '" + Convert.ToString(Session["UserTypeID"]) + "'";

                        DataSet dsResult = PaymentSlabeBLL.GetPaymentSlab(strQuery);

                        if (dsResult.Tables[0] != null && dsResult.Tables[0].Rows.Count > 0)
                            txtSearchExecutiveName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DisplayName"]);
                        else
                            txtSearchExecutiveName.Text = "";
                    }
                    else if (strManagerType.ToUpper() == "CHANNEL PARTNER")
                    {
                        strQuery = "select UserID,DisplayName from irm_ChannelPartner Where IsActive = 1 and UserID = '" + Convert.ToString(Session["UserTypeID"]) + "'";

                        DataSet dsResult = PaymentSlabeBLL.GetPaymentSlab(strQuery);

                        if (dsResult.Tables[0] != null && dsResult.Tables[0].Rows.Count > 0)
                            txtSearchExecutiveName.Text = Convert.ToString(dsResult.Tables[0].Rows[0]["DisplayName"]);
                        else
                            txtSearchExecutiveName.Text = "";
                    }
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            Investor GetInv = new Investor();
            string InvestorName, Location, FirmName, ExecutiveName = null;
            if (hfSelectedAlphabet.Value.ToString() != string.Empty)
            {
                if (hfSelectedAlphabet.Value.ToString() != "ALL")
                    InvestorName = hfSelectedAlphabet.Value.ToString();
                else
                    InvestorName = null;

                hfSelectedAlphabet.Value = string.Empty;
            }
            else
            {
                if (txtSInvestorName.Text.Trim() != "")
                    InvestorName = txtSInvestorName.Text.Trim();
                else
                    InvestorName = null;
            }

            if (!txtSLocation.Text.Trim().Equals(""))
                Location = txtSLocation.Text.Trim();
            else
                Location = null;

            if (!txtSearchChannelPartnerFirm.Text.Trim().Equals(""))
                FirmName = txtSearchChannelPartnerFirm.Text.Trim();
            else
                FirmName = null;

            if (!txtSearchExecutiveName.Text.Trim().Equals(""))
            {
                string[] strExecutiveName = txtSearchExecutiveName.Text.Trim().Split('-');

                if (strExecutiveName.Length > 0)
                    ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                else
                    ExecutiveName = "";
            }
            else
                ExecutiveName = null;

            string UserType = Convert.ToString(Session["UserType"]);
            DataSet Dst = InvestorBLL.NewSearchInfo(InvestorName, Location, FirmName, ExecutiveName, this.CompanyID, "ALL");
            grdInvestorList.DataSource = Dst.Tables[0];
            grdInvestorList.DataBind();

            litInvestorsCount.Text = "(" + Convert.ToString(Dst.Tables[0].Rows.Count) + ")";
        }
        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
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

        protected void lnkAlphabet_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSInvestorName.Text = txtSLocation.Text = string.Empty;
                if (Session["UserType"] != null && Convert.ToString(Session["UserType"]).ToUpper() == "ADMIN")
                    txtSearchChannelPartnerFirm.Text = txtSearchExecutiveName.Text = string.Empty;

                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Button Event

        #region Grid Event

        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((CheckBox)e.Row.FindControl("chkViewSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkViewSelectAll")).ClientID + "','" + 1 + "')");
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            litMobileNo.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Grid Event


    }
}