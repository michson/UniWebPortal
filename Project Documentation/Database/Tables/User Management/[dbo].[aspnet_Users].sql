/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ApplicationId]
      ,[UserId]
      ,[UserName]
      ,[LoweredUserName]
      ,[MobileAlias]
      ,[IsAnonymous]
      ,[LastActivityDate]
  FROM [UniversityDB].[dbo].[aspnet_Users]