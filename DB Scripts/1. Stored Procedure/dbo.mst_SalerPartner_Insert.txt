DROP PROCEDURE IF EXISTS dbo.mst_SalerPartner_Insert
GO
CREATE PROCEDURE [dbo].[mst_SalerPartner_Insert]
(
  @PartnerID uniqueidentifier,
  @FirstName nvarchar(65) = null,
  @MiddleName nvarchar(65) = null,
  @LastName nvarchar(65) = null,
  --@DisplayName nvarchar(155) = null,
  @MobileNo nvarchar(13) = null,
  @Email nvarchar(50) = null,
  @Address nvarchar(MAX) = null,
  @TotalProperties int = null,
  @TotalInvestment DECIMAL(18,2) = 0,
  @CreatedBy uniqueidentifier
)
AS
BEGIN
	INSERT mst_partner
	(
	   PartnerID,
	   FirstName,
	   MiddleName,
	   LastName,
	   DisplayName,
	   MobileNo,
	   Email,
	   Address,
	   TotalProperties,
	   TotalInvestment,
	   CreatedBy,
	   CreatedOn,
	   IsActive,
	   UpdateLog
	)
	VALUES(
	  @PartnerID,
	  @FirstName,
	  @MiddleName,
	  @LastName,
	  CONCAT(@FirstName,@LastName),
	  @MobileNo,
	  @Email,
	  @Address,
	  @TotalProperties,
	  @TotalInvestment,
	  @CreatedBy,
	  GETDATE(),
	  1,
	  Current_Timestamp
	)
       
END
