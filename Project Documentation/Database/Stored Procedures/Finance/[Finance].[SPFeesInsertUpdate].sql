USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPFeesInsertUpdate]    Script Date: 08/14/2011 13:40:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.Fees Table

ALTER PROC [Finance].[SPFeesInsertUpdate]
(
	@Code BIGINT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@AccountTitle NVARCHAR(256)=NULL,
	@AccountNo NVARCHAR(50)=NULL,
	@BankCode NVARCHAR(50)=NULL,
	@BankBranch NVARCHAR(256)=NULL,
	@PaymentMode NVARCHAR(50)=NULL,
	@DateX DATETIME2(7)=NULL,
	@Amount DECIMAL(18,0)=NULL,
	@Balance DECIMAL(18,2)=NULL,
	@PaymentStatus NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[Fees] WHERE ([Code] = @Code) AND ([UniversityCode]=@UniversityCode) AND ([Deleted]=@Deleted))
			BEGIN
				INSERT INTO [Finance] .[Fees] 
				(
					[MatricNo],
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[SessionCode],
					[SemesterCode],
					[Amount],
					[AccountTitle],
					[AccountNo],
					[BankCode],
					[BankBranch],
					[PaymentMode],
					[DateX],
					[Balance],
					[PaymentStatus],
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
					@SessionCode,
					@SemesterCode,
					@Amount,
					@AccountTitle,
					@AccountNo,
					@BankCode,
					@BankBranch,
					@PaymentMode,
					@DateX,
					@Balance,
					@PaymentStatus,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[Fees] 
				SET
					[MatricNo]=@MatricNo,
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[Amount]=@Amount,
					[AccountTitle]=@AccountTitle,
					[AccountNo]=@AccountNo,
					[BankCode]=@BankCode,
					[BankBranch]=@BankBranch,
					[PaymentMode]=@PaymentMode,
					[DateX]=@DateX,
					[Balance]=@Balance,
					[PaymentStatus]=@PaymentStatus,
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

GRANT EXECUTE ON [Finance].[SPFeesInsertUpdate] TO PUBLIC