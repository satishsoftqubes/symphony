using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Activity
{
	public partial class CtrlAdminOldRentPayout : System.Web.UI.UserControl
	{
        #region Property and Variable
        public bool IsInsert = false;
        public bool IsInsertForDetails = false;
        public bool IsToHideDateImages = false;
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
        public int NoOfDays
        {
            get
            {
                return ViewState["NoOfDays"] != null ? Convert.ToInt32(ViewState["NoOfDays"]) : 0;
            }
            set
            {
                ViewState["NoOfDays"] = value;
            }
        }
        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
        public Guid QuarterID
        {
            get
            {
                return ViewState["QuarterID"] != null ? new Guid(Convert.ToString(ViewState["QuarterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["QuarterID"] = value;
            }
        }
        public Guid QuarterIDForHeader
        {
            get
            {
                return ViewState["QuarterID"] != null ? new Guid(Convert.ToString(ViewState["QuarterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["QuarterID"] = value;
            }
        }
        public string PropertymgmtPercentage
        {
            get
            {
                return ViewState["PropertymgmtPercentage"] != null ? Convert.ToString(ViewState["PropertymgmtPercentage"]) : string.Empty;
            }
            set
            {
                ViewState["PropertymgmtPercentage"] = value;
            }
        }
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.DateFormat = "dd-MM-yyyy";
                    calEndDate.Format = calStartDate.Format = this.DateFormat;
                    if (Session["CompanyID"] != null)
                    {
                        this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    }
                    BindRentPayoutQuarterInfo();
                    BindRentPayoutHeaderData();
                    mvRentPayoutHeader.ActiveViewIndex = 0;
                    mpeRentPayOut.ActiveViewIndex = 0;
                    BindRentPayoutGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Page load

        #region Private Method
        private void RentPayoutDataCalculation(DataTable dtForRentPauoutCalc, ref decimal douReturnValue, int RowNumber)
        {
            for (int j = 1; j < dtForRentPauoutCalc.Columns.Count - 1; j++)
            {
                if (!Convert.ToString(dtForRentPauoutCalc.Rows[RowNumber][j]).Equals(""))
                {
                    douReturnValue += Convert.ToDecimal(dtForRentPauoutCalc.Rows[RowNumber][j]);
                }
            }
        }
        private void BindRentPayoutQuarterInfo()
        {
            DataSet dsForRentPayoutInfo = RentPayoutQuarterSetupBLL.GetAllWithDataSet();
            if (dsForRentPayoutInfo != null && dsForRentPayoutInfo.Tables.Count > 0 && dsForRentPayoutInfo.Tables[0].Rows.Count > 0)
            {
                DataView dvForRentPayout = new DataView(dsForRentPayoutInfo.Tables[0]);
                dvForRentPayout.Sort = "StartDate asc";
                dlRentPayOutQuarter.DataSource = dvForRentPayout;
                dlRentPayOutQuarter.DataBind();
            }
        }
        private void BindRentPayoutHeaderData()
        {
            DataSet dsForRentPayoutInfo = RentPayoutQuarterSetupBLL.GetAllWithDataSet();
            if (dsForRentPayoutInfo != null && dsForRentPayoutInfo.Tables.Count > 0 && dsForRentPayoutInfo.Tables[0].Rows.Count > 0)
            {
                DataView dvForRentPayout = new DataView(dsForRentPayoutInfo.Tables[0]);
                dvForRentPayout.Sort = "StartDate asc";
                gvRentPayoutQuarterSetup.DataSource = dvForRentPayout;
                gvRentPayoutQuarterSetup.DataBind();
            }
        }
        public void BindRentPayoutGrid()
        {
            DataTable dtTable = new DataTable();
            DataColumn dc1 = new DataColumn("UnitNo");
            DataColumn dc2 = new DataColumn("SFT");
            DataColumn dc3 = new DataColumn("StartDate");
            DataColumn dc4 = new DataColumn("EndDate");
            DataColumn dc5 = new DataColumn("NoofDays");
            DataColumn dc6 = new DataColumn("YieldPerDay");
            DataColumn dc7 = new DataColumn("YieldAmount");
            DataColumn dc8 = new DataColumn("TDS");
            DataColumn dc9 = new DataColumn("NetAmountPayable");
            DataColumn dc10 = new DataColumn("PayOutDate");
            DataColumn dc11 = new DataColumn("PaymentMode");


            dtTable.Columns.Add(dc1);
            dtTable.Columns.Add(dc2);
            dtTable.Columns.Add(dc3);
            dtTable.Columns.Add(dc4);
            dtTable.Columns.Add(dc5);
            dtTable.Columns.Add(dc6);
            dtTable.Columns.Add(dc7);
            dtTable.Columns.Add(dc8);
            dtTable.Columns.Add(dc9);
            dtTable.Columns.Add(dc10);
            dtTable.Columns.Add(dc11);



            DataRow dr1 = dtTable.NewRow();
            dr1["UnitNo"] = "A0-007";
            dr1["SFT"] = "100";
            dr1["StartDate"] = "12-09-2012";
            dr1["EndDate"] = "14-09-2012";
            dr1["NoofDays"] = "2";
            dr1["YieldPerDay"] = "3";
            dr1["YieldAmount"] = "100";
            dr1["TDS"] = "10";
            dr1["NetAmountPayable"] = "110";
            dr1["PayOutDate"] = "15-09-2012";
            dr1["PaymentMode"] = "Check";

            dtTable.Rows.Add(dr1);



            DataRow dr2 = dtTable.NewRow();
            dr2["UnitNo"] = "A0-007";
            dr2["SFT"] = "100";
            dr2["StartDate"] = "12-09-2012";
            dr2["EndDate"] = "14-09-2012";
            dr2["NoofDays"] = "2";
            dr2["YieldPerDay"] = "3";
            dr2["YieldAmount"] = "100";
            dr2["TDS"] = "10";
            dr2["NetAmountPayable"] = "110";
            dr2["PayOutDate"] = "15-09-2012";
            dr2["PaymentMode"] = "Check";
            dtTable.Rows.Add(dr2);

            DataRow dr3 = dtTable.NewRow();
            dr3["UnitNo"] = "A0-007";
            dr3["SFT"] = "100";
            dr3["StartDate"] = "12-09-2012";
            dr3["EndDate"] = "14-09-2012";
            dr3["NoofDays"] = "2";
            dr3["YieldPerDay"] = "3";
            dr3["YieldAmount"] = "100";
            dr3["TDS"] = "10";
            dr3["NetAmountPayable"] = "110";
            dr3["PayOutDate"] = "15-09-2012";
            dr3["PaymentMode"] = "Check";
            dtTable.Rows.Add(dr3);




            gvAdminRendPayoutDetails.DataSource = dtTable;
            gvAdminRendPayoutDetails.DataBind();

        }
        private void ClearControl()
        {
            aQuarterCertificate.Visible = false;
            imgDelete.Visible = false;
            this.QuarterIDForHeader = Guid.Empty;
            txtEndDate.Enabled = txtStartDate.Enabled = txtPropertymgmtcharge.Enabled = true;
            IsToHideDateImages = false;
            txtEndDate.Text = txtNote.Text = txtQuarterTitle.Text = txtStartDate.Text = txtPropertymgmtcharge.Text = "";
        }
        private void ClearDetailControl()
        {
            this.QuarterID = Guid.Empty;
            NoOfDays = 0;
            PropertymgmtPercentage = string.Empty;

            litDisplayRentYieldPerDay.Text = litDisplayRentYieldPerSFT.Text = litDisplaySelfOccupiedArea.Text = txtDisplaySelfOccupiedArea.Text = litDisplayTotalAreaOfComplex.Text = "0";
            litDispTotalRoomRentTodistribute.Text = txtPropertyMgmtFees.Text = litDisplayNetAreaUnderPMS.Text = txtDisplayNetAreaUnderPMS.Text = litDisplayRentToDistributed.Text = "0";
            txtInterestOnRoomRent.Text = txtDisplayTotalAreaOfComplex.Text = txtDisplayRoomRentForPeriod.Text = litDisplayRoomRentForPeriod.Text = "0";
            txtServiceTax.Text = txtBankCharges.Text = ltrTotalAmountToDeduct.Text = "0";
            litDisplayRentYieldPerSFT.Text = litDisplayRentYieldPerDay.Text = "0";
        }
        #endregion

        #region Button Event
        protected void btnAddRentPayout_Click(object sender, EventArgs e)
        {
            ClearControl();
            mvRentPayoutHeader.ActiveViewIndex = 1;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            ClearControl();
            mvRentPayoutHeader.ActiveViewIndex = 0;
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
        }
        protected void btnBackToQuarterList_Click(object sender, EventArgs e)
        {
            ClearDetailControl();
            mpeRentPayOut.ActiveViewIndex = 0;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime dtStartDate = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    DateTime dtEndDate = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    if (txtStartDate.Enabled == true || txtEndDate.Enabled == true)
                    {
                        if (dtEndDate.Date <= dtStartDate.Date)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            litMessageBox.Text = "End date must be greater than start date";
                            mpeMessageBox.Show();
                            return;
                        }
                        // Check For Date Over lapping

                        if (this.QuarterIDForHeader != null && this.QuarterIDForHeader != Guid.Empty)
                        {
                            for (int j = 0; j < gvRentPayoutQuarterSetup.Rows.Count; j++)
                            {
                                DateTime dtGVStartDate = Convert.ToDateTime(gvRentPayoutQuarterSetup.DataKeys[j]["StartDate"]);
                                DateTime dtGVEndDate = Convert.ToDateTime(gvRentPayoutQuarterSetup.DataKeys[j]["EndDate"]);
                                string strQuarterID = Convert.ToString(gvRentPayoutQuarterSetup.DataKeys[j]["QuarterID"]);
                                if (strQuarterID.ToUpper() != this.QuarterIDForHeader.ToString().ToUpper())
                                {
                                    if (dtStartDate >= dtGVStartDate && dtStartDate <= dtGVEndDate)
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                        litMessageBox.Text = "Date Range is Overlapping";
                                        mpeMessageBox.Show();
                                        return;
                                    }
                                    else if (dtEndDate >= dtGVStartDate && dtEndDate <= dtGVEndDate)
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                        litMessageBox.Text = "Date Range is Overlapping";
                                        mpeMessageBox.Show();
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DataSet dsForDateOveLapping = RentPayoutQuarterSetupBLL.RentPayoutQuarterSetupCheckDateOverLappingBLL(dtStartDate, this.CompanyID, null);
                            if (dsForDateOveLapping != null && dsForDateOveLapping.Tables.Count > 0 && dsForDateOveLapping.Tables[0].Rows.Count > 0)
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                litMessageBox.Text = "Date Range is Overlapping";
                                mpeMessageBox.Show();
                                return;
                            }
                        }


                        if (Convert.ToDecimal(txtPropertymgmtcharge.Text.Trim()) > 100)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            litMessageBox.Text = "% should be less than or equal to 100.";
                            mpeMessageBox.Show();
                            return;
                        }
                    }
                    if (this.QuarterIDForHeader != null && this.QuarterIDForHeader != Guid.Empty)
                    {
                        RentPayoutQuarterSetup objRentPayoutQuarterDataForEdit = new RentPayoutQuarterSetup();
                        objRentPayoutQuarterDataForEdit = RentPayoutQuarterSetupBLL.GetByPrimaryKey(this.QuarterIDForHeader);

                        RentPayoutQuarterSetup objoldRentPayoutQuarterDataForEdit = new RentPayoutQuarterSetup();
                        objoldRentPayoutQuarterDataForEdit = RentPayoutQuarterSetupBLL.GetByPrimaryKey(this.QuarterIDForHeader);


                        if (objRentPayoutQuarterDataForEdit != null)
                        {
                            objRentPayoutQuarterDataForEdit.CompanyID = this.CompanyID;
                            objRentPayoutQuarterDataForEdit.Title = Convert.ToString(txtQuarterTitle.Text.Trim());
                            objRentPayoutQuarterDataForEdit.StartDate = dtStartDate;
                            objRentPayoutQuarterDataForEdit.EndDate = dtEndDate;
                            objRentPayoutQuarterDataForEdit.PropertyManagementCharge = Convert.ToDecimal(txtPropertymgmtcharge.Text.Trim());
                            objRentPayoutQuarterDataForEdit.UpdatedOn = DateTime.Now;
                            objRentPayoutQuarterDataForEdit.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                            objRentPayoutQuarterDataForEdit.IsActive = true;
                            objRentPayoutQuarterDataForEdit.Note = Convert.ToString(txtNote.Text.Trim());
                            RentPayoutQuarterSetupBLL.Update(objRentPayoutQuarterDataForEdit);
                            ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objoldRentPayoutQuarterDataForEdit.ToString(), objRentPayoutQuarterDataForEdit.ToString(), "mst_RentPayoutQuarterSetup");

                        }
                        if (fuQuarterCertificate.FileName != "")
                        {
                            List<Documents> Lst = DocumentsBLL.GetAllBy(Documents.DocumentsFields.AssociationID, objRentPayoutQuarterDataForEdit.QuarterID.ToString());
                            if (Lst.Count > 0)
                                DocumentsBLL.Delete(Lst[0].DocumentID);

                            string FileConstructionAgreement = "QuarterCertificate$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuQuarterCertificate.FileName.Replace(" ", "_");
                            string path1 = Server.MapPath("~/Document/" + FileConstructionAgreement);
                            fuQuarterCertificate.SaveAs(path1);
                            Documents d1 = new Documents();
                            d1.DocumentName = FileConstructionAgreement;
                            d1.Extension = System.IO.Path.GetExtension(fuQuarterCertificate.FileName);
                            d1.DateOfSubmission = DateTime.Now;
                            d1.CreatedOn = DateTime.Now;
                            d1.IsActive = true;
                            d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                            List<ProjectTerm> objProjecttermDataForCertificate = ProjectTermBLL.GetAllBy(ProjectTerm.ProjectTermFields.Term, "Quarter certificate");
                            if (objProjecttermDataForCertificate.Count > 0)
                            {
                                d1.TypeID = objProjecttermDataForCertificate[0].TermID;
                                d1.AssociationType = Convert.ToString(objProjecttermDataForCertificate[0].Term);
                            }
                            else
                            {
                                d1.AssociationType = "Quarter Certificate";
                            }

                            d1.AssociationID = objRentPayoutQuarterDataForEdit.QuarterID;
                            d1.IsSynch = false;
                            d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            // d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            DocumentsBLL.Save(d1);
                        }
                        ClearControl();
                        BindRentPayoutHeaderData();
                        IsInsert = true;
                        lblRentPayoutmsg.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                        mvRentPayoutHeader.ActiveViewIndex = 1;
                    }
                    else
                    {
                        RentPayoutQuarterSetup objRentPayoutQuartersetup = new RentPayoutQuarterSetup();
                        objRentPayoutQuartersetup.CompanyID = this.CompanyID;
                        objRentPayoutQuartersetup.Title = Convert.ToString(txtQuarterTitle.Text.Trim());
                        objRentPayoutQuartersetup.StartDate = dtStartDate;
                        objRentPayoutQuartersetup.EndDate = dtEndDate;
                        objRentPayoutQuartersetup.PropertyManagementCharge = Convert.ToDecimal(txtPropertymgmtcharge.Text.Trim());
                        objRentPayoutQuartersetup.CreatedOn = DateTime.Now;
                        objRentPayoutQuartersetup.IsActive = true;
                        objRentPayoutQuartersetup.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objRentPayoutQuartersetup.Note = Convert.ToString(txtNote.Text.Trim());
                        RentPayoutQuarterSetupBLL.Save(objRentPayoutQuartersetup);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objRentPayoutQuartersetup.ToString(), objRentPayoutQuartersetup.ToString(), "mst_RentPayoutQuarterSetup");



                        if (fuQuarterCertificate.FileName != "")
                        {
                            string FileConstructionAgreement = "QuarterCertificate$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuQuarterCertificate.FileName.Replace(" ", "_");
                            string path1 = Server.MapPath("~/Document/" + FileConstructionAgreement);
                            fuQuarterCertificate.SaveAs(path1);
                            Documents d1 = new Documents();
                            d1.DocumentName = FileConstructionAgreement;
                            d1.Extension = System.IO.Path.GetExtension(fuQuarterCertificate.FileName);
                            d1.DateOfSubmission = DateTime.Now;
                            d1.CreatedOn = DateTime.Now;
                            d1.IsActive = true;
                            d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));


                            List<ProjectTerm> objProjecttermDataForCertificate = ProjectTermBLL.GetAllBy(ProjectTerm.ProjectTermFields.Term, "Quarter certificate");

                            if (objProjecttermDataForCertificate.Count > 0)
                            {
                                d1.TypeID = objProjecttermDataForCertificate[0].TermID;
                                d1.AssociationType = Convert.ToString(objProjecttermDataForCertificate[0].Term);
                            }
                            else
                            {
                                d1.AssociationType = "Quarter Certificate";
                            }
                            d1.AssociationID = objRentPayoutQuartersetup.QuarterID;
                            d1.IsSynch = false;
                            d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            //  d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                            DocumentsBLL.Save(d1);
                        }

                        ClearControl();
                        BindRentPayoutHeaderData();
                        IsInsert = true;
                        lblRentPayoutmsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                        mvRentPayoutHeader.ActiveViewIndex = 1;
                    }

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void dlRentPayOutQuarter_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    LinkButton lnkToViewQuarterDetail = (LinkButton)e.Item.FindControl("lnkToViewQuarterDetail");
                    if (DataBinder.Eval(e.Item.DataItem, "StartDate") != null && Convert.ToString(DataBinder.Eval(e.Item.DataItem, "StartDate")) != "" && DataBinder.Eval(e.Item.DataItem, "EndDate") != null && Convert.ToString(DataBinder.Eval(e.Item.DataItem, "EndDate")) != "")
                    {
                        lnkToViewQuarterDetail.Text = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "StartDate")).ToString(this.DateFormat) + " to " + Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "EndDate")).ToString(this.DateFormat);
                    }
                    else
                    {
                        lnkToViewQuarterDetail.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void dlRentPayOutQuarter_ItemCommand(Object sender, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("QUARTERDETAILS") && e.CommandArgument != null && Convert.ToString(e.CommandArgument) != string.Empty)
                {
                    ClearDetailControl();
                    this.QuarterID = new Guid(e.CommandArgument.ToString());
                    RentPayoutQuarterSetup objRentPauoutData = new RentPayoutQuarterSetup();
                    objRentPauoutData = RentPayoutQuarterSetupBLL.GetByPrimaryKey(this.QuarterID);
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    int intNoOfDays;

                    if (objRentPauoutData.StartDate != null && Convert.ToString(objRentPauoutData.StartDate) != "" && objRentPauoutData.EndDate != null && Convert.ToString(objRentPauoutData.EndDate) != "")
                    {
                        DateTime dtStartDate = Convert.ToDateTime(objRentPauoutData.StartDate);
                        litDisplayPeriodFrom.Text = Convert.ToDateTime(objRentPauoutData.StartDate).ToString(this.DateFormat);
                        DateTime dtEndDate = Convert.ToDateTime(objRentPauoutData.EndDate);
                        litDisplayTo.Text = Convert.ToDateTime(objRentPauoutData.EndDate).ToString(this.DateFormat);
                        intNoOfDays = (Convert.ToInt32((dtEndDate - dtStartDate).TotalDays));
                        NoOfDays = intNoOfDays + 1;
                        litNoOfays.Text = "No. of Days : " + Convert.ToString(intNoOfDays + 1);

                        if (objRentPauoutData.PropertyManagementCharge != null && Convert.ToString(objRentPauoutData.PropertyManagementCharge) != "")
                        {
                            PropertymgmtPercentage = Convert.ToString(objRentPauoutData.PropertyManagementCharge);
                            litDisppropertymangeper.Text = PropertymgmtPercentage.Substring(0, PropertymgmtPercentage.LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                        }

                        List<RentPayOutPerQuarter> objRentPerPauoutData = RentPayOutPerQuarterBLL.GetAllBy(RentPayOutPerQuarter.RentPayOutPerQuarterFields.QuarterID, Convert.ToString(this.QuarterID));
                        if (objRentPerPauoutData.Count > 0)
                        {
                            txtDisplayTotalAreaOfComplex.Text = litDisplayTotalAreaOfComplex.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].TotalAreaOfComplex)).ToString(); // Convert.ToString(objRentPerPauoutData[0].TotalAreaOfComplex).Substring(0, Convert.ToString(objRentPerPauoutData[0].TotalAreaOfComplex).LastIndexOf(".") + 1 + Convert.ToInt16("0"));
                            litDisplaySelfOccupiedArea.Text = txtDisplaySelfOccupiedArea.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].SelfOccupiedArea)).ToString(); //Convert.ToString(objRentPerPauoutData[0].SelfOccupiedArea).Substring(0, Convert.ToString(objRentPerPauoutData[0].SelfOccupiedArea).LastIndexOf(".") + 1 + Convert.ToInt16("0"));
                            litDisplayNetAreaUnderPMS.Text = txtDisplayNetAreaUnderPMS.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].AreaUnderPMS)).ToString(); //Convert.ToString(objRentPerPauoutData[0].AreaUnderPMS).Substring(0, Convert.ToString(objRentPerPauoutData[0].AreaUnderPMS).LastIndexOf(".") + 1 + Convert.ToInt16("0"));
                            litDisplayRoomRentForPeriod.Text = txtDisplayRoomRentForPeriod.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RoomRentCollected)).ToString(); //Convert.ToString(objRentPerPauoutData[0].RoomRentCollected).Substring(0, Convert.ToString(objRentPerPauoutData[0].RoomRentCollected).LastIndexOf(".") + 1 + Convert.ToInt16("0"));

                            txtInterestOnRoomRent.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].InterestOnRoomRent)).ToString(); //Convert.ToString(objRentPerPauoutData[0].InterestOnRoomRent).Substring(0, Convert.ToString(objRentPerPauoutData[0].InterestOnRoomRent).LastIndexOf(".") + 1 + Convert.ToInt16("0"));

                            litDispTotalRoomRentTodistribute.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].TotalAmountToDistribute)).ToString(); //Convert.ToString(objRentPerPauoutData[0].TotalAmountToDistribute).Substring(0, Convert.ToString(objRentPerPauoutData[0].TotalAmountToDistribute).LastIndexOf(".") + 1 + Convert.ToInt16("0"));
                            txtPropertyMgmtFees.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].PropertyManagementCharge)).ToString(); //Convert.ToString(objRentPerPauoutData[0].PropertyManagementCharge).Substring(0, Convert.ToString(objRentPerPauoutData[0].PropertyManagementCharge).LastIndexOf(".") + 1 + Convert.ToInt16("0"));
                            txtServiceTax.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].ServiceTax)).ToString();
                            txtBankCharges.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].BankCharges)).ToString();
                            ltrTotalAmountToDeduct.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].TotalAmountToDeduct)).ToString();
                            litDisplayRentToDistributed.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].NetAmountToDistribute)).ToString(); //Convert.ToString(objRentPerPauoutData[0].NetAmountToDistribute).Substring(0, Convert.ToString(objRentPerPauoutData[0].NetAmountToDistribute).LastIndexOf(".") + 1 + Convert.ToInt16("0"));
                            litDisplayRentYieldPerSFT.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RentYieldPerSqft), 3).ToString(); //Convert.ToString(objRentPerPauoutData[0].RentYieldPerSqft).Substring(0, Convert.ToString(objRentPerPauoutData[0].RentYieldPerSqft).LastIndexOf(".") + 1 + Convert.ToInt16("3"));
                            litDisplayRentYieldPerDay.Text = Math.Round(Convert.ToDecimal(objRentPerPauoutData[0].RentYieldPerDay), 3).ToString(); //Convert.ToString(objRentPerPauoutData[0].RentYieldPerDay).Substring(0, Convert.ToString(objRentPerPauoutData[0].RentYieldPerDay).LastIndexOf(".") + 1 + Convert.ToInt16("3"));
                            btnQuarterDetailSave.Visible = false;
                            mpeRentPayOut.ActiveViewIndex = 1;
                            txtDisplayTotalAreaOfComplex.Enabled = txtDisplaySelfOccupiedArea.Enabled = txtDisplayNetAreaUnderPMS.Enabled = txtInterestOnRoomRent.Enabled = txtPropertyMgmtFees.Enabled = txtServiceTax.Enabled = txtBankCharges.Enabled = txtDisplayRoomRentForPeriod.Enabled = false;
                            return;
                        }
                        else
                        {
                            txtInterestOnRoomRent.Enabled = true;
                            txtDisplayTotalAreaOfComplex.Enabled = txtDisplaySelfOccupiedArea.Enabled = txtDisplayNetAreaUnderPMS.Enabled = txtInterestOnRoomRent.Enabled = txtPropertyMgmtFees.Enabled = txtServiceTax.Enabled = txtBankCharges.Enabled = txtDisplayRoomRentForPeriod.Enabled = true;
                            btnQuarterDetailSave.Visible = true;
                        }
                    }
                    else
                    {
                        intNoOfDays = 0;
                        NoOfDays = 0;
                        litDisplayTo.Text = "";
                        litDisplayPeriodFrom.Text = "";
                        litNoOfays.Text = "No. of Days : ";
                    }

                    txtDisplayTotalAreaOfComplex.Text = litDisplayTotalAreaOfComplex.Text = txtDisplaySelfOccupiedArea.Text = litDisplaySelfOccupiedArea.Text = "0";
                    txtDisplayNetAreaUnderPMS.Text = litDisplayNetAreaUnderPMS.Text = txtDisplayRoomRentForPeriod.Text = litDisplayRoomRentForPeriod.Text = "0";
                    litDispTotalRoomRentTodistribute.Text = txtPropertyMgmtFees.Text = litDisplayRentToDistributed.Text = litDisplayRentYieldPerSFT.Text = "0";
                    litDisplayRentYieldPerDay.Text = txtServiceTax.Text = txtBankCharges.Text = ltrTotalAmountToDeduct.Text = txtInterestOnRoomRent.Text = "0";

                    mpeRentPayOut.ActiveViewIndex = 1;
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void imgDelete_OnClick(object sender, EventArgs e)
        {
            string str = Convert.ToString(imgDelete.CommandArgument);
            DocumentsBLL.Delete(new Guid(Convert.ToString(str)));
            imgDelete.Visible = false;
            aQuarterCertificate.Visible = false;
            IsInsert = true;
            lblRentPayoutmsg.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();

        }
        protected void btnQuarterDetailSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (this.QuarterID != null && this.QuarterID != Guid.Empty)
                    {
                        RentPayOutPerQuarter objRentPayoutDetails = new RentPayOutPerQuarter();
                        objRentPayoutDetails.QuarterID = this.QuarterID;
                        objRentPayoutDetails.TotalAreaOfComplex = Convert.ToDecimal(txtDisplayTotalAreaOfComplex.Text.Trim());
                        objRentPayoutDetails.SelfOccupiedArea = Convert.ToDecimal(txtDisplaySelfOccupiedArea.Text.Trim());
                        objRentPayoutDetails.AreaUnderPMS = Convert.ToDecimal(txtDisplayNetAreaUnderPMS.Text.Trim());
                        objRentPayoutDetails.RoomRentCollected = Convert.ToDecimal(txtDisplayRoomRentForPeriod.Text.Trim());

                        if (txtInterestOnRoomRent.Text.Trim() != "")
                            objRentPayoutDetails.InterestOnRoomRent = Convert.ToDecimal(txtInterestOnRoomRent.Text.Trim());

                        if (txtPropertyMgmtFees.Text.Trim() != string.Empty)
                            objRentPayoutDetails.PropertyManagementCharge = Convert.ToDecimal(txtPropertyMgmtFees.Text.Trim());
                        else
                            objRentPayoutDetails.PropertyManagementCharge = 0;



                        if (txtServiceTax.Text.Trim() != string.Empty)
                            objRentPayoutDetails.ServiceTax = Convert.ToDecimal(txtServiceTax.Text.Trim());
                        else
                            objRentPayoutDetails.ServiceTax = 0;

                        if (txtBankCharges.Text.Trim() != string.Empty)
                            objRentPayoutDetails.BankCharges = Convert.ToDecimal(txtBankCharges.Text.Trim());
                        else
                            objRentPayoutDetails.BankCharges = 0;

                        if (ltrTotalAmountToDeduct.Text.Trim() != string.Empty)
                            objRentPayoutDetails.TotalAmountToDeduct = Convert.ToDecimal(ltrTotalAmountToDeduct.Text.Trim());
                        else
                            objRentPayoutDetails.TotalAmountToDeduct = 0;

                        objRentPayoutDetails.TotalAmountToDistribute = Convert.ToDecimal(litDispTotalRoomRentTodistribute.Text.Trim());

                        objRentPayoutDetails.NetAmountToDistribute = Convert.ToDecimal(litDisplayRentToDistributed.Text.Trim());
                        objRentPayoutDetails.RentYieldPerSqft = Convert.ToDecimal(litDisplayRentYieldPerSFT.Text.Trim());
                        objRentPayoutDetails.RentYieldPerDay = Convert.ToDecimal(litDisplayRentYieldPerDay.Text.Trim());
                        objRentPayoutDetails.CompanyID = this.CompanyID;
                        objRentPayoutDetails.CreatedOn = DateTime.Now;
                        objRentPayoutDetails.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objRentPayoutDetails.IsActive = true;
                        RentPayOutPerQuarterBLL.Save(objRentPayoutDetails);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objRentPayoutDetails.ToString(), objRentPayoutDetails.ToString(), "mst_RentPayOutPerQuarter");

                        ClearDetailControl();
                        btnQuarterDetailSave.Visible = false;
                        IsInsertForDetails = true;
                        lblRentDetailsmsg.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void txtDisplayTotalAreaOfComplex_TextChange(object sender, EventArgs e)
        {
            txtDisplaySelfOccupiedArea_TextChange(sender, e);
        }
        protected void txtDisplaySelfOccupiedArea_TextChange(object sender, EventArgs e)
        {
            decimal dcmlAreaOfComplex = Convert.ToDecimal("0.000000");
            decimal dcmlSelfOccupiedArea = Convert.ToDecimal("0.000000");
            decimal dcmlAreaUnderPMS = Convert.ToDecimal("0.000000");

            if (txtDisplayTotalAreaOfComplex.Text.Trim() != "" && Convert.ToDecimal(txtDisplayTotalAreaOfComplex.Text.Trim()) > 0)
                dcmlAreaOfComplex = Convert.ToDecimal(txtDisplayTotalAreaOfComplex.Text.Trim());

            if (txtDisplaySelfOccupiedArea.Text.Trim() != "" && Convert.ToDecimal(txtDisplaySelfOccupiedArea.Text.Trim()) > 0)
                dcmlSelfOccupiedArea = Convert.ToDecimal(txtDisplaySelfOccupiedArea.Text.Trim());

            dcmlAreaUnderPMS = dcmlAreaOfComplex - dcmlSelfOccupiedArea;

            txtDisplayNetAreaUnderPMS.Text = Math.Round(dcmlAreaUnderPMS).ToString(); // dcmlAreaUnderPMS.ToString().Contains(".") == true ? dcmlAreaUnderPMS.ToString().Substring(0, dcmlAreaUnderPMS.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("0")) : dcmlAreaUnderPMS.ToString();

            txtDisplayNetAreaUnderPMS_TextChange(sender, e);
        }
        protected void txtDisplayNetAreaUnderPMS_TextChange(object sender, EventArgs e)
        {
            decimal dcmlRentYieldPersft = Convert.ToDecimal("0.000000");
            decimal dcmlRentToDistribute = Convert.ToDecimal(litDisplayRentToDistributed.Text);
            decimal dcmlRentYieldPersDay = Convert.ToDecimal("0.000000");

            if (txtDisplayNetAreaUnderPMS.Text.Trim() != "" && Convert.ToDecimal(txtDisplayNetAreaUnderPMS.Text.Trim()) > 0)
                dcmlRentYieldPersft = Convert.ToDecimal((dcmlRentToDistribute / Convert.ToDecimal(txtDisplayNetAreaUnderPMS.Text)));

            litDisplayRentYieldPerSFT.Text = Math.Round(dcmlRentYieldPersft, 3).ToString(); // dcmlRentYieldPersft.ToString().Contains(".") == true ? dcmlRentYieldPersft.ToString().Substring(0, dcmlRentYieldPersft.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("2")) : dcmlRentYieldPersft.ToString();

            if (NoOfDays > 0)
                dcmlRentYieldPersDay = Convert.ToDecimal((dcmlRentYieldPersft / Convert.ToDecimal(NoOfDays)));

            litDisplayRentYieldPerDay.Text = Math.Round(dcmlRentYieldPersDay, 3).ToString(); //dcmlRentYieldPersDay.ToString().Contains(".") == true ? dcmlRentYieldPersDay.ToString().Substring(0, dcmlRentYieldPersDay.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("2")) : dcmlRentYieldPersDay.ToString();
        }
        protected void txtServiceTax_TextChanged(object sender, EventArgs e)
        {
            txtInterestOnRoomRent_TextChanged(sender, e);
        }
        protected void txtDisplayRoomRentForPeriod_TextChanged(object sender, EventArgs e)
        {
            txtInterestOnRoomRent_TextChanged(null, null);
        }
        protected void txtInterestOnRoomRent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal dcmlTotalAmtToDistribute = Convert.ToDecimal("0.000000");
                decimal dsmlLessProperytmgmgfees = Convert.ToDecimal("0.000000");
                decimal dsmlTotalRoomrentToDistribute = Convert.ToDecimal("0.000000");
                decimal dcmlNetRentToDistribute = Convert.ToDecimal("0.000000");
                decimal dcmlRentYieldPersft = Convert.ToDecimal("0.000000");
                decimal dcmlRentYieldPersDay = Convert.ToDecimal("0.000000");

                dcmlTotalAmtToDistribute = Convert.ToDecimal((Convert.ToDecimal(txtDisplayRoomRentForPeriod.Text.Trim() != "" ? Convert.ToDecimal(txtDisplayRoomRentForPeriod.Text) : Convert.ToDecimal("0.00")))); // + Convert.ToDecimal(txtInterestOnRoomRent.Text.Trim() != "" ? Convert.ToDecimal(txtInterestOnRoomRent.Text.Trim()) : Convert.ToDecimal("0.00"))));

                if (PropertymgmtPercentage != null && PropertymgmtPercentage != "")
                {
                    litDisppropertymangeper.Text = PropertymgmtPercentage.Substring(0, PropertymgmtPercentage.LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    //dsmlLessProperytmgmgfees = Convert.ToDecimal(((dcmlTotalAmtToDistribute * Convert.ToDecimal(PropertymgmtPercentage)) / 100));
                }

                if (txtPropertyMgmtFees.Text.Trim() != string.Empty)
                    dsmlLessProperytmgmgfees = Convert.ToDecimal(txtPropertyMgmtFees.Text.Trim()); // txtPropertyMgmtFees.Text = dsmlLessProperytmgmgfees.ToString().Contains(".") == true ? dsmlLessProperytmgmgfees.ToString().Substring(0, dsmlLessProperytmgmgfees.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("2")) : dsmlLessProperytmgmgfees.ToString();

                decimal dcmlServiceTax = Convert.ToDecimal("0.000000");
                decimal dcmlBankCharges = Convert.ToDecimal("0.000000");
                decimal dcmlTotalAmountToDeduct = Convert.ToDecimal("0.000000");

                if (txtServiceTax.Text.Trim() != string.Empty)
                    dcmlServiceTax = Convert.ToDecimal(txtServiceTax.Text.Trim());
                if (txtBankCharges.Text.Trim() != string.Empty)
                    dcmlBankCharges = Convert.ToDecimal(txtBankCharges.Text.Trim());

                dcmlTotalAmountToDeduct = dsmlLessProperytmgmgfees + dcmlServiceTax + dcmlBankCharges;
                ltrTotalAmountToDeduct.Text = Math.Round(dcmlTotalAmountToDeduct).ToString(); //dcmlTotalAmountToDeduct.ToString().Substring(0, dcmlTotalAmountToDeduct.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("2"));

                dsmlTotalRoomrentToDistribute = dcmlTotalAmtToDistribute - dcmlTotalAmountToDeduct;
                litDispTotalRoomRentTodistribute.Text = Math.Round(dsmlTotalRoomrentToDistribute).ToString(); // dsmlTotalRoomrentToDistribute.ToString().Contains(".") == true ? dsmlTotalRoomrentToDistribute.ToString().Substring(0, dsmlTotalRoomrentToDistribute.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("2")) : dsmlTotalRoomrentToDistribute.ToString();

                dcmlNetRentToDistribute = Convert.ToDecimal(dsmlTotalRoomrentToDistribute) + Convert.ToDecimal(txtInterestOnRoomRent.Text.Trim() != "" ? Convert.ToDecimal(txtInterestOnRoomRent.Text.Trim()) : Convert.ToDecimal("0.00"));
                litDisplayRentToDistributed.Text = Math.Round(dcmlNetRentToDistribute).ToString(); //dcmlNetRentToDistribute.ToString().Contains(".") == true ? dcmlNetRentToDistribute.ToString().Substring(0, dcmlNetRentToDistribute.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("2")) : dcmlNetRentToDistribute.ToString();

                if (txtDisplayNetAreaUnderPMS.Text != "")
                    dcmlRentYieldPersft = Convert.ToDecimal((dcmlNetRentToDistribute / Convert.ToDecimal(txtDisplayNetAreaUnderPMS.Text)));

                litDisplayRentYieldPerSFT.Text = Math.Round(dcmlRentYieldPersft, 3).ToString(); //dcmlRentYieldPersft.ToString().Substring(0, dcmlRentYieldPersft.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("3"));

                if (NoOfDays > 0)
                    dcmlRentYieldPersDay = Convert.ToDecimal((dcmlRentYieldPersft / Convert.ToDecimal(NoOfDays)));

                litDisplayRentYieldPerDay.Text = Math.Round(dcmlRentYieldPersDay, 3).ToString(); //dcmlRentYieldPersDay.ToString().Contains(".") == true ? dcmlRentYieldPersDay.ToString().Substring(0, dcmlRentYieldPersft.ToString().LastIndexOf(".") + 1 + Convert.ToInt16("3")) : dcmlRentYieldPersDay.ToString();

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Event
        protected void gvRentPayoutQuarterSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvRentPayoutQuarterSetup.PageIndex = e.NewPageIndex;
                BindRentPayoutHeaderData();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRentPayoutQuarterSetup_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblGvStartDate = (Label)e.Row.FindControl("lblGvStartDate");
                if (DataBinder.Eval(e.Row.DataItem, "StartDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StartDate")) != "")
                {
                    lblGvStartDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "StartDate")).ToString("dd-MM-yyyy");
                }
                else
                {
                    lblGvStartDate.Text = "";
                }


                Label lblGvEndDate = (Label)e.Row.FindControl("lblGvEndDate");
                if (DataBinder.Eval(e.Row.DataItem, "EndDate") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EndDate")) != "")
                {
                    lblGvEndDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "EndDate")).ToString("dd-MM-yyyy");
                }
                else
                {
                    lblGvEndDate.Text = "";
                }

                Label lblGvPropertyManagementCharge = (Label)e.Row.FindControl("lblGvPropertyManagementCharge");
                if (DataBinder.Eval(e.Row.DataItem, "PropertyManagementCharge") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PropertyManagementCharge")) != "")
                {
                    lblGvPropertyManagementCharge.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PropertyManagementCharge")).Substring(0, Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PropertyManagementCharge")).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                }
                else
                {
                    lblGvPropertyManagementCharge.Text = "";
                }
            }
        }

        protected void gvRentPayoutQuarterSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("QUARTEREDIT"))
            {
                ClearControl();
                this.QuarterIDForHeader = new Guid(e.CommandArgument.ToString());
                RentPayoutQuarterSetup objRentPayoutQuarterData = new RentPayoutQuarterSetup();
                objRentPayoutQuarterData = RentPayoutQuarterSetupBLL.GetByPrimaryKey(this.QuarterIDForHeader);
                if (objRentPayoutQuarterData != null)
                {
                    List<RentPayOutPerQuarter> objRentPerPauoutDataForEdit = RentPayOutPerQuarterBLL.GetAllBy(RentPayOutPerQuarter.RentPayOutPerQuarterFields.QuarterID, Convert.ToString(this.QuarterIDForHeader));
                    if (objRentPerPauoutDataForEdit.Count > 0)
                    {
                        txtStartDate.Enabled = false;
                        txtEndDate.Enabled = false;
                        IsToHideDateImages = true;
                        txtPropertymgmtcharge.Enabled = false;
                    }
                    else
                    {
                        txtStartDate.Enabled = true;
                        txtEndDate.Enabled = true;
                        IsToHideDateImages = false;
                        txtPropertymgmtcharge.Enabled = true;
                    }
                    txtQuarterTitle.Text = Convert.ToString(objRentPayoutQuarterData.Title);

                    if (objRentPayoutQuarterData.StartDate != null && Convert.ToString(objRentPayoutQuarterData.StartDate) != "")
                        txtStartDate.Text = Convert.ToDateTime(objRentPayoutQuarterData.StartDate).ToString(this.DateFormat);
                    else
                        txtStartDate.Text = "";


                    if (objRentPayoutQuarterData.EndDate != null && Convert.ToString(objRentPayoutQuarterData.EndDate) != "")
                        txtEndDate.Text = Convert.ToDateTime(objRentPayoutQuarterData.EndDate).ToString(this.DateFormat);
                    else
                        txtEndDate.Text = "";


                    if (objRentPayoutQuarterData.PropertyManagementCharge != null && Convert.ToString(objRentPayoutQuarterData.PropertyManagementCharge) != "")
                        txtPropertymgmtcharge.Text = Convert.ToString(objRentPayoutQuarterData.PropertyManagementCharge).Substring(0, Convert.ToString(objRentPayoutQuarterData.PropertyManagementCharge).LastIndexOf(".") + 1 + Convert.ToInt16("2"));
                    else
                        txtPropertymgmtcharge.Text = "";


                    txtNote.Text = Convert.ToString(objRentPayoutQuarterData.Note);
                    List<Documents> Lst = DocumentsBLL.GetAllBy(Documents.DocumentsFields.AssociationID, objRentPayoutQuarterData.QuarterID.ToString());
                    if (Lst.Count > 0)
                    {
                        string str = "~/Document/" + Lst[0].DocumentName;
                        aQuarterCertificate.Visible = true;
                        aQuarterCertificate.HRef = str;

                        imgDelete.CommandArgument = Convert.ToString(Lst[0].DocumentID);
                        imgDelete.Visible = true;
                    }
                    else
                    {
                        aQuarterCertificate.Visible = false;
                        imgDelete.Visible = false;
                    }

                    mvRentPayoutHeader.ActiveViewIndex = 1;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                }

            }

        }
        #endregion Grid Event
	}
}