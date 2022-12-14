/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Code]
      ,[AddressTypeCode]
      ,[AccountCode]
      ,[Description]
      ,[ScreenCode]
      ,[CountryCode]
      ,[StateCode]
      ,[LgCode]
      ,[CreatedOn]
      ,[CreatedBy]
      ,[ModifiedOn]
      ,[ModifiedBy]
      ,[Deleted]
      ,[DeletedOn]
      ,[DeletedBy]
  FROM [UniversityDB].[Personals].[Addresses]