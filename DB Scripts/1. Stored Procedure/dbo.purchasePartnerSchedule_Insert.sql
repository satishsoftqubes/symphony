DROP PROCEDURE IF EXISTS dbo.purchasePartnerSchedule_Insert

GO

CREATE PROCEDURE dbo.purchasePartnerSchedule_Insert
(
	@PurchasePartnerScheduleID uniqueidentifier,
	@PropertyID uniqueidentifier = null,
	@PartnerID uniqueidentifier = null,
	@InstallmentTypeTerm VARCHAR(39) = null,
	@InstallmentAmount DECIMAL(18,2) = null,
	@InstallmentInPercentage DECIMAL(5,2) = null,
	@StatusTerm VARCHAR(29) = null,
	@MOPTerm VARCHAR(29) = null,
	@ActualPaymentDate DATETIME = null,
	@TotalToInvest DECIMAL(18,2) = null,
	@TotalPaid DECIMAL(18,2) = null,
	@TotalDue DECIMAL(18,2) = null	
)
AS
BEGIN

-- Purchase partner insert
INSERT [dbo].[purchasepartner_schedule]
(
	[PurchasePartnerScheduleID], 
	[PropertyID] ,
	[PartnerID],
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
	@PurchasePartnerScheduleID,
	@PropertyID,
	@PartnerID,
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

 -- update TotalToInvest in mst_propertypartner
 UPDATE mst_propertypartner
 SET
	[TotalToInvest] = @TotalToInvest
 WHERE 
 [PropertyID] = @PropertyID AND
 [PartnerID] = @PartnerID AND 
 IsActive = 1

END