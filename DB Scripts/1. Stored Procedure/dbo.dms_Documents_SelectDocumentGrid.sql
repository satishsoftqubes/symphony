DROP PROCEDURE IF EXISTS dbo.dms_Documents_SelectDocumentGrid

GO

CREATE PROCEDURE dbo.dms_Documents_SelectDocumentGrid
(  
 @DocumentID uniqueidentifier = null,  
 @CategoryID uniqueidentifier = null,  
 @CompanyID uniqueidentifier = null,  
 @Category nvarchar(50) = null,  
 @AssociationID uniqueidentifier = null  
)  
AS  
BEGIN  
  
if(@Category = 'COMPANY DOCUMENT')  
begin   
select mst_ProjectTerm.TermID,mst_ProjectTerm.Term,mst_ProjectTerm.DisplayTerm,dms_Documents.DocumentID,dms_Documents.DocumentName,dms_Documents.TypeID,dms_Documents.Extension,mst_Company.TanNo,mst_Company.TinNo,mst_Company.ServiceTaxNo,mst_Company.InCorporatonNo,mst_Company.PanNo,dms_Documents.Notes  
from mst_ProjectTerm  
left outer join dms_Documents on dms_Documents.TypeID = mst_ProjectTerm.TermID and dms_Documents.AssociationID = @AssociationID  
left outer join mst_Company on mst_Company.CompanyID = dms_Documents.AssociationID  
  
where mst_ProjectTerm.Category = @Category And  
mst_ProjectTerm.IsActive = 1 and  
ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CategoryID, ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
--ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@AssociationID, ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@DocumentID, ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627'))  
order by mst_ProjectTerm.SeqNo  
end  
  
else if(@Category = 'PROPERTY DOCUMENT')  
begin  
select mst_ProjectTerm.TermID,mst_ProjectTerm.Term,mst_ProjectTerm.DisplayTerm,dms_Documents.DocumentID,dms_Documents.DocumentName,dms_Documents.TypeID,dms_Documents.Extension,dms_Documents.Notes  
from mst_ProjectTerm  
left outer join dms_Documents on dms_Documents.TypeID = mst_ProjectTerm.TermID and dms_Documents.AssociationID = @AssociationID  
left outer join mst_Property on mst_Property.PropertyID = dms_Documents.AssociationID  
  
where mst_ProjectTerm.Category = @Category And  
mst_ProjectTerm.IsActive = 1 and  
ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CategoryID, ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
--ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@AssociationID, ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@DocumentID, ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627'))  
order by mst_ProjectTerm.SeqNo  
end  

else if(@Category = 'LANDISSUE')  
begin  
select mst_ProjectTerm.TermID,mst_ProjectTerm.Term,mst_ProjectTerm.DisplayTerm,dms_Documents.DocumentID,dms_Documents.DocumentName,dms_Documents.TypeID,dms_Documents.Extension,dms_Documents.Notes  
from mst_ProjectTerm  
left outer join dms_Documents on dms_Documents.TypeID = mst_ProjectTerm.TermID and dms_Documents.AssociationID = @AssociationID  
left outer join mst_Property on mst_Property.PropertyID = dms_Documents.AssociationID  
  
where mst_ProjectTerm.Category = @Category And  
mst_ProjectTerm.IsActive = 1 and  
ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CategoryID, ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
--ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@AssociationID, ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@DocumentID, ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627'))  
order by mst_ProjectTerm.SeqNo  
end  

else if(@Category = 'PROPERTYINSTALLMENTS')  
begin  
select mst_ProjectTerm.TermID,mst_ProjectTerm.Term,mst_ProjectTerm.DisplayTerm,dms_Documents.DocumentID,dms_Documents.DocumentName,dms_Documents.TypeID,dms_Documents.Extension,dms_Documents.Notes  
from mst_ProjectTerm  
left outer join dms_Documents on dms_Documents.TypeID = mst_ProjectTerm.TermID and dms_Documents.AssociationID = @AssociationID  
left outer join mst_Property on mst_Property.PropertyID = dms_Documents.AssociationID  
  
where mst_ProjectTerm.Category = @Category And  
mst_ProjectTerm.IsActive = 1 and  
ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CategoryID, ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@DocumentID, ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627'))  
order by mst_ProjectTerm.SeqNo  
end  
  
else if (@Category = 'INVESTOR UNIT DOCUMENT')  
begin  
  
select mst_ProjectTerm.TermID,mst_ProjectTerm.Term,mst_ProjectTerm.DisplayTerm,dms_Documents.DocumentID,dms_Documents.DocumentName,dms_Documents.TypeID,dms_Documents.Extension,dms_Documents.Notes,dms_Documents.DateOfSubmission  
from mst_ProjectTerm  
left outer join dms_Documents on dms_Documents.TypeID = mst_ProjectTerm.TermID and dms_Documents.AssociationID = @AssociationID  
left outer join irm_InvestorsUnit on irm_InvestorsUnit.InvestorRoomID = dms_Documents.AssociationID  
  
where mst_ProjectTerm.Category = @Category And  
mst_ProjectTerm.IsActive = 1 and  
ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CompanyID, ISNULL(mst_ProjectTerm.CompanyID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and   
ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@CategoryID, ISNULL(CategoryID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
--ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@AssociationID, ISNULL(AssociationID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627')) and  
ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627') = ISNULL(@DocumentID, ISNULL(DocumentID,'DBC06FD8-60D9-4008-BE1B-D24976EF7627'))  
order by mst_ProjectTerm.SeqNo  
end  
  
END  