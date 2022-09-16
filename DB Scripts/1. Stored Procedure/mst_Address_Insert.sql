DROP PROCEDURE dbo.mst_Address_Insert
USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Address_Insert]    Script Date: 9/9/2022 5:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Address_Insert]
(
	@AddressID uniqueidentifier ,
	@CompanyID uniqueidentifier = null ,
	@Add1 nvarchar(380) = null ,
	@Add2 nvarchar(380) = null ,
	@Add3 nvarchar(220) = null ,
	@CityID uniqueidentifier = null ,
	@ZipCode nvarchar(13) = null ,
	@StateID uniqueidentifier = null ,
	@CountryID uniqueidentifier = null ,
	@City nvarchar(78) = null ,
	@AddressTypeTermID uniqueidentifier = null ,
	@RetAddressID uniqueidentifier = null ,
	@IsActive bit = null ,
	@IsSynch bit = null ,
	@SynchOn datetime = null ,
	@SeqNo int = null,
	@Village nvarchar(78) = null

)
AS
BEGIN

INSERT [dbo].[mst_Address]
(
	[AddressID],
	[CompanyID],
	[Add1],
	[Add2],
	[Add3],
	[CityID],
	[ZipCode],
	[StateID],
	[CountryID],
	[City],
	[AddressTypeTermID],
	[RetAddressID],
	[IsActive],
	[IsSynch],
	[SynchOn],
	[Village]
)
VALUES
(
	@AddressID,
	@CompanyID,
	@Add1,
	@Add2,
	@Add3,
	@CityID,
	@ZipCode,
	@StateID,
	@CountryID,
	@City,
	@AddressTypeTermID,
	@RetAddressID,
	@IsActive,
	@IsSynch,
	@SynchOn,
	@Village

)

END

