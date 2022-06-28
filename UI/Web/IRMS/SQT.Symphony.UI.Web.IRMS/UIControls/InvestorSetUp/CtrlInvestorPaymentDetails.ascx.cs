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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorPaymentDetails : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsInsert = false;

        public Guid InvestorRoomID
        {
            get
            {
                return ViewState["InvestorRoomID"] != null ? new Guid(Convert.ToString(ViewState["InvestorRoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InvestorRoomID"] = value;
            }
        }

        public Guid InvestorPaymentReceiptID
        {
            get
            {
                return ViewState["InvestorPaymentReceiptID"] != null ? new Guid(Convert.ToString(ViewState["InvestorPaymentReceiptID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InvestorPaymentReceiptID"] = value;
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

        private DataSet ds = null;

        public bool IsPreview = false;

        decimal dblTotalAmountPayable = 0;

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["InvRm"] != null)
            {
                this.InvestorRoomID = new Guid(Convert.ToString(Request.QueryString["InvRm"]));
                Session.Add("InvRm", this.InvestorRoomID);
            }
            if (Session["InvID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("InvestorPaymentReceiptSetUP.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();
                if (!IsPostBack)
                {
                    mvInvestorPaymentDetails.ActiveViewIndex = 0;
                    LoadDefaultValue();
                    if (Session["UserType"].ToString().ToUpper() == "INVESTOR")
                    {
                        btnAdd.Visible = false;
                    }
                    else
                    {
                        btnAdd.Visible = true;
                    }
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
            try
            {
                DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorPaymentReceiptSetUP.aspx", new Guid(Convert.ToString(Session["UserID"])));
                if (DV.Count > 0)
                {
                    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                    ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                    /////ViewState["Add"] = btnAdd.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                    ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
                }
                else
                    Response.Redirect("~/Applications/AccessDenied.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
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

                ViewState["InvestorID"] = Session["InvID"];
                ClearControlValue();
                LoadInvestorRoomDetail();
                BindGrid();
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
            litUnitNO.Text = "";
            litTypeOfUnit.Text = "";
            litTotalPurValue.Text = "0.00";
            ltrUnitPrice.Text = "0.00";
            //litAmountPayable.Text = "0.00";
        }

        /// <summary>
        /// Load Investor Room Detail
        /// </summary>
        private void LoadInvestorRoomDetail()
        {
            if (this.InvestorRoomID != null)
            {
                //DataSet ds = InvestorBLL.GetPaymentList(new Guid(Convert.ToString(ViewState["InvestorID"])), this.InvestorRoomID, null, null);
                //litUnitNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoomNo"]);
                //litTypeOfUnit.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoomTypeName"]);
                //litAmountPayable.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["UnitPrice"]).ToString("N");
                //litTotalPurValue.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["BalancePayable"]).ToString("N");
                //if (Convert.ToString(ds.Tables[0].Rows[0]["PaidAmount"]) != "")
                //    litAmountPaid.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["PaidAmount"]).ToString("N");
                //else
                //    litAmountPaid.Text = "0.00";
                //decimal NetAmt = 0;
                //if (Convert.ToString(ds.Tables[0].Rows[0]["UnitPrice"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["PaidAmount"]) != "")
                //    NetAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["UnitPrice"]) - Convert.ToDecimal(ds.Tables[0].Rows[0]["PaidAmount"]);
                //if (NetAmt != 0)
                //    litNetPaymentOutStanding.Text = Convert.ToString(NetAmt);
                //else
                //    litNetPaymentOutStanding.Text = "0.00";

                DataSet dsUnitDetails = InvestorsUnitBLL.SelectInvestorUnitDetails(this.InvestorRoomID, new Guid(Convert.ToString(Session["InvID"])));

                if (dsUnitDetails.Tables[0] != null && dsUnitDetails.Tables[0].Rows.Count > 0)
                {
                    litUnitNO.Text = Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["RoomNo"]);
                    litTypeOfUnit.Text = Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["RoomTypeName"]);
                    if (dsUnitDetails.Tables[0].Rows[0]["TotalPrice"] != null && Convert.ToString((dsUnitDetails.Tables[0].Rows[0]["TotalPrice"])) != "")
                        litTotalPurValue.Text = Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["TotalPrice"].ToString().Substring(0, dsUnitDetails.Tables[0].Rows[0]["TotalPrice"].ToString().LastIndexOf(".") + 1 + 2));
                    else
                        litTotalPurValue.Text = "0.00";

                    if (dsUnitDetails.Tables[0].Rows[0]["UnitPrice"] != null && Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["UnitPrice"]) != "")
                        ltrUnitPrice.Text = Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["UnitPrice"].ToString().Substring(0, dsUnitDetails.Tables[0].Rows[0]["UnitPrice"].ToString().LastIndexOf(".") + 1 + 2));
                    else
                        ltrUnitPrice.Text = "0.00";

                    //decimal NetAmt = 0;
                    //if (Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["TotalPrice"]) != "" && Convert.ToString(dsUnitDetails.Tables[0].Rows[0]["AmountPaid"]) != "")
                    //    NetAmt = Convert.ToDecimal(dsUnitDetails.Tables[0].Rows[0]["TotalPrice"]) - Convert.ToDecimal(dsUnitDetails.Tables[0].Rows[0]["AmountPaid"]);
                    //if (NetAmt != 0)
                    //    litNetPaymentOutStanding.Text = Convert.ToString(NetAmt.ToString().Substring(0, NetAmt.ToString().LastIndexOf(".") + 1 + 2));
                    //else
                    //    litNetPaymentOutStanding.Text = "0.00";
                }
                else
                {
                    litUnitNO.Text = litTypeOfUnit.Text = litTotalPurValue.Text = ltrUnitPrice.Text = "0.00";
                }
            }
        }

        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {

            //DataSet ds = InvestorBLL.GetPaymentScheduleDetail(this.InvestorRoomID);
            //grdInvestorPaymentList.DataSource = ds;
            //grdInvestorPaymentList.DataBind();

            //ds = InvestorPaymentReceiptBLL.SelectAllWithSearchDataSetForTax(null, new Guid(Convert.ToString(ViewState["InvestorID"])), null, null, new Guid(Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["ReceiptTypeTermIDRoom"])), null, null, Convert.ToString(litUnitNO.Text), null, null);
            //grdInvestorPaymentList.DataSource = ds;
            //grdInvestorPaymentList.DataBind();

            DataSet dsPaymentDetails = PaymentScheduleBLL.PaymentScheduleSelectInvestorPaymentDetails(this.InvestorRoomID, new Guid(Convert.ToString(Session["InvID"])), new Guid(Convert.ToString(Session["CompanyID"])));

            if (dsPaymentDetails.Tables[0] != null && dsPaymentDetails.Tables[0].Rows.Count > 0)
            {
                decimal totalPayableAmountCount = 0;

                for (int i = 0; i < dsPaymentDetails.Tables[0].Rows.Count; i++)
                {
                    totalPayableAmountCount += Convert.ToDecimal(dsPaymentDetails.Tables[0].Rows[i]["AmountPayable"]);
                }

                dblTotalAmountPayable = totalPayableAmountCount;
            }


            if (dsPaymentDetails.Tables[0] != null && dsPaymentDetails.Tables[0].Rows.Count > 0)
            {
                grdInvestorPaymentDetails.DataSource = dsPaymentDetails.Tables[0];
                grdInvestorPaymentDetails.DataBind();

                litScheduleType.Text = Convert.ToString(dsPaymentDetails.Tables[0].Rows[0]["ScheduleType"]) + " PAYMENT";
                //btnPrint.Visible = true;
            }
            else
            {
                //btnPrint.Visible = false;
                litScheduleType.Text = "";
                grdInvestorPaymentDetails.DataSource = null;
                grdInvestorPaymentDetails.DataBind();
            }

        }

        /// <summary>
        /// Load Report
        /// </summary>
        private void LoadReport()
        {
            try
            {
                //ds = InvestorPaymentReceiptBLL.SelectAllWithSearchDataSetForTax(null, new Guid(Convert.ToString(ViewState["InvestorID"])), null, null, new Guid(Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["ReceiptTypeTermIDRoom"])), null, null, Convert.ToString(litUnitNO.Text), null, null);
                Session.Add("Unit", litTypeOfUnit.Text.Trim());
                Session.Add("UnitNo", litUnitNO.Text.Trim());
                Session.Add("Name", litScheduleType.Text.Trim());
                Session.Add("Total", litTotalPurValue.Text.Trim());
                ds = PaymentScheduleBLL.PaymentScheduleSelectInvestorPaymentDetails(this.InvestorRoomID, new Guid(Convert.ToString(Session["InvID"])), new Guid(Convert.ToString(Session["CompanyID"])));
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Button Event

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Val"] != null)
            {
                string strPropertyID = Convert.ToString(Request.QueryString["PRID"]);
                Response.Redirect("~/Applications/Investors/InvestorPaymentReceiptSetUP.aspx?Val=True&PRID=" + strPropertyID);
            }
            else
            {
                Response.Redirect("~/Applications/Investors/InvestorPaymentReceiptSetUP.aspx");
            }
        }

        /// <summary>
        /// Print Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Investor Payment Details");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

         
        protected void btnBackInvesterPaymentList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Investors/InvestorPaymentList.aspx");
        }
        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Investor Payment Details");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Investor Payment Details");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Investor Payment Details");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Investor Payment Details");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            mvInvestorPaymentDetails.ActiveViewIndex = 0;
        }

        #endregion Button Event

        #region Popup Button

        ///// <summary>
        ///// Ok Button Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnAddressSave_Click(object sender, EventArgs e)
        //{
        //    if (this.InvestorPaymentReceiptID != Guid.Empty)
        //    {
        //        InvestorPaymentReceipt GetData = InvestorPaymentReceiptBLL.GetByPrimaryKey(this.InvestorPaymentReceiptID);
        //        IsInsert = true;
        //        InvestorPaymentReceiptBLL.Delete(this.InvestorPaymentReceiptID);
        //        ActionLogBLL.Save(null, "Delete Investor Payment Receipt", GetData.ToString(), GetData.ToString(), "Update" + GetData.ReceiptNo + " Record");
        //        this.InvestorPaymentReceiptID = Guid.Empty;
        //        lblInvestorMsg.Text = global::Resources.IRMSMsg.DeleteMsg;
        //        BindGrid();
        //    }
        //    msgbx.Hide();
        //}
        ///// <summary>
        ///// Cancel Button Event
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnAddressCancel_Click(object sender, EventArgs e)
        //{
        //    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
        //    this.InvestorPaymentReceiptID = Guid.Empty;
        //    msgbx.Hide();
        //}
        #endregion Popup Button

        #region Grid Event

        ///// <summary>
        ///// Data Row Command
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void grdInvestorPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                e.Row.Cells[3].Text = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                e.Row.Cells[3].Text = "View";
        //            e.Row.Cells[3].Visible = e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
        //            e.Row.Cells[4].Visible = Convert.ToBoolean(ViewState["Delete"]);
        //        }
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
        //            ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");
        //            Image AttImg = (Image)e.Row.FindControl("btnAttachment");

        //            AttImg.Visible = EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
        //            DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);


        //            string DocumentName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DocumentName"));
        //            if (!DocumentName.Equals("") && DocumentName != null)
        //                AttImg.Visible = true;
        //            else
        //                AttImg.Visible = false;
        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                EditImg.ToolTip = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                EditImg.ToolTip = "View";
        //            e.Row.Cells[3].Visible = e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
        //            e.Row.Cells[4].Visible = Convert.ToBoolean(ViewState["Delete"]);

        //        }
        //        if (e.Row.RowType == DataControlRowType.Footer)
        //        {
        //            if (Convert.ToBoolean(ViewState["Edit"]) == true)
        //                e.Row.Cells[3].Text = "View/Edit";
        //            else if (Convert.ToBoolean(ViewState["View"]) == true)
        //                e.Row.Cells[3].Text = "View";
        //            e.Row.Cells[3].Visible = e.Row.Cells[5].Visible = Convert.ToBoolean(ViewState["View"]);
        //            e.Row.Cells[4].Visible = Convert.ToBoolean(ViewState["Delete"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }

        //}

        /// <summary>
        /// Data Row Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdInvestorPaymentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strDue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DUE"));
                    //int ReceiptCount = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ReceiptCount"));

                    Label lblGvDue = (Label)e.Row.FindControl("lblGvDue");

                    if (lblGvDue != null)
                    {
                        if (strDue != string.Empty)
                            lblGvDue.Text = Convert.ToString(strDue.ToString().Substring(0, strDue.ToString().LastIndexOf(".") + 1 + 2));
                    }

                    //LinkButton lnkInvestorPaymentDetailsView = (LinkButton)e.Row.FindControl("lnkInvestorPaymentDetailsView");

                    //if (ReceiptCount > 0)
                    //{
                    //    if (lnkInvestorPaymentDetailsView != null)
                    //        lnkInvestorPaymentDetailsView.Visible = true;
                    //}
                    //else
                    //{
                    //    if (lnkInvestorPaymentDetailsView != null)
                    //        lnkInvestorPaymentDetailsView.Visible = false;
                    //}

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvTotalAmountPayable = (Label)e.Row.FindControl("lblGvTotalAmountPayable");

                    if (lblGvTotalAmountPayable != null)
                    {
                        lblGvTotalAmountPayable.Text = Convert.ToString(dblTotalAmountPayable.ToString().Substring(0, dblTotalAmountPayable.ToString().LastIndexOf(".") + 1 + 2));
                    }

                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void grdInvestorPaymentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("VIEWRECEIPT"))
            {
                mvInvestorPaymentDetails.ActiveViewIndex = 1;

                DataSet dsReceipt = InvestorPaymentReceiptBLL.SelectPaymentReceiptData(this.InvestorRoomID, new Guid(Convert.ToString(Session["InvID"])), new Guid(Convert.ToString(Session["CompanyID"])), new Guid(Convert.ToString(e.CommandArgument)));

                if (dsReceipt.Tables[0] != null && dsReceipt.Tables[0].Rows.Count > 0)
                {
                    litReceiptDetailsMilestoneTitle.Text = Convert.ToString(dsReceipt.Tables[0].Rows[0]["ProjectMilestone"]);
                    litReceiptDetailsDue.Text = Convert.ToString(dsReceipt.Tables[0].Rows[0]["DUE"].ToString().Substring(0, dsReceipt.Tables[0].Rows[0]["DUE"].ToString().LastIndexOf(".") + 1 + 2));
                    litReceiptDetailsTotalMilestoneAmountPayable.Text = Convert.ToString(dsReceipt.Tables[0].Rows[0]["AmountPayable"]);
                    if (Convert.ToString(dsReceipt.Tables[0].Rows[0]["DueDate"]) != "" && Convert.ToString(dsReceipt.Tables[0].Rows[0]["DueDate"]) != null)
                    {
                        DateTime dtDueDate = Convert.ToDateTime(Convert.ToString(dsReceipt.Tables[0].Rows[0]["DueDate"]));
                        litReceiptDetailsDate.Text = Convert.ToString(dtDueDate.ToString(this.DateFormat));
                    }
                    else
                        litReceiptDetailsDate.Text = "";
                    litReceiptDetailsAmountPaid.Text = Convert.ToString(dsReceipt.Tables[0].Rows[0]["AmountPaid"]);
                    litReceiptDetailsBalanceAmount.Text = Convert.ToString(dsReceipt.Tables[0].Rows[0]["BalanceAmount"]);

                    if (dsReceipt.Tables[1] != null && dsReceipt.Tables[1].Rows.Count > 0)
                    {
                        grdInvestorPaymentReceipt.DataSource = dsReceipt.Tables[1];
                        grdInvestorPaymentReceipt.DataBind();
                    }
                    else
                    {
                        grdInvestorPaymentReceipt.DataSource = null;
                        grdInvestorPaymentReceipt.DataBind();
                    }
                }
                else
                {
                    litReceiptDetailsMilestoneTitle.Text = litReceiptDetailsDue.Text = litReceiptDetailsTotalMilestoneAmountPayable.Text = litReceiptDetailsDate.Text = litReceiptDetailsAmountPaid.Text = litReceiptDetailsBalanceAmount.Text = "";
                    grdInvestorPaymentReceipt.DataSource = null;
                    grdInvestorPaymentReceipt.DataBind();
                }

            }
        }

        protected void grdInvestorPaymentReceipt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string strDocumentName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DocumentName"));

                    Image imgAttachment = (Image)e.Row.FindControl("imgAttachment");

                    if (imgAttachment != null)
                    {
                        if (strDocumentName != string.Empty)
                            imgAttachment.Visible = true;
                        else
                            imgAttachment.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void grdInvestorPaymentList_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETECMD"))
            {
                this.InvestorPaymentReceiptID = new Guid(Convert.ToString(e.CommandArgument));
                //msgbx.Show();
            }
            else if (e.CommandName.Equals("EDITCMD"))
            {
                if (Request.QueryString["Val"] != null)
                {
                    Response.Redirect("~/Applications/Investors/InvestorPaymentReceiptSetUP.aspx?Val=True&IPRID=" + e.CommandArgument.ToString());
                }
                else
                {
                    Response.Redirect("~/Applications/Investors/InvestorPaymentReceiptSetUP.aspx?IPRID=" + e.CommandArgument.ToString());
                }
            }
        }

        #endregion Grid Event
    }
}