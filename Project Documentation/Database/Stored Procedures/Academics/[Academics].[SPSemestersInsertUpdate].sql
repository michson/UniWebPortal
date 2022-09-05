USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Academics].[SPSemestersInsertUpdate]    Script Date: 08/14/2011 12:00:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Academics.Semesters Table

ALTER PROC [Academics].[SPSemestersInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@StartDate DATETIME2(7)=NULL,
	@EndDate DATETIME2(7)=NULL,
	@RegistrationClosingDate DATETIME2(7)=NULL,
	@SemesterStatus NVARCHAR(50)=NULL,
	@Applicable BIT=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Academics].[Semesters] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Academics].[Semesters] 
				(
					[UniversityCode],
					[SessionCode],
					[SemesterCode],
					[StartDate],
					[EndDate],
					[RegistrationClosingDate],
					[SemesterStatus],
					[Applicable],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@SessionCode,
					@SemesterCode,
					@StartDate,
					@EndDate,
					@RegistrationClosingDate,
					@SemesterStatus,
					@Applicable,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Academics].[Semesters] 
				SET
					[UniversityCode]=@UniversityCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[StartDate]=@StartDate,
					[EndDate]=@EndDate,
					[RegistrationClosingDate]=@RegistrationClosingDate,
					[SemesterStatus]=@SemesterStatus,
					[Applicable]=@Applicable,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
					
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

GRANT EXECUTE ON [Academics].[SPSemestersInsertUpdate] TO PUBLIC