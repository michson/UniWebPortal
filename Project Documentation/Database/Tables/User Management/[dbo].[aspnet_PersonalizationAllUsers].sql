/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [PathId]
      ,[PageSettings]
      ,[LastUpdatedDate]
  FROM [UniversityDB].[dbo].[aspnet_PersonalizationAllUsers]