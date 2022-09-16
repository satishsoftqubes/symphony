DROP PROCEDURE IF EXISTS dbo.PurchaseSchedule_SelectByPrimaryKey

GO

CREATE PROCEDURE dbo.PurchaseSchedule_SelectByPrimaryKey
(
	@PurchaseScheduleID uniqueidentifier
)
AS
BEGIN
	SELECT 
		[PurchaseScheduleID], [PropertyID], [InstallmentTypeTerm], [InstallmentAmount], [InstallmentInPercentage], 
		[StatusTerm], [MOPTerm], [ActualpaymentDate], [TotalPaid], [TotalDue], [Date], [TotalPaymentMonth], [Installment]
	FROM [dbo].[propertypurchase_schedule]
	WHERE 
			[PurchaseScheduleID] = @PurchaseScheduleID
END

