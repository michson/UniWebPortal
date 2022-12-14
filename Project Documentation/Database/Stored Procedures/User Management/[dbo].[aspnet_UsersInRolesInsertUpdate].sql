USE [UniversityDB]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRolesInsertUpdate]    Script Date: 08/14/2011 13:35:35 ******/
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
	
ALTER PROC [dbo].[aspnet_UsersInRolesInsertUpdate]
(
	@UserId UNIQUEIDENTIFIER = Null,
	@RoleId UNIQUEIDENTIFIER = null,
	@SchoolCode NVARCHAR(50) = null,
	@BranchCode NVARCHAR(50) = null,
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

		IF NOT EXISTS (SELECT * FROM [dbo].[aspnet_UsersInRoles] WHERE ((UserId = @UserId) AND (RoleId=@RoleId) AND (SchoolCode=@SchoolCode) AND (BranchCode=@BranchCode)))
			BEGIN
				INSERT INTO [dbo].[aspnet_UsersInRoles]
				(
					[UserId],
					[RoleId],
					[SchoolCode],
					[BranchCode],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@UserId,
					@RoleId,
					@SchoolCode,
					@BranchCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [dbo].[aspnet_UsersInRoles]
				SET
					[UserId]=@UserId,
					[RoleId]=@RoleId,
					[SchoolCode]=@SchoolCode,
					[BranchCode]=@BranchCode,
					[ModifiedOn] = @ModifiedOn,
					[ModifiedBy] = @ModifiedBy,
					[Deleted]=@Deleted
					
				WHERE ((UserId = @UserId) AND (RoleId=@RoleId) AND (SchoolCode=@SchoolCode) AND (BranchCode=@BranchCode))
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

GRANT EXECUTE ON  [dbo].[aspnet_UsersInRolesInsertUpdate] TO PUBLIC
