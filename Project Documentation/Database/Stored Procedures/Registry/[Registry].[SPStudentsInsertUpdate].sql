USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Registry].[SPStudentsInsertUpdate]    Script Date: 08/14/2011 14:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Registry.Students Table

ALTER PROC [Registry].[SPStudentsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@EntryMode NVARCHAR(50)=NULL,
	@StudyMode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@AdmittedOn DATE=NULL,
	@AwardCode NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Registry].[Students] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode) AND ([MatricNo]=@MatricNo) AND ([Deleted]=@Deleted))
			BEGIN
				INSERT INTO [Registry].[Students]
				(
					[UniversityCode],
					[AccountCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[AwardCode],
					[LevelCode],
					[EntryMode],
					[StudyMode],
					[SessionCode],
					[AdmittedOn],
					[MatricNo],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@UniversityCode,
					@AccountCode,
					@FacultyCode,
					@DepartmentCode,
					@CourseCode,
					@ProgramCode,
					@AwardCode,
					@LevelCode,
					@EntryMode,
					@StudyMode,
					@SessionCode,
					@AdmittedOn,
					@MatricNo,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Registry].[Students]
				SET
					[UniversityCode]=@UniversityCode,
					[AccountCode]=@AccountCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[AwardCode]=@AwardCode,
					[LevelCode]=@LevelCode,
					[EntryMode]=@EntryMode,
					[StudyMode]=@StudyMode,
					[SessionCode]=@SessionCode,
					[AdmittedOn]=@AdmittedOn,
					[MatricNo]=@MatricNo,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					(([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([MatricNo] = @MatricNo))
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

GRANT EXECUTE ON [Registry].[SPStudentsInsertUpdate] TO PUBLIC