DROP PROCEDURE IF EXISTS dbo.purchaseSchedule_Insert

GO

CREATE PROCEDURE dbo.purchaseSchedule_Insert
(
	@PurchaseScheduleID uniqueidentifier,
	@PropertyID uniqueidentifier = null,
	@InstallmentTypeTerm VARCHAR(39) = null,
	@InstallmentAmount DECIMAL(18,2) = null,
	@InstallmentInPercentage DECIMAL(5,2) = null,
	@StatusTerm VARCHAR(29) = null,
	@MOPTerm VARCHAR(29) = null,
	@ActualPaymentDate DATETIME = null,
	@TotalPaid DECIMAL(18,2) = null,
	@TotalDue DECIMAL(18,2) = null	
)
AS
BEGIN

DELETE FROM propertypurchase_schedule WHERE PropertyID = @PropertyID

INSERT [dbo].[propertypurchase_schedule]
(
	[PurchaseScheduleID], 
	[PropertyID] ,
	[InstallmentTypeTerm] ,
	[InstallmentAmount] ,
	[InstallmentInPercentage] ,
	[StatusTerm] ,
	[MOPTerm] ,
	[ActualPaymentDate] ,
	[TotalPaid],
	[TotalDue] ,
	[IsActive] 
)
VALUES
(
	@PurchaseScheduleID,
	@PropertyID,
	@InstallmentTypeTerm,
	@InstallmentAmount,
	@InstallmentInPercentage,
	@StatusTerm,
	@MOPTerm,
	@ActualPaymentDate,
	@TotalPaid,
	@TotalDue,	
	1
)
END