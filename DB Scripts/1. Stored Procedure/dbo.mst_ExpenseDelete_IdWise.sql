USE [symphony_sakariyagroup]
GO
/****** Object:  StoredProcedure [dbo].[mst_ExpenseDelete_IdWise]    Script Date: 9/1/2022 6:43:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[mst_ExpenseDelete_IdWise](
@ExpenseID uniqueidentifier
)
AS
BEGIN
UPDATE tra_propertyexpenses SET IsActive = 0 Where ExpenseID = @ExpenseID;
UPDATE tra_propertyexpensesdetail SET IsActive = 0 Where ExpenseID = @ExpenseID;
END