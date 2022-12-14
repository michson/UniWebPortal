USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPVouchersInsertUpdate]    Script Date: 08/14/2011 13:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.Vouchers Table

ALTER PROC [Finance].[SPVouchersInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@AccountGroupCode NVARCHAR(50)=NULL,
	@AccountSubCode INT=NULL,
	@AccountTypeCode DECIMAL(18,0)=NULL,
	@AccountCode DECIMAL(18,0)=NULL,
	@VoucherTypeCode NVARCHAR(50)=NULL,
	@TransactionTypeCode NVARCHAR(50)=NULL,
	@EntityTypeCode NVARCHAR(50)=NULL,
	@ParticularsCode NVARCHAR(50)=NULL,
	@DateX DATETIME=NULL,
	@DebitAmount DECIMAL(18,2)=NULL,
	@CreditAmount DECIMAL(18,2)=NULL,
	@Narration NVARCHAR(256)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[Vouchers] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Finance] .[Vouchers] 
				(
					[UniversityCode],
					[SessionCode],
					[SemesterCode],
					[AccountGroupCode],
					[AccountSubCode],
					[AccountTypeCode],
					[AccountCode],
					[VoucherTypeCode],
					[TransactionTypeCode],
					[EntityTypeCode],
					[ParticularsCode],
					[DateX],
					[DebitAmount],
					[CreditAmount],
					[Narration],
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
					@SessionCode,
					@SemesterCode,
					@AccountGroupCode,
					@AccountSubCode,
					@AccountTypeCode,
					@AccountCode,
					@VoucherTypeCode,
					@TransactionTypeCode,
					@EntityTypeCode,
					@ParticularsCode,
					@DateX,
					@DebitAmount,
					@CreditAmount,
					@Narration,
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
				UPDATE [Finance] .[Vouchers] 
				SET
					[UniversityCode]=@UniversityCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[AccountGroupCode]=@AccountGroupCode,
					[AccountSubCode]=@AccountSubCode,
					[AccountTypeCode]=@AccountTypeCode,
					[AccountCode]=@AccountCode,
					[VoucherTypeCode]=@VoucherTypeCode,
					[TransactionTypeCode]=@TransactionTypeCode,
					[EntityTypeCode]=@EntityTypeCode,
					[ParticularsCode]=@ParticularsCode,
					[DateX]=@DateX,
					[DebitAmount]=@DebitAmount,
					[CreditAmount]=@CreditAmount,
					[Narration]=@Narration,
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

GRANT EXECUTE ON [Finance].[SPVouchersInsertUpdate] TO PUBLIC