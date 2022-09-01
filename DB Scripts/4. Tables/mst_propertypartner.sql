CREATE TABLE dbo.mst_propertypartner
(
	[PropertyPartnerID]			uniqueidentifier		NOT NULL PRIMARY KEY,
	[PropertyID]				uniqueidentifier		NULL DEFAULT NULL,
	[PartnerID]					uniqueidentifier		NULL DEFAULT NULL,
	[AddedOn]					DATETIME		NULL DEFAULT NULL,
	[PartnershipInPercentage]	DECIMAL(5,2)	NULL DEFAULT NULL,
	[TotalToInvest]				DECIMAL(18,2)	NULL DEFAULT NULL,
	[TotalDue]					DECIMAL(18,2)	NULL DEFAULT NULL,
	[TotalInvested]				DECIMAL(18,2)	NULL DEFAULT NULL,
	[PartnershipDissolveOn]		DATETIME		NULL DEFAULT NULL,
	[StatusTerm]				VARCHAR(39)		NULL DEFAULT NULL,
	[SeqNo]						INT				IDENTITY(1,1),
	[IsActive]					BIT				NULL DEFAULT NULL,
	[PartnerLegalName]			VARCHAR(161)	NULL DEFAULT NULL,
	[Description]				VARCHAR(3710)	NULL DEFAULT NULL
)
GO