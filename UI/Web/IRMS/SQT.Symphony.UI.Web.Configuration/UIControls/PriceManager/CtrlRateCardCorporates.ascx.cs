using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardCorporates : System.Web.UI.UserControl
    {
        #region Property And Variables
        public Guid RateCardID
        {
            get
            {
                return ViewState["RateCardID"] != null ? new Guid(Convert.ToString(ViewState["RateCardID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateCardID"] = value;
            }
        }

        public GridView gvucCorporates
        {
            get { return this.gvCorporates; }
        }

        public DataTable dtExistingDetails = null;
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                litHeaderCorporates.Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblHeaderCorporates", "Corporates");
            }
        }
        #endregion

        #region Control Events
        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;

            if (chkSelect != null)
            {
                ((CheckBox)gvCorporates.Rows[Convert.ToInt32(hfCorporateRowIndex.Value)].FindControl("chkIsDefault")).Enabled = chkSelect.Checked;
            }
        }
        #endregion

        #region Grid Events
        protected void gvCorporates_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Attributes.Add("onclick", "fnSetCorporateRowIndex('" + Convert.ToString(e.Row.DataItemIndex) + "');");

                CheckBox chkIsDefault = (CheckBox)e.Row.FindControl("chkIsDefault");
                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefaultRateID")) != string.Empty)
                {
                    chkIsDefault.Checked = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefaultRateID")) == Convert.ToString(this.RateCardID);
                }

                if (dtExistingDetails != null)
                {
                    DataRow[] rows = dtExistingDetails.Select("CorporateID = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CorporateID")) + "'");
                    ((CheckBox)e.Row.FindControl("chkSelect")).Checked = chkIsDefault.Enabled = rows.Length > 0;
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Literal)e.Row.FindControl("litGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblGvHdrSelect", "Select");
                ((Literal)e.Row.FindControl("litGvHdrAgentCorporate")).Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblGvHdrAgentCorporate", "Agent/Corporate");
                ((Literal)e.Row.FindControl("litGvHdrConpanyName")).Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblGvHdrConpanyName", "Company Name");
                ((Literal)e.Row.FindControl("litGvHdrCorporateType")).Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblGvHdrCorporateType", "Corporate Type");
                ((Literal)e.Row.FindControl("litGvHdrIsDefault")).Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblGvHdrIsDefault", "Is Default");
                ((Literal)e.Row.FindControl("litGvHdrDefaultRateCardName")).Text = clsCommon.GetGlobalResourceText("RateCardCorporates", "lblGvHdrDefaultRateCardName", "Default RateCard");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        #endregion
    }
}