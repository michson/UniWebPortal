USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPGetUrl]    Script Date: 08/14/2011 14:28:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [SetUp].[SPGetUrl]
(
	@SearchWord nvarchar(50)
) 
AS
BEGIN
	DECLARE @SearchedWord NVARCHAR(256)=NULL
	SET @SearchedWord = (SELECT Url FROM [SetUp].[Universities] WHERE FREETEXT(Url, @SearchWord))
	select @SearchedWord
END