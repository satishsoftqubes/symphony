using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonCounterLogin : System.Web.UI.UserControl
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

        public Guid CounterLoginLogID
        {
            get
            {
                return ViewState["CounterLoginLogID"] != null ? new Guid(Convert.ToString(ViewState["CounterLoginLogID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CounterLoginLogID"] = value;
            }
        }

        public string CounterName
        {
            get
            {
                return ViewState["CounterName"] != null ? Convert.ToString(ViewState["CounterName"]) : string.Empty;
            }
            set
            {
                ViewState["CounterName"] = value;
            }
        }

        public string strRights;

        public string strValidate;

        public DropDownList ucddlCounter
        {
            get { return this.ddlCounter; }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Page Load

        #region Private method

        private void BindDLLCounter()
        {
            try
            {
                DataSet dsCounter = CountersBLL.GetLogoutCounterList(clsSession.PropertyID, clsSession.CompanyID);
                ddlCounter.Items.Clear();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindCounterData()
        {
            try
            {
                BindDLLCounter();
                litDspLoginTime.Text = DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat);

                if (clsSession.UserID != Guid.Empty)
                {
                    DataSet dtUserCounterDetails = CounterLoginLogBLL.GetCounterDetailsWithDataSet(clsSession.UserID, clsSession.PropertyID, clsSession.CompanyID);
                    if (dtUserCounterDetails.Tables.Count > 0 && dtUserCounterDetails.Tables[0].Rows.Count != 0)
                    {
                        if (Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["LogOutDate"]) != "" && dtUserCounterDetails.Tables[0].Rows[0]["LogOutDate"] != null)
                        {
                            clsSession.DefaultCounterID = this.DefaultCounterID = this.CounterLoginLogID = Guid.Empty;
                            this.CounterName = string.Empty;
                            mvCounter.ActiveViewIndex = 0;
                            strValidate = "YES";
                        }
                        else
                        {
                            strValidate = "NO";

                            this.DefaultCounterID = new Guid(dtUserCounterDetails.Tables[0].Rows[0]["CounterID"].ToString());
                            litDspDetailCounter.Text = Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterNo"]);
                            litDspDetailLoginTime.Text = Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["LogInDate"]);
                            litDspAmount.Text = "0.00";

                            //clsSession.DefaultCounterID = new Guid(dtUserCounterDetails.Tables[0].Rows[0]["CounterID"].ToString());
                            //clsSession.CounterLoginLogID = new Guid(Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterLoginLogID"]));
                            //clsSession.CounterName = Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterNo"]);

                            this.DefaultCounterID = new Guid(dtUserCounterDetails.Tables[0].Rows[0]["CounterID"].ToString());
                            this.CounterLoginLogID = new Guid(Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterLoginLogID"]));
                            this.CounterName = Convert.ToString(dtUserCounterDetails.Tables[0].Rows[0]["CounterNo"]);

                            mvCounter.ActiveViewIndex = 1;
                        }
                    }
                    else
                    {
                        clsSession.DefaultCounterID = this.DefaultCounterID = this.CounterLoginLogID = Guid.Empty;
                        this.CounterName = string.Empty;
                        mvCounter.ActiveViewIndex = 0;
                        strValidate = "YES";
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
            //mvCounte.ActiveViewIndex = 0;
        }

        private void ClearControl()
        {
            this.DefaultCounterID = Guid.Empty;
            ddlCounter.SelectedIndex = 0;
            litDspLoginTime.Text = "";
            litDspDetailCounter.Text = "";
            litDspDetailLoginTime.Text = "";
            litDspAmount.Text = "0.00";
        }

        public void CheckAuthentication()
        {
            if (clsSession.UserID != Guid.Empty && clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                DataSet dsUserRole = RoleBLL.GetUserRole(clsSession.UserID, clsSession.CompanyID, clsSession.PropertyID, "Counter");

                if (dsUserRole.Tables.Count > 0 && dsUserRole.Tables[0].Rows.Count != 0)
                {
                    strRights = "ALLOWOPEN";
                    BindCounterData();
                }
                else
                    strRights = "NOTALLOW";
            }
            else
            {
                Response.Redirect("~/GUI/Login.aspx");
            }
        }

        #endregion

        #region Public Method For Button Event

        public void SaveDataInCounter()
        {
            try
            {
                CounterLoginLog objCounterData = new CounterLoginLog();
                objCounterData.CompanyID = clsSession.CompanyID;
                objCounterData.CounterID = new Guid(ddlCounter.SelectedValue.ToString());
                objCounterData.LogInDate = DateTime.Now;
                objCounterData.PropertyID = clsSession.PropertyID;
                objCounterData.UserID = clsSession.UserID;

                CounterLoginLogBLL.Save(objCounterData);

                clsSession.CounterLoginLogID = this.CounterLoginLogID = objCounterData.CounterLoginLogID;
                clsSession.DefaultCounterID = this.DefaultCounterID = new Guid(ddlCounter.SelectedValue.ToString());
                clsSession.CounterName = this.CounterName = Convert.ToString(ddlCounter.SelectedItem.Text);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        public void LoginWithDetailButton()
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        public void CancelLoginButton()
        {
            Response.Redirect("~/Login.aspx");
            ClearControl();
        }

        #endregion
    }
}