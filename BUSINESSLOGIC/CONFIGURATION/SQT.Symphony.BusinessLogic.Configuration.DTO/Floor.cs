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
	public class Floor: BusinessObjectBase
	{

		#region InnerClass
		public enum FloorFields
		{
			FloorID,
			PropertyID,
			FloorCode,
			FloorName,
			SeqNo,
			CreatedOn,
			CreatedBy,
			LastUpdateOn,
			LastUpdatedBy,
			UpdateLog,
			IsActive,
			IsAynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _floorID;
			Guid? _propertyID;
			string _floorCode;
			string _floorName;
			int? _seqNo;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _lastUpdateOn;
			Guid? _lastUpdatedBy;
			byte[] _updateLog;
			bool? _isActive;
			bool? _isAynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  FloorID
		{
			 get { return _floorID; }
			 set
			 {
				 if (_floorID != value)
				 {
					_floorID = value;
					 PropertyHasChanged("FloorID");
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
		public string  FloorCode
		{
			 get { return _floorCode; }
			 set
			 {
				 if (_floorCode != value)
				 {
					_floorCode = value;
					 PropertyHasChanged("FloorCode");
				 }
			 }
		}

		[DataMember]
		public string  FloorName
		{
			 get { return _floorName; }
			 set
			 {
				 if (_floorName != value)
				 {
					_floorName = value;
					 PropertyHasChanged("FloorName");
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
		public bool?  IsAynch
		{
			 get { return _isAynch; }
			 set
			 {
				 if (_isAynch != value)
				 {
					_isAynch = value;
					 PropertyHasChanged("IsAynch");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("FloorID", "FloorID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FloorCode", "FloorCode",3));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FloorName", "FloorName",3));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"FloorID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"FloorCode = {2}~\n"+
			"FloorName = {3}~\n"+
			"SeqNo = {4}~\n"+
			"CreatedOn = {5}~\n"+
			"CreatedBy = {6}~\n"+
			"LastUpdateOn = {7}~\n"+
			"LastUpdatedBy = {8}~\n"+
			"UpdateLog = {9}~\n"+
			"IsActive = {10}~\n"+
			"IsAynch = {11}~\n"+
			"SynchOn = {12}~\n",
			FloorID,			PropertyID,			FloorCode,			FloorName,			SeqNo,			CreatedOn,			CreatedBy,			LastUpdateOn,			LastUpdatedBy,			UpdateLog,			IsActive,			IsAynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class FloorKeys
	{

		#region Data Members

		Guid _floorID;

		#endregion

		#region Constructor

		public FloorKeys(Guid floorID)
		{
			 _floorID = floorID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  FloorID
		{
			 get { return _floorID; }
		}

		#endregion

	}
}
