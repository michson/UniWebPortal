USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPFeeAllotmentInsertUpdate]    Script Date: 08/14/2011 13:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.FeeAllotment Table

ALTER PROC [Finance].[SPFeeAllotmentInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@EntryMode NVARCHAR(50)=NULL,
	@StudyMode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@FeeDefinitionCode NVARCHAR(50)=NULL,
	@Amount DECIMAL(18,0)=NULL,
	@DiscountPercentage INT=NULL,
	@Approved BIT=NULL,
	@ApproveBy NVARCHAR(50)=NULL,
	@ApproveOn DATETIME2(7)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[FeeAllotment] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode) AND ([Deleted]=@Deleted))
			BEGIN
				INSERT INTO [Finance] .[FeeAllotment] 
				(
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[EntryMode],
					[StudyMode],
					[SessionCode],
					[SemesterCode],
					[FeeDefinitionCode],
					[Amount],
					[DiscountPercentage],
					[Approved],
					[ApproveBy],
					[ApproveOn],
					[Notes],
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
					@EntryMode,
					@StudyMode,
					@SessionCode,
					@SemesterCode,
					@FeeDefinitionCode,
					@Amount,
					@DiscountPercentage,
					@Approved,
					@ApproveBy,
					@ApproveOn,
					@Notes,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[FeeAllotment] 
				SET
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[EntryMode]=@EntryMode,
					[StudyMode]=@StudyMode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[FeeDefinitionCode]=@FeeDefinitionCode,
					[Amount]=@Amount,
					[DiscountPercentage]=@DiscountPercentage,
					[Approved]=@Approved,
					[ApproveBy]=@ApproveBy,
					[ApproveOn]=@ApproveOn,
					[Notes]=@Notes,
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

GRANT EXECUTE ON [Finance].[SPFeeAllotmentInsertUpdate] TO PUBLIC