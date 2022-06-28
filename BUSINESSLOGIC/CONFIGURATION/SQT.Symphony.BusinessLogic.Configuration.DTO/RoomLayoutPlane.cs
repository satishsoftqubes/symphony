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
	public class RoomLayoutPlane: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomLayoutPlaneFields
		{
			RoomLayoutPlanID,
			PropertyID,
			SeqNo,
			PlanName,
			PlaneCode,
			CreatedOn,
			CreatedBy,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			UpdateLog,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _roomLayoutPlanID;
			Guid? _propertyID;
			int? _seqNo;
			string _planName;
			string _planeCode;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomLayoutPlanID
		{
			 get { return _roomLayoutPlanID; }
			 set
			 {
				 if (_roomLayoutPlanID != value)
				 {
					_roomLayoutPlanID = value;
					 PropertyHasChanged("RoomLayoutPlanID");
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
		public string  PlanName
		{
			 get { return _planName; }
			 set
			 {
				 if (_planName != value)
				 {
					_planName = value;
					 PropertyHasChanged("PlanName");
				 }
			 }
		}

		[DataMember]
		public string  PlaneCode
		{
			 get { return _planeCode; }
			 set
			 {
				 if (_planeCode != value)
				 {
					_planeCode = value;
					 PropertyHasChanged("PlaneCode");
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
		public DateTime?  UpdatedOn
		{
			 get { return _updatedOn; }
			 set
			 {
				 if (_updatedOn != value)
				 {
					_updatedOn = value;
					 PropertyHasChanged("UpdatedOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  UpdatedBy
		{
			 get { return _updatedBy; }
			 set
			 {
				 if (_updatedBy != value)
				 {
					_updatedBy = value;
					 PropertyHasChanged("UpdatedBy");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomLayoutPlanID", "RoomLayoutPlanID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PlanName", "PlanName",75));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PlaneCode", "PlaneCode",7));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomLayoutPlanID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"SeqNo = {2}~\n"+
			"PlanName = {3}~\n"+
			"PlaneCode = {4}~\n"+
			"CreatedOn = {5}~\n"+
			"CreatedBy = {6}~\n"+
			"UpdatedOn = {7}~\n"+
			"UpdatedBy = {8}~\n"+
			"IsActive = {9}~\n"+
			"UpdateLog = {10}~\n"+
			"IsSynch = {11}~\n"+
			"SynchOn = {12}~\n",
			RoomLayoutPlanID,			PropertyID,			SeqNo,			PlanName,			PlaneCode,			CreatedOn,			CreatedBy,			UpdatedOn,			UpdatedBy,			IsActive,			UpdateLog,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomLayoutPlaneKeys
	{

		#region Data Members

		Guid _roomLayoutPlanID;

		#endregion

		#region Constructor

		public RoomLayoutPlaneKeys(Guid roomLayoutPlanID)
		{
			 _roomLayoutPlanID = roomLayoutPlanID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomLayoutPlanID
		{
			 get { return _roomLayoutPlanID; }
		}

		#endregion

	}
}
