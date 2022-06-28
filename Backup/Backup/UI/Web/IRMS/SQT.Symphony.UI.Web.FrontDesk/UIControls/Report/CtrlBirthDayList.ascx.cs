using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlBirthDayList : System.Web.UI.UserControl
    {

        #region Property and variable
        public bool IsMessage = false;
        #endregion Property and variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkMonthOnly.Checked = chkMonthRange.Checked = false;
                chkMonthOnly_OnCheckedChanged(sender, e);
                chkMonthRange_OnCheckedChanged(sender, e);
                //BindGuestBirthDayList();
            }
        }
        #endregion Page Load

        #region Control Event
        protected void imtbtnSearchBirthDayList_Click(object sender, EventArgs e)
        {
            try
            {
                gvBirthDayList.PageIndex = 0;
                BindGuestBirthDayList();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void imtbtnSearchClearBirthDayList_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvBirthDayList.PageIndex = 0;
                BindGuestBirthDayList();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void chkMonthOnly_OnCheckedChanged(object sender, EventArgs e)
        {
            if (chkMonthOnly.Checked)
            {
                ddlMonthOnly.SelectedIndex = 0;
                rfvMonthOnly.Enabled = ddlMonthOnly.Enabled = true;
                chkMonthRange.Checked = false;
                chkMonthRange_OnCheckedChanged(sender,e);
            }
            else
            {
                ddlMonthOnly.SelectedIndex = 0;
                rfvMonthOnly.Enabled = ddlMonthOnly.Enabled = false;
            }
        }

        protected void chkMonthRange_OnCheckedChanged(object sender, EventArgs e)
        {
            if (chkMonthRange.Checked)
            {
                ddlDOBFromMonth.SelectedIndex = ddlDOBToMonth.SelectedIndex = 0;
                ddlDOBFromMonth.Enabled = ddlDOBToMonth.Enabled = rfvDOBFromMonth.Enabled = rfvDOBToMonth.Enabled = true;
                chkMonthOnly.Checked = false;
                chkMonthOnly_OnCheckedChanged(sender,e);
            }
            else
            {
                ddlDOBFromMonth.SelectedIndex = ddlDOBToMonth.SelectedIndex = 0;
                ddlDOBFromMonth.Enabled = ddlDOBToMonth.Enabled = rfvDOBFromMonth.Enabled = rfvDOBToMonth.Enabled = false;
            }
        }
        protected void btnPrintBirthDayList_OnClick(object sender, EventArgs e)
        {
            if (gvBirthDayList.Rows.Count > 0)
            {
                if (chkMonthOnly.Checked == true && ddlMonthOnly.SelectedIndex > 0)
                {
                    Session["BirthDayFromMonth"] = Convert.ToInt32(ddlMonthOnly.SelectedValue);
                    Session["BirthDayToMonth"] = Convert.ToInt32(ddlMonthOnly.SelectedValue);
                    Session["BirthDayFromMonthText"] = Convert.ToString(ddlMonthOnly.SelectedItem.Text);
                    Session["BirthDayToMonthText"] = Convert.ToString(ddlMonthOnly.SelectedItem.Text);
                  
                }
                else if (chkMonthRange.Checked == true && ddlDOBFromMonth.SelectedIndex > 0 && ddlDOBToMonth.SelectedIndex > 0)
                {
                    Session["BirthDayFromMonth"] = Convert.ToInt32(ddlDOBFromMonth.SelectedValue);
                    Session["BirthDayToMonth"] = Convert.ToInt32(ddlDOBToMonth.SelectedValue);
                    Session["BirthDayFromMonthText"] = Convert.ToString (ddlDOBFromMonth.SelectedItem.Text);
                    Session["BirthDayToMonthText"] = Convert.ToString(ddlDOBToMonth.SelectedItem.Text);
                }
                Session["GuestBirthDayListPageIndex"] = Convert.ToInt32(gvBirthDayList.PageIndex);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnBirthDayListPrint();", true);
            }
 
        }
        #endregion Control Event

        #region Private Method
        private void ClearSearch()
        {
            //txtSearchBirthDayFromDate .Text = "";
            //txtSearchBirthDayToDate .Text = "";
        }
        private void BindGuestBirthDayList()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                int? FromMonth = null;
                int? ToMonth = null;

                if (chkMonthOnly.Checked == true && ddlMonthOnly.SelectedIndex >0)
                {
                    FromMonth = Convert.ToInt32(ddlMonthOnly.SelectedValue);
                    ToMonth = Convert.ToInt32(ddlMonthOnly.SelectedValue);
                }
                else if (chkMonthRange.Checked  == true && ddlDOBFromMonth.SelectedIndex >0 && ddlDOBToMonth.SelectedIndex >0)
                {
                    FromMonth = Convert.ToInt32(ddlDOBFromMonth.SelectedValue);
                    ToMonth = Convert.ToInt32(ddlDOBToMonth.SelectedValue);
                }


                //if (txtSearchBirthDayFromDate .Text.Trim() != "")
                //    ArrivalDate = DateTime.ParseExact(txtSearchBirthDayFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                //if (txtSearchInqGuestDeptDate.Text.Trim() != "")
                //    DepartureDate = DateTime.ParseExact(txtSearchInqGuestDeptDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                //if (txtSearchInqGuestName.Text.Trim() != "")
                //    strName = Convert.ToString(txtSearchInqGuestName.Text.Trim());

                //if (txtSearchInqMobileNo.Text.Trim() != "")
                //    strMobileNo = Convert.ToString(txtSearchInqMobileNo.Text.Trim());


                //if (txtSearchInqGuestEmail.Text.Trim() != "")
                //    strEmail = Convert.ToString(txtSearchInqGuestEmail.Text.Trim());


                //if (ddlSearchInqGuestStatus.SelectedIndex > 0)
                //    strInqStatus = ddlSearchInqGuestStatus.SelectedValue.Trim();


                DataSet dsGuestBirthDayList = GuestBLL.GettGuestBirthDayReport(clsSession.PropertyID, clsSession.CompanyID, FromMonth, ToMonth);

                if (dsGuestBirthDayList != null && dsGuestBirthDayList.Tables.Count > 0 && dsGuestBirthDayList.Tables[0].Rows.Count > 0)
                {
                    gvBirthDayList .DataSource = dsGuestBirthDayList;
                    gvBirthDayList.DataBind();
                }
                else
                {
                    gvBirthDayList.DataSource = null;
                    gvBirthDayList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion Private Method

        #region Grid Event
        protected void gvBirthDayList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //if (e.CommandName.ToUpper().Equals("VIEWINQDATA"))
                //{
                //    ClearInquiryData();
                //    this.InqID = new Guid(Convert.ToString(e.CommandArgument));
                //    EditViewData();
                //    btnUpdateInquiry.Visible = false;
                //    mpeEditInquiryData.Show();
                //}
                //else if (e.CommandName.ToUpper().Equals("EDITINQDATA") && e.CommandArgument != null)
                //{
                //    ClearInquiryData();
                //    this.InqID = new Guid(Convert.ToString(e.CommandArgument));
                //    EditViewData();
                //    btnUpdateInquiry.Visible = true;
                //    mpeEditInquiryData.Show();
                //}
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvBirthDayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvBirthDate = (Label)e.Row.FindControl("lblGvBirthDate");
                    if (DataBinder.Eval(e.Row.DataItem, "DOB") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DOB")) != "")
                    {
                        lblGvBirthDate.Text = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DOB")).ToString(clsSession.DateFormat);
                    }
                    else
                    {
                        lblGvBirthDate.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void gvBirthDayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBirthDayList.PageIndex = e.NewPageIndex;
            BindGuestBirthDayList();
        }
        #endregion Grid Event
    }
}