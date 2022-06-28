using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp
{
    public partial class CtrlLoginLog : System.Web.UI.UserControl
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
            col1.ColumnName = "PropertyName";
            tbl.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "UserName";
            tbl.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.ColumnName = "CounterName";
            tbl.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.ColumnName = "SessionName";
            tbl.Columns.Add(col4);

            DataColumn col5 = new DataColumn();
            col5.ColumnName = "TokenNo";
            tbl.Columns.Add(col5);

            DataColumn col6 = new DataColumn();
            col6.ColumnName = "LogIn";
            tbl.Columns.Add(col6);

            DataColumn col7 = new DataColumn();
            col7.ColumnName = "LogOut";
            tbl.Columns.Add(col7);

            DataRow dr = tbl.NewRow();
            dr["PropertyName"] = "UniWorld";
            dr["UserName"] = "Admin";
            dr["CounterName"] = "Counter NO 1";
            dr["SessionName"] = "695E4032-44FA-4615-94B5-F0A0CFC56F1B";
            dr["TokenNo"] = "AEF8299B-D14A-4205-9C57-C81CC262245B";
            dr["LogIn"] = "12/12/2012";
            dr["LogOut"] = "12/12/2012";

            tbl.Rows.Add(dr);

            DataRow dr1 = tbl.NewRow();
            dr1["PropertyName"] = "UniWorld";
            dr1["UserName"] = "Guest User";
            dr1["CounterName"] = "Counter NO 2";
            dr1["SessionName"] = "0EA384E5-4A00-470D-907B-429E428FAFA4";
            dr1["TokenNo"] = "DB6410BF-D15D-4957-842F-1E9585C49752";
            dr1["LogIn"] = "13/12/2012";
            dr1["LogOut"] = "13/12/2012";
            tbl.Rows.Add(dr1);

            gvLoginLogList.DataSource = tbl;
            gvLoginLogList.DataBind();
        }
        #endregion Private Method
    }
}