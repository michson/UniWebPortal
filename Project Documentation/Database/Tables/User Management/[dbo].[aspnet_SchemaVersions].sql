/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Feature]
      ,[CompatibleSchemaVersion]
      ,[IsCurrentVersion]
  FROM [UniversityDB].[dbo].[aspnet_SchemaVersions]