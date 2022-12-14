USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPTransactionsInsertUpdate]    Script Date: 08/14/2011 13:44:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.Transactions Table

ALTER PROC [Finance].[SPTransactionsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@TransactionActivityCode NVARCHAR(50)=NULL,
	@InvoiceTypeCode NVARCHAR(50)=NULL,
	@LpoNo DECIMAL(18,0)=NULL,
	@PoNo DECIMAL(18,0)=NULL,
	@CategoryCode NVARCHAR(50)=NULL,
	@Amount DECIMAL(18,0)=NULL,
	@AmountPaid DECIMAL(18,0)=NULL,
	@Balance DECIMAL(18,0)=NULL,
	@Total DECIMAL(18,0)=NULL,
	@CompanyCode NVARCHAR(50)=NULL,
	@PaymentStatus NVARCHAR(50)=NULL,
	@DateX DATETIME2(7)=NULL,
	@AmountInWords NVARCHAR(500)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[Transactions] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode))
			BEGIN
				INSERT INTO [Finance] .[Transactions] 
				(
					[UniversityCode],
					[SessionCode],
					[SemesterCode],
					[TransactionActivityCode],
					[InvoiceTypeCode],
					[LpoNo],
					[PoNo],
					[CategoryCode],
					[Amount],
					[AmountPaid],
					[Balance],
					[Total],
					[CompanyCode],
					[PaymentStatus],
					[DateX],
					[AmountInWords],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@SessionCode,
					@SemesterCode,
					@TransactionActivityCode,
					@InvoiceTypeCode,
					@LpoNo,
					@PoNo,
					@CategoryCode,
					@Amount,
					@AmountPaid,
					@Balance,
					@Total,
					@CompanyCode,
					@PaymentStatus,
					@DateX,
					@AmountInWords,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[Transactions] 
				SET
					[UniversityCode]=@UniversityCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[TransactionActivityCode]=@TransactionActivityCode,
					[InvoiceTypeCode]=@InvoiceTypeCode,
					[LpoNo]=@LpoNo,
					[PoNo]=@PoNo,
					[CategoryCode]=@CategoryCode,
					[Amount]=@Amount,
					[AmountPaid]=@AmountPaid,
					[Balance]=@Balance,
					[Total]=@Total,
					[CompanyCode]=@CompanyCode,
					[PaymentStatus]=@PaymentStatus,
					[DateX]=@DateX,
					[AmountInWords]=@AmountInWords,
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

GRANT EXECUTE ON [Finance].[SPTransactionsInsertUpdate] TO PUBLIC