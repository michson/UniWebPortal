USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPStaffInsertUpdate]    Script Date: 08/14/2011 14:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Staff Table

ALTER PROC [SetUp].[SPStaffInsertUpdate]
(
	@Code NVARCHAR(50)=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@StaffType NVARCHAR(50)=NULL,
	@ContractType NVARCHAR(50)=NULL,
	@ComDate DATETIME2(7)=NULL,
	@CessDate DATETIME2(7)=NULL,
	@StatusCode NVARCHAR(50)=NULL,
	@StatusReason NVARCHAR(500)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [SetUp].[Staff]  WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))  
			BEGIN
				INSERT INTO [SetUp].[Staff] 
				(
					[Code],
					[AccountCode],
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[StaffType],
					[ContractType],
					[ComDate],
					[CessDate],
					[StatusCode],
					[StatusReason],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@Code,
					@AccountCode,
					@UniversityCode,
					@FacultyCode,
					@DepartmentCode,
					@StaffType,
					@ContractType,
					@ComDate,
					@CessDate,
					@StatusCode,
					@StatusReason,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Staff] 
				SET
					[Code]=@Code,
					[AccountCode]=@AccountCode,
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[StaffType]=@StaffType,
					[ContractType]=@ContractType,
					[ComDate]=@ComDate,
					[CessDate]=@CessDate,
					[StatusCode]=@StatusCode,
					[StatusReason]=@StatusReason,
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

GRANT EXECUTE ON [SetUp].[SPStaffInsertUpdate] TO PUBLIC