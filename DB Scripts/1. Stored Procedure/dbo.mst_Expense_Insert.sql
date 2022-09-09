USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Expense_Insert]    Script Date: 9/1/2022 6:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Expense_Insert](
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
INSERT tra_propertyexpenses 
                         (
						 ExpenseID,
						 PropertyID,
						 DateOfExpense,
						 AssociationTypeTerm,
						 ExpenseTypeTerm,
						 ExpenseAmount,
						 ModeOfPaymentTerm,
						 ExpenseDetail,
						 IsSettled,
						 IsActive,
						 UpdateLog,
						 CreatedOn
                         )
						 Values(
						 @ExpenseID,
						 @PropertyID,
						 @DateOfExpense,
						 @AssociationTypeTerm,
						 @ExpenseTypeTerm,
						 @ExpenseAmount,
						 @ModeOfPaymentTerm,
						 @ExpenseDetail,
						 '1',
						 '1',
						 CURRENT_TIMESTAMP,
						 GETDATE()
						 )
END