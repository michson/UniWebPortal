USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Assessment].[SPRecordsInsertUpdate]    Script Date: 08/14/2011 12:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Assessment.Records Table

ALTER PROC [Assessment].[SPRecordsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@AssessmentTypeCode NVARCHAR(50)=NULL,
	@SubCourseCode NVARCHAR(50)=NULL,
	@StaffCode NVARCHAR(50)=NULL,
	@Score DECIMAL(18,2)=NULL,
	@GradeDescription NVARCHAR(50)=NULL,
	@GP DECIMAL(18,0)=NULL,
	@Position BIGINT=NULL,
	@StudentCode BIGINT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@Remark NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Assessment].[Records] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Assessment].[Records] 
				(
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[SessionCode],
					[SemesterCode],
					[LevelCode],
					[AssessmentTypeCode],
					[SubCourseCode],
					[StaffCode],
					[Score],
					[GradeDescription],
					[GP],
					[Position],
					[StudentCode],
					[MatricNo],
					[Remark],
					[ScreenCode],
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
					@SessionCode,
					@SemesterCode,
					@LevelCode,
					@AssessmentTypeCode,
					@SubCourseCode,
					@StaffCode,
					@Score,
					@GradeDescription,
					@GP,
					@Position,
					@StudentCode,
					@MatricNo,
					@Remark,
					@ScreenCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Assessment].[Records] 
				SET
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[LevelCode]=@LevelCode,
					[AssessmentTypeCode]=@AssessmentTypeCode,
					[SubCourseCode]=@SubCourseCode,
					[StaffCode]=@StaffCode,
					[Score]=@Score,
					[GradeDescription]=@GradeDescription,
					[GP]=@GP,
					[Position]=@Position,
					[StudentCode]=@StudentCode,
					[MatricNo]=@MatricNo,
					[Remark]=@Remark,
					[ScreenCode]=@ScreenCode,
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

GRANT EXECUTE ON [Assessment].[SPRecordsInsertUpdate] TO PUBLIC