/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[UniversityCode]
      ,[DesignationCode]
      ,[OrderCode]
      ,[SessionCode]
      ,[Applicable]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
  FROM [UniversityDB].[Academics].[SigningHierarchy]