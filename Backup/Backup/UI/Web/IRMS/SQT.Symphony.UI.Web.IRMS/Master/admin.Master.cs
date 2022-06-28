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
    public partial class admin : System.Web.UI.MasterPage
    {
        public bool? IsPreview = false;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CompanyID"] != null)
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                if (Session["User"] != null)
                {
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

                    if (Request.QueryString["Val"] != null)
                    {
                        if (Session["InvID"] == null)
                            lblInvestorName.Text = "SETUP";
                        else
                        {
                            if (Session["InvID"] != null)
                            {
                                Investor Inv = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["InvID"])));
                                lblInvestorName.Text = Inv.Title + " " + Inv.FName + " " + Inv.LName;
                                spnInvestorName.Attributes.Add("style", "padding:0px;");
                            }
                            else
                                lblInvestorName.Text = "SETUP";
                        }
                    }
                    else
                    {
                        Session["InvID"] = null;
                        lblInvestorName.Text = "SETUP";
                    }                   
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }                        
    }
}