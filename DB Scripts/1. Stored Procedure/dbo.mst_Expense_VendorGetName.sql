USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Expense_VendorGetName]    Script Date: 9/1/2022 6:32:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Expense_VendorGetName]
AS
BEGIN
    SELECT VendorID as 'TermID',VendorName as 'DisplayTerm'
    FROM mst_vendor 
    WHERE IsActive = 1;
END