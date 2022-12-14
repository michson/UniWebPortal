USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPDesignationsInsertUpdate]    Script Date: 08/14/2011 14:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Designations Table

ALTER PROC [SetUp].[SPDesignationsInsertUpdate]
(
	@Code BIGINT=NULL,
	@StaffCode NVARCHAR(50)=NULL,
	@ComDate DATETIME2(7)=NULL,
	@CessDate DATETIME2(7)=NULL,
	@DesignationCode NVARCHAR(50)=NULL,
	@TypeCode NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [SetUp].[Designations]  WHERE ([Code] = @Code) )  
			BEGIN
				INSERT INTO [SetUp].[Designations] 
				(
					[StaffCode],
					[ComDate],
					[CessDate],
					[DesignationCode],
					[TypeCode],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@StaffCode,
					@ComDate,
					@CessDate,
					@DesignationCode,
					@TypeCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Designations] 
				SET
					[StaffCode]=@StaffCode,
					[ComDate]=@ComDate,
					[CessDate]=@CessDate,
					[DesignationCode]=@DesignationCode,
					[TypeCode]=@TypeCode,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					([Code] = @Code)
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

GRANT EXECUTE ON [SetUp].[SPDesignationsInsertUpdate] TO PUBLIC