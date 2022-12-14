USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [SetUp].[FnGetProgramDescription]    Script Date: 08/14/2011 11:56:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Godwin Mathias
--Reviewer			:	Godwin Mathias	
--Date Created		:	04/28/2011 
--Last Updated		:	04/28/2011 
--Last Updated By	:	Godwin Mathias
--Description		:	Function for retrieving discounted amount from [SetUp].[Modules] Table

ALTER FUNCTION [SetUp].[FnGetProgramDescription](@Code BIGINT) RETURNS NVARCHAR(256)
AS
BEGIN
		DECLARE @Decription NVARCHAR(256)
		SET @Decription= (SELECT [ProgName]+' ('+[AwardInViewName]+')' FROM [SetUp].[Programs] WHERE ([Code]=@Code))
		RETURN (@Decription)
END
