USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPComputerSkillsInsertUpdate]    Script Date: 08/14/2011 13:49:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personals.ComputerSkills Table

ALTER PROC [Personals].[SPComputerSkillsInsertUpdate]
(
	@Code INT=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50) = NULL,
	@PackageCode NVARCHAR(50)=NULL,
	@LevelOfKnowledgeCode NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Personals].[ComputerSkills] WHERE (([Code] = @Code) AND ([AccountCode]=@AccountCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[ComputerSkills]
				(
					[AccountCode],
					[ScreenCode],
					[PackageCode],
					[LevelOfKnowledgeCode],
					[Notes],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@AccountCode,
					@ScreenCode,
					@PackageCode,
					@LevelOfKnowledgeCode,
					@Notes,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[ComputerSkills]
				SET
					[AccountCode]=@AccountCode,
					[ScreenCode]=@ScreenCode,
					[PackageCode]=@PackageCode,
					[LevelOfKnowledgeCode]=@LevelOfKnowledgeCode,
					[Notes]=@Notes,
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

GRANT EXECUTE ON [Personals].[SPComputerSkillsInsertUpdate] TO PUBLIC