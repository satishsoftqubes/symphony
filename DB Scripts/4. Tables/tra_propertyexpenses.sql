CREATE TABLE tra_propertyexpenses
(
	[ExpenseID]					CHAR(38)		NOT NULL PRIMARY KEY,	
	[PropertyID]				CHAR(38)		NULL DEFAULT NULL,
	[DateOfExpense]				DATETIME		NULL DEFAULT NULL,
	[ExpenseByAssociationID]	CHAR(38)		NULL DEFAULT NULL,
	[AssociationTypeTerm]		VARCHAR(61)		NULL DEFAULT NULL,
	[ExpenseTypeTerm]			VARCHAR(361)	NULL DEFAULT NULL,
	[ExpenseAmount]				DECIMAL(18,2)	NULL DEFAULT NULL,
	[ModeOfPaymentTerm]			VARCHAR(39)		NULL DEFAULT NULL,
	[ExpenseDetail]				VARCHAR(361)	NULL DEFAULT NULL,
	[UploadDocument]			VARCHAR(361)	NULL DEFAULT NULL,
	[PurchaseAssociationID]		CHAR(38)		NULL DEFAULT NULL,
	[IsSettled]					BIT				NULL DEFAULT NULL,
	[IsActive]					BIT				NULL DEFAULT NULL,
	[UpdateLog]					TIMESTAMP		NULL DEFAULT NULL,
	[CreatedOn]					DATETIME		NULL DEFAULT NULL,	
	[SeqNo]						INT				NULL DEFAULT NULL
)
GO