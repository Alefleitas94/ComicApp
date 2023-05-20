CREATE PROCEDURE [hero].[heroes_getbyid](
	@Id INT 
)
AS
BEGIN

	SET NOCOUNT ON;	 
	SELECT 
			id = H.id,
			[Name] = H.[name], 
			Gender = H.gender,
			Publisher = H.publisher,
		    FirstAppearance = H.first_appearance,
			CreatedAt = H.created_at
	FROM hero.heroes H
		
	WHERE H.id = @Id
END

/*
--------------------------------------------------------------------------------
-- TEST
--------------------------------------------------------------------------------

EXEC [hero].[heroes_getbyid]
	@Id = 1

--------------------------------------------------------------------------------
*/
