USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPPermissionsInsertUpdate]    Script Date: 08/14/2011 14:31:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Godwin Mathias
--Reviewer			:	Godwin Mathias	
--Date Created		:	08/06/2011 
--Last Updated		:	08/06/2011 
--Last Updated By	:	Godwin Mathias
--Description		:	Stored procedure for saving values into Academics.Semesters Table

ALTER PROC [SetUp].[SPPermissionsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@ModuleCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@RoleCode UNIQUEIDENTIFIER=NULL,
	@ActionCode NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [SetUp].[Permissions] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [SetUp].[Permissions] 
				(
					[UniversityCode],
					[ModuleCode],
					[ScreenCode],
					[RoleCode],
					[ActionCode],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@ModuleCode,
					@ScreenCode,
					@RoleCode,
					@ActionCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Permissions]  
				SET
					[UniversityCode]=@UniversityCode,
					[ModuleCode]=@ModuleCode,
					[ScreenCode]=@ScreenCode,
					[RoleCode]=@RoleCode,
					[ActionCode]=@ActionCode,
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

GRANT EXECUTE ON [SetUp].[SPPermissionsInsertUpdate] TO PUBLIC