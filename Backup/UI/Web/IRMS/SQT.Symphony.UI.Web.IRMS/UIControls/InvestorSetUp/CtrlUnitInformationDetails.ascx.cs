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
using System.Web.UI.HtmlControls;
using System.IO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlUnitInformationDetails : System.Web.UI.UserControl
    {
        #region Property and Variables

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

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["InvestorRoomID"] != null)
                    {
                        if (Session["PropertyConfigurationInfo"] != null)
                        {
                            if (Session["CompanyID"] == null)
                            {
                                Session.Clear();
                                Response.Redirect("~/Default.aspx");
                            }
                            this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                            PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];

                            string ProjectTermQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And CompanyID= '" + this.CompanyID + "' And TermID= '" + objPropertyConfiguration.DateFormatID + "'";
                            DataSet ds = ProjectTermBLL.SelectData(ProjectTermQuery);

                            if (ds.Tables[0].Rows.Count != 0)
                                this.DateFormat = Convert.ToString(ds.Tables[0].Rows[0]["Term"]);
                            else
                                this.DateFormat = "dd/MM/yyyy";
                        }
                        else
                            this.DateFormat = "dd/MM/yyyy";

                        this.InvestorRoomID = new Guid(Convert.ToString(Session["InvestorRoomID"]));
                        Session.Remove("InvestorRoomID");

                        BindInvestorUnitData();
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindInvestorUnitData()
        {
            DataSet ds = InvestorsUnitBLL.SearchInvestorsUnitData(this.InvestorRoomID, null, null, null, null, null);
            if (ds.Tables[0].Rows.Count != 0)
            {
                litInvestorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["InvestorName"]);
                LitPropertyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PropertyName"]);
                ltUnitType.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoomTypeName"]);
                LitUniteNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoomNo"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["SBArea"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["SBArea"]) != null)
                    ltSBArea.Text = Convert.ToString(ds.Tables[0].Rows[0]["SBArea"]);
                litUnitPrise.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnitPrice"]);
                litRatePerST.Text = Convert.ToString(ds.Tables[0].Rows[0]["RatePerSqtft"]);

                if (Convert.ToString(ds.Tables[0].Rows[0]["DateOfBooking"]) != null && Convert.ToString(ds.Tables[0].Rows[0]["DateOfBooking"]) != "")
                {
                    DateTime dtDOB = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["DateOfBooking"]));
                    ltrDateOfBooking.Text = dtDOB.ToString(this.DateFormat);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["SellerCompany"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["SellerCompany"]) != null)
                    ltrSellerCompany.Text = Convert.ToString(ds.Tables[0].Rows[0]["SellerCompany"]);

                if (Convert.ToString(ds.Tables[0].Rows[0]["AgreementToSellValue"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["AgreementToSellValue"]) != null)
                    ltAgreementSellValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgreementToSellValue"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]) != null)
                    litStmpDutyOnArgeToSell.Text = Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnAgrToSell"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]) != null)
                    litStmpdutyonsaledeedl.Text = Convert.ToString(ds.Tables[0].Rows[0]["StmpDutyOnSaleDeed"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCharges"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCharges"]) != null)
                    litRegistrationChrg.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegistrationCharges"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["OtherCosts"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["OtherCosts"]) != null)
                    litOtherCst.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherCosts"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["ConstructionValue"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["ConstructionValue"]) != null)
                    litConstructionCostValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConstructionValue"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["Vat"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["Vat"]) != null)
                    litVATValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vat"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["STax"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["STax"]) != null)
                    litSTaxValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["STax"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["OtherConstructionCost"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["OtherConstructionCost"]) != null)
                    litOtherConstructorcostValue.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherConstructionCost"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["DateOfPossession"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["DateOfPossession"]) != null)
                {
                    DateTime dtDOP = Convert.ToDateTime(Convert.ToString(ds.Tables[0].Rows[0]["DateOfPossession"]));
                    litDateOFPoss.Text = dtDOP.ToString(this.DateFormat);
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsInterestApplicable"]) == true)
                    litInterestRate.Text = "Yes";
                if (Convert.ToString(ds.Tables[0].Rows[0]["RateOfInterest"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["RateOfInterest"]) != null)
                    litRateOfINte.Text = Convert.ToString(ds.Tables[0].Rows[0]["RateOfInterest"]) + "%";


                if (Convert.ToString(ds.Tables[0].Rows[0]["TotalCost"]) != "" && Convert.ToString(ds.Tables[0].Rows[0]["TotalCost"]) != null)
                    litDisplayTotalCosts.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalCost"]);
                

                DataSet dsDocumentList = DocumentsBLL.GetDocumentGrid(null, null, this.CompanyID, "INVESTOR UNIT DOCUMENT", this.InvestorRoomID);
                if (dsDocumentList.Tables[0].Rows.Count != 0)
                {
                    gvDocument.DataSource = dsDocumentList.Tables[0];
                    gvDocument.DataBind();
                }


                //if (lstGetDocuments.Count != 0)
                //{
                //    for (int i = 0; i < lstGetDocuments.Count; i++)
                //    {
                //        string[] file = lstGetDocuments[i].DocumentName.Split(new char[] { '$' });
                //        if (file.Length != 0)
                //        {
                //            string str = "~/Document/" + lstGetDocuments[i].DocumentName;

                //            if (file[0] == "AgreementtoSell")
                //                ddlAgreement.Text = "Completed";
                //            else if (file[0] == "ConstructionAgreement")
                //                ddlConstructionArgeement.Text = "Completed";
                //            else if (file[0] == "PropertyMgmtAgreement")
                //                ddlPropertyMgmtArreement.Text = "Completed";
                //            else if (file[0] == "AbsoluteSaleDeed")
                //                ddlAbsoluteSaleDeed.Text = "Completed";
                //            else if (file[0] == "Registration")
                //                ddlRegistration.Text = "Completed";
                //        }
                //    }
                //}
                //else
                //{
                //    ddlAgreement.Text = "NA";
                //    ddlConstructionArgeement.Text = "NA";
                //    ddlPropertyMgmtArreement.Text = "NA";
                //    ddlAbsoluteSaleDeed.Text = "NA";
                //    ddlRegistration.Text = "NA";
                //}
            }
            else
            {
                litInvestorName.Text = "-";
                LitPropertyName.Text = "-";
                ltUnitType.Text = "-";
                ltSBArea.Text = "-";
                litUnitPrise.Text = "-";
                litRatePerST.Text = "-";
                ltAgreementSellValue.Text = "-";
                litStmpDutyOnArgeToSell.Text = "-";
                litStmpdutyonsaledeedl.Text = "-";
                litRegistrationChrg.Text = "-";
                litOtherCst.Text = "-";
                litConstructionCostValue.Text = "-";
                litVATValue.Text = "-";
                litSTaxValue.Text = "-";
                litOtherConstructorcostValue.Text = "-";
                litDateOFPoss.Text = "-";
                litInterestRate.Text = "-";
                litRateOfINte.Text = "-";
                litDisplayTotalCosts.Text = "-";
                //ddlAgreement.Text = "NA";
                //ddlConstructionArgeement.Text = "NA";
                //ddlPropertyMgmtArreement.Text = "NA";
                //ddlAbsoluteSaleDeed.Text = "NA";
                //ddlRegistration.Text = "NA";
            }
        }

        #endregion Private Method

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Applications/Investors/InvestorUnitList.aspx");
        }

        protected void gvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton imgViewDoc = (ImageButton)e.Row.FindControl("imgViewDoc");

                    imgViewDoc.ToolTip = "Click to View/Download";
                    if (gvDocument.DataKeys[e.Row.DataItemIndex]["DocumentName"] != null && Convert.ToString(gvDocument.DataKeys[e.Row.DataItemIndex]["DocumentName"]) != string.Empty)
                        imgViewDoc.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }


        protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("VIEWDOC"))
                {
                    string fName = Server.MapPath("~/Document") + "\\" + Convert.ToString(e.CommandArgument);
                    FileInfo fi = new FileInfo(fName);
                    long sz = fi.Length;
                    Response.ClearContent();
                    Response.ContentType = MimeType(Path.GetExtension(fName));
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fName)));
                    Response.AddHeader("Content-Length", sz.ToString("F0"));
                    Response.TransmitFile(fName);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        } 

    }
}