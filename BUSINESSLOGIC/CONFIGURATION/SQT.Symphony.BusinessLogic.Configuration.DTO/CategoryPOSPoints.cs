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
	public class CategoryPOSPoints: BusinessObjectBase
	{

		#region InnerClass
		public enum CategoryPOSPointsFields
		{
			CategoryPOSPointID,
			SeqNo,
			IsSynch,
			SynchOn,
			IsActive,
			CategoryID,
			POSPointID,
			Location_TermID
		}
		#endregion

		#region Data Members

			Guid _categoryPOSPointID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			bool? _isActive;
			Guid? _categoryID;
			Guid? _pOSPointID;
			Guid? _location_TermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CategoryPOSPointID
		{
			 get { return _categoryPOSPointID; }
			 set
			 {
				 if (_categoryPOSPointID != value)
				 {
					_categoryPOSPointID = value;
					 PropertyHasChanged("CategoryPOSPointID");
				 }
			 }
		}

		[DataMember]
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
		public Guid?  CategoryID
		{
			 get { return _categoryID; }
			 set
			 {
				 if (_categoryID != value)
				 {
					_categoryID = value;
					 PropertyHasChanged("CategoryID");
				 }
			 }
		}

		[DataMember]
		public Guid?  POSPointID
		{
			 get { return _pOSPointID; }
			 set
			 {
				 if (_pOSPointID != value)
				 {
					_pOSPointID = value;
					 PropertyHasChanged("POSPointID");
				 }
			 }
		}

		[DataMember]
		public Guid?  Location_TermID
		{
			 get { return _location_TermID; }
			 set
			 {
				 if (_location_TermID != value)
				 {
					_location_TermID = value;
					 PropertyHasChanged("Location_TermID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CategoryPOSPointID", "CategoryPOSPointID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CategoryPOSPointID = {0}~\n"+
			"SeqNo = {1}~\n"+
			"IsSynch = {2}~\n"+
			"SynchOn = {3}~\n"+
			"IsActive = {4}~\n"+
			"CategoryID = {5}~\n"+
			"POSPointID = {6}~\n"+
			"Location_TermID = {7}~\n",
			CategoryPOSPointID,			SeqNo,			IsSynch,			SynchOn,			IsActive,			CategoryID,			POSPointID,			Location_TermID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CategoryPOSPointsKeys
	{

		#region Data Members

		Guid _categoryPOSPointID;

		#endregion

		#region Constructor

		public CategoryPOSPointsKeys(Guid categoryPOSPointID)
		{
			 _categoryPOSPointID = categoryPOSPointID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CategoryPOSPointID
		{
			 get { return _categoryPOSPointID; }
		}

		#endregion

	}
}
