using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using AjaxControlToolkit;
using System.Text;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlFloor : System.Web.UI.UserControl
    {
        #region Variable Declaraction

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
        public Guid WingID
        {
            get
            {
                return ViewState["WingID"] != null ? new Guid(Convert.ToString(ViewState["WingID"])) : Guid.Empty;
            }
            set
            {
                ViewState["WingID"] = value;
            }
        }
        public Guid FloorID
        {
            get
            {
                return ViewState["FloorID"] != null ? new Guid(Convert.ToString(ViewState["FloorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FloorID"] = value;
            }
        }
        public bool IsWInsert = false;

        public bool IsFInsert = false;

        public bool IsWFInsert = false;

        #endregion Variable Declaraction

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("FloorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            if (!IsPostBack)
                LoadDefaultValue();
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("FloorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = btnSaveWing.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNewWing.Visible = btnNewF.Visible = btnCancel.Visible = btnCancelWing.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNewWing.Visible = btnNewF.Visible  = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.WingID == Guid.Empty)
                    btnSaveWing.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.FloorID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                if (Session["Property"] != null)
                {
                    this.PropertyID = new Guid(Convert.ToString(Session["Property"]));
                    Session.Remove("Property");
                    if (Session["WingSelect"] != null)
                    {
                        //tbWingFloor.ActiveTabIndex = 0;                        
                        Session.Remove("WingSelect");
                    }
                    else if (Session["FloorSelect"] != null)
                    {
                        //tbWingFloor.ActiveTabIndex = 1;
                        Session.Remove("FloorSelect");
                    }
                }
                //else
                //    tbWingFloor.ActiveTabIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindGrid()
        {
            ClearControlValueW();
            ClearControlValueF();
        }
        /// <summary>
        /// Load Clear Value
        /// </summary>
        private void ClearControlValueW()
        {
            LoadPropertyData(ddlWPropertyName, true);
            LoadPropertyData(ddlProperty, false);
            if (this.PropertyID == Guid.Empty)
                ddlWPropertyName.SelectedValue = Guid.Empty.ToString();
            txtWingName.Text = "";
            txtWingCode.Text = "";
            txtWingName.Focus();
            BindWing();
            this.WingID = Guid.Empty;
            ddlWPropertyName.Enabled = true;
        }
        /// <summary>
        /// Clear Control Value F
        /// </summary>
        private void ClearControlValueF()
        {
            LoadPropertyData(ddlPropertyFloor, true);
            LoadPropertyData(ddlSFloorSearch, false);
            if (this.PropertyID == Guid.Empty)
                ddlPropertyFloor.SelectedValue = Guid.Empty.ToString();
            // txtFloorCode.Text = "";
            chkFloorBlocks.Items.Clear();
            txtFloorName.Text = "";
            BindWing();
            BindFloor();
            this.FloorID = Guid.Empty;
            ddlPropertyFloor.Enabled = true;
        }
        /// <summary>
        /// Load DropDown List Data
        /// </summary>
        /// <param name="ddl"></param>
        private void LoadPropertyData(DropDownList ddl, bool IsEntry)
        {
            ddl.Items.Clear();
            DataSet ds = PropertyBLL.SelectData(new Guid(Convert.ToString(Session["CompanyID"])));
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";
                ddl.DataSource = dv;
                ddl.DataTextField = "PropertyName";
                ddl.DataValueField = "PropertyID";
                ddl.DataBind();
                if (IsEntry == true)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
                if (this.PropertyID != Guid.Empty && IsEntry == false)
                    ddl.SelectedValue = Convert.ToString(this.PropertyID);
            }
            else
            {
                if (IsEntry == true)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Bind Wing
        /// </summary>
        private void BindWing()
        {
            Guid? PropertyID;
            if (ddlProperty.SelectedValue != Guid.Empty.ToString())
                PropertyID = new Guid(ddlProperty.SelectedValue.ToString());
            else
                PropertyID = null;

            DataSet dsWing = WingBLL.SearchWingData(null, PropertyID, null);
            DataView dvWing = new DataView(dsWing.Tables[0]);
            dvWing.Sort = "WingName Asc";
            grdWingList.DataSource = dvWing;
            grdWingList.DataBind();

        }

        /// <summary>
        /// Bind Floor
        /// </summary>
        private void BindFloor()
        {
            Floor GetAllFloor = new Floor();
            if (ddlSFloorSearch.SelectedValue != Guid.Empty.ToString())
                GetAllFloor.PropertyID = new Guid(ddlSFloorSearch.SelectedValue.ToString());
            else
                GetAllFloor.PropertyID = null;

            DataSet dsFoors = FloorBLL.GetAllWithDataSet(GetAllFloor);
            if (dsFoors != null && dsFoors.Tables[0].Rows.Count > 0)
            {
                DataView dvFloor = new DataView(dsFoors.Tables[0]);
                dvFloor.Sort = "FloorName Asc";
                grdFloorList.DataSource = dvFloor;
                grdFloorList.DataBind();
                DVFloor.Visible = false;
            }
            else
            {
                grdFloorList.DataSource = null;
                grdFloorList.DataBind();
                DVFloor.Visible = true;
            }
        }
        private void BindCheckBoxWing()
        {
            string WingQuery = "Select WingID, WingName From mst_Wing Where IsActive = 1 And PropertyID= '" + ddlPropertyFloor.SelectedValue + "'";
            DataSet dsWing = WingBLL.GetWing(WingQuery);

            chkFloorBlocks.Items.Clear();
            if (dsWing.Tables[0].Rows.Count != 0)
            {
                DataView dvWing = new DataView(dsWing.Tables[0]);
                dvWing.Sort = "WingName Asc";
                chkFloorBlocks.Visible = true;
                for (int i = 0; i < dvWing.Count; i++)
                {
                    chkFloorBlocks.Items.Add(new ListItem(Convert.ToString(dvWing[i]["WingName"]), Convert.ToString(dvWing[i]["WingID"])));                    
                    chkFloorBlocks.Items[i].Selected = true;
                }
            }
            else
            {
                chkFloorBlocks.Visible = false;
                chkFloorBlocks.DataSource = null;
                chkFloorBlocks.DataBind();
            }
        }

        private void BindWingCheckBox()
        {
            if (this.FloorID != Guid.Empty)
            {
                DataSet dsWingFloorJoin = new DataSet();
                WingFloorJoin objWingFloorJoin = new WingFloorJoin();
                objWingFloorJoin.FloorID = this.FloorID;

                dsWingFloorJoin = WingFloorJoinBLL.GetAllWithDataSet(objWingFloorJoin);                
                if (dsWingFloorJoin.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < chkFloorBlocks.Items.Count; i++)
                    {
                        DataRow[] rows = dsWingFloorJoin.Tables[0].Select("WingID = '" + chkFloorBlocks.Items[i].Value.ToString() + "'");
                        if (rows.Length > 0)
                            chkFloorBlocks.Items[i].Selected = true;
                        else
                            chkFloorBlocks.Items[i].Selected = false;
                    }
                }
                else
                {
                    for (int j = 0; j < chkFloorBlocks.Items.Count; j++)
                    {
                        chkFloorBlocks.Items[j].Selected = false;
                    }
                }
            }
        }

        #endregion Private Method

        #region Wing Button Event
        /// <summary>
        /// Add New Wing
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNewWing_Click(object sender, EventArgs e)
        {
            ClearControlValueW();
            btnSaveWing.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        /// <summary>
        /// Save Wing Information
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveWing_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Wing IsWingDup = new Wing();
                    IsWingDup.PropertyID = new Guid(Convert.ToString(Convert.ToString(ddlWPropertyName.SelectedValue)));
                    IsWingDup.WingName = txtWingName.Text.Trim();
                    IsWingDup.IsActive = true;
                    List<Wing> LstDupWing = WingBLL.GetAll(IsWingDup);
                    if (LstDupWing.Count > 0)
                    {
                        if (this.WingID != null)
                        {
                            if (Convert.ToString((LstDupWing[0].WingID)) != Convert.ToString(this.WingID))
                            {
                                IsWInsert = true;
                                lblWingMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsWInsert = true;
                            lblWingMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }
                    if (this.WingID != Guid.Empty)
                    {
                        //Update Wing Information
                        Wing oldUpdt = WingBLL.GetByPrimaryKey(this.WingID);
                        Wing Updt = WingBLL.GetByPrimaryKey(this.WingID);
                        Updt.PropertyID = new Guid(ddlWPropertyName.SelectedValue.ToString());
                        Updt.WingName = txtWingName.Text;
                        Updt.WingCode = txtWingCode.Text;
                        //if (!txtSBArea.Text.Equals(""))
                        //    Updt.SBArea = Convert.ToDecimal(txtSBArea.Text);
                        //if (!txtCarpetArea.Text.Equals(""))
                        //    Updt.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text);                        
                        Updt.LastUpdateOn = DateTime.Now.Date;
                        Updt.LastUpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        WingBLL.Update(Updt);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", oldUpdt.ToString(), Updt.ToString(), "mst_Wing");
                        this.WingID = Guid.Empty;
                        IsWInsert = true;
                        lblWingMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        //Insert Wing Information
                        Wing Ins = new Wing();
                        Ins.PropertyID = new Guid(ddlWPropertyName.SelectedValue.ToString());
                        Ins.WingName = txtWingName.Text;
                        Ins.WingCode = txtWingCode.Text;
                        //if (!txtSBArea.Text.Equals(""))
                        //    Ins.SBArea = Convert.ToDecimal(txtSBArea.Text);
                        //if (!txtCarpetArea.Text.Equals(""))
                        //    Ins.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text);
                        Ins.IsActive = true;
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.LastUpdateOn = DateTime.Now.Date;
                        Ins.IsSynch = false;
                        Ins.LastUpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        WingBLL.Save(Ins);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "mst_Wing");
                        IsWInsert = true;
                        lblWingMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControlValueW();
                    ddlPropertyFloor_SelectedIndexChanged(null, null);
                    BindWingCheckBox();
                    //LoadWing();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Cancel Wing Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancelWing_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControlValueW();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        #endregion Wing Button Event

        #region Wing Grid View Event
        /// <summary>
        /// Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void grdWingList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    Wing UpdtWing = WingBLL.GetByPrimaryKey(new Guid(e.CommandArgument.ToString()));
                    this.WingID = UpdtWing.WingID;
                    LoadPropertyData(ddlWPropertyName, true);
                    if (UpdtWing.PropertyID != null)
                        ddlWPropertyName.SelectedValue = Convert.ToString(UpdtWing.PropertyID);
                    ddlWPropertyName.Enabled = false;
                    txtWingCode.Text = UpdtWing.WingCode;
                    txtWingName.Text = UpdtWing.WingName;
                    LoadAccess();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    hdnProcessType.Value = "Block";
                    this.WingID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
                else if (e.CommandName.Equals("FloorData"))
                {
                    string WingID = Convert.ToString(e.CommandArgument.ToString());
                }
                else if (e.CommandName.Equals("UnitData"))
                {
                    string WingID = Convert.ToString(e.CommandArgument.ToString());
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdWingList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnWingEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnWingDelete");

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                    Label lblPropertyName = (Label)e.Row.FindControl("lblPropertyName");

                    if (ddlProperty.SelectedIndex != 0)
                        lblPropertyName.Visible = false;
                    else
                        lblPropertyName.Visible = true;

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
        #endregion Wing Grid View Event

        #region Popup Button Event
        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                if (this.WingID != Guid.Empty && Convert.ToString(hdnProcessType.Value) == "Block")
                {
                    Wing Updt = WingBLL.GetByPrimaryKey(this.WingID);
                    this.WingID = Guid.Empty;
                    WingBLL.Delete(Updt);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", Updt.ToString(), null, "mst_Wing");
                    ClearControlValueW();
                    ddlPropertyFloor_SelectedIndexChanged(null, null);
                    BindWingCheckBox();
                    IsWInsert = true;
                    lblWingMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                else if (this.FloorID != Guid.Empty && Convert.ToString(hdnProcessType.Value) == "Floor")
                {
                    Floor Updt = FloorBLL.GetByPrimaryKey(this.FloorID);
                    this.FloorID = Guid.Empty;
                    FloorBLL.Delete(Updt);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", Updt.ToString(), null, "mst_Floor");
                    IsFInsert = true;
                    lblFMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                    ClearControlValueF();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.WingID = Guid.Empty;
                this.FloorID = Guid.Empty;
                msgbx.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Popup Button Event

        #region Floor Button Event
        /// <summary>
        /// Add New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNewF_Click(object sender, EventArgs e)
        {
            ClearControlValueF();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControlValueF();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}
        /// <summary>
        /// Save Floor Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Floor IsWingDup = new Floor();
                    IsWingDup.PropertyID = new Guid(Convert.ToString(ddlPropertyFloor.SelectedValue));
                    IsWingDup.FloorName = txtFloorName.Text.Trim();
                    IsWingDup.IsActive = true;
                    List<Floor> LstDupWing = FloorBLL.GetAll(IsWingDup);
                    if (LstDupWing.Count > 0)
                    {
                        if (this.FloorID != null)
                        {
                            if (Convert.ToString((LstDupWing[0].FloorID)) != Convert.ToString(this.FloorID))
                            {
                                IsFInsert = true;
                                lblFMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsFInsert = true;
                            lblFMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    List<WingFloorJoin> lstWingFloorJoin = new List<WingFloorJoin>();
                    if (this.FloorID != Guid.Empty)
                    {
                        //Update Wing Information
                        Floor oldUpdt = FloorBLL.GetByPrimaryKey(this.FloorID);
                        Floor Updt = FloorBLL.GetByPrimaryKey(this.FloorID);
                        Updt.PropertyID = new Guid(ddlPropertyFloor.SelectedValue.ToString());
                        Updt.FloorName = txtFloorName.Text;
                        // Updt.FloorCode = txtFloorCode.Text;                        
                        Updt.LastUpdateOn = DateTime.Now.Date;
                        for (int i = 0; i < chkFloorBlocks.Items.Count; i++)
                        {
                            if (chkFloorBlocks.Items[i].Selected)
                            {
                                WingFloorJoin temp = new WingFloorJoin();
                                temp.WingID = new Guid(chkFloorBlocks.Items[i].Value.ToString());
                                lstWingFloorJoin.Add(temp);
                            }
                        }
                        FloorBLL.Update(Updt, lstWingFloorJoin);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", oldUpdt.ToString(), Updt.ToString(), "mst_Floor");
                        IsFInsert = true;
                        lblFMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.FloorID = Guid.Empty;
                    }
                    else
                    {
                        //Insert Wing Information
                        Floor Ins = new Floor();
                        Ins.PropertyID = new Guid(ddlPropertyFloor.SelectedValue.ToString());
                        Ins.FloorName = txtFloorName.Text;
                        //Ins.FloorCode = txtFloorCode.Text;
                        Ins.IsActive = true;
                        Ins.CreatedOn = DateTime.Now.Date;
                        Ins.LastUpdateOn = DateTime.Now.Date;

                        for (int i = 0; i < chkFloorBlocks.Items.Count; i++)
                        {
                            if (chkFloorBlocks.Items[i].Selected)
                            {
                                WingFloorJoin temp = new WingFloorJoin();
                                temp.WingID = new Guid(chkFloorBlocks.Items[i].Value.ToString());
                                lstWingFloorJoin.Add(temp);
                            }
                        }
                        IsFInsert = true;
                        lblFMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        FloorBLL.Save(Ins, lstWingFloorJoin);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", null, Ins.ToString(), "mst_Floor");
                    }
                    ClearControlValueF();
                    BindWing();
                    //LoadFloor();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        #endregion Floor Button Event

        #region Floor Grid Event
        /// <summary>
        /// Floor Grid Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdFloorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    Floor Updtflr = FloorBLL.GetByPrimaryKey(new Guid(e.CommandArgument.ToString()));
                    this.FloorID = Updtflr.FloorID;
                    LoadPropertyData(ddlPropertyFloor, true);
                    if (Updtflr.PropertyID != null)
                        ddlPropertyFloor.SelectedValue = Convert.ToString(Updtflr.PropertyID);
                    ddlPropertyFloor.Enabled = false;
                    txtFloorName.Text = Updtflr.FloorName;

                    DataSet dsWingFloorJoin = new DataSet();
                    WingFloorJoin objWingFloorJoin = new WingFloorJoin();
                    objWingFloorJoin.FloorID = new Guid(e.CommandArgument.ToString());

                    dsWingFloorJoin = WingFloorJoinBLL.GetAllWithDataSet(objWingFloorJoin);
                    BindCheckBoxWing();
                    if (dsWingFloorJoin.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < chkFloorBlocks.Items.Count; i++)
                        {
                            DataRow[] rows = dsWingFloorJoin.Tables[0].Select("WingID = '" + chkFloorBlocks.Items[i].Value.ToString() + "'");
                            if (rows.Length > 0)
                                chkFloorBlocks.Items[i].Selected = true;
                            else
                                chkFloorBlocks.Items[i].Selected = false;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < chkFloorBlocks.Items.Count; j++)
                        {
                            chkFloorBlocks.Items[j].Selected = false;
                        }
                    }
                    LoadAccess();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    hdnProcessType.Value = "Floor";
                    this.FloorID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdFloorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                    Label lblPropertyName = (Label)e.Row.FindControl("lblPropertyName");

                    if (ddlSFloorSearch.SelectedIndex != 0)
                        lblPropertyName.Visible = false;
                    else
                        lblPropertyName.Visible = true;

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
        #endregion Floor Grid Event

        #region Search Information
        /// <summary>
        /// Search Wing Inforamtion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchWing_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindWing();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Search Floor Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindFloor();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Search Information

        #region DropDown Event

        protected void ddlPropertyFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPropertyFloor.SelectedValue != Guid.Empty.ToString())
                    BindCheckBoxWing();
                else
                {
                    chkFloorBlocks.Visible = false;
                    chkFloorBlocks.DataSource = null;
                    chkFloorBlocks.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}