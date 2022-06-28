using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlRateCardRoomTypes : System.Web.UI.UserControl
    {
        #region Property And Variables
        public string ParentType
        {
            get
            {
                return ViewState["ParentType"] != null ? Convert.ToString(ViewState["ParentType"]) : string.Empty;
            }
            set
            {
                ViewState["ParentType"] = value;
            }
        }

        //public Guid RateCardID
        //{
        //    get
        //    {
        //        return ViewState["RateCardID"] != null ? new Guid(Convert.ToString(ViewState["RateCardID"])) : Guid.Empty;
        //    }
        //    set
        //    {
        //        ViewState["RateCardID"] = value;
        //    }
        //}

        public GridView gvucRoomTypes
        {
            get { return this.gvRoomTypes; }
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

        public DataTable dtExistingDetails = null;

        public List<ProjectTerm> lstPostingFrequency = null;

        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
                SetControlVisibility();
                ////BindRoomTypeGrid();
            }
        }
        #endregion

        #region Methods
        private void SetPageLables()
        {
            litHeaderRoomTypes.Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblHeaderRoomTypes", "Room Types");
            chkEnableDayRates.Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblEnableDayRates", "Enable Day Rates");
        }

        private void SetControlVisibility()
        {
            ////if (this.ParentType == "PACKAGERATECARD")
            ////{
            //for (int i = 10; i < 17; i++)
            //{
            //    gvRoomTypes.Columns[i].Visible = false;
            //}

            //gvRoomTypes.Width = 700;
            chkEnableDayRates.Visible = false;
            ////}
        }

        //private void BindRoomTypeGrid()
        //{
        //    // To manage record in textboxes on checked change.
        //    //DataSet dsRoomType = RoomTypeBLL.GetAllForRateCard(clsSession.PropertyID, this.RateCardID);
        //    //if (dsRoomType.Tables.Count > 1)
        //    //{
        //    //    dtExistingDetails = dsRoomType.Tables[1];
        //    //}

        //    //ucRateCardRoomTypes.gvucRoomTypes.DataSource = dsRoomType.Tables[0];
        //    //ucRateCardRoomTypes.gvucRoomTypes.DataBind();
        //}

        private void BindPostingFrequency()
        {
            lstPostingFrequency = new List<ProjectTerm>();
            lstPostingFrequency = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "ROOM SERVICE POSTING FREQUENCY");
        }

        #endregion

        #region Control Events
        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;

            if (chkSelect != null)
            {
                int rowIndex = Convert.ToInt32(hfRowIndex.Value);
                TextBox txtRackRate = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtRackRate");
                TextBox txtDeposit = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtDeposit");
                TextBox txtTotalRackRate = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtTotalRackRate");
                LinkButton lnkView = (LinkButton)gvRoomTypes.Rows[rowIndex].FindControl("lnkView");
                ////ImageButton imgbtnRefreshTax = (ImageButton)gvRoomTypes.Rows[rowIndex].FindControl("imgbtnRefreshTax");
                TextBox txtExtraBedCharge = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtExtraBedCharge");

                TextBox txtMonday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtMonday");
                TextBox txtTuesday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtTuesday");
                TextBox txtWednesday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtWednesday");
                TextBox txtThursday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtThursday");
                TextBox txtFriday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtFriday");
                TextBox txtSaturday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtSaturday");
                TextBox txtSunday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtSunday");
                RequiredFieldValidator rfvRackRate = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvRackRate");
                RequiredFieldValidator rfvDeposit = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvDeposit");
                RequiredFieldValidator rfvTotalRackRate = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvTotalRackRate");
                RequiredFieldValidator rfvExtraBedCharge = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvExtraBedCharge");

                if (chkSelect.Checked)
                {
                    rfvExtraBedCharge.Enabled = rfvRackRate.Enabled = rfvDeposit.Enabled = rfvTotalRackRate.Enabled = txtExtraBedCharge.Enabled = txtDeposit.Enabled = txtTotalRackRate.Enabled = true; //// txtExtraAdult.Enabled = txtExtraChild.Enabled = true;
                    lnkView.Enabled = txtMonday.Enabled = txtTuesday.Enabled = txtWednesday.Enabled = txtThursday.Enabled = txtFriday.Enabled = txtSaturday.Enabled = txtSunday.Enabled = true;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regRackRate")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regDeposit")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTotalRackRate")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regExtraBedCharge")).Enabled = true;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regMonday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTuesday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regWednesday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regThursday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regFriday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSaturday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSunday")).Enabled = true;
                }
                else
                {
                    rfvExtraBedCharge.Enabled = rfvRackRate.Enabled = rfvDeposit.Enabled = rfvTotalRackRate.Enabled = txtExtraBedCharge.Enabled = txtDeposit.Enabled = txtTotalRackRate.Enabled = false;
                    lnkView.Enabled = txtMonday.Enabled = txtTuesday.Enabled = txtWednesday.Enabled = txtThursday.Enabled = txtFriday.Enabled = txtSaturday.Enabled = txtSunday.Enabled = false;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regRackRate")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regDeposit")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTotalRackRate")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regExtraBedCharge")).Enabled = false;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regMonday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTuesday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regWednesday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regThursday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regFriday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSaturday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSunday")).Enabled = false;

                }
            }
        }

        protected void chkEnableDayRates_OnCheckedChanged(object sender, EventArgs e)
        {
            #region Commented Code
            /*
            DataTable dtRoomTypes = new DataTable();
            DataColumn clRoomTypeID = new DataColumn("RoomTypeID");
            DataColumn clIsSelect = new DataColumn("IsSelect");
            DataColumn clRoomTypeName = new DataColumn("RoomTypeName");
            DataColumn clRackRate = new DataColumn("RackRate");
            DataColumn clExtraAdultRate = new DataColumn("ExtraAdultRate");
            DataColumn clChildRate = new DataColumn("ChildRate");
            DataColumn clMondayRate = new DataColumn("MondayRate");
            DataColumn clTuesdayRate = new DataColumn("TuesdayRate");
            DataColumn clWednesdayRate = new DataColumn("WednesdayRate");
            DataColumn clThursdayRate = new DataColumn("ThursdayRate");
            DataColumn clFridayRate = new DataColumn("FridayRate");
            DataColumn clSaturdayRate = new DataColumn("SaturdayRate");
            DataColumn clSundayRate = new DataColumn("SundayRate");

            dtRoomTypes.Columns.Add(clRoomTypeID);
            dtRoomTypes.Columns.Add(clIsSelect);
            dtRoomTypes.Columns.Add(clRoomTypeName);
            dtRoomTypes.Columns.Add(clRackRate);
            dtRoomTypes.Columns.Add(clExtraAdultRate);
            dtRoomTypes.Columns.Add(clChildRate);
            dtRoomTypes.Columns.Add(clMondayRate);
            dtRoomTypes.Columns.Add(clTuesdayRate);
            dtRoomTypes.Columns.Add(clWednesdayRate);
            dtRoomTypes.Columns.Add(clThursdayRate);
            dtRoomTypes.Columns.Add(clFridayRate);
            dtRoomTypes.Columns.Add(clSaturdayRate);
            dtRoomTypes.Columns.Add(clSundayRate);

            for (int i = 0; i < gvRoomTypes.Rows.Count; i++)
            {
                DataRow drToAdd = dtRoomTypes.NewRow();

                CheckBox chkSelect = (CheckBox)gvRoomTypes.Rows[i].FindControl("chkSelect");
                Label lblRoomType = (Label)gvRoomTypes.Rows[i].FindControl("lblRoomType");
                TextBox txtRackRate = (TextBox)gvRoomTypes.Rows[i].FindControl("txtRackRate");
                TextBox txtExtraAdult = (TextBox)gvRoomTypes.Rows[i].FindControl("txtExtraAdult");
                TextBox txtExtraChild = (TextBox)gvRoomTypes.Rows[i].FindControl("txtExtraChild");
                TextBox txtMonday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtMonday");
                TextBox txtTuesday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtTuesday");
                TextBox txtWednesday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtWednesday");
                TextBox txtThursday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtThursday");
                TextBox txtFriday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtFriday");
                TextBox txtSaturday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtSaturday");
                TextBox txtSunday = (TextBox)gvRoomTypes.Rows[i].FindControl("txtSunday");

                if (chkSelect != null && chkSelect.Checked == true)
                {
                    drToAdd["RoomTypeID"] = Convert.ToString(gvRoomTypes.DataKeys[i]["RoomTypeID"]);

                    drToAdd["IsSelect"] = "True";

                    if (lblRoomType != null)
                        drToAdd["RoomTypeName"] = lblRoomType.Text.Trim();

                    if (txtRackRate != null)
                        drToAdd["RackRate"] = txtRackRate.Text.Trim() + "000000";

                    if (txtExtraAdult != null)
                        drToAdd["ExtraAdultRate"] = txtExtraAdult.Text.Trim() + "000000";

                    if (txtExtraChild != null)
                        drToAdd["ChildRate"] = txtExtraChild.Text.Trim() + "000000";

                    if (txtMonday != null)
                        drToAdd["MondayRate"] = txtMonday.Text.Trim() + "000000";

                    if (txtTuesday != null)
                        drToAdd["TuesdayRate"] = txtTuesday.Text.Trim() + "000000";

                    if (txtWednesday != null)
                        drToAdd["WednesdayRate"] = txtWednesday.Text.Trim() + "000000";

                    if (txtThursday != null)
                        drToAdd["ThursdayRate"] = txtThursday.Text.Trim() + "000000";

                    if (txtFriday != null)
                        drToAdd["FridayRate"] = txtFriday.Text.Trim() + "000000";

                    if (txtSaturday != null)
                        drToAdd["SaturdayRate"] = txtSaturday.Text.Trim() + "000000";

                    if (txtSunday != null)
                        drToAdd["SundayRate"] = txtSunday.Text.Trim() + "000000";

                    dtRoomTypes.Rows.Add(drToAdd);
                }
            }

            dtExistingDetails = dtRoomTypes;

            DataSet dsRoomType = RoomTypeBLL.GetAllForRateCard(clsSession.PropertyID, this.RateCardID);

            for (int i = 0; i < dsRoomType.Tables[0].Rows.Count; i++)
            {
                DataRow[] rows = dtExistingDetails.Select("RoomTypeID = '" + Convert.ToString(dsRoomType.Tables[0].Rows[i]["RoomTypeID"]) + "'");
                if (rows.Length > 0)
                {
                    dsRoomType.Tables[0].Rows[i]["RackRate"] = rows[0]["RackRate"];
                    dsRoomType.Tables[0].Rows[i]["ExtraAdultRate"] = rows[0]["ExtraAdultRate"];
                    dsRoomType.Tables[0].Rows[i]["ChildRate"] = rows[0]["ChildRate"];
                    dsRoomType.Tables[0].Rows[i]["MondayRate"] = rows[0]["MondayRate"];
                    dsRoomType.Tables[0].Rows[i]["TuesdayRate"] = rows[0]["TuesdayRate"];
                    dsRoomType.Tables[0].Rows[i]["WednesdayRate"] = rows[0]["WednesdayRate"];
                    dsRoomType.Tables[0].Rows[i]["ThursdayRate"] = rows[0]["ThursdayRate"];
                    dsRoomType.Tables[0].Rows[i]["FridayRate"] = rows[0]["FridayRate"];
                    dsRoomType.Tables[0].Rows[i]["SaturdayRate"] = rows[0]["SaturdayRate"];
                    dsRoomType.Tables[0].Rows[i]["SundayRate"] = rows[0]["SundayRate"];
                }
            }
             * */
            #endregion

            if (chkEnableDayRates.Checked)
            {
                gvRoomTypes.Columns[6].Visible = true;
                gvRoomTypes.Columns[7].Visible = true;
                gvRoomTypes.Columns[8].Visible = true;
                gvRoomTypes.Columns[9].Visible = true;
                gvRoomTypes.Columns[10].Visible = true;
                gvRoomTypes.Columns[11].Visible = true;
                gvRoomTypes.Columns[12].Visible = true;
                gvRoomTypes.Columns[12].Visible = true;
                //for (int i = 6; i < 13; i++)
                //{
                //    gvRoomTypes.Columns[i].Visible = true;
                //}
            }
            else
            {
                gvRoomTypes.Columns[6].Visible = false;
                gvRoomTypes.Columns[7].Visible = false;
                gvRoomTypes.Columns[8].Visible = false;
                gvRoomTypes.Columns[9].Visible = false;
                gvRoomTypes.Columns[10].Visible = false;
                gvRoomTypes.Columns[11].Visible = false;
                gvRoomTypes.Columns[12].Visible = false;
                gvRoomTypes.Columns[12].Visible = false;
                //for (int i = 6; i < 13; i++)
                //{
                //    gvRoomTypes.Columns[i].Visible = false;
                //}
            }


            //gvucRoomTypes.DataSource = dsRoomType.Tables[0];
            //gvucRoomTypes.DataBind();
        }

        protected void chkSelectChargePerDay_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;

            if (chkSelect != null)
            {
                int rowIndex = Convert.ToInt32(hfRowIndex.Value);
                TextBox txtRackRate = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtRackRate");
                TextBox txtDeposit = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtDeposit");
                TextBox txtTotalRackRate = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtTotalRackRate");
                LinkButton lnkView = (LinkButton)gvRoomTypes.Rows[rowIndex].FindControl("lnkView");
                ////ImageButton imgbtnRefreshTax = (ImageButton)gvRoomTypes.Rows[rowIndex].FindControl("imgbtnRefreshTax");
                TextBox txtExtraBedCharge = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtExtraBedCharge");

                TextBox txtMonday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtMonday");
                TextBox txtTuesday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtTuesday");
                TextBox txtWednesday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtWednesday");
                TextBox txtThursday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtThursday");
                TextBox txtFriday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtFriday");
                TextBox txtSaturday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtSaturday");
                TextBox txtSunday = (TextBox)gvRoomTypes.Rows[rowIndex].FindControl("txtSunday");
                RequiredFieldValidator rfvRackRate = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvRackRate");
                RequiredFieldValidator rfvDeposit = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvDeposit");
                RequiredFieldValidator rfvTotalRackRate = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvTotalRackRate");
                RequiredFieldValidator rfvExtraBedCharge = (RequiredFieldValidator)gvRoomTypes.Rows[rowIndex].FindControl("rfvExtraBedCharge");

                if (chkSelect.Checked)
                {
                    rfvExtraBedCharge.Enabled = rfvRackRate.Enabled = rfvDeposit.Enabled = rfvTotalRackRate.Enabled = txtExtraBedCharge.Enabled = txtDeposit.Enabled = txtTotalRackRate.Enabled = true; //// txtExtraAdult.Enabled = txtExtraChild.Enabled = true;
                    lnkView.Enabled = txtMonday.Enabled = txtTuesday.Enabled = txtWednesday.Enabled = txtThursday.Enabled = txtFriday.Enabled = txtSaturday.Enabled = txtSunday.Enabled = true;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regRackRate")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regDeposit")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTotalRackRate")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regExtraBedCharge")).Enabled = true;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regMonday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTuesday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regWednesday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regThursday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regFriday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSaturday")).Enabled = true;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSunday")).Enabled = true;
                }
                else
                {
                    rfvExtraBedCharge.Enabled = rfvRackRate.Enabled = rfvDeposit.Enabled = rfvTotalRackRate.Enabled = txtExtraBedCharge.Enabled = txtDeposit.Enabled = txtTotalRackRate.Enabled = false;
                    lnkView.Enabled = txtMonday.Enabled = txtTuesday.Enabled = txtWednesday.Enabled = txtThursday.Enabled = txtFriday.Enabled = txtSaturday.Enabled = txtSunday.Enabled = false;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regRackRate")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regDeposit")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTotalRackRate")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regExtraBedCharge")).Enabled = false;

                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regMonday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regTuesday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regWednesday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regThursday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regFriday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSaturday")).Enabled = false;
                    ((RegularExpressionValidator)gvRoomTypes.Rows[rowIndex].FindControl("regSunday")).Enabled = false;

                }
            }
        }

        protected void btnCancelComplimentoryServices_Click(object sender, EventArgs e)
        {
            DataTable dtComplimentoryServices = new DataTable();

            DataColumn dc1 = new DataColumn("RoomTypeID");
            DataColumn dc2 = new DataColumn("ItemID");
            DataColumn dc3 = new DataColumn("TermID");

            dtComplimentoryServices.Columns.Add(dc1);
            dtComplimentoryServices.Columns.Add(dc2);
            dtComplimentoryServices.Columns.Add(dc3);

            if (Session["ComplimentoryServices"] != null)
            {
                dtComplimentoryServices = (DataTable)Session["ComplimentoryServices"];
            }

            for (int i = 0; i < gvRoomTypeComplimentoryServices.Rows.Count; i++)
            {
                CheckBox chkSelectComplimentoryServices = (CheckBox)gvRoomTypeComplimentoryServices.Rows[i].FindControl("chkSelectComplimentoryServices");
                string ItemID = Convert.ToString(gvRoomTypeComplimentoryServices.DataKeys[i]["ItemID"]);

                if (chkSelectComplimentoryServices.Checked)
                {
                    DropDownList ddlPostingFrequency = (DropDownList)gvRoomTypeComplimentoryServices.Rows[i].FindControl("ddlPostingFrequency");

                    if (Session["ComplimentoryServices"] != null)
                    {
                        DataRow[] drInsert = dtComplimentoryServices.Select("ItemID = '" + Convert.ToString(gvRoomTypeComplimentoryServices.DataKeys[i]["ItemID"]) + "' and RoomTypeID = '" + Convert.ToString(this.RoomTypeID) + "'");
                        if (drInsert.Length > 0)
                        {
                            drInsert[0].Delete();
                            dtComplimentoryServices.AcceptChanges();
                        }

                        DataRow dr = dtComplimentoryServices.NewRow();

                        dr["RoomTypeID"] = Convert.ToString(this.RoomTypeID);
                        dr["ItemID"] = ItemID;
                        dr["TermID"] = Convert.ToString(ddlPostingFrequency.SelectedValue);

                        dtComplimentoryServices.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dtComplimentoryServices.NewRow();

                        dr["RoomTypeID"] = Convert.ToString(this.RoomTypeID);
                        dr["ItemID"] = ItemID;
                        dr["TermID"] = Convert.ToString(ddlPostingFrequency.SelectedValue);

                        dtComplimentoryServices.Rows.Add(dr);
                    }
                }
                else
                {
                    if (Session["ComplimentoryServices"] != null)
                    {
                        for (int j = 0; j < dtComplimentoryServices.Rows.Count; j++)
                        {
                            DataRow[] drselect = dtComplimentoryServices.Select("ItemID = '" + Convert.ToString(gvRoomTypeComplimentoryServices.DataKeys[i]["ItemID"]) + "' and RoomTypeID = '" + Convert.ToString(this.RoomTypeID) + "'");
                            //if (Convert.ToString(dtComplimentoryServices.Rows[i]["ItemID"]) == Convert.ToString(gvRoomTypeComplimentoryServices.DataKeys[i]["ItemID"]) && Convert.ToString(dtComplimentoryServices.Rows[i]["RoomTypeID"]) == Convert.ToString(this.RoomTypeID))
                            if (drselect.Length > 0)
                            {
                                //dtComplimentoryServices.Rows.Remove(drselect[j]);
                                drselect[0].Delete();
                                dtComplimentoryServices.AcceptChanges();
                            }
                        }
                    }
                }
            }

            Session["ComplimentoryServices"] = dtComplimentoryServices;
        }

        #endregion

        #region Grid Events
        protected void gvRoomTypes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.Attributes.Add("onclick", "fnSetRowIndex('" + Convert.ToString(e.Row.DataItemIndex) + "');");

                RegularExpressionValidator regRackRate = (RegularExpressionValidator)e.Row.FindControl("regRackRate");
                RegularExpressionValidator regDeposit = (RegularExpressionValidator)e.Row.FindControl("regDeposit");
                RegularExpressionValidator regTotalRackRate = (RegularExpressionValidator)e.Row.FindControl("regTotalRackRate");
                RegularExpressionValidator regExtraBedCharge = (RegularExpressionValidator)e.Row.FindControl("regExtraBedCharge");

                RegularExpressionValidator regMonday = (RegularExpressionValidator)e.Row.FindControl("regMonday");
                RegularExpressionValidator regTuesday = (RegularExpressionValidator)e.Row.FindControl("regTuesday");
                RegularExpressionValidator regWednesday = (RegularExpressionValidator)e.Row.FindControl("regWednesday");
                RegularExpressionValidator regThursday = (RegularExpressionValidator)e.Row.FindControl("regThursday");
                RegularExpressionValidator regFriday = (RegularExpressionValidator)e.Row.FindControl("regFriday");
                RegularExpressionValidator regSaturday = (RegularExpressionValidator)e.Row.FindControl("regSaturday");
                RegularExpressionValidator regSunday = (RegularExpressionValidator)e.Row.FindControl("regSunday");

                int allowedDecimalPlace = Convert.ToInt32(clsSession.DigitsAfterDecimalPoint);
                string strRegExpression = "\\d{0,13}.\\d{0," + Convert.ToString(allowedDecimalPlace) + "}";

                regRackRate.ValidationExpression = regDeposit.ValidationExpression = regTotalRackRate.ValidationExpression = regExtraBedCharge.ValidationExpression = strRegExpression; ////regExtraAdult.ValidationExpression = regExtraChild.ValidationExpression = 
                regMonday.ValidationExpression = regTuesday.ValidationExpression = regWednesday.ValidationExpression = strRegExpression;
                regThursday.ValidationExpression = regFriday.ValidationExpression = regSaturday.ValidationExpression = regSunday.ValidationExpression = strRegExpression;

                string strTemp = string.Empty;

                TextBox txtRackRate = (TextBox)e.Row.FindControl("txtRackRate");
                strTemp = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RackRate"));
                if (strTemp != string.Empty)
                {
                    strTemp = strTemp + "000000";
                    txtRackRate.Text = strTemp.Substring(0, strTemp.LastIndexOf(".") + 1 + allowedDecimalPlace);
                }
                strTemp = string.Empty;

                TextBox txtDeposit = (TextBox)e.Row.FindControl("txtDeposit");
                strTemp = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepositAmount"));
                if (strTemp != string.Empty)
                {
                    strTemp = strTemp + "000000";
                    txtDeposit.Text = strTemp.Substring(0, strTemp.LastIndexOf(".") + 1 + allowedDecimalPlace);
                }
                strTemp = string.Empty;

                TextBox txtTotalRackRate = (TextBox)e.Row.FindControl("txtTotalRackRate");
                strTemp = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotalRackRate"));
                if (strTemp != string.Empty)
                {
                    strTemp = strTemp + "000000";
                    txtTotalRackRate.Text = strTemp.Substring(0, strTemp.LastIndexOf(".") + 1 + allowedDecimalPlace);
                }
                strTemp = string.Empty;

                TextBox txtExtraBedCharge = (TextBox)e.Row.FindControl("txtExtraBedCharge");
                strTemp = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ExtarbedCharge"));
                if (strTemp != string.Empty)
                {
                    strTemp = strTemp + "000000";
                    txtExtraBedCharge.Text = strTemp.Substring(0, strTemp.LastIndexOf(".") + 1 + allowedDecimalPlace);
                }
                strTemp = string.Empty;

                if (dtExistingDetails != null)
                {
                    DataRow[] rows = dtExistingDetails.Select("RoomTypeID = '" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomTypeID")) + "'");
                    if (rows.Length > 0)
                    {
                        ((RequiredFieldValidator)e.Row.FindControl("rfvRackRate")).Enabled = true;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvTotalRackRate")).Enabled = true;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvDeposit")).Enabled = true;
                        ((RequiredFieldValidator)e.Row.FindControl("rfvExtraBedCharge")).Enabled = true;
                        ((CheckBox)e.Row.FindControl("chkSelect")).Checked = true;
                        ((LinkButton)e.Row.FindControl("lnkView")).Enabled = true;

                        TextBox txtMonday = (TextBox)e.Row.FindControl("txtMonday");
                        TextBox txtTuesday = (TextBox)e.Row.FindControl("txtTuesday");
                        TextBox txtWednesday = (TextBox)e.Row.FindControl("txtWednesday");
                        TextBox txtThursday = (TextBox)e.Row.FindControl("txtThursday");
                        TextBox txtFriday = (TextBox)e.Row.FindControl("txtFriday");
                        TextBox txtSaturday = (TextBox)e.Row.FindControl("txtSaturday");
                        TextBox txtSunday = (TextBox)e.Row.FindControl("txtSunday");

                        txtDeposit.Enabled = txtTotalRackRate.Enabled = txtExtraBedCharge.Enabled = txtMonday.Enabled = txtTuesday.Enabled = txtWednesday.Enabled = true; ////txtExtraAdult.Enabled = txtExtraChild.Enabled = 
                        txtThursday.Enabled = txtFriday.Enabled = txtSaturday.Enabled = txtSunday.Enabled = true;

                        string strTempNew = string.Empty;
                        strTempNew = Convert.ToString(rows[0]["RackRate"]);
                        if (strTempNew != string.Empty)
                            txtRackRate.Text = strTempNew.Substring(0, strTempNew.LastIndexOf(".") + 1 + allowedDecimalPlace);
                        strTempNew = string.Empty;

                        strTempNew = Convert.ToString(rows[0]["DepositAmount"]);
                        if (strTempNew != string.Empty)
                            txtDeposit.Text = strTempNew.Substring(0, strTempNew.LastIndexOf(".") + 1 + allowedDecimalPlace);
                        strTempNew = string.Empty;

                        strTempNew = Convert.ToString(rows[0]["TotalRackRate"]);
                        if (strTempNew != string.Empty)
                            txtTotalRackRate.Text = strTempNew.Substring(0, strTempNew.LastIndexOf(".") + 1 + allowedDecimalPlace);
                        strTempNew = string.Empty;

                        strTempNew = Convert.ToString(rows[0]["ExtarbedCharge"]);
                        if (strTempNew != string.Empty)
                            txtExtraBedCharge.Text = strTempNew.Substring(0, strTempNew.LastIndexOf(".") + 1 + allowedDecimalPlace);
                        strTempNew = string.Empty;


                        string strMondayRate = Convert.ToString(rows[0]["MondayRate"]);
                        if (strMondayRate != string.Empty)
                            txtMonday.Text = strMondayRate.Substring(0, strMondayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strTuesdayRate = Convert.ToString(rows[0]["TuesdayRate"]);
                        if (strTuesdayRate != string.Empty)
                            txtTuesday.Text = strTuesdayRate.Substring(0, strTuesdayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strWednesdayRate = Convert.ToString(rows[0]["WednesdayRate"]);
                        if (strWednesdayRate != string.Empty)
                            txtWednesday.Text = strWednesdayRate.Substring(0, strWednesdayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strThursdayRate = Convert.ToString(rows[0]["ThursdayRate"]);
                        if (strThursdayRate != string.Empty)
                            txtThursday.Text = strThursdayRate.Substring(0, strThursdayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strFridayRate = Convert.ToString(rows[0]["FridayRate"]);
                        if (strFridayRate != string.Empty)
                            txtFriday.Text = strFridayRate.Substring(0, strFridayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strSaturdayRate = Convert.ToString(rows[0]["SaturdayRate"]);
                        if (strSaturdayRate != string.Empty)
                            txtSaturday.Text = strSaturdayRate.Substring(0, strSaturdayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);

                        string strSundayRate = Convert.ToString(rows[0]["SundayRate"]);
                        if (strSundayRate != string.Empty)
                            txtSunday.Text = strSundayRate.Substring(0, strSundayRate.LastIndexOf(".") + 1 + allowedDecimalPlace);
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Literal)e.Row.FindControl("litGvHdrSelect")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrSelect", "Select");
                ((Literal)e.Row.FindControl("litGvHdrRoomType")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrRoomType", "Room Type");
                ((Literal)e.Row.FindControl("litGvHdrRackRate")).Text = "Rack Rate/Night"; //clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrRackRate", "Rack Rate");
                ((Literal)e.Row.FindControl("litGvHdrTotalRackRate")).Text = "Rack Rate";
                ((Literal)e.Row.FindControl("litGvHdrMonday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrMonday", "MON");
                ((Literal)e.Row.FindControl("litGvHdrTuesday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrTuesday", "TUE");
                ((Literal)e.Row.FindControl("litGvHdrWednesday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrWednesday", "WED");
                ((Literal)e.Row.FindControl("litGvHdrThursday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrThursday", "THU");
                ((Literal)e.Row.FindControl("litGvHdrFriday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrFriday", "FRI");
                ((Literal)e.Row.FindControl("litGvHdrSaturday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrSaturday", "SAT");
                ((Literal)e.Row.FindControl("litGvHdrSunday")).Text = clsCommon.GetGlobalResourceText("RateCardRoomTypes", "lblGvHdrSunday", "SUN");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Literal)e.Row.FindControl("litNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        protected void gvRoomTypes_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("VIEWCOMPLMNTRYSERVICE"))
            {
                this.RoomTypeID = new Guid(Convert.ToString(e.CommandArgument));

                BindPostingFrequency();

                DataSet dsComplimentoryServices = RoomTypeBLL.SelectRoomTypeServices(clsSession.PropertyID, clsSession.CompanyID, this.RoomTypeID);

                gvRoomTypeComplimentoryServices.DataSource = dsComplimentoryServices;
                gvRoomTypeComplimentoryServices.DataBind();

                if (Session["ComplimentoryServices"] != null)
                {
                    DataTable dtData = (DataTable)Session["ComplimentoryServices"];
                    if (dtData.Rows.Count > 0)
                    {
                        for (int i = 0; i < gvRoomTypeComplimentoryServices.Rows.Count; i++)
                        {
                            DataRow[] dr = dtData.Select("RoomTypeID = '" + Convert.ToString(this.RoomTypeID) + "' and ItemID = '" + Convert.ToString(gvRoomTypeComplimentoryServices.DataKeys[i]["ItemID"]) + "'");

                            if (dr.Length > 0)
                            {
                                DropDownList ddlPostingFrequency = (DropDownList)gvRoomTypeComplimentoryServices.Rows[i].FindControl("ddlPostingFrequency");
                                ((CheckBox)gvRoomTypeComplimentoryServices.Rows[i].FindControl("chkSelectComplimentoryServices")).Checked = true;
                                ddlPostingFrequency.SelectedIndex = ddlPostingFrequency.Items.FindByValue(Convert.ToString(dr[0]["TermID"])) != null ? ddlPostingFrequency.Items.IndexOf(ddlPostingFrequency.Items.FindByValue(Convert.ToString(dr[0]["TermID"]))) : 0;
                            }
                            else
                                ((CheckBox)gvRoomTypeComplimentoryServices.Rows[i].FindControl("chkSelectComplimentoryServices")).Checked = false;
                        }
                    }
                }

                mpeAddEditService.Show();
            }
            //else if (e.CommandName.Equals("DELETEDATA"))
            //{
            //    this.CorporateID = new Guid(Convert.ToString(e.CommandArgument));
            //    mpeConfirmDelete.Show();
            //}
        }

        protected void gvRoomTypeComplimentoryServices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlPostingFrequency = (DropDownList)e.Row.FindControl("ddlPostingFrequency");
                
                ddlPostingFrequency.Items.Clear();

                if (lstPostingFrequency != null && lstPostingFrequency.Count != 0)
                {
                    ddlPostingFrequency.DataSource = lstPostingFrequency;
                    ddlPostingFrequency.DataTextField = "DisplayTerm";
                    ddlPostingFrequency.DataValueField = "TermID";
                    ddlPostingFrequency.DataBind();
                }
                else
                    ddlPostingFrequency.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }
        #endregion

        #region Textbox Event

        protected void txtTotalRackRate_textChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox txtTotalRackRate = (TextBox)row.FindControl("txtTotalRackRate");
            TextBox txtRackRate = (TextBox)row.FindControl("txtRackRate");
            TextBox txtExtraBedCharge = (TextBox)row.FindControl("txtExtraBedCharge");
            
            TextBox txtDeposit = (TextBox)row.FindControl("txtDeposit");
            TextBox txtTaxes = (TextBox)row.FindControl("txtTaxes");
            Label lblTotal = (Label)row.FindControl("lblTotal");

            if (txtTotalRackRate.Text.Trim() != "")
            {
                if (Session["MinDaysRequired"] != null)
                {
                    string strRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";

                    decimal days = Convert.ToDecimal(strRackRate) / Convert.ToDecimal(Convert.ToString(Session["MinDaysRequired"]));
                    txtRackRate.Text = days.ToString().Substring(0, days.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                    txtRackRate.Text = "";
            }
            else
                txtRackRate.Text = "";
            
            decimal dcDisplayDeposit = 0;
            decimal dcDisplayRackrate = 0;
            decimal dcDisplayTaxes = 0;

            if (txtDeposit.Text.Trim() != "")
            {
                string strDeposit = txtDeposit.Text.Trim().IndexOf('.') > -1 ? txtDeposit.Text.Trim() + "000000" : txtDeposit.Text.Trim() + ".000000";
                dcDisplayDeposit = Convert.ToDecimal(strDeposit);
            }

            if (txtTotalRackRate.Text.Trim() != "")
            {
                string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                dcDisplayRackrate = Convert.ToDecimal(strTotalRackRate);
            }

            if (txtTaxes.Text.Trim() != "")
            {
                string strTaxes = txtTaxes.Text.Trim().IndexOf('.') > -1 ? txtTaxes.Text.Trim() + "000000" : txtTaxes.Text.Trim() + ".000000";
                dcDisplayTaxes = Convert.ToDecimal(strTaxes);
            }

            
            decimal dcDisplayTotal = Convert.ToDecimal(dcDisplayDeposit + dcDisplayRackrate + dcDisplayTaxes);
            string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";
            lblTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            txtExtraBedCharge.Focus();
        }

        protected void txtDeposit_textChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            TextBox txtTotalRackRate = (TextBox)row.FindControl("txtTotalRackRate");
            //TextBox txtRackRate = (TextBox)row.FindControl("txtRackRate");

            TextBox txtDeposit = (TextBox)row.FindControl("txtDeposit");
            TextBox txtTaxes = (TextBox)row.FindControl("txtTaxes");
            Label lblTotal = (Label)row.FindControl("lblTotal");

            decimal dcDisplayDeposit = 0;
            decimal dcDisplayRackrate = 0;
            decimal dcDisplayTaxes = 0;

            if (txtDeposit.Text.Trim() != "")
            {
                string strDeposit = txtDeposit.Text.Trim().IndexOf('.') > -1 ? txtDeposit.Text.Trim() + "000000" : txtDeposit.Text.Trim() + ".000000";
                dcDisplayDeposit = Convert.ToDecimal(strDeposit);
            }

            if (txtTotalRackRate.Text.Trim() != "")
            {
                string strTotalRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
                dcDisplayRackrate = Convert.ToDecimal(strTotalRackRate);
            }

            if (txtTaxes.Text.Trim() != "")
            {
                string strTaxes = txtTaxes.Text.Trim().IndexOf('.') > -1 ? txtTaxes.Text.Trim() + "000000" : txtTaxes.Text.Trim() + ".000000";
                dcDisplayTaxes = Convert.ToDecimal(strTaxes);
            }

            decimal dcDisplayTotal = Convert.ToDecimal(dcDisplayDeposit + dcDisplayRackrate + dcDisplayTaxes);
            string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";
            lblTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            txtTotalRackRate.Focus();

        }

        #endregion Textbox Event
    }
}