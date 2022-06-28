using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;


namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class MarketRateList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }

        public bool IsMessage = false;

        public Guid PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
            }
        }

        public string DateOfRate
        {
            get
            {
                return ViewState["DateOfRate"] != null ? Convert.ToString(ViewState["DateOfRate"]) : string.Empty;
            }
            set
            {
                ViewState["DateOfRate"] = value;
            }
        }

        #endregion Property and Variables

        #region Form Load

        protected void Page_Load(object sender, EventArgs e)
        {
            /////mstChartPosition.Visible = false;

            if (!IsPostBack)
            {
                if (RoleRightJoinBLL.GetAccessString("UnitTypeMarketRate.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("UnitTypeMarketRate.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Create"] = btnAddUp.Visible = btnAddBottom.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        private void LoadDefaultValue()
        {
            try
            {
                if (Session["CompanyID"] != null)
                {
                    if (Session["PropertyConfigurationInfo"] != null)
                    {
                        PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                        ProjectTerm objProjectTerm = new ProjectTerm();
                        Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                        objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                        if (objProjectTerm != null)
                        {
                            this.DateFormat = objProjectTerm.Term;
                        }
                        else
                        {
                            this.DateFormat = "dd/MM/yyyy";
                        }
                    }
                    else
                    {
                        this.DateFormat = "dd/MM/yyyy";
                    }

                    Session.Remove("strPropertyAndDate");
                    /////mstChartPosition.Visible = false;
                    calFromDate.Format = calToDate.Format = this.DateFormat;
                    BindProperty();
                    txtFromDate.Text = txtToDate.Text = "";

                    if (Session["PropertyID4UnitInfo"] != null)
                    {
                        BindGrid();
                    }
                    else
                    {
                        message.Visible = true;
                        gvUnitTypeMarketRateList.DataSource = null;
                        gvUnitTypeMarketRateList.DataBind();
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        //private void BindGrid()
        //{
        //    try
        //    {
        //        string strQuery = "select RoomTypeID,RoomTypeName,PropertyName,mst_RoomType.PropertyID from mst_RoomType inner join mst_Property on mst_Property.PropertyID = mst_RoomType.PropertyID where mst_Property.CompanyID = '" + Convert.ToString(Session["CompanyID"]) + "' and mst_RoomType.IsActive = 1 order by RoomTypeName asc";
        //        DataSet dsData = RoomTypeBLL.GetUnitType(strQuery);

        //        if (dsData.Tables[0] != null && dsData.Tables[0].Rows.Count > 0)
        //        {
        //            gvMarkertRateList.DataSource = dsData.Tables[0];
        //            gvMarkertRateList.DataBind();
        //        }
        //        else
        //        {
        //            gvMarkertRateList.DataSource = null;
        //            gvMarkertRateList.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        /// <summary>
        /// Bind Property
        /// </summary>
        private void BindProperty()
        {
            DataSet ds = PropertyBLL.SelectData(new Guid(Convert.ToString(Session["CompanyID"])));

            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlSearchProperty.DataSource = dv;
                ddlSearchProperty.DataTextField = "PropertyName";
                ddlSearchProperty.DataValueField = "PropertyID";
                ddlSearchProperty.DataBind();
                ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                if (Session["PropertyID4UnitInfo"] != null)
                    ddlSearchProperty.SelectedValue = Convert.ToString(Session["PropertyID4UnitInfo"]);
            }
            else
                ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind UnitType
        /// </summary>
        //private void BindUnitType()
        //{
        //    ddlSearchUnitType.Items.Clear();
        //    if (ddlSearchProperty.SelectedValue != Guid.Empty.ToString())
        //    {
        //        string strUnitTypeQuery = "select RoomTypeName,RoomTypeID from mst_RoomType where PropertyID like '" + Convert.ToString(ddlSearchProperty.SelectedValue) + "' and IsActive = 1 order by RoomTypeName asc";
        //        DataSet dsUnitType = RoomTypeBLL.GetUnitType(strUnitTypeQuery);

        //        if (dsUnitType.Tables[0].Rows.Count != 0)
        //        {
        //            ddlSearchUnitType.DataSource = dsUnitType.Tables[0];
        //            ddlSearchUnitType.DataTextField = "RoomTypeName";
        //            ddlSearchUnitType.DataValueField = "RoomTypeID";
        //            ddlSearchUnitType.DataBind();
        //            ddlSearchUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //            if (Session["PropertyID4UnitInfo"] != null)
        //                ddlSearchProperty.SelectedValue = Convert.ToString(dsUnitType.Tables[0].Rows[0]["RoomTypeID"]);
        //        }
        //        else
        //            ddlSearchUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlSearchUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //}

        private void BindGrid()
        {
            try
            {
                Guid? PropertyID = null;
                DateTime? StartDate = null;
                DateTime? EndDate = null;
                Guid? InvestorID = null;

                string strUserType = Convert.ToString(Session["UserType"]);
                if (strUserType.ToUpper().Equals("INVESTOR"))
                {
                    string strGetInvestorID = "select InvestorID from irm_Investor where IsActive = 1 and RefInverstorID is null and UserID = '" + Convert.ToString(Session["UserID"]) + "'";
                    DataSet dsInvestor = InvestorBLL.GetSearchData(strGetInvestorID);
                    if (dsInvestor.Tables.Count > 0 && dsInvestor.Tables[0].Rows.Count > 0)
                        InvestorID = new Guid(Convert.ToString(dsInvestor.Tables[0].Rows[0]["InvestorID"]));
                    else
                        InvestorID = null;
                }

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (ddlSearchProperty.SelectedIndex != 0)
                    PropertyID = new Guid(ddlSearchProperty.SelectedValue);

                if (txtFromDate.Text.Trim() != "")
                    StartDate = DateTime.ParseExact(txtFromDate.Text.Trim(), this.DateFormat, objCultureInfo);

                if (txtToDate.Text.Trim() != "")
                    EndDate = DateTime.ParseExact(txtToDate.Text.Trim(), this.DateFormat, objCultureInfo);

                DataSet dsData = UnitTypeMarketRateBLL.SelectUnitTypeMarketGridData(PropertyID, new Guid(Convert.ToString(Session["CompanyID"])), StartDate, EndDate, InvestorID);

                if (dsData.Tables.Count > 0)
                {
                    if (dsData.Tables[0] != null && dsData.Tables[0].Rows.Count > 0)
                    {
                        dsData.Tables[0].Columns.Remove("DateOfRate");

                        gvUnitTypeMarketRateList.DataSource = dsData.Tables[0];
                        gvUnitTypeMarketRateList.DataBind();

                        /////mstChartPosition.DataSource = dsData.Tables[0];

                        message.Visible = false;
                        /////mstChartPosition.Visible = true;

                        ////for (int i = 1; i < dsData.Tables[0].Columns.Count; i++)
                        ////{
                        ////    string str = Convert.ToString(dsData.Tables[0].Columns[i].ToString());

                        ////    mstChartPosition.Series.Add("Series" + (i + 1));
                        ////    mstChartPosition.Series["Series" + (i + 1)].XValueMember = dsData.Tables[0].Columns[0].ToString();
                        ////    mstChartPosition.Series["Series" + (i + 1)].YValueMembers = dsData.Tables[0].Columns[i].ToString();
                        ////    mstChartPosition.Series["Series" + (i + 1)].ChartType = SeriesChartType.Column;
                        ////    mstChartPosition.Series["Series" + (i + 1)].ToolTip = Convert.ToString(dsData.Tables[0].Columns[i].ToString());

                        ////    mstChartPosition.Series["Series" + (i + 1)].IsValueShownAsLabel = true;
                        ////    ////mstChartPosition.Series["Series" + (i + 1)]["BarLabelStyle"] = "BottomToTop";
                        ////    ////mstChartPosition.Series["Series" + (i + 1)].LabelAngle = -90;
                        ////    mstChartPosition.Series["Series" + (i + 1)].Label = Convert.ToString(dsData.Tables[0].Columns[i].ToString());
                        ////    mstChartPosition.Series["Series" + (i + 1)].SmartLabelStyle.Enabled = false;
                        ////    mstChartPosition.Series["Series" + (i + 1)].LabelAngle = -90;
                        ////    ////mstChartPosition.Series["Series" + (i + 1)]["PointWidth"] = "1.2"; 

                        ////}

                        ////mstChartPosition.Width = dsData.Tables[0].Rows.Count * 100;
                    }
                    else
                    {
                        gvUnitTypeMarketRateList.DataSource = null;
                        gvUnitTypeMarketRateList.DataBind();

                        message.Visible = true;
                        /////mstChartPosition.Visible = false;
                    }
                }
                else
                {
                    gvUnitTypeMarketRateList.DataSource = null;
                    gvUnitTypeMarketRateList.DataBind();

                    message.Visible = true;
                    /////mstChartPosition.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            txtFromDate.Text = txtToDate.Text = this.DateOfRate = string.Empty;
            this.PropertyID = Guid.Empty;
            ddlSearchProperty.SelectedIndex = 0;
        }

        //private void DrawGraph()
        //{
        //    ArrayList arlX = new ArrayList();
        //    ArrayList arlY = new ArrayList();

        //    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

        //    DateTime? dtSearchDateOfRate = null;
        //    if (txtSearchDate.Text.Trim() != "")
        //        dtSearchDateOfRate = DateTime.ParseExact(txtSearchDate.Text.Trim(), this.DateFormat, objCultureInfo);

        //    DataSet ds = UnitTypeMarketRateBLL.DrawChart(new Guid(ddlSearchProperty.SelectedValue), new Guid(Convert.ToString(Session["CompanyID"])), new Guid(ddlSearchUnitType.SelectedValue), dtSearchDateOfRate);

        //    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            DateTime dtDateOfRate = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfRate"]);
        //            arlX.Add(dtDateOfRate.ToString(this.DateFormat));
        //            arlY.Add(Convert.ToDouble(ds.Tables[0].Rows[i]["Rate"]));
        //        }

        //        double[] yValues = new double[arlY.Count];
        //        string[] xValues = new string[arlX.Count];

        //        for (int j = 0; j < arlX.Count; j++)
        //        {
        //            yValues[j] = Convert.ToDouble(arlY[j]);
        //            xValues[j] = arlX[j].ToString();
        //        }

        //        message.Visible = false;
        //        mstChartPosition.Visible = true;

        //        mstChartPosition.Series["Default"].Points.DataBindXY(xValues, yValues);
        //        mstChartPosition.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
        //        mstChartPosition.ChartAreas[0].AxisX.Interval = 1;
        //        mstChartPosition.Series["Default"].ChartType = SeriesChartType.Line;
        //        mstChartPosition.Legends[0].Enabled = false;
        //    }
        //    else
        //    {
        //        message.Visible = true;
        //        mstChartPosition.Visible = false;
        //    }
        //}

        #endregion Private Method

        #region Button Event

        /// <summary>
        /// Add New Channel Partner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Activity/UnitTypeMarketRate.aspx");
        }

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnRateListSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    BindGrid();
                    //DrawGraph();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Button Event

        #region Dropdown Event

        //protected void ddlSearchProperty_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    message.Visible = true;
        //    BindUnitType();
        //}

        #endregion Dropdown Event

        #region Grid Event

        //protected void gvUnitTypeMarketRateList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName.Equals("EditData"))
        //        {
        //            Session.Add("strPropertyAndDate", Convert.ToString(e.CommandArgument));
        //            Response.Redirect("~/Applications/Activity/UnitTypeMarketRate.aspx");
        //        }
        //        else if (e.CommandName.Equals("DeleteData"))
        //        {
        //            string strID = Convert.ToString(e.CommandArgument);
        //            string[] strnewID = strID.ToString().Split('|');

        //            if (strnewID.Length != 0)
        //                this.PropertyID = new Guid(Convert.ToString(strnewID[0]));

        //            if (strnewID.Length > 1 && strnewID[1] != "")
        //            {
        //                DateTime dt = Convert.ToDateTime(strnewID[1]);

        //                string strTime = dt.ToString("HH:mm:ss");
        //                string strDate = dt.ToString("MM-dd-yyyy");

        //                string strFinalDate = strDate + " " + strTime;

        //                this.DateOfRate = strFinalDate;
        //            }
        //            msgbx.Show();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        protected void gvUnitTypeMarketRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (e.Row.RowType == DataControlRowType.Header)
                //{
                //    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                //        e.Row.Cells[2].Text = "View/ Edit";
                //    else if (Convert.ToBoolean(ViewState["View"]) == true)
                //        e.Row.Cells[2].Text = "View";

                //    e.Row.Cells[2].Visible = Convert.ToBoolean(ViewState["View"]);
                //    e.Row.Cells[3].Visible = Convert.ToBoolean(ViewState["Delete"]);
                //}
                //else 
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int i = 0; i < gvUnitTypeMarketRateList.HeaderRow.Cells.Count; i++)
                    {
                        string strCell = Convert.ToString(e.Row.Cells[i].Text);
                    }

                    //e.Row.Cells[2].Visible = Convert.ToBoolean(ViewState["View"]);
                    //e.Row.Cells[3].Visible = Convert.ToBoolean(ViewState["Delete"]);

                    //if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    //    ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View/Edit";
                    //else if (Convert.ToBoolean(ViewState["View"]) == true)
                    //    ((ImageButton)e.Row.FindControl("btnEdit")).ToolTip = "View";

                    //string strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Rate"));

                    //Label lblGvRate = (Label)e.Row.FindControl("lblGvRate");
                    //if (lblGvRate != null)
                    //{
                    //    if (strRate != string.Empty && strRate != null)
                    //        lblGvRate.Text = Convert.ToString(strRate.ToString().Substring(0, strRate.ToString().LastIndexOf(".") + 1 + 2));
                    //}
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUnitTypeMarketRateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUnitTypeMarketRateList.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnitTypeMarketRateYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PropertyID != Guid.Empty)
                {
                    msgbx.Hide();

                    //Amenities objDelete = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);

                    DateTime dtDeleteDate = Convert.ToDateTime(this.DateOfRate);
                    UnitTypeMarketRateBLL.DeleteByID(this.PropertyID, new Guid(Convert.ToString(Session["CompanyID"])), dtDeleteDate);
                    //ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "mst_Amenities");

                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                ClearControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnitTypeMarketRateNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event
    }
}