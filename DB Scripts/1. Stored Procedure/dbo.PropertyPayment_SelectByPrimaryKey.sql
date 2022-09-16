DROP PROCEDURE IF EXISTS dbo.PropertyPayment_SelectByPrimaryKey

GO

CREATE PROCEDURE dbo.PropertyPayment_SelectByPrimaryKey
(
	@PropertyPaymentID uniqueidentifier
)
AS
BEGIN
	SELECT 
		[PropertyPaymentID], [PropertyID], [PropertyScheduleID], [AmountPaid], [MOPTerm], 
		[DateOfTransaction], [BankName], [ChequeNo], [ChequeTo], [OrderNo], [UserID], [Description]
	FROM [dbo].[tra_propertypayment]
	WHERE 
			[PropertyPaymentID] = @PropertyPaymentID
END

