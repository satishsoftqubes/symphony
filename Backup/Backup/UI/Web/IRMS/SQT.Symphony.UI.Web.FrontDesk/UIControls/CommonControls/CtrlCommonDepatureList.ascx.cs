using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonDepatureList : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartureGrid();
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindDepartureGrid()
        {
            try
            {
                DataSet dsCheckOutList = ReservationBLL.SelectDepatureListData(null, clsSession.PropertyID, clsSession.CompanyID, null, null, null, DateTime.Now, DateTime.Now, null);

                if (dsCheckOutList.Tables.Count > 0 && dsCheckOutList.Tables[0].Rows.Count > 0)
                {
                    gvDeparture.DataSource = dsCheckOutList.Tables[0];
                    gvDeparture.DataBind();
                }
                else
                {
                    gvDeparture.DataSource = null;
                    gvDeparture.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        protected void gvDeparture_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblgvRoomNo = (Label)e.Row.FindControl("lblgvRoomNo");
                    string strRoom = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblgvRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoom));


                    Label lblGvDeparturePayment = (Label)e.Row.FindControl("lblGvDeparturePayment");
                    decimal dcmlBalance = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Balance"));
                    lblGvDeparturePayment.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}