/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ApplicationId]
      ,[PathId]
      ,[Path]
      ,[LoweredPath]
  FROM [UniversityDB].[dbo].[aspnet_Paths]