USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPPaymentPlanDetailsSelect]    Script Date: 08/14/2011 13:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for retrieving values from Finance.PaymentPlanDetails Table

ALTER PROC [Finance].[SPPaymentPlanDetailsSelect]
(
	@Code BIGINT=NULL,
	@PaymentPlanCode BIGINT=NULL
	
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF EXISTS (SELECT * FROM [Finance].[PaymentPlanDetails] WHERE (([Code] = @Code) AND ([PaymentPlanCode] = @PaymentPlanCode)))
			BEGIN
			SELECT * FROM [Finance].[PaymentPlanDetails] 
			WHERE 
				(
				([Code] = @Code) AND 
				([PaymentPlanCode] = @PaymentPlanCode)
				)	
			END
		ELSE
			BEGIN
			SELECT * FROM [Finance].[PaymentPlanDetails] 
			WHERE 
				(
				([PaymentPlanCode] = @PaymentPlanCode)
				)	
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

GRANT EXECUTE ON [Finance].[SPPaymentPlanDetailsSelect] TO PUBLIC