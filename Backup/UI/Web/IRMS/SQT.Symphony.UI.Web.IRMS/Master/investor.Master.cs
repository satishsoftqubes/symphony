using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.Master
{
    public partial class investor : System.Web.UI.MasterPage
    {
        #region Property and Variables

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

        #endregion Property and Variables

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));

                if (Session["PropertyConfigurationInfo"] != null)
                {
                    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                    string ProjectTermDateQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And TermID= '" + objPropertyConfiguration.DateFormatID + "' And CompanyID= '" + this.CompanyID + "'";
                    DataSet dsDate = ProjectTermBLL.SelectData(ProjectTermDateQuery);

                    string ProjectTermTimeQuery = "Select TermID, Term From mst_ProjectTerm Where IsActive = 1 And TermID= '" + objPropertyConfiguration.TimeFormatID + "' And CompanyID= '" + this.CompanyID + "'";
                    DataSet dsTime = ProjectTermBLL.SelectData(ProjectTermTimeQuery);
                    if (dsDate.Tables[0].Rows.Count != 0)
                        litDate.Text = DateTime.Now.Date.ToString(Convert.ToString(dsDate.Tables[0].Rows[0]["Term"]));
                    else
                        litDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

                    if (dsTime.Tables[0].Rows.Count != 0)
                        litTime.Text = DateTime.Now.ToString(Convert.ToString(dsTime.Tables[0].Rows[0]["Term"]));
                    else
                        litTime.Text = DateTime.Now.ToString("hh:mm");
                }
                else
                {
                    litDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    litTime.Text = DateTime.Now.ToString("hh:mm");
                }
                lblUserName.Text = Convert.ToString(Session["User"]);
                if (Session["InvID"] == null)
                    lblInvestorName.Text = "INFORMATION";
                else
                {
                    Investor Inv = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["InvID"])));
                    if (Inv != null)
                        lblInvestorName.Text = Inv.Title + " " + Inv.FName + " " + Inv.LName;
                }

                //BindInvestorToUpdateInfo();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }

        }
        #endregion

        #region Control Event
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
        #endregion

        #region Methods
        /* 
        public void BindInvestorToUpdateInfo()
        {
            string strInvestorIndicationInfo = "";
            if (Session["InvID"] != null)
            {
                //// Session value is not set, so Get value from DB and set controls' visibility.
                if (Session["InvestorIndicationInfo"] == null)
                {
                    //// Don't change ROWS OPERATION ORDER and 5 CONTROL'S VISIBILITY SETTING ORDER
                    //// Don't change ROWS OPERATION ORDER and 5 CONTROL'S VISIBILITY SETTING ORDER
                    //// Don't change ROWS OPERATION ORDER and 5 CONTROL'S VISIBILITY SETTING ORDER
                    DataSet dsInvInfo = InvestorBLL.SelectForInvestorUpdateIndication(new Guid(Convert.ToString(Session["InvID"])));
                    DataRow dr = null;
                    if (dsInvInfo != null && dsInvInfo.Tables.Count > 0)
                    {
                        if (dsInvInfo.Tables[0].Rows.Count > 0)
                        {
                            dr = dsInvInfo.Tables[0].Rows[0];
                            if (Convert.ToString(dr["InvestorFullName"]) != string.Empty)
                            {
                                trUpdateOwnerDOB.Visible = Convert.ToString(dr["DateOfBirth"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdateOwnerDOB.Visible ? "1|" : "0|";
                                trUpdateOwnerPANNo.Visible = Convert.ToString(dr["PanNo"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdateOwnerPANNo.Visible ? "1|" : "0|";
                                trUpdateOwnerBankName.Visible = Convert.ToString(dr["BankName"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdateOwnerBankName.Visible ? "1|" : "0|";
                                trUpdateOwnerBankAcctNo.Visible = Convert.ToString(dr["AccountNo"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdateOwnerBankAcctNo.Visible ? "1|" : "0|";
                                trUpdateOwnerIFSCCode.Visible = Convert.ToString(dr["IFSCCode"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdateOwnerIFSCCode.Visible ? "1|" : "0|";
                                trUpdtFristOwnerTitle.Visible = (trUpdateOwnerDOB.Visible || trUpdateOwnerPANNo.Visible || trUpdateOwnerBankName.Visible || trUpdateOwnerBankAcctNo.Visible || trUpdateOwnerIFSCCode.Visible);
                            }
                            else
                            {
                                strInvestorIndicationInfo += "0|0|0|0|0|";
                                trUpdtFristOwnerTitle.Visible = trUpdateOwnerDOB.Visible = trUpdateOwnerPANNo.Visible = trUpdateOwnerBankName.Visible = trUpdateOwnerBankAcctNo.Visible = trUpdateOwnerIFSCCode.Visible = false;
                            }
                        }

                        if (dsInvInfo.Tables[0].Rows.Count > 1)
                        {
                            dr = dsInvInfo.Tables[0].Rows[1];
                            if (Convert.ToString(dr["InvestorFullName"]) != string.Empty)
                            {
                                trUpdtJointOwnerDOB.Visible = Convert.ToString(dr["DateOfBirth"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdtJointOwnerDOB.Visible ? "1|" : "0|";
                                trUpdtJointOwnerPANNo.Visible = Convert.ToString(dr["PanNo"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdtJointOwnerPANNo.Visible ? "1|" : "0|";
                                trUpdtJointOwnerBankName.Visible = Convert.ToString(dr["BankName"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdtJointOwnerBankName.Visible ? "1|" : "0|";
                                trUpdtJointOwnerBankAcctNo.Visible = Convert.ToString(dr["AccountNo"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdtJointOwnerBankAcctNo.Visible ? "1|" : "0|";
                                trUpdtJointOwnerIFSCCode.Visible = Convert.ToString(dr["IFSCCode"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdtJointOwnerIFSCCode.Visible ? "1|" : "0|";
                                trUpdtJointOwnerTitle.Visible = (trUpdtJointOwnerDOB.Visible || trUpdtJointOwnerPANNo.Visible || trUpdtJointOwnerBankName.Visible || trUpdtJointOwnerBankAcctNo.Visible || trUpdtJointOwnerIFSCCode.Visible);
                            }
                            else
                            {
                                strInvestorIndicationInfo += "0|0|0|0|0|";
                                trUpdtJointOwnerTitle.Visible = trUpdtJointOwnerDOB.Visible = trUpdtJointOwnerPANNo.Visible = trUpdtJointOwnerBankName.Visible = trUpdtJointOwnerBankAcctNo.Visible = trUpdtJointOwnerIFSCCode.Visible = false;
                            }
                        }

                        if (dsInvInfo.Tables[0].Rows.Count > 2)
                        {
                            dr = dsInvInfo.Tables[0].Rows[2];
                            if (Convert.ToString(dr["InvestorFullName"]) != string.Empty)
                            {
                                trUpdt2ndJointOwnerDOB.Visible = Convert.ToString(dr["DateOfBirth"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdt2ndJointOwnerDOB.Visible ? "1|" : "0|";
                                trUpdt2ndJointOwnerPANNo.Visible = Convert.ToString(dr["PanNo"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdt2ndJointOwnerPANNo.Visible ? "1|" : "0|";
                                trUpdt2ndJointOwnerBankName.Visible = Convert.ToString(dr["BankName"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdt2ndJointOwnerBankName.Visible ? "1|" : "0|";
                                trUpdt2ndJointOwnerBankAcctNo.Visible = Convert.ToString(dr["AccountNo"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdt2ndJointOwnerBankAcctNo.Visible ? "1|" : "0|";
                                trUpdt2ndJointOwnerIFSCCode.Visible = Convert.ToString(dr["IFSCCode"]) == string.Empty;
                                strInvestorIndicationInfo += trUpdt2ndJointOwnerIFSCCode.Visible ? "1|" : "0|";
                                trUpdt2ndJointOwnerTitle.Visible = (trUpdt2ndJointOwnerDOB.Visible || trUpdt2ndJointOwnerPANNo.Visible || trUpdt2ndJointOwnerBankName.Visible || trUpdt2ndJointOwnerBankAcctNo.Visible || trUpdt2ndJointOwnerIFSCCode.Visible);
                            }
                            else
                            {
                                strInvestorIndicationInfo += "0|0|0|0|0|";
                                trUpdt2ndJointOwnerTitle.Visible = trUpdt2ndJointOwnerDOB.Visible = trUpdt2ndJointOwnerPANNo.Visible = trUpdt2ndJointOwnerBankName.Visible = trUpdt2ndJointOwnerBankAcctNo.Visible = trUpdt2ndJointOwnerIFSCCode.Visible = false;
                            }
                        }

                        tblUpdateIndication.Visible = (trUpdtFristOwnerTitle.Visible || trUpdtJointOwnerTitle.Visible || trUpdt2ndJointOwnerTitle.Visible);
                        Session["InvestorIndicationInfo"] = strInvestorIndicationInfo;
                    }
                    else
                    {
                        //// No record found with session's investorID, so set 0000 value.
                        Session["InvestorIndicationInfo"] = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|";
                        tblUpdateIndication.Visible = false;
                        trUpdtFristOwnerTitle.Visible = trUpdateOwnerDOB.Visible = trUpdateOwnerPANNo.Visible = trUpdateOwnerBankName.Visible = trUpdateOwnerBankAcctNo.Visible = trUpdateOwnerIFSCCode.Visible = false;
                        trUpdtJointOwnerTitle.Visible = trUpdtJointOwnerDOB.Visible = trUpdtJointOwnerPANNo.Visible = trUpdtJointOwnerBankName.Visible = trUpdtJointOwnerBankAcctNo.Visible = trUpdtJointOwnerIFSCCode.Visible = false;
                        trUpdt2ndJointOwnerTitle.Visible = trUpdt2ndJointOwnerDOB.Visible = trUpdt2ndJointOwnerPANNo.Visible = trUpdt2ndJointOwnerBankName.Visible = trUpdt2ndJointOwnerBankAcctNo.Visible = trUpdt2ndJointOwnerIFSCCode.Visible = false;
                    }
                }
                else//// Session value is set, so Get value from session instead of DB and set controls' visibility.
                {
                    string[] strArray = Convert.ToString(Session["InvestorIndicationInfo"]).Split('|');

                    trUpdateOwnerDOB.Visible = Convert.ToString(strArray[0]) == "1";
                    trUpdateOwnerPANNo.Visible = Convert.ToString(strArray[1]) == "1";
                    trUpdateOwnerBankName.Visible = Convert.ToString(strArray[2]) == "1";
                    trUpdateOwnerBankAcctNo.Visible = Convert.ToString(strArray[3]) == "1";
                    trUpdateOwnerIFSCCode.Visible = Convert.ToString(strArray[4]) == "1";
                    trUpdtFristOwnerTitle.Visible = (trUpdateOwnerDOB.Visible || trUpdateOwnerPANNo.Visible || trUpdateOwnerBankName.Visible || trUpdateOwnerBankAcctNo.Visible || trUpdateOwnerIFSCCode.Visible);

                    trUpdtJointOwnerDOB.Visible = Convert.ToString(strArray[5]) == "1";
                    trUpdtJointOwnerPANNo.Visible = Convert.ToString(strArray[6]) == "1";
                    trUpdtJointOwnerBankName.Visible = Convert.ToString(strArray[7]) == "1";
                    trUpdtJointOwnerBankAcctNo.Visible = Convert.ToString(strArray[8]) == "1";
                    trUpdtJointOwnerIFSCCode.Visible = Convert.ToString(strArray[9]) == "1";
                    trUpdtJointOwnerTitle.Visible = (trUpdtJointOwnerDOB.Visible || trUpdtJointOwnerPANNo.Visible || trUpdtJointOwnerBankName.Visible || trUpdtJointOwnerBankAcctNo.Visible || trUpdtJointOwnerIFSCCode.Visible);

                    trUpdt2ndJointOwnerDOB.Visible = Convert.ToString(strArray[10]) == "1";
                    trUpdt2ndJointOwnerPANNo.Visible = Convert.ToString(strArray[11]) == "1";
                    trUpdt2ndJointOwnerBankName.Visible = Convert.ToString(strArray[12]) == "1";
                    trUpdt2ndJointOwnerBankAcctNo.Visible = Convert.ToString(strArray[13]) == "1";
                    trUpdt2ndJointOwnerIFSCCode.Visible = Convert.ToString(strArray[14]) == "1";
                    trUpdt2ndJointOwnerTitle.Visible = (trUpdt2ndJointOwnerDOB.Visible || trUpdt2ndJointOwnerPANNo.Visible || trUpdt2ndJointOwnerBankName.Visible || trUpdt2ndJointOwnerBankAcctNo.Visible || trUpdt2ndJointOwnerIFSCCode.Visible);

                    tblUpdateIndication.Visible = (trUpdtFristOwnerTitle.Visible || trUpdtJointOwnerTitle.Visible || trUpdt2ndJointOwnerTitle.Visible);
                }
            }
            else
            {
                Session["InvestorIndicationInfo"] = "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|";
                tblUpdateIndication.Visible = false;
                trUpdtFristOwnerTitle.Visible = trUpdateOwnerDOB.Visible = trUpdateOwnerPANNo.Visible = trUpdateOwnerBankName.Visible = trUpdateOwnerBankAcctNo.Visible = trUpdateOwnerIFSCCode.Visible = false;
                trUpdtJointOwnerTitle.Visible = trUpdtJointOwnerDOB.Visible = trUpdtJointOwnerPANNo.Visible = trUpdtJointOwnerBankName.Visible = trUpdtJointOwnerBankAcctNo.Visible = trUpdtJointOwnerIFSCCode.Visible = false;
                trUpdt2ndJointOwnerTitle.Visible = trUpdt2ndJointOwnerDOB.Visible = trUpdt2ndJointOwnerPANNo.Visible = trUpdt2ndJointOwnerBankName.Visible = trUpdt2ndJointOwnerBankAcctNo.Visible = trUpdt2ndJointOwnerIFSCCode.Visible = false;
            }
        }
        */
        #endregion
    }
}