using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using System.ServiceModel;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
	[DataContract]
	public class Wing: BusinessObjectBase
	{

		#region InnerClass
		public enum WingFields
		{
			WingID,
			PropertyID,
			SeqNo,
			SBArea,
			CarpetArea,
			WingCode,
			WingName,
			IsActive,
			CreatedOn,
			CreatedBy,
			LastUpdateOn,
			LastUpdatedBy,
			UpdateLog,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _wingID;
			Guid? _propertyID;
			int? _seqNo;
			decimal? _sBArea;
			decimal? _carpetArea;
			string _wingCode;
			string _wingName;
			bool? _isActive;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _lastUpdateOn;
			Guid? _lastUpdatedBy;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  WingID
		{
			 get { return _wingID; }
			 set
			 {
				 if (_wingID != value)
				 {
					_wingID = value;
					 PropertyHasChanged("WingID");
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
		public int?  SeqNo
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

		[DataMember]
		public decimal?  SBArea
		{
			 get { return _sBArea; }
			 set
			 {
				 if (_sBArea != value)
				 {
					_sBArea = value;
					 PropertyHasChanged("SBArea");
				 }
			 }
		}

		[DataMember]
		public decimal?  CarpetArea
		{
			 get { return _carpetArea; }
			 set
			 {
				 if (_carpetArea != value)
				 {
					_carpetArea = value;
					 PropertyHasChanged("CarpetArea");
				 }
			 }
		}

		[DataMember]
		public string  WingCode
		{
			 get { return _wingCode; }
			 set
			 {
				 if (_wingCode != value)
				 {
					_wingCode = value;
					 PropertyHasChanged("WingCode");
				 }
			 }
		}

		[DataMember]
		public string  WingName
		{
			 get { return _wingName; }
			 set
			 {
				 if (_wingName != value)
				 {
					_wingName = value;
					 PropertyHasChanged("WingName");
				 }
			 }
		}

		[DataMember]
		public bool?  IsActive
		{
			 get { return _isActive; }
			 set
			 {
				 if (_isActive != value)
				 {
					_isActive = value;
					 PropertyHasChanged("IsActive");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CreatedOn
		{
			 get { return _createdOn; }
			 set
			 {
				 if (_createdOn != value)
				 {
					_createdOn = value;
					 PropertyHasChanged("CreatedOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  CreatedBy
		{
			 get { return _createdBy; }
			 set
			 {
				 if (_createdBy != value)
				 {
					_createdBy = value;
					 PropertyHasChanged("CreatedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastUpdateOn
		{
			 get { return _lastUpdateOn; }
			 set
			 {
				 if (_lastUpdateOn != value)
				 {
					_lastUpdateOn = value;
					 PropertyHasChanged("LastUpdateOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  LastUpdatedBy
		{
			 get { return _lastUpdatedBy; }
			 set
			 {
				 if (_lastUpdatedBy != value)
				 {
					_lastUpdatedBy = value;
					 PropertyHasChanged("LastUpdatedBy");
				 }
			 }
		}

		[DataMember]
		public byte[]  UpdateLog
		{
			 get { return _updateLog; }
			 set
			 {
				 if (_updateLog != value)
				 {
					_updateLog = value;
					 PropertyHasChanged("UpdateLog");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSynch
		{
			 get { return _isSynch; }
			 set
			 {
				 if (_isSynch != value)
				 {
					_isSynch = value;
					 PropertyHasChanged("IsSynch");
				 }
			 }
		}

		[DataMember]
		public DateTime?  SynchOn
		{
			 get { return _synchOn; }
			 set
			 {
				 if (_synchOn != value)
				 {
					_synchOn = value;
					 PropertyHasChanged("SynchOn");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("WingID", "WingID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("WingCode", "WingCode",3));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("WingName", "WingName",17));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "WingID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "SeqNo = {2}~\n" +
            "SBArea = {3}~\n" +
            "CarpetArea = {4}~\n" +
            "WingCode = {5}~\n" +
            "WingName = {6}~\n" +
            "IsActive = {7}~\n" +
            "CreatedOn = {8}~\n" +
            "CreatedBy = {9}~\n" +
            "LastUpdateOn = {10}~\n" +
            "LastUpdatedBy = {11}~\n" +
            "UpdateLog = {12}~\n" +
            "IsSynch = {13}~\n" +
            "SynchOn = {14}~\n",
			WingID,			PropertyID,			SeqNo,			SBArea,			CarpetArea,			WingCode,			WingName,			IsActive,			CreatedOn,			CreatedBy,			LastUpdateOn,			LastUpdatedBy,			UpdateLog,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class WingKeys
	{

		#region Data Members

		Guid _wingID;

		#endregion

		#region Constructor

		public WingKeys(Guid wingID)
		{
			 _wingID = wingID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  WingID
		{
			 get { return _wingID; }
		}

		#endregion

	}
}
