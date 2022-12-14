USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPParametersInsertUpdate]    Script Date: 08/14/2011 14:30:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Parameters Table

ALTER PROC [SetUp].[SPParametersInsertUpdate]
(
	@Code NVARCHAR(50)=NULL,
	@Description NVARCHAR(256)=NULL
		
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[Parameters]  WHERE ([Code] = @Code))  
			BEGIN
				INSERT INTO [SetUp].[Parameters] 
				(
					[Code],
					[Description]
					
					
				)
				VALUES
				(
					@Code,
					@Description
					
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Parameters] 
				SET
					[Description]=@Description
					
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

GRANT EXECUTE ON [SetUp].[SPParametersInsertUpdate] TO PUBLIC