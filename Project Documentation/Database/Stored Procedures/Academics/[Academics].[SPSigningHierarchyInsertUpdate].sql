USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Academics].[SPSigningHierarchyInsertUpdate]    Script Date: 08/14/2011 12:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Academics.SigningHierarchy Table

ALTER PROC [Academics].[SPSigningHierarchyInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@DesignationCode NVARCHAR(50)=NULL,
	@OrderCode NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Academics].[SigningHierarchy] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Academics].[SigningHierarchy] 
				(
					[UniversityCode],
					[DesignationCode],
					[OrderCode],
					[SessionCode],
					[Applicable],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@DesignationCode,
					@OrderCode,
					@SessionCode,
					@Applicable,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Academics].[SigningHierarchy] 
				SET
					[UniversityCode]=@UniversityCode,
					[DesignationCode]=@DesignationCode,
					[OrderCode]=@OrderCode,
					[SessionCode]=@SessionCode,
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

GRANT EXECUTE ON [Academics].[SPSigningHierarchyInsertUpdate] TO PUBLIC