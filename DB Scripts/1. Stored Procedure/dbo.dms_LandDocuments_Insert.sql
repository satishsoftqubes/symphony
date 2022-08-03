DROP PROCEDURE IF EXISTS dbo.dms_LandDocuments_Insert

GO

CREATE PROCEDURE [dbo].[dms_LandDocuments_Insert]
(
	@DocumentID uniqueidentifier ,
	@CategoryID uniqueidentifier = null ,
	@TypeID uniqueidentifier = null ,
	@StatusTermID uniqueidentifier = null ,
	@DocumentName nvarchar(MAX) = null ,
	@Notes nvarchar(MAX) = null ,
	@DocumentPath nvarchar(MAX) = null ,
	@Extension nvarchar(6) = null ,
	@DateOfSubmission datetime = null ,
	@AssociationID uniqueidentifier = null ,
	@AssociationType nvarchar(65) = null ,
	@CreatedOn datetime = null ,
	@UpdatedOn datetime = null ,
	@CreatedBy uniqueidentifier = null ,
	@UpdatedBy uniqueidentifier = null ,
	@IsActive bit = null ,
	@IsSynch bit = null ,
	@SynchOn datetime = null ,
	@SeqNo int output,
	@PropertyID uniqueidentifier = null ,
	@CompanyID uniqueidentifier = null 

)
AS
BEGIN
INSERT [dbo].[dms_Documents]
(
	[DocumentID],
	[CategoryID],
	[TypeID],
	[StatusTermID],
	[DocumentName],
	[Notes],
	[DocumentPath],
	[Extension],
	[DateOfSubmission],
	[AssociationID],
	[AssociationType],
	[CreatedOn],
	[UpdatedOn],
	[CreatedBy],
	[UpdatedBy],
	[IsActive],
	[IsSynch],
	[SynchOn],
	[PropertyID],
	[CompanyID]

)
VALUES
(
	@DocumentID,
	@CategoryID,
	@TypeID,
	@StatusTermID,
	@DocumentName,
	@Notes,
	@DocumentPath,
	@Extension,
	@DateOfSubmission,
	@AssociationID,
	@AssociationType,
	@CreatedOn,
	@UpdatedOn,
	@CreatedBy,
	@UpdatedBy,
	@IsActive,
	@IsSynch,
	@SynchOn,
	@PropertyID,
	@CompanyID

)
	SELECT @SeqNo=SCOPE_IDENTITY();

END
