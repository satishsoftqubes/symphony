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
using System.Globalization;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorsUnit : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

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

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InvID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("InvestorsUnitSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();
                ValidDate.Visible = false;
                if (!IsPostBack)
                {
                    LoadDefaultValue();

                    if (Session["InvestorRoomID"] != null)
                    {
                        this.InvestorRoomID = new Guid(Convert.ToString(Session["InvestorRoomID"]));
                        Session.Remove("InvestorRoomID");
                        LoadInvestorsUnitData();
                    }
                    else
                        btnSave.Visible = btnSaveUp.Visible = true;
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
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorsUnitSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnNewUp.Visible = btnCancel.Visible = btnCancelUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = btnNewUp.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Defalutl Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];

                    string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                    DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
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

                ajxCalendarDateOfBooking.Format = calRegistrationDate.Format= calFinalPaymentDate.Format = this.DateFormat;
                

                BindInvestor();
                BindDate();
                BindPropertyName();
                ddlRoomName.Items.Clear();
                ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlUnitNo.Items.Clear();
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                lblSubTotalConstructionAgreement.Text = lblSubTotalAgreementToSell.Text = txtSBA.Text = lblErrorMessage.Text = hdnConstructionAgreement.Value = hdnAgreementtoSell.Value = lblSubTotalAgreementToSell.Text = lblSubTotalConstructionAgreement.Text = "";
                LoadDocumentGrid();
                BindGrid();
                chkIsInterestApplicable_CheckedChanged(null, null);
                trRateOfInterest.Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SendEmail(Guid InvestorRoomID)
        {
            if (Session["PropertyConfigurationInfo"] != null)
            {
                PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);

                //string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/PurchaseUnit.htm"));
                DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Unit Purchase Notification");
                if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                {
                    string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/PurchaseUnit.htm"));

                    DataSet Dst = SQT.Symphony.BusinessLogic.IRMS.BLL.InvestorsUnitBLL.SearchInvestorsUnitData(InvestorRoomID, null, null, null, null, null);
                    DataView Dv = new DataView(Dst.Tables[0]);
                    if (Dv.Count == 1)
                    {
                        strHTML = strHTML.Replace("$PROPERTYNAME$", Convert.ToString(Dv[0]["PropertyName"]));
                        strHTML = strHTML.Replace("$UNITTYPE$", Convert.ToString(Dv[0]["RoomTypeName"]));
                        strHTML = strHTML.Replace("$UNITNO$", Convert.ToString(Dv[0]["RoomNo"]));
                        strHTML = strHTML.Replace("$SBAREA$", Convert.ToString(Dv[0]["SBArea"].ToString().Substring(0, Dv[0]["SBArea"].ToString().LastIndexOf("."))));
                        strHTML = strHTML.Replace("$UNITPRICE$", Convert.ToString(Dv[0]["UnitPrice"]));
                        strHTML = strHTML.Replace("$UNITRATEPERSQFT$", Convert.ToString(Dv[0]["RatePerSqtft"]));
                        strHTML = strHTML.Replace("$AGREEMENTTOSELLVALUE$", Convert.ToString(Dv[0]["AgreementToSellValue"]));
                        strHTML = strHTML.Replace("$CONSTRUCTIONVALUE$", Convert.ToString(Dv[0]["ConstructionValue"]));
                        strHTML = strHTML.Replace("$STMPDUTYONAGRTOSELL$", Convert.ToString(Dv[0]["StmpDutyOnAgrToSell"]));
                        strHTML = strHTML.Replace("$VAT$", Convert.ToString(Dv[0]["Vat"]));
                        strHTML = strHTML.Replace("$STMPDUTYONSALEDEED$", Convert.ToString(Dv[0]["StmpDutyOnSaleDeed"]));
                        strHTML = strHTML.Replace("$STAX$", Convert.ToString(Dv[0]["STax"]));
                        strHTML = strHTML.Replace("$REGISTRATIONCHARGES$", Convert.ToString(Dv[0]["RegistrationCharges"]));
                        strHTML = strHTML.Replace("$OTHERCONSTRUCTIONCOST$", Convert.ToString(Dv[0]["OtherConstructionCost"]));
                        strHTML = strHTML.Replace("$OTHERCOSTS$", Convert.ToString(Dv[0]["OtherCosts"]));
                        if (Convert.ToString(Dv[0]["DateOfPossession"]) != "")
                            strHTML = strHTML.Replace("$DATEOFPOSSESSION$", Convert.ToString(Dv[0]["DateOfPossession"]));
                        else
                            strHTML = strHTML.Replace("$DATEOFPOSSESSION$", "NA");
                        strHTML = strHTML.Replace("$INTERESTAPPLICABLE$", Convert.ToString(Dv[0]["IsInterestApplicable"]));
                        strHTML = strHTML.Replace("$INTERESTRATE$", Convert.ToString(Dv[0]["RateOfInterest"]));

                        Investor Inv = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Dv[0]["InvestorID"])));

                        strHTML = strHTML.Replace("$NAME$", Inv.UniworldPrime);
                        strHTML = strHTML.Replace("$CONTACTNO$", Inv.PrimeMobileNo);
                        strHTML = strHTML.Replace("$EMAIL$", Inv.PrimeEmail);
                        strHTML = strHTML.Replace("$FULLNAME$", Inv.Title.ToString() + " " + Inv.FName.ToString() + " " + Inv.LName.ToString());
                        if (Inv.ManagerType.ToUpper().Equals("SALES"))
                        {
                            List<SalesTeam> lstsl = SalesTeamBLL.GetAllBy(SalesTeam.SalesTeamFields.UserID, Convert.ToString(Inv.RelationShipManagerID));
                            if (lstsl.Count == 1)
                            {
                                SalesTeam sl = (SalesTeam)lstsl[0];
                                strHTML = strHTML.Replace("$RELATIONSHIPTHROUGH$", "SALES");
                                strHTML = strHTML.Replace("$RELNAME$", sl.DisplayName);
                                strHTML = strHTML.Replace("$CONTACTNO$", sl.MobileNo);
                                strHTML = strHTML.Replace("$RELSEMAIL$", sl.Email);
                            }
                            else
                            {
                                strHTML = strHTML.Replace("$RELATIONSHIPTHROUGH$", "SALES");
                                strHTML = strHTML.Replace("$RELNAME$", "NA");
                                strHTML = strHTML.Replace("$CONTACTNO$", "NA");
                                strHTML = strHTML.Replace("$RELSEMAIL$", "NA");
                            }
                        }
                        else
                        {
                            List<ChannelPartner> lstchnl = ChannelPartnerBLL.GetAllBy(ChannelPartner.ChannelPartnerFields.UserID, Convert.ToString(Inv.RelationShipManagerID));
                            if (lstchnl.Count == 1)
                            {
                                ChannelPartner Chnl = (ChannelPartner)lstchnl[0];
                                strHTML = strHTML.Replace("$RELATIONSHIPTHROUGH$", "CHANNEL PARTNER");
                                strHTML = strHTML.Replace("$RELNAME$", Chnl.DisplayName);
                                strHTML = strHTML.Replace("$CONTACTNO$", Chnl.MobileNo);
                                strHTML = strHTML.Replace("$RELSEMAIL$", Chnl.Email);
                            }
                            else
                            {
                                strHTML = strHTML.Replace("$RELATIONSHIPTHROUGH$", "CHANNEL PARTNER");
                                strHTML = strHTML.Replace("$RELNAME$", "NA");
                                strHTML = strHTML.Replace("$CONTACTNO$", "NA");
                                strHTML = strHTML.Replace("$RELSEMAIL$", "NA");
                            }
                        }
                        strHTML = strHTML.Replace("$TOTALCOST$", Dv[0]["TotalCost"].ToString());


                        //AttachDocument
                        string DocumentName = string.Empty;
                        List<Documents> LstDoc = DocumentsBLL.GetAllBy(Documents.DocumentsFields.AssociationID, Convert.ToString(Dv[0]["InvestorRoomID"]));
                        for (int i = 0; i < LstDoc.Count; i++)
                        {
                            DocumentName = DocumentName + Server.MapPath("~/Document/" + LstDoc[i].DocumentName) + ",";
                        }

                        if (!Inv.EMail.Equals(""))
                            SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), Inv.EMail, "Unit Registration", strHTML, DocumentName == string.Empty ? "" : DocumentName.Substring(0, DocumentName.Length - 1).ToString());
                    }
                }
            }
            else
                MessageBox.Show("Please set Company email configuration");
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string RoomNo = null;

            Guid? InvestorID = new Guid(Convert.ToString(Session["InvID"]));
            if (!(txtSInvestorName.Text.Trim().Equals("")))
                RoomNo = txtSInvestorName.Text.Trim();
            else
                RoomNo = null;

            DataSet dsInvestorsUnit = InvestorsUnitBLL.SearchInvestorsUnitData(null, RoomNo, InvestorID, null, null, null);
            DataView dvInvestorsUnit = new DataView(dsInvestorsUnit.Tables[0]);
            grdInvestorUnitList.DataSource = dvInvestorsUnit;
            grdInvestorUnitList.DataBind();

        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            BindInvestor();
            BindPropertyName();
            BindDate();
            ddlPropertyName.SelectedValue = Guid.Empty.ToString();
            ddlRoomName.Items.Clear();
            ddlUnitNo.Items.Clear();
            ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            txtSBA.Text = "";
            txtUnitPrice.Text = "";
            txtRatePerSqtFt.Text = "";
            txtAgToSellValue.Text = "";
            txtStampDutyonAgrtoSell.Text = "";
            txtStampDutyonSaleDeed.Text = "";
            txtRegistrationCharges.Text = "";
            txtOtherCosts.Text = "";
            txtConstructionCost.Text = "";
            txtVAT.Text = "";
            txtSTax.Text = "";
            txtOtherConstructorCost.Text = "";
            txtRateOfInterest.Text = "";
            lblSubTotalAgreementToSell.Text = lblSubTotalConstructionAgreement.Text = "";
            chkIsInterestApplicable.Checked = chkIntAppNo.Checked = false;
            this.InvestorRoomID = Guid.Empty;
            LoadDocumentGrid();
            BindGrid();
            ddlPropertyName.Enabled = true;
            ddlDate.SelectedValue = ddlMonth.SelectedValue = ddlYear.SelectedValue = Guid.Empty.ToString();
            ValidDate.Visible = false;
            chkIsInterestApplicable_CheckedChanged(null, null);
            trRateOfInterest.Visible = false;
            txtDateOfBooking.Text = txtSellerCompany.Text =txtRegistrationDate.Text = txtFinalPaymentDate.Text = "";
            lblSubTotalConstructionAgreement.Text = lblSubTotalAgreementToSell.Text = lblErrorMessageOfUnitPrice.Text = hdnAgreementtoSell.Value = hdnConstructionAgreement.Value = "";


        }

        /// <summary>
        /// Load DocumentStatus
        /// </summary>
        //private void BindDocumentStatus()
        //{
        //    List<ProjectTerm> lstProjectTermDS = null;
        //    ProjectTerm objProjectTermDS = new ProjectTerm();
        //    objProjectTermDS.IsActive = true;
        //    objProjectTermDS.Category = "DOCUMENTSTATUS";
        //    objProjectTermDS.CompanyID = this.CompanyID;

        //    lstProjectTermDS = ProjectTermBLL.GetAll(objProjectTermDS);

        //    if (lstProjectTermDS.Count != 0)
        //    {
        //        ddlAgreementtoSell.DataSource = lstProjectTermDS;
        //        ddlAgreementtoSell.DataTextField = "Term";
        //        ddlAgreementtoSell.DataValueField = "TermID";
        //        ddlAgreementtoSell.DataBind();
        //        ddlAgreementtoSell.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        //    }
        //    else
        //        ddlAgreementtoSell.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        //}

        /// <summary>
        /// Load Property Name
        /// </summary>
        private void BindPropertyName()
        {
            DataSet ds = PropertyBLL.SelectData(this.CompanyID);

            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlPropertyName.DataSource = dv;
                ddlPropertyName.DataTextField = "PropertyName";
                ddlPropertyName.DataValueField = "PropertyID";
                ddlPropertyName.DataBind();
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Date
        /// </summary>
        private void BindDate()
        {
            ddlDate.Items.Clear();
            ddlYear.Items.Clear();
            //Load Date Based On Month
            ddlDate.Items.Insert(0, new ListItem("-Date-", Guid.Empty.ToString()));
            for (int i = 1; i < 32; i++)
            {
                if (i < 10)
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlDate.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                }
            }
            //Load Year
            int j = 1;
            ddlYear.Items.Insert(0, new ListItem("-Year-", Guid.Empty.ToString()));
            for (int i = Convert.ToInt32(DateTime.Now.Year) + 15; i >= 1970; i--)
            {
                ddlYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                j++;
            }
        }

        /// <summary>
        /// Load Investor
        /// </summary>
        private void BindInvestor()
        {
            string InvestorQuery = "Select InvestorID, Title + ' ' + FName  + ' ' + LName As FullName From irm_Investor Where RefInverstorID Is NULL And IsActive = 1" + (this.CompanyID == null ? null : " And CompanyID = '" + this.CompanyID.ToString() + "'");
            DataSet dsInvestor = InvestorBLL.GetSearchData(InvestorQuery);

            if (dsInvestor.Tables[0].Rows.Count != 0)
            {
                DataView dvInvestor = new DataView(dsInvestor.Tables[0]);
                dvInvestor.Sort = "FullName Asc";
                ddlInvestor.DataSource = dvInvestor;
                ddlInvestor.DataTextField = "FullName";
                ddlInvestor.DataValueField = "InvestorID";
                ddlInvestor.DataBind();
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlInvestor.SelectedValue = Convert.ToString(Session["InvID"]);
            }
            else
                ddlInvestor.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load UnitType
        /// </summary>
        private void BindUnitType()
        {
            Guid PropertyID = new Guid(ddlPropertyName.SelectedValue);
            string RoomTypeQuery = "Select RoomTypeID, RoomTypeName From mst_RoomType Where IsActive = 1 And PropertyID= '" + PropertyID + "'";
            DataSet dsRoomType = RoomTypeBLL.GetUnitType(RoomTypeQuery);

            if (dsRoomType.Tables[0].Rows.Count != 0)
            {
                DataView dvRoomType = new DataView(dsRoomType.Tables[0]);
                dvRoomType.Sort = "RoomTypeName Asc";
                ddlRoomName.DataSource = dvRoomType;
                ddlRoomName.DataTextField = "RoomTypeName";
                ddlRoomName.DataValueField = "RoomTypeID";
                ddlRoomName.DataBind();
                ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load UnitNo
        /// </summary>
        private void BindUnitNo(string strRoomID)
        {
            Guid RoomTypeID = new Guid(ddlRoomName.SelectedValue);
            string RoomNoQuery = "Select RoomID, RoomNo From mst_Room Where RoomID Not In (Select RoomID From irm_InvestorsUnit Where ISNULL(IsSoldToCompany,0) = 0 " + (strRoomID.Equals("") ? "" : ("and RoomID Not In ('" + strRoomID + "')")) + ") and IsActive = 1 And RoomTypeID= '" + RoomTypeID + "' And PropertyID='" + ddlPropertyName.SelectedValue.ToString() + "'";
            //// ISNULL(IsSoldToCompany,0) = 0 is added b'cas if Investor's unit sold back to company, then this unit should be availalbe to resell again by company to other investor in future. This flag is maintained at the time of Resell of any Unit.
            DataSet dsRoom = RoomBLL.GetUnitNo(RoomNoQuery);

            if (dsRoom.Tables[0].Rows.Count != 0)
            {
                DataView dvRoom = new DataView(dsRoom.Tables[0]);
                dvRoom.Sort = "RoomNo Asc";
                ddlUnitNo.DataSource = dvRoom;
                ddlUnitNo.DataTextField = "RoomNo";
                ddlUnitNo.DataValueField = "RoomID";
                ddlUnitNo.DataBind();
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Load SBA
        /// </summary>
        private void BindSBA()
        {
            Guid RoomID = new Guid(ddlUnitNo.SelectedValue);
            Room objLoadRoomNo = new Room();
            objLoadRoomNo = RoomBLL.GetByPrimaryKey(RoomID);

            if (objLoadRoomNo != null)
                txtSBA.Text = Convert.ToString(objLoadRoomNo.SBArea);
            else
                txtSBA.Text = "";
        }

        /// <summary>
        /// Load InvestorsUnit Data
        /// </summary>
        private void LoadInvestorsUnitData()
        {
            DataSet ds = InvestorsUnitBLL.SearchInvestorsUnitData(this.InvestorRoomID, null, null, null, null, null);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlInvestor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InvestorID"]);
                ddlPropertyName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PropertyID"]);
                ddlPropertyName.Enabled = false;
                BindUnitType();
                ddlRoomName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RoomTypeID"]);
                BindUnitNo(Convert.ToString(ds.Tables[0].Rows[0]["RoomID"]));
                ddlUnitNo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["RoomID"]);
                txtSBA.Text = Convert.ToString(ds.Tables[0].Rows[0]["SBArea"]);
                txtUnitPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitPrice"]);
                txtRatePerSqtFt.Text = Convert.ToString(ds.Tables[0].Rows[0]["RatePerSqtft"]);

                if (Convert.ToString(ds.Tables[0].Rows[0]["DateOfBooking"]) != "")
                {
                    DateTime dtDateOfBooking = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["DateOfBooking"]));
                    txtDateOfBooking.Text = dtDateOfBooking.ToString(this.DateFormat);
                }
                else
                    txtDateOfBooking.Text = "";


                if (Convert.ToString(ds.Tables[0].Rows[0]["RegistrationDate"]) != "")
                {
                    DateTime dtRegistrationDate = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["RegistrationDate"]));
                    txtRegistrationDate.Text = dtRegistrationDate.ToString(this.DateFormat);
                }
                else
                    txtRegistrationDate.Text = "";


                if (Convert.ToString(ds.Tables[0].Rows[0]["FinalPaymentDate"]) != "")
                {
                    DateTime dtFinalPaymentDate = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["FinalPaymentDate"]));
                    txtFinalPaymentDate.Text = dtFinalPaymentDate.ToString(this.DateFormat);
                }
                else
                    txtFinalPaymentDate.Text = "";

                txtSellerCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["SellerCompany"]);

                double dblAgreementtoSelltotal = 0.00;
                double dblConstructionAgreement = 0.00;

                if (Convert.ToString(ds.Tables[0].Rows[0]["AgreementToSellValue"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["AgreementToSellValue"]) != null)
                {
                    txtAgToSellValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgreementToSellValue"]);
                    dblAgreementtoSelltotal += Convert.ToDouble(ds.Tables[0].Rows[0]["AgreementToSellValue"]);
                }
                else
                    txtAgToSellValue.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]) != null)
                {
                    txtStampDutyonAgrtoSell.Text = Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]);
                    dblAgreementtoSelltotal += Convert.ToDouble(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]);
                }
                else
                    txtStampDutyonAgrtoSell.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]) != null)
                {
                    txtStampDutyonSaleDeed.Text = Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]);
                    dblAgreementtoSelltotal += Convert.ToDouble(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]);
                }
                else
                    txtStampDutyonSaleDeed.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCharges"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCharges"]) != null)
                {
                    txtRegistrationCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCharges"]);
                    dblAgreementtoSelltotal += Convert.ToDouble(ds.Tables[0].Rows[0]["RegistrationCharges"]);
                }
                else
                    txtRegistrationCharges.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["OtherCosts"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["OtherCosts"]) != null)
                {
                    txtOtherCosts.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherCosts"]);
                    dblAgreementtoSelltotal += Convert.ToDouble(ds.Tables[0].Rows[0]["OtherCosts"]);
                }
                else
                    txtOtherCosts.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["ConstructionValue"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["ConstructionValue"]) != null)
                {
                    txtConstructionCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConstructionValue"]);
                    dblConstructionAgreement += Convert.ToDouble(ds.Tables[0].Rows[0]["ConstructionValue"]);
                }
                else
                    txtConstructionCost.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["Vat"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["Vat"]) != null)
                {
                    txtVAT.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vat"]);
                    dblConstructionAgreement += Convert.ToDouble(ds.Tables[0].Rows[0]["Vat"]);
                }
                else
                    txtVAT.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["STax"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["STax"]) != null)
                {
                    txtSTax.Text = Convert.ToString(ds.Tables[0].Rows[0]["STax"]);
                    dblConstructionAgreement += Convert.ToDouble(ds.Tables[0].Rows[0]["STax"]);
                }
                else
                    txtSTax.Text = "";
                if (Convert.ToString(ds.Tables[0].Rows[0]["OtherConstructionCost"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["OtherConstructionCost"]) != null)
                {
                    txtOtherConstructorCost.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherConstructionCost"]);
                    dblConstructionAgreement += Convert.ToDouble(ds.Tables[0].Rows[0]["OtherConstructionCost"]);
                }
                else
                    txtOtherConstructorCost.Text = "";

                lblSubTotalAgreementToSell.Text = hdnAgreementtoSell.Value = Convert.ToString(dblAgreementtoSelltotal);
                lblSubTotalConstructionAgreement.Text = hdnConstructionAgreement.Value = Convert.ToString(dblConstructionAgreement);


                if (Convert.ToString(ds.Tables[0].Rows[0]["DateOfPossession"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["DateOfPossession"]) != null)
                {
                    DateTime dtDOP = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["DateOfPossession"]));
                    ddlDate.SelectedValue = dtDOP == null ? Guid.Empty.ToString() : dtDOP.Day.ToString().Length == 2 ? dtDOP.Day.ToString() : "0" + dtDOP.Day.ToString();
                    ddlMonth.SelectedValue = dtDOP == null ? Guid.Empty.ToString() : dtDOP.Month.ToString().Length == 2 ? dtDOP.Month.ToString() : "0" + dtDOP.Month.ToString();
                    ddlYear.SelectedValue = dtDOP == null ? Guid.Empty.ToString() : dtDOP.Year.ToString();
                }
                else
                    ddlDate.SelectedValue = ddlMonth.SelectedValue = ddlYear.SelectedValue = Guid.Empty.ToString();


                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsInterestApplicable"]) == true)
                {
                    chkIsInterestApplicable.Checked = true;
                    chkIntAppNo.Checked = false;
                    if (Convert.ToString(ds.Tables[0].Rows[0]["RateOfInterest"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["RateOfInterest"]) != null)
                        txtRateOfInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["RateOfInterest"]);
                    else
                        txtRateOfInterest.Text = "";
                    trRateOfInterest.Visible = true;
                }
                else if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsInterestApplicable"]) == false)
                {
                    chkIsInterestApplicable.Checked = false;
                    trRateOfInterest.Visible = false;
                    chkIntAppNo.Checked = true;
                    txtRateOfInterest.Text = "";
                }
                LoadDocumentGrid();
            }
        }

        /// <summary>
        /// Load Document Grid
        /// </summary>
        private void LoadDocumentGrid()
        {
            Guid? InvestorRoomID;
            if (this.InvestorRoomID != Guid.Empty)
                InvestorRoomID = this.InvestorRoomID;
            else
                InvestorRoomID = null;

            DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "INVESTOR UNIT DOCUMENT", InvestorRoomID);
            if (dsDocumentList.Tables[0].Rows.Count != 0)
            {
                gvDocument.DataSource = dsDocumentList.Tables[0];
                gvDocument.DataBind();
            }
        }
        #endregion Private Method

        #region Dropdown Event

        protected void ddlPropertyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSubTotalConstructionAgreement.Text = Convert.ToString(hdnConstructionAgreement.Value);
            lblSubTotalAgreementToSell.Text = Convert.ToString(hdnAgreementtoSell.Value);

            if (ddlPropertyName.SelectedValue != Guid.Empty.ToString())
            {
                ddlRoomName.Items.Clear();
                txtSBA.Text = "";
                BindUnitType();
            }
            else
            {
                ddlRoomName.Items.Clear();
                ddlRoomName.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlUnitNo.Items.Clear();
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                txtSBA.Text = "";
            }
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        protected void ddlRoomName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSubTotalConstructionAgreement.Text = Convert.ToString(hdnConstructionAgreement.Value);
            lblSubTotalAgreementToSell.Text = Convert.ToString(hdnAgreementtoSell.Value);

            if (ddlRoomName.SelectedValue != Guid.Empty.ToString())
            {
                ddlUnitNo.Items.Clear();
                txtSBA.Text = "";
                BindUnitNo("");
            }
            else
            {
                ddlUnitNo.Items.Clear();
                ddlUnitNo.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                txtSBA.Text = "";
            }
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        protected void ddlUnitNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSubTotalConstructionAgreement.Text = Convert.ToString(hdnConstructionAgreement.Value);
            lblSubTotalAgreementToSell.Text = Convert.ToString(hdnAgreementtoSell.Value);

            if (ddlUnitNo.SelectedValue != Guid.Empty.ToString())
            {
                DataSet dsMilestoneTotal = PaymentSlabeBLL.GetBlocksTotalMilestoneByRoomID(new Guid(ddlUnitNo.SelectedValue.ToString()));
                if (dsMilestoneTotal != null && dsMilestoneTotal.Tables[0].Rows.Count > 0)
                {
                    Double dblTotalMilestone = Convert.ToDouble(dsMilestoneTotal.Tables[0].Rows[0]["TotalCount"]);
                    if (dblTotalMilestone > 100 || dblTotalMilestone < 100)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Please insure Payment milestone is 100%.");
                        updMessage.Update();
                        ddlUnitNo.SelectedIndex = 0;
                        return;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Please insure Payment milestone is 100%.");
                    updMessage.Update();
                    ddlUnitNo.SelectedIndex = 0;
                    return;
                }

                BindSBA();
            }
            else
                txtSBA.Text = "";
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        #endregion Dropdown Event

        #region Control Event
        protected void btnNewUp_Click(object sender, EventArgs e)
        {
            btnNew_Click(null, null);
        }

        protected void btnSaveUp_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }

        //protected void btnCancelUp_Click(object sender, EventArgs e)
        //{
        //    btnCancel_Click(null, null);
        //}

        /// <summary>
        /// Add New Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        /// <summary>
        /// Button Save And Update Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //DateTime? PassationDate = null;
            string PassationDate = null;
            if (this.Page.IsValid)
            {
                try
                {
                    try
                    {

                        if (Convert.ToString(ddlDate.SelectedValue) == Guid.Empty.ToString() && Convert.ToString(ddlMonth.SelectedValue) == Guid.Empty.ToString() && Convert.ToString(ddlYear.SelectedValue) == Guid.Empty.ToString())
                        {
                            PassationDate = null;
                        }
                        else
                        {
                            PassationDate = Convert.ToString(Convert.ToString(ddlMonth.SelectedValue) + "-" + Convert.ToString(ddlDate.SelectedValue) + "-" + Convert.ToString(ddlYear.SelectedValue));
                            string DateOfPassation = Convert.ToString(ddlDate.SelectedValue.ToString().Trim() + "-" + ddlMonth.SelectedItem.Text.Trim() + "-" + ddlYear.SelectedValue.ToString().Trim());
                            //DateTime PSDT = Convert.ToDateTime(Convert.ToString(ddlDate.SelectedValue) + "-" + Convert.ToString(ddlMonth.SelectedValue) + "-" + Convert.ToString(ddlYear.SelectedValue));

                            DateTime dtToValidate = Convert.ToDateTime(DateOfPassation);
                        }
                        ValidDate.Visible = false;
                    }
                    catch
                    {
                        ValidDate.Visible = true;
                        return;
                    }
                    List<Documents> lstDocuments = new List<Documents>();
                    DataSet dsDupInvestorsUnit = InvestorsUnitBLL.CheckDuplicateInInvestorUnit(new Guid(ddlInvestor.SelectedValue), new Guid(ddlUnitNo.SelectedValue), new Guid(ddlRoomName.SelectedValue), new Guid(ddlPropertyName.SelectedValue));

                    if (dsDupInvestorsUnit.Tables[0].Rows.Count > 0)
                    {
                        if (this.InvestorRoomID != Guid.Empty)
                        {
                            if (Convert.ToString((dsDupInvestorsUnit.Tables[0].Rows[0]["InvestorRoomID"])) != Convert.ToString(this.InvestorRoomID.ToString()))
                            {
                                IsMessage = true;
                                lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                                return;
                            }
                        }
                        else
                        {
                            IsMessage = true;
                            lblErrorMessage.Text = global::Resources.IRMSMsg.AlreadyExitMsg.ToString().Trim();
                            return;
                        }
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (this.InvestorRoomID != Guid.Empty)
                    {
                        InvestorsUnit objUpd = new InvestorsUnit();
                        InvestorsUnit objOldInvestorsUnitData = new InvestorsUnit();

                        objUpd = InvestorsUnitBLL.GetByPrimaryKey(this.InvestorRoomID);
                        objOldInvestorsUnitData = InvestorsUnitBLL.GetByPrimaryKey(this.InvestorRoomID);

                        objUpd.InvestorID = new Guid(ddlInvestor.SelectedValue);
                        objUpd.RoomID = new Guid(ddlUnitNo.SelectedValue);
                        objUpd.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
                        objUpd.RatePerSqtft = Convert.ToDecimal(txtRatePerSqtFt.Text.Trim());

                        if (txtDateOfBooking.Text.Trim() != "")
                            objUpd.DateOfBooking = DateTime.ParseExact(txtDateOfBooking.Text.Trim(), this.DateFormat, objCultureInfo);
                        else
                            objUpd.DateOfBooking = null;


                        if (txtRegistrationDate.Text.Trim() != "")
                            objUpd.RegistrationDate = DateTime.ParseExact(txtRegistrationDate.Text.Trim(), this.DateFormat, objCultureInfo);
                        else
                            objUpd.RegistrationDate = null;


                        if (txtFinalPaymentDate.Text.Trim() != "")
                            objUpd.FinalPaymentDate = DateTime.ParseExact(txtFinalPaymentDate.Text.Trim(), this.DateFormat, objCultureInfo);
                        else
                            objUpd.FinalPaymentDate = null;

                        objUpd.SellerCompany = Convert.ToString(txtSellerCompany.Text.Trim());

                        if (!(txtAgToSellValue.Text.Trim().Equals("")))
                            objUpd.AgreementToSellValue = Convert.ToDecimal(txtAgToSellValue.Text.Trim());
                        else
                            objUpd.AgreementToSellValue = null;
                        if (!(txtStampDutyonAgrtoSell.Text.Trim().Equals("")))
                            objUpd.StmpDutyOnAgrToSell = Convert.ToDecimal(txtStampDutyonAgrtoSell.Text.Trim());
                        else
                            objUpd.StmpDutyOnAgrToSell = null;
                        if (!(txtStampDutyonSaleDeed.Text.Trim().Equals("")))
                            objUpd.StmpDutyOnSaleDeed = Convert.ToDecimal(txtStampDutyonSaleDeed.Text.Trim());
                        else
                            objUpd.StmpDutyOnSaleDeed = null;
                        if (!(txtRegistrationCharges.Text.Trim().Equals("")))
                            objUpd.RegistrationCharges = Convert.ToDecimal(txtRegistrationCharges.Text.Trim());
                        else
                            objUpd.RegistrationCharges = null;
                        if (!(txtOtherCosts.Text.Trim().Equals("")))
                            objUpd.OtherCosts = Convert.ToDecimal(txtOtherCosts.Text.Trim());
                        else
                            objUpd.OtherCosts = null;
                        if (!(txtConstructionCost.Text.Trim().Equals("")))
                            objUpd.ConstructionValue = Convert.ToDecimal(txtConstructionCost.Text.Trim());
                        else
                            objUpd.ConstructionValue = null;
                        if (!(txtVAT.Text.Trim().Equals("")))
                            objUpd.Vat = Convert.ToDecimal(txtVAT.Text.Trim());
                        else
                            objUpd.Vat = null;
                        if (!(txtSTax.Text.Trim().Equals("")))
                            objUpd.STax = Convert.ToDecimal(txtSTax.Text.Trim());
                        else
                            objUpd.STax = null;
                        if (!(txtOtherConstructorCost.Text.Trim().Equals("")))
                            objUpd.OtherConstructionCost = Convert.ToDecimal(txtOtherConstructorCost.Text.Trim());
                        else
                            objUpd.OtherConstructionCost = null;
                        if (PassationDate != null)
                            objUpd.DateOfPossession = DateTime.ParseExact(Convert.ToString(PassationDate), "MM-dd-yyyy", objCultureInfo);
                        else
                            objUpd.DateOfPossession = null;

                        if (chkIsInterestApplicable.Checked == false && chkIntAppNo.Checked == false)
                        {
                            objUpd.IsInterestApplicable = false;
                            objUpd.RateOfInterest = null;
                        }
                        else if (chkIsInterestApplicable.Checked == true && chkIntAppNo.Checked == false)
                        {
                            objUpd.IsInterestApplicable = true;
                            if (!(txtRateOfInterest.Text.Trim().Equals("")))
                                objUpd.RateOfInterest = Convert.ToDecimal(txtRateOfInterest.Text.Trim());
                            else
                                objUpd.RateOfInterest = null;
                        }
                        else if (chkIsInterestApplicable.Checked == false && chkIntAppNo.Checked == true)
                        {
                            objUpd.IsInterestApplicable = false;
                            objUpd.RateOfInterest = null;
                        }
                        else { objUpd.IsInterestApplicable = false; objUpd.RateOfInterest = null; }

                        objUpd.UpdateOn = DateTime.Now;
                        objUpd.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        Room objGetRoomData = new Room();
                        if (objOldInvestorsUnitData.RoomID.ToString() == objUpd.RoomID.ToString())
                            objGetRoomData = null;
                        else
                        {
                            objGetRoomData = RoomBLL.GetByPrimaryKey(new Guid(ddlUnitNo.SelectedValue));
                            objGetRoomData.IsSold = true;
                            objGetRoomData.InvesterID = new Guid(ddlInvestor.SelectedValue);

                            Room objRoomData = new Room();
                            objRoomData = RoomBLL.GetByPrimaryKey((Guid)objOldInvestorsUnitData.RoomID);
                            objRoomData.InvesterID = null;
                            objRoomData.IsSold = null;
                            RoomBLL.Update(objRoomData);
                        }

                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtDate = (TextBox)gvDocument.Rows[i].FindControl("txtDate");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            HiddenField hdnDocumentName = (HiddenField)gvDocument.Rows[i].FindControl("hdnDocumentName");

                            if (fuDocument.FileName != "")
                            {
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "IUD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Investor Unit";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtDate.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                                d1.IsSynch = false;
                                lstDocuments.Add(d1);
                            }
                            else if (hdnDocumentName.Value != "")
                            {
                                Documents d5 = new Documents();
                                d5.DocumentName = hdnDocumentName.Value;
                                d5.Extension = System.IO.Path.GetExtension(hdnDocumentName.Value);
                                d5.DateOfSubmission = DateTime.Now;
                                d5.CreatedOn = DateTime.Now;
                                d5.IsActive = true;
                                d5.AssociationType = "Investor Unit";
                                d5.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d5.Notes = txtDate.Text.Trim();
                                d5.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                d5.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                d5.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                                d5.IsSynch = false;
                                lstDocuments.Add(d5);
                            }
                        }
                        InvestorsUnitBLL.Update(objUpd, objGetRoomData, lstDocuments);
                        this.InvestorRoomID = objUpd.InvestorRoomID;
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldInvestorsUnitData.ToString(), objUpd.ToString(), "irm_InvestorsUnit");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        InvestorsUnit objIns = new InvestorsUnit();

                        objIns.InvestorID = new Guid(ddlInvestor.SelectedValue);
                        objIns.RoomID = new Guid(ddlUnitNo.SelectedValue);
                        objIns.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
                        objIns.RatePerSqtft = Convert.ToDecimal(txtRatePerSqtFt.Text.Trim());

                        if (!(txtAgToSellValue.Text.Trim().Equals("")))
                            objIns.AgreementToSellValue = Convert.ToDecimal(txtAgToSellValue.Text.Trim());
                        else
                            objIns.AgreementToSellValue = null;
                        if (!(txtStampDutyonAgrtoSell.Text.Trim().Equals("")))
                            objIns.StmpDutyOnAgrToSell = Convert.ToDecimal(txtStampDutyonAgrtoSell.Text.Trim());
                        else
                            objIns.StmpDutyOnAgrToSell = null;
                        if (!(txtStampDutyonSaleDeed.Text.Trim().Equals("")))
                            objIns.StmpDutyOnSaleDeed = Convert.ToDecimal(txtStampDutyonSaleDeed.Text.Trim());
                        else
                            objIns.StmpDutyOnSaleDeed = null;
                        if (!(txtRegistrationCharges.Text.Trim().Equals("")))
                            objIns.RegistrationCharges = Convert.ToDecimal(txtRegistrationCharges.Text.Trim());
                        else
                            objIns.RegistrationCharges = null;
                        if (!(txtOtherCosts.Text.Trim().Equals("")))
                            objIns.OtherCosts = Convert.ToDecimal(txtOtherCosts.Text.Trim());
                        else
                            objIns.OtherCosts = null;
                        if (!(txtConstructionCost.Text.Trim().Equals("")))
                            objIns.ConstructionValue = Convert.ToDecimal(txtConstructionCost.Text.Trim());
                        else
                            objIns.ConstructionValue = null;
                        if (!(txtVAT.Text.Trim().Equals("")))
                            objIns.Vat = Convert.ToDecimal(txtVAT.Text.Trim());
                        else
                            objIns.Vat = null;
                        if (!(txtSTax.Text.Trim().Equals("")))
                            objIns.STax = Convert.ToDecimal(txtSTax.Text.Trim());
                        else
                            objIns.STax = null;
                        if (!(txtOtherConstructorCost.Text.Trim().Equals("")))
                            objIns.OtherConstructionCost = Convert.ToDecimal(txtOtherConstructorCost.Text.Trim());
                        else
                            objIns.OtherConstructionCost = null;
                        //objIns.DateOfPossession = DateTime.ParseExact(Convert.ToString(PassationDate), this.DateFormat, objCultureInfo);
                        if (PassationDate != null)
                            objIns.DateOfPossession = DateTime.ParseExact(Convert.ToString(PassationDate), "MM-dd-yyyy", objCultureInfo);
                        else
                            objIns.DateOfPossession = null;

                        if (chkIsInterestApplicable.Checked == false && chkIntAppNo.Checked == false)
                        {
                            objIns.IsInterestApplicable = false;
                            objIns.RateOfInterest = null;
                        }
                        else if (chkIsInterestApplicable.Checked == true && chkIntAppNo.Checked == false)
                        {
                            objIns.IsInterestApplicable = true;
                            if (!(txtRateOfInterest.Text.Trim().Equals("")))
                                objIns.RateOfInterest = Convert.ToDecimal(txtRateOfInterest.Text.Trim());
                            else
                                objIns.RateOfInterest = null;
                        }
                        else if (chkIsInterestApplicable.Checked == false && chkIntAppNo.Checked == true)
                        {
                            objIns.IsInterestApplicable = false;
                            objIns.RateOfInterest = null;
                        }
                        else { objIns.IsInterestApplicable = false; objIns.RateOfInterest = null; }

                        if (txtDateOfBooking.Text.Trim() != "")
                            objIns.DateOfBooking = DateTime.ParseExact(txtDateOfBooking.Text.Trim(), this.DateFormat, objCultureInfo);


                        if (txtRegistrationDate.Text.Trim() != "")
                            objIns.RegistrationDate = DateTime.ParseExact(txtRegistrationDate.Text.Trim(), this.DateFormat, objCultureInfo);



                        if (txtFinalPaymentDate.Text.Trim() != "")
                            objIns.FinalPaymentDate = DateTime.ParseExact(txtFinalPaymentDate.Text.Trim(), this.DateFormat, objCultureInfo);


                        objIns.SellerCompany = Convert.ToString(txtSellerCompany.Text.Trim());

                        objIns.IsActive = true;
                        objIns.CreatedOn = DateTime.Now;
                        objIns.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));

                        for (int i = 0; i < gvDocument.Rows.Count; i++)
                        {
                            TextBox txtDate = (TextBox)gvDocument.Rows[i].FindControl("txtDate");
                            FileUpload fuDocument = (FileUpload)gvDocument.Rows[i].FindControl("fuDocument");
                            HiddenField hdnDocumentName = (HiddenField)gvDocument.Rows[i].FindControl("hdnDocumentName");

                            if (fuDocument.FileName != "")
                            {
                                Documents d1 = new Documents();
                                string FileInCorporatonNo = "IUD$" + Guid.NewGuid().ToString().Substring(0, 10) + "$" + fuDocument.FileName.Replace(" ", "_");
                                string path1 = Server.MapPath("~/Document/" + FileInCorporatonNo);
                                fuDocument.SaveAs(path1);
                                d1.DocumentName = FileInCorporatonNo;
                                d1.Extension = System.IO.Path.GetExtension(fuDocument.FileName);
                                d1.CreatedOn = DateTime.Now;
                                d1.IsActive = true;
                                d1.AssociationType = "Investor Unit";
                                d1.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                                d1.Notes = txtDate.Text.Trim();
                                d1.TypeID = new Guid(gvDocument.DataKeys[i].Value.ToString());
                                d1.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                                d1.PropertyID = new Guid(ddlPropertyName.SelectedValue);
                                d1.DateOfSubmission = DateTime.Now;
                                d1.IsSynch = false;
                                lstDocuments.Add(d1);
                            }
                        }


                        Room objGetRoomData = new Room();
                        objGetRoomData = RoomBLL.GetByPrimaryKey(new Guid(ddlUnitNo.SelectedValue));
                        objGetRoomData.IsSold = true;
                        objGetRoomData.InvesterID = new Guid(ddlInvestor.SelectedValue);

                        InvestorsUnitBLL.Save(objIns, objGetRoomData, lstDocuments);
                        //SendEmail(objIns.InvestorRoomID);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "irm_InvestorsUnit");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                        this.InvestorRoomID = objIns.InvestorRoomID;
                    }
                    LoadInvestorsUnitData();
                    BindGrid();
                    //ClearControl();
                }

                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Button Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //try
            //{
            Response.Redirect("~/Applications/Investors/InvestorUnitList.aspx?Val=True");
            //ClearControl();
            //btnSave.Visible = btnSaveUp.Visible = Convert.ToBoolean(ViewState["Add"]);
            //}

            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event
        protected void grdInvestorUnitList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    this.InvestorRoomID = new Guid(Convert.ToString(e.CommandArgument));
                    LoadAccess();
                    LoadInvestorsUnitData();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.InvestorRoomID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorUnitList_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView row = (DataRowView)e.Row.DataItem;

                    string DocumentName = string.Empty;
                    DocumentName = DataBinder.Eval(e.Row.DataItem, "DocumentName").ToString();
                    string str = "~/Document/" + DocumentName;

                    HtmlAnchor aDocumentLink = (HtmlAnchor)e.Row.FindControl("aDocumentLink");
                    ImageButton btnDeleteDocument = (ImageButton)e.Row.FindControl("btnDeleteDocument");

                    if (DocumentName != string.Empty && DocumentName != null)
                    {
                        aDocumentLink.Visible = true;
                        aDocumentLink.HRef = str;
                        //btnDeleteDocument.Visible = true;
                        btnDeleteDocument.Visible = Convert.ToBoolean(ViewState["Delete"]);
                    }
                    else
                    {
                        btnDeleteDocument.Visible = false;
                        aDocumentLink.Visible = false;
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
        /// Row Command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("DELETEDATA"))
            {
                DocumentsBLL.Delete(new Guid(Convert.ToString(e.CommandArgument)));
                LoadDocumentGrid();

            }
        }
        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInvestorsUnitYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.InvestorRoomID != Guid.Empty)
                {
                    msgbx.Hide();
                    InvestorsUnit objDelete = InvestorsUnitBLL.GetByPrimaryKey(this.InvestorRoomID);
                    InvestorsUnitBLL.Delete(objDelete);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "irm_InvestorsUnit");
                    IsMessage = true;
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteMsg.ToString().Trim();
                }
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInvestorsUnitNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();
                ClearControl();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            lblSubTotalConstructionAgreement.Text = Convert.ToString(hdnConstructionAgreement.Value);
            lblSubTotalAgreementToSell.Text = Convert.ToString(hdnAgreementtoSell.Value);

            if (txtUnitPrice.Text.Trim() != string.Empty && txtSBA.Text.Trim() != string.Empty)
            {
                decimal Value = Convert.ToDecimal(txtUnitPrice.Text) / Convert.ToDecimal(txtSBA.Text);
                if (Value.ToString().IndexOf(".") != -1)
                {
                    int NoOFValue = Value.ToString().Length - Convert.ToInt32(Value.ToString().IndexOf("."));
                    if (NoOFValue > 2)
                        txtRatePerSqtFt.Text = Convert.ToString(Value.ToString().Substring(0, Value.ToString().IndexOf(".") + 3));
                    else
                        txtRatePerSqtFt.Text = Convert.ToString(Value);
                }
                else
                    txtRatePerSqtFt.Text = Convert.ToString(Convert.ToDecimal(Value));
                txtAgToSellValue.Focus();
            }
            else
                txtRatePerSqtFt.Text = "0.00";
        }

        #region CheckBox Check Event
        /// <summary>
        /// Yes Check Box Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkIsInterestApplicable_CheckedChanged(object sender, EventArgs e)
        {
            lblSubTotalConstructionAgreement.Text = Convert.ToString(hdnConstructionAgreement.Value);
            lblSubTotalAgreementToSell.Text = Convert.ToString(hdnAgreementtoSell.Value);

            if (chkIsInterestApplicable.Checked)
            {
                trRateOfInterest.Visible = true;
                txtRateOfInterest.Text = "";
                chkIntAppNo.Checked = false;
            }
            else
            {
                trRateOfInterest.Visible = false;
                txtRateOfInterest.Text = "";
            }
        }
        /// <summary>
        /// No Check Box Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void chkIntAppNo_CheckedChanged(object sender, EventArgs e)
        {
            lblSubTotalConstructionAgreement.Text = Convert.ToString(hdnConstructionAgreement.Value);
            lblSubTotalAgreementToSell.Text = Convert.ToString(hdnAgreementtoSell.Value);

            if (chkIntAppNo.Checked)
            {
                trRateOfInterest.Visible = false;
                txtRateOfInterest.Text = "";
                chkIsInterestApplicable.Checked = false;
            }
            else
            {
                trRateOfInterest.Visible = false;
                txtRateOfInterest.Text = "";
            }
        }

        #endregion CheckBox Check Event

        #region DateOfBooking Validation
        protected void vDataOfBooking_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1900/12/01");
            //year/month/date
            //DateTime maxDate = DateTime.Parse(DateTime.Now.ToString(clsSession.DateFormat));
            DateTime maxDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
        protected void vRegistrationDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1900/12/01");
            DateTime maxDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
        protected void vFinalPaymentDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1900/12/01");
            DateTime maxDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
        
        #endregion DateOfBooking Validation
    }
}