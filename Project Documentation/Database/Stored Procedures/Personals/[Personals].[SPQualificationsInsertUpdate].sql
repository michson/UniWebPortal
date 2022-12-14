USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Personals].[SPQualificationsInsertUpdate]    Script Date: 08/14/2011 14:00:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/08/2011 
--Last Updated		:	07/08/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Personals.Qualifications Table

ALTER PROC [Personals].[SPQualificationsInsertUpdate]
(
	@Code INT=NULL,
	@AccountCode NVARCHAR(50)=NULL,
	@ScreenCode NVARCHAR(50) = NULL,
	@EducationTypeCode NVARCHAR(50)=NULL,
	@QualificationTypeCode NVARCHAR(50)=NULL,
	@FromYear NVARCHAR(50)=NULL,
	@ToYear NVARCHAR(50)=NULL,
	@FromMonth NVARCHAR(50)=NULL,
	@ToMonth NVARCHAR(50)=NULL,
	@AwardingBody NVARCHAR(256)=NULL,
	@Certificate NVARCHAR(50)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Personals].[Qualifications] WHERE (([Code] = @Code) AND ([AccountCode]=@AccountCode) AND ([Deleted]=@Deleted)))
			BEGIN
				INSERT INTO [Personals].[Qualifications]
				(
					[AccountCode],
					[ScreenCode],
					[EducationTypeCode],
					[QualificationTypeCode],
					[FromYear],
					[ToYear],
					[FromMonth],
					[ToMonth],
					[AwardingBody],
					[Certificate],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
				)
				VALUES
				(
					@AccountCode,
					@ScreenCode,
					@EducationTypeCode,
					@QualificationTypeCode,
					@FromYear,
					@ToYear,
					@FromMonth,
					@ToMonth,
					@AwardingBody,
					@Certificate,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				)
			END
		ELSE
			BEGIN
				UPDATE [Personals].[Qualifications]
				SET
					[AccountCode]=@AccountCode,
					[ScreenCode]=@ScreenCode,
					[EducationTypeCode]=@EducationTypeCode,
					[QualificationTypeCode]=@QualificationTypeCode,
					[FromYear]=@FromYear,
					[ToYear]=@ToYear,
					[FromMonth]=@FromMonth,
					[ToMonth]=@ToMonth,
					[AwardingBody]=@AwardingBody,
					[Certificate]=@Certificate,
					[ModifiedOn]=@ModifiedOn,
					[ModifiedBy]=@ModifiedBy,
					[Deleted]=@Deleted
				WHERE
					(([Code] = @Code) AND ([AccountCode]=@AccountCode))
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

GRANT EXECUTE ON [Personals].[SPQualificationsInsertUpdate] TO PUBLIC