/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[FirstChoice]
      ,[SecondChoice]
      ,[AccountCode]
      ,[ScreenCode]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
  FROM [UniversityDB].[Personals].[Choices]