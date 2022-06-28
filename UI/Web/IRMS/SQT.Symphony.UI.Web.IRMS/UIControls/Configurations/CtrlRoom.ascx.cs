using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlRoom : System.Web.UI.UserControl
    {
        #region Variable

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
        public Guid RoomID
        {
            get
            {
                return ViewState["RoomID"] != null ? new Guid(Convert.ToString(ViewState["RoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomID"] = value;
            }
        }

        public bool IsInsert = false;
        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("RoomSetup.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");

            LoadAccess();
            if (!IsPostBack)
            {
                LoadDefaultValue();
                ////Session.Remove("InvID");

                if (Session["RoomID4Unit"] != null)
                {
                    this.RoomID = new Guid(Convert.ToString(Session["RoomID4Unit"]));
                    Session.Remove("RoomID4Unit");
                    LoadRoomData();
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("RoomTypeSetup.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.RoomID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                if (Session["Property"] != null)
                {
                    this.PropertyID = new Guid(Convert.ToString(Session["Property"]));
                    Session.Remove("Property");
                }
                ClearControlValue();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Clear Control Value
        /// </summary>
        private void ClearControlValue()
        {
            chklstRoomTypeAmenities.Items.Clear();
            this.RoomID = Guid.Empty;
            LoadPropertyData(ddlPropertyName, true);
            LoadPropertyData(ddlSProperty, false);
            if (this.PropertyID == Guid.Empty)
            {
                ddlPropertyName.SelectedValue = Guid.Empty.ToString();
                ddlSProperty.SelectedValue = Guid.Empty.ToString();
            }

            ddlFloor.Items.Clear();
            ddlFloor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddlUnitType.Items.Clear();
            ddlSUnitType.Items.Clear();
            ddlWing.Items.Clear();
            ddlUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            if (this.PropertyID != Guid.Empty)
                BindSearchUnitType();
            else
                ddlSUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            ddlWing.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            txtRoomNo.Text = "";
            txtCarpetArea.Text = "";
            txtLocationDetail.Text = "";
            //txtPropertyTaxAmt.Text = "";
            txtSBArea.Text = "";
            ddlPropertyName.Focus();
            BindGrid();
            ddlPropertyName.Enabled = true;
        }
        /// <summary>
        /// Load Unit No
        /// </summary>
        private void BindUnitType()
        {
            ddlUnitType.Items.Clear();
            RoomType Rm = new RoomType();
            Rm.PropertyID = new Guid(ddlPropertyName.SelectedValue);
            Rm.IsActive = true;
            List<RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((RoomType rm1, RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));
                ddlUnitType.DataSource = LstRm;
                ddlUnitType.DataTextField = "RoomTypeName";
                ddlUnitType.DataValueField = "RoomTypeID";
                ddlUnitType.DataBind();
                ddlUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        private void BindSearchUnitType()
        {
            ddlSUnitType.Items.Clear();
            RoomType Rm = new RoomType();
            Rm.PropertyID = new Guid(ddlSProperty.SelectedValue);
            Rm.IsActive = true;
            List<RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((RoomType rm1, RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));
                ddlSUnitType.DataSource = LstRm;
                ddlSUnitType.DataTextField = "RoomTypeName";
                ddlSUnitType.DataValueField = "RoomTypeID";
                ddlSUnitType.DataBind();
                ddlSUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlSUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
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
                    ddl.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
                if (this.PropertyID != Guid.Empty && IsEntry == false)
                    ddl.SelectedValue = Convert.ToString(this.PropertyID);
            }
            else
            {
                if (IsEntry == true)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }

        }
        /// <summary>
        /// Load Wing Information
        /// </summary>
        private void LoadWing()
        {
            ddlWing.Items.Clear();
            Wing objLoadWing = new Wing();
            objLoadWing.IsActive = true;
            objLoadWing.PropertyID = new Guid(ddlPropertyName.SelectedValue);
            List<Wing> LstWin = WingBLL.GetAll(objLoadWing);
            if (LstWin.Count > 0)
            {
                LstWin.Sort((Wing win1, Wing win2) => win1.WingName.CompareTo(win2.WingName));
                ddlWing.DataSource = LstWin;
                ddlWing.DataTextField = "WingName";
                ddlWing.DataValueField = "WingID";
                ddlWing.DataBind();
                ddlWing.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlWing.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        }
        /// <summary>
        /// Load Floor Information
        /// </summary>
        private void LoadFloor(Guid? WingID)
        {
            ddlFloor.Items.Clear();
            DataSet Dst = WingFloorJoinBLL.GetAllWithName(WingID, null);
            DataView Lstflr = new DataView(Dst.Tables[0]);
            if (Lstflr.Count > 0)
            {
                Lstflr.Sort = "FloorName Asc";
                ddlFloor.DataSource = Lstflr;
                ddlFloor.DataTextField = "FloorName";
                ddlFloor.DataValueField = "FloorID";
                ddlFloor.DataBind();
                ddlFloor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlFloor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindGrid()
        {
            Guid? wingID = null;
            string strRoomNo = null;
            Room GetAllRm = new Room();
            if (ddlSProperty.SelectedValue != Guid.Empty.ToString())
                GetAllRm.PropertyID = new Guid(ddlSProperty.SelectedValue.ToString());
            else
                GetAllRm.PropertyID = null;

            if (ddlSUnitType.SelectedValue != Guid.Empty.ToString())
                GetAllRm.RoomTypeID = new Guid(ddlSUnitType.SelectedValue.ToString());
            else
                GetAllRm.RoomTypeID = null;

            if (txtSearchUnitNo.Text.Trim() != "")
                strRoomNo = txtSearchUnitNo.Text.Trim();

            //Code by Vijay 21 Jan 2012
            if (Session["PropertyID4Unit"] != null)
            {
                GetAllRm.PropertyID = new Guid(Convert.ToString(Session["PropertyID4Unit"]));
                ddlSProperty.SelectedIndex = ddlSProperty.Items.FindByValue(Convert.ToString(Session["PropertyID4Unit"])) != null ? ddlSProperty.Items.IndexOf(ddlSProperty.Items.FindByValue(Convert.ToString(Session["PropertyID4Unit"]))) : 0;
                ddlSProperty_SelectedIndexChanged(null, null);
                Session.Remove("PropertyID4Unit");
            }

            if (Session["RoomTypeID4Unit"] != null)
            {
                GetAllRm.RoomTypeID = new Guid(Convert.ToString(Session["RoomTypeID4Unit"]));
                ddlSUnitType.SelectedIndex = ddlSUnitType.Items.FindByValue(Convert.ToString(GetAllRm.RoomTypeID)) != null ? ddlSUnitType.Items.IndexOf(ddlSUnitType.Items.FindByValue(Convert.ToString(GetAllRm.RoomTypeID))) : 0;
                Session.Remove("RoomTypeID4Unit");
            }

            if (Session["WingID4Unit"] != null)
            {
                wingID = new Guid(Convert.ToString(Session["WingID4Unit"]));
                Session.Remove("WingID4Unit");
            }
            //Code by Vijay End

            GetAllRm.IsActive = true;
            DataSet Dst = RoomBLL.SelectByPropertyRoomType(GetAllRm.PropertyID, GetAllRm.RoomTypeID, wingID, strRoomNo);
            DataView LstRm = new DataView(Dst.Tables[0]);
            if (LstRm.Count > 0)
            {
                //LstRm.Sort = "PropertyName Asc";
                grdRoomList.DataSource = LstRm;
                grdRoomList.DataBind();
                MsgRecFnd.Visible = false;
            }
            else
            {
                grdRoomList.DataSource = null;
                grdRoomList.DataBind();
                MsgRecFnd.Visible = true;
            }
        }

        /// <summary>
        /// Load RoomType Amenities
        /// </summary>
        private void BindRoomTypeAmenities()
        {
            chklstRoomTypeAmenities.Items.Clear();
            DataSet dsRTA = RoomTypeAmenitiesBLL.GetAmenitiesByRoomTypeID(new Guid(ddlUnitType.SelectedValue), null, null);
            if (dsRTA.Tables[0].Rows.Count != 0)
            {
                trAmenities.Visible = true;
                chklstRoomTypeAmenities.DataSource = dsRTA.Tables[0];
                chklstRoomTypeAmenities.DataTextField = "AmenitiesName";
                chklstRoomTypeAmenities.DataValueField = "AmenitiesID";
                chklstRoomTypeAmenities.DataBind();
            }
            else
                trAmenities.Visible = false;
        }

        #endregion Private Method

        #region Popup Button Event
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            if (this.RoomID != Guid.Empty)
            {
                //Last Modified by Harikrishna as on 30-Dec-2011
                Room Updt = RoomBLL.GetByPrimaryKey(this.RoomID);
                //Updt.IsActive = false;
                RoomBLL.Delete(this.RoomID);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", Updt.ToString(), null, "mst_Room");
                IsInsert = true;
                lblRoomErrorMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                ClearControlValue();
            }
            this.RoomID = Guid.Empty;
            msgbx.Hide();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            this.RoomID = Guid.Empty;
            msgbx.Hide();
        }

        #endregion Popup Button Event

        #region Button Event
        /// <summary>
        /// New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
            ClearControlValue();
        }

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ClearControlValue();
        //    LoadAccess();
        //}

        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Room IsWingDup = new Room();
                    IsWingDup.PropertyID = new Guid(Convert.ToString(ddlPropertyName.SelectedValue));
                    //IsWingDup.RoomTypeID = new Guid(ddlUnitType.SelectedValue.ToString());
                    //IsWingDup.WingID = new Guid(ddlWing.SelectedValue.ToString());
                    //IsWingDup.FloorID = new Guid(ddlFloor.SelectedValue.ToString());
                    IsWingDup.RoomNo = txtRoomNo.Text.Trim();
                    IsWingDup.IsActive = true;
                    List<Room> LstDupWing = RoomBLL.GetAll(IsWingDup);
                    if (LstDupWing.Count > 0)
                    {
                        if (this.RoomID != null)
                        {
                            if (Convert.ToString((LstDupWing[0].RoomID)) != Convert.ToString(this.RoomID))
                            {
                                IsInsert = true;
                                lblRoomErrorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsInsert = true;
                            lblRoomErrorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    List<RoomAmenities> lstRoomAmenities = new List<RoomAmenities>();
                    if (this.RoomID != Guid.Empty)
                    {
                        //Update Data
                        Room oldUpdt = RoomBLL.GetByPrimaryKey(this.RoomID);
                        Room Updt = RoomBLL.GetByPrimaryKey(this.RoomID);
                        Updt.PropertyID = new Guid(ddlPropertyName.SelectedValue.ToString());
                        Updt.RoomTypeID = new Guid(ddlUnitType.SelectedValue.ToString());
                        Updt.WingID = new Guid(ddlWing.SelectedValue.ToString());
                        Updt.FloorID = new Guid(ddlFloor.SelectedValue.ToString());
                        Updt.RoomNo = txtRoomNo.Text.Trim();
                        Updt.SBArea = Convert.ToDecimal(txtSBArea.Text.Trim());
                        Updt.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text.Trim());
                        //if (!(txtPropertyTaxAmt.Text.Trim().Equals("")))
                        //    Updt.PropertyTaxNo = txtPropertyTaxAmt.Text;
                        //else
                        //    Updt.PropertyTaxNo = null;
                        Updt.LocationDetail = txtLocationDetail.Text.Trim();
                        Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Updt.UpdatedOn = DateTime.Now;

                        for (int i = 0; i < chklstRoomTypeAmenities.Items.Count; i++)
                        {
                            if (chklstRoomTypeAmenities.Items[i].Selected)
                            {
                                RoomAmenities objTemp = new RoomAmenities();
                                objTemp.AmenitiesID = new Guid(chklstRoomTypeAmenities.Items[i].Value.ToString());
                                lstRoomAmenities.Add(objTemp);
                            }
                        }

                        RoomBLL.Update(Updt, lstRoomAmenities);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", oldUpdt.ToString(), Updt.ToString(), "mst_Room");
                        IsInsert = true;

                        lblRoomErrorMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        //Insert Data
                        Room Ins = new Room();
                        Ins.PropertyID = new Guid(ddlPropertyName.SelectedValue.ToString());
                        Ins.RoomTypeID = new Guid(ddlUnitType.SelectedValue.ToString());
                        Ins.WingID = new Guid(ddlWing.SelectedValue.ToString());
                        Ins.FloorID = new Guid(ddlFloor.SelectedValue.ToString());
                        Ins.RoomNo = txtRoomNo.Text.Trim();
                        Ins.SBArea = Convert.ToDecimal(txtSBArea.Text.Trim());
                        Ins.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text.Trim());
                        //if (!(txtPropertyTaxAmt.Text.Trim().Equals("")))
                        //    Ins.PropertyTaxNo = txtPropertyTaxAmt.Text;
                        //else
                        //    Ins.PropertyTaxNo = null;
                        Ins.LocationDetail = txtLocationDetail.Text.Trim();
                        Ins.IsActive = true;
                        Ins.IsSynch = false;
                        Ins.CreatedOn = DateTime.Now;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                        for (int i = 0; i < chklstRoomTypeAmenities.Items.Count; i++)
                        {
                            if (chklstRoomTypeAmenities.Items[i].Selected)
                            {
                                RoomAmenities objTemp = new RoomAmenities();
                                objTemp.AmenitiesID = new Guid(chklstRoomTypeAmenities.Items[i].Value.ToString());
                                lstRoomAmenities.Add(objTemp);
                            }
                        }

                        RoomBLL.Save(Ins, lstRoomAmenities);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "mst_Room");
                        IsInsert = true;
                        lblRoomErrorMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControlValue();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Grid Row Data Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdRoomList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    this.RoomID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadRoomData();
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.RoomID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
                else if (e.CommandName.Equals("INVESTOR"))
                {
                    Session["InvID"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/Investors/InvestorSetUp.aspx?Val=True");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void LoadRoomData()
        {
            Room GetData = RoomBLL.GetByPrimaryKey(this.RoomID);
            LoadAccess();
            ddlPropertyName.SelectedIndex = ddlPropertyName.Items.FindByValue(Convert.ToString(GetData.PropertyID.Value)) != null ? ddlPropertyName.Items.IndexOf(ddlPropertyName.Items.FindByValue(Convert.ToString(GetData.PropertyID.Value))) : 0;

            ddlPropertyName.Enabled = false;
            BindUnitType();
            if (Convert.ToString(GetData.RoomTypeID.Value) != "")
                ddlUnitType.SelectedIndex = ddlUnitType.Items.FindByValue(Convert.ToString(GetData.RoomTypeID.Value)) != null ? ddlUnitType.Items.IndexOf(ddlUnitType.Items.FindByValue(Convert.ToString(GetData.RoomTypeID.Value))) : 0;
            txtRoomNo.Text = GetData.RoomNo;
            LoadWing();
            if (GetData.WingID != null && Convert.ToString(GetData.WingID) != "")
                ddlWing.SelectedIndex = ddlWing.Items.FindByValue(Convert.ToString(GetData.WingID)) != null ? ddlWing.Items.IndexOf(ddlWing.Items.FindByValue(Convert.ToString(GetData.WingID))) : 0;
            LoadFloor(new Guid(ddlWing.SelectedValue.ToString()));
            if (Convert.ToString(GetData.FloorID) != "" && Convert.ToString(GetData.FloorID) != null)
                ddlFloor.SelectedIndex = ddlFloor.Items.FindByValue(Convert.ToString(GetData.FloorID)) != null ? ddlFloor.Items.IndexOf(ddlFloor.Items.FindByValue(Convert.ToString(GetData.FloorID))) : 0;
            txtSBArea.Text = Convert.ToInt32(GetData.SBArea).ToString();
            txtCarpetArea.Text = Convert.ToInt32(GetData.CarpetArea).ToString();
            //txtPropertyTaxAmt.Text = Convert.ToString(GetData.PropertyTaxNo);
            txtLocationDetail.Text = GetData.LocationDetail;

            BindRoomTypeAmenities();
            RoomAmenities objLoadRoomAmenities = new RoomAmenities();
            objLoadRoomAmenities.RoomID = new Guid(GetData.RoomID.ToString());
            DataSet dsRA = RoomAmenitiesBLL.GetAllWithDataSet(objLoadRoomAmenities);

            if (dsRA.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < chklstRoomTypeAmenities.Items.Count; i++)
                {
                    DataRow[] rows = dsRA.Tables[0].Select("AmenitiesID = '" + chklstRoomTypeAmenities.Items[i].Value.ToString() + "'");
                    if (rows.Length > 0)
                        chklstRoomTypeAmenities.Items[i].Selected = true;
                }
            }
        }

        protected void grdRoomList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

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
        #endregion Grid Event

        #region Wing DropDown List Event
        /// <summary>
        /// Wing Selection Change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadFloor(new Guid(ddlWing.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Wing DropDown List Event

        #region UnitType DropDown List Event
        protected void ddlUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitType.SelectedValue != Guid.Empty.ToString())
                {
                    RoomType objRoomTypeData = new RoomType();
                    objRoomTypeData = RoomTypeBLL.GetByPrimaryKey(new Guid(ddlUnitType.SelectedValue));
                    if (objRoomTypeData != null)
                    {
                        txtCarpetArea.Text = Convert.ToString(objRoomTypeData.CarpetArea);
                        txtSBArea.Text = Convert.ToString(objRoomTypeData.SBArea);
                    }
                    else
                    {
                        txtSBArea.Text = "";
                        txtCarpetArea.Text = "";
                    }
                    BindRoomTypeAmenities();
                }
                else
                {
                    txtSBArea.Text = "";
                    txtCarpetArea.Text = "";
                    chklstRoomTypeAmenities.Items.Clear();
                    trAmenities.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion UnitType DropDown List Event

        #region Property Dropdown Event
        /// <summary>
        /// Property Dropdown Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            chklstRoomTypeAmenities.Items.Clear();
            if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
            {
                BindUnitType();
                LoadWing();
                LoadFloor(new Guid(Guid.Empty.ToString()));
                ddlUnitType_SelectedIndexChanged(null, null);
            }
            else
            {

                ddlUnitType.Items.Clear();
                trAmenities.Visible = false;
                ddlWing.Items.Clear();
                ddlFloor.Items.Clear();
                ddlUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlWing.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlFloor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                txtSBArea.Text = "";
                txtCarpetArea.Text = "";
            }
        }

        /// <summary>
        ///  Dropdown Event For Search Property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSProperty.SelectedValue != Guid.Empty.ToString())
                BindSearchUnitType();
            else
            {
                ddlSUnitType.Items.Clear();
                ddlSUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }

        }

        #endregion

    }
}