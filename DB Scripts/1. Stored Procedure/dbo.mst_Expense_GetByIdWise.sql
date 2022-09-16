DROP PROCEDURE mst_Expense_GetByIdWise
CREATE PROCEDURE [dbo].[mst_Expense_GetByIdWise](
@ExpenseID uniqueidentifier
)

AS
BEGIN
SELECT ExpenseID,PropertyID as TermID,DateOfExpense,AssociationTypeTerm,ExpenseTypeTerm,ExpenseAmount,ModeOfPaymentTerm,ExpenseDetail
FROM tra_propertyexpenses WHERE ExpenseID = @ExpenseID AND IsActive = 1;

SELECT pd.PropertyExpenseDetailID,pd.PropertyID as TermID,
       pd.VendorID ,pd.PurchaseNote,pd.TotalAmount,pd.PurchaseTypeTerm,pd.ItemTypeTerm,pd.ExpenseID,
       ds.DocumentID,ds.DocumentName
FROM tra_propertyexpensesdetail pd LEFT JOIN dms_Documents ds ON ds.AssociationID = pd.PropertyExpenseDetailID
WHERE pd.ExpenseID = @ExpenseID AND pd.IsActive = 1;

select sum(TotalAmount) as TotalAmount from tra_propertyexpensesdetail where ExpenseID = @ExpenseID;
END

