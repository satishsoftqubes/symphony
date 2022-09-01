CREATE TABLE dbo.tra_propertyexpensesdetail
(
	[PropertyExpenseDetailID]	uniqueidentifier		NOT NULL PRIMARY KEY,	
	[PropertyID]				uniqueidentifier		NULL DEFAULT NULL,
	[VendorName]				VARCHAR(161)	        NULL DEFAULT NULL,
	[VendorID]					uniqueidentifier		NULL DEFAULT NULL,
	[ReferenceNo]				VARCHAR(161)	NULL DEFAULT NULL,
	[PurchaseNote]				VARCHAR(161)	NULL DEFAULT NULL,
	[TotalAmount]				DECIMAL(18,2)	NULL DEFAULT NULL,
	[TotalPaid]					DECIMAL(18,2)	NULL DEFAULT NULL,
	[TotalDue]					DECIMAL(18,2)	NULL DEFAULT NULL,
	[BillAttached]				VARCHAR(361)	NULL DEFAULT NULL,
	[PurchaseTypeTerm]			VARCHAR(61)		NULL DEFAULT NULL,
	[ItemTypeTerm]				VARCHAR(61)		NULL DEFAULT NULL,
	[IsActive]					BIT				NULL DEFAULT NULL,
	[UpdateLog]					DATETIME		NULL DEFAULT NULL,	
	[SeqNo]						INT				IDENTITY(1,1),
	[ExpenseID]                 CHAR(38)        NULL DEFAULT NULL
)
GO