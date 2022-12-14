USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPBioDatasInsertUpdate]    Script Date: 08/14/2011 13:47:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personals.BioDatas Table

ALTER PROC [Personals].[SPBioDatasInsertUpdate]
(
	@Code NVARCHAR(50)=NULL,
	@Surname NVARCHAR(50) = NULL,
	@MiddleName NVARCHAR(50)=NULL,
	@FirstName NVARCHAR(50)=NULL,
	@GenderCode NVARCHAR(50)=NULL,
	@CivilStatus NVARCHAR(50)=NULL,
	@DateOfBirth DATETIME=NULL,
	@CountryCode NVARCHAR(50)=NULL,
	@StateCode NVARCHAR(50)=NULL,
	@LGACode NVARCHAR(50)=NULL,
	@PlaceOfBirth NVARCHAR(50)=NULL,
	@Height NVARCHAR(50)=NULL,
	@Weight NVARCHAR(50)=NULL,
	@HealthStatusCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50)=NULL,
	@PositionInFamily INT=NULL,
	@NoOfChildren INT=NULL,
	@TicketCode NUMERIC(18,0)=NULL,
	@PinCode NUMERIC(18,0)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Personals].[BioDatas] WHERE (([Code] = @Code) AND ([ScreenCode]=@ScreenCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[BioDatas]
				(
					[Code],
					[Surname],
					[MiddleName],
					[FirstName],
					[GenderCode],
					[CivilStatus],
					[DateOfBirth],
					[CountryCode],
					[StateCode],
					[LGACode],
					[PlaceOfBirth],
					[Height],
					[Weight],
					[HealthStatusCode],
					[ScreenCode],
					[PositionInFamily],
					[NoOfChildren],
					[TicketCode],
					[PinCode],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@Code,
					@Surname,
					@MiddleName,
					@FirstName,
					@GenderCode,
					@CivilStatus,
					@DateOfBirth,
					@CountryCode,
					@StateCode,
					@LGACode,
					@PlaceOfBirth,
					@Height,
					@Weight,
					@HealthStatusCode,
					@ScreenCode,
					@PositionInFamily,
					@NoOfChildren,
					@TicketCode,
					@PinCode,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[BioDatas]
				SET
					[Surname]=@Surname,
					[MiddleName]=@MiddleName,
					[FirstName]=@FirstName,
					[GenderCode]=@GenderCode,
					[CivilStatus]=@CivilStatus,
					[DateOfBirth]=@DateOfBirth,
					[CountryCode]=@CountryCode,
					[StateCode]=@StateCode,
					[LGACode]=@LGACode,
					[PlaceOfBirth]=@PlaceOfBirth,
					[Height]=@Height,
					[Weight]=@Weight,
					[HealthStatusCode]=@HealthStatusCode,
					[ScreenCode]=@ScreenCode,
					[PositionInFamily]=@PositionInFamily,
					[NoOfChildren]=@NoOfChildren,
					[TicketCode]=@TicketCode,
					[PinCode]=@PinCode,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					(([Code] = @Code) AND ([ScreenCode]=@ScreenCode))
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

GRANT EXECUTE ON [Personals].[SPBioDatasInsertUpdate] TO PUBLIC