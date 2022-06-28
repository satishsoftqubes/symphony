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
    public partial class CtrlAutoAssignUnit : System.Web.UI.UserControl
    {
        #region Property and Variable

        public ModalPopupExtender ucMpeAddEditAutoAssignUnit
        {
            get { return this.mpeAutoAssignUnit; }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindAutoAssignUnitGrid();
            }
        }

        #endregion

        #region Private Method

        private void BindAutoAssignUnitGrid()
        {
            try
            {
                DataTable dtTable = new DataTable();

                DataColumn dc1 = new DataColumn("UnitNo");
                DataColumn dc2 = new DataColumn("BlockFloor");

                dtTable.Columns.Add(dc1);
                dtTable.Columns.Add(dc2);

                DataRow dr1 = dtTable.NewRow();
                dr1["UnitNo"] = "101";
                dr1["BlockFloor"] = "Block-A / 1";

                dtTable.Rows.Add(dr1);

                DataRow dr2 = dtTable.NewRow();
                dr2["UnitNo"] = "102";
                dr2["BlockFloor"] = "Block-A / 2";

                dtTable.Rows.Add(dr2);

                DataRow dr3 = dtTable.NewRow();
                dr3["UnitNo"] = "103";
                dr3["BlockFloor"] = "R-Block-A / 3";

                dtTable.Rows.Add(dr3);

                gvAutoAssignUnitList.DataSource = dtTable;
                gvAutoAssignUnitList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}