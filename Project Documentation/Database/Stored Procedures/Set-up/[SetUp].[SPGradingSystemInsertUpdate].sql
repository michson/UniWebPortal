USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPGradingSystemInsertUpdate]    Script Date: 08/14/2011 14:29:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.GradingSystem Table

ALTER PROC [SetUp].[SPGradingSystemInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@ScoreLowerBound DECIMAL(18,2)=NULL,
	@ScoreUpperBound DECIMAL(18,2)=NULL,
	@Description NVARCHAR(2)=NULL,
	@CGPALowerBound DECIMAL(18,2)=NULL,
	@CGPAUpperBound DECIMAL(18,2)=NULL,
	@Notes NVARCHAR(500)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [SetUp].[GradingSystem]  WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))  
			BEGIN
				INSERT INTO [SetUp].[GradingSystem] 
				(
					[UniversityCode],
					[ScoreLowerBound],
					[ScoreUpperBound],
					[Description],
					[CGPALowerBound],
					[CGPAUpperBound],
					[Notes],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@ScoreLowerBound,
					@ScoreUpperBound,
					@Description,
					@CGPALowerBound,
					@CGPAUpperBound,
					@Notes,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[GradingSystem] 
				SET
					[UniversityCode]=@UniversityCode,
					[ScoreLowerBound]=@ScoreLowerBound,
					[ScoreUpperBound]=@ScoreUpperBound,
					[Description]=@Description,
					[CGPALowerBound]=@CGPALowerBound,
					[CGPAUpperBound]=@CGPAUpperBound,
					[Notes]=@Notes,
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

GRANT EXECUTE ON [SetUp].[SPGradingSystemInsertUpdate] TO PUBLIC