USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPPaymentPlansSelect]    Script Date: 08/14/2011 13:42:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for retrieving values from Finance.PaymentPlans Table

ALTER PROC [Finance].[SPPaymentPlansSelect]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@Deleted BIT=NULL
	
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF EXISTS (SELECT * FROM [Finance].[PaymentPlans] WHERE (([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted)))
			BEGIN
			SELECT * FROM [Finance].[PaymentPlans] 
			WHERE 
				(
				([Code] = @Code) AND 
				([UniversityCode] = @UniversityCode) AND
				([Deleted] = @Deleted)
				)	
			END
		ELSE
			BEGIN
			SELECT * FROM [Finance].[PaymentPlans] 
			WHERE 
				(
				([UniversityCode] = @UniversityCode) AND
				([Deleted] = @Deleted)
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

GRANT EXECUTE ON [Finance].[SPPaymentPlansSelect] TO PUBLIC