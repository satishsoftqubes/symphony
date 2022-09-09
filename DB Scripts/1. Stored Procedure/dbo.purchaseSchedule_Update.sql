DROP PROCEDURE IF EXISTS dbo.purchaseSchedule_Update

GO

CREATE PROCEDURE dbo.purchaseSchedule_Update
(
	@PurchaseScheduleID uniqueidentifier,
	@PropertyID uniqueidentifier,
	@InstallmentTypeTerm VARCHAR(39) = null,
	@InstallmentAmount DECIMAL(18,2) = null,
	@InstallmentInPercentage DECIMAL(5,2) = null,
	@StatusTerm VARCHAR(29) = null,
	@MOPTerm VARCHAR(29) = null	
)
AS
BEGIN
UPDATE propertypurchase_schedule
SET
	[PropertyID] = @PropertyID,
	[InstallmentTypeTerm] = @InstallmentTypeTerm,
	[InstallmentAmount] = @InstallmentAmount,
	[InstallmentInPercentage] = @InstallmentInPercentage,
	[StatusTerm] = @StatusTerm,
	[MOPTerm] = @MOPTerm,
	[UpdateLog] = CURRENT_TIMESTAMP
 WHERE 
	[PurchaseScheduleID] = @PurchaseScheduleID
END