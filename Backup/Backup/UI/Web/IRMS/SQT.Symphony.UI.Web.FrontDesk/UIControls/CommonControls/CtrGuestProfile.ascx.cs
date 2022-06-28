using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.IO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrGuestProfile : System.Web.UI.UserControl
    {
        #region Property and Variables
        public bool IsListMessage = false;
        public bool IsMessage = false;
        public bool IsGuestDocMessage = false;

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
        public Guid ForeignNationalityID
        {
            get
            {
                return ViewState["ForeignNationalityID"] != null ? new Guid(Convert.ToString(ViewState["ForeignNationalityID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ForeignNationalityID"] = value;
            }
        }
        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
            }
        }

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

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvGuestProfile.ActiveViewIndex = 0;

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                if (clsSession.ToEditItemID != Guid.Empty && clsSession.ToEditItemType == "GUESTDETAILS")
                {
                    this.ReservationID = clsSession.ToEditItemID;
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                }

                LoadPageData();
            }
        }

        #endregion

        #region Control Event
        protected void btnSaveForeignNationalInfo_Click(object sender,EventArgs e)
        {
            try
            {
                if (this.ForeignNationalityID != null && this.ForeignNationalityID != Guid.Empty)
                {
                    ForeignNationalInfo objUpdForeignNationalInfo = new ForeignNationalInfo();
                    ForeignNationalInfo objoldUpdForeignNationalInfo = new ForeignNationalInfo();
                    objUpdForeignNationalInfo = ForeignNationalInfoBLL.GetByPrimaryKey(this.ForeignNationalityID);
                    objoldUpdForeignNationalInfo = ForeignNationalInfoBLL.GetByPrimaryKey(this.ForeignNationalityID);


                    if (Convert.ToString(txtVisaNo.Text).Trim() != string.Empty)
                        objUpdForeignNationalInfo.VisaNumber = clsCommon.GetUpperCaseText(txtVisaNo.Text.Trim());
                    else
                        objUpdForeignNationalInfo.VisaNumber = null;

                    if (Convert.ToString(txtVisaplaceofissue.Text).Trim() != string.Empty)
                        objUpdForeignNationalInfo.VisaPlaceOfIssue = clsCommon.GetUpperCaseText(txtVisaplaceofissue.Text.Trim());
                    else
                        objUpdForeignNationalInfo.VisaPlaceOfIssue = null;

                    if (Convert.ToString(txtVisatype.Text).Trim() != string.Empty)
                        objUpdForeignNationalInfo.VisaType = clsCommon.GetUpperCaseText(txtVisatype.Text.Trim());
                    else
                        objUpdForeignNationalInfo.VisaType = null;

                    if (Convert.ToString(txtVisaPurpose.Text).Trim() != string.Empty)
                        objUpdForeignNationalInfo.PurposeOfVisa = clsCommon.GetUpperCaseText(txtVisaPurpose.Text.Trim());
                    else
                        objUpdForeignNationalInfo.PurposeOfVisa = null;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (Convert.ToString(txtVisaDateofExpiry.Text.Trim()) != "")
                        objUpdForeignNationalInfo.VisaDateOfExpiry = DateTime.ParseExact(Convert.ToString(txtVisaDateofExpiry.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    else
                        objUpdForeignNationalInfo.VisaDateOfExpiry = null;

                    if (Convert.ToString(txtVisaDateofIssue.Text.Trim()) != "")
                        objUpdForeignNationalInfo.VisaDateOfIssue = DateTime.ParseExact(Convert.ToString(txtVisaDateofIssue.Text.Trim()), clsSession.DateFormat, objCultureInfo);
                    else
                        objUpdForeignNationalInfo.VisaDateOfIssue = null;

                    if (!Directory.Exists(Server.MapPath("~/PassportScan")))
                        Directory.CreateDirectory(Server.MapPath("~/PassportScan"));

                    if (!Directory.Exists(Server.MapPath("~/Visascan")))
                        Directory.CreateDirectory(Server.MapPath("~/Visascan"));

                    string strDocumentNameTemp = "";
                    if (fupVisaScan.FileName != "")
                    {
                        strDocumentNameTemp = "";
                        strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fupVisaScan.FileName.Replace(" ", "_");
                        fupVisaScan.SaveAs(Server.MapPath("~/Visascan/" + strDocumentNameTemp));
                        objUpdForeignNationalInfo.ScannedVisa = strDocumentNameTemp;
                    }

                    ForeignNationalInfoBLL.Update(objUpdForeignNationalInfo);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objoldUpdForeignNationalInfo.ToString(), objUpdForeignNationalInfo.ToString(), "res_ForeignNationalInfo");
                    ClearForeignNationalInfo();
                    mvGuestProfile.ActiveViewIndex = 0;
                    //IsListMessage = true;
                    //ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnBackGuestInfo_Click(object sender, EventArgs e)
        {
            mvGuestProfile.ActiveViewIndex = 0;
 
        }
        protected void ddlNationality_selectedindexchanged(object sender, EventArgs e)
        {
            if (ddlNationality.SelectedIndex != 0 && ddlNationality.SelectedValue.ToUpper() != "INDIAN")
                linkForeignNationalpopup.Visible = true;
            else
                linkForeignNationalpopup.Visible = false;
        }
        protected void linkForeignNationalpopup_Click(object sender, EventArgs e)
        {
            BindIDDocumentType();
            ClearForeignNationalInfo();
            BindForeignNationalInfo();
            mvGuestProfile.ActiveViewIndex = 1;

        }
        protected void btnGuestHistoryCallParent_Click(object sender, EventArgs e)
        {
            //mvGuestProfile.ActiveViewIndex = 0;
        }

        //protected void btnGuestProfileHistory_Click(object sender, EventArgs e)
        //{
        //    ctrlCommonGuestHistory.uclitGuestHistoryName.Text = Convert.ToString(ddlTitel.SelectedValue + " " + txtGuestFirstName.Text.Trim());
        //    ctrlCommonGuestHistory.BindGrid();

        //    if (txtGuestContact.Text.Trim() != "")
        //        ctrlCommonGuestHistory.uclitGuestHistoryContactNo.Text = Convert.ToString(txtGuestContact.Text.Trim());
        //    else
        //        ctrlCommonGuestHistory.uclitGuestHistoryContactNo.Text = "-";
        //    //mvGuestProfile.ActiveViewIndex = 1;
        //}

        protected void btnGuestProfileCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["RoomReservation"] != null)
                Response.Redirect("~/GUI/Reservation/RoomReservation.aspx");
            else if (Request.QueryString["GuestMaster"] != null)
                Response.Redirect("~/GUI/Guest/GuestMaster.aspx");
            else if (Request.QueryString["FolioDetails"] != null)
                Response.Redirect("~/GUI/Folio/FolioDetails.aspx");
            else if (Request.QueryString["BanquetMgmt"] != null)
                Response.Redirect("~/GUI/Banquet/BanquetManagement.aspx#tabs-3");
        }

        protected void btnAddPreferences_Click(object sender, EventArgs e)
        {
            ClearControl();
            mpePreference.Show();
        }

        protected void btnAddMgmtNote_Click(object sender, EventArgs e)
        {
            ClearControl();
            mpeManagementNote.Show();
        }

        protected void btnAddFeedBack_Click(object sender, EventArgs e)
        {
            ClearControl();
            mpeFeedBackAndComplain.Show();
            rbtCategoryList.SelectedIndex = 0;
            litHdrFeedBackAndComplain.Text = "Feedback";
        }

        protected void btnAddCompalin_Click(object sender, EventArgs e)
        {
            ClearControl();
            mpeFeedBackAndComplain.Show();
            rbtCategoryList.SelectedIndex = 1;
            litHdrFeedBackAndComplain.Text = "Complaint";
        }

        //protected void lnkViewDoc1_OnClick(object sender, EventArgs e)
        //{
        //    DataSet dsGuestData = ReservationBLL.GetArrivalListData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, "DETAILS");

        //    if (dsGuestData.Tables.Count > 0 && dsGuestData.Tables[0].Rows.Count > 0)
        //    {
        //        DataRow drResData = dsGuestData.Tables[0].Rows[0];
        //        string fName = Server.MapPath("~/GuestDocument") + "\\" + drResData["ScanID1"].ToString();
        //        FileInfo fi = new FileInfo(fName);
        //        long sz = fi.Length;
        //        Response.ClearContent();
        //        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fName)));
        //        Response.AddHeader("Content-Length", sz.ToString("F0"));
        //        Response.TransmitFile(fName);
        //        Response.End();
        //    }
        //}

        //protected void lnkViewDoc2_OnClick(object sender, EventArgs e)
        //{
        //    DataSet dsGuestData = ReservationBLL.GetArrivalListData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, "DETAILS");

        //    if (dsGuestData.Tables.Count > 0 && dsGuestData.Tables[0].Rows.Count > 0)
        //    {
        //        DataRow drResData = dsGuestData.Tables[0].Rows[0];
        //        string fName = Server.MapPath("~/GuestDocument") + "\\" + drResData["ScanID2"].ToString();
        //        FileInfo fi = new FileInfo(fName);
        //        long sz = fi.Length;
        //        Response.ClearContent();
        //        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fName)));
        //        Response.AddHeader("Content-Length", sz.ToString("F0"));
        //        Response.TransmitFile(fName);
        //        Response.End();
        //    }
        //}

        protected void btnGuestProfileSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);
                    List<ProjectTerm> lstGenders = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "GENDER");

                    objGuest.CompanyName = clsCommon.GetUpperCaseText(txtCompanyName.Text.Trim());
                    objGuest.JobTitle = clsCommon.GetUpperCaseText(txtJobTitle.Text.Trim());
                    objGuest.Department = clsCommon.GetUpperCaseText(txtDepartment.Text.Trim());
                    objGuest.EmployeeID = txtEmployeeID.Text.Trim();
                    objGuest.WorkLocation = clsCommon.GetUpperCaseText(txtWorkLocation.Text.Trim());

                    if (ddlCompanySector.SelectedIndex != 0)
                        objGuest.CompanySector = new Guid(ddlCompanySector.SelectedValue);

                    if (ddlWorkTiming.SelectedIndex != 0)
                        objGuest.WorkTiming = new Guid(ddlWorkTiming.SelectedValue);

                    if (ddlNationality.SelectedIndex != 0)
                        objGuest.Nationality = ddlNationality.SelectedValue ;
                    else
                        objGuest.Nationality = null;

                    if (ddlTitel.SelectedIndex != 0)
                        objGuest.Title = Convert.ToString(ddlTitel.SelectedItem.Text);
                    else
                        objGuest.Title = null;

                    objGuest.FName = clsCommon.GetUpperCaseText(txtGuestFirstName.Text.Trim());
                    objGuest.LName = clsCommon.GetUpperCaseText(txtGuestLastName.Text.Trim());
                    objGuest.GuestFullName = clsCommon.GetUpperCaseText(Convert.ToString(ddlTitel.SelectedItem.Text) + " " + txtGuestFirstName.Text.Trim() + " " + txtGuestLastName.Text.Trim());

                    if (ddlGuestType.SelectedIndex != 0)
                        objGuest.Guest_TypeID = new Guid(ddlGuestType.SelectedValue);
                    else
                        objGuest.Guest_TypeID = null;

                    if (txtCode.Text.Trim() == "")
                        objGuest.Phone1 = "-" + txtGuestContact.Text.Trim();
                    else
                        objGuest.Phone1 = txtCode.Text.Trim() + "-" + txtGuestContact.Text.Trim();

                    objGuest.Email = clsCommon.GetUpperCaseText(txtGuestEmail.Text.Trim());

                    Address GuestAddress = new Address();
                    GuestAddress = AddressBLL.GetByPrimaryKey((Guid)objGuest.AddressID);

                    GuestAddress.Add1 = clsCommon.GetUpperCaseText(txtGuestAddress1.Text.Trim());
                    GuestAddress.Add2 = clsCommon.GetUpperCaseText(txtGuestAddress2.Text.Trim());
                    GuestAddress.ZipCode = clsCommon.GetUpperCaseText(txtGuestZipCode.Text.Trim());
                    GuestAddress.IsActive = true;
                    GuestAddress.CompanyID = clsSession.CompanyID;
                    GuestAddress.IsSynch = false;
                    GuestAddress.CountryID = clsCommon.Country(txtCountry.Text.Trim());
                    GuestAddress.StateID = clsCommon.State(txtGuestState.Text.Trim());
                    GuestAddress.CityID = clsCommon.City(txtGuestCity.Text.Trim());

                    AddressBLL.Update(GuestAddress);

                    if (ddlTitel.SelectedIndex != 0)
                    {
                        if (Convert.ToString(ddlTitel.SelectedValue).ToUpper() == "MR.")
                        {
                            if (lstGenders[0].DisplayTerm.ToUpper() == "MALE")
                                objGuest.Gender_TermID = lstGenders[0].TermID;
                            else
                                objGuest.Gender_TermID = lstGenders[1].TermID;
                        }
                        else
                            objGuest.Gender_TermID = lstGenders[1].TermID;
                    }

                    if (ddlGuestType.SelectedIndex != 0)
                        objGuest.Guest_TypeID = new Guid(ddlGuestType.SelectedValue);
                    else
                        objGuest.Guest_TypeID = null;
                    //// Object of Guest End


                    objGuest.DOB = new DateTime(Convert.ToInt32(ddlDOBYear.SelectedValue), Convert.ToInt32(ddlDOBMonth.SelectedValue), Convert.ToInt32(ddlDOBDate.SelectedValue));

                    if (ddlBloodGroup.SelectedIndex != 0)
                        objGuest.BloodGroup = ddlBloodGroup.SelectedValue;

                    if (ddlMealPreference.SelectedIndex != 0)
                        objGuest.MealPreference = new Guid(ddlMealPreference.SelectedValue);

                    objGuest.ParentName = clsCommon.GetUpperCaseText(txtParentName.Text.Trim());
                    objGuest.ParentContactNo = clsCommon.GetUpperCaseText(txtGaurdianNumber.Text.Trim());
                    objGuest.LocalContactPerson = clsCommon.GetUpperCaseText(txtLocalContactPerson.Text.Trim());
                    objGuest.LocalContactNo = clsCommon.GetUpperCaseText(txtLocalContactNumber.Text.Trim());
                    if (txtGuestAnniversary.Text.Trim() != "")
                    {
                        objGuest.AnniversaryDate = Convert.ToDateTime(txtGuestAnniversary.Text.Trim());
                    }
                    if (!Directory.Exists(Server.MapPath("~/GuestPhoto")))
                        Directory.CreateDirectory(Server.MapPath("~/GuestPhoto"));

                    if (!Directory.Exists(Server.MapPath("~/GuestDocument")))
                        Directory.CreateDirectory(Server.MapPath("~/GuestDocument"));

                    //string strDocumentNameTemp = "";
                    if (fuGuestPhoto.FileName != "")
                    {
                        string Photo = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuGuestPhoto.FileName.Replace(" ", "_");
                        fuGuestPhoto.SaveAs(Server.MapPath("~/GuestPhoto/" + Photo));
                        objGuest.GuestPhoto = Photo;
                        //rfvGuestPhoto.Enabled = false;
                        imgPhoto.ImageUrl = "~/GuestPhoto/" + Photo;
                        //aViewGuestPhoto.HRef = "~/GuestPhoto/" + Photo;
                        //aViewGuestPhoto.Visible = true;
                    }


                    if (ddlGuestIDDocument.SelectedIndex != 0)
                        objGuest.IDType1_TermID = new Guid(ddlGuestIDDocument.SelectedValue);

                    objGuest.IDType1 = txtIDRefNo.Text.Trim();
                    if (fuIDScanCopy.FileName != "")
                    {
                        string Doc1 = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuIDScanCopy.FileName.Replace(" ", "_");
                        fuIDScanCopy.SaveAs(Server.MapPath("~/GuestDocument/" + Doc1));
                        objGuest.ScanID1 = Doc1;
                        /////rfvIDScanCopy.Enabled = false;
                        aViewGuestDoc1.HRef = "~/GuestDocument/" + Doc1;
                        aViewGuestDoc1.Visible = true;
                    }


                    if (ddlGuestIDDocument2.SelectedIndex != 0)
                        objGuest.IDType2_TermID = new Guid(ddlGuestIDDocument2.SelectedValue);

                    objGuest.IDType2 = txtIDRefNo2.Text.Trim();
                    if (fuIDDocument2.FileName != "")
                    {
                        string Doc2 = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fuIDDocument2.FileName.Replace(" ", "_");
                        fuIDDocument2.SaveAs(Server.MapPath("~/GuestDocument/" + Doc2));
                        objGuest.ScanID2 = Doc2;

                        aViewGuestDoc2.HRef = "~/GuestDocument/" + Doc2;
                        aViewGuestDoc2.Visible = true;
                    }

                    //objGuest.DOB = Convert.ToDateTime(ddlDOBDate.SelectedItem + "-" + ddlDOBMonth.SelectedItem + "-" + ddlDOBYear.SelectedItem);

                    GuestBLL.Update(objGuest);


                    IsMessage = true;
                    lblFeedbackMsg.Text = "Record Update successfully.";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnManagementNoteSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                GuestManagementNote objIns = new GuestManagementNote();

                objIns.Notes = clsCommon.GetUpperCaseText(txtManagementNote.Text.Trim());
                objIns.NoteBy = clsSession.UserID;
                objIns.NoteOn = DateTime.Now.Date;
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.IsActive = true;
                objIns.GuestID = this.GuestID;
                GuestManagementNoteBLL.Save(objIns);
                IsMessage = true;
                lblFeedbackMsg.Text = "Recode Saved successfully.";

                BindGuestNote();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPreferenceSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                GuestPreference objInsPref = new GuestPreference();



                objInsPref.CompanyID = clsSession.CompanyID;
                objInsPref.PropertyID = clsSession.PropertyID;
                objInsPref.IsActive = true;
                objInsPref.GuestID = this.GuestID;
                objInsPref.Preference = ddlPreference.SelectedItem.ToString();
                objInsPref.PreferenceDetail = clsCommon.GetUpperCaseText(txtPreferenceDetails.Text.Trim());
                objInsPref.PreferenceID = new Guid(ddlPreference.SelectedValue);
                objInsPref.DateToSet = DateTime.Now.Date;

                GuestPreferenceBLL.Save(objInsPref);
                IsMessage = true;
                lblFeedbackMsg.Text = "Recode Saved successfully.";

                BindGuestPreferences();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveFeedBackAndComplain_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {
                    if (rbtCategoryList.SelectedIndex == 0)
                    {
                        DataSet dsGuestData = ReservationBLL.GetDetailForFeedback(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
                        if (dsGuestData.Tables.Count > 0 && dsGuestData.Tables[0].Rows.Count > 0)
                        {
                            DataRow drResData = dsGuestData.Tables[0].Rows[0];
                            GuestComments objInsFeedback = new GuestComments();

                            if (drResData["CheckInDate"].ToString() != "")
                            {
                                objInsFeedback.CheckInDate = Convert.ToDateTime(drResData["CheckInDate"].ToString());
                            }
                            if (drResData["CheckOutDate"].ToString() != "")
                            {
                                objInsFeedback.CheckOutDate = Convert.ToDateTime(drResData["CheckOutDate"].ToString());
                            }
                            //objInsFeedback.CommentTermID

                            objInsFeedback.Comment = clsCommon.GetUpperCaseText(txtDescription.Text.Trim());
                            objInsFeedback.CompanyID = clsSession.CompanyID;
                            objInsFeedback.ConferenceName = clsCommon.GetUpperCaseText(drResData["ConferenceName"].ToString());
                            objInsFeedback.CreatedBy = clsSession.UserID;
                            objInsFeedback.CreatedOn = DateTime.Now.Date;
                            objInsFeedback.GuestID = this.GuestID;
                            objInsFeedback.IsActive = true;

                            if (drResData["CheckInDate"].ToString() != "" && drResData["CheckOutDate"].ToString() != "")
                            {
                                objInsFeedback.Nights = (Convert.ToInt32(((Convert.ToDateTime(drResData["CheckOutDate"].ToString())) - (Convert.ToDateTime(drResData["CheckInDate"].ToString()))).TotalDays));
                            }

                            objInsFeedback.PropertyID = clsSession.PropertyID;
                            //objInsFeedback.Rate=
                            objInsFeedback.ReservationID = new Guid(drResData["ReservationID"].ToString());
                            objInsFeedback.ReservatioNo = clsCommon.GetUpperCaseText(drResData["ReservationNo"].ToString());
                            objInsFeedback.RoomNo = clsCommon.GetUpperCaseText(drResData["RoomNo"].ToString());
                            objInsFeedback.RoomType = clsCommon.GetUpperCaseText(drResData["RoomTypeName"].ToString());
                            objInsFeedback.NatureOfComplaint = clsCommon.GetUpperCaseText(txtNatureOfComplaint.Text.Trim());
                            objInsFeedback.Department = new Guid(ddlDepartment.SelectedValue);
                            objInsFeedback.CommentsBy = clsCommon.GetUpperCaseText(txtComplainBy.Text.Trim());
                            GuestCommentsBLL.Save(objInsFeedback);
                            IsMessage = true;
                            lblFeedbackMsg.Text = "Recode Saved successfully.";
                            BindGuestFeedback();
                        }
                    }
                    else
                    {
                        GuestComplaint objInsComplaint = new GuestComplaint();

                        objInsComplaint.CompanyID = clsSession.CompanyID;
                        objInsComplaint.CompainTime = DateTime.Now.TimeOfDay;
                        objInsComplaint.ComplaintDescription = clsCommon.GetUpperCaseText(txtDescription.Text.Trim());
                        objInsComplaint.CreatedBy = clsSession.UserID;
                        objInsComplaint.CreatedOn = DateTime.Now.Date;
                        objInsComplaint.DateOfComplain = DateTime.Now.Date;
                        objInsComplaint.Department = new Guid(ddlDepartment.SelectedValue);
                        objInsComplaint.GuestID = this.GuestID;
                        objInsComplaint.IsActive = true;
                        objInsComplaint.NatureOfComplaint = clsCommon.GetUpperCaseText(txtNatureOfComplaint.Text.Trim());
                        objInsComplaint.PropertyID = clsSession.PropertyID;
                        objInsComplaint.ComplaintBy = clsCommon.GetUpperCaseText(txtComplainBy.Text.Trim());
                        GuestComplaintBLL.Save(objInsComplaint);
                        IsMessage = true;
                        lblFeedbackMsg.Text = "Recode Saved successfully.";
                        BindGuestComplain();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnGuestProfileCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/CurrentGuestList.aspx");
        }
        #endregion

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "GuestProfile.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

            btnGuestProfileSave.Visible = this.UserRights.Substring(2, 1) == "1";
        }
        private void BindIDDocumentType()
        {
            try
            {
                ddlIdtypeForeignNatinal.Items.Clear();
                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "ID DOCUMENT TYPE");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlIdtypeForeignNatinal.DataSource = lstProjectTermTitle;
                    ddlIdtypeForeignNatinal.DataTextField = "DisplayTerm";
                    ddlIdtypeForeignNatinal.DataValueField = "TermID";
                    ddlIdtypeForeignNatinal.DataBind();
                    ddlIdtypeForeignNatinal.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlIdtypeForeignNatinal.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindForeignNationalInfo()
        {
            try
            {
                if (this.ReservationID != Guid.Empty && this.GuestID != Guid.Empty)
                {
                    ForeignNationalInfo objForeignNationalInfo = new ForeignNationalInfo();
                    objForeignNationalInfo.CompanyID = clsSession.CompanyID;
                    objForeignNationalInfo.PropertyID = clsSession.PropertyID;
                    objForeignNationalInfo.ReservationID = this.ReservationID;
                    objForeignNationalInfo.GuestID = this.GuestID;
                    if (ddlNationality.SelectedIndex != 0)
                        objForeignNationalInfo.Nationality = ddlNationality.SelectedValue;

                    DataSet dsForeignNationalInfo = ForeignNationalInfoBLL.GetAllWithDataSet(objForeignNationalInfo);
                    if (dsForeignNationalInfo != null && dsForeignNationalInfo.Tables.Count > 0 && dsForeignNationalInfo.Tables[0].Rows.Count > 0)
                    {
                        DataRow drForeignNationalInfo = dsForeignNationalInfo.Tables[0].Rows[0];
                        this.ForeignNationalityID = new Guid(Convert.ToString(drForeignNationalInfo["ForeignNationalityID"]));
                        txtPassportNumber.Text = Convert.ToString(drForeignNationalInfo["PassportNumber"]);
                        txtPassportPlaceOfIssue.Text = Convert.ToString(drForeignNationalInfo["PassportPlaceOfIssue"]);
                        if (drForeignNationalInfo["PassportDateOfExpiry"].ToString() != "")
                        {
                            DateTime dtPassPortExpityDate = Convert.ToDateTime(Convert.ToString(drForeignNationalInfo["PassportDateOfExpiry"]));
                            txtPassportDateOfExpiry.Text = Convert.ToString(dtPassPortExpityDate.ToString(clsSession.DateFormat));
                        }
                        else
                        {
                            txtPassportDateOfExpiry.Text = "";
                        }
                        if (drForeignNationalInfo["PassportPlaceOfIssue"].ToString() != "")
                        {
                            DateTime dtPassPortDateOfIssue = Convert.ToDateTime(Convert.ToString(drForeignNationalInfo["PassportDateOfIssue"]));
                            txtPassportDateOfIssue.Text = Convert.ToString(dtPassPortDateOfIssue.ToString(clsSession.DateFormat));
                        }
                        else
                        {
                            txtPassportDateOfIssue.Text = "";
                        }
                        if (drForeignNationalInfo["IDType"].ToString() != "")
                        {
                            ddlIdtypeForeignNatinal.SelectedValue = Convert.ToString(drForeignNationalInfo["IDType"]);
                        }
                        else
                        {
                            ddlIdtypeForeignNatinal.SelectedIndex = 0;
                        }
                        txtVisaNo.Text = Convert.ToString(drForeignNationalInfo["VisaNumber"]);
                        txtVisaplaceofissue.Text = Convert.ToString(drForeignNationalInfo["VisaPlaceOfIssue"]);
                        txtVisatype.Text = Convert.ToString(drForeignNationalInfo["VisaType"]);
                        txtVisaPurpose.Text = Convert.ToString(drForeignNationalInfo["PurposeOfVisa"]);
                        if (drForeignNationalInfo["VisaDateOfExpiry"].ToString() != "")
                        {
                            DateTime dtVisaDateOfExpiry = Convert.ToDateTime(Convert.ToString(drForeignNationalInfo["VisaDateOfExpiry"]));
                            txtVisaDateofExpiry.Text = Convert.ToString(dtVisaDateOfExpiry.ToString(clsSession.DateFormat));
                        }
                        else
                        {
                            txtVisaDateofExpiry.Text = "";
                        }
                        if (drForeignNationalInfo["VisaDateOfIssue"].ToString() != "")
                        {
                            DateTime dtVisaDateOfIssue = Convert.ToDateTime(Convert.ToString(drForeignNationalInfo["VisaDateOfIssue"]));
                            txtVisaDateofIssue.Text = Convert.ToString(dtVisaDateOfIssue.ToString(clsSession.DateFormat));
                        }
                        else
                        {
                            txtVisaDateofIssue.Text = "";
                        }

                        if (Convert.ToString(drForeignNationalInfo["ScannedPassport1"]) != "")
                        {
                            ancViewPassportScan1.HRef = "~/PassportScan/" + Convert.ToString(drForeignNationalInfo["ScannedPassport1"]);
                            ancViewPassportScan1.Visible = true;
                        }
                        if (Convert.ToString(drForeignNationalInfo["ScannedPassport2"]) != "")
                        {
                            ancViewPassportScan2.HRef = "~/PassportScan/" + Convert.ToString(drForeignNationalInfo["ScannedPassport2"]);
                            ancViewPassportScan2.Visible = true;
                        }
                        if (Convert.ToString(drForeignNationalInfo["ScannedVisa"]) != "")
                        {
                            ancViewVisaScan.HRef = "~/Visascan/" + Convert.ToString(drForeignNationalInfo["ScannedVisa"]);
                            ancViewVisaScan.Visible = true;
                            rfvVisaScan.Enabled = false;
                        }
                        else
                        {
                            rfvVisaScan.Enabled = false;
                        }
                        //strDocumentNameTemp = Guid.NewGuid().ToString().Substring(0, 16) + "_" + fupVisaScan.FileName.Replace(" ", "_");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearForeignNationalInfo()
        {
            txtPassportDateOfExpiry.Text = txtPassportDateOfIssue.Text = txtPassportNumber.Text = txtPassportPlaceOfIssue.Text = txtVisaDateofExpiry.Text = txtVisaDateofIssue.Text = txtVisaNo.Text = txtVisaplaceofissue.Text = txtVisaPurpose.Text = txtVisatype.Text = "";
          
        }
        private void BindNationality()
        {
            try
            {
                ddlNationality.Items.Clear();
                List<ProjectTerm> lstProjectTermTitle = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "NATIONALITY");
                if (lstProjectTermTitle.Count != 0)
                {
                    ddlNationality.DataSource = lstProjectTermTitle;
                    ddlNationality.DataTextField = "DisplayTerm";
                    ddlNationality.DataValueField = "DisplayTerm";
                    ddlNationality.DataBind();
                    ddlNationality.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlNationality.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadPageData()
        {
            try
            {
                BindBreadCrumb();
                BindNationality();
                BindProjectTermData();
                BindDDLDepartment();
                BindDDLPreference();
                BindGuestBasicDetails();
                BindGuestNote();
                BindGuestStayHistory();
                BindGuestFeedback();
                BindGuestComplain();
                BindGuestPreferences();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
        /// 
        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Guest Profile";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);


            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGuestPreferences()
        {
            try
            {
                if (this.GuestID != Guid.Empty)
                {
                    DataSet dsGuestPref = GuestPreferenceBLL.GetAllForGuestPreferenceList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                    gvGuestPreferences.DataSource = dsGuestPref;
                    gvGuestPreferences.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGuestNote()
        {
            try
            {
                if (this.GuestID != Guid.Empty)
                {
                    DataSet dtGuestManNote = GuestManagementNoteBLL.GetAllForGuestManagementNoteList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                    gvFrontDesksNote.DataSource = dtGuestManNote;
                    gvFrontDesksNote.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGuestFeedback()
        {
            try
            {
                if (this.GuestID != Guid.Empty)
                {
                    DataSet dtGuestFeedback = GuestCommentsBLL.GetAllForCommentsGuestList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                    gvFeedbacks.DataSource = dtGuestFeedback;
                    gvFeedbacks.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGuestComplain()
        {
            try
            {
                if (this.GuestID != Guid.Empty)
                {
                    DataSet dtGuestComplain = GuestComplaintBLL.GetAllForComplaintGuestList(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                    gvComplains.DataSource = dtGuestComplain;
                    gvComplains.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindGuestStayHistory()
        {
            try
            {
                if (this.GuestID != Guid.Empty)
                {
                    DataSet dtGuestFeedback = ReservationGuestBLL.GetAllGuestStayHistory(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                    gvGuestHistory.DataSource = dtGuestFeedback;
                    gvGuestHistory.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }

        private void BindGuestBasicDetails()
        {
            try
            {
                if (this.ReservationID != Guid.Empty)
                {
                    DataSet dsGuestData = ReservationBLL.GetArrivalListData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, "DETAILS", null);

                    if (dsGuestData.Tables.Count > 0 && dsGuestData.Tables[0].Rows.Count > 0)
                    {
                        DataRow drResData = dsGuestData.Tables[0].Rows[0];
                        this.GuestID = new Guid(Convert.ToString(drResData["GuestID"]));

                        litGuestHistoryName.Text = drResData["GuestFullName"].ToString();
                        litGuestHistoryContactNo.Text = drResData["Phone1"].ToString();
                        ddlNationality.SelectedIndex = ddlNationality.Items.FindByValue(Convert.ToString(drResData["Nationality"])) != null ? ddlNationality.Items.IndexOf(ddlNationality.Items.FindByValue(Convert.ToString(drResData["Nationality"]))) : 0;
                        if (ddlNationality.SelectedIndex != 0 && ddlNationality.SelectedValue.ToUpper() != "INDIAN")
                            linkForeignNationalpopup.Visible = true;
                        else
                            linkForeignNationalpopup.Visible = false;

                        // txtNationality.Text = drResData["Nationality"].ToString();
                        ddlTitel.SelectedIndex = ddlTitel.Items.FindByValue(Convert.ToString(drResData["Title"])) != null ? ddlTitel.Items.IndexOf(ddlTitel.Items.FindByValue(Convert.ToString(drResData["Title"]))) : 0;
                        txtGuestFirstName.Text = drResData["FName"].ToString();
                        txtGuestLastName.Text = drResData["LName"].ToString();
                        //txtGuestContact.Text = drResData["Phone1"].ToString();


                        if (Convert.ToString(drResData["Phone1"]) != "" && Convert.ToString(drResData["Phone1"]) != null)
                        {
                            string[] words = Convert.ToString(drResData["Phone1"]).Split('-');
                            if (words.Length > 1)
                            {
                                txtCode.Text = Convert.ToString(words[0]);
                                txtGuestContact.Text = Convert.ToString(words[1]);
                            }
                            else
                            {
                                txtCode.Text = Convert.ToString(words[0]);
                                txtGuestContact.Text = "";
                            }
                        }
                        else
                        {
                            txtCode.Text = "";
                            txtGuestContact.Text = "";
                        }
                        txtGuestEmail.Text = drResData["Email"].ToString();
                        txtGuestAddress1.Text = drResData["Add1"].ToString();
                        txtGuestAddress2.Text = drResData["Add2"].ToString();
                        txtGuestCity.Text = drResData["CityName"].ToString();
                        txtGuestZipCode.Text = drResData["ZipCode"].ToString();
                        txtGuestState.Text = drResData["StateName"].ToString();
                        txtCountry.Text = drResData["CountryName"].ToString();
                        ddlGuestType.SelectedIndex = ddlGuestType.Items.FindByValue(Convert.ToString(drResData["Guest_TypeID"])) != null ? ddlGuestType.Items.IndexOf(ddlGuestType.Items.FindByValue(Convert.ToString(drResData["Guest_TypeID"]))) : 0;
                        ddlGuestIDDocument.SelectedIndex = ddlGuestIDDocument.Items.FindByValue(Convert.ToString(drResData["IDType1_TermID"])) != null ? ddlGuestIDDocument.Items.IndexOf(ddlGuestIDDocument.Items.FindByValue(Convert.ToString(drResData["IDType1_TermID"]))) : 0;
                        txtIDRefNo.Text = drResData["IDType1"].ToString();
                        ddlGuestIDDocument2.SelectedIndex = ddlGuestIDDocument2.Items.FindByValue(Convert.ToString(drResData["IDType2_TermID"])) != null ? ddlGuestIDDocument2.Items.IndexOf(ddlGuestIDDocument2.Items.FindByValue(Convert.ToString(drResData["IDType2_TermID"]))) : 0;
                        txtIDRefNo2.Text = drResData["IDType2"].ToString();
                        txtParentName.Text = drResData["ParentName"].ToString();
                        txtGaurdianNumber.Text = drResData["ParentContactNo"].ToString();
                        txtLocalContactPerson.Text = drResData["LocalContactPerson"].ToString();
                        txtLocalContactNumber.Text = drResData["LocalContactNo"].ToString();
                        ddlBloodGroup.SelectedIndex = ddlBloodGroup.Items.FindByValue(Convert.ToString(drResData["BloodGroup"])) != null ? ddlBloodGroup.Items.IndexOf(ddlBloodGroup.Items.FindByValue(Convert.ToString(drResData["BloodGroup"]))) : 0;
                        ddlMealPreference.SelectedIndex = ddlMealPreference.Items.FindByValue(Convert.ToString(drResData["MealPreference"])) != null ? ddlMealPreference.Items.IndexOf(ddlMealPreference.Items.FindByValue(Convert.ToString(drResData["MealPreference"]))) : 0;
                        txtCompanyName.Text = drResData["CompanyName"].ToString();
                        txtJobTitle.Text = drResData["JobTitle"].ToString();
                        txtDepartment.Text = drResData["Department"].ToString();
                        txtEmployeeID.Text = drResData["EmployeeID"].ToString();
                        ddlCompanySector.SelectedIndex = ddlCompanySector.Items.FindByValue(Convert.ToString(drResData["CompanySector"])) != null ? ddlCompanySector.Items.IndexOf(ddlCompanySector.Items.FindByValue(Convert.ToString(drResData["CompanySector"]))) : 0;
                        txtWorkLocation.Text = drResData["WorkLocation"].ToString();
                        ddlWorkTiming.SelectedIndex = ddlWorkTiming.Items.FindByValue(Convert.ToString(drResData["WorkTiming"])) != null ? ddlWorkTiming.Items.IndexOf(ddlWorkTiming.Items.FindByValue(Convert.ToString(drResData["WorkTiming"]))) : 0;

                        if (Convert.ToString(drResData["DOB"]) != "")
                        {
                            DateTime dob = Convert.ToDateTime(drResData["DOB"]);

                            ddlDOBDate.SelectedValue = ddlDOBDate.Items.FindByText(dob.Day.ToString()).Value;
                            ddlDOBMonth.SelectedValue = ddlDOBMonth.Items.FindByValue(dob.Month.ToString()).Value;
                            ddlDOBYear.SelectedValue = ddlDOBYear.Items.FindByText(dob.Year.ToString()).Value;
                        }
                        string anniverDate = drResData["AnniversaryDate"].ToString();
                        if (anniverDate != "")
                        {
                            DateTime dtAnneiversaryDate = Convert.ToDateTime(Convert.ToString(drResData["AnniversaryDate"]));
                            txtGuestAnniversary.Text = Convert.ToString(dtAnneiversaryDate.ToString(clsSession.DateFormat));
                        }
                        else
                        {
                            txtGuestAnniversary.Text = "";
                        }

                        if (Convert.ToString(drResData["ScanID1"]) != "")
                        {
                            /////rfvIDScanCopy.Enabled = false;
                            aViewGuestDoc1.HRef = "~/GuestDocument/" + drResData["ScanID1"].ToString();
                            aViewGuestDoc1.Visible = true;
                        }
                        else
                        {
                            /////rfvIDScanCopy.Enabled = true;
                            aViewGuestDoc1.Visible = false;
                        }

                        if (Convert.ToString(drResData["ScanID2"]) != "")
                        {
                            aViewGuestDoc2.HRef = "~/GuestDocument/" + drResData["ScanID2"].ToString();
                            aViewGuestDoc2.Visible = true;
                        }
                        else
                        {
                            aViewGuestDoc2.Visible = false;
                        }
                        if (Convert.ToString(drResData["GuestPhoto"]) != "")
                        {
                            //rfvGuestPhoto.Enabled = false;
                            imgPhoto.ImageUrl = "~/GuestPhoto/" + drResData["GuestPhoto"].ToString();
                            //aViewGuestPhoto.HRef = "~/GuestPhoto/" + drResData["GuestPhoto"].ToString();
                            //aViewGuestPhoto.Visible = true;
                        }
                        else
                        {
                            //rfvGuestPhoto.Enabled = true;
                            aViewGuestPhoto.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindProjectTermData()
        {
            try
            {
                ddlTitel.Items.Clear();
                DataSet dsData = ProjectTermBLL.SelectTitleCSWTGT(clsSession.CompanyID, clsSession.PropertyID, "TITLE", "COMPANYSECTOR", "WORKINGTIME", "GUESTTYPE", "ID DOCUMENT TYPE", "BLOOD GROUP", "MEAL PREFERENCE", "PAYMENTMODE");
                if (dsData.Tables.Count != 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    ddlTitel.DataSource = dsData.Tables[0];
                    ddlTitel.DataTextField = "DisplayTerm";
                    ddlTitel.DataValueField = "Term";
                    ddlTitel.DataBind();
                    ddlTitel.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlTitel.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));

                ddlCompanySector.Items.Clear();
                if (dsData.Tables.Count != 0 && dsData.Tables[1].Rows.Count > 0)
                {
                    ddlCompanySector.DataSource = dsData.Tables[1];
                    ddlCompanySector.DataTextField = "DisplayTerm";
                    ddlCompanySector.DataValueField = "TermID";
                    ddlCompanySector.DataBind();
                    ddlCompanySector.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlCompanySector.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));

                ddlWorkTiming.Items.Clear();
                if (dsData.Tables.Count != 0 && dsData.Tables[2].Rows.Count > 0)
                {
                    ddlWorkTiming.DataSource = dsData.Tables[2];
                    ddlWorkTiming.DataTextField = "DisplayTerm";
                    ddlWorkTiming.DataValueField = "TermID";
                    ddlWorkTiming.DataBind();
                    ddlWorkTiming.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlWorkTiming.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));

                ddlGuestType.Items.Clear();
                if (dsData.Tables.Count != 0 && dsData.Tables[3].Rows.Count > 0)
                {
                    ddlGuestType.DataSource = dsData.Tables[3];
                    ddlGuestType.DataTextField = "DisplayTerm";
                    ddlGuestType.DataValueField = "TermID";
                    ddlGuestType.DataBind();
                    ddlGuestType.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlGuestType.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));


                ddlGuestIDDocument.Items.Clear();
                ddlGuestIDDocument2.Items.Clear();
                if (dsData.Tables.Count != 0 && dsData.Tables[4].Rows.Count > 0)
                {
                    ddlGuestIDDocument.DataSource = dsData.Tables[4];
                    ddlGuestIDDocument.DataTextField = "DisplayTerm";
                    ddlGuestIDDocument.DataValueField = "TermID";
                    ddlGuestIDDocument.DataBind();
                    ddlGuestIDDocument.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));

                    ddlGuestIDDocument2.DataSource = dsData.Tables[4];
                    ddlGuestIDDocument2.DataTextField = "DisplayTerm";
                    ddlGuestIDDocument2.DataValueField = "TermID";
                    ddlGuestIDDocument2.DataBind();
                    ddlGuestIDDocument2.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlGuestIDDocument.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                    ddlGuestIDDocument2.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }


                ddlBloodGroup.Items.Clear();
                if (dsData.Tables.Count != 0 && dsData.Tables[5].Rows.Count > 0)
                {
                    ddlBloodGroup.DataSource = dsData.Tables[5];
                    ddlBloodGroup.DataTextField = "DisplayTerm";
                    ddlBloodGroup.DataValueField = "Term";
                    ddlBloodGroup.DataBind();
                    ddlBloodGroup.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlBloodGroup.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));

                ddlMealPreference.Items.Clear();
                if (dsData.Tables.Count != 0 && dsData.Tables[6].Rows.Count > 0)
                {
                    ddlMealPreference.DataSource = dsData.Tables[6];
                    ddlMealPreference.DataTextField = "DisplayTerm";
                    ddlMealPreference.DataValueField = "TermID";
                    ddlMealPreference.DataBind();
                    ddlMealPreference.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlMealPreference.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));



                ddlDOBDate.Items.Clear();
                ddlDOBYear.Items.Clear();

                ddlDOBDate.Items.Insert(0, new ListItem("-DATE-", Guid.Empty.ToString()));
                for (int i = 1; i < 32; i++)
                {
                    if (i < 10)
                        ddlDOBDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                    else
                        ddlDOBDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }

                int l = 1;
                ddlDOBYear.Items.Insert(0, new ListItem("-YEAR-", Guid.Empty.ToString()));
                for (int i = DateTime.Now.Year; i >= 1940; i--)
                {
                    ddlDOBYear.Items.Insert(l, new ListItem(i.ToString(), i.ToString()));
                    l++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            ddlPreference.SelectedIndex = ddlDepartment.SelectedIndex = 0;
            txtPreferenceDetails.Text = txtPreferenceDescription.Text = txtManagementNote.Text = txtComplainBy.Text = txtNatureOfComplaint.Text = txtDescription.Text = "";
        }

        private void BindDDLPreference()
        {
            try
            {
                ddlPreference.Items.Clear();
                DataSet dsData = SQT.Symphony.BusinessLogic.FrontDesk.BLL.PreferenceMasterBLL.GetAllForList(clsSession.PropertyID, clsSession.CompanyID);
                if (dsData.Tables.Count != 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    ddlPreference.DataSource = dsData.Tables[0];
                    ddlPreference.DataTextField = "PreferenceName";
                    ddlPreference.DataValueField = "PreferenceID";
                    ddlPreference.DataBind();
                    ddlPreference.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlPreference.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDDLDepartment()
        {
            try
            {
                ddlDepartment.Items.Clear();
                DataSet dsData = DepartmentBLL.GetSearcahDepartmentData(clsSession.PropertyID, null, null, clsSession.CompanyID);
                if (dsData.Tables.Count != 0 && dsData.Tables[0].Rows.Count > 0)
                {
                    ddlDepartment.DataSource = dsData.Tables[0];
                    ddlDepartment.DataTextField = "DepartmentName";
                    ddlDepartment.DataValueField = "DepartmentID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
                }
                else
                    ddlDepartment.Items.Insert(0, new ListItem("-SELECT-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public int Reservation_GetTotalDays(Object CheckInDate, Object CheckOutDate)
        {
            int Day = (Convert.ToInt32(((Convert.ToDateTime(CheckOutDate.ToString())) - (Convert.ToDateTime(CheckInDate.ToString()))).TotalDays));
            return Day;
        }

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }
        #endregion

        #region Grid Event

        protected void gvGuestHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlInvoiceAmt = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Display_Charges"));
                    ((Label)e.Row.FindControl("lblGvInvoiceAmount")).Text = dcmlInvoiceAmt.ToString().Substring(0, dcmlInvoiceAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));                    
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event
    }
}