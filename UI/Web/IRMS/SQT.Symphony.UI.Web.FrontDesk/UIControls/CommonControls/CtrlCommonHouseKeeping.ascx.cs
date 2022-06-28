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
    public partial class CtrlCommonHouseKeeping : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditHouseKeeping
        {
            get { return this.mpeHouseKeeping; }
        }
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHouseKeepingGrid();
            }
        }

        #endregion

        #region Private Method

        public void BindHouseKeepingGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("Date");
                DataColumn dc2 = new DataColumn("Notes");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);

                DataRow dr1 = dtTable.NewRow();
                dr1["Date"] = "12-May-2012";
                dr1["Notes"] = "Default HouseKeeping";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["Date"] = "11-May-2012";
                dr2["Notes"] = "Default HouseKeeping";

                dtTable.Rows.Add(dr2);

                gvHouseKeepingList.DataSource = dtTable;
                gvHouseKeepingList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}