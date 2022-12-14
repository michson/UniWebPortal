USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [Academics].[GetTotalDays]    Script Date: 08/14/2011 11:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [Academics].[GetTotalDays](@StartDate DateTime2(7),@EndDate DateTime2(7)) RETURNS INT
AS
BEGIN
		DECLARE @Diff INT=NULL
		SET @Diff=(SELECT DATEDIFF(dd,@StartDate,@EndDate) FROM [Academics].[Semesters])
		RETURN ISNULL(@Diff,0)
END