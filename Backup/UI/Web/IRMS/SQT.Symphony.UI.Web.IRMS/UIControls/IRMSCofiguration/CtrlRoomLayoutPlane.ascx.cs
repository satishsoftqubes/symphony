using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration
{
    public partial class CtrlRoomLayoutPlane : System.Web.UI.UserControl
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
        /// Load Default Data Here
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindGridInformation();
                BindGridDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bing Deatails Grind Information
        /// </summary>
        private void BindGridDetails()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.ColumnName = "PropertyName";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "WingName";
            dt.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.ColumnName = "FloorName";
            dt.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.ColumnName = "CarpetArea";
            dt.Columns.Add(col4);

            DataRow dr = dt.NewRow();
            dr["PropertyName"] = "Uni World";
            dr["WingName"] = "Wing A";
            dr["FloorName"] = "Floor 1";
            dr["CarpetArea"] = "1500Sqft";

            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["PropertyName"] = "Uni World";
            dr1["WingName"] = "Wing B";
            dr1["FloorName"] = "Floor 1";
            dr1["CarpetArea"] = "1400Sqft";

            dt.Rows.Add(dr1);

            grdRoomLayoutPlaneDetailsList.DataSource = dt;
            grdRoomLayoutPlaneDetailsList.DataBind();
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGridInformation()
        {
            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.ColumnName = "PropertyName";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "PlanName";
            dt.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.ColumnName = "PlanCode";
            dt.Columns.Add(col3);

            DataRow dr = dt.NewRow();
            dr["PropertyName"] = "Uni World";
            dr["PlanName"] = "CityWorld";
            dr["PlanCode"] = "CW-#001";

            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["PropertyName"] = "UB City";
            dr1["PlanName"] = "Canbarra";
            dr1["PlanCode"] = "CN-#002";

            dt.Rows.Add(dr1);

            grdRoomLayoutPlaneList.DataSource = dt;
            grdRoomLayoutPlaneList.DataBind();
        }
        #endregion Private Method
    }
}