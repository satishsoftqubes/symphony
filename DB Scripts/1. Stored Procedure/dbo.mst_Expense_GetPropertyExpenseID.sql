CREATE PROCEDURE [dbo].[mst_Expense_GetPropertyExpenseID](
@PropertyExpenseDetailID uniqueidentifier
)
AS
BEGIN
SELECT  ISNULL(PropertyExpenseDetailID,'00000000-0000-0000-0000-000000000000') as PropertyExpenseDetailID FROM tra_propertyexpensesdetail
        WHERE PropertyExpenseDetailID = @PropertyExpenseDetailID;
END
