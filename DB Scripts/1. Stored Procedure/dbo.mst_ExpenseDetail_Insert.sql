USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_ExpenseDetail_Insert]    Script Date: 9/1/2022 6:37:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_ExpenseDetail_Insert](
@PropertyExpenseDetailID uniqueidentifier,
@PropertyID uniqueidentifier,
@VendorID uniqueidentifier,
@PurchaseNote varchar(161),
@TotalAmount Decimal(18,2),
@PurchaseTypeTerm varchar(61),
@ItemTypeTerm varchar(61),
@ExpenseID uniqueidentifier
)
AS
BEGIN
INSERT tra_propertyexpensesdetail(
                                 PropertyExpenseDetailID,
								 PropertyID,
								 VendorID,
								 PurchaseNote,
								 TotalAmount,
								 PurchaseTypeTerm,
								 ItemTypeTerm,
								 ExpenseID,
								 IsActive,
								 UpdateLog
                                 )
								 values(
								 @PropertyExpenseDetailID,
								 @PropertyID,
								 @VendorID,
								 @PurchaseNote,
								 @TotalAmount,
								 @PurchaseTypeTerm,
								 @ItemTypeTerm,
								 @ExpenseID,
								 '1',
								 CURRENT_TIMESTAMP
								 )
END