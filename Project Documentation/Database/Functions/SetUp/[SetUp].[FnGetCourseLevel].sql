USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [SetUp].[FnGetCourseLevel]    Script Date: 08/13/2011 18:11:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [SetUp].[FnGetCourseLevel](@Code BIGINT) RETURNS NVARCHAR(256)
AS
BEGIN
	DECLARE @Description NVARCHAR(256)
	SET @Description= (SELECT Convert(NVARCHAR(4),[Code])+' '+'(Course Numbers :'+Convert(NVARCHAR(4),NumberingLowerBound)+'-'+ Convert(NVARCHAR(4),NumberingUpperBound)+')' FROM [SetUp].[CourseNumbering] WHERE ([Code]=@Code))
	RETURN @Description
END