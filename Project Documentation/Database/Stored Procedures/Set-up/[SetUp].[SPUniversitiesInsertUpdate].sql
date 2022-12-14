USE [UniversityDB]
GO
/****** Object:  StoredProcedure [SetUp].[SPUniversitiesInsertUpdate]    Script Date: 08/14/2011 14:37:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into SetUp.Universities Table

ALTER PROC [SetUp].[SPUniversitiesInsertUpdate]
(
	@Code NVARCHAR(50)=NULL,
	@Description NVARCHAR(256)=NULL,
	@UniversityTypeCode NVARCHAR(50)=NULL,
	@BannerCode NVARCHAR(50)=NULL,
	@LogoCode NVARCHAR(50)=NULL,
	@Url NVARCHAR(256)=NULL,
	@CountryCode NVARCHAR(50)=NULL,
	@StateCode NVARCHAR(50)=NULL,
	@LgaCode NVARCHAR(50)=NULL,
	@Motto NVARCHAR(50)=NULL,
	@Notes NVARCHAR(MAX)=NULL,
	@EstablishedYear INT=NULL,
	@CreatedOn DATETIME2(7)=NULL,
	@CreatedBy NVARCHAR(50)=NULL,
	@ModifiedOn DATETIME2(7)=NULL,
	@ModifiedBy NVARCHAR(50)=NULL,
	@Deleted BIT=NULL
	
)
AS
BEGIN TRY
BEGIN TRAN
SET NOCOUNT ON;

		IF NOT EXISTS (SELECT * FROM [SetUp].[Universities]  WHERE ([Code] = @Code) AND ([Deleted] = @Deleted))  
			BEGIN
				INSERT INTO [SetUp].[Universities] 
				(
					[Code],
					[Description],
					[UniversityTypeCode],
					[BannerCode],
					[LogoCode],
					[Url],
					[CountryCode],
					[StateCode],
					[LgaCode],
					[Motto],
					[Notes],
					[EstablishedYear],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@Code,
					@Description,
					@UniversityTypeCode,
					@BannerCode,
					@LogoCode,
					@Url,
					@CountryCode,
					@StateCode,
					@LgaCode,
					@Motto,
					@Notes,
					@EstablishedYear,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [SetUp].[Universities] 
				SET
					[Description]=@Description,
					[UniversityTypeCode]=@UniversityTypeCode,
					[BannerCode]=@BannerCode,
					[LogoCode]=@LogoCode,
					[Url]=@Url,
					[CountryCode]=@CountryCode,
					[StateCode]=@StateCode,
					[LgaCode]=@LgaCode,
					[Motto]=@Motto,
					[Notes]=@Notes,
					[EstablishedYear]=@EstablishedYear,
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

GRANT EXECUTE ON [SetUp].[SPUniversitiesInsertUpdate] TO PUBLIC