USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPFeesDetailInsertUpdate]    Script Date: 08/14/2011 13:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.FeesDetail Table

ALTER PROC [Finance].[SPFeesDetailInsertUpdate]
(
	@Code BIGINT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@FeesCode BIGINT=NULL,
	@FeeDefinitionCode NVARCHAR(50)=NULL,
	@FeeAllotmentCode BIGINT=NULL,
	@Amount DECIMAL(18,2)=NULL,
	@ExtraDiscount INT=NULL,
	@FinalAmount DECIMAL(18,2)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[FeesDetail] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Finance] .[FeesDetail] 
				(
					[MatricNo],
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[FeesCode],
					[FeeDefinitionCode],
					[FeeAllotmentCode],
					[Amount],
					[ExtraDiscount],
					[FinalAmount],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@MatricNo,
					@UniversityCode,
					@FacultyCode,
					@DepartmentCode,
					@CourseCode,
					@ProgramCode,
					@LevelCode,
					@FeesCode,
					@FeeDefinitionCode,
					@FeeAllotmentCode,
					@Amount,
					@ExtraDiscount,
					@FinalAmount,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[FeesDetail] 
				SET
					[MatricNo]=@MatricNo,
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[FeesCode]=@FeesCode,
					[FeeDefinitionCode]=@FeeDefinitionCode,
					[FeeAllotmentCode]=@FeeAllotmentCode,
					[Amount]=@Amount,
					[ExtraDiscount]=@ExtraDiscount,
					[FinalAmount]=@FinalAmount,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
					
				WHERE
					(([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
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

GRANT EXECUTE ON [Finance].[SPFeesDetailInsertUpdate] TO PUBLIC