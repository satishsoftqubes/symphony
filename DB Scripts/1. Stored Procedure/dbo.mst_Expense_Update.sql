USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Expense_Update]    Script Date: 9/1/2022 6:36:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Expense_Update](
@ExpenseID uniqueidentifier,
@PropertyID uniqueidentifier,
@DateOfExpense VARCHAR(38),
@AssociationTypeTerm varchar(61),
@ExpenseTypeTerm varchar(361),
@ExpenseAmount Decimal(18,2),
@ModeOfPaymentTerm varchar(39),
@ExpenseDetail varchar(361)
)
AS
BEGIN
UPDATE tra_propertyexpenses SET
                           PropertyID = @PropertyID,
						   DateOfExpense = @DateOfExpense,
						   AssociationTypeTerm = @AssociationTypeTerm,
						   ExpenseTypeTerm = @ExpenseTypeTerm,
						   ExpenseAmount = @ExpenseAmount,
						   ModeOfPaymentTerm = @ModeOfPaymentTerm,
						   ExpenseDetail = @ExpenseDetail,
						   UpdateLog = CURRENT_TIMESTAMP,
						   CreatedOn = GETDATE()
						   WHERE ExpenseID  = @ExpenseID
END