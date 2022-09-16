DROP PROCEDURE IF EXISTS dbo.mst_Vendor_Insert
GO
CREATE PROCEDURE [dbo].[mst_Vendor_Insert](
  @VendorID  uniqueidentifier,
  @CompanyID uniqueidentifier,
  @VendorName nvarchar(67) = null,
  @ContactName nvarchar(67) = null,
  -- @Email nvarchar(67) = null,
  @MobileNo nvarchar(13) = null,
  @VendorDetail nvarchar(MAX) = null,
  @CreatedBy uniqueidentifier,
  @TypeID uniqueidentifier
)
AS
BEGIN
     INSERT mst_vendor(
	   VendorID,
	   CompanyID,
	   VendorName,
	   ContactName,
	  -- Email,
	   MobileNo,
	   VendorDetail,
	   CreatedBy,
	   CreatedOn,
	   IsActive,
	   UpdateLog,
	   Status_Term,
	   TypeID
	 )
	 values(
	    @VendorID,
		@CompanyID,
		@VendorName,
		@ContactName,
		-- @Email,
		@MobileNo,
		@VendorDetail,
		@CreatedBy,
	    GETDATE(),
		'1',
		CURRENT_TIMESTAMP,
		'Active',
		@TypeID
	 )
END