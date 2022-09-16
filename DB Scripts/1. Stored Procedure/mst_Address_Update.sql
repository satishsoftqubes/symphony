DROP PROCEDURE dbo.mst_Address_Update
USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Address_Update]    Script Date: 9/9/2022 6:12:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Address_Update]
(
	@AddressID uniqueidentifier,
	@CompanyID uniqueidentifier = null,
	@Add1 nvarchar(380) = null,
	@Add2 nvarchar(380) = null,
	@Add3 nvarchar(220) = null,
	@CityID uniqueidentifier = null,
	@ZipCode nvarchar(13) = null,
	@StateID uniqueidentifier = null,
	@CountryID uniqueidentifier = null,
	@City nvarchar(78) = null,
	@AddressTypeTermID uniqueidentifier = null,
	@RetAddressID uniqueidentifier = null,
	@IsActive bit = null,
	@UpdateLog timestamp = null,
	@IsSynch bit = null,
	@SynchOn datetime = null,
	@SeqNo int = null,
	@Village nvarchar(76) = null

)
AS
BEGIN
UPDATE [dbo].[mst_Address]
SET
	[AddressID] = @AddressID,
	[CompanyID] = @CompanyID,
	[Add1] = @Add1,
	[Add2] = @Add2,
	[Add3] = @Add3,
	[CityID] = @CityID,
	[ZipCode] = @ZipCode,
	[StateID] = @StateID,
	[CountryID] = @CountryID,
	[City] = @City,
	[AddressTypeTermID] = @AddressTypeTermID,
	[RetAddressID] = @RetAddressID,
	[IsActive] = @IsActive,
	[IsSynch] = @IsSynch,
	[SynchOn] = @SynchOn,
	[Village] = @Village
 WHERE 
	[AddressID] = @AddressID
END

