using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard
{
    public partial class CtrlSettings : System.Web.UI.UserControl
    {

        #region Variable

        public bool IsInsert = false;

        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                BindGedgad();
                LoadDisplayName();
                if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                {
                    Investor Inv = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["InvID"])));
                    chkIsEmail.Checked = Convert.ToBoolean(Inv.IsEmail);
                    chkIsSMS.Checked = Convert.ToBoolean(Inv.IsSMS);
                    chkIsEmail.Visible = true;
                    chkIsSMS.Visible = true;
                }
                else
                {
                    chkIsEmail.Visible = false;
                    chkIsSMS.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Load Display Name
        /// </summary>
        private void LoadDisplayName()
        {
            try
            {
                SQT.Symphony.BusinessLogic.Configuration.DTO.User Usr = SQT.Symphony.BusinessLogic.Configuration.BLL.UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));
                Session["User"] = litDisplayName.Text = Usr.UserDisplayName;
                litCurrentPassword.Text = WritePwd(Usr.Password.Length);
                txtDisplayName.Text = Usr.UserDisplayName;
                txtCurrentPassword.Text = Usr.Password;
                txtCurrentPassword.Attributes.Add("value", Usr.Password);
                lblEmail.Text = Usr.UserName;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private string WritePwd(int No)
        {
            string A = "";
            for (int i = 0; i < No; i++)
            {
                A = A + "*";
            }
            return A;
        }
        /// <summary>
        /// Bind Gedgad Here
        /// </summary>
        private void BindGedgad()
        {
            DataSet Dst = new DataSet();
            if(Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
                Dst = InvestorBLL.GetSearchData("Select * from Mst_Gadget Where IsAdmin = 1");
            else if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                Dst = InvestorBLL.GetSearchData("Select * from Mst_Gadget Where IsInvestor = 1");
            else if (Session["UserType"].ToString().ToUpper().Equals("SALES"))
                Dst = InvestorBLL.GetSearchData("Select * from Mst_Gadget Where IsSales = 1");
            else if(Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                Dst = InvestorBLL.GetSearchData("Select * from Mst_Gadget Where IsSales = 1 And DisplayName not in ('Channel Partners')");
            grdGadgetlist.DataSource = Dst;
            grdGadgetlist.DataBind();
        }
        /// <summary>
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void SendEmail(string FullName, string UserName, string Password)
        {
            DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Reset password");
            if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
            {
                PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]);
                strHTML = strHTML.Replace("$PASSWORD$", Password.Trim());
                strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), UserName.Trim(), "Notification of Reset password", strHTML);
            }

            /*Old code to send mail useing HTML template            
            if (File.Exists(Server.MapPath("~/EmailTemplates/PasswordResetMessage.htm")))
            {
                PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplates/PasswordResetMessage.htm"));
                strHTML = strHTML.Replace("$PASSWORD$", Password.Trim());
                strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), UserName.Trim(), "Notification of Reset password", strHTML);
            }
             * */
        }

        #endregion Private Method

        #region Link Button Event
        /// <summary>
        /// Change Display Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtnChangeDisplayName_Click(object sender, EventArgs e)
        {
            msgbx.Show();
        }
        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtnChangePassword_Click(object sender, EventArgs e)
        {

            ChangePwd.Show();
        }

        #endregion Link Button Event

        #region Popup Change Display Name

        protected void btnSaveDisplayName_Click(object sender, EventArgs e)
        {
            try
            {
                User GetUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));
                User OldGetUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));
                Session["User"] = GetUsr.UserDisplayName = txtDisplayName.Text.Trim();
                UserBLL.Update(GetUsr);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldGetUsr.ToString(), GetUsr.ToString(), "Insert" + GetUsr.UserName + "Usr_User");
                LoadDisplayName();
                msgbx.Hide();
                IsInsert = true;
                lblSaveMsg.Text = "Change DisplayName successfully";
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Event for Display Name 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelDisplayName_Click(object sender, EventArgs e)
        {
            msgbx.Hide();
        }

        #endregion Popup Change Display Name

        #region Popup Change Password Button Event
        /// <summary>
        /// Save Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            try
            {
                User GetUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));
                User OldGetUsr = UserBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["UserID"])));
                GetUsr.Password = txtNewPassword.Text;
                UserBLL.Update(GetUsr);
                ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldGetUsr.ToString(), GetUsr.ToString(), "Insert" + GetUsr.UserName + "Usr_User");
                LoadDisplayName();
                ChangePwd.Hide();
                SendEmail(GetUsr.UserDisplayName, GetUsr.UserName, GetUsr.Password);
                IsInsert = true;
                lblSaveMsg.Text = "Password  Changed successfully.";
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
        protected void btnCancelPassword_Click(object sender, EventArgs e)
        {
            ChangePwd.Hide();
        }
        #endregion Popup Change Password Button Event

        #region Grid Data Row Binding Event
        /// <summary>
        /// Data Row Binding Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdGadgetlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    CheckBox ChkAdmin = (CheckBox)e.Row.FindControl("chkIsAdmin");
                    string DelQuery = "Select * From Mst_GradgetUserJoin Where UserID = '" + Convert.ToString(Session["UserID"]) + "' And GadgetID ='" + DataBinder.Eval(e.Row.DataItem, "GadgetID") + "'";
                    DataSet DelDst = InvestorBLL.GetSearchData(DelQuery);
                    if (DelDst.Tables[0].Rows.Count > 0)
                    {
                        ChkAdmin.Checked = true;
                    }
                    else
                    {
                        ChkAdmin.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Grid Data Row Binding Event

        #region Gradet Button Event
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDefaultValue();
        }
        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Save Investor Alert
            if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
            {
                Investor Inv = InvestorBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["InvID"])));
                Inv.IsSMS = chkIsSMS.Checked;
                Inv.IsEmail = chkIsEmail.Checked;
                InvestorBLL.Update(Inv);
            }
            for (int i = 0; i < grdGadgetlist.Rows.Count; i++)
            {
                CheckBox chkIsAdmin = (CheckBox)grdGadgetlist.Rows[i].FindControl("chkIsAdmin");
                string Query ="";
                if (Session["UserType"].ToString().ToUpper().Equals("SALES"))
                    Query = "Select GadgetID From Mst_Gadget Where IsSales = 1 And DisplayName = '" + grdGadgetlist.Rows[i].Cells[0].Text + "'";
                if (Session["UserType"].ToString().ToUpper().Equals("ADMIN"))
                    Query = "Select GadgetID From Mst_Gadget Where IsAdmin = 1 And DisplayName = '" + grdGadgetlist.Rows[i].Cells[0].Text + "'";
                if (Session["UserType"].ToString().ToUpper().Equals("INVESTOR"))
                    Query = "Select GadgetID From Mst_Gadget Where IsInvestor = 1 And DisplayName = '" + grdGadgetlist.Rows[i].Cells[0].Text + "'";
                if (Session["UserType"].ToString().ToUpper().Equals("CHANNELPARTNER"))
                    Query = "Select GadgetID From Mst_Gadget Where IsSales = 1 And DisplayName = '" + grdGadgetlist.Rows[i].Cells[0].Text + "'";
                DataSet Dst = InvestorBLL.GetSearchData(Query);
                if (Dst.Tables[0].Rows.Count > 0)
                {
                    string DelQuery = "Delete From Mst_GradgetUserJoin Where UserID = '" + Convert.ToString(Session["UserID"]) + "' And GadgetID ='" + Dst.Tables[0].Rows[0]["GadgetID"].ToString() + "'";
                    DataSet DelDst = InvestorBLL.GetSearchData(DelQuery);

                    if (chkIsAdmin.Checked == true)
                    {
                        string InsertQuery = "Insert Into Mst_GradgetUserJoin(UserGadgetID,GadgetID,UserID) Values (NewID(),'" + Dst.Tables[0].Rows[0]["GadgetID"].ToString() + "','" + Convert.ToString(Session["UserID"]) + "')";
                        DataSet SaveDst = InvestorBLL.GetSearchData(InsertQuery);
                    }
                }
                IsInsert = true;
                lblSaveMsg.Text = "save successfully";
            }
        }

        #endregion Gradet Button Event
    }
}