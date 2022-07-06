-- PurchaseOptionID
ALTER TABLE mst_Property 
ADD PurchaseOptionID UNIQUEIDENTIFIER

-- SurveyNo
ALTER TABLE mst_Property 
ADD SurveyNo NVARCHAR(65)

-- PaymentTermID
ALTER TABLE mst_Property 
ADD PaymentTermID UNIQUEIDENTIFIER

-- Jantri
ALTER TABLE mst_Property 
ADD Jantri decimal(18,2)