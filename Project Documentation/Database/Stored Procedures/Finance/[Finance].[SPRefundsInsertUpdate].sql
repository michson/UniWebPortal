USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPRefundsInsertUpdate]    Script Date: 08/14/2011 13:43:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.Refunds Table

ALTER PROC [Finance].[SPRefundsInsertUpdate]
(
	@Code BIGINT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@FeesCode DECIMAL(18,0)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@Amount DECIMAL(18,2)=NULL,
	@Refunded BIT=NULL,
	@RefundedOn DATETIME2(7)=NULL,
	@RefundedBy NVARCHAR(50)=NULL,
	@Approved BIT=NULL,
	@ApproveBy NVARCHAR(50)=NULL,
	@ApproveOn DATETIME2(7)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[Refunds] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode))
			BEGIN
				INSERT INTO [Finance] .[Refunds] 
				(
					[MatricNo],
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[FeesCode],
					[SessionCode],
					[SemesterCode],
					[Amount],
					[Refunded],
					[RefundedOn],
					[RefundedBy],
					[Approved],
					[ApproveBy],
					[ApproveOn],
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
					@SessionCode,
					@SemesterCode,
					@Amount,
					@Refunded,
					@RefundedOn,
					@RefundedBy,
					@Approved,
					@ApproveBy,
					@ApproveOn,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[Refunds] 
				SET
					[MatricNo]=@MatricNo,
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[FeesCode]=@FeesCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[Amount]=@Amount,
					[Refunded]=@Refunded,
					[RefundedOn]=@RefundedOn,
					[RefundedBy]=@RefundedBy,
					[Approved]=@Approved,
					[ApproveBy]=@ApproveBy,
					[ApproveOn]=@ApproveOn,
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

GRANT EXECUTE ON [Finance].[SPRefundsInsertUpdate] TO PUBLIC