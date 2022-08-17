CREATE TABLE propertypurchase_schedule
(
	[PurchaseScheduleID]		CHAR(38)			NOT NULL PRIMARY KEY,
	[PropertyID]				CHAR(38)			NULL DEFAULT NULL,
	[InstallmentTypeTerm]  		VARCHAR(39)			NULL DEFAULT NULL,	
	[InstallmentAmount] 		DECIMAL(18,2)		NULL DEFAULT NULL,	
	[InstallmentInPercentage] 	DECIMAL(5,2)		NULL DEFAULT NULL,	
	[StatusTerm]				VARCHAR(29)			NULL DEFAULT NULL,	
	[MOPTerm]					VARCHAR(29)			NULL DEFAULT NULL,	
	[ActualPaymentDate]			DATETIME			NULL DEFAULT NULL,	
	[TotalPaid]			 		DECIMAL(18,2)		NULL DEFAULT NULL,	
	[TotalDue]			 		DECIMAL(18,2)		NULL DEFAULT NULL,	
	[IsActive]			 		BIT					NULL DEFAULT NULL,	
	[SeqNo]						INT					NULL DEFAULT NULL,	
	[UpdateLog]					DATETIME			NULL DEFAULT NULL	
)
GO