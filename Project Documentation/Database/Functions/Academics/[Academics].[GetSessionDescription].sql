USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [Academics].[GetSessionDescription]    Script Date: 08/14/2011 11:57:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [Academics].[GetSessionDescription](@CurrentYear int,@NextYear int) RETURNS NVARCHAR(50)
AS
BEGIN
		RETURN ISNULL((CONVERT(NVARCHAR(5), @CurrentYear)+'/'+CONVERT(NVARCHAR(5), @NextYear)),'N/A')
END