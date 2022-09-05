/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[UniversityCode]
      ,[FacultyCode]
      ,[DepartmentCode]
      ,[CourseCode]
      ,[AwardCode]
      ,[ProgCode]
      ,[Notes]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
      ,[ProgName]
      ,[AwardInViewName]
      ,[Description]
  FROM [UniversityDB].[SetUp].[Programs]