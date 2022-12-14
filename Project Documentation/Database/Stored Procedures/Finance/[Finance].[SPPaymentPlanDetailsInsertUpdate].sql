USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPPaymentPlanDetailsInsertUpdate]    Script Date: 08/14/2011 13:41:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.PaymentPlanDetails Table

ALTER PROC [Finance].[SPPaymentPlanDetailsInsertUpdate]
(
	@Code BIGINT=NULL,
	@PaymentPlanCode BIGINT=NULL,
	@Description NVARCHAR(256)=NULL,
	@Amount DECIMAL(18,2)=NULL,
	@DiscountedAmount DECIMAL(18,2)=NULL,
	@DiscountedPercentage INT=NULL,
	@Total DECIMAL(18,2)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[PaymentPlanDetails] WHERE ([Code] = @Code))
			BEGIN
				INSERT INTO [Finance] .[PaymentPlanDetails] 
				(
					[PaymentPlanCode],
					[Description],
					[Amount],
					[DiscountedAmount],
					[DiscountedPercentage],
					[Total],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@PaymentPlanCode,
					@Description,
					@Amount,
					@DiscountedAmount,
					@DiscountedPercentage,
					@Total,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[PaymentPlanDetails] 
				SET
					[PaymentPlanCode]=@PaymentPlanCode,
					[Description]=@Description,
					[Amount]=@Amount,
					[DiscountedAmount]=@DiscountedAmount,
					[DiscountedPercentage]=@DiscountedPercentage,
					[Total]=@Total,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
					
				WHERE
					(([Code] = @Code))
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

GRANT EXECUTE ON [Finance].[SPPaymentPlanDetailsInsertUpdate] TO PUBLIC