using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlRoomType : System.Web.UI.UserControl
    {
        #region Property and Variable

        public bool IsListMessageForBI = false;
        public bool IsListMessageForGallary = false;

        public Guid RoomTypeID
        {
            get
            {
                return ViewState["RoomTypeID"] != null ? new Guid(Convert.ToString(ViewState["RoomTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomTypeID"] = value;
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
        #endregion

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
                if (clsSession.ToEditItemType == "ROOMTYPE" && clsSession.ToEditItemID != Guid.Empty)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                    btnSave.Visible = trPhoto.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.RoomTypeID = clsSession.ToEditItemID;
                    BindRoomTypeData();
                }

                BindBreadCrumb();
            }

        }
        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITTYPESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("RoomType", "lblMainHeader", "ROOM TYPE");
            lbltpUnitTypeName.Text = clsCommon.GetGlobalResourceText("RoomType", "lbltpUnitTypeName", "Room Type");
            lbltpUnitTypeCode.Text = clsCommon.GetGlobalResourceText("RoomType", "lbltpUnitTypeCode", "Code");
            lblAmenitiesList.Text = clsCommon.GetGlobalResourceText("RoomType", "lblAmenitiesList", "Amenities");
            litReservationInformation.Text = clsCommon.GetGlobalResourceText("RoomType", "lblReservationInformation", "Reservation Information");
            litRackRate.Text = clsCommon.GetGlobalResourceText("RoomType", "lblRackRate", "Rack Rate");
            litMaxNight.Text = clsCommon.GetGlobalResourceText("RoomType", "lblMaxNight", "Max");
            litMinNight.Text = clsCommon.GetGlobalResourceText("RoomType", "lblMinNight", "Min");
            litCRLimit.Text = clsCommon.GetGlobalResourceText("RoomType", "lblCRLimit", "CR Limit");
            litMaxAdult.Text = clsCommon.GetGlobalResourceText("RoomType", "lblMaxAdult", "Maximum Adult");
            litMaxChild.Text = clsCommon.GetGlobalResourceText("RoomType", "lblMaxChild", "Maximum Child");
            litDeposit.Text = clsCommon.GetGlobalResourceText("RoomType", "lblDeposit", "Deposit");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            chkIsdiscountApplicable.Text = clsCommon.GetGlobalResourceText("RoomType", "lblIsDiscountApplicable", "Is Discount Applicable");
            chkIsavailableCRS.Text = clsCommon.GetGlobalResourceText("RoomType", "lblIsAvaiableonCRS", "Is Avaiable on CRS");
            litNight.Text = clsCommon.GetGlobalResourceText("RoomType", "lblNight", "Night");
            litRoomTypeTabBasicInformation.Text = clsCommon.GetGlobalResourceText("RoomType", "litRoomTypeTabBasicInformation", "Basic Information");
            litRoomTypeTabGallery.Text = clsCommon.GetGlobalResourceText("RoomType", "litRoomTypeTabGallery", "Gallery");
            btnUpload.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnUpload", "Upload All");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");

            litNoOfBeds.Text = clsCommon.GetGlobalResourceText("RoomType", "lblNoOfBeds", "No. of Beds");
            litBedSize.Text = clsCommon.GetGlobalResourceText("RoomType", "lblBedSize", "Bed Size");
            litSBA.Text = clsCommon.GetGlobalResourceText("RoomType", "lblSBA", "SBA(Sft)");
            litCarpetArea.Text = clsCommon.GetGlobalResourceText("RoomType", "lblCarpetArea", "Carpet Area(Sft)");

            revSBA.ErrorMessage = Convert.ToString("2") + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            revCarpetArea.ErrorMessage = Convert.ToString("2") + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            chkExtraBedAllowed.Text = clsCommon.GetGlobalResourceText("RoomType", "lblExtraBedAllowed", "Extra Bed Allow");
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitTypesList", "Room Types List");
            dr3["Link"] = "~/GUI/Configurations/RoomTypeList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = txtUnitTypeName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitTypes", "Room Type") : txtUnitTypeName.Text.Trim();
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
                ClearControl();
                //tpGallary.Visible = false;

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Grid Method
        /// </summary>
        private void BindDepositGrid()
        {
            List<Deposits> lstDeposits = null;
            Deposits objDeposits = new Deposits();
            objDeposits.PropertyID = clsSession.PropertyID;
            objDeposits.CompanyID = clsSession.CompanyID;
            objDeposits.IsActive = true;

            lstDeposits = DepositsBLL.GetAll(objDeposits);
            lstDeposits.Sort((Deposits d1, Deposits d2) => d1.DepositName.CompareTo(d2.DepositName));
            gvDepositList.DataSource = lstDeposits;
            gvDepositList.DataBind();
        }

        /// <summary>
        /// Bind Amenities
        /// </summary>
        private void BindAmenities()
        {
            try
            {

                chkAmenitiesList.Items.Clear();
                //string AmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in ('268105BE-899A-40CA-9718-82448FF38172','9435ED89-A452-4DE4-9D8C-1CF1E9BD7B46') And PropertyID='" + clsSession.PropertyID + "' And IsActive = 1 order by AmenitiesName Asc";
                string AmenitiesQuery = "select AmenitiesID,AmenitiesName from mst_Amenities where AmenitiesTypeTermID in (select TermID from mst_ProjectTerm where Term in ('Both','Unit') and IsActive = 1 and PropertyID = '" + clsSession.PropertyID + "' and CompanyID = '" + clsSession.CompanyID + "') And PropertyID='" + clsSession.PropertyID + "' And IsActive = 1 order by AmenitiesName Asc";
                DataSet ds = AmenitiesBLL.GetAmenities(AmenitiesQuery);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    chkAmenitiesList.DataSource = ds.Tables[0];
                    chkAmenitiesList.DataTextField = "AmenitiesName";
                    chkAmenitiesList.DataValueField = "AmenitiesID";
                    chkAmenitiesList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindOverBookingDDL()
        {
            try
            {
                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

                List<ProjectTerm> lstProjectTerm = null;
                ProjectTerm objProjectTerm = new ProjectTerm();
                objProjectTerm.CompanyID = clsSession.CompanyID;
                objProjectTerm.PropertyID = clsSession.PropertyID;
                objProjectTerm.Category = "PerFlat";
                objProjectTerm.IsActive = true;

                lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);

                if (lstProjectTerm.Count != 0)
                {
                    ddlOverBooking.DataSource = lstProjectTerm;
                    ddlOverBooking.DataTextField = "DisplayTerm";
                    ddlOverBooking.DataValueField = "TermID";
                    ddlOverBooking.DataBind();
                    ddlOverBooking.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlOverBooking.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            BindAmenities();
            BindOverBookingDDL();
            BindDepositGrid();
            BindComplementoryServices();
            txtUnitTypeName.Text = txtUnitTypeCode.Text = txtRackRate.Text = txtMaxNight.Text = txtMinNight.Text = txtCRLimit.Text = txtMaxAdult.Text = txtMaxChild.Text = "";
            chkOverBooking.Checked = chkIsdiscountApplicable.Checked = chkIsavailableCRS.Checked = false;
            ddlOverBooking.Enabled = txtOverBooking.Enabled = false;
            rfvddlOverBooking.Enabled = rfvtxtOverBooking.Enabled = false;
            revOverBooking.ErrorMessage = revCRLimit.ErrorMessage = revRackRate.ErrorMessage = "2 " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            lblOverBooking.Text = clsCommon.GetGlobalResourceText("RoomType", "lblMsgDiscountLimitInPercentage", "% should be less than or equal to 100.");
            cmpRackRate.ErrorMessage = clsCommon.GetGlobalResourceText("RoomType", "lblMsgForRackRataNight", "Min Neight should be less than or equal Max Neight");
        }

        private void BindRoomTypeData()
        {
            try
            {
                if (clsSession.ToEditItemType == "ROOMTYPE" && clsSession.ToEditItemID != Guid.Empty)
                {
                    RoomType objLoadRTData = new RoomType();
                    objLoadRTData = RoomTypeBLL.GetByPrimaryKey(this.RoomTypeID);
                    if (objLoadRTData != null)
                    {
                        //tpGallary.Visible = true;
                        txtUnitTypeName.Text = Convert.ToString(objLoadRTData.RoomTypeName);
                        txtUnitTypeCode.Text = Convert.ToString(objLoadRTData.RoomTypeCode);
                        if (Convert.ToString(objLoadRTData.RackRate) != "")
                            txtRackRate.Text = Convert.ToString(objLoadRTData.RackRate);

                        if (Convert.ToString(objLoadRTData.MinimumStay) != "")
                            txtMinNight.Text = Convert.ToString(objLoadRTData.MinimumStay);

                        if (Convert.ToString(objLoadRTData.MaximumStay) != "")
                            txtMaxNight.Text = Convert.ToString(objLoadRTData.MaximumStay);

                        if (Convert.ToString(objLoadRTData.CreditLimit) != "")
                            txtCRLimit.Text = Convert.ToString(objLoadRTData.CreditLimit);

                        if (Convert.ToString(objLoadRTData.MaximumAdults) != "")
                            txtMaxAdult.Text = Convert.ToString(objLoadRTData.MaximumAdults);

                        if (Convert.ToString(objLoadRTData.MaximumChilds) != "")
                            txtMaxChild.Text = Convert.ToString(objLoadRTData.MaximumChilds);

                        if (Convert.ToBoolean(objLoadRTData.IsOBInPercentage))
                        {
                            chkOverBooking.Checked = true;
                            txtOverBooking.Enabled = ddlOverBooking.Enabled = rfvddlOverBooking.Enabled = rfvtxtOverBooking.Enabled = true;
                            ddlOverBooking.SelectedIndex = ddlOverBooking.Items.FindByValue(Convert.ToString(objLoadRTData.PerFlat_TermID)) != null ? ddlOverBooking.Items.IndexOf(ddlOverBooking.Items.FindByValue(Convert.ToString(objLoadRTData.PerFlat_TermID))) : 0;

                            if (Convert.ToString(objLoadRTData.Overbooking) != "")
                                txtOverBooking.Text = Convert.ToString(objLoadRTData.Overbooking.ToString().Substring(0, objLoadRTData.Overbooking.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                        }

                        chkIsdiscountApplicable.Checked = Convert.ToBoolean(objLoadRTData.IsDiscountApplicable);
                        chkIsavailableCRS.Checked = Convert.ToBoolean(objLoadRTData.IsAvailableOnIRS);


                        if (Convert.ToString(objLoadRTData.NoOfBeds) != "")
                            txtNoOfBeds.Text = Convert.ToString(objLoadRTData.NoOfBeds);

                        if (Convert.ToString(objLoadRTData.SBArea) != "")
                            txtSBA.Text = Convert.ToString(objLoadRTData.SBArea);

                        if (Convert.ToString(objLoadRTData.CarpetArea) != "")
                            txtCarpetArea.Text = Convert.ToString(objLoadRTData.CarpetArea);

                        txtBedSize.Text = Convert.ToString(objLoadRTData.BedSize);

                        if (objLoadRTData.IsExtraBedAllow != null && Convert.ToString(objLoadRTData.IsExtraBedAllow) != "")
                        {
                            if (objLoadRTData.IsExtraBedAllow == true)
                            {
                                chkExtraBedAllowed.Checked = true;
                                txtExtraBed.Enabled = true;

                                if (objLoadRTData.NoOfExtraBed != null && Convert.ToString(objLoadRTData.NoOfExtraBed) != "")
                                {
                                    txtExtraBed.Text = Convert.ToString(objLoadRTData.NoOfExtraBed);
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

                        BindAmenities();
                        DataSet dsRoomTypeAmenities = new DataSet();
                        RoomTypeAmenities objLoadRoomTypeAmenities = new RoomTypeAmenities();
                        objLoadRoomTypeAmenities.RoomTypeID = objLoadRTData.RoomTypeID;
                        dsRoomTypeAmenities = RoomTypeAmenitiesBLL.GetAllWithDataSet(objLoadRoomTypeAmenities);

                        if (dsRoomTypeAmenities.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                            {
                                DataRow[] rows = dsRoomTypeAmenities.Tables[0].Select("AmenitiesID = '" + chkAmenitiesList.Items[i].Value.ToString() + "'");
                                if (rows.Length > 0)
                                    chkAmenitiesList.Items[i].Selected = true;
                            }
                        }

                        BindComplementoryServices();
                        DataSet dsRoomTypeServices = new DataSet();
                        RoomTypeServices objLoadRoomTypeServices = new RoomTypeServices();
                        objLoadRoomTypeServices.RoomTypeID = objLoadRTData.RoomTypeID;
                        dsRoomTypeServices = RoomTypeServicesBLL.GetAllWithDataSet(objLoadRoomTypeServices);

                        if (dsRoomTypeServices.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < chkComplementoryServices.Items.Count; i++)
                            {
                                DataRow[] rows = dsRoomTypeServices.Tables[0].Select("ItemID = '" + chkComplementoryServices.Items[i].Value.ToString() + "'");
                                if (rows.Length > 0)
                                    chkComplementoryServices.Items[i].Selected = true;
                            }
                        }

                        BindDepositGrid();
                        DataSet dsRTDeposit = new DataSet();
                        RoomTypeDeposit objLoadRoomTypeDeposit = new RoomTypeDeposit();
                        objLoadRoomTypeDeposit.RoomTypeID = objLoadRTData.RoomTypeID;
                        dsRTDeposit = RoomTypeDepositBLL.GetAllWithDataSet(objLoadRoomTypeDeposit);

                        if (dsRTDeposit.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < gvDepositList.Rows.Count; i++)
                            {
                                GridViewRow row = gvDepositList.Rows[i];
                                DataRow[] rows = dsRTDeposit.Tables[0].Select("DepositID = '" + gvDepositList.DataKeys[i]["DepositID"].ToString() + "'");
                                if (rows.Length > 0)
                                {
                                    ((CheckBox)row.FindControl("chkDepositList")).Checked = true;
                                }
                            }
                        }
                        BindRoomTypePhoto();
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
        private void BindRoomTypePhoto()
        {
            try
            {
                List<Documents> lstLoadDocument = null;
                Documents objLoadDocuments = new Documents();
                objLoadDocuments.AssociationID = this.RoomTypeID;
                objLoadDocuments.CompanyID = clsSession.CompanyID;
                objLoadDocuments.PropertyID = clsSession.PropertyID;

                lstLoadDocument = DocumentsBLL.GetAll(objLoadDocuments);

                if (lstLoadDocument.Count != 0)
                {
                    dtlstRoomTypeGallary.DataSource = lstLoadDocument;
                    dtlstRoomTypeGallary.DataBind();
                }
                else
                {
                    dtlstRoomTypeGallary.DataSource = null;
                    dtlstRoomTypeGallary.DataBind();
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
            string str = "~/Upload/CompanyDocuments/" + clsSession.HotelCode.ToString() + "/RoomType/" + Convert.ToString(this.RoomTypeID) + "/" + Convert.ToString(strval);
            string mappath = Server.MapPath(str);
            FileInfo f = new FileInfo(mappath);
            if (f.Exists)
                return str;
            else
                return "~/images/BlankPhoto.jpg";
        }

        private void BindComplementoryServices()
        {
            try
            {
                chkComplementoryServices.Items.Clear();

                //List<Item> lisServices = ItemBLL.GetAllBy(Item.ItemFields.IsRoomService, "1");

                Item objService = new Item();

                objService.CompanyID = clsSession.CompanyID;
                objService.PropertyID = clsSession.PropertyID;
                objService.IsRoomService = true;

                List<Item> lisServices = ItemBLL.GetAll(objService);

                if (lisServices.Count != 0)
                {
                    chkComplementoryServices.DataSource = lisServices;
                    chkComplementoryServices.DataTextField = "ItemName";
                    chkComplementoryServices.DataValueField = "ItemID";
                    chkComplementoryServices.DataBind();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Grid Event
        protected void gvDepositList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvDepositRate = (Label)e.Row.FindControl("lblGvDepositRate");
                    if (lblGvDepositRate != null)
                        lblGvDepositRate.Text = lblGvDepositRate.Text.Substring(0, lblGvDepositRate.Text.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrDeposit")).Text = clsCommon.GetGlobalResourceText("RoomType", "lblGvHdrDeposit", "Deposit");
                    ((Label)e.Row.FindControl("lblGvHdrRate")).Text = clsCommon.GetGlobalResourceText("RoomType", "lblGvHdrRate", "lblGvHdrRate");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void dtlstRoomTypeGallary_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("DELETEPHOTO"))
                {
                    lblSelectFileForRG.Text = "";
                    Documents objDelete = DocumentsBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    DocumentsBLL.Delete(objDelete);
                    string strPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode.ToString() + "/RoomType/" + Convert.ToString(this.RoomTypeID) + "/" + Convert.ToString(dtlstRoomTypeGallary.DataKeys[e.Item.ItemIndex]));

                    if (File.Exists(strPath))
                        File.Delete(strPath);

                    DocumentsBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "dms_Documents");
                    IsListMessageForGallary = true;
                    ltrListMessageGallary.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");

                    //Response.Redirect("~/GUI/Configurations/RoomType.aspx");
                    BindRoomTypePhoto();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void dtlstRoomTypeGallary_ItemDataBound(object sender, DataListItemEventArgs e)
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

            //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);

            sm.RegisterPostBackControl(lb);
            //sm.RegisterPostBackControl(lb);
        }
        #endregion Grid Event

        #region Control Event

        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemType = "";
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/Configurations/RoomType.aspx");
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = string.Empty;
            Response.Redirect("~/GUI/Configurations/RoomTypeList.aspx");
        }

        /// <summary>
        /// Button Save And Update Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    RoomType IsRoomTypeDup = new RoomType();
                    IsRoomTypeDup.RoomTypeName = txtUnitTypeName.Text.Trim();
                    IsRoomTypeDup.PropertyID = clsSession.PropertyID;
                    IsRoomTypeDup.IsActive = true;

                    List<RoomType> LstDupIsRoomTypeDup = RoomTypeBLL.GetAll(IsRoomTypeDup);
                    if (LstDupIsRoomTypeDup.Count > 0)
                    {
                        if (this.RoomTypeID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupIsRoomTypeDup[0].RoomTypeID)) != Convert.ToString(this.RoomTypeID))
                            {
                                IsListMessageForBI = true;
                                ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsListMessageForBI = true;
                            ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }

                    List<RoomTypeAmenities> lstRoomTypeAmenities = new List<RoomTypeAmenities>();
                    List<RoomTypeDeposit> lstRoomTypeDeposit = new List<RoomTypeDeposit>();
                    List<RoomTypeServices> lstRoomTypeServices = new List<RoomTypeServices>();

                    if (this.RoomTypeID != Guid.Empty)
                    {
                        RoomType objToUpdate = new RoomType();
                        RoomType objToUpdateOldRTData = new RoomType();

                        objToUpdate = RoomTypeBLL.GetByPrimaryKey(this.RoomTypeID);
                        objToUpdateOldRTData = RoomTypeBLL.GetByPrimaryKey(this.RoomTypeID);

                        objToUpdate.RoomTypeName = txtUnitTypeName.Text.Trim();
                        objToUpdate.RoomTypeCode = txtUnitTypeCode.Text.Trim();

                        if (txtRackRate.Text.Trim() != "")
                            objToUpdate.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());
                        else
                            objToUpdate.RackRate = null;

                        if (txtMinNight.Text.Trim() != "")
                            objToUpdate.MinimumStay = Convert.ToInt32(txtMinNight.Text.Trim());
                        else
                            objToUpdate.MinimumStay = null;

                        if (txtMaxNight.Text.Trim() != "")
                            objToUpdate.MaximumStay = Convert.ToInt32(txtMaxNight.Text.Trim());
                        else
                            objToUpdate.MaximumStay = null;

                        if (txtCRLimit.Text.Trim() != "")
                            objToUpdate.CreditLimit = Convert.ToDecimal(txtCRLimit.Text.Trim());
                        else
                            objToUpdate.CreditLimit = null;

                        if (txtMaxAdult.Text.Trim() != "")
                            objToUpdate.MaximumAdults = Convert.ToInt32(txtMaxAdult.Text.Trim());
                        else
                            objToUpdate.MaximumAdults = null;

                        if (txtMaxChild.Text.Trim() != "")
                            objToUpdate.MaximumChilds = Convert.ToInt32(txtMaxChild.Text.Trim());
                        else
                            objToUpdate.MaximumChilds = null;

                        if (chkOverBooking.Checked)
                        {
                            objToUpdate.IsOBInPercentage = true;
                            if (ddlOverBooking.SelectedValue != Guid.Empty.ToString())
                            {
                                objToUpdate.PerFlat_TermID = new Guid(ddlOverBooking.SelectedValue);
                                if (txtOverBooking.Text.Trim() != "")
                                    objToUpdate.Overbooking = Convert.ToDecimal(txtOverBooking.Text.Trim());
                                else
                                    objToUpdate.Overbooking = null;
                            }
                            else
                            {
                                objToUpdate.PerFlat_TermID = null;
                                objToUpdate.Overbooking = null;
                            }
                        }
                        else
                        {
                            objToUpdate.IsOBInPercentage = false;
                            objToUpdate.PerFlat_TermID = null;
                            objToUpdate.Overbooking = null;
                        }

                        objToUpdate.IsDiscountApplicable = Convert.ToBoolean(chkIsdiscountApplicable.Checked);
                        objToUpdate.IsAvailableOnIRS = Convert.ToBoolean(chkIsavailableCRS.Checked);

                        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                        {
                            if (chkAmenitiesList.Items[i].Selected)
                            {
                                RoomTypeAmenities objTempRA = new RoomTypeAmenities();
                                objTempRA.AmenitiesID = new Guid(chkAmenitiesList.Items[i].Value.ToString());

                                lstRoomTypeAmenities.Add(objTempRA);
                            }
                        }

                        for (int i = 0; i < chkComplementoryServices.Items.Count; i++)
                        {
                            if (chkComplementoryServices.Items[i].Selected)
                            {
                                RoomTypeServices objTempRS = new RoomTypeServices();
                                objTempRS.ItemID = new Guid(chkComplementoryServices.Items[i].Value.ToString());
                                objTempRS.IsPerPerson = false;

                                lstRoomTypeServices.Add(objTempRS);
                            }
                        }


                        for (int j = 0; j < gvDepositList.Rows.Count; j++)
                        {
                            CheckBox chkDepositList = (CheckBox)gvDepositList.Rows[j].FindControl("chkDepositList");

                            if (chkDepositList.Checked)
                            {
                                RoomTypeDeposit objTempRD = new RoomTypeDeposit();
                                objTempRD.DepositID = new Guid(gvDepositList.DataKeys[j]["DepositID"].ToString());

                                Label lblGvDepositRate = (Label)gvDepositList.Rows[j].FindControl("lblGvDepositRate");

                                objTempRD.DepositRate = Convert.ToDecimal(lblGvDepositRate.Text.Trim());
                                objTempRD.IsRateFlat = Convert.ToBoolean(gvDepositList.DataKeys[j]["IsFlat"].ToString());

                                lstRoomTypeDeposit.Add(objTempRD);
                            }
                        }

                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.UpdatedOn = DateTime.Now;

                        if (txtNoOfBeds.Text.Trim() != "")
                            objToUpdate.NoOfBeds = Convert.ToInt32(txtNoOfBeds.Text.Trim());
                        else
                            objToUpdate.NoOfBeds = null;

                        objToUpdate.BedSize = Convert.ToString(txtBedSize.Text.Trim());

                        if (txtSBA.Text.Trim() != "")
                            objToUpdate.SBArea = Convert.ToDecimal(txtSBA.Text.Trim());
                        else
                            objToUpdate.SBArea = null;

                        if (txtCarpetArea.Text.Trim() != "")
                            objToUpdate.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text.Trim());
                        else
                            objToUpdate.CarpetArea = null;

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

                        RoomTypeBLL.Update(objToUpdate, lstRoomTypeAmenities, lstRoomTypeDeposit, lstRoomTypeServices);
                        this.RoomTypeID = objToUpdate.RoomTypeID;
                        //tpGallary.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);

                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objToUpdateOldRTData.ToString(), objToUpdate.ToString(), "mst_RoomType");
                        IsListMessageForBI = true;
                        ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        RoomType objToInsert = new RoomType();

                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.RoomTypeName = txtUnitTypeName.Text.Trim();
                        objToInsert.RoomTypeCode = txtUnitTypeCode.Text.Trim();

                        if (txtRackRate.Text.Trim() != "")
                            objToInsert.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());

                        if (txtMinNight.Text.Trim() != "")
                            objToInsert.MinimumStay = Convert.ToInt32(txtMinNight.Text.Trim());
                        if (txtMaxNight.Text.Trim() != "")
                            objToInsert.MaximumStay = Convert.ToInt32(txtMaxNight.Text.Trim());

                        if (txtCRLimit.Text.Trim() != "")
                            objToInsert.CreditLimit = Convert.ToDecimal(txtCRLimit.Text.Trim());

                        if (txtMaxAdult.Text.Trim() != "")
                            objToInsert.MaximumAdults = Convert.ToInt32(txtMaxAdult.Text.Trim());

                        if (txtMaxChild.Text.Trim() != "")
                            objToInsert.MaximumChilds = Convert.ToInt32(txtMaxChild.Text.Trim());

                        if (chkOverBooking.Checked)
                        {
                            objToInsert.IsOBInPercentage = true;
                            if (ddlOverBooking.SelectedValue != Guid.Empty.ToString())
                            {
                                objToInsert.PerFlat_TermID = new Guid(ddlOverBooking.SelectedValue);
                                if (txtOverBooking.Text.Trim() != "")
                                    objToInsert.Overbooking = Convert.ToDecimal(txtOverBooking.Text.Trim());
                            }
                        }
                        else
                            objToInsert.IsOBInPercentage = false;

                        objToInsert.IsDiscountApplicable = Convert.ToBoolean(chkIsdiscountApplicable.Checked);
                        objToInsert.IsAvailableOnIRS = Convert.ToBoolean(chkIsavailableCRS.Checked);

                        for (int i = 0; i < chkAmenitiesList.Items.Count; i++)
                        {
                            if (chkAmenitiesList.Items[i].Selected)
                            {
                                RoomTypeAmenities objTempRA = new RoomTypeAmenities();
                                objTempRA.AmenitiesID = new Guid(chkAmenitiesList.Items[i].Value.ToString());

                                lstRoomTypeAmenities.Add(objTempRA);
                            }
                        }

                        for (int i = 0; i < chkComplementoryServices.Items.Count; i++)
                        {
                            if (chkComplementoryServices.Items[i].Selected)
                            {
                                RoomTypeServices objTempRS = new RoomTypeServices();
                                objTempRS.ItemID = new Guid(chkComplementoryServices.Items[i].Value.ToString());
                                objTempRS.IsPerPerson = false;

                                lstRoomTypeServices.Add(objTempRS);
                            }
                        }

                        for (int j = 0; j < gvDepositList.Rows.Count; j++)
                        {
                            CheckBox chkDepositList = (CheckBox)gvDepositList.Rows[j].FindControl("chkDepositList");

                            if (chkDepositList.Checked)
                            {
                                RoomTypeDeposit objTempRD = new RoomTypeDeposit();
                                objTempRD.DepositID = new Guid(gvDepositList.DataKeys[j]["DepositID"].ToString());

                                Label lblGvDepositRate = (Label)gvDepositList.Rows[j].FindControl("lblGvDepositRate");

                                objTempRD.DepositRate = Convert.ToDecimal(lblGvDepositRate.Text.Trim());
                                objTempRD.IsRateFlat = Convert.ToBoolean(gvDepositList.DataKeys[j]["IsFlat"].ToString());

                                lstRoomTypeDeposit.Add(objTempRD);
                            }
                        }
                        objToInsert.IsActive = true;
                        objToInsert.IsSynch = false;
                        objToInsert.CreatedBy = clsSession.UserID;
                        objToInsert.CreatedOn = DateTime.Now;

                        if (txtNoOfBeds.Text.Trim() != "")
                            objToInsert.NoOfBeds = Convert.ToInt32(txtNoOfBeds.Text.Trim());

                        objToInsert.BedSize = Convert.ToString(txtBedSize.Text.Trim());

                        if (txtSBA.Text.Trim() != "")
                            objToInsert.SBArea = Convert.ToDecimal(txtSBA.Text.Trim());

                        if (txtCarpetArea.Text.Trim() != "")
                            objToInsert.CarpetArea = Convert.ToDecimal(txtCarpetArea.Text.Trim());

                        objToInsert.IsExtraBedAllow = Convert.ToBoolean(chkExtraBedAllowed.Checked);

                        if (chkExtraBedAllowed.Checked)
                        {
                            if (txtExtraBed.Text.Trim() != "")
                                objToInsert.NoOfExtraBed = Convert.ToInt32(txtExtraBed.Text.Trim());
                        }

                        RoomTypeBLL.Save(objToInsert, lstRoomTypeAmenities, lstRoomTypeDeposit, lstRoomTypeServices);
                        this.RoomTypeID = objToInsert.RoomTypeID;

                        //clsSession.ToEditItemType = "ROOMTYPE";
                        //clsSession.ToEditItemID = objToInsert.RoomTypeID;

                        //tpGallary.Visible = true;                        

                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_RoomType");
                        IsListMessageForBI = true;
                        ltrListMessageBI.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }


                    btnSave.Visible = trPhoto.Visible = this.UserRights.Substring(2, 1) == "1";
                    if (chkOverBooking.Checked)
                    {
                        ddlOverBooking.Enabled = txtOverBooking.Enabled = true;
                    }
                    else
                    {
                        ddlOverBooking.Enabled = txtOverBooking.Enabled = false;
                    }

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
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Photo Upload Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                                string strRoomTypeWithPath = strHotelCodeWithPath + "/" + "/RoomType";
                                string strRoomTypeNameWithPath = strRoomTypeWithPath + "/" + Convert.ToString(this.RoomTypeID);

                                if (!Directory.Exists(strCompDocsDirPath))
                                    Directory.CreateDirectory(strCompDocsDirPath);

                                if (!Directory.Exists(strHotelCodeWithPath))
                                    Directory.CreateDirectory(strHotelCodeWithPath);

                                if (!Directory.Exists(strRoomTypeWithPath))
                                    Directory.CreateDirectory(strRoomTypeWithPath);

                                if (!Directory.Exists(strRoomTypeNameWithPath))
                                    Directory.CreateDirectory(strRoomTypeNameWithPath);

                                SQT.Symphony.BusinessLogic.IRMS.DTO.Documents objDocuments = new BusinessLogic.IRMS.DTO.Documents();
                                string strImage = Guid.NewGuid().ToString() + "$" + hpf.FileName.Replace(" ", "_");
                                string strImagePath = strRoomTypeNameWithPath + "/" + strImage;

                                hpf.SaveAs(strImagePath);
                                objDocuments.DocumentName = strImage;
                                objDocuments.Extension = strExtension.Replace(".", "");
                                objDocuments.DateOfSubmission = DateTime.Now;
                                objDocuments.CreatedOn = DateTime.Now;
                                objDocuments.IsActive = true;
                                objDocuments.AssociationType = "RoomType";
                                objDocuments.CreatedBy = clsSession.UserID;
                                objDocuments.AssociationID = this.RoomTypeID;
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
                    ltrListMessageGallary.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                }
                BindRoomTypePhoto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event

        #region CheckBox Event

        protected void chkOverBooking_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkOverBooking.Checked)
                    ddlOverBooking.Enabled = true;
                else
                {
                    ddlOverBooking.Enabled = false;
                    ddlOverBooking.SelectedIndex = 0;
                    txtOverBooking.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

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

        #endregion CheckBox Event

        #region DropDown Event
        //protected void ddlOverBooking_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlOverBooking.SelectedValue != Guid.Empty.ToString())
        //    {
        //        if (ddlOverBooking.SelectedIndex == 1)
        //        {
        //            txtOverBooking.Enabled = true;
        //            rvOverBooking.Enabled = true;
        //            //revOverBooking.Enabled = false;
        //            rvOverBooking.MinimumValue = "0";
        //            rvOverBooking.MaximumValue = "100";
        //        }
        //        else
        //        {
        //            txtOverBooking.Enabled = true;
        //            rvOverBooking.Enabled = false;
        //            //revOverBooking.Enabled = true;
        //            rvOverBooking.MinimumValue = "";
        //            rvOverBooking.MaximumValue = "";
        //        }
        //    }
        //    else
        //    {
        //        txtOverBooking.Text = "";
        //        txtOverBooking.Enabled = false;
        //        rvOverBooking.Enabled = false;
        //        revOverBooking.Enabled = false;
        //        rvOverBooking.MinimumValue = "";
        //        rvOverBooking.MaximumValue = "";
        //    }
        //}
        #endregion DropDown Event
    }
}