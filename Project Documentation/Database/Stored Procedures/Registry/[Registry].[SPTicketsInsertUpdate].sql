USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Registry].[SPTicketsInsertUpdate]    Script Date: 08/14/2011 14:17:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Registry.Tickets Table

ALTER PROC [Registry].[SPTicketsInsertUpdate]
(
	@Code NUMERIC(18,0)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@PinCode NUMERIC(18,0)=NULL,
	@DateX DATETIME2(7)=NULL,
	@StatusCode NVARCHAR(50)=NULL,
	@NoOfUse INT=NULL,
	@MaxNoUse INT=NULL,
	@ExpiryDate DATETIME2(7)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Registry].[Tickets] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode) AND ([PinCode] = @PinCode) AND ([Deleted]=@Deleted))
			BEGIN
				INSERT INTO [Registry].[Tickets]
				(
					[UniversityCode],
					[ScreenCode],
					[SessionCode],
					[SemesterCode],
					[PinCode],
					[DateX],
					[StatusCode],
					[NoOfUse],
					[MaxNoUse],
					[ExpiryDate],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@UniversityCode,
					@ScreenCode,
					@SessionCode,
					@SemesterCode,
					@PinCode,
					@DateX,
					@StatusCode,
					@NoOfUse,
					@MaxNoUse,
					@ExpiryDate,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Registry].[Tickets]
				SET
					[UniversityCode]=@UniversityCode,
					[ScreenCode]=@ScreenCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[PinCode]=@PinCode,
					[DateX]=@DateX,
					[StatusCode]=@StatusCode,
					[NoOfUse]=@NoOfUse,
					[MaxNoUse]=@MaxNoUse,
					[ExpiryDate]=@ExpiryDate,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					(([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([PinCode] = @PinCode))
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

GRANT EXECUTE ON [Registry].[SPTicketsInsertUpdate] TO PUBLIC