/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[ModuleCode]
      ,[ScreenCode]
      ,[ImageTypeCode]
      ,[AccountCode]
      ,[ByteThumb]
      ,[BytePoster]
      ,[ByteFull]
      ,[ByteOriginal]
      ,[Notes]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
  FROM [UniversityDB].[Personals].[Photos]