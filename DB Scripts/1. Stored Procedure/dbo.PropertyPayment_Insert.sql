DROP PROCEDURE IF EXISTS dbo.PropertyPayment_Insert

GO

CREATE PROCEDURE dbo.PropertyPayment_Insert
(
	@PropertyPaymentID UNIQUEIDENTIFIER,
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

INSERT [dbo].[tra_propertypayment]
(
	[PropertyPaymentID],
	[PropertyID],
	[PropertyScheduleID],
	[AmountPaid],
	[MOPTerm],
	[DateOfTransaction],
	[BankName],
	[ChequeNo],
	[ChequeTo],	
	[UserID],
	[Description]
)
VALUES
(
	@PropertyPaymentID,
	@PropertyID,
	@PropertyScheduleID,
	@AmountPaid,
	@MOPTerm,
	@DateOfTransaction,
	@BankName,
	@ChequeNo,
	@ChequeTo,	
	@UserID,
	@Description
)

END