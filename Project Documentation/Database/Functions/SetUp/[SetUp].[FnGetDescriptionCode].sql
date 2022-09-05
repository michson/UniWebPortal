USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [SetUp].[FnGetDescriptionCode]    Script Date: 08/14/2011 11:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [SetUp].[FnGetDescriptionCode](@Code NVARCHAR(50),@Id INT) RETURNS NVARCHAR(50)
AS
BEGIN
		RETURN @Code+ '-'+ Convert(NVARCHAR(50),@Id)
END
