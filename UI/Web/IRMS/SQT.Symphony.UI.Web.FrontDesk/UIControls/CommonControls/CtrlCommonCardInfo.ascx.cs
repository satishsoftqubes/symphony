using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonCardInfo : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditCardInfo
        {
            get { return this.mpeAddCardDetails; }
        }

        public TextBox uctxtCardHolderName
        {
            get { return this.txtCardHolderName; }
        }

        public Literal uclitDisplayCardHolderName
        {
            get { return this.litDisplayCardHolderName; }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCardListGrid();
            }
        }

        #endregion

        #region Methods
        
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
                dr1["CardNo"] = "************9514";
                dr1["Name"] = "Mr. Hari Patel";
                dr1["ExpiryDate"] = "01-08-2012";
                dr1["SecurityCode"] = "951753";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Type"] = "Solo";
                dr2["CardNo"] = "************7531";
                dr2["Name"] = "Mr. Hari Patel";
                dr2["ExpiryDate"] = "30-08-2014";
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
            txtCardNo.Text = txtCardHolderName.Text = txtIssueDate.Text = txtExpiryDate.Text = txtIssueNo.Text = txtSecurityCode.Text = txtAuthorizedAmount.Text = "";
        }

        #endregion
        
    }
}