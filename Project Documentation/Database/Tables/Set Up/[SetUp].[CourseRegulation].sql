/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[UniversityCode]
      ,[FacultyCode]
      ,[DepartmentCode]
      ,[CourseCode]
      ,[ProgramCode]
      ,[LevelCode]
      ,[SemesterCode]
      ,[CreditLowerBound]
      ,[CreditUpperBound]
      ,[ModeOfStudyCode]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
  FROM [UniversityDB].[SetUp].[CourseRegulation]