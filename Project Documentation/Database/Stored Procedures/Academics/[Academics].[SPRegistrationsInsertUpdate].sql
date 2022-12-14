USE [UniversityDB]
GO
/****** Object:  StoredProcedure [Academics].[SPRegistrationsInsertUpdate]    Script Date: 08/14/2011 12:00:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Author			:	Ademola Adebo
--Reviewer			:	Godwin Mathias	
--Date Created		:	07/18/2011 
--Last Updated		:	07/18/2011 
--Last Updated By	:	Ademola Adebo
--Description		:	Stored procedure for saving values into Academics.Registrations Table

ALTER PROC [Academics].[SPRegistrationsInsertUpdate]
(
	@Code BIGINT=NULL,
	@UniversityCode NVARCHAR(50)=NULL,
	@FacultyCode BIGINT=NULL,
	@DepartmentCode BIGINT=NULL,
	@CourseCode BIGINT=NULL,
	@ProgramCode BIGINT=NULL,
	@LevelCode INT=NULL,
	@StudentCode BIGINT=NULL,
	@MatricNo NVARCHAR(50)=NULL,
	@SessionCode BIGINT=NULL,
	@SemesterCode BIGINT=NULL,
	@TypeCode NVARCHAR(50)=NULL,
	@SubCourseCode BIGINT=NULL,
	@Status NVARCHAR(50)=NULL,
	@TicketCode NUMERIC(18,0)=NULL,
	@PinCode NUMERIC(18,0)=NULL,
	@Signed BIT=NULL,
	@SignedBy NVARCHAR(50)=NULL,
	@SignedOn DATETIME2(7)=NULL,
	@SelfSigned BIT=NULL,
	@SelfSignedOn DATETIME2(7)=NULL,
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

		IF NOT EXISTS (SELECT * FROM [Academics].[Registrations] WHERE ([Code] = @Code) AND ([UniversityCode] = @UniversityCode) AND ([Deleted] = @Deleted))
			BEGIN
				INSERT INTO [Academics].[Registrations] 
				(
					[UniversityCode],
					[FacultyCode],
					[DepartmentCode],
					[CourseCode],
					[ProgramCode],
					[LevelCode],
					[StudentCode],
					[MatricNo],
					[SessionCode],
					[SemesterCode],
					[TypeCode],
					[SubCourseCode],
					[Status],
					[TicketCode],
					[PinCode],
					[Signed],
					[SignedBy],
					[SignedOn],
					[SelfSigned],
					[SelfSignedOn],
					[CreatedOn],
					[CreatedBy],
					[Deleted]
					
				)
				VALUES
				(
					@UniversityCode,
					@FacultyCode,
					@DepartmentCode,
					@CourseCode,
					@ProgramCode,
					@LevelCode,
					@StudentCode,
					@MatricNo,
					@SessionCode,
					@SemesterCode,
					@TypeCode,
					@SubCourseCode,
					@Status,
					@TicketCode,
					@PinCode,
					@Signed,
					@SignedBy,
					@SignedOn,
					@SelfSigned,
					@SelfSignedOn,
					@CreatedOn,
					@CreatedBy,
					@Deleted
				
				)
			END
		ELSE
			BEGIN
				UPDATE [Academics].[Registrations] 
				SET
					[UniversityCode]=@UniversityCode,
					[FacultyCode]=@FacultyCode,
					[DepartmentCode]=@DepartmentCode,
					[CourseCode]=@CourseCode,
					[ProgramCode]=@ProgramCode,
					[LevelCode]=@LevelCode,
					[StudentCode]=@StudentCode,
					[MatricNo]=@MatricNo,
					[SessionCode]=@SessionCode,
					[SemesterCode]=@SemesterCode,
					[TypeCode]=@TypeCode,
					[SubCourseCode]=@SubCourseCode,
					[Status]=@Status,
					[TicketCode]=@TicketCode,
					[PinCode]=@PinCode,
					[Signed]=@Signed,
					[SignedBy]=@SignedBy,
					[SignedOn]=@SignedOn,
					[SelfSigned]=@SelfSigned,
					[SelfSignedOn]=@SelfSignedOn,
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

GRANT EXECUTE ON [Academics].[SPRegistrationsInsertUpdate] TO PUBLIC