USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPPhotosInsertUpdate]    Script Date: 08/14/2011 14:00:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personal.Photos Table

ALTER PROC [Personals].[SPPhotosInsertUpdate]
(
	@Code INT=NULL,
	@ModuleCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@ImageTypeCode NVARCHAR(50)=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@ByteThumb VARBINARY(MAX)=NULL,
	@BytePoster VARBINARY(MAX)=NULL,
	@ByteFull VARBINARY(MAX)=NULL,
	@ByteOriginal VARBINARY(MAX)=NULL,
	@Notes NVARCHAR(256)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Personals].[Photos] WHERE (([Code] = @Code) AND ([AccountCode]=@AccountCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[Photos]
				(
					[ModuleCode],
					[ScreenCode],
					[ImageTypeCode],
					[AccountCode],
					[ByteThumb],
					[BytePoster],
					[ByteFull],
					[ByteOriginal],
					[Notes],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@ModuleCode,
					@ScreenCode,
					@ImageTypeCode,
					@AccountCode,
					@ByteThumb,
					@BytePoster,
					@ByteFull,
					@ByteOriginal,
					@Notes,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[Photos]
				SET
					[ModuleCode]=@ModuleCode,
					[ScreenCode]=@ScreenCode,
					[ImageTypeCode]=@ImageTypeCode,
					[AccountCode]=@AccountCode,
					[ByteThumb]=@ByteThumb,
					[BytePoster]=@BytePoster,
					[ByteFull]=@ByteFull,
					[ByteOriginal]=@ByteOriginal,
					[Notes]=@Notes,
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

GRANT EXECUTE ON [Personals].[SPPhotosInsertUpdate] TO PUBLIC