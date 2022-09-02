USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Expense_GetByIdWise]    Script Date: 9/1/2022 6:40:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Expense_GetByIdWise](
@ExpenseID uniqueidentifier
)

AS
BEGIN
SELECT ExpenseID,PropertyID as TermID,DateOfExpense,AssociationTypeTerm,ExpenseTypeTerm,ExpenseAmount,ModeOfPaymentTerm,ExpenseDetail
FROM tra_propertyexpenses WHERE ExpenseID = @ExpenseID AND IsActive = 1;

SELECT pd.PropertyExpenseDetailID,pd.PropertyID as TermID,
       pd.VendorID ,pd.PurchaseNote,pd.TotalAmount,pd.PurchaseTypeTerm,pd.ItemTypeTerm,pd.ExpenseID,
       ds.TypeID,ds.DocumentID,ds.DocumentName
FROM tra_propertyexpensesdetail pd LEFT JOIN dms_Documents ds ON ds.TypeID = pd.ExpenseID
WHERE pd.ExpenseID = @ExpenseID AND pd.IsActive = 1;

select sum(TotalAmount) as TotalAmount from tra_propertyexpensesdetail where ExpenseID = @ExpenseID;
END
