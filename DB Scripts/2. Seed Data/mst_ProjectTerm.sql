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
	'0'
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
	'0'
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
	'0'
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
	'0'
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
	'0'
)

-- Expense Type -- Land document expense
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
	'Land document expense',
	'ETLDOC',
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
	'Land document expense',
	'0'
)

-- Expense Type -- Land development expense
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
	'48A75156-3022-4383-8DB2-091FF39E3DF2',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'EXPENSETYPE',
	'Land development expense',
	'ETLDEV',
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
	'48A75156-3022-4383-8DB2-091FF39E3DF2',
	'Land development expense',
	'0'
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
	'Open Land',
	'OPL',
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
	'Open Land',
	'0'
)

-- Property Installments
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
	'3BBB5E71-35E7-4078-9828-FEE71885A5EE',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PROPERTYINSTALLMENTS',
	'Property Installments',
	'PRPINS',
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
	'3BBB5E71-35E7-4078-9828-FEE71885A5EE',
	'PROPERTYINSTALLMENTS',
	'0'
)

-- Payment period -- Monthly
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
	'F01B26F3-724E-4AEB-AB25-7290287CF717',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTPERIOD',
	'Monthly',
	'PAYMON',
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
	'F01B26F3-724E-4AEB-AB25-7290287CF717',
	'Monthly',
	'0'
)

-- Payment period -- Bimonthly
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
	'F6F0415F-706E-4E1E-9FC5-431A012C1526',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTPERIOD',
	'Bimonthly',
	'PAYBMON',
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
	'F6F0415F-706E-4E1E-9FC5-431A012C1526',
	'Bimonthly',
	'0'
)

-- Payment period -- Three month
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
	'06610F7A-48AC-4556-A4D1-34F617F4E272',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTPERIOD',
	'Three Month',
	'PAYTMON',
	NULL,
	NULL,
	NULL,
	'3',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'06610F7A-48AC-4556-A4D1-34F617F4E272',
	'Three Month',
	'0'
)

-- Payment period -- Quaterly
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
	'5B78E892-10C5-467F-8235-1B375F68CFAB',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTPERIOD',
	'Quaterly',
	'PAYQMON',
	NULL,
	NULL,
	NULL,
	'4',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'5B78E892-10C5-467F-8235-1B375F68CFAB',
	'Quaterly',
	'0'
)

-- Payment period -- Sixmonthly
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
	'E4B846A9-D8D6-445C-8564-E3FE45DC464E',
	'14f1a0dc-3a5b-4e7e-9869-96979a03ea3a',
	'PAYMENTPERIOD',
	'Sixmonthly',
	'PAYSMON',
	NULL,
	NULL,
	NULL,
	'5',
	'1',
	GETUTCDATE(),
	NULL,
	NULL,
	NULL,
	NULL,
	'E4B846A9-D8D6-445C-8564-E3FE45DC464E',
	'Sixmonthly',
	'0'
)

