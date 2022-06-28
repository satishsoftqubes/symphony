using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;
using System.Collections;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.CommonControls
{
    public partial class CtrlCounterLogin : System.Web.UI.UserControl
    {

        #region Property and Variables

        public Guid DefaultCounterID
        {
            get
            {
                return ViewState["DefaultCounterID"] != null ? new Guid(Convert.ToString(ViewState["DefaultCounterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["DefaultCounterID"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (clsSession.UserID != Guid.Empty && clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                DataSet dsUserRole = RoleBLL.GetUserRole(clsSession.UserID, clsSession.CompanyID, clsSession.PropertyID, "Counter");

                if (dsUserRole.Tables[0].Rows.Count != 0)
                {
                    if (!IsPostBack)
                    {
                        BindPageDate();
                    }
                }
                else
                {
                    clsSession.DefaultCounterID = clsSession.CounterLoginLogID = Guid.Empty;
                    Response.Redirect("~/GUI/AccountsHome.aspx");
                }
            }
            else
            {
                Response.Redirect("http://pms.uniworldindia.com/");
            }
        }

        #endregion Page Load

        #region Private Method

        private void ClearControl()
        {
            this.DefaultCounterID = Guid.Empty;
            ddlCounter.SelectedIndex = 0;
            litDspLoginTime.Text = "";
            litDspDetailCounter.Text = "";
            litDspDetailLoginTime.Text = "";
            litDspAmount.Text = "0.00";
        }

        private void BindPageDate()
        {
            BindDLLCounter();
            litDspLoginTime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

            if (clsSession.UserID != Guid.Empty)
            {
                DataSet dtUserCounterDetails = CounterLoginLogBLL.GetCounterDetailsWithDataSet(clsSession.UserID, clsSession.PropertyID, clsSession.CompanyID);

                if (dtUserCounterDetails.Tables[0].Rows.Count != 0)
                {
                    if (dtUserCounterDetails.Tables[0].Rows[0]["LogOutDate"].ToString() != "")
                    {
                        clsSession.DefaultCounterID = Guid.Empty;
                        mvCounte.ActiveViewIndex = 0;
                    }
                    else
                    {
                        this.DefaultCounterID = new Guid(dtUserCounterDetails.Tables[0].Rows[0]["CounterID"].ToString());
                        litDspDetailCounter.Text = dtUserCounterDetails.Tables[0].Rows[0]["CounterNo"].ToString();
                        litDspDetailLoginTime.Text = dtUserCounterDetails.Tables[0].Rows[0]["LogInDate"].ToString();
                        litDspAmount.Text = "0.00";
                        clsSession.DefaultCounterID = new Guid(dtUserCounterDetails.Tables[0].Rows[0]["CounterID"].ToString());
                        clsSession.CounterLoginLogID = new Guid(Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterLoginLogID"]));
                        mvCounte.ActiveViewIndex = 1;

                        clsSession.CounterName = Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterNo"]);
                    }
                }
                else
                {
                    mvCounte.ActiveViewIndex = 0;
                }
            }
            //mvCounte.ActiveViewIndex = 0;
        }

        private void BindDLLCounter()
        {
            DataSet dsCounter = CountersBLL.GetLogoutCounterList(clsSession.PropertyID, clsSession.CompanyID);

            if (dsCounter.Tables[0].Rows.Count != 0)
            {
                ddlCounter.DataSource = dsCounter;
                ddlCounter.DataTextField = "CounterNo";
                ddlCounter.DataValueField = "CounterID";
                ddlCounter.DataBind();
                ddlCounter.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlCounter.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));

        }

        #endregion

        #region Control Event

        protected void rblLoginOption_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLoginOption.SelectedIndex == 0)
            {
                btnLogin.Text = "Login";
                divLogin.Visible = false;
                rfvCounter.Enabled = false;
            }
            else
            {
                btnLogin.Text = "Login Counter";
                divLogin.Visible = true;
                rfvCounter.Enabled = true;
            }
        }

        protected void rblDetailLoginOption_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblDetailLoginOption.SelectedIndex == 0)
            {
                btnDetailLogin.Text = "Login";
                divDetails.Visible = false;
            }
            else
            {
                btnDetailLogin.Text = "Login Counter";
                divDetails.Visible = true;
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (rblLoginOption.SelectedIndex == 0)
                {
                    clsSession.DefaultCounterID = clsSession.CounterLoginLogID = Guid.Empty;
                    Response.Redirect("~/GUI/AccountsHome.aspx");
                }
                else
                {
                    if (ddlCounter.SelectedIndex > 0 && ddlCounter.SelectedValue.ToString() != "" && ddlCounter.SelectedValue.ToString() != null)
                    {
                        string strToCheckRecordCouner = "select * FROm usr_CounterLoginLog Where CompanyID = '" + clsSession.CompanyID + "' and PropertyID = '" + clsSession.PropertyID + "' and CounterID = '" + ddlCounter.SelectedValue + "' and LogOutDate IS NULL ";
                        DataSet dsCounter = RoomTypeBLL.GetUnitType(strToCheckRecordCouner);
                        if (dsCounter != null && dsCounter.Tables.Count > 0 && dsCounter.Tables[0].Rows.Count != 0)
                        {
                            if (Convert.ToString(dsCounter.Tables[0].Rows[0]["UserID"]) != Convert.ToString(clsSession.UserID))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                MessageBox.Show("User with this counter id allready login ");
                                return;
                            }
                        }
                    }

                    CounterLoginLog objCounterData = new CounterLoginLog();
                    objCounterData.CompanyID = clsSession.CompanyID;
                    objCounterData.CounterID = new Guid(ddlCounter.SelectedValue.ToString());
                    objCounterData.LogInDate = DateTime.Now;
                    objCounterData.PropertyID = clsSession.PropertyID;
                    objCounterData.UserID = clsSession.UserID;

                    CounterLoginLogBLL.Save(objCounterData);

                    clsSession.CounterLoginLogID = objCounterData.CounterLoginLogID;
                    clsSession.DefaultCounterID = new Guid(ddlCounter.SelectedValue.ToString());
                    clsSession.CounterName = Convert.ToString(ddlCounter.SelectedItem.Text);

                    Response.Redirect("~/GUI/AccountsHome.aspx");
                }
            }
            catch
            {

            }
        }

        protected void btnDetailLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (rblDetailLoginOption.SelectedIndex == 0)
                {
                    clsSession.DefaultCounterID = clsSession.CounterLoginLogID = Guid.Empty;
                    Response.Redirect("~/GUI/AccountsHome.aspx");
                }
                else
                {
                    if (clsSession.DefaultCounterID != Guid.Empty)
                    {
                        Response.Redirect("~/GUI/AccountsHome.aspx");
                    }
                }

            }
            catch
            {

            }
        }

        protected void btnDetailCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("http://pms.uniworldindia.com/");
        }

        #endregion
    }
}