CREATE PROCEDURE [hero].[Hero_Delete](
	@Id INT
)
AS
BEGIN

	DECLARE @IsSuccess BIT = 0,
			@Message VARCHAR(1000) = ''



	DECLARE @IsThereAnyHero INT  = (ISNULL((SELECT TOP 1 1 
													FROM hero.heroes H
													WHERE H.Id = @Id),0))
		
	SET XACT_ABORT ON
	SET NOCOUNT ON;
	BEGIN TRY 
		BEGIN TRANSACTION

			BEGIN
					IF(@IsThereAnyHero = 0)
						BEGIN
							SET @IsSuccess = CONVERT(BIT,0)
							SET @Message = 'El heroe que intenta eliminar no existe.'
						END
					ELSE
						BEGIN
							
							DELETE H
							FROM hero.heroes H
							WHERE H.id = @Id
							
							SET @IsSuccess = CONVERT(BIT,1)
							SET @Message = CONCAT('El heroe: ', @Id, ' se elimino exitósamente.')
						END 

			END 				
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH

       IF (XACT_STATE()) <> 0
	   BEGIN
	   		ROLLBACK TRANSACTION
	   END
		
	   DECLARE @Line INT = ERROR_LINE()
	   SET @IsSuccess = CONVERT(BIT, 0)
       SET @Message = CONCAT(ERROR_MESSAGE(), ' -Linea ' ,CONVERT(VARCHAR(10), @Line))
  
   END CATCH

END
GO

/*
-------------------------------------------
---TEST
-------------------------------------------

EXEC [hero].[hero_delete]
	 @Id = 5

SELECT * FROM hero.heroes
	
-------------------------------------------
*/

