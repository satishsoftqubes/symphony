using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Configuration;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System.ServiceModel;

namespace SQT.Symphony.UI.Web.IRServices.Services
{
    /// <summary>
    /// Summary description for InvestorList
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class InvestorList : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet GetInvestorListInDataSet(Guid? InvestorID)
        {
            try
            {
                Guid CompanyID = new Guid(Convert.ToString(ConfigurationSettings.AppSettings["IR_CompanyID"]));

                DataSet dsInvestorList = new DataSet("InvestorList");

                dsInvestorList = InvestorBLL.GetAllInvestorsForFrontDesk(CompanyID,InvestorID);

                if (dsInvestorList != null && dsInvestorList.Tables.Count > 0 && dsInvestorList.Tables[0].Rows.Count > 0)
                {
                    dsInvestorList.Tables[0].TableName = "Investors";
                }
                //}

                return dsInvestorList;
            }
            catch (FaultException ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet GetVoucherListByInvestorIDInDataSet(Guid InvestorID)
        {
            try
            {
                DataSet dsVoucherList = new DataSet("VoucherList");

                dsVoucherList = ReservationVoucherBLL.GetAll_ForFrontDesk_ByInvestorID(InvestorID);

                if (dsVoucherList != null && dsVoucherList.Tables.Count > 0 && dsVoucherList.Tables[0].Rows.Count > 0)
                {
                    dsVoucherList.Tables[0].TableName = "Vouchers";
                }
                //}

                return dsVoucherList;
            }
            catch (FaultException ex)
            {
                throw;
            }
        }

        [WebMethod]
        public DataSet GetVoucherDetailByVoucherID(Guid ResVoucherID)
        {
            try
            {
                DataSet dsVoucherDetail = new DataSet("VoucherDetail");

                dsVoucherDetail = ReservationVoucherBLL.GetByPrimaryKeyInDataSet(ResVoucherID);

                if (dsVoucherDetail != null && dsVoucherDetail.Tables.Count > 0 && dsVoucherDetail.Tables[0].Rows.Count > 0)
                {
                    dsVoucherDetail.Tables[0].TableName = "Vouchers";
                }
                //}

                return dsVoucherDetail;
            }
            catch (FaultException ex)
            {
                throw;
            }
        }

        [WebMethod]
        public bool Update_ReservationAndAllocatedRoomID(Guid ResVoucherID, Guid ReservationID, Guid? AllocatedRoomID, string UpdateMode)
        {
            try
            {
                return ReservationVoucherBLL.Update_ReservationAndAllocatedRoomID(ResVoucherID, ReservationID, AllocatedRoomID, UpdateMode);
            }
            catch (FaultException ex)
            {
                throw;
            }
        }
        [WebMethod]
        public DataSet GetInvestorEmailAddress()
        {
            try
            {
                Guid CompanyID = new Guid(Convert.ToString(ConfigurationSettings.AppSettings["IR_CompanyID"]));

                DataSet dsInvestorList = new DataSet("InvestorEmailAddress");

                dsInvestorList = InvestorBLL.GetInvestorEmailAddress(CompanyID);

                if (dsInvestorList != null && dsInvestorList.Tables.Count > 0 && dsInvestorList.Tables[0].Rows.Count > 0)
                {
                    dsInvestorList.Tables[0].TableName = "InvestorEmailAddress";
                }
                //}

                return dsInvestorList;
            }
            catch (FaultException ex)
            {
                throw;
            }
        }
    }
}
