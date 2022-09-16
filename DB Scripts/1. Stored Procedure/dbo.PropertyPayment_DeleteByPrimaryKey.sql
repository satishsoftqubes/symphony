DROP PROCEDURE IF EXISTS dbo.PropertyPayment_DeleteByPrimaryKey

GO

CREATE PROCEDURE [dbo].[PropertyPayment_DeleteByPrimaryKey]
(
	@PropertyPaymentID uniqueidentifier
)
AS
BEGIN

-- Property payment
DELETE FROM [dbo].[tra_propertypayment]
 WHERE 
	[PropertyPaymentID] = @PropertyPaymentID 

END