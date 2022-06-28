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
    public partial class CltrDashBoardChannelPartners : System.Web.UI.UserControl
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
                    BindChannelPartnersData();
                }
            }
        }

        #endregion PageLoad Event

        #region PrivateMethod

        private void BindChannelPartnersData()
        {
            try
            {
                Guid? UserID;
                string UserType = Convert.ToString(Session["UserType"]);
                if (UserType.ToUpper() == "ADMIN")
                    UserID = null;
                else
                    UserID = new Guid(Convert.ToString(Session["UserID"]));
                DataSet dsChannelPartners = PropertyBLL.GetIndexDashBoard(this.CompanyID, UserID);
                if (dsChannelPartners != null)
                {
                    if (dsChannelPartners.Tables[3].Rows.Count != 0)
                    {
                        DataTable dtMainChannelPartner = dsChannelPartners.Tables[3];
                        DataTable dtToBindChannelPartner = dtMainChannelPartner.Clone();

                        int forForLoopCP = dtMainChannelPartner.Rows.Count >= 2 ? 2 : dtMainChannelPartner.Rows.Count;

                        for (int i = 0; i < forForLoopCP; i++)
                        {
                            dtToBindChannelPartner.ImportRow(dtMainChannelPartner.Rows[i]);
                        }
                        gvChannelPartner.DataSource = dtToBindChannelPartner;
                        gvChannelPartner.DataBind();
                        lblCPCount.Text = Convert.ToString(dsChannelPartners.Tables[3].Rows.Count);
                    }
                    else
                    {
                        gvChannelPartner.DataSource = null;
                        gvChannelPartner.DataBind();
                        lblCPCount.Text = "0";
                    }
                }
                else
                {
                    gvChannelPartner.DataSource = null;
                    gvChannelPartner.DataBind();
                    lblCPCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessageForChannelPartners();", true);
                MsgBoxChannelPartners.Show(ex.Message.ToString());
            }
        }

        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
        }

        #endregion PrivateMethod

        #region Grid Event

        protected void gvChannelPartner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litDBMobileNo = (Literal)e.Row.FindControl("litDBMobileNo");

                string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                if (litDBMobileNo != null)
                {
                    if (Convert.ToString(strMobileNo) != "")
                        litDBMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                    else
                        litDBMobileNo.Text = "";
                }
            }
        }
        #endregion
    }
}