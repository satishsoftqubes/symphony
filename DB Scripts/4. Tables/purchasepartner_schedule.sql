CREATE TABLE dbo.purchasepartner_schedule
(
	[PurchasePartnerScheduleID]		UNIQUEIDENTIFIER	NOT NULL PRIMARY KEY,
	[PropertyID]					UNIQUEIDENTIFIER	NULL DEFAULT NULL,
	[PartnerID]						UNIQUEIDENTIFIER	NULL DEFAULT NULL,
	[InstallmentTypeTerm]  			VARCHAR(39)			NULL DEFAULT NULL,	
	[InstallmentAmount] 			DECIMAL(18,2)		NULL DEFAULT NULL,	
	[InstallmentInPercentage] 		DECIMAL(5,2)		NULL DEFAULT NULL,	
	[StatusTerm]					VARCHAR(29)			NULL DEFAULT NULL,	
	[MOPTerm]						VARCHAR(29)			NULL DEFAULT NULL,	
	[ActualPaymentDate]				DATETIME			NULL DEFAULT NULL,	
	[TotalPaid]			 			DECIMAL(18,2)		NULL DEFAULT NULL,	
	[TotalDue]			 			DECIMAL(18,2)		NULL DEFAULT NULL,	
	[IsActive]			 			BIT					NULL DEFAULT NULL,	
	[SeqNo]							INT					IDENTITY(1,1) NOT NULL,
	[UpdateLog]						DATETIME			NULL DEFAULT NULL	
)
GO