DROP PROCEDURE IF EXISTS dbo.mst_SalerDelete_IdWise
GO
CREATE PROCEDURE [dbo].[mst_SalerDelete_IdWise](
@PartnerID uniqueidentifier
)
AS
BEGIN
UPDATE mst_partner set IsActive = 0 where PartnerID = @PartnerID;
END