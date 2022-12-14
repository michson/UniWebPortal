USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPStatesInsertUpdate]    Script Date: 08/14/2011 14:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.States Table

ALTER PROC [SetUp].[SPStatesInsertUpdate]
(
	@Code NVARCHAR(50)=NULL,
	@Name NVARCHAR(256)=NULL,
	@CountriesCode NVARCHAR(50)=NULL
	
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[States]  WHERE (([Code] = @Code) AND ([CountriesCode] = @CountriesCode)) )
			BEGIN
				INSERT INTO [SetUp].[States] 
				(
					[Code],
					[Name],
					[CountriesCode]
					
				)
				VALUES
				(
					@Code,
					@Name,
					@CountriesCode
					
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[States] 
				SET
					[Name]=@Name,
					[CountriesCode]=@CountriesCode
					
				WHERE
					([Code] = @Code)
			END
COMMIT TRAN
END TRY

BEGIN CATCH
ROLLBACK TRAN

DECLARE @ErrorNumber_INT INT;
DECLARE @ErrorSeverity_INT INT;
DECLARE @ErrorProcedure_VC VARCHAR(200);
DECLARE @ErrorLine_INT INT;
DECLARE @ErrorMessage_NVC NVARCHAR(4000);

SELECT
		@ErrorMessage_NVC = ERROR_MESSAGE(),
		@ErrorSeverity_INT = ERROR_SEVERITY(),
		@ErrorNumber_INT = ERROR_NUMBER(),
		@ErrorProcedure_VC = ERROR_PROCEDURE(),
		@ErrorLine_INT = ERROR_LINE()

RAISERROR(@ErrorMessage_NVC,@ErrorSeverity_INT,1);

END CATCH

GRANT EXECUTE ON [SetUp].[SPStatesInsertUpdate] TO PUBLIC