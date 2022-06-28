using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard
{
    public partial class CltrDashboardProperty : System.Web.UI.UserControl
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

        #region PageLoad Event

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
                    BindPropertyData();
                }
            }
        }

        #endregion PageLoad Event

        #region PrivateMethod

        private void BindPropertyData()
        {
            try
            {
                Guid? UserID;
                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.ToUpper() == "ADMIN")
                    UserID = null;
                else
                    UserID = new Guid(Convert.ToString(Session["UserID"]));
                DataSet dsProperty = PropertyBLL.GetIndexDashBoard(this.CompanyID, UserID);
                if (dsProperty != null)
                {
                    if (dsProperty.Tables[0].Rows.Count != 0)
                    {
                        DataTable dtMain = dsProperty.Tables[0];
                        DataTable dtToBind = dtMain.Clone();

                        int forForLoopPrp = dtMain.Rows.Count >= 2 ? 2 : dtMain.Rows.Count;

                        for (int i = 0; i < forForLoopPrp; i++)
                        {
                            dtToBind.ImportRow(dtMain.Rows[i]);
                        }
                        gvPropertyDashBoard.DataSource = dtToBind;
                        gvPropertyDashBoard.DataBind();
                        lblPropertiesCount.Text = Convert.ToString(dsProperty.Tables[0].Rows.Count);
                    }
                    else
                    {
                        gvPropertyDashBoard.DataSource = null;
                        gvPropertyDashBoard.DataBind();
                        lblPropertiesCount.Text = "0";
                    }
                }
                else
                {
                    gvPropertyDashBoard.DataSource = null;
                    gvPropertyDashBoard.DataBind();
                    lblPropertiesCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessageForProperty();", true);
                MsgBoxProperty.Show(ex.Message.ToString());
            }
        }


        #endregion PrivateMethod

        #region Grid Event
        protected void gvPropertyDashBoard_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("propertyunits"))
                {
                    Session["PropertyID4UnitInfo"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/SetUp/PropertyUnits.aspx");

                }
                else if (e.CommandName.Equals("CURRENTMARKETRATE"))
                {
                    Session["PropertyID4UnitInfo"] = Convert.ToString(e.CommandArgument);
                    Response.Redirect("~/Applications/Activity/UnitTypeMarketRateList.aspx");
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        protected void gvPropertyDashBoard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal lblNoOfInvestor = (Literal)e.Row.FindControl("lblNoOfInvestor");
                Label lblDisplayNoOfInvestor = (Label)e.Row.FindControl("lblDisplayNoOfInvestor");
                LinkButton lnkCurrentMarketRate = (LinkButton)e.Row.FindControl("lnkCurrentMarketRate");

                string strUserType = Convert.ToString(Session["UserType"]);

                if (strUserType.ToUpper() == "INVESTOR")
                {
                    lblNoOfInvestor.Visible = lblDisplayNoOfInvestor.Visible = false;
                    lnkCurrentMarketRate.Visible = false;
                }
                else
                {
                    lblDisplayNoOfInvestor.Visible = lblNoOfInvestor.Visible = true;
                    lnkCurrentMarketRate.Visible = false;
                }
            }
        }
        #endregion


    }
}