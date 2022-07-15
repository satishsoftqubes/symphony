DROP PROCEDURE IF EXISTS dbo.mst_Property_SelectData

GO

CREATE PROCEDURE dbo.mst_Property_SelectData
(  
 @PropertyID uniqueidentifier = null,  
 @CompanyID uniqueidentifier = null,  
 @PropertyName nvarchar(65) = null,
 @Location varchar(120) = null,
 @PropertyType uniqueidentifier = null
)  
AS  
BEGIN  
 SELECT   
  mst_Property.PropertyID, mst_Property.CompanyID, mst_Property.SeqNo, [PropertyTypeID], [PropertyStatusID], [PropertyCode], [PropertyName], [PurchaseOptionID], [SurveyNo], [PaymentTermID], [Jantri], mst_Property.AddressID, [PropManagerName], [PrimaryContactNo], [PrimaryEmail], [PrimaryFax], [PropertyDisplayName], [PropertyRegisteredOn], 
  [PropertyRegisteredBy], [PropertyCreatedOn], [IsApproved], [ApprovedBy], [ApprovedOn], [PropertyRating], [PropertyComments], [LastUpdateOn], [LastUpdateBy], mst_Property.IsSynch,mst_Property.IsActive, [ActivationKey], [ActivationCode], [LicenseNoOfUsers], mst_Property.Thumb, mst_Property.SynchOn, mst_Property.UpdateLog, [SBArea], [CarpetArea], [PhotoLocal],  
  mst_Address.Add1,mst_Address.Add2,mst_Address.ZipCode,mst_Address.City,mst_Address.AddressTypeTermID,mst_Country.CountryName,mst_State.StateName,p1.Term 'ProperyType',p2.Term 'AddressType',mst_Address.AddressID,  
  SBAreaCommercial,KhataNo,BuldingPlanApprovalNo,KPSBNoc,SEACNOC,LicenceNo,CertificationNo,  
  mst_Address.CityID,mst_City.CityName as CityName, p3.Term 'PurchaseOption', p4.Term 'PaymentTerm', p5.Term 'PropertyStatus',
  (Select COUNT(*) From mst_Wing Where mst_Wing.PropertyID = mst_Property.PropertyID and mst_Wing.IsActive = 1) AS WingCount,  
  (Select COUNT(*) From mst_RoomType Where mst_RoomType.PropertyID = mst_Property.PropertyID and mst_RoomType.IsActive = 1) AS UnitTypesCount,  
  (Select COUNT(*) From mst_Room Where mst_Room.PropertyID = mst_Property.PropertyID and mst_Room.IsActive = 1) AS UnitsCount,  
  (Select COUNT(*) From mst_Floor Where mst_Floor.PropertyID = mst_Property.PropertyID and mst_Floor.IsActive = 1) AS FloorCount  
    
 FROM [dbo].[mst_Property]  
   
 left join mst_ProjectTerm p1 on p1.TermID = mst_Property.PropertyTypeID  
 left join mst_Address on mst_Address.AddressID  = mst_Property.AddressID  
 left join mst_ProjectTerm p2 on p2.TermID = mst_Property.PropertyTypeID  
 left join mst_Country on mst_Country.CountryID = mst_Address.CountryID  
 left join mst_State on mst_State.StateID = mst_Address.StateID  
 left join mst_City on mst_City.CityID = mst_Address.CityID
 left join mst_ProjectTerm p3 on p3.TermID = mst_Property.PurchaseOptionID  
 left join mst_ProjectTerm p4 on p4.TermID = mst_Property.PaymentTermID   
 left join mst_ProjectTerm p5 on p5.TermID = mst_Property.PropertyStatusID   
 
 WHERE   
 ISNULL(mst_Property.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_Property.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
 ISNULL(mst_Property.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyID, ISNULL(mst_Property.PropertyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
 ISNULL(PropertyTypeID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@PropertyType, ISNULL(PropertyTypeID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and    
 ISNULL(PropertyName,'-aa#$$')  like '%'+ ISNULL(@PropertyName, ISNULL(PropertyName,'-aa#$$'))+'%' and   
 ISNULL(mst_City.CityName,'-aa#$$') Like ISNULL(@Location, ISNULL(mst_City.CityName,'-aa#$$')) + '%' and   
 ISNULL(mst_Property.IsActive,1) = 1 and  
 ISNULL(mst_Address.IsActive,1) = 1  
 
END