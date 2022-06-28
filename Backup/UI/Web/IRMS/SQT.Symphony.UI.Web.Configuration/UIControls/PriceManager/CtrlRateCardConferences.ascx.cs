using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardConferences : System.Web.UI.UserControl
    {
        #region Property And Variables
        public GridView gvucConferences
        {
            get { return this.gvConferences; }
        }

        public DataTable dtExistingDetails = null;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                litHeaderConferences.Text = clsCommon.GetGlobalResourceText("RateCardConferences", "litHeaderConferences", "Conferences");
            }
        }
        #endregion

        #region Control Events
        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;

            if (chkSelect != null)
            {
                int rowIndex = Convert.ToInt32(hfRowIndex.Value);
                TextBox txtRackRate = (TextBox)gvConferences.Rows[rowIndex].FindControl("txtRackRate");
                TextBox txtExtraAdult = (TextBox)gvConferences.Rows[rowIndex].FindControl("txtExtraAdult");
                TextBox txtExtraChild = (TextBox)gvConferences.Rows[rowIndex].FindControl("txtExtraChild");
                RequiredFieldValidator rfvRackRate = (RequiredFieldValidator)gvConferences.Rows[rowIndex].FindControl("rfvRackRate");

                if (chkSelect.Checked)
                {
                    rfvRackRate.Enabled = txtRackRate.Enabled = txtExtraAdult.Enabled = txtExtraChild.Enabled = true;

                    ((RegularExpressionValidator)gvConferences.Rows[rowIndex].FindControl("regRackRate")).Enabled = true;
                    ((RegularExpressionValidator)gvConferences.Rows[rowIndex].FindControl("regExtraAdult")).Enabled = true;
                    ((RegularExpressionValidator)gvConferences.Rows[rowIndex].FindControl("regExtraChild")).Enabled = true;                    
                }
                else
                {
                    rfvRackRate.Enabled = txtRackRate.Enabled = txtExtraAdult.Enabled = txtExtraChild.Enabled = false;

                    ((RegularExpressionValidator)gvConferences.Rows[rowIndex].FindControl("regRackRate")).Enabled = false;
                    ((RegularExpressionValidator)gvConferences.Rows[rowIndex].FindControl("regExtraAdult")).Enabled = false;
                    ((RegularExpressionValidator)gvConferences.Rows[rowIndex].FindControl("regExtraChild")).Enabled = false;
                }
            }
        }
        #endregion

        #region Grid Events
        protected void gvConferences_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Attributes.Add("onclick", "fnSetRowIndex('" + Convert.ToString(e.Row.DataItemIndex) + "');");

                RegularExpressionValidator regRackRate = (RegularExpressionValidator)e.Row.FindControl("regRackRate");
                RegularExpressionValidator regExtraAdult = (RegularExpressionValidator)e.Row.FindControl("regExtraAdult");
                RegularExpressionValidator regExtraChild = (RegularExpressionValidator)e.Row.FindControl("regExtraChild");

                int allowedDecimalPlace = Convert.ToInt32(clsSession.DigitsAfterDecimalPoint);
                string strRegExpression = "\\d{0,13}.\\d{0," + Convert.ToString(allowedDecimalPlace) + "}";

                regRackRate.ValidationExpression = regExtraAdult.ValidationExpression = regExtraChild.ValidationExpression = strRegExpression;

                TextBox txtRackRate = (TextBox)e.Row.FindControl("txtRackRate");
                string strRackRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RackRate"));
                if (strRackRate != string.Empty)
                {
                    strRackRate = strRackRate + "000000";
                    txtRackRate.Text = strRackRate.Substring(0, strRackRate.LastIndexOf(".") + 1 + allowedDecimalPlace);
                }

                if (dtExistingDetails != null)
                {
                    DataRow[] rows = dtExistingDetails.Select("ConferenceID = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ConferenceID")) + "'");
                    if (rows.Length > 0)
                    {
                        ((RequiredFieldValidator)e.Row.FindControl("rfvRackRate")).Enabled = true;
                        ((CheckBox)e.Row.FindControl("chkSelect")).Checked = true;

                        TextBox txtExtraAdult = (TextBox)e.Row.FindControl("txtExtraAdult");
                        TextBox txtExtraChild = (TextBox)e.Row.FindControl("txtExtraChild");

                        txtRackRate.Enabled = txtExtraAdult.Enabled = txtExtraChild.Enabled = true;

                        string strRackRateNew = Convert.ToString(rows[0]["RackRate"]);
                        if (strRackRateNew != string.Empty)
                            txtRackRate.Text = strRackRateNew.Substring(0, strRackRateNew.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strExtraAdultRate = Convert.ToString(rows[0]["ExtraAdultRate"]);
                        if (strExtraAdultRate != string.Empty)
                            txtExtraAdult.Text = strExtraAdultRate.Substring(0, strExtraAdultRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strChildRate = Convert.ToString(rows[0]["ChildRate"]);
                        if (strChildRate != string.Empty)
                            txtExtraChild.Text = strChildRate.Substring(0, strChildRate.LastIndexOf(".") + 1 + allowedDecimalPlace);
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Literal)e.Row.FindControl("litGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("RateCardConferences", "lblGvHdrSelect", "Select");
                ((Literal)e.Row.FindControl("litGvHdrConferenceName")).Text = clsCommon.GetGlobalResourceText("RateCardConferences", "lblGvHdrConferenceName", "Conference");
                ((Literal)e.Row.FindControl("litGvHdrRackRate")).Text = clsCommon.GetGlobalResourceText("RateCardConferences", "lblGvHdrRackRate", "Rack Rate");
                ((Literal)e.Row.FindControl("litGvHdrExtraAdult")).Text = clsCommon.GetGlobalResourceText("RateCardConferences", "lblGvHdrExtraAdult", "Ext. Adult");
                ((Literal)e.Row.FindControl("litGvHdrExtChild")).Text = clsCommon.GetGlobalResourceText("RateCardConferences", "lblGvHdrExtChild", "Ext. Child");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }
        #endregion
    }
}