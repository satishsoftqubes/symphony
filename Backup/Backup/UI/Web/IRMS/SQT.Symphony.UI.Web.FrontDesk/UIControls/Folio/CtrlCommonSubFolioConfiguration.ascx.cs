using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlCommonSubFolioConfiguration : System.Web.UI.UserControl
    {
        #region Property and Variable

        public string strMode
        {
            get
            {
                return ViewState["strMode"] != null ? Convert.ToString(ViewState["strMode"]) : string.Empty;
            }
            set
            {
                ViewState["strMode"] = value;
            }
        }

        public MultiView mvOpenSubFolio
        {
            get { return this.mvSubFolio; }
        }

        public event EventHandler btnSubFolioConfigurationCallParent_Click;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvSubFolio.ActiveViewIndex = 0;
                ClearControlSubFolio();
                BindSubFolioGrid();
            }
        }

        #endregion

        #region Private Method

        private void BindSubFolioGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("FolioNo");
                DataColumn dc2 = new DataColumn("GuestName");
                DataColumn dc3 = new DataColumn("CreatedOn");
                DataColumn dc4 = new DataColumn("Balance");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);

                DataRow dr1 = dtTable.NewRow();
                dr1["FolioNo"] = "30417";
                dr1["GuestName"] = "Mr. Bharat Patel";
                dr1["CreatedOn"] = "11-08-2012";
                dr1["Balance"] = "120.00";

                dtTable.Rows.Add(dr1);

                gvSubFolioList.DataSource = dtTable;
                gvSubFolioList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearControlSubFolio()
        {
            ddlSubFolioGuestName.SelectedIndex = ddlTitle.SelectedIndex = 0;
            txtAddress.Text = txtCityName.Text = txtContactNo.Text = txtCountryName.Text = txtFirstName.Text = txtLastName.Text = txtStateName.Text = txtZipCode.Text = "";
        }

        public void BindCardListGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Type");
                DataColumn dc2 = new DataColumn("CardNo");
                DataColumn dc3 = new DataColumn("Name");
                DataColumn dc4 = new DataColumn("ExpiryDate");
                DataColumn dc5 = new DataColumn("SecurityCode");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);
                dtTable.Columns.Add(dc3);
                dtTable.Columns.Add(dc4);
                dtTable.Columns.Add(dc5);

                DataRow dr1 = dtTable.NewRow();
                dr1["Type"] = "Mastercard";
                dr1["CardNo"] = "123456";
                dr1["Name"] = "Mr. Hari Patel";
                dr1["ExpiryDate"] = "15-08-2012";
                dr1["SecurityCode"] = "951753";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Type"] = "Solo";
                dr2["CardNo"] = "654123";
                dr2["Name"] = "Mr. Hari Patel";
                dr2["ExpiryDate"] = "16-08-2014";
                dr2["SecurityCode"] = "3571596";

                dtTable.Rows.Add(dr2);

                gvCardList.DataSource = dtTable;
                gvCardList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ClearControlCardInfo()
        {
            ddlCardType.SelectedIndex = 0;
            txtCardNo.Text = txtCardHolderName.Text = txtIssueDate.Text = txtExpiryDate.Text = txtIssueNo.Text = txtSecurityCode.Text = txtAuthorizationCode.Text = txtAuthorizedAmount.Text = "";
        }

        #endregion

        #region Control Event

        protected void btnSubFolioCardInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlCardInfo();
                txtCardHolderName.Text = litDisplayCardHolderName.Text = Convert.ToString(ddlTitle.SelectedValue + " " + txtFirstName.Text.Trim());
                BindCardListGrid();

                string strPageName = GetPageName();

                if (strPageName.ToUpper() == "REROUTEFOLIOSETUP.ASPX")
                {
                    mvSubFolio.ActiveViewIndex = 1;
                }
                else
                {
                    strMode = "OPENPOPUP";
                    EventHandler temp1 = btnSubFolioConfigurationCallParent_Click;
                    if (temp1 != null)
                    {
                        temp1(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSubFolioCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string strPageName = GetPageName();

                if (strPageName.ToUpper() == "FOLIODETAILS.ASPX")
                {
                    strMode = "CLOSEPOPUP";
                }
                else if (strPageName.ToUpper() == "ROOMRESERVATIONLIST.ASPX")
                {
                    strMode = "SHOWVIEWWITHRRPOPUP0";
                }
                else if (strPageName.ToUpper() == "FOLIOLIST.ASPX")
                {
                    strMode = "CLOSESUBFOLIO";
                }


                EventHandler temp = btnSubFolioConfigurationCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnCancelCardDetails_Click(object sender, EventArgs e)
        {
            string strPageName = GetPageName();

            if (strPageName.ToUpper() == "REROUTEFOLIOSETUP.ASPX")
            {
                mvSubFolio.ActiveViewIndex = 0;
            }
            else
            {
                strMode = "SHOWVIEWWITHPOPUP0";
                EventHandler temp1 = btnSubFolioConfigurationCallParent_Click;
                if (temp1 != null)
                {
                    temp1(sender, e);
                }
            }
        }

        private string GetPageName()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            string[] strArray = path.Split('/');
            string strPageName = "";
            return strPageName = Convert.ToString(strArray[strArray.Length - 1]);
        }
        #endregion
    }
}