using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
	[DataContract]
	public class CounterLoginLog: BusinessObjectBase
	{

		#region InnerClass
		public enum CounterLoginLogFields
		{
			CounterLoginLogID,
			UserID,
			CounterID,
			LogInDate,
			LogOutDate,
			CloseID,
			PropertyID,
			CompanyID,
			SeqNo
		}
		#endregion

		#region Data Members

			Guid _counterLoginLogID;
			Guid? _userID;
			Guid? _counterID;
			DateTime? _logInDate;
			DateTime? _logOutDate;
			Guid? _closeID;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CounterLoginLogID
		{
			 get { return _counterLoginLogID; }
			 set
			 {
				 if (_counterLoginLogID != value)
				 {
					_counterLoginLogID = value;
					 PropertyHasChanged("CounterLoginLogID");
				 }
			 }
		}

		[DataMember]
		public Guid?  UserID
		{
			 get { return _userID; }
			 set
			 {
				 if (_userID != value)
				 {
					_userID = value;
					 PropertyHasChanged("UserID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CounterID
		{
			 get { return _counterID; }
			 set
			 {
				 if (_counterID != value)
				 {
					_counterID = value;
					 PropertyHasChanged("CounterID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LogInDate
		{
			 get { return _logInDate; }
			 set
			 {
				 if (_logInDate != value)
				 {
					_logInDate = value;
					 PropertyHasChanged("LogInDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LogOutDate
		{
			 get { return _logOutDate; }
			 set
			 {
				 if (_logOutDate != value)
				 {
					_logOutDate = value;
					 PropertyHasChanged("LogOutDate");
				 }
			 }
		}

		[DataMember]
		public Guid?  CloseID
		{
			 get { return _closeID; }
			 set
			 {
				 if (_closeID != value)
				 {
					_closeID = value;
					 PropertyHasChanged("CloseID");
				 }
			 }
		}

		[DataMember]
		public Guid?  PropertyID
		{
			 get { return _propertyID; }
			 set
			 {
				 if (_propertyID != value)
				 {
					_propertyID = value;
					 PropertyHasChanged("PropertyID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CompanyID
		{
			 get { return _companyID; }
			 set
			 {
				 if (_companyID != value)
				 {
					_companyID = value;
					 PropertyHasChanged("CompanyID");
				 }
			 }
		}

		[DataMember]
		public long  SeqNo
		{
			 get { return _seqNo; }
			 set
			 {
				 if (_seqNo != value)
				 {
					_seqNo = value;
					 PropertyHasChanged("SeqNo");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CounterLoginLogID", "CounterLoginLogID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CounterLoginLogID = {0}\n"+
			"UserID = {1}\n"+
			"CounterID = {2}\n"+
			"LogInDate = {3}\n"+
			"LogOutDate = {4}\n"+
			"CloseID = {5}\n"+
			"PropertyID = {6}\n"+
			"CompanyID = {7}\n"+
			"SeqNo = {8}\n",
			CounterLoginLogID,			UserID,			CounterID,			LogInDate,			LogOutDate,			CloseID,			PropertyID,			CompanyID,			SeqNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CounterLoginLogKeys
	{

		#region Data Members

		Guid _counterLoginLogID;

		#endregion

		#region Constructor

		public CounterLoginLogKeys(Guid counterLoginLogID)
		{
			 _counterLoginLogID = counterLoginLogID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CounterLoginLogID
		{
			 get { return _counterLoginLogID; }
		}

		#endregion

	}
}
