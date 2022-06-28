using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
	public class CancellationPolicy: BusinessObjectBase
	{

		#region InnerClass
		public enum CancellationPolicyFields
		{
			PolicyID,
			ResPolicyID,
			CancellationCharges,
			IsFlatCharge,
			MinDays,
			MaxDays,
			SeqNo
		}
		#endregion

		#region Data Members

			Guid _policyID;
			Guid? _resPolicyID;
			decimal? _cancellationCharges;
			bool? _isFlatCharge;
			int? _minDays;
			int? _maxDays;
			int _seqNo;

		#endregion

		#region Properties

		public Guid  PolicyID
		{
			 get { return _policyID; }
			 set
			 {
				 if (_policyID != value)
				 {
					_policyID = value;
					 PropertyHasChanged("PolicyID");
				 }
			 }
		}

		public Guid?  ResPolicyID
		{
			 get { return _resPolicyID; }
			 set
			 {
				 if (_resPolicyID != value)
				 {
					_resPolicyID = value;
					 PropertyHasChanged("ResPolicyID");
				 }
			 }
		}

		public decimal?  CancellationCharges
		{
			 get { return _cancellationCharges; }
			 set
			 {
				 if (_cancellationCharges != value)
				 {
					_cancellationCharges = value;
					 PropertyHasChanged("CancellationCharges");
				 }
			 }
		}

		public bool?  IsFlatCharge
		{
			 get { return _isFlatCharge; }
			 set
			 {
				 if (_isFlatCharge != value)
				 {
					_isFlatCharge = value;
					 PropertyHasChanged("IsFlatCharge");
				 }
			 }
		}

		public int?  MinDays
		{
			 get { return _minDays; }
			 set
			 {
				 if (_minDays != value)
				 {
					_minDays = value;
					 PropertyHasChanged("MinDays");
				 }
			 }
		}

		public int?  MaxDays
		{
			 get { return _maxDays; }
			 set
			 {
				 if (_maxDays != value)
				 {
					_maxDays = value;
					 PropertyHasChanged("MaxDays");
				 }
			 }
		}

		public int  SeqNo
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

		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PolicyID", "PolicyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		public override string ToString()
		{
			string objValue = string.Format(
			"PolicyID = {0}\n"+
			"ResPolicyID = {1}\n"+
			"CancellationCharges = {2}\n"+
			"IsFlatCharge = {3}\n"+
			"MinDays = {4}\n"+
			"MaxDays = {5}\n"+
			"SeqNo = {6}\n",
			PolicyID,			ResPolicyID,			CancellationCharges,			IsFlatCharge,			MinDays,			MaxDays,			SeqNo);			return objValue;
		}

		#endregion

	}
	public class CancellationPolicyKeys
	{

		#region Data Members

		Guid _policyID;

		#endregion

		#region Constructor

		public CancellationPolicyKeys(Guid policyID)
		{
			 _policyID = policyID; 
		}

		#endregion

		#region Properties

		public Guid  PolicyID
		{
			 get { return _policyID; }
		}

		#endregion

	}
}
