using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp
{
    public partial class CtrlActionLog : System.Web.UI.UserControl
    {
        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            DataTable tbl = new DataTable();

            DataColumn col1 = new DataColumn();
            col1.ColumnName = "ActionPerformedBy";
            tbl.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "ActionPerformedOn";
            tbl.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.ColumnName = "ActionObject";
            tbl.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.ColumnName = "ActionType";
            tbl.Columns.Add(col4);

            DataColumn col5 = new DataColumn();
            col5.ColumnName = "ObjectOldValue";
            tbl.Columns.Add(col5);

            DataColumn col6 = new DataColumn();
            col6.ColumnName = "ObjectNewValue";
            tbl.Columns.Add(col6);

            DataColumn col7 = new DataColumn();
            col7.ColumnName = "LoginInLogID";
            tbl.Columns.Add(col7);

            DataRow dr = tbl.NewRow();
            dr["ActionPerformedBy"] = "Insert Opration";
            dr["ActionPerformedOn"] = "12/12/2012";
            dr["ActionObject"] = "Reporting Viewwser";
            dr["ActionType"] = "View";
            dr["ObjectOldValue"] = "OldValue1";
            dr["ObjectNewValue"] = "First Change Value1";
            dr["LoginInLogID"] = "Admin";

            tbl.Rows.Add(dr);

            DataRow dr1 = tbl.NewRow();
            dr1["ActionPerformedBy"] = "Insert Opration";
            dr1["ActionPerformedOn"] = "12/12/2012";
            dr1["ActionObject"] = "Reporting Viewwser";
            dr1["ActionType"] = "View";
            dr1["ObjectOldValue"] = "OldValue1";
            dr1["ObjectNewValue"] = "First Change Value1";
            dr1["LoginInLogID"] = "Admin";
            tbl.Rows.Add(dr1);

            gvLoginLogList.DataSource = tbl;
            gvLoginLogList.DataBind();
        }
        #endregion Private Method
    }
}