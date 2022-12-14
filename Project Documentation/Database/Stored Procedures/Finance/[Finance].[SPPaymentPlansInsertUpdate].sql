USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Finance].[SPPaymentPlansInsertUpdate]    Script Date: 08/14/2011 13:42:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Finance.PaymentPlans Table

ALTER PROC [Finance].[SPPaymentPlansInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode NVARCHAR(50)=NULL,
	@NoOfPaymentAllowed INT=NULL,
	@DateX DATETIME2(7)=NULL,
	@StatusCode NVARCHAR(50)=NULL,
	@Applicable BIT=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Finance] .[PaymentPlans] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode))
			BEGIN
				INSERT INTO [Finance] .[PaymentPlans] 
				(
					[UniversityCode],
					[SessionCode],
					[SemesterCode],
					[NoOfPaymentAllowed],
					[DateX],
					[StatusCode],
					[Applicable],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@SessionCode,
					@SemesterCode,
					@NoOfPaymentAllowed,
					@DateX,
					@StatusCode,
					@Applicable,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Finance] .[PaymentPlans] 
				SET
					[UniversityCode]=@UniversityCode,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[NoOfPaymentAllowed]=@NoOfPaymentAllowed,
					[DateX]=@DateX,
					[StatusCode]=@StatusCode,
					[Applicable]=@Applicable,
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

GRANT EXECUTE ON [Finance].[SPPaymentPlanDetailsInsertUpdate] TO PUBLIC