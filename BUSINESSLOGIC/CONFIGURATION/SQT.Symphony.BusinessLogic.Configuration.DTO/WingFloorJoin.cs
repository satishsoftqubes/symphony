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
	public class WingFloorJoin: BusinessObjectBase
	{

		#region InnerClass
		public enum WingFloorJoinFields
		{
			WingFloorJoinID,
			WingID,
			FloorID,
			Area,
			CarpateArea,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _wingFloorJoinID;
			Guid? _wingID;
			Guid? _floorID;
			decimal? _area;
			decimal? _carpateArea;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  WingFloorJoinID
		{
			 get { return _wingFloorJoinID; }
			 set
			 {
				 if (_wingFloorJoinID != value)
				 {
					_wingFloorJoinID = value;
					 PropertyHasChanged("WingFloorJoinID");
				 }
			 }
		}

		[DataMember]
		public Guid?  WingID
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
		public Guid?  FloorID
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
		public decimal?  Area
		{
			 get { return _area; }
			 set
			 {
				 if (_area != value)
				 {
					_area = value;
					 PropertyHasChanged("Area");
				 }
			 }
		}

		[DataMember]
		public decimal?  CarpateArea
		{
			 get { return _carpateArea; }
			 set
			 {
				 if (_carpateArea != value)
				 {
					_carpateArea = value;
					 PropertyHasChanged("CarpateArea");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("WingFloorJoinID", "WingFloorJoinID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"WingFloorJoinID = {0}~\n"+
            "WingID = {1}~\n" +
            "FloorID = {2}~\n" +
            "Area = {3}~\n" +
            "CarpateArea = {4}~\n" +
            "IsSynch = {5}~\n" +
            "SynchOn = {6}~\n",
			WingFloorJoinID,			WingID,			FloorID,			Area,			CarpateArea,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class WingFloorJoinKeys
	{

		#region Data Members

		Guid _wingFloorJoinID;

		#endregion

		#region Constructor

		public WingFloorJoinKeys(Guid wingFloorJoinID)
		{
			 _wingFloorJoinID = wingFloorJoinID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  WingFloorJoinID
		{
			 get { return _wingFloorJoinID; }
		}

		#endregion

	}
}
