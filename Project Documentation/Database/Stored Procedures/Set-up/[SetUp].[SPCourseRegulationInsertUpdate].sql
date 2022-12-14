USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPCourseRegulationInsertUpdate]    Script Date: 08/14/2011 14:20:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.CourseRegulation Table

ALTER PROC [SetUp].[SPCourseRegulationInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@CreditLowerBound INT=NULL,
	@CreditUpperBound INT=NULL,
	@ModeOfStudyCode NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [SetUp].[CourseRegulation]  WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))  
			BEGIN
				INSERT INTO [SetUp].[CourseRegulation] 
				(
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[SemesterCode],
					[CreditLowerBound],
					[CreditUpperBound],
					[ModeOfStudyCode],
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
					@SemesterCode,
					@CreditLowerBound,
					@CreditUpperBound,
					@ModeOfStudyCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[CourseRegulation] 
				SET
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[SemesterCode]=@SemesterCode,
					[CreditLowerBound]=@CreditLowerBound,
					[CreditUpperBound]=@CreditUpperBound,
					[ModeOfStudyCode]=@ModeOfStudyCode,
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

GRANT EXECUTE ON [SetUp].[SPCourseRegulationInsertUpdate] TO PUBLIC