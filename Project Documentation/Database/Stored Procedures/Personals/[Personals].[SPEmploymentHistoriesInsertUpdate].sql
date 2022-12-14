USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPEmploymentHistoriesInsertUpdate]    Script Date: 08/14/2011 13:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personals.EmploymentHistories Table

ALTER PROC [Personals].[SPEmploymentHistoriesInsertUpdate]
(
	@Code INT=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@TitleCode NVARCHAR(50)=NULL,
	@JobCategoryCode NVARCHAR(50)=NULL,
	@JobDescCode NVARCHAR(50)=NULL,
	@LevelOfXpertiseCode NVARCHAR(50)=NULL,
	@WorkPercentageCode NVARCHAR(50)=NULL,
	@FromYearCode NVARCHAR(50)=NULL,
	@ToYearCode NVARCHAR(50)=NULL,
	@FromMonthCode NVARCHAR(50)=NULL,
	@ToMonthCode NVARCHAR(50)=NULL,
	@FromSAS NVARCHAR(50)=NULL,
	@FromSASCurrencyCode NVARCHAR(50)=NULL,
	@FromSASTotals DECIMAL(18,0)=NULL,
	@FromEAS NVARCHAR(50)=NULL,
	@FromEASCurrencyCode NVARCHAR(50)=NULL,
	@FromEASTotals DECIMAL(18,0)=NULL,
	@Supervisor NVARCHAR(150)=NULL,
	@SupervisorTitle NVARCHAR(50)=NULL,
	@Employer NVARCHAR(256)=NULL,
	@EmployerAddress NVARCHAR(256)=NULL,
	@EmployerBusinessNatureCode NVARCHAR(50)=NULL,
	@EmployerURL NVARCHAR(256)=NULL,
	@DutiesDescription NVARCHAR(500)=NULL,
	@KeyAchievements NVARCHAR(500)=NULL,
	@ContactRefrenceCode NVARCHAR(50)=NULL,
	@NoOfPeopleSupervised INT=NULL,
	@ReasonForLeaving NVARCHAR(256)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Personals].[EmploymentHistories] WHERE (([Code] = @Code) AND ([AccountCode]=@AccountCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[EmploymentHistories]
				(
					[AccountCode],
					[ScreenCode],
					[TitleCode],
					[JobCategoryCode],
					[JobDescCode],
					[LevelOfXpertiseCode],
					[WorkPercentageCode],
					[FromYearCode],
					[ToYearCode],
					[FromMonthCode],
					[ToMonthCode],
					[FromSAS],
					[FromSASCurrencyCode],
					[FromSASTotals],
					[FromEAS],
					[FromEASCurrencyCode],
					[FromEASTotals],
					[Supervisor],
					[SupervisorTitle],
					[Employer],
					[EmployerAddress],
					[EmployerBusinessNatureCode],
					[EmployerURL],
					[DutiesDescription],
					[KeyAchievements],
					[ContactRefrenceCode],
					[NoOfPeopleSupervised],
					[ReasonForLeaving],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@AccountCode,
					@ScreenCode,
					@TitleCode,
					@JobCategoryCode,
					@JobDescCode,
					@LevelOfXpertiseCode,
					@WorkPercentageCode,
					@FromYearCode,
					@ToYearCode,
					@FromMonthCode,
					@ToMonthCode,
					@FromSAS,
					@FromSASCurrencyCode,
					@FromSASTotals,
					@FromEAS,
					@FromEASCurrencyCode,
					@FromEASTotals,
					@Supervisor,
					@SupervisorTitle,
					@Employer,
					@EmployerAddress,
					@EmployerBusinessNatureCode,
					@EmployerURL,
					@DutiesDescription,
					@KeyAchievements,
					@ContactRefrenceCode,
					@NoOfPeopleSupervised,
					@ReasonForLeaving,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[EmploymentHistories]
				SET
					[AccountCode]=@AccountCode,
					[ScreenCode]=@ScreenCode,
					[TitleCode]=@TitleCode,
					[JobCategoryCode]=@JobCategoryCode,
					[JobDescCode]=@JobDescCode,
					[LevelOfXpertiseCode]=@LevelOfXpertiseCode,
					[WorkPercentageCode]=@WorkPercentageCode,
					[FromYearCode]=@FromYearCode,
					[ToYearCode]=@ToYearCode,
					[FromMonthCode]=@FromMonthCode,
					[ToMonthCode]=@ToMonthCode,
					[FromSAS]=@FromSAS,
					[FromSASCurrencyCode]=@FromSASCurrencyCode,
					[FromSASTotals]=@FromSASTotals,
					[FromEAS]=@FromEAS,
					[FromEASCurrencyCode]=@FromEASCurrencyCode,
					[FromEASTotals]=@FromEASTotals,
					[Supervisor]=@Supervisor,
					[SupervisorTitle]=@SupervisorTitle,
					[Employer]=@Employer,
					[EmployerAddress]=@EmployerAddress,
					[EmployerBusinessNatureCode]=@EmployerBusinessNatureCode,
					[EmployerURL]=@EmployerURL,
					[DutiesDescription]=@DutiesDescription,
					[KeyAchievements]=@KeyAchievements,
					[ContactRefrenceCode]=@ContactRefrenceCode,
					[NoOfPeopleSupervised]=@NoOfPeopleSupervised,
					[ReasonForLeaving]=@ReasonForLeaving,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					(([Code] = @Code) AND ([AccountCode]=@AccountCode))
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

GRANT EXECUTE ON [Personals].[SPEmploymentHistoriesInsertUpdate] TO PUBLIC