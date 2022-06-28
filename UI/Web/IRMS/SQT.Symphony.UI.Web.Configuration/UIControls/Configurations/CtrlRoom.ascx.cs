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
using System.IO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlRoom : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;
        public bool IsListMessageForGallary = false;

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

        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }
        #endregion Variable and Property

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(0);", true);
                lblSelectFileForRG.Text = "";
                BindData();

                if (clsSession.ToEditItemType == "ROOM" && clsSession.ToEditItemID != Guid.Empty)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                    btnSave.Visible = trPhoto.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.RoomID = clsSession.ToEditItemID;
                    hdnRoomID.Value = Convert.ToString(clsSession.ToEditItemID);
                    BindRoomData();
                }

                BindBreadCrumb();
            }

        }
        #endregion Form Load

        #region Private Method

        //private void BindAmenities()
        //{
        //    try
        //    {

        //        chkAmenitiesList.Items.Clear();
        //        //string AmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in ('268105BE-899A-40CA-9718-82448FF38172','9435ED89-A452-4DE4-9D8C-1CF1E9BD7B46') And PropertyID='" + clsSession.PropertyID + "' And IsActive = 1 order by AmenitiesName Asc";
        //        string AmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in (select TermID from mst_ProjectTerm where Term in ('Both','Unit') and IsActive = 1 and PropertyID = '" + clsSession.PropertyID + "' and CompanyID = '" + clsSession.CompanyID + "') And PropertyID='" + clsSession.PropertyID + "' And IsActive = 1 order by AmenitiesName Asc";
        //        DataSet ds = AmenitiesBLL.GetAmenities(AmenitiesQuery);
        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            chkAmenitiesList.DataSource = ds.Tables[0];
        //            chkAmenitiesList.DataTextField = "AmenitiesName";
        //            chkAmenitiesList.DataValueField = "AmenitiesID";
        //            chkAmenitiesList.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Room", "lblMainHeader", "ROOM SETUP");
            lbltpUnitTypeName.Text = clsCommon.GetGlobalResourceText("Room", "lbltpUnitTypeName", "Room Type");
            lblBlock.Text = clsCommon.GetGlobalResourceText("Room", "lblBlock", "Block");
            lblFloor.Text = clsCommon.GetGlobalResourceText("Room", "lblFloor", "Floor");
            lbltpUnitNo.Text = clsCommon.GetGlobalResourceText("Room", "lbltpUnitNo", "Room No.");
            lbltpKeyNo.Text = clsCommon.GetGlobalResourceText("Room", "lbltpKeyNo", "Key No.");
            lbltpExtNo.Text = clsCommon.GetGlobalResourceText("Room", "lbltpExtNo", "Ext No.");
            lbltpNoOfBed.Text = clsCommon.GetGlobalResourceText("Room", "lbltpNoOfBed", "No. of Bed");
            litReservationDetail.Text = clsCommon.GetGlobalResourceText("Room", "lblReservationDetail", "Reservation Detail");
            //lbltpMaximum.Text = clsCommon.GetGlobalResourceText("Room", "lbltpMaximum", "Maximum");
            lbltpAdult.Text = clsCommon.GetGlobalResourceText("Room", "lbltpAdult", "Maximum Adult");
            lbltpChild.Text = clsCommon.GetGlobalResourceText("Room", "lbltpChild", "Maximum Child");
            lbltpStay.Text = clsCommon.GetGlobalResourceText("Room", "lbltpStay", "Stay");
            lbltpMin.Text = clsCommon.GetGlobalResourceText("Room", "lbltpMin", "Min");
            lbltpMax.Text = clsCommon.GetGlobalResourceText("Room", "lbltpMax", "Max");
            litAmenities.Text = clsCommon.GetGlobalResourceText("Room", "lblAmenities", "Amenities");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            chkIsDiscountApplicable.Text = clsCommon.GetGlobalResourceText("Room", "lblIsDiscountApplicable", "Is Discount Applicable");
            chkIsBlockForBooking.Text = clsCommon.GetGlobalResourceText("Room", "lblIsBlockforBooking", "Is Block for Booking");
            chkIsavailableCRS.Text = clsCommon.GetGlobalResourceText("Room", "lblIsAvaiableOnCRS", "Is Avaiable On CRS");
            cmpStay.Text = clsCommon.GetGlobalResourceText("Room", "lblMsgMinMaxStay", "Min. Stay should be less than or equal to Max. Stay.");
            litTabBasicInformation.Text = clsCommon.GetGlobalResourceText("Room", "lblTabBasicInformation", "Basic Information");
            litTabGallary.Text = clsCommon.GetGlobalResourceText("Room", "lblTabGallary", "Gallary");
            btnUpload.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnUpload", "Upload All");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
            chkIsSmokingAllowed.Text = clsCommon.GetGlobalResourceText("Room", "lblIsSmokingAllowed", "Is Smoking Allowed");
            chkExtraBedAllowed.Text = clsCommon.GetGlobalResourceText("Room", "lblExtraBedAllowed", "Extra Bed Allow");
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitList", "Unit List");
            dr3["Link"] = "~/GUI/Configurations/RoomList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = txtUnitNo.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnit", "Unit") : "Unit No. " + txtUnitNo.Text.Trim() + "&nbsp;";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindUnitType();
                BindWing();
                ddlFloor.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                //tpGallary.Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Unit Type
        /// </summary>
        private void BindUnitType()
        {
            ddlUnitTypeName.Items.Clear();
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            RoomType Rm = new RoomType();
            Rm.PropertyID = clsSession.PropertyID;
            Rm.IsActive = true;
            List<RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((RoomType rm1, RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));
                ddlUnitTypeName.DataSource = LstRm;
                ddlUnitTypeName.DataTextField = "RoomTypeName";
                ddlUnitTypeName.DataValueField = "RoomTypeID";
                ddlUnitTypeName.DataBind();
                ddlUnitTypeName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlUnitTypeName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind Wing
        /// </summary>
        private void BindWing()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            Wing objLoadWing = new Wing();
            objLoadWing.IsActive = true;
            objLoadWing.PropertyID = clsSession.PropertyID;
            List<Wing> LstWin = WingBLL.GetAll(objLoadWing);
            if (LstWin.Count > 0)
            {
                LstWin.Sort((Wing win1, Wing win2) => win1.WingName.CompareTo(win2.WingName));
                ddlWing.DataSource = LstWin;
                ddlWing.DataTextField = "WingName";
                ddlWing.DataValueField = "WingID";
                ddlWing.DataBind();
                ddlWing.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlWing.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind Floor
        /// </summary>
        private void BindFloor()
        {
            ddlFloor.Items.Clear();
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            DataSet Dst = WingFloorJoinBLL.GetAllWithName(new Guid(ddlWing.SelectedValue), null);
            DataView Lstflr = new DataView(Dst.Tables[0]);
            if (Lstflr.Count > 0)
            {
                Lstflr.Sort = "FloorName Asc";
                ddlFloor.DataSource = Lstflr;
                ddlFloor.DataTextField = "FloorName";
                ddlFloor.DataValueField = "FloorID";
                ddlFloor.DataBind();
                ddlFloor.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlFloor.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load RoomType Amenities
        /// </summary>
        private void BindRoomTypeAmenities()
        {
            chkAmenitiesList.Items.Clear();

            string AmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in (select TermID from mst_ProjectTerm where Term in ('Both','Unit') and IsActive = 1 and PropertyID = '" + clsSession.PropertyID + "' and CompanyID = '" + clsSession.CompanyID + "') And PropertyID='" + clsSession.PropertyID + "' And IsActive = 1 order by AmenitiesName Asc";
            DataSet ds = AmenitiesBLL.GetAmenities(AmenitiesQuery);
            if (ds.Tables[0].Rows.Count != 0)
            {
                trAmenities.Visible = trAmenitiesHeader.Visible = true;
                chkAmenitiesList.DataSource = ds.Tables[0];
                chkAmenitiesList.DataTextField = "AmenitiesName";
                chkAmenitiesList.DataValueField = "AmenitiesID";
                chkAmenitiesList.DataBind();
            }
            else
                trAmenities.Visible = trAmenitiesHeader.Visible = false;

            //chkAmenitiesList.Items.Clear();
            //string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            //DataSet dsRTA = RoomTypeAmenitiesBLL.GetAmenitiesByRoomTypeID(new Guid(ddlUnitTypeName.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
            //if (dsRTA.Tables[0].Rows.Count != 0)
            //{
            //    trAmenities.Visible = trAmenitiesHeader.Visible = true;
            //    chkAmenitiesList.DataSource = dsRTA.Tables[0];
            //    chkAmenitiesList.DataTextField = "AmenitiesName";
            //    chkAmenitiesList.DataValueField = "AmenitiesID";
            //    chkAmenitiesList.DataBind();
            //}
            //else
            //{
            //    trAmenities.Visible = trAmenitiesHeader.Visible = false;
            //}
        }

        /// <summary>
        /// Bind Room Data
        /// </summary>
        private void BindRoomData()
        {
            try
            {
                if (clsSession.ToEditItemType == "ROOM" && clsSession.ToEditItemID != Guid.Empty)
                {
                    //tpGallary.Visible = true;
                    Room objLoadRoomData = new Room();
                    objLoadRoomData = RoomBLL.GetByPrimaryKey(this.RoomID);
                    if (objLoadRoomData != null)
                    {
                        ddlUnitTypeName.SelectedIndex = ddlUnitTypeName.Items.FindByValue(Convert.ToString(objLoadRoomData.RoomTypeID)) != null ? ddlUnitTypeName.Items.IndexOf(ddlUnitTypeName.Items.FindByValue(Convert.ToString(objLoadRoomData.RoomTypeID))) : 0;
                        ddlWing.SelectedIndex = ddlWing.Items.FindByValue(Convert.ToString(objLoadRoomData.WingID)) != null ? ddlWing.Items.IndexOf(ddlWing.Items.FindByValue(Convert.ToString(objLoadRoomData.WingID))) : 0;
                        BindFloor();
                        ddlFloor.SelectedIndex = ddlFloor.Items.FindByValue(Convert.ToString(objLoadRoomData.FloorID)) != null ? ddlFloor.Items.IndexOf(ddlFloor.Items.FindByValue(Convert.ToString(objLoadRoomData.FloorID))) : 0;

                        if (objLoadRoomData.RoomNo != null && Convert.ToString(objLoadRoomData.RoomNo) != "")
                        {
                            string strroom = Convert.ToString(objLoadRoomData.RoomNo);
                            string[] word = strroom.Split('|');

                            if (word.Length > 0)
                                txtUnitNo.Text = Convert.ToString(word[0]);
                            else
                                txtUnitNo.Text = Convert.ToString(objLoadRoomData.RoomNo);
                        }
                        else
                            txtUnitNo.Text = "";

                        //txtUnitNo.Text = Convert.ToString(objLoadRoomData.RoomNo);

                        txtKeyNo.Text = Convert.ToString(objLoadRoomData.KeyNo);
                        txtExtNo.Text = Convert.ToString(objLoadRoomData.ExtentionNo);
                        txtNoOfBed.Text = Convert.ToString(objLoadRoomData.NoOfBeds);

                        if (Convert.ToString(objLoadRoomData.NoOfAdults) != "")
                            txtAdult.Text = Convert.ToString(objLoadRoomData.NoOfAdults);
                        if (Convert.ToString(objLoadRoomData.NoOfChilds) != "")
                            txtChild.Text = Convert.ToString(objLoadRoomData.NoOfChilds);
                        if (Convert.ToString(objLoadRoomData.MinimumStay) != "")
                            txtMin.Text = Convert.ToString(objLoadRoomData.MinimumStay);
                        if (Convert.ToString(objLoadRoomData.MaximumStay) != "")
                            txtMax.Text = Convert.ToString(objLoadRoomData.MaximumStay);

                        chkIsavailableCRS.Checked = Convert.ToBoolean(objLoadRoomData.IsAvailableOnIRS);
                        chkIsBlockForBooking.Checked = Convert.ToBoolean(objLoadRoomData.IsBlocked);
                        chkIsDiscountApplicable.Checked = Convert.ToBoolean(objLoadRoomData.IsDiscountApplicable);

                        if (objLoadRoomData.IsSmokingAllowed != null && Convert.ToString(objLoadRoomData.IsSmokingAllowed) != "")
                            chkIsSmokingAllowed.Checked = Convert.ToBoolean(objLoadRoomData.IsSmokingAllowed);
                        else
                            chkIsSmokingAllowed.Checked = false;

                        if (objLoadRoomData.IsExtraBedAllow != null && Convert.ToString(objLoadRoomData.IsExtraBedAllow) != "")
                        {
                            if (objLoadRoomData.IsExtraBedAllow == true)
                            {
                                chkExtraBedAllowed.Checked = true;
                                txtExtraBed.Enabled = true;

                                if (objLoadRoomData.NoOfExtraBed != null && Convert.ToString(objLoadRoomData.NoOfExtraBed) != "")
                                {
                                    txtExtraBed.Text = Convert.ToString(objLoadRoomData.NoOfExtraBed);
                                }
                                else
                                    txtExtraBed.Text = "";
                            }
                            else
                            {
                                chkExtraBedAllowed.Checked = false;
                                txtExtraBed.Text = "";
                                txtExtraBed.Enabled = false;
                            }
                        }
                        else
                        {
                            chkExtraBedAllowed.Checked = false;
                            txtExtraBed.Text = "";
                            txtExtraBed.Enabled = false;
                        }

                        BindRoomTypeAmenities();
                        DataSet dsRoomAmenities = new DataSet();
                        RoomAmenities objLoadRoomAmenities = new RoomAmenities();
                        objLoadRoomAmenities.RoomID = objLoadRoomData.RoomID;
                        dsRoomAmenities = RoomAmenitiesBLL.GetAllWithDataSet(objLoadRoomAmenities);

                        if (dsRoomAmenities.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                            {
                                DataRow[] rows = dsRoomAmenities.Tables[0].Select("AmenitiesID = '" + chkAmenitiesList.Items[i].Value.ToString() + "'");
                                if (rows.Length > 0)
                                    chkAmenitiesList.Items[i].Selected = true;
                            }
                        }

                        BindRoomPhoto();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Room Photo Method
        /// </summary>
        private void BindRoomPhoto()
        {
            try
            {
                List<Documents> lstLoadDocument = null;
                Documents objLoadDocuments = new Documents();
                objLoadDocuments.AssociationID = this.RoomID;
                objLoadDocuments.CompanyID = clsSession.CompanyID;
                objLoadDocuments.PropertyID = clsSession.PropertyID;

                lstLoadDocument = DocumentsBLL.GetAll(objLoadDocuments);

                if (lstLoadDocument.Count != 0)
                {
                    dtlstRoomGallary.DataSource = lstLoadDocument;
                    dtlstRoomGallary.DataBind();
                }
                else
                {
                    dtlstRoomGallary.DataSource = null;
                    dtlstRoomGallary.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Get Image Method
        /// </summary>
        /// <param name="strval"></param>
        /// <returns></returns>
        public string GetImage(object strval)
        {
            string str = "~/Upload/CompanyDocuments/" + clsSession.HotelCode.ToString() + "/Room/" + Convert.ToString(this.RoomID) + "/" + Convert.ToString(strval);
            string mappath = Server.MapPath(str);
            FileInfo f = new FileInfo(mappath);
            if (f.Exists)
                return str;
            else
                return "~/images/BlankPhoto.jpg";
        }
        #endregion Private Method

        #region Control Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    //Room IsDupRoom = new Room();
                    //IsDupRoom.RoomNo = txtUnitNo.Text.Trim();
                    //IsDupRoom.IsActive = true;
                    //IsDupRoom.PropertyID = clsSession.PropertyID;

                    string strRoomNo = txtUnitNo.Text.Trim() + "|";
                    DataSet dsDupRoom = RoomBLL.RoomCheckDuplicateRoom(clsSession.PropertyID, strRoomNo);

                    if (dsDupRoom.Tables.Count > 0 && dsDupRoom.Tables[0].Rows.Count > 0)
                    {
                        if (this.RoomID != Guid.Empty)
                        {
                            if (Convert.ToString((dsDupRoom.Tables[0].Rows[0]["RoomID"])) != Convert.ToString(this.RoomID))
                            {
                                IsListMessage = true;
                                ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }

                    //List<Room> LstDupRoom = RoomBLL.GetAll(IsDupRoom);
                    //if (LstDupRoom.Count > 0)
                    //{
                    //    if (this.RoomID != Guid.Empty)
                    //    {
                    //        if (Convert.ToString((LstDupRoom[0].RoomID)) != Convert.ToString(this.RoomID))
                    //        {
                    //            IsListMessage = true;
                    //            ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        IsListMessage = true;
                    //        ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    //        return;
                    //    }
                    //}

                    ////DataSet dsDuplicateExtNo = RoomBLL.RoomAndConferenceSelectExtensionNO(clsSession.PropertyID, txtExtNo.Text.Trim());
                    ////if (dsDuplicateExtNo.Tables[0] != null && dsDuplicateExtNo.Tables[0].Rows.Count > 0)
                    ////{
                    ////    if (this.RoomID != Guid.Empty)
                    ////    {
                    ////        if (Convert.ToString((dsDuplicateExtNo.Tables[0].Rows[0]["RoomID"])) != Convert.ToString(this.RoomID))
                    ////        {
                    ////            IsListMessage = true;
                    ////            ltrListMessageBI.Text = "Recored with same Ext. No. Already Exist.";
                    ////            return;
                    ////        }
                    ////    }
                    ////    else
                    ////    {
                    ////        IsListMessage = true;
                    ////        ltrListMessageBI.Text = "Recored with same Ext. No. Already Exist.";
                    ////        return;
                    ////    }
                    ////}

                    List<RoomAmenities> lstRoomAmenities = new List<RoomAmenities>();
                    if (this.RoomID != Guid.Empty)
                    {
                        //Update Data
                        Room objOldData = new Room();
                        Room objToUpdate = new Room();
                        objOldData = RoomBLL.GetByPrimaryKey(this.RoomID);
                        objToUpdate = RoomBLL.GetByPrimaryKey(this.RoomID);

                        objToUpdate.RoomTypeID = new Guid(ddlUnitTypeName.SelectedValue.ToString());
                        objToUpdate.WingID = new Guid(ddlWing.SelectedValue.ToString());
                        objToUpdate.FloorID = new Guid(ddlFloor.SelectedValue.ToString());
                        objToUpdate.RoomNo = txtUnitNo.Text.Trim();
                        objToUpdate.KeyNo = txtKeyNo.Text.Trim();
                        objToUpdate.ExtentionNo = txtExtNo.Text.Trim();
                        if (txtNoOfBed.Text.Trim() != "")
                            objToUpdate.NoOfBeds = Convert.ToInt32(txtNoOfBed.Text.Trim());
                        else
                            objToUpdate.NoOfBeds = null;
                        objToUpdate.IsAvailableOnIRS = Convert.ToBoolean(chkIsavailableCRS.Checked);
                        objToUpdate.IsDiscountApplicable = Convert.ToBoolean(chkIsDiscountApplicable.Checked);
                        objToUpdate.IsBlocked = Convert.ToBoolean(chkIsBlockForBooking.Checked);
                        if (txtAdult.Text.Trim() != "")
                            objToUpdate.NoOfAdults = Convert.ToInt32(txtAdult.Text.Trim());
                        else
                            objToUpdate.NoOfAdults = null;
                        if (txtChild.Text.Trim() != "")
                            objToUpdate.NoOfChilds = Convert.ToInt32(txtChild.Text.Trim());
                        else
                            objToUpdate.NoOfChilds = null;
                        if (txtMin.Text.Trim() != "")
                            objToUpdate.MinimumStay = Convert.ToInt32(txtMin.Text.Trim());
                        else
                            objToUpdate.MinimumStay = null;
                        if (txtMax.Text.Trim() != "")
                            objToUpdate.MaximumStay = Convert.ToInt32(txtMax.Text.Trim());
                        else
                            objToUpdate.MaximumStay = null;

                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.IsSmokingAllowed = Convert.ToBoolean(chkIsSmokingAllowed.Checked);

                        objToUpdate.IsExtraBedAllow = Convert.ToBoolean(chkExtraBedAllowed.Checked);
                        if (chkExtraBedAllowed.Checked)
                        {
                            if (txtExtraBed.Text.Trim() != "")
                                objToUpdate.NoOfExtraBed = Convert.ToInt32(txtExtraBed.Text.Trim());
                            else
                                objToUpdate.NoOfExtraBed = null;
                        }
                        else
                            objToUpdate.NoOfExtraBed = null;

                        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                        {
                            if (chkAmenitiesList.Items[i].Selected)
                            {
                                RoomAmenities objTemp = new RoomAmenities();
                                objTemp.AmenitiesID = new Guid(chkAmenitiesList.Items[i].Value.ToString());
                                lstRoomAmenities.Add(objTemp);
                            }
                        }

                        RoomBLL.Update(objToUpdate, lstRoomAmenities);
                        this.RoomID = objToUpdate.RoomID;
                        hdnRoomID.Value = Convert.ToString(this.RoomID);
                        //tpGallary.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                        ActionLogBLL.SaveConfigurationActionLog(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldData.ToString(), objToUpdate.ToString(), "mst_Room");
                        IsListMessage = true;
                        ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        //Insert Data
                        Room objToInsert = new Room();

                        objToInsert.RoomID = Guid.NewGuid();
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.RoomTypeID = new Guid(ddlUnitTypeName.SelectedValue.ToString());
                        objToInsert.WingID = new Guid(ddlWing.SelectedValue.ToString());
                        objToInsert.FloorID = new Guid(ddlFloor.SelectedValue.ToString());
                        objToInsert.RoomNo = txtUnitNo.Text.Trim();
                        objToInsert.KeyNo = txtKeyNo.Text.Trim();
                        objToInsert.ExtentionNo = txtExtNo.Text.Trim();
                        if (txtNoOfBed.Text.Trim() != "")
                            objToInsert.NoOfBeds = Convert.ToInt32(txtNoOfBed.Text.Trim());
                        objToInsert.IsAvailableOnIRS = Convert.ToBoolean(chkIsavailableCRS.Checked);
                        objToInsert.IsDiscountApplicable = Convert.ToBoolean(chkIsDiscountApplicable.Checked);
                        objToInsert.IsBlocked = Convert.ToBoolean(chkIsBlockForBooking.Checked);
                        if (txtAdult.Text.Trim() != "")
                            objToInsert.NoOfAdults = Convert.ToInt32(txtAdult.Text.Trim());
                        if (txtChild.Text.Trim() != "")
                            objToInsert.NoOfChilds = Convert.ToInt32(txtChild.Text.Trim());
                        if (txtMin.Text.Trim() != "")
                            objToInsert.MinimumStay = Convert.ToInt32(txtMin.Text.Trim());
                        if (txtMax.Text.Trim() != "")
                            objToInsert.MaximumStay = Convert.ToInt32(txtMax.Text.Trim());
                        objToInsert.IsActive = true;
                        objToInsert.IsSynch = false;
                        objToInsert.CreatedOn = DateTime.Now;
                        objToInsert.CreatedBy = clsSession.UserID;
                        objToInsert.IsSmokingAllowed = Convert.ToBoolean(chkIsSmokingAllowed.Checked);

                        objToInsert.IsExtraBedAllow = Convert.ToBoolean(chkExtraBedAllowed.Checked);

                        if (chkExtraBedAllowed.Checked)
                        {
                            if (txtExtraBed.Text.Trim() != "")
                                objToInsert.NoOfExtraBed = Convert.ToInt32(txtExtraBed.Text.Trim());
                        }

                        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                        {
                            if (chkAmenitiesList.Items[i].Selected)
                            {
                                RoomAmenities objTemp = new RoomAmenities();
                                objTemp.AmenitiesID = new Guid(chkAmenitiesList.Items[i].Value.ToString());
                                lstRoomAmenities.Add(objTemp);
                            }
                        }

                        RoomBLL.RoomSaveWithID(objToInsert, lstRoomAmenities);
                        this.RoomID = objToInsert.RoomID;
                        hdnRoomID.Value = Convert.ToString(this.RoomID);
                        //tpGallary.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_Room");
                        IsListMessage = true;
                        ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }

                    btnSave.Visible = trPhoto.Visible = this.UserRights.Substring(2, 1) == "1";

                    if (chkExtraBedAllowed.Checked)
                    {
                        txtExtraBed.Enabled = true;
                    }
                    else
                    {
                        txtExtraBed.Enabled = false;
                    }

                    BindBreadCrumb();
                    UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                    uPnlBreadCrumb.Update();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = string.Empty;
            Response.Redirect("~/GUI/Configurations/Room.aspx");
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = string.Empty;
            Response.Redirect("~/GUI/Configurations/RoomList.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                List<SQT.Symphony.BusinessLogic.IRMS.DTO.Documents> lstDocuments = new List<SQT.Symphony.BusinessLogic.IRMS.DTO.Documents>();
                HttpFileCollection hfc = Request.Files;
                bool flag = false;

                if (hfc.Count > 0)
                {
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        HttpPostedFile hpf = hfc[i];
                        if (hpf.ContentLength > 0)
                        {
                            lblSelectFileForRG.Text = "";
                            string strExtension = System.IO.Path.GetExtension(hpf.FileName);

                            if (strExtension.ToUpper() == ".JPG" || strExtension.ToUpper() == ".JPEG" || strExtension.ToUpper() == ".BMP" || strExtension.ToUpper() == ".PNG" || strExtension.ToUpper() == ".GIF")
                            {
                                //hpf.SaveAs(Server.MapPath("MyFiles") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                                //Path to create directory for document and logo based on company.
                                flag = true;

                                string strCompDocsDirPath = Server.MapPath("~/Upload/CompanyDocuments");
                                string strHotelCodeWithPath = strCompDocsDirPath + "/" + clsSession.HotelCode.ToString();
                                string strRoomWithPath = strHotelCodeWithPath + "/" + "/Room";
                                string strRoomNoWithPath = strRoomWithPath + "/" + Convert.ToString(this.RoomID);

                                if (!Directory.Exists(strCompDocsDirPath))
                                    Directory.CreateDirectory(strCompDocsDirPath);

                                if (!Directory.Exists(strHotelCodeWithPath))
                                    Directory.CreateDirectory(strHotelCodeWithPath);

                                if (!Directory.Exists(strRoomWithPath))
                                    Directory.CreateDirectory(strRoomWithPath);

                                if (!Directory.Exists(strRoomNoWithPath))
                                    Directory.CreateDirectory(strRoomNoWithPath);

                                SQT.Symphony.BusinessLogic.IRMS.DTO.Documents objDocuments = new BusinessLogic.IRMS.DTO.Documents();
                                string strImage = Guid.NewGuid().ToString() + "$" + hpf.FileName.Replace(" ", "_");
                                string strImagePath = strRoomNoWithPath + "/" + strImage;

                                hpf.SaveAs(strImagePath);
                                objDocuments.DocumentName = strImage;
                                objDocuments.Extension = strExtension.Replace(".", "");
                                objDocuments.DateOfSubmission = DateTime.Now;
                                objDocuments.CreatedOn = DateTime.Now;
                                objDocuments.IsActive = true;
                                objDocuments.AssociationType = "Room";
                                objDocuments.CreatedBy = clsSession.UserID;
                                objDocuments.AssociationID = this.RoomID;
                                objDocuments.CompanyID = clsSession.CompanyID;
                                objDocuments.PropertyID = clsSession.PropertyID;

                                lstDocuments.Add(objDocuments);
                            }
                        }
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
                }
                else
                {
                    lblSelectFileForRG.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgUploadPhoto", "Please Select Photo");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
                    return;
                }

                if (flag == true)
                {
                    RoomBLL.SaveRoomPhoto(lstDocuments);
                    //tpBasicInfo.Visible = true;
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", lstDocuments.ToString(), lstDocuments.ToString(), "dms_Documents");
                    IsListMessageForGallary = true;
                    litMsgForGallary.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
                BindRoomPhoto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region DropDown Event
        protected void ddlUnitTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitTypeName.SelectedValue != Guid.Empty.ToString())
                {

                    BindRoomTypeAmenities();

                    RoomTypeAmenities objRoomTypeAmenities = new RoomTypeAmenities();
                    objRoomTypeAmenities.RoomTypeID = new Guid(ddlUnitTypeName.SelectedValue);

                    DataSet dsRoomTypeAmenities = RoomTypeAmenitiesBLL.GetAllWithDataSet(objRoomTypeAmenities);

                    if (dsRoomTypeAmenities.Tables.Count > 0 && dsRoomTypeAmenities.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                        {
                            DataRow[] rows = dsRoomTypeAmenities.Tables[0].Select("AmenitiesID = '" + chkAmenitiesList.Items[i].Value.ToString() + "'");
                            if (rows.Length > 0)
                                chkAmenitiesList.Items[i].Selected = true;
                            else
                                chkAmenitiesList.Items[i].Selected = false;
                        }
                    }

                    RoomType objRoomType = new RoomType();
                    objRoomType = RoomTypeBLL.GetByPrimaryKey(new Guid(ddlUnitTypeName.SelectedValue));
                    if (objRoomType != null)
                    {
                        txtNoOfBed.Text = Convert.ToString(objRoomType.NoOfBeds);

                        if (objRoomType.MaximumAdults != null && Convert.ToString(objRoomType.MaximumAdults) != "")
                            txtAdult.Text = Convert.ToString(objRoomType.MaximumAdults);
                        else
                            txtAdult.Text = "";

                        if (objRoomType.MaximumChilds != null && Convert.ToString(objRoomType.MaximumChilds) != "")
                            txtChild.Text = Convert.ToString(objRoomType.MaximumChilds);
                        else
                            txtChild.Text = "";


                        if (objRoomType.IsExtraBedAllow != null && Convert.ToString(objRoomType.IsExtraBedAllow) != "")
                        {
                            if (objRoomType.IsExtraBedAllow == true)
                            {
                                chkExtraBedAllowed.Checked = true;
                                txtExtraBed.Enabled = true;

                                if (objRoomType.NoOfExtraBed != null && Convert.ToString(objRoomType.NoOfExtraBed) != "")
                                {
                                    txtExtraBed.Text = Convert.ToString(objRoomType.NoOfExtraBed);
                                }
                                else
                                    txtExtraBed.Text = "";
                            }
                            else
                            {
                                chkExtraBedAllowed.Checked = false;
                                txtExtraBed.Text = "";
                                txtExtraBed.Enabled = false;
                            }
                        }
                        else
                        {
                            chkExtraBedAllowed.Checked = false;
                            txtExtraBed.Text = "";
                            txtExtraBed.Enabled = false;
                        }

                    }
                    else
                    {
                        txtNoOfBed.Text = "";
                        chkExtraBedAllowed.Checked = false;
                        txtExtraBed.Text = "";
                        txtExtraBed.Enabled = false;
                        txtChild.Text = txtAdult.Text = "";
                    }

                    ////Guid? RoomTypeID;
                    ////Guid? RoomID;
                    ////RoomTypeID = new Guid(ddlUnitTypeName.SelectedValue);

                    ////DataSet dsRoom = new DataSet();
                    ////dsRoom = RoomBLL.RoomSearchData(clsSession.PropertyID, RoomTypeID, null, null, null);
                    ////if (dsRoom.Tables[0].Rows.Count != 0)
                    ////{
                    ////    RoomID = new Guid(dsRoom.Tables[0].Rows[0][0].ToString());
                    ////    BindRoomTypeAmenities();
                    ////    DataSet dsRoomAmenities = new DataSet();
                    ////    RoomAmenities objLoadRoomAmenities = new RoomAmenities();
                    ////    objLoadRoomAmenities.RoomID = RoomID;
                    ////    dsRoomAmenities = RoomAmenitiesBLL.GetAllWithDataSet(objLoadRoomAmenities);

                    ////    if (dsRoomAmenities.Tables[0].Rows.Count != 0)
                    ////    {
                    ////        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                    ////        {
                    ////            DataRow[] rows = dsRoomAmenities.Tables[0].Select("AmenitiesID = '" + chkAmenitiesList.Items[i].Value.ToString() + "'");
                    ////            if (rows.Length > 0)
                    ////                chkAmenitiesList.Items[i].Selected = true;
                    ////        }
                    ////        trAmenities.Visible = trAmenitiesHeader.Visible = true;
                    ////    }
                    ////}
                    ////else
                    ////{
                    ////    BindRoomTypeAmenities();
                    ////    DataSet dsRoomTypeAmenities = new DataSet();
                    ////    RoomTypeAmenities objLoadRoomTypeAmenities = new RoomTypeAmenities();
                    ////    objLoadRoomTypeAmenities.RoomTypeID = RoomTypeID;
                    ////    dsRoomTypeAmenities = RoomTypeAmenitiesBLL.GetAllWithDataSet(objLoadRoomTypeAmenities);

                    ////    if (dsRoomTypeAmenities.Tables[0].Rows.Count != 0)
                    ////    {
                    ////        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                    ////        {
                    ////            DataRow[] rows = dsRoomTypeAmenities.Tables[0].Select("AmenitiesID = '" + chkAmenitiesList.Items[i].Value.ToString() + "'");
                    ////            if (rows.Length > 0)
                    ////                chkAmenitiesList.Items[i].Selected = true;
                    ////        }
                    ////        trAmenities.Visible = trAmenitiesHeader.Visible = true;
                    ////    }
                    ////}
                }
                else
                {
                    trAmenities.Visible = trAmenitiesHeader.Visible = false;
                    txtNoOfBed.Text = "";
                    chkExtraBedAllowed.Checked = false;
                    txtExtraBed.Text = "";
                    txtExtraBed.Enabled = false;
                    txtChild.Text = txtAdult.Text = "";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void ddlWing_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlWing.SelectedValue != Guid.Empty.ToString())
                {
                    BindFloor();
                }
                else
                {
                    ddlFloor.Items.Clear();
                    ddlFloor.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion DropDown Event

        #region Grid Event

        protected void dtlstRoomGallary_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("DELETEPHOTO"))
                {
                    lblSelectFileForRG.Text = "";
                    Documents objDelete = DocumentsBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    DocumentsBLL.Delete(objDelete);
                    string strPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode.ToString() + "/Room/" + Convert.ToString(this.RoomID) + "/" + Convert.ToString(dtlstRoomGallary.DataKeys[e.Item.ItemIndex]));

                    if (File.Exists(strPath))
                        File.Delete(strPath);

                    DocumentsBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "dms_Documents");
                    IsListMessageForGallary = true;
                    litMsgForGallary.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    BindRoomPhoto();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void dtlstRoomGallary_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lnkRommGallaryDelete = (LinkButton)e.Item.FindControl("lnkRommGallaryDelete");
                lnkRommGallaryDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                lnkRommGallaryDelete.Visible = this.UserRights.Substring(3, 1) == "1";
            }
        }

        protected void lnkRommGallaryDelete_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            ScriptManager sm = (ScriptManager)Page.Master.FindControl("scptInnerHTML");
            sm.RegisterPostBackControl(lb);
        }

        #endregion GridEvent

        protected void chkExtraBedAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtraBedAllowed.Checked)
            {
                txtExtraBed.Enabled = true;
            }
            else
            {
                txtExtraBed.Enabled = false;
                txtExtraBed.Text = "";
            }
        }
    }
}