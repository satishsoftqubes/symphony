-- PROPERTY TYPE - Open Land
-- Added from infill setup

-- PURCHASEOPTION - Hector
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
	'1',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'5F037220-CD7B-4FB1-BCF5-2A9DD407D018',
	'Hector',
	'1'
)

-- PURCHASEOPTION - Var
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
	'2',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'07D92EE9-FCA2-4732-80C4-66FC05D80954',
	'Var',
	'1'
)

-- PAYMENTTERM - Monthly
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
	'1',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'5F84BF2E-3163-49B4-A035-24A445C71BC0',
	'Monthly',
	'1'
)

-- PAYMENTTERM - Yearly
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
	'2',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'C43F6695-CA13-432C-8C21-95A0437A542C',
	'Yearly',
	'1'
)

-- Land issue/modification
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
	'C78C8F86-C59F-4C02-8088-5DE1F9DA0EEC',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'LANDISSUE',
	'Land Issue/Modification',
	'LIM',
	NULL,
	NULL,
	NULL,
	'1',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'C78C8F86-C59F-4C02-8088-5DE1F9DA0EEC',
	'LANDISSUE',
	'1'
)

-- Expense Type
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
	'8556A3CF-5122-4596-BB71-C5AD80267E86',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'EXPENSETYPE',
	'Expense Type',
	'EXPT',
	NULL,
	NULL,
	NULL,
	'1',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'8556A3CF-5122-4596-BB71-C5AD80267E86',
	'EXPENSETYPE',
	'1'
)

-- Property Status
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
	'A681B36D-4AF3-4B59-882C-54AFF84270A9',
	'14F1A0DC-3A5B-4E7E-9869-96979A03EA3A',
	'PROPERTY STATUS',
	'Property Status',
	'PS',
	NULL,
	NULL,
	NULL,
	'1',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'A681B36D-4AF3-4B59-882C-54AFF84270A9',
	'PROPERTY STATUS',
	'1'
)


