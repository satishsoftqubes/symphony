using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonExtendReservation : System.Web.UI.UserControl
    {
        #region Property and Variable

        ////public ModalPopupExtender ucMpeAddEditExtendReservation
        ////{
        ////    get { return this.mpeExtendReservation; }
        ////}

        public event EventHandler btnExtendReservationCallParent_Click;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindExtendReservationGrid();
            }
        }

        #endregion

        #region Control Events

        protected void btnAddCardInfo_Click(object sender, EventArgs e)
        {
            //if (this.Page.IsValid)
            //{

            if (ddlERCardType.SelectedValue == "Card")
            {
                ////mpeExtendReservation.Show();

                EventHandler temp = btnExtendReservationCallParent_Click;
                if (temp != null)
                {
                    temp(sender, e);
                }

                CtrlERCommonCardInfo.ucMpeAddEditCardInfo.Show();

                CtrlERCommonCardInfo.uclitDisplayCardHolderName.Text = CtrlERCommonCardInfo.uctxtCardHolderName.Text = "Mr. Prakash Patel";
                CtrlERCommonCardInfo.ClearControlCardInfo();
                CtrlERCommonCardInfo.BindCardListGrid();

            }

           
           // }
        }
        
        #endregion

        #region Private Method

        private void BindExtendReservationGrid()
        {
            DataTable dtTable = new DataTable();

            DataColumn dc1 = new DataColumn("Date");
            DataColumn dc2 = new DataColumn("Rate");
            DataColumn dc3 = new DataColumn("UnitRate");
            DataColumn dc4 = new DataColumn("Tax");
            DataColumn dc5 = new DataColumn("Discount");
            DataColumn dc6 = new DataColumn("Service");
            DataColumn dc7 = new DataColumn("Extra");
            DataColumn dc8 = new DataColumn("Total");

            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);
            dtTable.Columns.Add(dc6);
            dtTable.Columns.Add(dc7);
            dtTable.Columns.Add(dc8);            

            DataRow dr1 = dtTable.NewRow();
            dr1["Date"] = "10-08-2012";
            dr1["Rate"] = "200.00";
            dr1["UnitRate"] = "200.00";
            dr1["Tax"] = "0.00";
            dr1["Discount"] = "0.00";
            dr1["Service"] = "0.00";
            dr1["Extra"] = "0.00";
            dr1["Total"] = "400.00";
            

            dtTable.Rows.Add(dr1);

            DataRow dr2 = dtTable.NewRow();
            dr2["Date"] = "11-08-2012";
            dr2["Rate"] = "200.00";
            dr2["UnitRate"] = "200.00";
            dr2["Tax"] = "0.00";
            dr2["Discount"] = "0.00";
            dr2["Service"] = "0.00";
            dr2["Extra"] = "0.00";
            dr2["Total"] = "400.00";
            
            dtTable.Rows.Add(dr2);

            gvExtendReservationList.DataSource = dtTable;
            gvExtendReservationList.DataBind();
        }

        #endregion
    }
}