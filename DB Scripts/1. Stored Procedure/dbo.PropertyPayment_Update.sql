DROP PROCEDURE IF EXISTS dbo.PropertyPayment_Update

GO

CREATE PROCEDURE dbo.PropertyPayment_Update
(
	@PropertyPaymentID UNIQUEIDENTIFIER = NULL ,
	@PropertyID UNIQUEIDENTIFIER = NULL ,
	@PropertyScheduleID UNIQUEIDENTIFIER = NULL ,
	@AmountPaid DECIMAL(18,2) = NULL ,	
	@MOPTerm VARCHAR(37) =  NULL ,
	@DateOfTransaction DATETIME = NULL ,
	@BankName VARCHAR(161) =  NULL ,
	@ChequeNo VARCHAR(11) =  NULL ,
	@ChequeTo VARCHAR(161) NULL ,
	@OrderNo INT = NULL,
	@UserID CHAR(38) = NULL ,
	@Description VARCHAR(3710) = NULL 
)
AS
BEGIN
UPDATE tra_propertypayment
SET
	[PropertyID] = @PropertyID,
	[PropertyScheduleID] = @PropertyScheduleID,
	[AmountPaid] = @AmountPaid,
	[MOPTerm] = @MOPTerm,
	[DateOfTransaction] = @DateOfTransaction,
	[BankName] = @BankName,		
	[ChequeNo] = @ChequeNo,
	[ChequeTo] = @ChequeTo,
	[UserID] = @UserID,
	[Description] = @Description
 WHERE 
	[PropertyPaymentID] = @PropertyPaymentID
END