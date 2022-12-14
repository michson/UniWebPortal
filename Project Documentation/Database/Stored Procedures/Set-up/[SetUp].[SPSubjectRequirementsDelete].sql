USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPSubjectRequirementsDelete]    Script Date: 08/14/2011 14:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/28/2011 
--Last Updated		:	07/28/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for deleting values temporarily from SetUp.SubjectRequirements Table

ALTER PROC [SetUp].[SPSubjectRequirementsDelete]
(
	@Code BIGINT=NULL,
	@Deleted BIT=NULL,
	@DeletedOn DATETIME2(7)=NULL,
	@DeletedBy NVARCHAR(50)=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[SubjectRequirements] WHERE (([Code] = @Code) AND (Deleted=@Deleted)))
			BEGIN
			UPDATE [SetUp].[SubjectRequirements] 
			SET
				[Deleted]=@Deleted,
				[DeletedOn]=@DeletedOn,
				[DeletedBy]=@DeletedBy
				
			WHERE 
				(
					([Code] = @Code) 
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

GRANT EXECUTE ON [SetUp].[SPSubjectRequirementsDelete] TO PUBLIC