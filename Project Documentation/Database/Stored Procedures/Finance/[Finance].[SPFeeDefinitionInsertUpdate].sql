USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPFeeDefinitionInsertUpdate]    Script Date: 08/14/2011 13:39:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.FeeDefinition Table

ALTER PROC [Finance].[SPFeeDefinitionInsertUpdate]
(
	@Code NVARCHAR(50)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@Description NVARCHAR(256)=NULL,
	@FeeStatusCode NVARCHAR(50)=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [Finance].[FeeDefinition] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode))
			BEGIN
				INSERT INTO [Finance].[FeeDefinition]
				(
					[Code],
					[UniversityCode],
					[Description],
					[FeeStatusCode] 
					
				)
				VALUES
				(
					@Code,
					@UniversityCode,
					@Description,
					@FeeStatusCode 
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance].[FeeDefinition]
				SET
					
					[UniversityCode]=@UniversityCode,
					[Description]=@Description,
					[FeeStatusCode] =@FeeStatusCode 
					
				WHERE
					(([Code] = @Code) AND ([UniversityCode] = @UniversityCode))
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

GRANT EXECUTE ON [Finance].[SPFeeDefinitionInsertUpdate] TO PUBLIC