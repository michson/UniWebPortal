USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPTransactionsDetailInsertUpdate]    Script Date: 08/14/2011 13:43:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.TransactionsDetail Table

ALTER PROC [Finance].[SPTransactionsDetailInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@InvoiceCode DECIMAL(18,0)=NULL,
	@ItemDescription NVARCHAR(500)=NULL,
	@Quantity INT=NULL,
	@Unit NVARCHAR(50)=NULL,
	@UnitCost DECIMAL(18,2)=NULL,
	@DiscountPercentage DECIMAL(18,2)=NULL,
	@DiscountAmount DECIMAL(18,2)=NULL,
	@TaxType NVARCHAR(50)=NULL,
	@TaxValue DECIMAL(18,2)=NULL,
	@TotalCost DECIMAL(18,2)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[TransactionsDetail] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode))
			BEGIN
				INSERT INTO [Finance] .[TransactionsDetail] 
				(
					[UniversityCode],
					[SessionCode],
					[SemesterCode],
					[InvoiceCode],
					[ItemDescription],
					[Quantity],
					[Unit],
					[UnitCost],
					[DiscountPercentage],
					[DiscountAmount],
					[TaxType],
					[TaxValue],
					[TotalCost],
					[CreatedOn],
					[CreatedBy]
					
				)
				VALUES
				(
					@UniversityCode,
					@SessionCode,
					@SemesterCode,
					@InvoiceCode,
					@ItemDescription,
					@Quantity,
					@Unit,
					@UnitCost,
					@DiscountPercentage,
					@DiscountAmount,
					@TaxType,
					@TaxValue,
					@TotalCost,
					@CreatedOn,
					@CreatedBy
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[TransactionsDetail] 
				SET
					[UniversityCode]=@UniversityCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[InvoiceCode]=@InvoiceCode,
					[ItemDescription]=@ItemDescription,
					[Quantity]=@Quantity,
					[Unit]=@Unit,
					[UnitCost]=@UnitCost,
					[DiscountPercentage]=@DiscountPercentage,
					[DiscountAmount]=@DiscountAmount,
					[TaxType]=@TaxType,
					[TaxValue]=@TaxValue,
					[TotalCost]=@TotalCost,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy
					
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

GRANT EXECUTE ON [Finance].[SPTransactionsDetailsInsertUpdate] TO PUBLIC