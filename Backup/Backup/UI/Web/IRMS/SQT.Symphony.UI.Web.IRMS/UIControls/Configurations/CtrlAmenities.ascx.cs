using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Configurations
{
    public partial class CtrlAmenities : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid AmenitiesID
        {
            get
            {
                return ViewState["AmenitiesID"] != null ? new Guid(Convert.ToString(ViewState["AmenitiesID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AmenitiesID"] = value;
            }
        }

        #endregion Property and Variables

        #region Form Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("AmenitiesSetup.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();
            if (!IsPostBack)
                LoadDefaultData();
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("AmenitiesSetup.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = btnSave.Visible = Convert.ToBoolean(DV[0]["IsUpdate"]);
                //ViewState["Add"] = btnNew.Visible = btnCancel.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["Add"] = btnNew.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                if (this.AmenitiesID == Guid.Empty)
                    btnSave.Visible = Convert.ToBoolean(DV[0]["IsCreate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }

        /// <summary>
        /// Load Default Data
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                //BindPropertyName();
                ClearControl();
                BindGrid();

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
            DataSet ds = PropertyBLL.SelectData(new Guid(Convert.ToString(Session["CompanyID"])));
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "PropertyName Asc";

                ddlProperty.DataSource = dv;
                ddlProperty.DataTextField = "PropertyName";
                ddlProperty.DataValueField = "PropertyID";
                ddlProperty.DataBind();
                ddlProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

                ddlsPropertyName.DataSource = dv;
                ddlsPropertyName.DataTextField = "PropertyName";
                ddlsPropertyName.DataValueField = "PropertyID";
                ddlsPropertyName.DataBind();
                ddlsPropertyName.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
            else
            {
                ddlProperty.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlsPropertyName.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            Guid? PropertyID;
            string AmenitiesName = null;
            Guid? AmenitiesFor = null;
            if (ddlsPropertyName.SelectedValue != Guid.Empty.ToString())
                PropertyID = new Guid(ddlsPropertyName.SelectedValue);
            else
                PropertyID = null;
            if (ddlSAmenities.SelectedValue != Guid.Empty.ToString())
                AmenitiesFor = new Guid(ddlSAmenities.SelectedValue.ToString());
            else
                AmenitiesFor = null;
            DataSet dsAmenities = AmenitiesBLL.SearchAmenitiesData(null, PropertyID, AmenitiesName, AmenitiesFor);
            DataView dvAmenities = new DataView(dsAmenities.Tables[0]);
            dvAmenities.Sort = "AmenitiesName Asc";
            grdAmenitiesList.DataSource = dvAmenities;
            grdAmenitiesList.DataBind();
        }

        /// <summary>
        /// Clear Controls
        /// </summary>
        private void ClearControl()
        {
            BindPropertyName();
            BindAmenities();
            ddlsPropertyName.SelectedValue = Guid.Empty.ToString();
            ddlProperty.SelectedValue = Guid.Empty.ToString();
            txtAmenitiesCode.Text = "";
            txtAmenitiesDescription.Text = "";
            txtAmenitiesName.Text = "";
            this.AmenitiesID = Guid.Empty;
            ddlProperty.Enabled = true;
            ddlAmenitiesType.SelectedValue = Guid.Empty.ToString();
            BindGrid();
        }
        /// <summary>
        /// Bind Amenities Information
        /// </summary>
        private void BindAmenities()
        {
            ProjectTerm Prj = new ProjectTerm();
            Prj.Category = "AmenitiesType";
            Prj.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(Prj);
            if (Lst.Count > 0)
            {
                Lst.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlSAmenities.DataSource = Lst;
                ddlSAmenities.DataTextField = "DisplayTerm";
                ddlSAmenities.DataValueField = "TermID";
                ddlSAmenities.DataBind();
                ddlSAmenities.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));

                ddlAmenitiesType.DataSource = Lst;
                ddlAmenitiesType.DataTextField = "DisplayTerm";
                ddlAmenitiesType.DataValueField = "TermID";
                ddlAmenitiesType.DataBind();
                ddlAmenitiesType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

            }
            else
            {
                ddlAmenitiesType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                ddlSAmenities.Items.Insert(0, new ListItem("-All-", Guid.Empty.ToString()));
            }
        }
        #endregion Private Method

        #region Button Event
        /// <summary>
        /// Add New Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearControl();
            btnSave.Visible = Convert.ToBoolean(ViewState["Add"]);
        }

        /// <summary>
        /// Search Button Event
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

        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ClearControl();
        //        LoadAccess();
        //    }
        //    catch (Exception ex)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        /// <summary>
        /// Save And Update Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    Amenities IsDupAmenities = new Amenities();
                    IsDupAmenities.PropertyID = new Guid(ddlProperty.SelectedValue);
                    IsDupAmenities.AmenitiesName = txtAmenitiesName.Text.Trim();
                    IsDupAmenities.AmenitiesCode = txtAmenitiesCode.Text.Trim();
                    IsDupAmenities.IsActive = true;

                    List<Amenities> lstIsDupAmenities = AmenitiesBLL.GetAll(IsDupAmenities);
                    if (lstIsDupAmenities.Count > 0)
                    {
                        if (this.AmenitiesID != Guid.Empty)
                        {
                            if (Convert.ToString((lstIsDupAmenities[0].AmenitiesID)) != Convert.ToString(this.AmenitiesID.ToString()))
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

                    if (this.AmenitiesID != Guid.Empty)
                    {
                        Amenities objUpd = new Amenities();
                        Amenities objOldUpdData = new Amenities();
                        objUpd = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);
                        objOldUpdData = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);

                        objUpd.PropertyID = new Guid(ddlProperty.SelectedValue);
                        objUpd.AmenitiesCode = txtAmenitiesCode.Text.Trim();
                        objUpd.AmenitiesDescription = txtAmenitiesDescription.Text.Trim();
                        objUpd.AmenitiesName = txtAmenitiesName.Text.Trim();
                        objUpd.UpdatedOn = DateTime.Now;
                        objUpd.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objUpd.AmenitiesTypeTermID = new Guid(Convert.ToString(ddlAmenitiesType.SelectedValue.ToString()));

                        AmenitiesBLL.Update(objUpd);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", objOldUpdData.ToString(), objUpd.ToString(), "mst_Amenities");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.UpdateMsg.ToString().Trim();
                    }
                    else
                    {
                        Amenities objIns = new Amenities();
                        objIns.PropertyID = new Guid(ddlProperty.SelectedValue);
                        objIns.AmenitiesCode = txtAmenitiesCode.Text.Trim();
                        objIns.AmenitiesDescription = txtAmenitiesDescription.Text.Trim();
                        objIns.AmenitiesName = txtAmenitiesName.Text.Trim();
                        objIns.IsActive = true;
                        objIns.IsSynch = false;
                        objIns.CreatedOn = DateTime.Now;
                        objIns.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
                        objIns.AmenitiesTypeTermID = new Guid(Convert.ToString(ddlAmenitiesType.SelectedValue.ToString()));

                        AmenitiesBLL.Save(objIns);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Save", objIns.ToString(), objIns.ToString(), "mst_Amenities");
                        IsMessage = true;
                        lblErrorMessage.Text = global::Resources.IRMSMsg.SaveMsg.ToString().Trim();
                    }
                    ClearControl();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Button Event

        #region Grid Event
        protected void grdAmenitiesList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdAmenitiesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EditData"))
                {
                    
                    this.AmenitiesID = new Guid(Convert.ToString(e.CommandArgument));
                    Amenities objLoadData = new Amenities();
                    objLoadData = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);
                    if (objLoadData != null)
                    {
                        ddlProperty.SelectedValue = Convert.ToString(objLoadData.PropertyID);
                        ddlProperty.Enabled = false;
                        txtAmenitiesCode.Text = objLoadData.AmenitiesCode;
                        txtAmenitiesName.Text = objLoadData.AmenitiesName;
                        txtAmenitiesDescription.Text = objLoadData.AmenitiesDescription;
                        ddlAmenitiesType.SelectedIndex = ddlAmenitiesType.Items.FindByValue(Convert.ToString(objLoadData.AmenitiesTypeTermID)) != null ? ddlAmenitiesType.Items.IndexOf(ddlAmenitiesType.Items.FindByValue(Convert.ToString(objLoadData.AmenitiesTypeTermID))) : 0;
                    }
                    LoadAccess();
                }
                else if (e.CommandName.Equals("DeleteData"))
                {
                    lblErrorMessage.Text = global::Resources.IRMSMsg.DeleteWarMsg.ToString().Trim();
                    this.AmenitiesID = new Guid(Convert.ToString(e.CommandArgument));
                    msgbx.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Event Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAmenitiesYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.AmenitiesID != Guid.Empty)
                {
                    msgbx.Hide();
                    Amenities objDelete = AmenitiesBLL.GetByPrimaryKey(this.AmenitiesID);

                    AmenitiesBLL.Delete(this.AmenitiesID);
                    ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Delete", objDelete.ToString(), null, "mst_Amenities");

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
        protected void btnAmenitiesNo_Click(object sender, EventArgs e)
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
    }
}