using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio
{
    public partial class CtrlSubFolioList : System.Web.UI.UserControl
    {
        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion Page Load

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                CalStartDate.Format = calEndDate.Format = clsSession.DateFormat;
                BindFolioGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindFolioGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                string strFolioNo = null;
                string strReservationNo = null;
                string strGuestName = null;
                DateTime? dtStartDate = null;
                DateTime? dtEndDate = null;

                if (Convert.ToString(txtSearchFolioNo.Text.Trim()) != "")
                    strFolioNo = Convert.ToString(txtSearchFolioNo.Text.Trim());

                if (Convert.ToString(txtSearchReservationNo.Text.Trim()) != "")
                    strReservationNo = Convert.ToString(txtSearchReservationNo.Text.Trim());

                if (Convert.ToString(txtSearchGuestName.Text.Trim()) != "")
                    strGuestName = Convert.ToString(txtSearchGuestName.Text.Trim());

                if (Convert.ToString(txtSearchStartDate.Text.Trim()) != "")
                    dtStartDate = DateTime.ParseExact(Convert.ToString(txtSearchStartDate.Text.Trim()),clsSession.DateFormat,objCultureInfo);

                if (Convert.ToString(txtSearchEndDate.Text.Trim()) != "")
                    dtEndDate = DateTime.ParseExact(Convert.ToString(txtSearchEndDate.Text.Trim()), clsSession.DateFormat, objCultureInfo);

                DataSet dsData = FolioBLL.GetPastFolioList(strFolioNo, strReservationNo, strGuestName, dtStartDate, dtEndDate, clsSession.CompanyID, clsSession.PropertyID);
                if (dsData.Tables.Count > 0)
                {
                    gvFolioList.DataSource = dsData;
                    gvFolioList.DataBind();
                }
                else
                {
                    gvFolioList.DataSource = null;
                    gvFolioList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSearchControl()
        {
            txtSearchFolioNo.Text = txtSearchReservationNo.Text = txtSearchGuestName.Text = txtSearchStartDate.Text = txtSearchEndDate.Text = "";
        }

        #endregion Private Method

        #region Grid Event

        protected void gvFolioList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((Label)e.Row.FindControl("lblGvRoomNo")).Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"))));

                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Charges"));
                    ((Label)e.Row.FindControl("lblGvCharge")).Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    decimal dcmlPayment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Payment"));
                    ((Label)e.Row.FindControl("lblGvPayment")).Text = dcmlPayment.ToString().Substring(0, dcmlPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    decimal dcmlAdjustment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Adjustment"));
                    ((Label)e.Row.FindControl("lblGvAdjustment")).Text = dcmlAdjustment.ToString().Substring(0, dcmlAdjustment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvFolioList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFolioList.PageIndex = e.NewPageIndex;
            BindFolioGrid();
        }

        #endregion Grid Event

        #region Control Event

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvFolioList.PageIndex = 0;
            BindFolioGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            gvFolioList.PageIndex = 0;
            ClearSearchControl();
            BindFolioGrid();
        }

        #endregion Control Event
    }
}