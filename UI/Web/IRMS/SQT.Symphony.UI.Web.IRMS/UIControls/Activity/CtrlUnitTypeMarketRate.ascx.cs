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
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
    public partial class CtrlUnitTypeMarketRate : System.Web.UI.UserControl
    {
        //#region Property and Variables

        //public bool IsMessage = false;

        //public Guid PropertyID
        //{
        //    get
        //    {
        //        return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
        //    }
        //    set
        //    {
        //        ViewState["PropertyID"] = value;
        //    }
        //}

        //public string DateFormat
        //{
        //    get
        //    {
        //        return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
        //    }
        //    set
        //    {
        //        ViewState["DateFormat"] = value;
        //    }
        //}

        //public string DateOfRate
        //{
        //    get
        //    {
        //        return ViewState["DateOfRate"] != null ? Convert.ToString(ViewState["DateOfRate"]) : string.Empty;
        //    }
        //    set
        //    {
        //        ViewState["DateOfRate"] = value;
        //    }
        //}

        //#endregion Property and Variables

        //#region Page Load

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (RoleRightJoinBLL.GetAccessString("UnitTypeMarketRate.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
        //            Response.Redirect("~/Applications/AccessDenied.aspx");
        //        LoadAccess();

        //        LoadDefaultValue();

        //    }
        //}

        //#endregion Page Load

        //#region Private Method

        ///// <summary>
        ///// Load Access
        ///// </summary>
        //private void LoadAccess()
        //{
        //    DataView DV = RoleRightJoinBLL.GetIUDVAccess("UnitTypeMarketRate.aspx", new Guid(Convert.ToString(Session["UserID"])));
        //    if (DV.Count > 0)
        //    {
        //        ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
        //        ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
        //        ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
        //        if (this.PropertyID == Guid.Empty)
        //            btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
        //        ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
        //    }
        //    else
        //        Response.Redirect("~/Applications/AccessDenied.aspx");
        //}

        //private void LoadDefaultValue()
        //{
        //    if (Session["CompanyID"] != null)
        //    {
        //        if (Session["PropertyConfigurationInfo"] != null)
        //        {
        //            PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
        //            ProjectTerm objProjectTerm = new ProjectTerm();
        //            Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
        //            objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

        //            if (objProjectTerm != null)
        //            {
        //                this.DateFormat = objProjectTerm.Term;
        //            }
        //            else
        //            {
        //                this.DateFormat = "dd/MM/yyyy";
        //            }
        //        }
        //        else
        //        {
        //            this.DateFormat = "dd/MM/yyyy";
        //        }

        //        ajxCalendarDateOfRate.Format = calSearchDate.Format = this.DateFormat;
        //        BindProperty();
        //        ClearControl();
        //        BindGrid();

        //        if (Session["strPropertyAndDate"] != null)
        //        {
        //            string strSessionID = Convert.ToString(Session["strPropertyAndDate"]);
        //            string[] strID = strSessionID.ToString().Split('|');

        //            if (strID.Length != 0)
        //                this.PropertyID = new Guid(Convert.ToString(strID[0]));

        //            if (strID.Length > 1 && strID[1] != "")
        //                this.DateOfRate = Convert.ToString(strID[1]);

        //            Session.Remove("strPropertyAndDate");

        //            EditData();                    
        //        }
        //    }
        //    else
        //    {
        //        Session.Clear();
        //        Response.Redirect("~/Default.aspx");
        //    }
        //}

        //private void ClearControl()
        //{            
        //    txtDateOfRate.Text = txtSearchDate.Text = this.DateOfRate = string.Empty;
        //    ddlPropertyName.Enabled = ajxCalendarDateOfRate.Enabled = true;
        //    this.PropertyID = Guid.Empty;
        //    ddlPropertyName.SelectedIndex = 0;
        //    BindUnitTypeGrid();
        //}

        //private void BindUnitTypeGrid()
        //{
        //    if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
        //    {
        //        DataSet dsUnitType = UnitTypeMarketRateBLL.GetMarketRateData(new Guid(ddlPropertyName.SelectedValue));

        //        if (dsUnitType.Tables[0] != null && dsUnitType.Tables[0].Rows.Count > 0)
        //        {
        //            gvUntiType.DataSource = dsUnitType.Tables[0];
        //            gvUntiType.DataBind();
        //        }
        //        else
        //        {
        //            gvUntiType.DataSource = null;
        //            gvUntiType.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        gvUntiType.DataSource = null;
        //        gvUntiType.DataBind();
        //    }
        //}

        //private void BindGrid()
        //{
        //    Guid? PropertyID = null;
        //    DateTime? DateOfRate = null;

        //    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

        //    if (ddlSearchProperty.SelectedIndex != 0)
        //        PropertyID = new Guid(ddlSearchProperty.SelectedValue);

        //    if (txtSearchDate.Text.Trim() != "")
        //        DateOfRate = DateTime.ParseExact(txtSearchDate.Text.Trim(), this.DateFormat, objCultureInfo);

        //    DataSet dsData = UnitTypeMarketRateBLL.SearchMarketRateData(PropertyID, DateOfRate, "SEARCH");

        //    if (dsData.Tables[0] != null && dsData.Tables[0].Rows.Count > 0)
        //    {
        //        gvUnitTypeMarketRateList.DataSource = dsData.Tables[0];
        //        gvUnitTypeMarketRateList.DataBind();
        //    }
        //    else
        //    {
        //        gvUnitTypeMarketRateList.DataSource = null;
        //        gvUnitTypeMarketRateList.DataBind();
        //    }
        //}

        //private void EditData()
        //{
        //    if (this.PropertyID != Guid.Empty && this.DateOfRate != string.Empty)
        //    {
        //        LoadAccess();
        //        DateTime? dtLoadDateOfRate = null;
        //        dtLoadDateOfRate = Convert.ToDateTime(this.DateOfRate);

        //        DataSet dsLoadData = UnitTypeMarketRateBLL.SearchMarketRateData(this.PropertyID, dtLoadDateOfRate, "EDIT");


        //        if (dsLoadData.Tables[0] != null && dsLoadData.Tables[0].Rows.Count > 0)
        //        {
        //            ddlPropertyName.Enabled = ajxCalendarDateOfRate.Enabled = false;

        //            ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(this.PropertyID)) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(this.PropertyID))) : 0;

        //            if (dtLoadDateOfRate != null)
        //            {
        //                DateTime EditDateOfRate = Convert.ToDateTime(dsLoadData.Tables[0].Rows[0]["DateOfRate"]);
        //                txtDateOfRate.Text = EditDateOfRate.ToString(this.DateFormat);
        //            }
        //            else
        //                txtDateOfRate.Text = "";

        //            //BindUnitTypeGrid();
        //            gvUntiType.DataSource = dsLoadData.Tables[0];
        //            gvUntiType.DataBind();

        //            for (int i = 0; i < gvUntiType.Rows.Count; i++)
        //            {
        //                GridViewRow row = gvUntiType.Rows[i];
        //                DataRow[] rows = dsLoadData.Tables[0].Select("RoomTypeID = '" + gvUntiType.DataKeys[i]["RoomTypeID"].ToString() + "'");

        //                TextBox txtNewRate = (TextBox)row.FindControl("txtNewRate");
        //                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

        //                if (rows.Length > 0)
        //                {
        //                    if (Convert.ToString(rows[0]["Rate"]) != string.Empty)
        //                    {
        //                        chkSelect.Checked = true;
        //                        txtNewRate.Text = Convert.ToString(rows[0]["Rate"].ToString().Substring(0, rows[0]["Rate"].ToString().LastIndexOf(".") + 1 + 2));
        //                    }
        //                    else
        //                    {
        //                        chkSelect.Checked = false;
        //                        txtNewRate.Text = "";
        //                    }
        //                }
        //                else
        //                {
        //                    chkSelect.Checked = false;
        //                    txtNewRate.Text = "";
        //                }
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Bind Property
        ///// </summary>
        //private void BindProperty()
        //{
        //    DataSet ds = PropertyBLL.SelectData(new Guid(Convert.ToString(Session["CompanyID"])));

        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        DataView dv = new DataView(ds.Tables[0]);
        //        dv.Sort = "PropertyName Asc";

        //        ddlPropertyName.DataSource = dv;
        //        ddlPropertyName.DataTextField = "PropertyName";
        //        ddlPropertyName.DataValueField = "PropertyID";
        //        ddlPropertyName.DataBind();
        //        ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        //        ddlSearchProperty.DataSource = dv;
        //        ddlSearchProperty.DataTextField = "PropertyName";
        //        ddlSearchProperty.DataValueField = "PropertyID";
        //        ddlSearchProperty.DataBind();
        //        ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //    {
        //        ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //        ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //}

        //#endregion Private Method

        //#region Button Event
        ///// <summary>
        ///// New Button Event
        ///// </summary>
        ///// <param name="sender">sender as Object</param>
        ///// <param name="e">e as EventArgs</param>
        //protected void btnNew_Click(object sender, EventArgs e)
        //{
        //    ClearControl();
        //    btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        //    Session.Remove("strPropertyAndDate");
        //}
        ///// <summary>
        ///// Button Cancel Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Response.Redirect("~/Applications/Activity/UnitTypeMarketRateList.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        ///// <summary>
        ///// Button Save Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {
        //        try
        //        {
        //            if (this.PropertyID != Guid.Empty)
        //            {
        //                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
        //                List<UnitTypeMarketRate> lstUnitTypeMarketRate = new List<UnitTypeMarketRate>();

        //                DateTime dtDateOfRate = DateTime.ParseExact(txtDateOfRate.Text.Trim(), this.DateFormat, objCultureInfo);

        //                DateTime dtTemp = dtDateOfRate.Date + DateTime.Now.TimeOfDay;

        //                for (int i = 0; i < gvUntiType.Rows.Count; i++)
        //                {
        //                    CheckBox chkSelect = (CheckBox)gvUntiType.Rows[i].FindControl("chkSelect");

        //                    if (chkSelect.Checked)
        //                    {
        //                        HiddenField hdnMarketRateID = (HiddenField)gvUntiType.Rows[i].FindControl("hdnMarketRateID");

        //                        TextBox txtNewRate = (TextBox)gvUntiType.Rows[i].FindControl("txtNewRate");

        //                        if (hdnMarketRateID != null && Convert.ToString(hdnMarketRateID.Value) != string.Empty)
        //                        {
        //                            UnitTypeMarketRate objUpdate = new UnitTypeMarketRate();

        //                            objUpdate = UnitTypeMarketRateBLL.GetByPrimaryKey(new Guid(hdnMarketRateID.Value));
        //                            objUpdate.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
        //                            objUpdate.UpdatedOn = DateTime.Now;
        //                            objUpdate.Rate = Convert.ToDecimal(txtNewRate.Text.Trim());
        //                            objUpdate.DateOfRate = Convert.ToDateTime(this.DateOfRate);

        //                            UnitTypeMarketRateBLL.Update(objUpdate);
        //                        }
        //                        else
        //                        {
        //                            UnitTypeMarketRate objSave = new UnitTypeMarketRate();

        //                            objSave.PropertyID = this.PropertyID;
        //                            objSave.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
        //                            objSave.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
        //                            objSave.CreatedOn = DateTime.Now;
        //                            objSave.IsActive = true;
        //                            objSave.IsSynch = false;
        //                            objSave.UnitTypeID = new Guid(gvUntiType.DataKeys[i]["RoomTypeID"].ToString());
        //                            objSave.Rate = Convert.ToDecimal(txtNewRate.Text.Trim());
        //                            objSave.DateOfRate = Convert.ToDateTime(this.DateOfRate);

        //                            lstUnitTypeMarketRate.Add(objSave);
        //                        }
        //                    }
        //                }

        //                if (lstUnitTypeMarketRate.Count > 0)
        //                {
        //                    UnitTypeMarketRateBLL.Save(lstUnitTypeMarketRate);
        //                }

        //                ClearControl();
        //                BindGrid();
        //                IsMessage = true;
        //                lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
        //            }
        //            else
        //            {
        //                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
        //                List<UnitTypeMarketRate> lstUnitTypeMarketRate = new List<UnitTypeMarketRate>();
        //                DateTime dtDateOfRate = DateTime.ParseExact(txtDateOfRate.Text.Trim(), this.DateFormat, objCultureInfo);

        //                DateTime dtTemp = dtDateOfRate.Date + DateTime.Now.TimeOfDay;

        //                //DateTime dt = Convert.ToDateTime(dtDateOfRate + " " + Convert.ToDateTime(strTime));

        //                for (int i = 0; i < gvUntiType.Rows.Count; i++)
        //                {
        //                    CheckBox chkSelect = (CheckBox)gvUntiType.Rows[i].FindControl("chkSelect");

        //                    if (chkSelect.Checked)
        //                    {
        //                        UnitTypeMarketRate objSave = new UnitTypeMarketRate();
        //                        objSave.PropertyID = new Guid(ddlPropertyName.SelectedValue);
        //                        objSave.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
        //                        objSave.DateOfRate = dtTemp;
        //                        objSave.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
        //                        objSave.CreatedOn = DateTime.Now;
        //                        objSave.IsActive = true;
        //                        objSave.IsSynch = false;


        //                        TextBox txtNewRate = (TextBox)gvUntiType.Rows[i].FindControl("txtNewRate");
        //                        objSave.Rate = Convert.ToDecimal(txtNewRate.Text.Trim());
        //                        objSave.UnitTypeID = new Guid(gvUntiType.DataKeys[i]["RoomTypeID"].ToString());

        //                        lstUnitTypeMarketRate.Add(objSave);
        //                    }
        //                }

        //                if (lstUnitTypeMarketRate.Count > 0)
        //                {
        //                    UnitTypeMarketRateBLL.Save(lstUnitTypeMarketRate);
        //                    IsMessage = true;
        //                    ClearControl();
        //                    BindGrid();
        //                    lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //            MessageBox.Show(ex.Message.ToString());
        //        }
        //    }
        //}

        ///// <summary>
        ///// Button Search Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        BindGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //#endregion Button Event

        //#region Grid Event
        //protected void gvUnitTypeMarketRateList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName.Equals("EditData"))
        //        {
        //            string strID = Convert.ToString(e.CommandArgument);
        //            string[] strnewID = strID.ToString().Split('|');

        //            if (strnewID.Length != 0)
        //                this.PropertyID = new Guid(Convert.ToString(strnewID[0]));

        //            if (strnewID.Length > 1 && strnewID[1] != "")
        //                this.DateOfRate = Convert.ToString(strnewID[1]);
                    
        //            EditData();
                    
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

        //protected void gvUnitTypeMarketRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
        //            ((ImageButton)e.Row.FindControl("btnDelete")).Visible = Convert.ToBoolean(ViewState["Delete"]);

        //            EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    
        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                EditImg.ToolTip = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                EditImg.ToolTip = "View";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //protected void gvUntiType_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            ((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
        //                    ((CheckBox)e.Row.FindControl("chkSelectAll")).ClientID + "')");
        //        }
        //        else if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            Label lblOldRate = (Label)e.Row.FindControl("lblOldRate");
        //            Label lblOldRateDate = (Label)e.Row.FindControl("lblOldRateDate");

        //            string[] strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OldRate")).Split('|');

        //            string strMarketRateID = string.Empty;
        //            //if (this.PropertyID != Guid.Empty)

        //            strMarketRateID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MarketRateID"));

        //            if (lblOldRate != null)
        //            {
        //                if (strRate.Length != 0 && strRate[0] != string.Empty)
        //                    lblOldRate.Text = Convert.ToString(strRate[0].ToString().Substring(0, strRate[0].ToString().LastIndexOf(".") + 1 + 2));
        //            }
        //            if (lblOldRateDate != null)
        //            {
        //                if (strRate.Length > 1 && strRate[1] != string.Empty)
        //                {
        //                    DateTime dtDate = Convert.ToDateTime(strRate[1]);
        //                    lblOldRateDate.Text = Convert.ToString(dtDate.ToString(this.DateFormat));
        //                }
        //            }

        //            if (strMarketRateID != string.Empty && strMarketRateID != null)
        //            {
        //                ((HiddenField)e.Row.FindControl("hdnMarketRateID")).Value = Convert.ToString(strMarketRateID);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //#endregion Grid Event

        //#region DropDown Event

        //protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindUnitTypeGrid();
        //}

        //#endregion DropDown Event

        //#region Popup Button Event

        ///// <summary>
        ///// Yes Button Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnUnitTypeMarketRateYes_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.PropertyID != Guid.Empty)
        //        {
        //            msgbx.Hide();

        //            //Amenities objDelete = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);

        //            DateTime dtDeleteDate = Convert.ToDateTime(this.DateOfRate);
        //            UnitTypeMarketRateBLL.DeleteByID(this.PropertyID, new Guid(Convert.ToString(Session["CompanyID"])), dtDeleteDate);
        //            //ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "mst_Amenities");

        //            IsMessage = true;
        //            lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
        //        }
        //        ClearControl();
        //        BindGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        ///// <summary>
        ///// Cancel Button Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnUnitTypeMarketRateNo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        msgbx.Hide();
        //        ClearControl();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }

        //}

        //#endregion Popup Button Event

        #region Property and Variables

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

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RoleRightJoinBLL.GetAccessString("UnitTypeMarketRate.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();

                LoadDefaultValue();

            }
        }

        #endregion Page Load

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
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.PropertyID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        private void LoadDefaultValue()
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

                ajxCalendarDateOfRate.Format = calSearchDate.Format = this.DateFormat;
                BindProperty();
                ClearControl();
                BindGrid();

                if (Session["strPropertyAndDate"] != null)
                {
                    string strSessionID = Convert.ToString(Session["strPropertyAndDate"]);
                    string[] strID = strSessionID.ToString().Split('|');

                    if (strID.Length != 0)
                        this.PropertyID = new Guid(Convert.ToString(strID[0]));

                    if (strID.Length > 1 && strID[1] != "")
                        this.DateOfRate = Convert.ToString(strID[1]);

                    Session.Remove("strPropertyAndDate");

                    EditData();
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
        }

        private void ClearControl()
        {
            txtDateOfRate.Text = txtSearchDate.Text = this.DateOfRate = string.Empty;
            ddlPropertyName.Enabled = ajxCalendarDateOfRate.Enabled = true;
            this.PropertyID = Guid.Empty;
            ddlPropertyName.SelectedIndex = 0;
            BindUnitTypeGrid();
        }

        private void BindUnitTypeGrid()
        {
            if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
            {
                DataSet dsUnitType = UnitTypeMarketRateBLL.GetMarketRateData(new Guid(ddlPropertyName.SelectedValue));

                if (dsUnitType.Tables[0] != null && dsUnitType.Tables[0].Rows.Count > 0)
                {
                    gvUntiType.DataSource = dsUnitType.Tables[0];
                    gvUntiType.DataBind();
                }
                else
                {
                    gvUntiType.DataSource = null;
                    gvUntiType.DataBind();
                }
            }
            else
            {
                gvUntiType.DataSource = null;
                gvUntiType.DataBind();
            }
        }

        private void BindGrid()
        {
            Guid? PropertyID = null;
            DateTime? DateOfRate = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            if (ddlSearchProperty.SelectedIndex != 0)
                PropertyID = new Guid(ddlSearchProperty.SelectedValue);

            if (txtSearchDate.Text.Trim() != "")
                DateOfRate = DateTime.ParseExact(txtSearchDate.Text.Trim(), this.DateFormat, objCultureInfo);

            DataSet dsData = UnitTypeMarketRateBLL.SearchMarketRateData(PropertyID, DateOfRate, "SEARCH");

            if (dsData.Tables[0] != null && dsData.Tables[0].Rows.Count > 0)
            {
                gvUnitTypeMarketRateList.DataSource = dsData.Tables[0];
                gvUnitTypeMarketRateList.DataBind();
            }
            else
            {
                gvUnitTypeMarketRateList.DataSource = null;
                gvUnitTypeMarketRateList.DataBind();
            }
        }

        private void EditData()
        {
            if (this.PropertyID != Guid.Empty && this.DateOfRate != string.Empty)
            {
                LoadAccess();
                DateTime? dtLoadDateOfRate = null;
                dtLoadDateOfRate = Convert.ToDateTime(this.DateOfRate);

                DataSet dsLoadData = UnitTypeMarketRateBLL.SearchMarketRateData(this.PropertyID, dtLoadDateOfRate, "EDIT");


                if (dsLoadData.Tables[0] != null && dsLoadData.Tables[0].Rows.Count > 0)
                {
                    ddlPropertyName.Enabled = ajxCalendarDateOfRate.Enabled = false;

                    ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(this.PropertyID)) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(this.PropertyID))) : 0;

                    if (dtLoadDateOfRate != null)
                    {
                        DateTime EditDateOfRate = Convert.ToDateTime(dsLoadData.Tables[0].Rows[0]["DateOfRate"]);
                        txtDateOfRate.Text = EditDateOfRate.ToString(this.DateFormat);
                    }
                    else
                        txtDateOfRate.Text = "";

                    //BindUnitTypeGrid();
                    gvUntiType.DataSource = dsLoadData.Tables[0];
                    gvUntiType.DataBind();

                    for (int i = 0; i < gvUntiType.Rows.Count; i++)
                    {
                        GridViewRow row = gvUntiType.Rows[i];
                        DataRow[] rows = dsLoadData.Tables[0].Select("RoomTypeID = '" + gvUntiType.DataKeys[i]["RoomTypeID"].ToString() + "'");

                        TextBox txtNewRate = (TextBox)row.FindControl("txtNewRate");

                        if (rows.Length > 0)
                        {
                            if (Convert.ToString(rows[0]["Rate"]) != string.Empty)
                            {
                                txtNewRate.Text = Convert.ToString(rows[0]["Rate"].ToString().Substring(0, rows[0]["Rate"].ToString().LastIndexOf(".") + 1 + 2));
                            }
                            else
                            {

                                txtNewRate.Text = "0.00";
                            }
                        }
                        else
                        {
                            txtNewRate.Text = "0.00";
                        }
                    }
                }
            }
        }

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

                ddlPropertyName.DataSource = dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                ddlSearchProperty.DataSource = dv;
                ddlSearchProperty.DataTextField = "PropertyName";
                ddlSearchProperty.DataValueField = "PropertyID";
                ddlSearchProperty.DataBind();
                ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
            {
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSearchProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        #endregion Private Method

        #region Button Event
        /// <summary>
        /// New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
            Session.Remove("strPropertyAndDate");
        }
        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/Activity/UnitTypeMarketRateList.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Button Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.PropertyID != Guid.Empty)
                    {
                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                        List<UnitTypeMarketRate> lstUnitTypeMarketRate = new List<UnitTypeMarketRate>();

                        DateTime dtDateOfRate = DateTime.ParseExact(txtDateOfRate.Text.Trim(), this.DateFormat, objCultureInfo);

                        DateTime dtTemp = dtDateOfRate.Date + DateTime.Now.TimeOfDay;

                        for (int i = 0; i < gvUntiType.Rows.Count; i++)
                        {
                            HiddenField hdnMarketRateID = (HiddenField)gvUntiType.Rows[i].FindControl("hdnMarketRateID");

                            TextBox txtNewRate = (TextBox)gvUntiType.Rows[i].FindControl("txtNewRate");

                            if (hdnMarketRateID != null && Convert.ToString(hdnMarketRateID.Value) != string.Empty)
                            {
                                UnitTypeMarketRate objUpdate = new UnitTypeMarketRate();

                                objUpdate = UnitTypeMarketRateBLL.GetByPrimaryKey(new Guid(hdnMarketRateID.Value));
                                objUpdate.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                objUpdate.UpdatedOn = DateTime.Now;
                                objUpdate.Rate = Convert.ToDecimal(txtNewRate.Text.Trim());
                                objUpdate.DateOfRate = Convert.ToDateTime(this.DateOfRate);

                                UnitTypeMarketRateBLL.Update(objUpdate);
                            }
                            else
                            {
                                UnitTypeMarketRate objSave = new UnitTypeMarketRate();

                                objSave.PropertyID = this.PropertyID;
                                objSave.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                objSave.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                objSave.CreatedOn = DateTime.Now;
                                objSave.IsActive = true;
                                objSave.IsSynch = false;
                                objSave.UnitTypeID = new Guid(gvUntiType.DataKeys[i]["RoomTypeID"].ToString());
                                objSave.Rate = Convert.ToDecimal(txtNewRate.Text.Trim());
                                objSave.DateOfRate = Convert.ToDateTime(this.DateOfRate);

                                lstUnitTypeMarketRate.Add(objSave);
                            }
                        }

                        if (lstUnitTypeMarketRate.Count > 0)
                        {
                            UnitTypeMarketRateBLL.Save(lstUnitTypeMarketRate);
                        }

                        ClearControl();
                        BindGrid();
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                        List<UnitTypeMarketRate> lstUnitTypeMarketRate = new List<UnitTypeMarketRate>();
                        DateTime dtDateOfRate = DateTime.ParseExact(txtDateOfRate.Text.Trim(), this.DateFormat, objCultureInfo);

                        DateTime dtTemp = dtDateOfRate.Date + DateTime.Now.TimeOfDay;

                        //DateTime dt = Convert.ToDateTime(dtDateOfRate + " " + Convert.ToDateTime(strTime));

                        for (int i = 0; i < gvUntiType.Rows.Count; i++)
                        {
                            UnitTypeMarketRate objSave = new UnitTypeMarketRate();
                            objSave.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            objSave.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            objSave.DateOfRate = dtTemp;
                            objSave.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                            objSave.CreatedOn = DateTime.Now;
                            objSave.IsActive = true;
                            objSave.IsSynch = false;


                            TextBox txtNewRate = (TextBox)gvUntiType.Rows[i].FindControl("txtNewRate");
                            objSave.Rate = Convert.ToDecimal(txtNewRate.Text.Trim());
                            objSave.UnitTypeID = new Guid(gvUntiType.DataKeys[i]["RoomTypeID"].ToString());

                            lstUnitTypeMarketRate.Add(objSave);
                        }

                        if (lstUnitTypeMarketRate.Count > 0)
                        {
                            UnitTypeMarketRateBLL.Save(lstUnitTypeMarketRate);
                            IsMessage = true;
                            ClearControl();
                            BindGrid();
                            lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region Grid Event
        protected void gvUnitTypeMarketRateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    string strID = Convert.ToString(e.CommandArgument);
                    string[] strnewID = strID.ToString().Split('|');

                    if (strnewID.Length != 0)
                        this.PropertyID = new Guid(Convert.ToString(strnewID[0]));

                    if (strnewID.Length > 1 && strnewID[1] != "")
                        this.DateOfRate = Convert.ToString(strnewID[1]);

                    EditData();

                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    string strID = Convert.ToString(e.CommandArgument);
                    string[] strnewID = strID.ToString().Split('|');

                    if (strnewID.Length != 0)
                        this.PropertyID = new Guid(Convert.ToString(strnewID[0]));

                    if (strnewID.Length > 1 && strnewID[1] != "")
                    {
                        DateTime dt = Convert.ToDateTime(strnewID[1]);

                        string strTime = dt.ToString("HH:mm:ss");
                        string strDate = dt.ToString("MM-dd-yyyy");

                        string strFinalDate = strDate + " " + strTime;

                        this.DateOfRate = strFinalDate;
                    }
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUnitTypeMarketRateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ((ImageButton)e.Row.FindControl("btnDelete")).Visible = Convert.ToBoolean(ViewState["Delete"]);

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvUntiType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblOldRate = (Label)e.Row.FindControl("lblOldRate");
                    TextBox txtNewRate = (TextBox)e.Row.FindControl("txtNewRate");
                    Label lblOldRateDate = (Label)e.Row.FindControl("lblOldRateDate");

                    string[] strRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OldRate")).Split('|');

                    string strMarketRateID = string.Empty;
                    //if (this.PropertyID != Guid.Empty)

                    strMarketRateID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MarketRateID"));

                    ////if (lblOldRate != null)
                    ////{
                    ////    if (strRate.Length != 0 && strRate[0] != string.Empty)
                    ////    {
                    ////        lblOldRate.Text = txtNewRate.Text = Convert.ToString(strRate[0].ToString().Substring(0, strRate[0].ToString().LastIndexOf(".") + 1 + 2));
                    ////    }
                    ////    else
                    ////        txtNewRate.Text = "0.00";
                    ////}

                    if (lblOldRateDate != null)
                    {
                        if (strRate.Length > 1 && strRate[1] != string.Empty)
                        {
                            DateTime dtDate = Convert.ToDateTime(strRate[1]);
                            lblOldRateDate.Text = Convert.ToString(dtDate.ToString(this.DateFormat));
                        }
                    }

                    if (strMarketRateID != string.Empty && strMarketRateID != null)
                    {
                        ((HiddenField)e.Row.FindControl("hdnMarketRateID")).Value = Convert.ToString(strMarketRateID);
                    }

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region DropDown Event

        protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUnitTypeGrid();
        }

        #endregion DropDown Event

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

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    DateTime dtDeleteDate = DateTime.ParseExact(this.DateOfRate, "MM-dd-yyyy HH:mm:ss", objCultureInfo);
                    //DateTime dtDeleteDate = Convert.ToDateTime(this.DateOfRate);
                   
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