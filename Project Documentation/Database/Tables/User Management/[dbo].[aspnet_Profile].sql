/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [UserId]
      ,[PropertyNames]
      ,[PropertyValuesString]
      ,[PropertyValuesBinary]
      ,[LastUpdatedDate]
  FROM [UniversityDB].[dbo].[aspnet_Profile]