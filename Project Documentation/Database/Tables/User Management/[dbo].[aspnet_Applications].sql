/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ApplicationName]
      ,[LoweredApplicationName]
      ,[ApplicationId]
      ,[Description]
  FROM [UniversityDB].[dbo].[aspnet_Applications]