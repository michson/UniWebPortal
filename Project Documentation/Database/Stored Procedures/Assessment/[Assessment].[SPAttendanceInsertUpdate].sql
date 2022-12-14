USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Assessment].[SPAttendanceInsertUpdate]    Script Date: 08/14/2011 12:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Assessment.Attendance Table

ALTER PROC [Assessment].[SPAttendanceInsertUpdate]
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
	@AttendanceStatus NVARCHAR(50)=NULL,
	@StaffCode NVARCHAR(50)=NULL,
	@SubCourseCode BIGINT=NULL,
	@AttendanceType NVARCHAR(50)=NULL,
	@Remark NCHAR(10)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Assessment].[Attendance] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Assessment].[Attendance] 
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
					[AttendanceStatus],
					[StaffCode],
					[SubCourseCode],
					[AttendanceType],
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
					@LevelCode,
					@StudentCode,
					@MatricNo,
					@SessionCode,
					@SemesterCode,
					@AttendanceStatus,
					@StaffCode,
					@SubCourseCode,
					@AttendanceType,
					@Remark,
					@ScreenCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Assessment].[Attendance] 
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
					[AttendanceStatus]=@AttendanceStatus,
					[StaffCode]=@StaffCode,
					[SubCourseCode]=@SubCourseCode,
					[AttendanceType]=@AttendanceType,
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

GRANT EXECUTE ON [Assessment].[SPAttendanceInsertUpdate] TO PUBLIC