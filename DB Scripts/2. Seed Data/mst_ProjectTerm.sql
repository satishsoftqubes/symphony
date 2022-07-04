-- PAYMENTTERM
INSERT [dbo].[mst_ProjectTerm]
(
	[TermID],
	[CompanyID],
	[Category],
	[Term],
	[TermCode],
	[ForeColor],
	[BackColor],
	[Thumb],
	[SeqNo],
	[IsActive],
	[LastUpdatedOn],
	[LastUpdatedBy],
	[IsSynch],
	[PropertyID],
	[TermValue],
	[HardCodeTermID] ,
	[DisplayTerm] ,
	[IsDefault]
)
VALUES
(
	'5F84BF2E-3163-49B4-A035-24A445C71BC0',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTTERM',
	'Monthly',
	'MN',
	NULL,
	NULL,
	NULL,
	NULL,
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'5F84BF2E-3163-49B4-A035-24A445C71BC0',
	'Monthly',
	NULL
)

INSERT [dbo].[mst_ProjectTerm]
(
	[TermID],
	[CompanyID],
	[Category],
	[Term],
	[TermCode],
	[ForeColor],
	[BackColor],
	[Thumb],
	[SeqNo],
	[IsActive],
	[LastUpdatedOn],
	[LastUpdatedBy],
	[IsSynch],
	[PropertyID],
	[TermValue],
	[HardCodeTermID] ,
	[DisplayTerm] ,
	[IsDefault]
)
VALUES
(
	'C43F6695-CA13-432C-8C21-95A0437A542C',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTTERM',
	'Yearly',
	'YR',
	NULL,
	NULL,
	NULL,
	NULL,
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'C43F6695-CA13-432C-8C21-95A0437A542C',
	'Yearly',
	NULL
)

-- Purchase option - Hector
INSERT [dbo].[mst_ProjectTerm]
(
	[TermID],
	[CompanyID],
	[Category],
	[Term],
	[TermCode],
	[ForeColor],
	[BackColor],
	[Thumb],
	[SeqNo],
	[IsActive],
	[LastUpdatedOn],
	[LastUpdatedBy],
	[IsSynch],
	[PropertyID],
	[TermValue],
	[HardCodeTermID] ,
	[DisplayTerm] ,
	[IsDefault]
)
VALUES
(
	'5F037220-CD7B-4FB1-BCF5-2A9DD407D018',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PURCHASEOPTION',
	'Hector',
	'HCT',
	NULL,
	NULL,
	NULL,
	NULL,
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'5F037220-CD7B-4FB1-BCF5-2A9DD407D018',
	'Hector',
	NULL
)

-- Purchase option - Var
INSERT [dbo].[mst_ProjectTerm]
(
	[TermID],
	[CompanyID],
	[Category],
	[Term],
	[TermCode],
	[ForeColor],
	[BackColor],
	[Thumb],
	[SeqNo],
	[IsActive],
	[LastUpdatedOn],
	[LastUpdatedBy],
	[IsSynch],
	[PropertyID],
	[TermValue],
	[HardCodeTermID] ,
	[DisplayTerm] ,
	[IsDefault]
)
VALUES
(
	'07D92EE9-FCA2-4732-80C4-66FC05D80954',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PURCHASEOPTION',
	'Var',
	'VAR',
	NULL,
	NULL,
	NULL,
	NULL,
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'07D92EE9-FCA2-4732-80C4-66FC05D80954',
	'Var',
	NULL
)