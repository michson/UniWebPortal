USE [UniversityDB]
GO
/****** Object:  UserDefinedFunction [SetUp].[FnGetDescriptionName]    Script Date: 08/14/2011 11:55:53 ******/
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

ALTER FUNCTION [SetUp].[FnGetDescriptionName](@Code NVARCHAR(50)) RETURNS NVARCHAR(256)
AS
BEGIN
		DECLARE @DescriptionName Nvarchar(256)
		SET @DescriptionName = (SELECT [Name] FROM [SetUp].[Descriptions] WHERE Code=@Code)
		RETURN @DescriptionName
END
