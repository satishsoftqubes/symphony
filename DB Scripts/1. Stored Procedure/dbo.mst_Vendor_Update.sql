DROP PROCEDURE dbo.mst_Vendor_Update
GO

USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Vendor_Update]    Script Date: 8/30/2022 5:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[mst_Vendor_Update](
@VendorID uniqueidentifier,
@CompanyID uniqueidentifier,
@ContactName nvarchar(67) = null,
@VendorName nvarchar(67) = null,
@Email nvarchar(67) = null,
@MobileNo nvarchar(13) = null,
@VendorDetail nvarchar(MAX) = null,
@UpdatedBy uniqueidentifier
)
AS
BEGIN
   UPDATE mst_vendor SET
                     CompanyID = @CompanyID,
					 ContactName = @ContactName,
					 VendorName = @VendorName,
					 Email = @Email,
					 MobileNo = @MobileNo,
					 VendorDetail = @VendorDetail,
					 UpdatedBy = @UpdatedBy,
					 UpdatedOn = GetDate(),
					 UpdateLog = CURRENT_TIMESTAMP
					 WHERE VendorID = @VendorID

END