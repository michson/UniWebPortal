USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPAccountTypesInsertUpdate]    Script Date: 08/14/2011 13:38:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.AccountTypes Table

ALTER PROC [Finance].[SPAccountTypesInsertUpdate]
(
	@Code DECIMAL(18,0)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@Description NVARCHAR(256)=NULL,
	@DescriptionCode NVARCHAR(50)=NULL,
	@AccountSubCode NVARCHAR(50)=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [Finance].[AccountTypes] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode))
			BEGIN
				INSERT INTO [Finance].[AccountTypes]
				(
					[UniversityCode],
					[Description],
					[DescriptionCode] ,
					[AccountSubCode] 
					
				)
				VALUES
				(
					@UniversityCode,
					@Description,
					@DescriptionCode ,
					@AccountSubCode 
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance].[AccountTypes]
				SET
					[UniversityCode]=@UniversityCode,
					[Description]=@Description,
					[DescriptionCode] =@DescriptionCode ,
					[AccountSubCode] =@AccountSubCode 
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

GRANT EXECUTE ON [Finance].[SPAccountTypesInsertUpdate] TO PUBLIC