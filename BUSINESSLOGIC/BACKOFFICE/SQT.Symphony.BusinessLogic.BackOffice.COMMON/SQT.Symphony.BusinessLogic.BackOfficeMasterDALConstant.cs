using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.Symphony.BusinessLogic.BackOffice.COMMON
{
	public class MasterDALConstant
	{
		//SPs for  acc_Account
		public const string AccountInsert = "[dbo].[acc_Account_Insert]";
		public const string AccountUpdate = "[dbo].[acc_Account_Update]";
		public const string AccountSelectByPrimaryKey = "[dbo].[acc_Account_SelectByPrimaryKey]";
		public const string AccountSelectAll = "[dbo].[acc_Account_SelectAll]";
		public const string AccountSelectByField = "[dbo].[acc_Account_SelectByField]";
		public const string AccountDeleteByPrimaryKey = "[dbo].[acc_Account_DeleteByPrimaryKey]";
		public const string AccountDeleteByField = "[dbo].[acc_Account_DeleteByField]";
        public const string AccountSelectInGroup = "[dbo].[acc_Account_GetAllAccountsInGroup]";
		//SPs for  acc_AccountConfig
		public const string AccountConfigInsert = "[dbo].[acc_AccountConfig_Insert]";
		public const string AccountConfigUpdate = "[dbo].[acc_AccountConfig_Update]";
		public const string AccountConfigSelectByPrimaryKey = "[dbo].[acc_AccountConfig_SelectByPrimaryKey]";
		public const string AccountConfigSelectAll = "[dbo].[acc_AccountConfig_SelectAll]";
		public const string AccountConfigSelectByField = "[dbo].[acc_AccountConfig_SelectByField]";
		public const string AccountConfigDeleteByPrimaryKey = "[dbo].[acc_AccountConfig_DeleteByPrimaryKey]";
		public const string AccountConfigDeleteByField = "[dbo].[acc_AccountConfig_DeleteByField]";
        public const string AccountOnlySearchData = "[dbo].[acc_Account_SearchOnlyAccountData]";
		//SPs for  acc_AccountGroup
		public const string AccountGroupInsert = "[dbo].[acc_AccountGroup_Insert]";
		public const string AccountGroupUpdate = "[dbo].[acc_AccountGroup_Update]";
		public const string AccountGroupSelectByPrimaryKey = "[dbo].[acc_AccountGroup_SelectByPrimaryKey]";
		public const string AccountGroupSelectAll = "[dbo].[acc_AccountGroup_SelectAll]";
		public const string AccountGroupSelectByField = "[dbo].[acc_AccountGroup_SelectByField]";
		public const string AccountGroupDeleteByPrimaryKey = "[dbo].[acc_AccountGroup_DeleteByPrimaryKey]";
		public const string AccountGroupDeleteByField = "[dbo].[acc_AccountGroup_DeleteByField]";

        //SPs for  acc_AcctTaxJoin
        public const string AcctTaxJoinInsert = "[dbo].[acc_AcctTaxJoin_Insert]";
        public const string AcctTaxJoinUpdate = "[dbo].[acc_AcctTaxJoin_Update]";
        public const string AcctTaxJoinSelectByPrimaryKey = "[dbo].[acc_AcctTaxJoin_SelectByPrimaryKey]";
        public const string AcctTaxJoinSelectAll = "[dbo].[acc_AcctTaxJoin_SelectAll]";
        public const string AcctTaxJoinSelectByField = "[dbo].[acc_AcctTaxJoin_SelectByField]";
        public const string AcctTaxJoinDeleteByPrimaryKey = "[dbo].[acc_AcctTaxJoin_DeleteByPrimaryKey]";
        public const string AcctTaxJoinDeleteByField = "[dbo].[acc_AcctTaxJoin_DeleteByField]";
        public const string AcctTaxJoinSelectAllData = "[dbo].[acc_AcctTaxJoin_SelectAllData]";
        //SPs for  snd_Bank
        public const string BankInsert = "[symphony_sa].[snd_Bank_Insert]";
        public const string BankUpdate = "[symphony_sa].[snd_Bank_Update]";
        public const string BankSelectByPrimaryKey = "[symphony_sa].[snd_Bank_SelectByPrimaryKey]";
        public const string BankSelectAll = "[symphony_sa].[snd_Bank_SelectAll]";
        public const string BankSelectByField = "[symphony_sa].[snd_Bank_SelectByField]";
        public const string BankDeleteByPrimaryKey = "[symphony_sa].[snd_Bank_DeleteByPrimaryKey]";
        public const string BankDeleteByField = "[symphony_sa].[snd_Bank_DeleteByField]";

        //SPs for  tra_DayEnd
        public const string DayEndInsert = "[dbo].[tra_DayEnd_Insert]";
        public const string DayEndUpdate = "[dbo].[tra_DayEnd_Update]";
        public const string DayEndSelectByPrimaryKey = "[dbo].[tra_DayEnd_SelectByPrimaryKey]";
        public const string DayEndSelectAll = "[dbo].[tra_DayEnd_SelectAll]";
        public const string DayEndSelectByField = "[dbo].[tra_DayEnd_SelectByField]";
        public const string DayEndDeleteByPrimaryKey = "[dbo].[tra_DayEnd_DeleteByPrimaryKey]";
        public const string DayEndDeleteByField = "[dbo].[tra_DayEnd_DeleteByField]";
        public const string DayEnd_PreCheckReport = "[dbo].[acc_DAYEND_PreCheckReport]";
        public const string DayEnd_DetailReport = "[dbo].[acc_DAYEND_DetailReport]";
        public const string DayEnd_CounterCloseDetailRport = "[dbo].[acc_DayEnd_CounterCloseDetailRport]";
        public const string DayEnd_DayendCollectionRport = "[dbo].[acc_DayendCollectionRport]";
        public const string DayEnd_BackUp = "[dbo].[acc_DayEnd_BackUp]";
        public const string DayEnd_Save = "[dbo].[acc_DayEndSave]";
        public const string Reservation_AutoPostRoomAndServiceCharge = "[dbo].[res_AutoPostRoomAndServiceCharge]";

        //SPs for Reports
        public const string LedgerStatement = "[dbo].[rpt_LedgerStatement]";

        //SPs for  tra_Agent_Payment
        public const string Agent_PaymentInsert = "[dbo].[tra_Agent_Payment_Insert]";
        public const string Agent_PaymentUpdate = "[dbo].[tra_Agent_Payment_Update]";
        public const string Agent_PaymentSelectByPrimaryKey = "[dbo].[tra_Agent_Payment_SelectByPrimaryKey]";
        public const string Agent_PaymentSelectAll = "[dbo].[tra_Agent_Payment_SelectAll]";
        public const string Agent_PaymentSelectByField = "[dbo].[tra_Agent_Payment_SelectByField]";
        public const string Agent_PaymentDeleteByPrimaryKey = "[dbo].[tra_Agent_Payment_DeleteByPrimaryKey]";
        public const string Agent_PaymentDeleteByField = "[dbo].[tra_Agent_Payment_DeleteByField]";
        //SPs for  tra_Agent_Receipt
        public const string Agent_ReceiptInsert = "[dbo].[tra_Agent_Receipt_Insert]";
        public const string Agent_ReceiptUpdate = "[dbo].[tra_Agent_Receipt_Update]";
        public const string Agent_ReceiptSelectByPrimaryKey = "[dbo].[tra_Agent_Receipt_SelectByPrimaryKey]";
        public const string Agent_ReceiptSelectAll = "[dbo].[tra_Agent_Receipt_SelectAll]";
        public const string Agent_ReceiptSelectByField = "[dbo].[tra_Agent_Receipt_SelectByField]";
        public const string Agent_ReceiptDeleteByPrimaryKey = "[dbo].[tra_Agent_Receipt_DeleteByPrimaryKey]";
        public const string Agent_ReceiptDeleteByField = "[dbo].[tra_Agent_Receipt_DeleteByField]";
        //SPs for  tra_Receipt
        public const string ReceiptInsert = "[dbo].[tra_Receipt_Insert]";
        public const string ReceiptUpdate = "[dbo].[tra_Receipt_Update]";
        public const string ReceiptSelectByPrimaryKey = "[dbo].[tra_Receipt_SelectByPrimaryKey]";
        public const string ReceiptSelectAll = "[dbo].[tra_Receipt_SelectAll]";
        public const string ReceiptSelectByField = "[dbo].[tra_Receipt_SelectByField]";
        public const string ReceiptDeleteByPrimaryKey = "[dbo].[tra_Receipt_DeleteByPrimaryKey]";
        public const string ReceiptDeleteByField = "[dbo].[tra_Receipt_DeleteByField]";
	}
}

