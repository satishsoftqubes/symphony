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
    public partial class CtrlConference : System.Web.UI.UserControl
    {
        #region Variable and Property

        public bool IsListMessage = false;
        public bool IsListMessageForGallary = false;
        public Guid ConferenceID
        {
            get
            {
                return ViewState["ConferenceID"] != null ? new Guid(Convert.ToString(ViewState["ConferenceID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ConferenceID"] = value;
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
        public DataTable dtExistingDetails = null;

        #endregion Variable and Property

        #region Form Load
        /// <summary>
        /// Form Load Evnet
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(0);", true);
                lblSelectFileForRG.Text = "";
                LoadDefaultData();

                if (clsSession.ToEditItemType == "CONFERENCE" && clsSession.ToEditItemID != Guid.Empty)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                    btnSave.Visible = trPhoto.Visible = this.UserRights.Substring(2, 1) == "1";
                    this.ConferenceID = clsSession.ToEditItemID;
                    BindConferenceData();
                }
                BindConferenceType();
                BindBreadCrumb();
            }

        }
        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CONFERENCEBANQUET.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        // Bind Grid Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                SetPageLables();
                //tpGallary.Visible = false;
                revLength.ValidationExpression = revWidth.ValidationExpression = revHeight.ValidationExpression = revRackRate.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
                revLength.ErrorMessage = revWidth.ErrorMessage = revHeight.ErrorMessage = revRackRate.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        // Set Page Label
        /// </summary>
        private void SetPageLables()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("Conference", "lblMainHeader", "CONFERENCE HALL NAME");
            lbltpConferenceName.Text = clsCommon.GetGlobalResourceText("Conference", "lbltpConferenceName", "Conference hall Name");
            lbltpConferenceCode.Text = clsCommon.GetGlobalResourceText("Conference", "lbltpConferenceCode", "Conference Code");
            lbltpHWL.Text = clsCommon.GetGlobalResourceText("Conference", "lbltpHWL", "H x W x L (Ft)");
            lbltpKeyExtNo.Text = clsCommon.GetGlobalResourceText("Conference", "lbltpKeyExtNo", "Key/Ext No");
            lbltpDetail.Text = clsCommon.GetGlobalResourceText("Conference", "lbltpDetail", "Detail");
            litTypeArrangement.Text = clsCommon.GetGlobalResourceText("Conference", "lblTypeArrangement", "Type Arrangement");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litTabBasicInformation.Text = clsCommon.GetGlobalResourceText("Conference", "lblTabBasicInformation", "Basic Information");
            litTabGallary.Text = clsCommon.GetGlobalResourceText("Conference", "lblTabGallary", "Gallery");
            lblRackRate.Text = clsCommon.GetGlobalResourceText("Conference", "lblRackRate", "Rack Rate");
            btnUpload.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnUpload", "Upload All");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
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
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr5 = dt.NewRow();
            dr5["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr5["Link"] = "";
            dt.Rows.Add(dr5);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblConferenceBanquetList", "Conference hall List");
            dr3["Link"] = "~/GUI/Configurations/ConferenceList.aspx";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = txtConferenceName.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblConferenceBanquet", "Conference hall Name") : txtConferenceName.Text.Trim();
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Conference Type
        /// </summary>
        private void BindConferenceType()
        {
            DataSet dsConfernceType = ConferenceTypeBLL.GetDataByConferenceID(clsSession.ToEditItemID, clsSession.PropertyID, clsSession.CompanyID);

            if (dsConfernceType.Tables[1].Rows.Count > 0)
            {
                dtExistingDetails = dsConfernceType.Tables[1];
            }

            gvTypeArrangement.DataSource = dsConfernceType;
            gvTypeArrangement.DataBind();
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            //this.ConferenceID = Guid.Empty;
            txtConferenceName.Text = txtConferenceCode.Text = txtH.Text = txtW.Text = txtL.Text = txtKeyNo.Text = txtExtNo.Text = txtDetail.Text = "";
            revLength.ValidationExpression = revWidth.ValidationExpression = revHeight.ValidationExpression = "\\d{0,24}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            BindConferenceType();
        }

        private void BindConferenceData()
        {
            try
            {
                if (clsSession.ToEditItemType == "CONFERENCE" && clsSession.ToEditItemID != Guid.Empty)
                {
                    Conference objLoadConference = new Conference();
                    objLoadConference = ConferenceBLL.GetByPrimaryKey(this.ConferenceID);

                    if (objLoadConference != null)
                    {
                        //tpGallary.Visible = true;
                        txtConferenceName.Text = Convert.ToString(objLoadConference.ConferenceName);
                        txtConferenceCode.Text = Convert.ToString(objLoadConference.ConferenceCode);
                        if (Convert.ToString(objLoadConference.Height) != "")
                            txtH.Text = Convert.ToString(objLoadConference.Height.ToString().Substring(0, objLoadConference.Height.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                        if (Convert.ToString(objLoadConference.Width) != "")
                            txtW.Text = Convert.ToString(objLoadConference.Width.ToString().Substring(0, objLoadConference.Width.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                        if (Convert.ToString(objLoadConference.Length) != "")
                            txtL.Text = Convert.ToString(objLoadConference.Length.ToString().Substring(0, objLoadConference.Length.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                        if (Convert.ToString(objLoadConference.RackRate) != "")
                            txtRackRate.Text = Convert.ToString(objLoadConference.RackRate.ToString().Substring(0, objLoadConference.RackRate.ToString().LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint));
                        txtKeyNo.Text = Convert.ToString(objLoadConference.KeyNo);
                        txtExtNo.Text = Convert.ToString(objLoadConference.ExtensioNo);
                        txtDetail.Text = Convert.ToString(objLoadConference.ConferenceDetails);

                        BindConferencePhoto();
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
        private void BindConferencePhoto()
        {
            try
            {
                List<Documents> lstLoadDocument = null;
                Documents objLoadDocuments = new Documents();
                objLoadDocuments.AssociationID = this.ConferenceID;
                objLoadDocuments.CompanyID = clsSession.CompanyID;
                objLoadDocuments.PropertyID = clsSession.PropertyID;

                lstLoadDocument = DocumentsBLL.GetAll(objLoadDocuments);

                if (lstLoadDocument.Count != 0)
                {
                    dtlstConferenceGallary.DataSource = lstLoadDocument;
                    dtlstConferenceGallary.DataBind();
                }
                else
                {
                    dtlstConferenceGallary.DataSource = null;
                    dtlstConferenceGallary.DataBind();
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
            string str = "~/Upload/CompanyDocuments/" + clsSession.HotelCode.ToString() + "/Conference/" + Convert.ToString(this.ConferenceID) + "/" + Convert.ToString(strval);
            string mappath = Server.MapPath(str);
            FileInfo f = new FileInfo(mappath);
            if (f.Exists)
                return str;
            else
                return "~/images/BlankPhoto.jpg";
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        // Grid Data Row Bound
        /// </summary>
        // <param name="sender">sender as Object</param>
        // <param name="e">e as GridViewRowEventArgs</param>

        protected void gvTypeArrangement_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (dtExistingDetails != null)
                {
                    DataRow[] rows = dtExistingDetails.Select("ConferenceTypeID = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ConferenceTypeID")) + "'");
                    if (rows.Length > 0)
                    {
                        ((CheckBox)e.Row.FindControl("chkType")).Checked = true;
                        TextBox txtGvCapacity = (TextBox)e.Row.FindControl("txtGvCapacity");

                        txtGvCapacity.Text = Convert.ToString(rows[0]["Capacity"]);
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("chkGvType")).Attributes.Add("onclick", "javascript:SelectAll('" +
                        ((CheckBox)e.Row.FindControl("chkGvType")).ClientID + "')");

                ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Label)e.Row.FindControl("lblGvHdrType")).Text = clsCommon.GetGlobalResourceText("Conference", "lblGvHdrType", "Type");
                ((Label)e.Row.FindControl("lblGvHdrCapacity")).Text = clsCommon.GetGlobalResourceText("Conference", "lblGvHdrCapacity", "Capacity");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        /// <summary>
        // Grid Row Command Event
        /// </summary>
        // <param name="sender">sender as object</param>
        // <param name="e">e a GridViewCommandEventArgs</param>

        protected void dtlstConferenceGallary_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("DELETEPHOTO"))
                {
                    Documents objDelete = DocumentsBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));

                    DocumentsBLL.Delete(objDelete);
                    string strPath = Server.MapPath("~/Upload/CompanyDocuments/" + clsSession.HotelCode.ToString() + "/Conference/" + Convert.ToString(this.ConferenceID) + "/" + Convert.ToString(dtlstConferenceGallary.DataKeys[e.Item.ItemIndex]));

                    if (File.Exists(strPath))
                        File.Delete(strPath);

                    DocumentsBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "dms_Documents");
                    IsListMessageForGallary = true;
                    ltrListMessageGallary.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    BindConferencePhoto();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab();", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void dtlstConferenceGallary_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                lblSelectFileForRG.Text = "";
                LinkButton lnkConferenceGallaryDelete = (LinkButton)e.Item.FindControl("lnkConferenceGallaryDelete");
                lnkConferenceGallaryDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                lnkConferenceGallaryDelete.Visible = this.UserRights.Substring(3, 1) == "1";
            }
        }

        protected void lnkConferenceGallaryDelete_DataBinding(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            ScriptManager sm = (ScriptManager)Page.Master.FindControl("scptInnerHTML");
            sm.RegisterPostBackControl(lb);            
        }
        #endregion Grid Event

        #region Control Event

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = String.Empty;
            Response.Redirect("~/GUI/Configurations/Conference.aspx");
        }

        /// <summary>
        /// Save and Update Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    Conference IsConferenceDup = new Conference();

                    IsConferenceDup.ConferenceName = txtConferenceName.Text.Trim();
                    IsConferenceDup.IsActive = true;
                    IsConferenceDup.PropertyID = clsSession.PropertyID;
                    IsConferenceDup.CompanyID = clsSession.CompanyID;

                    List<Conference> LstDupConference = null;
                    LstDupConference = ConferenceBLL.GetAll(IsConferenceDup);

                    List<ConfConferenceType> lstConfConferenceType = new List<ConfConferenceType>();
                    if (LstDupConference.Count > 0)
                    {
                        if (this.ConferenceID != Guid.Empty)
                        {
                            if (Convert.ToString((LstDupConference[0].ConferenceID)) != Convert.ToString(this.ConferenceID))
                            {
                                IsListMessage = true;
                                ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                                return;
                            }
                        }
                        else
                        {
                            IsListMessage = true;
                            ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                            return;
                        }
                    }

                    ////DataSet dsDuplicateExtNo = RoomBLL.RoomAndConferenceSelectExtensionNO(clsSession.PropertyID, txtExtNo.Text.Trim());
                    ////if (dsDuplicateExtNo.Tables[0] != null && dsDuplicateExtNo.Tables[0].Rows.Count > 0)
                    ////{
                    ////    if (this.ConferenceID != Guid.Empty)
                    ////    {
                    ////        if (Convert.ToString((dsDuplicateExtNo.Tables[0].Rows[0]["RoomID"])) != Convert.ToString(this.ConferenceID))
                    ////        {
                    ////            IsListMessage = true;
                    ////            ltrListMessage.Text = "Recored with same Ext. No. Already Exist.";
                    ////            return;
                    ////        }
                    ////    }
                    ////    else
                    ////    {
                    ////        IsListMessage = true;
                    ////        ltrListMessage.Text = "Recored with same Ext. No. Already Exist.";
                    ////        return;
                    ////    }
                    ////}

                    if (this.ConferenceID != Guid.Empty)
                    {
                        Conference objToUpdate = new Conference();
                        Conference objOldData = new Conference();

                        objToUpdate = ConferenceBLL.GetByPrimaryKey(this.ConferenceID);
                        objOldData = ConferenceBLL.GetByPrimaryKey(this.ConferenceID);

                        objToUpdate.ConferenceName = txtConferenceName.Text.Trim();
                        objToUpdate.ConferenceCode = txtConferenceCode.Text.Trim();
                        if (txtH.Text.Trim() != "")
                            objToUpdate.Height = Convert.ToDecimal(txtH.Text.Trim());
                        else
                            objToUpdate.Height = null;
                        if (txtW.Text.Trim() != "")
                            objToUpdate.Width = Convert.ToDecimal(txtW.Text.Trim());
                        else
                            objToUpdate.Width = null;
                        if (txtL.Text.Trim() != "")
                            objToUpdate.Length = Convert.ToDecimal(txtL.Text.Trim());
                        else
                            objToUpdate.Length = null;
                        if (txtRackRate.Text.Trim() != "")
                            objToUpdate.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());
                        else
                            objToUpdate.RackRate = null;
                        objToUpdate.KeyNo = txtKeyNo.Text.Trim();
                        objToUpdate.ExtensioNo = txtExtNo.Text.Trim();
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.ConferenceDetails = txtDetail.Text.Trim();

                        for (int i = 0; i < gvTypeArrangement.Rows.Count; i++)
                        {
                            CheckBox chkType = (CheckBox)gvTypeArrangement.Rows[i].FindControl("chkType");
                            if (chkType.Checked)
                            {
                                ConfConferenceType objTemp = new ConfConferenceType();
                                objTemp.ConferenceTypeID = new Guid(gvTypeArrangement.DataKeys[i]["ConferenceTypeID"].ToString());
                                TextBox txtGvCapacity = (TextBox)gvTypeArrangement.Rows[i].FindControl("txtGvCapacity");
                                objTemp.Capacity = Convert.ToInt32(txtGvCapacity.Text.Trim());
                                objTemp.UpdatedOn = DateTime.Now;
                                objTemp.UpdatedBy = clsSession.UserID;
                                objTemp.IsSynch = false;
                                objTemp.IsActive = true;

                                lstConfConferenceType.Add(objTemp);
                            }
                        }

                        ConferenceBLL.Update(objToUpdate, lstConfConferenceType);
                        this.ConferenceID = objToUpdate.ConferenceID;
                        //tpGallary.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objToUpdate.ToString(), "mst_Conference");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Conference objToInsert = new Conference();

                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.ConferenceName = txtConferenceName.Text.Trim();
                        objToInsert.ConferenceCode = txtConferenceCode.Text.Trim();
                        if (txtH.Text.Trim() != "")
                            objToInsert.Height = Convert.ToDecimal(txtH.Text.Trim());
                        if (txtW.Text.Trim() != "")
                            objToInsert.Width = Convert.ToDecimal(txtW.Text.Trim());
                        if (txtL.Text.Trim() != "")
                            objToInsert.Length = Convert.ToDecimal(txtL.Text.Trim());
                        if (txtRackRate.Text.Trim() != "")
                            objToInsert.RackRate = Convert.ToDecimal(txtRackRate.Text.Trim());
                        objToInsert.KeyNo = txtKeyNo.Text.Trim();
                        objToInsert.ExtensioNo = txtExtNo.Text.Trim();
                        objToInsert.IsActive = true;
                        objToInsert.UpdatedOn = DateTime.Now;
                        objToInsert.UpdatedBy = clsSession.UserID;
                        objToInsert.IsSynch = false;
                        objToInsert.ConferenceDetails = txtDetail.Text.Trim();

                        for (int i = 0; i < gvTypeArrangement.Rows.Count; i++)
                        {
                            CheckBox chkType = (CheckBox)gvTypeArrangement.Rows[i].FindControl("chkType");
                            if (chkType.Checked)
                            {
                                ConfConferenceType objTemp = new ConfConferenceType();
                                objTemp.ConferenceTypeID = new Guid(gvTypeArrangement.DataKeys[i]["ConferenceTypeID"].ToString());
                                TextBox txtGvCapacity = (TextBox)gvTypeArrangement.Rows[i].FindControl("txtGvCapacity");
                                objTemp.Capacity = Convert.ToInt32(txtGvCapacity.Text.Trim());
                                objTemp.UpdatedOn = DateTime.Now;
                                objTemp.UpdatedBy = clsSession.UserID;
                                objTemp.IsSynch = false;
                                objTemp.IsActive = true;

                                lstConfConferenceType.Add(objTemp);
                            }
                        }

                        ConferenceBLL.Save(objToInsert, lstConfConferenceType);
                        this.ConferenceID = objToInsert.ConferenceID;
                        //tpGallary.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTabIndex(1);", true);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "mst_Conference");
                        IsListMessage = true;
                        ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    }
                    btnSave.Visible = trPhoto.Visible = this.UserRights.Substring(2, 1) == "1";

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

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            clsSession.ToEditItemType = String.Empty;
            Response.Redirect("~/GUI/Configurations/ConferenceList.aspx");
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
                                string strRoomTypeWithPath = strHotelCodeWithPath + "/" + "/Conference";
                                string strRoomTypeNameWithPath = strRoomTypeWithPath + "/" + Convert.ToString(this.ConferenceID);

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
                                objDocuments.AssociationType = "Conference";
                                objDocuments.CreatedBy = clsSession.UserID;
                                objDocuments.AssociationID = this.ConferenceID;
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
                BindConferencePhoto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Control Event
    }
}