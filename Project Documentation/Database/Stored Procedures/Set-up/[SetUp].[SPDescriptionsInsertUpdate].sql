USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPDescriptionsInsertUpdate]    Script Date: 08/14/2011 14:21:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Descriptions Table

ALTER PROC [SetUp].[SPDescriptionsInsertUpdate]
(
	@ID INT=NULL,
	@Code Nvarchar(50)=NULL,
	@ParametersCode NVARCHAR(50)=NULL,
	@Name NVARCHAR(500)=NULL,
	@Notes NVARCHAR(1000)=NULL
		
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[Descriptions]  WHERE (([Code] = @Code) AND ([ParametersCode] = @ParametersCode)))
			BEGIN
				INSERT INTO [SetUp].[Descriptions] 
				(
					[ParametersCode],
					[Name],
					[Notes]
					
				)
				VALUES
				(
					@ParametersCode,
					@Name,
					@Notes
					
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Descriptions] 
				SET
					[Name]=@Name,
					[Notes]=@Notes
					
				WHERE
					(([Code] = @Code) AND ([ParametersCode] = @ParametersCode))
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

GRANT EXECUTE ON [SetUp].[SPDescriptionsInsertUpdate] TO PUBLIC