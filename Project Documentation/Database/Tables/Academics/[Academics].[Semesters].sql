/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[SemesterCode]
      ,[SessionCode]
      ,[StartDate]
      ,[EndDate]
      ,[RegistrationClosingDate]
      ,[SemesterStatus]
      ,[TotalDays]
      ,[Applicable]
      ,[UniversityCode]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
      ,[SemesterStatusDescription]
  FROM [UniversityDB].[Academics].[Semesters]