USE [UniversityDB]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInBranchesInsertUpdate]    Script Date: 08/14/2011 12:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Godwin Mathias
--Reviewer			:	Godwin Mathias	
--Date Created		:	05/18/2011 
--Last Updated		:	05/18/2011 
--Last Updated By	:	Godwin Mathias
--Description		:	Stored procedure for inserting/updating values in  [dbo].[aspnet_UsersInBranches] Table 
	
ALTER PROC [dbo].[aspnet_UsersInBranchesInsertUpdate]
(
	@Code UNIQUEIDENTIFIER = Null,
	@UserId UNIQUEIDENTIFIER = null,
	@SchoolCode NVARCHAR(50) = null,
	@BranchCode NVARCHAR(50) = null,
	@DefaultBranch BIT=Null,
	@CreatedOn DATETIME2(7) = null,
	@CreatedBy NVARCHAR(50) = null,
	@ModifiedOn DATETIME2(7) = null,
	@ModifiedBy NVARCHAR(50) = null,
	@Deleted BIT = null
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [dbo].[aspnet_UsersInBranches] WHERE ((Code = @Code) AND (UserId=@UserId) AND (SchoolCode=@SchoolCode) AND (BranchCode=@BranchCode)))
			BEGIN
				INSERT INTO [dbo].[aspnet_UsersInBranches]
				(
					[Code],
					[UserId],
					[SchoolCode],
					[BranchCode],
					[DefaultBranch],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					NEWID(),
					@UserId,
					@SchoolCode,
					@BranchCode,
					@DefaultBranch,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [dbo].[aspnet_UsersInBranches]
				SET
					[UserId]=@UserId,
					[SchoolCode]=@SchoolCode,
					[BranchCode]=@BranchCode,
					[DefaultBranch]=@DefaultBranch,
					[ModifiedOn] = @ModifiedOn,
					[ModifiedBy] = @ModifiedBy,
					[Deleted]=@Deleted
				WHERE ([Code]=@Code)
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

GRANT EXECUTE ON  [dbo].[aspnet_UsersInBranchesInsertUpdate] TO PUBLIC
