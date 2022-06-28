using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardTaxes : System.Web.UI.UserControl
    {
        #region Property and Variables
        public GridView gvucTaxes
        {
            get { return this.gvTaxes; }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                litHeaderTaxes.Text = clsCommon.GetGlobalResourceText("RateCard", "lblHeaderTaxes", "Taxes"); 
            }
        }
        #endregion

        #region Grid Events
        protected void gvTaxes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrTax")).Text = clsCommon.GetGlobalResourceText("RateCard", "lblGvHdrTax", "Tax");
                //((Literal)e.Row.FindControl("litGvHdrRate")).Text = clsCommon.GetGlobalResourceText("RateCard", "lblGvHdrRate", "Rate");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Attributes.Add("onclick", "fnSetRowIndex('" + Convert.ToString(e.Row.DataItemIndex) + "');");

                //Label lblRate = (Label)e.Row.FindControl("lblRate");
                //string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TaxRate"));
                //if (strRate != string.Empty)
                //{
                //    lblRate.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                //    if (!Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsTaxFlat")))
                //        lblRate.Text = lblRate.Text + " %";
                //}
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }
        #endregion
    }
}