using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.BackOffice.DTO
{
	[DataContract]
	public class AcctTaxJoin: BusinessObjectBase
	{

		#region InnerClass
		public enum AcctTaxJoinFields
		{
			TaxJoinID,
			AcctID,
			AcctTaxID
		}
		#endregion

		#region Data Members

			Guid _taxJoinID;
			Guid _acctID;
			Guid _acctTaxID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxJoinID
		{
			 get { return _taxJoinID; }
			 set
			 {
				 if (_taxJoinID != value)
				 {
					_taxJoinID = value;
					 PropertyHasChanged("TaxJoinID");
				 }
			 }
		}

		[DataMember]
		public Guid  AcctID
		{
			 get { return _acctID; }
			 set
			 {
				 if (_acctID != value)
				 {
					_acctID = value;
					 PropertyHasChanged("AcctID");
				 }
			 }
		}

		[DataMember]
		public Guid  AcctTaxID
		{
			 get { return _acctTaxID; }
			 set
			 {
				 if (_acctTaxID != value)
				 {
					_acctTaxID = value;
					 PropertyHasChanged("AcctTaxID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TaxJoinID", "TaxJoinID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctID", "AcctID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctTaxID", "AcctTaxID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"TaxJoinID = {0}\n"+
			"AcctID = {1}\n"+
			"AcctTaxID = {2}\n",
			TaxJoinID,			AcctID,			AcctTaxID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AcctTaxJoinKeys
	{

		#region Data Members

		Guid _taxJoinID;

		#endregion

		#region Constructor

		public AcctTaxJoinKeys(Guid taxJoinID)
		{
			 _taxJoinID = taxJoinID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxJoinID
		{
			 get { return _taxJoinID; }
		}

		#endregion

	}
}
