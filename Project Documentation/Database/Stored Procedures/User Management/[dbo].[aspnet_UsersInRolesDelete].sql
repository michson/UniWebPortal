USE [UniversityDB]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRolesDelete]    Script Date: 08/14/2011 13:35:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Godwin Mathias
--Reviewer			:	Godwin Mathias	
--Date Created		:	05/16/2011
--Last Updated		:	05/18/2011 
--Last Updated By	:	Godwin Mathias
--Description		:	Stored procedure for retrieving values in the dbo.aspnet_UsersInRoles  Table

ALTER PROC [dbo].[aspnet_UsersInRolesDelete]
(
	@RoleId uniqueidentifier = null,
	@UserId uniqueidentifier = null,
	@SchoolCode nvarchar(50) = null,
	@BranchCode NVARCHAR(50) = NULL,
	@Deleted BIT = NULL,
	@DeletedOn DATETIME2(7)=NULL,
	@DeletedBy NVARCHAR(50)=NULL
)

AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF EXISTS (SELECT * FROM  [dbo].[aspnet_UsersInRoles] WHERE ((RoleId = @RoleId) AND (UserId=@UserId) AND (SchoolCode=@SchoolCode) AND (BranchCode=@BranchCode)))

			BEGIN
				UPDATE  [dbo].[aspnet_UsersInRoles] 
				SET 
					Deleted=@Deleted,
					DeletedOn=@DeletedOn,
					DeletedBy=@DeletedBy
				WHERE (([RoleId] = @RoleId) AND ([UserId]=@UserId) AND ([SchoolCode]=@SchoolCode) AND ([BranchCode]=@BranchCode))	 
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

GRANT EXECUTE ON [dbo].[aspnet_UsersInRolesDelete] TO PUBLIC