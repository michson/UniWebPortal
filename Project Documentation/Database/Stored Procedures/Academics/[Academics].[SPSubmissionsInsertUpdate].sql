USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Academics].[SPSubmissionsInsertUpdate]    Script Date: 08/14/2011 12:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Academics.Submissions Table

ALTER PROC [Academics].[SPSubmissionsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@StudentCode BIGINT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode BIGINT=NULL,
	@Submitted BIT=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@Accepted BIT=NULL,
	@AcceptedOn DATETIME2(7)=NULL,
	@AcceptedBy NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Academics].[Submissions] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Academics].[Submissions] 
				(
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[StudentCode],
					[MatricNo],
					[SessionCode],
					[SemesterCode],
					[Submitted],
					[ScreenCode],
					[Accepted],
					[AcceptedOn],
					[AcceptedBy],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@FacultyCode,
					@DepartmentCode,
					@CourseCode,
					@ProgramCode,
					@LevelCode,
					@StudentCode,
					@MatricNo,
					@SessionCode,
					@SemesterCode,
					@Submitted,
					@ScreenCode,
					@Accepted,
					@AcceptedOn,
					@AcceptedBy,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Academics].[Submissions] 
				SET
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[StudentCode]=@StudentCode,
					[MatricNo]=@MatricNo,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[Submitted]=@Submitted,
					[ScreenCode]=@ScreenCode,
					[Accepted]=@Accepted,
					[AcceptedOn]=@AcceptedOn,
					[AcceptedBy]=@AcceptedBy,
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

GRANT EXECUTE ON [Academics].[SPSubmissionsInsertUpdate] TO PUBLIC