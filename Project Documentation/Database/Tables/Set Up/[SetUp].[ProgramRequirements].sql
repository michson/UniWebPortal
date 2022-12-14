/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[UniversityCode]
      ,[FacultyCode]
      ,[DepartmentCode]
      ,[CourseCode]
      ,[ProgramCode]
      ,[MinimumCredit]
      ,[MaximumCredit]
      ,[TotalDuration]
      ,[DurationUnit]
      ,[EntryMode]
      ,[ModeOfStudy]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
  FROM [UniversityDB].[SetUp].[ProgramRequirements]