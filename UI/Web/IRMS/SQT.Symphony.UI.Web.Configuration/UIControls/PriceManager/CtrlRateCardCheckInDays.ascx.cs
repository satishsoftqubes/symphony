using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardCheckInDays : System.Web.UI.UserControl
    {
        #region Property And Variables
        public CheckBoxList ucChkLstDays
        {
            get { return this.chkLstDays; }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
            }
        }
        #endregion

        #region Methods
        public void SetPageLables()
        {
            litHeaderAllowRateCardOnCheckinDays.Text = clsCommon.GetGlobalResourceText("RateCard", "lblHeaderAllowRateCardOnCheckinDays", "Allow Ratecard on Check-in Days");
        }

        public void BindCheckboxList()
        {
            DataTable dtCheckInDays = new DataTable();
            DataColumn clText = new DataColumn("DataTextField");
            DataColumn clValue = new DataColumn("DataValueField");
            dtCheckInDays.Columns.Add(clText);
            dtCheckInDays.Columns.Add(clValue);

            DataRow drAll = dtCheckInDays.NewRow();
            drAll["DataTextField"] = "ALL"; //clsCommon.GetGlobalResourceText("RateCard", "lblCheckinMonday", "MON");
            drAll["DataValueField"] = "ALL";
            dtCheckInDays.Rows.Add(drAll);

            DataRow dr1 = dtCheckInDays.NewRow();
            dr1["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinMonday", "MON");
            dr1["DataValueField"] = "MONDAY";
            dtCheckInDays.Rows.Add(dr1);

            DataRow dr2 = dtCheckInDays.NewRow();
            dr2["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinTuesday", "TUE");
            dr2["DataValueField"] = "TUESDAY";
            dtCheckInDays.Rows.Add(dr2);

            DataRow dr3 = dtCheckInDays.NewRow();
            dr3["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinWednesday", "WED");
            dr3["DataValueField"] = "WEDNESDAY";
            dtCheckInDays.Rows.Add(dr3);

            DataRow dr4 = dtCheckInDays.NewRow();
            dr4["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinThursday", "THU");
            dr4["DataValueField"] = "THURSDAY";
            dtCheckInDays.Rows.Add(dr4);

            DataRow dr5 = dtCheckInDays.NewRow();
            dr5["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinFriday", "FRI");
            dr5["DataValueField"] = "FRIDAY";
            dtCheckInDays.Rows.Add(dr5);

            DataRow dr6 = dtCheckInDays.NewRow();
            dr6["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinSaturday", "SAT");
            dr6["DataValueField"] = "SATURDAY";
            dtCheckInDays.Rows.Add(dr6);

            DataRow dr7 = dtCheckInDays.NewRow();
            dr7["DataTextField"] = clsCommon.GetGlobalResourceText("RateCard", "lblCheckinSunday", "SUN");
            dr7["DataValueField"] = "SUNDAY";
            dtCheckInDays.Rows.Add(dr7);

            chkLstDays.DataTextField = "DataTextField";
            chkLstDays.DataValueField = "DataValueField";
            chkLstDays.DataSource = dtCheckInDays;
            chkLstDays.DataBind();
        }
        #endregion
    }
}