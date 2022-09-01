DROP PROCEDURE IF EXISTS dbo.mst_Vendor_Insert
GO
USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Vendor_Insert]    Script Date: 8/30/2022 5:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Vendor_Insert](
  @VendorID  uniqueidentifier,
  @CompanyID uniqueidentifier,
  @VendorName nvarchar(67) = null,
  @ContactName nvarchar(67) = null,
  @Email nvarchar(67) = null,
  @MobileNo nvarchar(13) = null,
  @VendorDetail nvarchar(MAX) = null,
  @CreatedBy uniqueidentifier
)
AS
BEGIN
     INSERT mst_vendor(
	   VendorID,
	   CompanyID,
	   VendorName,
	   ContactName,
	   Email,
	   MobileNo,
	   VendorDetail,
	   CreatedBy,
	   CreatedOn,
	   IsActive,
	   UpdateLog,
	   Status_Term
	 )
	 values(
	    @VendorID,
		@CompanyID,
		@VendorName,
		@ContactName,
		@Email,
		@MobileNo,
		@VendorDetail,
		@CreatedBy,
	    GETDATE(),
		'1',
		CURRENT_TIMESTAMP,
		'Active'
	 )
END