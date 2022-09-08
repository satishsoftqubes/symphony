DROP PROCEDURE IF EXISTS dbo.purchaseSchedule_Insert

GO

CREATE PROCEDURE dbo.purchaseSchedule_Insert
(
	@PurchaseScheduleID uniqueidentifier,
	@PurchasePartnerScheduleID uniqueidentifier,
	@PropertyID uniqueidentifier = null,
	@PartnerID uniqueidentifier = null,
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

-- purchase schedule insert
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




-- Purchase partner insert
-- INSERT [dbo].[purchasepartner_schedule]
-- (
	-- [PurchasePartnerScheduleID], 
	-- [PropertyID] ,
	-- [PartnerID],
	-- [InstallmentTypeTerm] ,
	-- [InstallmentAmount] ,
	-- [InstallmentInPercentage] ,
	-- [StatusTerm] ,
	-- [MOPTerm] ,
	-- [ActualPaymentDate] ,
	-- [TotalPaid],
	-- [TotalDue] ,
	-- [IsActive] 
-- )
-- VALUES
-- (
	-- @PurchasePartnerScheduleID,
	-- @PropertyID,
	-- @PartnerID,
	-- @InstallmentTypeTerm,
	-- @InstallmentAmount,
	-- @InstallmentInPercentage,
	-- @StatusTerm,
	-- @MOPTerm,
	-- @ActualPaymentDate,
	-- @TotalPaid,
	-- @TotalDue,	
	-- 1
-- )

-- update TotalToInvest in mst_propertypartner
-- UPDATE mst_propertypartner
-- SET
	-- [TotalToInvest] = @TotalToInvest
	
 -- WHERE 
	-- [PropertyID] = @PropertyID AND
	-- [PartnerID] = @PartnerID AND 
	-- IsActive = 1

END