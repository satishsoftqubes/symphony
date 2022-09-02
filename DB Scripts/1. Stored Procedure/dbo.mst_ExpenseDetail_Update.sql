USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_ExpenseDetail_Update]    Script Date: 9/1/2022 6:42:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_ExpenseDetail_Update](
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

  UPDATE tra_propertyexpensesdetail SET
		ExpenseID = @ExpenseID,
		PropertyID = @PropertyID,
		VendorID = @VendorID,
		PurchaseNote = @PurchaseNote,
		TotalAmount = @TotalAmount,
		PurchaseTypeTerm = @PurchaseTypeTerm,
		ItemTypeTerm = @ItemTypeTerm
		WHERE PropertyExpenseDetailID = @PropertyExpenseDetailID;

END