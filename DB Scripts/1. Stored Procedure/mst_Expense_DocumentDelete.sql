CREATE PROCEDURE[dbo].[mst_Expense_DocumentDelete](
@DocumentID uniqueidentifier
)
AS
BEGIN
Update dms_Documents SET IsActive = 0 WHERE AssociationID = @DocumentID;
Update tra_propertyexpensesdetail SET IsActive = 0 WHERE PropertyExpenseDetailID = @DocumentID;
END