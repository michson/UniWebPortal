/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ApplicationId]
      ,[RoleId]
      ,[RoleName]
      ,[LoweredRoleName]
      ,[Description]
  FROM [UniversityDB].[dbo].[aspnet_Roles]