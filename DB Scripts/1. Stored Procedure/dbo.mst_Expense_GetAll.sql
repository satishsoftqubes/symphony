USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Expense_GetAll]    Script Date: 9/1/2022 6:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Expense_GetAll](
@PropertyName varchar(61)
)
AS
BEGIN
SELECT mp.PropertyName,pt.Term as 'ModeOfPaymentTerm',pe.ExpenseAmount,pe.DateOfExpense,pe.ExpenseID
FROM tra_propertyexpenses pe 
LEFT JOIN mst_Property mp ON mp.PropertyID = pe.PropertyID 
LEFT JOIN mst_projectTerm pt ON pt.TermID = pe.ModeOfPaymentTerm
WHERE pe.IsActive = 1 
AND ISNULL(mp.PropertyName,'-aa#$$') = ISNULL(@PropertyName, ISNULL(mp.PropertyName,'-aa#$$'));
END