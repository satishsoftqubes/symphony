USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_Expense_PropertyGetName]    Script Date: 9/1/2022 6:31:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_Expense_PropertyGetName]
AS
BEGIN
SELECT PropertyID as 'TermID',PropertyName as 'DisplayTerm' FROM mst_Property Where IsActive = 1;
END