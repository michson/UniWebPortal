USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPAccountSubInsertUpdate]    Script Date: 08/14/2011 13:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.AccountSub Table

ALTER PROC [Finance].[SPAccountSubInsertUpdate]
(
	@Code INT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@Description NVARCHAR(256)=NULL,
	@DescriptionCode NVARCHAR(50)=NULL,
	@ParameterCode NVARCHAR(50)=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [Finance].[AccountSub] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode))
			BEGIN
				INSERT INTO [Finance].[AccountSub]
				(
					[UniversityCode],
					[Description],
					[DescriptionCode] ,
					[ParameterCode]
					
				)
				VALUES
				(
					@UniversityCode,
					@Description,
					@DescriptionCode ,
					@ParameterCode 
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance].[AccountSub]
				SET
					[UniversityCode]=@UniversityCode,
					[Description]=@Description,
					[DescriptionCode] =@DescriptionCode ,
					[ParameterCode]=@ParameterCode 
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

GRANT EXECUTE ON [Finance].[SPAccountSubInsertUpdate] TO PUBLIC