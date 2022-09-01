DROP PROCEDURE IF EXISTS dbo.mst_SalerPartner_Update
GO
CREATE PROCEDURE [dbo].[mst_SalerPartner_Update](
@PartnerID uniqueidentifier,
@FirstName nvarchar(65) = null,
@LastName nvarchar(65) =  null,
@MiddleName nvarchar(65) = null,
@MobileNo nvarchar(13) = null,
@Email nvarchar(50) = null,
@Address nvarchar(MAX) = null,
@TotalProperties int = null,
@TotalInvestment DECIMAL(18,2) = 0,
@UpdatedBy uniqueidentifier
)
AS
BEGIN
UPDATE mst_partner Set 
                   FirstName = @FirstName,
				   LastName = @LastName,
				   MiddleName = @MiddleName,
				   DisplayName = CONCAT(@FirstName,@LastName),
				   MobileNo = @MobileNo,
				   Email = @Email,
				   Address = @Address,
				   TotalProperties = @TotalProperties,
				   TotalInvestment = @TotalInvestment,
				   UpdatedOn = GETDATE(),
				   UpdateLog = CURRENT_TIMESTAMP,
				   UpdatedBy = @UpdatedBy
				   WHERE PartnerID = @PartnerID;
END