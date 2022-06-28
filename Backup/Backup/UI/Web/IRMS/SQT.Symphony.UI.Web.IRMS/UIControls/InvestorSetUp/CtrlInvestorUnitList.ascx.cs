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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorUnitList : System.Web.UI.UserControl
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

        decimal grandTotal = 0;
        private DataSet ds = null;
        public bool IsPreview = false;

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

                if (!IsPostBack)
                {                  
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                }
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// 
        /// </summary>
        //private void LoadUnitType()
        //{
        //    List<RoomType> lstrm = RoomTypeBLL.GetAll();
        //    if (lstrm.Count > 0)
        //    {
        //        ddlUnitType.DataSource = lstrm;
        //        ddlUnitType.DataTextField = "RoomTypeName";
        //        ddlUnitType.DataValueField = "RoomTypeID";
        //        ddlUnitType.DataBind();
        //        ddlUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //    }

        //    else
        //        ddlUnitType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        //}
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorsUnitSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                btnAdd.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);               
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                //if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                //    btnAdd.Visible = false;
                //else
                //    btnAdd.Visible = true;

                //LoadUnitType();
                BindPropertyName();
                BindGrid();
                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string RoomTypeName = null;
            Guid? PropertyID;
            if (drpPropertyName.SelectedValue != Guid.Empty.ToString())
                PropertyID = new Guid(drpPropertyName.SelectedValue);
            else
                PropertyID = null;

            if (!(txtSearchUnitType.Text.Trim().Equals("")))
                RoomTypeName = Convert.ToString(txtSearchUnitType.Text.Trim());
            else
                RoomTypeName = null;

            Guid? InvestorID = new Guid(Convert.ToString(Session["InvID"]));
            DataSet dsIUL = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, InvestorID, PropertyID, null, RoomTypeName);
            //DataView dvIUL = new DataView(dsIUL.Tables[0]);
            //dvIUL.Sort = "PropertyName Asc";

            DataTable dtUnits = dsIUL.Tables[0];

            if (dtUnits.Rows.Count > 0)
            {
                decimal totalCount = 0;
                for (int i = 0; i < dtUnits.Rows.Count; i++)
                {
                    totalCount += Convert.ToDecimal(dtUnits.Rows[i]["TotalCost"]);
                }

                grandTotal = totalCount;

                //DataRow dr = dtUnits.NewRow();
                //dr["PropertyName"] = "Total :";
                //dr["TotalCost"] = totalCount.ToString();
                //dtUnits.Rows.Add(dr);
            }

            gvInvestorUnitList.DataSource = dtUnits;
            gvInvestorUnitList.DataBind();
        }

        /// <summary>
        /// Load Report
        /// </summary>
        private void LoadReport()
        {
            try
            {
                Guid? idPName = null;
                string strUType = null;
                if (drpPropertyName.SelectedValue != Guid.Empty.ToString())
                    idPName = new Guid(drpPropertyName.SelectedValue);
                else
                    idPName = null;

                if (!(txtSearchUnitType.Text.Trim().Equals("")))
                    strUType = Convert.ToString(txtSearchUnitType.Text.Trim());
                else
                    strUType = null;
                if (drpPropertyName.SelectedValue != Guid.Empty.ToString())
                    Session.Add("Name", new Guid(drpPropertyName.SelectedValue));
                if (txtSearchUnitType.Text.Trim() != "")
                    Session.Add("UnitType", Convert.ToString(txtSearchUnitType.Text.Trim()));
                Guid? InvestorID = new Guid(Convert.ToString(Session["InvID"]));

                ds = InvestorsUnitBLL.SearchInvestorsUnitData(null, null, InvestorID, idPName, null, strUType);
                Session["DataSource"] = ds;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

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

                drpPropertyName.DataSource = dv;
                drpPropertyName.DataTextField = "PropertyName";
                drpPropertyName.DataValueField = "PropertyID";
                drpPropertyName.DataBind();
                drpPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                drpPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }
        #endregion Private Method

        #region Grid Event
        protected void gvInvestorUnitList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton EditImg = (LinkButton)e.Row.FindControl("lnkRoomNo");
                    EditImg.Enabled = Convert.ToBoolean(ViewState["View"]);
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if((Label)e.Row.FindControl("lblTotalFooter") != null)
                        ((Label)e.Row.FindControl("lblTotalFooter")).Text = grandTotal.ToString(); 
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvInvestorUnitList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EditData"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;

                LinkButton lnkRoomNo = (LinkButton)gvInvestorUnitList.Rows[RowIndex].FindControl("lnkRoomNo");

                if (lnkRoomNo != null)
                {
                    Session.Add("InvestorRoomID", new Guid(Convert.ToString(e.CommandArgument)));
                    if (Session["InvID"] != null && Session["UserType"].ToString().ToUpper() == "SALES")
                        Response.Redirect("~/Applications/Investors/InvestorsUnitSetUp.aspx?Val=True");
                    else if (Session["InvID"] != null && Session["UserType"].ToString().ToUpper() == "ADMIN")
                        Response.Redirect("~/Applications/Investors/InvestorsUnitSetUp.aspx?Val=True");
                    else
                        Response.Redirect("~/Applications/Investors/InvUnitDetails.aspx?Val=True");
                }
            }
        }

        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/Investors/InvestorsUnitSetUp.aspx?Val=True");
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

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

        /// <summary>
        /// Print Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Unit Information");
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }


        /// <summary>
        /// Preview Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Session.Add("ReportName", "Unit Information");
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Unit Information");
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Unit Information");
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            Session.Add("ReportName", "Unit Information");
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion Button Event
    }
}