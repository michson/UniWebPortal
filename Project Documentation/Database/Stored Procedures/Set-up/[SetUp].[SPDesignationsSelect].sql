USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPDesignationsSelect]    Script Date: 08/14/2011 14:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for retrieving values from SetUp.Designations Table

ALTER PROC [SetUp].[SPDesignationsSelect]
(
	@Code BIGINT=NULL,
	@StaffCode NVARCHAR(50)=NULL,
	@Deleted BIT=NULL
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF EXISTS (SELECT * FROM [SetUp].[Designations] WHERE ([Code] = @Code) AND ([StaffCode] = @StaffCode) AND ([Deleted] = @Deleted))
			BEGIN
			SELECT * FROM [SetUp].[Designations] 
			WHERE 
				(
				([Code] = @Code) AND 
				([StaffCode] = @StaffCode) AND
				([Deleted] = @Deleted)
				)	
			END
		ELSE
			BEGIN
			SELECT * FROM [SetUp].[Designations] 
			WHERE 
				(
				([StaffCode] = @StaffCode) AND
				([Deleted] = @Deleted)
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

GRANT EXECUTE ON [SetUp].[SPDesignationsSelect] TO PUBLIC