DROP PROCEDURE IF EXISTS dbo.PropertyPayment_CheckDuplication

GO

CREATE PROCEDURE dbo.PropertyPayment_CheckDuplication
(  
	@PropertyID UNIQUEIDENTIFIER = null,
	@PropertyScheduleID UNIQUEIDENTIFIER = null	
)  
AS  
BEGIN  

	SELECT COUNT(PropertyPaymentID) AS PropertyPaymentCount FROM tra_propertypayment WHERE PropertyID = @PropertyID
	AND PropertyScheduleID = @PropertyScheduleID

END