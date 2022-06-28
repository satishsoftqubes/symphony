using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;
using System.Data;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlCommonBillToCompany : System.Web.UI.UserControl
    {

        #region Property and Variable

        public ModalPopupExtender ucMpeBillToCompany
        {
            get { return this.mpeBillToCompany; }
        }

        public Literal uclitDisplayBillingMode
        {
            get { return this.litDisplayBillingMode; }
        }

        public TextBox uctxtCompnayWillBare
        {
            get { return this.txtCompnayWillBare; }
        }

        public TextBox uctxtBillToCmpStartDate
        {
            get { return this.txtBillToCmpStartDate; }
        }

        public TextBox uctxtBillToCmpEndDate
        {
            get { return this.txtBillToCmpEndDate; }
        }

        public DropDownList ucddlDiscountType
        {
            get { return this.ddlDiscountType; }
        }

        public CalendarExtender uccalBillToCmpStartDate
        {
            get { return this.calBillToCmpStartDate; }
        }

        public CalendarExtender uccalBillToCmpEndDate
        {
            get { return this.calBillToCmpEndDate; }
        }

        public Guid Reservation_ID
        {
            get
            {
                return ViewState["Reservation_ID"] != null ? new Guid(Convert.ToString(ViewState["Reservation_ID"])) : Guid.Empty;
            }
            set
            {
                ViewState["Reservation_ID"] = value;
            }
        }

        public bool IsListMessage = false;

        public event EventHandler btnCommonBillToCompanyCallParent_Click;

        public decimal dcmlAmtPayByCmp;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Page Load

        #region Private Method

        //public void SetRateMaxValue()
        //{
        //    if (ddlDiscountType.SelectedIndex == 0)
        //    {
        //        rvDiscountType.Enabled = true;
        //        rvDiscountType.MaximumValue = "100";
        //    }
        //    else
        //    {
        //        rvDiscountType.Enabled = false;
        //        rvDiscountType.MaximumValue = "999999999999999999";// 18 chars
        //    }
        //}

        public void setRow()
        {
            hfDateFormat.Value = calBillToCmpStartDate.Format = calBillToCmpEndDate.Format = clsSession.DateFormat;
            ddlDiscountType.SelectedIndex = 0;
            txtCompnayWillBare.Text = lblDiscountErrorMsg.Text = txtBillToCmpStartDate.Text = txtBillToCmpEndDate.Text = "";
            gvBlockDateRateList.PageIndex = 0;
        }

        public void BindRateGrid()
        {
            try
            {
                if (this.Reservation_ID != Guid.Empty)
                {
                    DataSet dsBlockDateRate = new DataSet();
                    BlockDateRate objBlockDateRate = new BlockDateRate();
                    objBlockDateRate.ReservationID = this.Reservation_ID;
                    objBlockDateRate.PropertyID = clsSession.PropertyID;
                    objBlockDateRate.CompanyID = clsSession.CompanyID;

                    dsBlockDateRate = BlockDateRateBLL.GetAllWithDataSet(objBlockDateRate);

                    if (dsBlockDateRate != null && dsBlockDateRate.Tables.Count > 0 && dsBlockDateRate.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = new DataView(dsBlockDateRate.Tables[0]);
                        dv.Sort = "BlockDate asc";

                        gvBlockDateRateList.DataSource = dv;
                        gvBlockDateRateList.DataBind();
                    }
                    else
                    {
                        gvBlockDateRateList.DataSource = null;
                        gvBlockDateRateList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox1.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Dropdown Event

        //protected void ddlDiscountType_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    mpeBillToCompany.Show();
        //    SetRateMaxValue();
        //}

        #endregion Dropdown Event

        #region Grid Event

        protected void gvBlockDateRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvBlockDateRate = (Label)e.Row.FindControl("lblGvBlockDateRate");
                    Label lblGvBlockDateTax = (Label)e.Row.FindControl("lblGvBlockDateTax");
                    Label lblGvTotal = (Label)e.Row.FindControl("lblGvTotal");
                    Label lblGvB2C = (Label)e.Row.FindControl("lblGvB2C");
                    Label lblGvB2G = (Label)e.Row.FindControl("lblGvB2G");

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")) != "")
                    {
                        decimal dcmlRateCardRate = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RateCardRate"));
                        lblGvBlockDateRate.Text = dcmlRateCardRate.ToString().Substring(0, dcmlRateCardRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvBlockDateRate.Text = "0.00";

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")) != "")
                    {
                        decimal dcmlAppliedTax = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AppliedTax"));
                        lblGvBlockDateTax.Text = dcmlAppliedTax.ToString().Substring(0, dcmlAppliedTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvBlockDateTax.Text = "0.00";

                    lblGvTotal.Text = Convert.ToString(Convert.ToDecimal(lblGvBlockDateRate.Text.Trim()) + Convert.ToDecimal(lblGvBlockDateTax.Text.Trim()));

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReRouteCharge")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReRouteCharge")) != "")
                    {
                        decimal dcmlReRouteCharge = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReRouteCharge"));
                        lblGvB2C.Text = dcmlReRouteCharge.ToString().Substring(0, dcmlReRouteCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvB2C.Text = "0.00";

                    lblGvB2G.Text = Convert.ToString(Convert.ToDecimal(lblGvTotal.Text.Trim()) - Convert.ToDecimal(lblGvB2C.Text.Trim()));
                }
            }
            catch (Exception ex)
            {
                MessageBox1.Show(ex.Message.ToString());
            }
        }

        protected void gvBlockDateRateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mpeBillToCompany.Show();
            gvBlockDateRateList.PageIndex = e.NewPageIndex;
            BindRateGrid();
        }

        #endregion Grid Event

        #region Button Event

        protected void btnApply_Click(object sender, EventArgs e)
        {
            mpeBillToCompany.Show();
            if (this.Page.IsValid)
            {
                try
                {
                    lblDiscountErrorMsg.Text = "";

                    if (this.Reservation_ID != Guid.Empty)
                    {
                        if (ddlDiscountType.SelectedIndex == 0)
                        {
                            if (Convert.ToDecimal(txtCompnayWillBare.Text.Trim()) > 100)
                            {
                                lblDiscountErrorMsg.Text = "% should be less than or equal to 100.";
                                return;
                            }
                        }

                        if (ddlDiscountType.SelectedIndex == 1)
                        {
                            for (int i = 0; i < gvBlockDateRateList.Rows.Count; i++)
                            {
                                Label lblGvTotal = (Label)gvBlockDateRateList.Rows[i].FindControl("lblGvTotal");

                                if (Convert.ToDecimal(txtCompnayWillBare.Text.Trim()) > Convert.ToDecimal(lblGvTotal.Text.Trim()))
                                {
                                    lblDiscountErrorMsg.Text = "Bill to compnay should not greater than total rate.";
                                    return;
                                }
                            }
                        }

                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                        DateTime dtStartDate = DateTime.ParseExact(Convert.ToString(txtBillToCmpStartDate.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                        DateTime dtEndDate = DateTime.ParseExact(Convert.ToString(txtBillToCmpEndDate.Text.Trim()), clsSession.DateFormat, objCultureInfo);

                        string strDiscountType = string.Empty;
                        if (ddlDiscountType.SelectedIndex == 0)
                            strDiscountType = "PERCENTAGE";
                        else
                            strDiscountType = "FLAT";

                        BlockDateRateBLL.BillingToCompany(dtStartDate, dtEndDate, Convert.ToDecimal(txtCompnayWillBare.Text.Trim()), strDiscountType, this.Reservation_ID, null);

                        IsListMessage = true;
                        lblListMessage.Text = "Bill to Company Rate applied Successfully.";

                        gvBlockDateRateList.PageIndex = 0;
                        BindRateGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox1.Show(ex.Message.ToString());
                }

                //this.Reservation_ID = Guid.Empty;
            }
        }

        protected void iBtnCloseForm_Click(object sender, EventArgs e)
        {
            dcmlAmtPayByCmp = Convert.ToDecimal("0.000000");
            string strQuery = "select ISNULL(SUM(ReRouteCharge),0) 'ReRouteCharge' from res_BlockDateRate where ReservationID = '" + Convert.ToString(this.Reservation_ID) + "'";

            DataSet ds = RoomBLL.GetUnitNo(strQuery);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dcmlAmtPayByCmp = Convert.ToDecimal(ds.Tables[0].Rows[0]["ReRouteCharge"]);
            }

            EventHandler temp = btnCommonBillToCompanyCallParent_Click;
            if (temp != null)
            {
                temp(sender, e);
            }
        }

        #endregion Button Event
    }
}