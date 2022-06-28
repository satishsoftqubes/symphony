using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonFrontDeskAlert : System.Web.UI.UserControl
    {
        public bool IsFrontDeskAlertMessageMsg = false;

        public Guid FrontDeskAlertMsgID
        {
            get
            {
                return ViewState["FrontDeskAlertMsgID"] != null ? new Guid(Convert.ToString(ViewState["FrontDeskAlertMsgID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FrontDeskAlertMsgID"] = value;
            }
        }
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mvFrontDeskAlert.ActiveViewIndex = 0;
                BindAlertMessage();
                BindBreadCrumb();
                BindUserGrid();
                BindUserWhoEmp();
            }
        }
        #endregion

        #region Button Event
        protected void btnAddTop_OnClick(object sender, EventArgs e)
        {

            mvFrontDeskAlert.ActiveViewIndex = 1;

        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {

            mvFrontDeskAlert.ActiveViewIndex = 0;

        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    List<FrontDeskAlert> lstFrontDeskAlert = new List<FrontDeskAlert>();
                    // To Insert a Data in to Front Desk Alert Master Table 
                    if (this.FrontDeskAlertMsgID != Guid.Empty)
                    {
                        FrontDeskAlertMaster objToUpdate = new FrontDeskAlertMaster();
                        FrontDeskAlert objFrontDeskAlert;

                        objToUpdate = FrontDeskAlertMasterBLL.GetByPrimaryKey(this.FrontDeskAlertMsgID);
                        if (txtMessage.Text.Trim() != "")
                        {
                            objToUpdate.Messege = Convert.ToString(txtMessage.Text.Trim());
                        }
                        objToUpdate.MsgDateTime = DateTime.Now;
                        if (ddlMassegeBy.SelectedIndex != 0)
                            objToUpdate.MessageBy = new Guid(ddlMassegeBy.SelectedValue);
                        else
                            objToUpdate.MessageBy = null;
                        objToUpdate.CompanyID = clsSession.CompanyID;
                        objToUpdate.PropertyID = clsSession.PropertyID;
                        objToUpdate.IsActive = true;
                        objToUpdate.UpdatedOn = DateTime.Now;
                        objToUpdate.UpdatedBy = clsSession.UserID;
                        objToUpdate.IsActive = true; // By Default insert it to TRUE
                        objToUpdate.IsInformed = true; // By Default insert it to TRUE

                        // Get all selected item for insert in to Front Desk Alert Detail 

                        foreach (GridViewRow row in gvUserList.Rows)
                        {
                            CheckBox chkBox = row.FindControl("chkSelectUser") as CheckBox;
                            if (chkBox != null && chkBox.Checked)
                            {
                                objFrontDeskAlert = new FrontDeskAlert();
                                objFrontDeskAlert.FrontDeskAlertID = Guid.NewGuid();
                                objFrontDeskAlert.FrontDeskAlertMsgID = objToUpdate.FrontDeskAlertMsgID;
                                objFrontDeskAlert.MsgFor = new Guid(Convert.ToString(gvUserList.DataKeys[row.RowIndex]["EmployeeID"]));
                                objFrontDeskAlert.CompanyID = clsSession.CompanyID;
                                objFrontDeskAlert.PropertyID = clsSession.PropertyID;
                                objFrontDeskAlert.CreatedOn = DateTime.Now;
                                objFrontDeskAlert.CreatedBy = clsSession.UserID;
                                objFrontDeskAlert.IsActive = true;
                                objFrontDeskAlert.AsReceive = true;
                                lstFrontDeskAlert.Add(objFrontDeskAlert);
                            }
                        }

                        FrontDeskAlertBLL.UpdateWithDetails(objToUpdate, lstFrontDeskAlert);
                        IsFrontDeskAlertMessageMsg = true;
                        //litFrontDeskAlertMessageMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        litFrontDeskAlertMessageMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        ClearControlOfForntDeskAlert();
                        BindAlertMessage();
                    }
                    else
                    {
                        FrontDeskAlertMaster objInsertFrontDeskAlertMaster = new FrontDeskAlertMaster();
                        FrontDeskAlert objFrontDeskAlert;
                        objInsertFrontDeskAlertMaster.FrontDeskAlertMsgID = Guid.NewGuid();
                        if (txtMessage.Text.Trim() != "")
                        {
                            objInsertFrontDeskAlertMaster.Messege = Convert.ToString(txtMessage.Text.Trim());
                        }
                        objInsertFrontDeskAlertMaster.MsgDateTime = DateTime.Now;
                        if (ddlMassegeBy.SelectedIndex != 0)
                            objInsertFrontDeskAlertMaster.MessageBy = new Guid(ddlMassegeBy.SelectedValue);
                        else
                            objInsertFrontDeskAlertMaster.MessageBy = null;
                        objInsertFrontDeskAlertMaster.CompanyID = clsSession.CompanyID;
                        objInsertFrontDeskAlertMaster.PropertyID = clsSession.PropertyID;
                        objInsertFrontDeskAlertMaster.IsActive = true; // By Default insert it to TRUE
                        objInsertFrontDeskAlertMaster.IsInformed = true; // By Default insert it to TRUE
                        objInsertFrontDeskAlertMaster.CreatedOn = DateTime.Now;
                        objInsertFrontDeskAlertMaster.CreatedBy = clsSession.UserID;

                        // Get all selected item for insert in to Front Desk Alert Detail 

                        foreach (GridViewRow row in gvUserList.Rows)
                        {
                            CheckBox chkBox = row.FindControl("chkSelectUser") as CheckBox;
                            if (chkBox != null && chkBox.Checked)
                            {
                                objFrontDeskAlert = new FrontDeskAlert();
                                objFrontDeskAlert.FrontDeskAlertID = Guid.NewGuid();
                                objFrontDeskAlert.FrontDeskAlertMsgID = objInsertFrontDeskAlertMaster.FrontDeskAlertMsgID;
                                objFrontDeskAlert.MsgFor = new Guid(Convert.ToString(gvUserList.DataKeys[row.RowIndex]["EmployeeID"]));
                                objFrontDeskAlert.CompanyID = clsSession.CompanyID;
                                objFrontDeskAlert.PropertyID = clsSession.PropertyID;
                                objFrontDeskAlert.CreatedOn = DateTime.Now;
                                objFrontDeskAlert.CreatedBy = clsSession.UserID;
                                objFrontDeskAlert.IsActive = true;
                                objFrontDeskAlert.AsReceive = true;
                                lstFrontDeskAlert.Add(objFrontDeskAlert);
                            }
                        }

                        FrontDeskAlertBLL.SaveWithDetails(objInsertFrontDeskAlertMaster, lstFrontDeskAlert);
                        IsFrontDeskAlertMessageMsg = true;
                        litFrontDeskAlertMessageMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                        // litFrontDeskAlertMessageMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        ClearControlOfForntDeskAlert();
                        BindAlertMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearControlOfForntDeskAlert()
        {
            txtMessage.Text = "";
            ddlMassegeBy.SelectedIndex = 0;
            //  chkSelectUser
            foreach (GridViewRow row in gvUserList.Rows)
            {
                CheckBox chkBox = row.FindControl("chkSelectUser") as CheckBox;
                if (chkBox != null && chkBox.Checked)
                {
                    chkBox.Checked = false;
                }
            }
            this.FrontDeskAlertMsgID = Guid.Empty;
        }


        #endregion

        #region Private Method
        private void BindAlertMessage()
        {
            try
            {
                //DataTable dtService = new DataTable();


                //DataColumn dc1 = new DataColumn("Message");
                //DataColumn dc2 = new DataColumn("PostBy");
                //DataColumn dc3 = new DataColumn("Date");


                //dtService.Columns.Add(dc1);
                //dtService.Columns.Add(dc2);
                //dtService.Columns.Add(dc3);


                //DataRow dr1 = dtService.NewRow();
                //dr1["Message"] = "HKP person is on leave.";
                //dr1["PostBy"] = "Mr. Jayesh Rathod";
                //dr1["Date"] = "13-08-2012";


                //dtService.Rows.Add(dr1);

                //DataRow dr2 = dtService.NewRow();
                //dr2["Message"] = "new VVIP in room 07.";
                //dr2["PostBy"] = "Miss. Palak Jain";
                //dr2["Date"] = "14-08-2012";

                //dtService.Rows.Add(dr2);

                //gvFrontDeskAlertList.DataSource = dtService;
                //gvFrontDeskAlertList.DataBind();

                //FrontDeskAlertMaster objFrontDeskAlertMasterNew = new FrontDeskAlertMaster();
                //objFrontDeskAlertMasterNew.CompanyID = clsSession.CompanyID;
                //objFrontDeskAlertMasterNew.PropertyID = clsSession.PropertyID;
                //objFrontDeskAlertMasterNew.CreatedBy = clsSession.UserID;
                //DataSet dsFrontDeskAlertMasterNew = FrontDeskAlertMasterBLL.GetAllWithDataSet(objFrontDeskAlertMasterNew);
                //gvFrontDeskAlertList.DataSource = dsFrontDeskAlertMasterNew;
                //gvFrontDeskAlertList.DataBind();
                //if (dsFrontDeskAlertMasterNew != null && dsFrontDeskAlertMasterNew.Tables.Count > 0 && dsFrontDeskAlertMasterNew.Tables[0].Rows.Count >0)
                //{

                //}
                string strMssageBy = null;
                DateTime? dtMessageDateTimeToPass = null;
                if (txtSearchPostBy.Text.Trim() != "")
                {
                    strMssageBy = Convert.ToString(txtSearchPostBy.Text.Trim());

                }
                if (txtSearchDate.Text.Trim() != "")
                {
                    dtMessageDateTimeToPass = DateTime.ParseExact(txtSearchDate.Text.Trim(), "dd-MM-yyyy", null);
                    //Convert.ToDateTime(txtSearchDate.Text.Trim() + " 23:59:59");
                }
                DataSet dsFrontDeskAlertMasterNew = FrontDeskAlertMasterBLL.GetFrontDeskAlertList(clsSession.PropertyID, clsSession.CompanyID, clsSession.UserID, strMssageBy, dtMessageDateTimeToPass);
                gvFrontDeskAlertList.DataSource = dsFrontDeskAlertMasterNew;
                gvFrontDeskAlertList.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvFrontDeskAlertList.PageIndex = 0;
            BindAlertMessage();
        }
        protected void gvFrontDeskAlertList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFrontDeskAlertList.PageIndex = e.NewPageIndex;
            BindAlertMessage();
        }

        private void BindUserGrid()
        {
            try
            {
                //DataTable dtUser = new DataTable();


                //DataColumn dc1 = new DataColumn("User");
                //DataColumn dc2 = new DataColumn("Department");



                //dtUser.Columns.Add(dc1);
                //dtUser.Columns.Add(dc2);



                //DataRow dr1 = dtUser.NewRow();
                //dr1["User"] = "Miss Meeta Patel";
                //dr1["Department"] = "HR";



                //dtUser.Rows.Add(dr1);

                //DataRow dr2 = dtUser.NewRow();
                //dr2["User"] = "Mr. Satish Thummar";
                //dr2["Department"] = "Account";


                //dtUser.Rows.Add(dr2);

                //gvUserList.DataSource = dtUser;
                //gvUserList.DataBind();
                string strEmployeeList = "select HE.EmployeeID,HE.FullName as [User],MD.DepartmentName as Department  FROM hrm_Employee HE INNER JOIN mst_Department MD ON HE.PropertyID= MD.PropertyID And HE.CompanyID = MD.CompanyID And HE.DepartmentID  = MD.DepartmentID  where HE.CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "'  And  HE.PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "'";
                DataSet dsEmpList = FrontDeskAlertBLL.GetAllUserWhoEmpBLL(strEmployeeList);
                if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
                {
                    gvUserList.DataSource = dsEmpList.Tables[0];
                    gvUserList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        // Method added to retrieve All User List For Specific Company and Property and also UserType = "Employee"
        private void BindUserWhoEmp()
        {
            try
            {
                string strUserAllWhoEmp = "select UsearID,UserDisplayName from usr_user where CompanyID = '" + Convert.ToString(clsSession.CompanyID) + "'  And  PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and UserType ='Employee'  order by UsearID asc";
                DataSet dsUserAllWhoEmp = FrontDeskAlertBLL.GetAllUserWhoEmpBLL(strUserAllWhoEmp);
                ddlMassegeBy.Items.Clear();
                if (dsUserAllWhoEmp != null && dsUserAllWhoEmp.Tables.Count > 0 && dsUserAllWhoEmp.Tables[0].Rows.Count > 0)
                {
                    ddlMassegeBy.DataSource = dsUserAllWhoEmp.Tables[0];
                    ddlMassegeBy.DataTextField = "UserDisplayName";
                    ddlMassegeBy.DataValueField = "UsearID";
                    ddlMassegeBy.DataBind();

                    ddlMassegeBy.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlMassegeBy.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Front Desk Alert";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        protected void gvFrontDeskAlertList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("ALERTEDIT"))
                {
                    mvFrontDeskAlert.ActiveViewIndex = 1;
                    string strName = Convert.ToString(e.CommandArgument);
                    string[] strSplit = strName.Split(',');
                    ddlMassegeBy.SelectedValue = strSplit[1];
                    this.FrontDeskAlertMsgID = new Guid(Convert.ToString(strSplit[0]));
                    txtMessage.Text = strSplit[2] + "";
                    DataSet dsToFlterRowOfDetail = FrontDeskAlertBLL.GetAllByWithDataSet(FrontDeskAlert.FrontDeskAlertFields.FrontDeskAlertMsgID, strSplit[0]);
                    if (dsToFlterRowOfDetail != null && dsToFlterRowOfDetail.Tables.Count > 0 && dsToFlterRowOfDetail.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drtofilter in dsToFlterRowOfDetail.Tables[0].Rows)
                        {
                            foreach (GridViewRow row in gvUserList.Rows)
                            {
                                if (new Guid(Convert.ToString(gvUserList.DataKeys[row.RowIndex]["EmployeeID"])).Equals(drtofilter["MsgFor"]))
                                {
                                    CheckBox chkBox = row.FindControl("chkSelectUser") as CheckBox;
                                    if (chkBox != null)
                                    {
                                        chkBox.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (e.CommandName.Equals("ALERTDELETE"))
                {
                    string strName = Convert.ToString(e.CommandArgument);
                    string[] strSplit = strName.Split(',');
                    FrontDeskAlertBLL.Delete(FrontDeskAlert.FrontDeskAlertFields.FrontDeskAlertMsgID, Convert.ToString(strSplit[0]));
                    FrontDeskAlertMasterBLL.Delete(new Guid(Convert.ToString(strSplit[0])));
                    BindAlertMessage();
                }

                if (e.CommandName.Equals("ALERTVIEW"))
                {
                    string strName = Convert.ToString(e.CommandArgument);
                    string[] strSplit = strName.Split(',');
                    txtMessageToView.Text = strSplit[2];
                    mpeMessege.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnCancelPopUp_Click(object sender, EventArgs e)
        {
            mpeMessege.Hide();
        }
        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            txtSearchDate.Text = txtSearchPostBy.Text = "";
            BindAlertMessage();
        }

        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }
        #endregion
    }

}