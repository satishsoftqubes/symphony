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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard
{
    public partial class CtrlUnitInformation : System.Web.UI.UserControl
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
        public Guid InvestorID
        {
            get
            {
                return ViewState["InvestorID"] != null ? new Guid(Convert.ToString(ViewState["InvestorID"])) : Guid.Empty;
            }
            set
            {
                ViewState["InvestorID"] = value;
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
            if (Session["CompanyID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    this.InvestorID = new Guid(Convert.ToString(Session["InvID"]));
                    LoadDefaultData();
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                DataSet DstInvUnt = InvestorsUnitBLL.GetInvestorUnitInfo(this.InvestorID, this.CompanyID);
                if (DstInvUnt != null)
                {
                    if (DstInvUnt.Tables[0].Rows.Count != 0)
                    {
                        DataTable dtMainProspects = DstInvUnt.Tables[0];
                        DataTable dtToBindProspects = dtMainProspects.Clone();
                        int forForLoopProspectus = dtMainProspects.Rows.Count >= 2 ? 2 : dtMainProspects.Rows.Count;
                        for (int i = 0; i < forForLoopProspectus; i++)
                        {
                            dtToBindProspects.ImportRow(dtMainProspects.Rows[i]);
                        }

                        int totalUnit = 0;
                        foreach (DataRow dr in DstInvUnt.Tables[0].Rows)
                        {
                            totalUnit += Convert.ToInt32(dr["TotalUnitCount"].ToString());
                        }

                        lblProspectsCount.Text = Convert.ToString(totalUnit);
                        gvProspects.DataSource = dtToBindProspects;
                        gvProspects.DataBind();
                    }
                    else
                    {
                        gvProspects.DataSource = null;
                        gvProspects.DataBind();
                        lblProspectsCount.Text = "0";
                    }
                }
                else
                {
                    gvProspects.DataSource = null;
                    gvProspects.DataBind();
                    lblProspectsCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessageForUnitInformation();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Private Method
    }
}