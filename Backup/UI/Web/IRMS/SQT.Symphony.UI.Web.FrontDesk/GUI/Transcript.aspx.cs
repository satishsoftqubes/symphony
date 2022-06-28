using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Collections;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI
{
    public partial class Transcript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string TranscriptName = Request.QueryString["LinkValue"].ToString();
                if (TranscriptName != string.Empty)
                {
                    string[] strTranscriptID = TranscriptName.Split('|');
                    litMainHeader.Text = strTranscriptID[0];
                    trDataToshow.Visible = true;
                    DataSet dsForDescription = TranscriptBLL.GetAllByWithDataSet(BusinessLogic.Configuration.DTO.Transcript.TranscriptFields.TranscriptID,strTranscriptID[1]);
                    if (dsForDescription != null && dsForDescription.Tables.Count > 0 && dsForDescription.Tables[0].Rows.Count > 0)
                    {
                        trDataToshow.Visible = true;
                        tdDataToshow.Visible = true;
                        tdDataToshow.InnerHtml = Convert.ToString(dsForDescription.Tables[0].Rows[0]["Description"]);
                    }
                    else
                    {
                        trDataToshow.Visible = false ;
                        tdDataToshow.Visible = false ;
                    }
                }
                else
                {
                    trDataToshow.Visible = false;
                    tdDataToshow.Visible = false;
                }
            }
        }
    }
}