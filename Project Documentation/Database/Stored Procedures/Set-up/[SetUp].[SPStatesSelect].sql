USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPStatesSelect]    Script Date: 08/14/2011 14:35:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for retrieving values from SetUp.States Table

ALTER PROC [SetUp].[SPStatesSelect]
(
	@Code NVARCHAR(50)=NULL,
	@CountriesCode NVARCHAR(50)=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF EXISTS (SELECT * FROM [SetUp].[States] WHERE ([Code] = @Code))
			BEGIN
			SELECT * FROM [SetUp].[States] 
			WHERE 
				(
				([Code] = @Code) AND 
				([CountriesCode]  = @CountriesCode)
				)	
			END
		ELSE
			BEGIN
			SELECT * FROM [SetUp].[States] 
			WHERE 
				(
				([CountriesCode]  = @CountriesCode)
				)	
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

GRANT EXECUTE ON [SetUp].[SPStatesSelect] TO PUBLIC