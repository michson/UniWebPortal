/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[PathId]
      ,[UserId]
      ,[PageSettings]
      ,[LastUpdatedDate]
  FROM [UniversityDB].[dbo].[aspnet_PersonalizationPerUser]