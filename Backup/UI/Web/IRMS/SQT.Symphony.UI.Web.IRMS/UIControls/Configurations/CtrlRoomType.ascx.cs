using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.IO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlRoomType : System.Web.UI.UserControl
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
        public Guid UnitTypeID
        {
            get
            {
                return ViewState["UnitTypeID"] != null ? new Guid(Convert.ToString(ViewState["UnitTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["UnitTypeID"] = value;
            }
        }
        
        Guid roomTypeID = Guid.Empty;
        public bool IsInsert = false;

        #endregion Variable Declaraction

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("RoomTypeSetup.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            if (!IsPostBack)
            {
                LoadDefaultValue();

                if (Session["RoomTypeID4Unit"] != null)
                {
                    this.UnitTypeID = new Guid(Convert.ToString(Session["RoomTypeID4Unit"]));
                    Session.Remove("RoomTypeID4Unit");
                    BindRoomType();
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
                if (this.UnitTypeID == Guid.Empty)
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
                ClearUnitTypeInformation();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Clear Unit Type Information
        /// </summary>
        private void ClearUnitTypeInformation()
        {
            chklstAmenities.Items.Clear();
            LoadPropertyData(ddlPropertyName,true);
            LoadPropertyData(ddlSProperty,false);
            if (this.PropertyID == Guid.Empty)
            {
                ddlPropertyName.SelectedValue = Guid.Empty.ToString();
                ddlSProperty.SelectedValue = Guid.Empty.ToString();
            }
            txtRoomTypeName.Text = "";
            txtRoomTypeCode.Text = "";
            txtAboutRoomType.Text = "";
            txtCarpetArea.Text = "";
            txtSBArea.Text = "";
            this.UnitTypeID = Guid.Empty;
            imbEvaliationDrawing.ImageUrl = "~/images/elevation.gif";
            lnkRemoveEvaluationDrawing.Visible = false;
            txtUnitTypeSearch.Text = "";
            ddlPropertyName.Focus();
            BindGrid();
            ddlPropertyName.Enabled = true;
            trEvaliationDrawing.Visible = trAmenities.Visible = false;
        }
        /// <summary>
        /// Load DropDown List Data
        /// </summary>
        /// <param name="ddl"></param>
        private void LoadPropertyData(DropDownList ddl,bool IsEntry)
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
                if (IsEntry)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));

                if (this.PropertyID != Guid.Empty && IsEntry == false)
                    ddl.SelectedValue = Convert.ToString(this.PropertyID);
            }
            else
            {
                if (IsEntry)
                    ddl.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                else
                    ddl.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Bind Grid
        /// </summary>
        private void BindGrid()
        {
            RoomType Search = new RoomType();
            if (ddlSProperty.SelectedValue != Guid.Empty.ToString())
                Search.PropertyID = new Guid(ddlSProperty.SelectedValue.ToString());
            else
                Search.PropertyID = null;
            if (!txtUnitTypeSearch.Text.Equals(""))
                Search.RoomTypeName = txtUnitTypeSearch.Text;
            else
                Search.RoomTypeName = null;

            DataSet dsRoomTypes = RoomTypeBLL.GetAllWithDataSet(Search);
            if (dsRoomTypes != null && dsRoomTypes.Tables[0].Rows.Count > 0)
            {
                DataView dv = new DataView(dsRoomTypes.Tables[0]);
                dv.Sort = "RoomTypeName Asc";
                gvRoomTypeList.DataSource = dv;
                gvRoomTypeList.DataBind();
                MsgRecFnd.Visible = false;
            }
            else
            {
                gvRoomTypeList.DataSource = null;
                gvRoomTypeList.DataBind();
                MsgRecFnd.Visible = true;
            }
        }

        /// <summary>
        /// Load Amenities
        /// </summary>
        private void BindAmenities()
        {
            chklstAmenities.Items.Clear();
            string AmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in ('268105BE-899A-40CA-9718-82448FF38172','9435ED89-A452-4DE4-9D8C-1CF1E9BD7B46') And PropertyID='" + ddlPropertyName.SelectedValue.ToString() + "' And IsActive = 1 order by AmenitiesName Asc";
            DataSet ds = AmenitiesBLL.GetAmenities(AmenitiesQuery);
            if (ds.Tables[0].Rows.Count != 0)
            {
                trAmenities.Visible = true;
                chklstAmenities.DataSource = ds.Tables[0];
                chklstAmenities.DataTextField = "AmenitiesName";
                chklstAmenities.DataValueField = "AmenitiesID";
                chklstAmenities.DataBind();
            }
            else
                trAmenities.Visible = false;
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add New Room Type 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearUnitTypeInformation();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    ClearUnitTypeInformation();
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
                    RoomType IsWingDup = new RoomType();
                    IsWingDup.PropertyID = new Guid(Convert.ToString(ddlPropertyName.SelectedValue));
                    IsWingDup.RoomTypeName = txtRoomTypeName.Text.Trim();
                    IsWingDup.IsActive = true;
                    List<RoomType> LstDupWing = RoomTypeBLL.GetAll(IsWingDup);
                    if (LstDupWing.Count > 0)
                    {
                        if (this.UnitTypeID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupWing[0].RoomTypeID)) != Convert.ToString(this.UnitTypeID))
                            {
                                IsInsert = true;
                                lblErrorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsInsert = true;
                            lblErrorMsg.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    List<RoomTypeAmenities> lstRoomTypeAmenities = new List<RoomTypeAmenities>();
                    if (this.UnitTypeID != Guid.Empty)
                    {
                        //Update Information
                        RoomType oldUpdt = RoomTypeBLL.GetByPrimaryKey(this.UnitTypeID);
                        RoomType Updt = RoomTypeBLL.GetByPrimaryKey(this.UnitTypeID);
                        Updt.PropertyID = new Guid(ddlPropertyName.SelectedValue.ToString());
                        Updt.RoomTypeName = txtRoomTypeName.Text;
                        Updt.RoomTypeCode = txtRoomTypeCode.Text;
                        Updt.SBArea = Convert.ToDecimal(txtSBArea.Text);
                        Updt.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text);
                        Updt.UpdatedOn = DateTime.Now.Date;
                        Updt.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Updt.AboutRoomType = txtAboutRoomType.Text;

                        if (flEvaliationDrawing.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "_" + flEvaliationDrawing.FileName.Replace(" ", "_");
                            string path = Server.MapPath("~/UploadPhoto/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(flEvaliationDrawing.FileContent);
                            double widthRatio = (double)origBMP.Width / (double)470;
                            double heightRatio = (double)origBMP.Height / (double)390;
                            double ratio = Math.Max(widthRatio, heightRatio);
                            int newWidth = (int)(origBMP.Width / ratio);
                            int newHeight = (int)(origBMP.Height / ratio);

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                            newBMP.Dispose();
                            objGra.Dispose();

                            Updt.ElevationDrawing = cmpPhoto;
                        }

                        for (int i = 0; i < chklstAmenities.Items.Count; i++)
                        {
                            if (chklstAmenities.Items[i].Selected)
                            {
                                RoomTypeAmenities objTemp = new RoomTypeAmenities();
                                objTemp.AmenitiesID = new Guid(chklstAmenities.Items[i].Value.ToString());
                                lstRoomTypeAmenities.Add(objTemp);
                            }
                        }

                        RoomTypeBLL.Update(Updt, lstRoomTypeAmenities);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", oldUpdt.ToString(), Updt.ToString(), "mst_RoomType");
                        IsInsert = true;
                        lblErrorMsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        this.UnitTypeID = Guid.Empty;
                    }
                    else
                    {
                        //Insert Information
                        RoomType Ins = new RoomType();
                        Ins.PropertyID = new Guid(ddlPropertyName.SelectedValue.ToString());
                        Ins.RoomTypeName = txtRoomTypeName.Text;
                        Ins.RoomTypeCode = txtRoomTypeCode.Text;
                        Ins.SBArea = Convert.ToDecimal(txtSBArea.Text);
                        Ins.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text);
                        Ins.AboutRoomType = txtAboutRoomType.Text;
                        Ins.CreatedOn = DateTime.Now;
                        Ins.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Ins.IsActive = true;
                        Ins.IsSynch = false;

                        if (flEvaliationDrawing.FileName != "")
                        {
                            string cmpPhoto = Guid.NewGuid() + "_" + flEvaliationDrawing.FileName.Replace(" ", "_");
                            string path = Server.MapPath("~/UploadPhoto/" + cmpPhoto);

                            System.Drawing.Bitmap origBMP = new System.Drawing.Bitmap(flEvaliationDrawing.FileContent);
                            int newWidth = 450;
                            int newHeight = 450;

                            System.Drawing.Bitmap newBMP = new System.Drawing.Bitmap(origBMP, newWidth, newHeight);
                            System.Drawing.Graphics objGra = System.Drawing.Graphics.FromImage(newBMP);

                            objGra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            objGra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            objGra.DrawImage(origBMP, 0, 0, newWidth, newHeight);

                            origBMP.Dispose();
                            newBMP.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                            newBMP.Dispose();
                            objGra.Dispose();

                            Ins.ElevationDrawing = cmpPhoto;
                        }
                        else
                            Ins.ElevationDrawing = "elevation.gif";

                        for (int i = 0; i < chklstAmenities.Items.Count; i++)
                        {
                            if (chklstAmenities.Items[i].Selected)
                            {
                                RoomTypeAmenities objTemp = new RoomTypeAmenities();
                                objTemp.AmenitiesID = new Guid(chklstAmenities.Items[i].Value.ToString());
                                lstRoomTypeAmenities.Add(objTemp);
                            }
                        }

                        RoomTypeBLL.Save(Ins, lstRoomTypeAmenities);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", Ins.ToString(), Ins.ToString(), "mst_RoomType");
                        IsInsert = true;
                        lblErrorMsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearUnitTypeInformation();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void lnkRemoveEvaluationDrawing_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UnitTypeID != Guid.Empty)
                {
                    RoomType GetImg = RoomTypeBLL.GetByPrimaryKey(this.UnitTypeID);
                    if (GetImg != null && GetImg.ElevationDrawing.ToString().ToUpper() != "ELEVATION.GIF")
                    {
                        string DeletePath = Server.MapPath("~/UploadPhoto/") + Convert.ToString(GetImg.ElevationDrawing);
                        File.Delete(DeletePath);
                        GetImg.ElevationDrawing = "elevation.gif";
                        RoomTypeBLL.Update(GetImg);
                        IsInsert = true;
                        lblErrorMsg.Text = global::Resources.IRMSMsg.RemovePhotoMsg.ToString().Trim();
                        imbEvaliationDrawing.ImageUrl = "~/images/elevation.gif";
                    }
                    else
                        imbEvaliationDrawing.ImageUrl = "~/images/elevation.gif";

                    lnkRemoveEvaluationDrawing.Visible = false;
                }
                else
                {
                    //MessageBox.Show("Select Investor Team Information From The List");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Button Event

        #region Grid View Event
        /// <summary>
        /// Data Row Command Evnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvRoomTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                this.UnitTypeID = new Guid(Convert.ToString(e.CommandArgument));                
                BindRoomType();
            }
            else if (e.CommandName.Equals("DELETEDATA"))
            {
                lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                this.UnitTypeID = new Guid(Convert.ToString(e.CommandArgument));
                LoadAccess();
                msgbx.Show();
            }
        }

        private void BindRoomType()
        {
            RoomType GetData = RoomTypeBLL.GetByPrimaryKey(this.UnitTypeID);
            LoadAccess();
            ddlPropertyName.SelectedValue = GetData.PropertyID.Value.ToString();
            ddlPropertyName.Enabled = false;
            txtRoomTypeCode.Text = GetData.RoomTypeCode;
            txtRoomTypeName.Text = GetData.RoomTypeName;
            txtCarpetArea.Text = Convert.ToInt32(GetData.CarpetArea).ToString();
            txtSBArea.Text = Convert.ToInt32(GetData.SBArea).ToString();

            trEvaliationDrawing.Visible = true;

            if (GetData.ElevationDrawing.ToUpper().ToString() == "ELEVATION.GIF")
            {
                imbEvaliationDrawing.ImageUrl = "~/images/elevation.gif";
                lnkRemoveEvaluationDrawing.Visible = false;
            }
            else
            {
                imbEvaliationDrawing.ImageUrl = "~/UploadPhoto/" + Convert.ToString(GetData.ElevationDrawing);
                lnkRemoveEvaluationDrawing.Visible = Convert.ToBoolean(ViewState["Edit"]);
            }
            txtAboutRoomType.Text = GetData.AboutRoomType;

            BindAmenities();
            RoomTypeAmenities objLoadRTA = new RoomTypeAmenities();
            objLoadRTA.RoomTypeID = this.UnitTypeID;
            DataSet ds = RoomTypeAmenitiesBLL.GetAllWithDataSet(objLoadRTA);

            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < chklstAmenities.Items.Count; i++)
                {
                    DataRow[] rows = ds.Tables[0].Select("AmenitiesID = '" + chklstAmenities.Items[i].Value.ToString() + "'");
                    if (rows.Length > 0)
                        chklstAmenities.Items[i].Selected = true;
                }
            }
        }

        protected void gvRoomTypeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                Label lblPropertyName = (Label)e.Row.FindControl("lblPropertyName");

                if (ddlSProperty.SelectedIndex != 0)
                    lblPropertyName.Visible = false;
                else
                    lblPropertyName.Visible = true;

                EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                if (Convert.ToBoolean(ViewState["Edit"]) == true)
                    EditImg.ToolTip = "View/Edit";
                else if (Convert.ToBoolean(ViewState["View"]) == true)
                    EditImg.ToolTip = "View";
            }
        }

        #endregion Grid View Event

        #region Popup Button Event
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            //Modified By Hari: as on 30-Dec-2011
            RoomType Del = RoomTypeBLL.GetByPrimaryKey(this.UnitTypeID);
            //Del.IsActive = false;
            RoomTypeBLL.Delete(this.UnitTypeID);
            ActionLogBLL.Save(null, "Delete", Del.ToString(), null, "mst_RoomType");
            this.UnitTypeID = Guid.Empty;
            IsInsert = true;
            lblErrorMsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
            msgbx.Hide();
            ClearUnitTypeInformation();
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            this.UnitTypeID = Guid.Empty;
            msgbx.Hide();
        }
        #endregion Popup Button Event

        #region Search Button Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid();
        }

        #endregion Search Button Event

        #region Dropdown Event
        protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
                BindAmenities();
            else
            {
                chklstAmenities.Items.Clear();
                trAmenities.Visible = false;
            }
        }
        #endregion Dropdown Event
    }
}