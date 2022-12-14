USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPApprovalsInsertUpdate]    Script Date: 08/14/2011 14:17:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Approvals Table

ALTER PROC [SetUp].[SPApprovalsInsertUpdate]
(
	@Code UNIQUEIDENTIFIER=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode INT=NULL,
	@SessionCode NVARCHAR(50)=NULL,
	@ModuleCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@LevelCode INT=NULL,
	@RoleCode UNIQUEIDENTIFIER=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@EntityCode NVARCHAR(50)=NULL,
	@ApprovalType NVARCHAR(50)=NULL,
	@Order INT=NULL,
	@Approved BIT=NULL,
	@ApprovedOn DATETIME=NULL,
	@ApprovedBy NVARCHAR(50)=NULL,
	@ApprovedNotes NVARCHAR(1000)=NULL,
	@Requested BIT=NULL,
	@RequestedOn DATETIME=NULL,
	@RequestedBy NVARCHAR(50)=NULL,
	@RequestedNotes NVARCHAR(1000)=NULL,
	@Rejected BIT=NULL,
	@RejectedOn DATETIME=NULL,
	@RejectedBy NVARCHAR(50)=NULL,
	@RejectedNotes NVARCHAR(1000)=NULL
	
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[Approvals]  WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode))  
			BEGIN
				INSERT INTO [SetUp].[Approvals] 
				(
					[Code],
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[SessionCode],
					[ModuleCode],
					[ScreenCode],
					[SemesterCode],
					[LevelCode],
					[RoleCode],
					[AccountCode],
					[EntityCode],
					[ApprovalType],
					[Order],
					[Approved],
					[ApprovedOn],
					[ApprovedBy],
					[ApprovedNotes],
					[Requested],
					[RequestedOn],
					[RequestedBy],
					[RequestedNotes],
					[Rejected],
					[RejectedOn],
					[RejectedBy],
					[RejectedNotes]
				)
				VALUES
				(
					@Code,
					@UniversityCode,
					@FacultyCode,
					@DepartmentCode,
					@CourseCode,
					@ProgramCode,
					@SessionCode,
					@ModuleCode,
					@ScreenCode,
					@SemesterCode,
					@LevelCode,
					@RoleCode,
					@AccountCode,
					@EntityCode,
					@ApprovalType,
					@Order,
					@Approved,
					@ApprovedOn,
					@ApprovedBy,
					@ApprovedNotes,
					@Requested,
					@RequestedOn,
					@RequestedBy,
					@RequestedNotes,
					@Rejected,
					@RejectedOn,
					@RejectedBy,
					@RejectedNotes
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Approvals] 
				SET
					[UniversityCode] = @UniversityCode,
					[FacultyCode] = @FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[SessionCode]=@SessionCode,
					[ModuleCode]=@ModuleCode,
					[ScreenCode]=@ScreenCode,
					[SemesterCode]=@SemesterCode,
					[LevelCode]=@LevelCode,
					[RoleCode]=@RoleCode,
					[AccountCode]=@AccountCode,
					[EntityCode]=@EntityCode,
					[ApprovalType]=@ApprovalType,
					[Order]=@Order,
					[Approved]=@Approved,
					[ApprovedOn]=@ApprovedOn,
					[ApprovedBy]=@ApprovedBy,
					[ApprovedNotes]=@ApprovedNotes,
					[Requested]=@Requested,
					[RequestedOn]=@RequestedOn,
					[RequestedBy]=@RequestedBy,
					[RequestedNotes]=@RequestedNotes,
					[Rejected]=@Rejected,
					[RejectedOn]=@RejectedOn,
					[RejectedBy]=@RejectedBy,
					[RejectedNotes]=@RejectedNotes
				WHERE
					([Code] = @Code)
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

GRANT EXECUTE ON [SetUp].[SPApprovalsInsertUpdate] TO PUBLIC