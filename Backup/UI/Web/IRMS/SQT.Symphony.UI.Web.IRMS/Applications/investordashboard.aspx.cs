using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;

namespace SQT.Symphony.UI.Web.IRMS.Applications
{
    public partial class investordashboard : System.Web.UI.Page
    {
        #region Form Load
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadDefaultData();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Default Value
        /// </summary>
        /// 
        /*
        private void LoadDefaultData()
        {
            string Query = "Select Grd.DisplayName, Grd.SeqNo From Mst_Gadget Grd Inner Join Mst_GradgetUserJoin GrdJn On GrdJn.GadgetID = Grd.GadgetID Where Grd.IsInvestor = 1 And GrdJn.UserID Like '" + Convert.ToString(Session["UserID"]) + "' Order By Grd.SeqNo ASC";
            DataSet Dst = InvestorBLL.GetSearchData(Query);
            DataView Dv = new DataView(Dst.Tables[0]);
            if (Dv.Count > 0)
            {
                if (Dv.Count == 4)
                {
                    col11.Visible = true;
                    col12.Visible = true;
                    col21.Visible = true;
                    col22.Visible = true;
                }
                else if (Dv.Count == 3)
                {
                    int SeqNo1 = Convert.ToInt32(Dv[0]["SeqNo"].ToString());
                    int SeqNo2 = Convert.ToInt32(Dv[1]["SeqNo"].ToString());
                    int SeqNo3 = Convert.ToInt32(Dv[2]["SeqNo"].ToString());
                    if (SeqNo1 == 1 & SeqNo2 == 2 && SeqNo3 == 3)
                    {
                        col21.ColSpan = 2;
                        col11.Visible = true;
                        col12.Visible = true;
                        col21.Visible = true;
                        col22.Visible = false;
                    }
                    if (SeqNo1 == 1 && SeqNo2 == 2 && SeqNo3 == 4)
                    {
                        col11.RowSpan = 2;
                        col11.Visible = true;
                        col12.Visible = true;
                        col21.Visible = false;
                        col22.Visible = true;
                    }
                    if (SeqNo1 == 2 && SeqNo2 == 3 && SeqNo3 == 4)
                    {
                        col12.ColSpan = 2;
                        col12.Visible = true;
                        col11.Visible = false;
                        col21.Visible = true;
                        col22.Visible = true;

                    }
                    if (SeqNo1 == 1 && SeqNo2 == 3 && SeqNo3 == 4)
                    {
                        col12.Visible = false;
                        col11.Visible = true;
                        col11.ColSpan = 2;
                        col21.Visible = true;
                        col22.Visible = true;
                    }
                }
                else if (Dv.Count == 2)
                {
                    int SeqNo1 = Convert.ToInt32(Dv[0]["SeqNo"].ToString());
                    int SeqNo2 = Convert.ToInt32(Dv[1]["SeqNo"].ToString());
                    if (SeqNo1 == 1 && SeqNo2 == 2)
                    {
                        col11.Visible = true;
                        col11.RowSpan = 2;
                        col12.Visible = true;
                        col12.RowSpan = 2;
                        col21.Visible = false;
                        col22.Visible = false;
                    }
                    if (SeqNo1 == 1 && SeqNo2 == 3)
                    {
                        col11.Visible = true;
                        col11.ColSpan = 2;
                        col12.Visible = false;
                        col21.Visible = true;
                        col21.ColSpan = 2;
                        col22.Visible = false;
                    }
                    if (SeqNo1 == 1 && SeqNo2 == 4)
                    {
                        col11.Visible = true;
                        col11.ColSpan = 2;
                        col12.Visible = false;
                        col21.Visible = false;
                        col22.ColSpan = 2;
                        col22.Visible = true;
                    }
                    if (SeqNo1 == 2 && SeqNo2 == 3)
                    {
                        col11.Visible = false;
                        col12.ColSpan = 2;
                        col12.Visible = true;
                        col21.Visible = true;
                        col21.ColSpan = 2;
                        col22.Visible = false;
                    }
                    if (SeqNo1 == 2 && SeqNo2 == 4)
                    {
                        col11.Visible = false;
                        col12.ColSpan = 2;
                        col12.Visible = true;
                        col21.Visible = false;
                        col22.ColSpan = 2;
                        col22.Visible = true;
                    }
                    if (SeqNo1 == 3 && SeqNo2 == 4)
                    {
                        col11.Visible = false;
                        col12.Visible = false;
                        col21.Visible = true;
                        col21.RowSpan = 2;
                        col22.Visible = true;
                        col22.RowSpan = 2;
                    }
                }
                else if (Dv.Count == 1)
                {
                    int SeqNo1 = Convert.ToInt32(Dv[0]["SeqNo"].ToString());
                    if (SeqNo1 == 1)
                    {
                        col11.Visible = true;
                        col11.RowSpan = 2;
                        col11.ColSpan = 2;
                        col12.Visible = col21.Visible = col22.Visible = false;
                    }
                    if (SeqNo1 == 2)
                    {
                        col12.Visible = true;
                        col12.RowSpan = 2;
                        col12.ColSpan = 2;
                        col11.Visible = col21.Visible = col22.Visible = false;
                    }
                    if (SeqNo1 == 3)
                    {
                        col21.Visible = true;
                        col21.RowSpan = 2;
                        col21.ColSpan = 2;
                        col11.Visible = col12.Visible = col22.Visible = false;
                    }
                    if (SeqNo1 == 4)
                    {
                        col22.Visible = true;
                        col22.RowSpan = 2;
                        col22.ColSpan = 2;
                        col11.Visible = col12.Visible = col21.Visible = false;
                    }

                }
            }
            else
            {
                col11.Visible = false;
                col12.Visible = false;
                col21.Visible = false;
                col22.Visible = false;
            }
        }
         * */
        #endregion Private Method
    }
}
        