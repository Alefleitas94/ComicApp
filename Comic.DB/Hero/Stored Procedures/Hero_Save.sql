CREATE PROCEDURE [hero].[heroes_save](
	@Id INT = NULL,
	@Name VARCHAR(250),
	@FirstAppearance VARCHAR(250),
	@Publisher VARCHAR(250),
	@Gender VARCHAR(100),
	@CreatedAt DATETIME2(7)

)
AS
BEGIN

	DECLARE @IsSuccess BIT = 0,
			@Message VARCHAR(1000) = '',
			@Index INT = 1


	SET XACT_ABORT ON
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRANSACTION

			--Check if the @id is null
			IF(@Id IS NULL)
			BEGIN
				INSERT INTO hero.heroes([name],gender, first_appearance, publisher, created_at)
				SELECT 
					[name] = @Name,
					gender = @Gender,
					first_appearance = @FirstAppearance,
					publisher = @Publisher,
					created_at = @CreatedAt
				
				SET @Id = SCOPE_IDENTITY()

				SET @Message = CONCAT('Se creó el heroe con id: ', @Id, ' exitósamente.')
				SET @IsSuccess = CONVERT(BIT,1)
			END
			ELSE
			BEGIN
				UPDATE hero.heroes
					SET 
						[name] = @Name,
						gender = @Gender,
						first_appearance = @FirstAppearance,
						publisher = @Publisher,
						created_at = @CreatedAt
					WHERE id = @Id

				SET @Message = CONCAT('Se actualizo el heroe con id: ', @Id, ' exitósamente.')
				SET @IsSuccess = CONVERT(BIT,1)
			END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH

       IF (XACT_STATE()) <> 0
	   BEGIN
	   		ROLLBACK TRANSACTION
	   END
		
	   DECLARE @Linea INT = ERROR_LINE()
	   SET @IsSuccess = CONVERT(BIT, 0)
       SET @Message = CONCAT(ERROR_MESSAGE(), ' -Linea ' ,CONVERT(VARCHAR(10), @Linea))
  
   END CATCH

   SELECT
	IsSuccess = @IsSuccess,
	[Message] = @Message,
	Id = @Id

END
