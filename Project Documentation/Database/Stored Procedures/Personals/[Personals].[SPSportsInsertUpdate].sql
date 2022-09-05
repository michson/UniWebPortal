USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPSportsInsertUpdate]    Script Date: 08/14/2011 14:03:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personals.Sports Table

ALTER PROC [Personals].[SPSportsInsertUpdate]
(
	@Code INT=NULL,
	@SportCode NVARCHAR(50)=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50) = NULL,
	@CreatedOn DATETIME2(7)=NULL,
	@CreatedBy NVARCHAR(50)=NULL,
	@ModifiedOn DATETIME2(7)=NULL,
	@ModifiedBy NVARCHAR(50)=NULL,
	@Deleted BIT=NULL,
	@DeletedOn DATETIME2(7)=NULL,
	@DeletedBy NVARCHAR(50)=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [Personals].[Sports] WHERE (([Code] = @Code) AND ([AccountCode]=@AccountCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[Sports]
				(
					[SportCode],
					[AccountCode],
					[ScreenCode],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@SportCode,
					@AccountCode,
					@ScreenCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[Sports]
				SET
					[SportCode]=@SportCode,
					[AccountCode]=@AccountCode,
					[ScreenCode]=@ScreenCode,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					(([Code] = @Code) AND ([AccountCode]=@AccountCode))
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

GRANT EXECUTE ON [Personals].[SPSportsInsertUpdate] TO PUBLIC