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

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlPropertyList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

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

        public Guid PropertyID
        {
            get
            {
                return ViewState["PropertyID"] != null ? new Guid(Convert.ToString(ViewState["PropertyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyID"] = value;
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
            if (Session["UserID"] == null)
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (RoleRightJoinBLL.GetAccessString("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                    Response.Redirect("~/Applications/AccessDenied.aspx");
                LoadAccess();
                
                if (!IsPostBack)
                {
                    this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                    LoadDefaultValue();
                }

                if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                {
                    btnAdd.Visible = btnAddTop.Visible = false;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true); 
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                btnAdd.Visible = btnAddTop.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
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
                BindDDL();
                BindGrid();                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            string PropertyName = null;
            string Location = null;
            Guid? PropertyType  = null;

            if (!(txtPropertyName.SelectedValue.Equals(Guid.Empty.ToString())))
                PropertyName = Convert.ToString(txtPropertyName.SelectedValue);

            if (!(txtLocation.SelectedValue.Equals(Guid.Empty.ToString())))
                Location = txtLocation.SelectedValue.ToString();

            if (ddlPropertyType.SelectedIndex != 0)
                PropertyType = new Guid(ddlPropertyType.SelectedValue.ToString());

            DataSet ds = PropertyBLL.GetPropertyData(null, this.CompanyID, PropertyName,Location,PropertyType);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "PropertyName Asc";
            grdPropertyList.DataSource = dv;
            grdPropertyList.DataBind();

        }

        private void BindDDL()
        {

            string PropertyNameQuery = "Select Distinct(PropertyName) From mst_Property Where IsActive = 1";
            DataSet Dst = InvestorBLL.GetSearchData(PropertyNameQuery);
            DataView Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                txtPropertyName.DataSource = Dv;
                txtPropertyName.DataTextField = "PropertyName";
                txtPropertyName.DataValueField = "PropertyName";
                txtPropertyName.DataBind();
                txtPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtPropertyName.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            List<ProjectTerm> lstProjectTermPT = null;
            ProjectTerm objProjectTermPT = new ProjectTerm();
            objProjectTermPT.IsActive = true;
            objProjectTermPT.Category = "PROPERTYTYPE";
            objProjectTermPT.CompanyID = this.CompanyID;

            lstProjectTermPT = ProjectTermBLL.GetAll(objProjectTermPT);

            if (lstProjectTermPT.Count != 0)
            {
                lstProjectTermPT.Sort((ProjectTerm p1, ProjectTerm p2) => p1.DisplayTerm.CompareTo(p2.DisplayTerm));
                ddlPropertyType.DataSource = lstProjectTermPT;
                ddlPropertyType.DataTextField = "DisplayTerm";
                ddlPropertyType.DataValueField = "TermID";
                ddlPropertyType.DataBind();
                ddlPropertyType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlPropertyType.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));

            //Bind City
            txtLocation.Items.Clear();
            List<City> LstCity = CityBLL.GetAll();
            if (LstCity.Count > 0)
            {
                LstCity.Sort((City p1, City p2) => p1.CityName.CompareTo(p2.CityName));
                txtLocation.DataSource = LstCity;
                txtLocation.DataTextField = "CityName";
                txtLocation.DataValueField = "CityName";
                txtLocation.DataBind();
                txtLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                txtLocation.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// ClearControl Event
        /// </summary>
        private void ClearControl()
        {
            txtPropertyName.SelectedIndex = 0;
            this.PropertyID = Guid.Empty;
            Session.Remove("Property");
            BindGrid();
        }
        #endregion Private Method

        #region Add New Property
        /// <summary>
        /// Add New Property List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Applications/SetUp/ConfigurationPropertyInfo.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Add New Property

        #region Control Event

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
        protected void grdPropertyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[7].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[7].Text = "View";
                    e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[8].Visible = Convert.ToBoolean(ViewState["Delete"]);
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                    }
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton EditImg = (ImageButton)e.Row.FindControl("btnEdit");
                    ImageButton DelImg = (ImageButton)e.Row.FindControl("btnDelete");

                    //Label lbl = (Label)e.Row.FindControl("lblCarpetArea");
                    //lbl.Text = lbl.Text.Substring(0, lbl.Text.Length - 3).ToString();

                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        EditImg.ToolTip = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        EditImg.ToolTip = "View";

                    EditImg.Visible = Convert.ToBoolean(ViewState["View"]);
                    DelImg.Visible = Convert.ToBoolean(ViewState["Delete"]);

                    LinkButton lnkbtnWingCount = (LinkButton)e.Row.FindControl("lnkbtnWingCount");
                    LinkButton lnkbtnFloorCount = (LinkButton)e.Row.FindControl("lnkbtnFloorCount");
                    LinkButton lnkbtnUnitTypes = (LinkButton)e.Row.FindControl("lnkbtnUnitTypes");
                    LinkButton lnkbtnUnits = (LinkButton)e.Row.FindControl("lnkbtnUnits");
                    e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["View"]); 
                    e.Row.Cells[8].Visible = Convert.ToBoolean(ViewState["Delete"]);

                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                        lnkbtnWingCount.Enabled = false;
                        lnkbtnFloorCount.Enabled = false;
                        lnkbtnUnitTypes.Enabled = false;
                        lnkbtnUnits.Enabled = false;
                    }

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    if (Convert.ToBoolean(ViewState["Edit"]) == true)
                        e.Row.Cells[7].Text = "View/Edit";
                    else if (Convert.ToBoolean(ViewState["View"]) == true)
                        e.Row.Cells[7].Text = "View";
                    e.Row.Cells[7].Visible = Convert.ToBoolean(ViewState["View"]);
                    e.Row.Cells[8].Visible = Convert.ToBoolean(ViewState["Delete"]);
                    if (Session["UserType"].ToString().ToUpper().Equals("SALES") || Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER") || Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    {
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    Session.Add("Property", new Guid(Convert.ToString(e.CommandArgument)));
                    Response.Redirect("~/Applications/SetUp/ConfigurationPropertyInfo.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    Label1.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.PropertyID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
                else if (e.CommandName.Equals("TOTALWING"))
                {
                    Session.Add("Property", new Guid(Convert.ToString(e.CommandArgument)));
                    Session.Add("WingSelect", 0);
                    Response.Redirect("~/Applications/SetUp/FloorSetUp.aspx#tabs-1");
                }
                else if (e.CommandName.Equals("TOTALUNITTYPES"))
                {
                    Session.Add("Property", new Guid(Convert.ToString(e.CommandArgument)));
                    Response.Redirect("~/Applications/SetUp/RoomTypeSetup.aspx");
                }
                else if (e.CommandName.Equals("TOTALUNIT"))
                {
                    Session.Add("Property", new Guid(Convert.ToString(e.CommandArgument)));
                    Response.Redirect("~/Applications/SetUp/RoomSetup.aspx");
                }
                else if (e.CommandName.Equals("TOTALFLOOR"))
                {
                    Session.Add("Property", new Guid(Convert.ToString(e.CommandArgument)));
                    Session.Add("FloorSelect", 0);
                    Response.Redirect("~/Applications/SetUp/FloorSetUp.aspx#tabs-2");
                }
                else if (e.CommandName.Equals("UNITINFO"))
                {
                    Session["PropertyID4UnitInfo"] = e.CommandArgument.ToString();
                    Response.Redirect("~/Applications/SetUp/PropertyUnits.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdPropertyList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPropertyList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        
        #endregion Grid Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPropertyYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PropertyID != Guid.Empty)
                {
                    msgbx.Hide();
                    List<Documents> lstDocuments = new List<Documents>();
                    Property objDelete = PropertyBLL.GetByPrimaryKey(this.PropertyID);
                    PropertyBLL.Delete(this.PropertyID);
                    BindDDL();
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "mst_Property");
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
        protected void btnPropertyNo_Click(object sender, EventArgs e)
        {
            try
            {
                msgbx.Hide();

                //ClearControl(); //Commented by Vijay b'cas no need to bind Grid when cancel Delete action.

                txtPropertyName.SelectedIndex = 0;
                this.PropertyID = Guid.Empty;
                Session.Remove("Property");                
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion Popup Button Event

    }
}