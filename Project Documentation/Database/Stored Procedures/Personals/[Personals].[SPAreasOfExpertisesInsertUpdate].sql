USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPAreasOfExpertisesInsertUpdate]    Script Date: 08/14/2011 13:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personals.AreaOfExpertises Table

ALTER PROC [Personals].[SPAreasOfExpertisesInsertUpdate]
(
	@Code INT=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50) = NULL,
	@JobCategoryCode NVARCHAR(50)=NULL,
	@AOSCode NVARCHAR(50)=NULL,
	@YearOfExperience NVARCHAR(50)=NULL,
	@LeveOfExperience NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Personals].[AreasOfExpertises] WHERE (([Code] = @Code) AND ([AccountCode]=@AccountCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[AreasOfExpertises]
				(
					[AccountCode],
					[ScreenCode],
					[JobCategoryCode],
					[AOSCode],
					[YearOfExperience],
					[LeveOfExperience],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@AccountCode,
					@ScreenCode,
					@JobCategoryCode,
					@AOSCode,
					@YearOfExperience,
					@LeveOfExperience,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[AreasOfExpertises]
				SET
					[AccountCode]=@AccountCode,
					[ScreenCode]=@ScreenCode,
					[JobCategoryCode]=@JobCategoryCode,
					[AOSCode]=@AOSCode,
					[YearOfExperience]=@YearOfExperience,
					[LeveOfExperience]=@LeveOfExperience,
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

GRANT EXECUTE ON [Personals].[SPAreasOfExpertisesInsertUpdate] TO PUBLIC