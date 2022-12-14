USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [Academics].[GetSessionStatusDescription]    Script Date: 08/14/2011 11:57:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [Academics].[GetSessionStatusDescription](@Code NVARCHAR(50)) RETURNS NVARCHAR(50)
AS
BEGIN
		DECLARE @Name NVARCHAR(50)=NULL
		SET @Name=(SELECT [Name] FROM [SetUp].[Descriptions] WHERE ([Code]=@Code))
		RETURN ISNULL(@Name,'N/A')
END