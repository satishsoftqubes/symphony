DROP PROCEDURE IF EXISTS dbo.property_Installment_Insert

GO

CREATE PROCEDURE [dbo].[property_Installment_Insert]
(
	@PurchaseScheduleID UNIQUEIDENTIFIER,
	@PropertyID UNIQUEIDENTIFIER = null,
	@InstallmentTypeTerm VARCHAR(39) = null,
	@InstallmentAmount DECIMAL(18,2) = null,
	@InstallmentInPercentage DECIMAL(18,2) = null,
	@StatusTerm VARCHAR(29) = null,
	@MOPTerm VARCHAR(29) = null,
	@ActualPaymentDate DATETIME = null,
	@TotalPaid DECIMAL(18,2) = null,
	@TotalDue DECIMAL(18,2) = null,
	@IsActive BIT = null,
	@SeqNo INT = null
)
AS
BEGIN
INSERT [dbo].[propertypurchase_schedule]
(
	[PurchaseScheduleID],
	[PropertyID],
	[InstallmentTypeTerm],
	[InstallmentAmount],
	[InstallmentInPercentage],
	[StatusTerm],
	[MOPTerm],
	[ActualPaymentDate],
	[TotalPaid],
	[TotalDue],
	[IsActive],
	[SeqNo]
)
VALUES
(
	@PurchaseScheduleID,
	@PropertyID,
	@InstallmentTypeTerm
	@InstallmentAmount
	@InstallmentInPercentage
	@StatusTerm
	@MOPTerm
	@ActualPaymentDate
	@TotalPaid,
	@TotalDue,
	@IsActive,
	@SeqNo
)
	SELECT @SeqNo=SCOPE_IDENTITY();

END
