USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPLockingsInsertUpdate]    Script Date: 08/14/2011 14:29:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Lockings Table

ALTER PROC [SetUp].[SPLockingsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@SessionCode NVARCHAR(50)=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@LevelCode INT=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@EntityCode NVARCHAR(50)=NULL,
	@Locked BIT=NULL,
	@LockedOn DATETIME=NULL,
	@LockedBy NVARCHAR(50)=NULL,
	@UnlockedOn DATETIME=NULL,
	@UnlockedBy NVARCHAR(50)=NULL,
	@LastLockedOn DATETIME=NULL,
	@LastLockedBy NVARCHAR(50)=NULL
	
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[Lockings]  WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode))  
			BEGIN
				INSERT INTO [SetUp].[Lockings] 
				(
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[SessionCode],
					[SemesterCode],
					[LevelCode],
					[AccountCode],
					[EntityCode],
					[Locked],
					[LockedOn],
					[LockedBy],
					[UnlockedOn],
					[UnlockedBy],
					[LastLockedOn],
					[LastLockedBy] 
					
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
					@AccountCode,
					@EntityCode,
					@Locked,
					@LockedOn,
					@LockedBy,
					@UnlockedOn,
					@UnlockedBy,
					@LastLockedOn,
					@LastLockedBy
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Lockings] 
				SET
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[LevelCode]=@LevelCode,
					[AccountCode]=@AccountCode,
					[EntityCode]=@EntityCode,
					[Locked]=@Locked,
					[LockedOn]=@LockedOn,
					[LockedBy]=@LockedBy,
					[UnlockedOn]=@UnlockedOn,
					[UnlockedBy]=@UnlockedBy,
					[LastLockedOn]=@LastLockedOn,
					[LastLockedBy]=@LastLockedBy
					
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

GRANT EXECUTE ON [SetUp].[SPLockingsInsertUpdate] TO PUBLIC