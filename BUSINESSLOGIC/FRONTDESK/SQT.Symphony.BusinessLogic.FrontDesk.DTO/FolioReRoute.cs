using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.FrontDesk.DTO
{
	[DataContract]
	public class FolioReRoute: BusinessObjectBase
	{

		#region InnerClass
		public enum FolioReRouteFields
		{
			FolioReRouteID,
			SourceFolioID,
			DestinationFolioID,
			TransactionZone_TermID,
			IsSameFolio,
			SearchType,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _folioReRouteID;
			Guid? _sourceFolioID;
			Guid? _destinationFolioID;
			int? _transactionZone_TermID;
			bool? _isSameFolio;
			string _searchType;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  FolioReRouteID
		{
			 get { return _folioReRouteID; }
			 set
			 {
				 if (_folioReRouteID != value)
				 {
					_folioReRouteID = value;
					 PropertyHasChanged("FolioReRouteID");
				 }
			 }
		}

		[DataMember]
		public Guid?  SourceFolioID
		{
			 get { return _sourceFolioID; }
			 set
			 {
				 if (_sourceFolioID != value)
				 {
					_sourceFolioID = value;
					 PropertyHasChanged("SourceFolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  DestinationFolioID
		{
			 get { return _destinationFolioID; }
			 set
			 {
				 if (_destinationFolioID != value)
				 {
					_destinationFolioID = value;
					 PropertyHasChanged("DestinationFolioID");
				 }
			 }
		}

		[DataMember]
		public int?  TransactionZone_TermID
		{
			 get { return _transactionZone_TermID; }
			 set
			 {
				 if (_transactionZone_TermID != value)
				 {
					_transactionZone_TermID = value;
					 PropertyHasChanged("TransactionZone_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSameFolio
		{
			 get { return _isSameFolio; }
			 set
			 {
				 if (_isSameFolio != value)
				 {
					_isSameFolio = value;
					 PropertyHasChanged("IsSameFolio");
				 }
			 }
		}

		[DataMember]
		public string  SearchType
		{
			 get { return _searchType; }
			 set
			 {
				 if (_searchType != value)
				 {
					_searchType = value;
					 PropertyHasChanged("SearchType");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("FolioReRouteID", "FolioReRouteID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SearchType", "SearchType",1));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"FolioReRouteID = {0}\n"+
			"SourceFolioID = {1}\n"+
			"DestinationFolioID = {2}\n"+
			"TransactionZone_TermID = {3}\n"+
			"IsSameFolio = {4}\n"+
			"SearchType = {5}\n"+
			"PropertyID = {6}\n"+
			"CompanyID = {7}\n"+
			"SeqNo = {8}\n"+
			"IsSynch = {9}\n"+
			"SynchOn = {10}\n"+
			"UpdatedOn = {11}\n"+
			"UpdatedBy = {12}\n"+
			"IsActive = {13}\n",
			FolioReRouteID,			SourceFolioID,			DestinationFolioID,			TransactionZone_TermID,			IsSameFolio,			SearchType,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class FolioReRouteKeys
	{

		#region Data Members

		Guid _folioReRouteID;

		#endregion

		#region Constructor

		public FolioReRouteKeys(Guid folioReRouteID)
		{
			 _folioReRouteID = folioReRouteID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  FolioReRouteID
		{
			 get { return _folioReRouteID; }
		}

		#endregion

	}
}
