CREATE PROCEDURE [hero].[Heroes_Search](
	@TextToSearch VARCHAR(250) = NULL,
	@ColumnToSort VARCHAR(250) = 'created_at desc',
	@PageIndex INT = 1,	
	@PageSize INT = 10
)
AS
BEGIN
	DECLARE	@FirstRow INT

	SET NOCOUNT ON;	 
	SET	@FirstRow = (@PageIndex - 1) * @PageSize;
	
	SELECT 
			id = H.id,
			[Name] = H.[name], 
			Gender = H.gender,
			Publisher = H.publisher,
		    FirstAppearance = H.first_appearance,
			CreatedAt = H.created_at,
			--Ordenamiento
			RowNumber = ROW_NUMBER() OVER (ORDER BY      
					(CASE UPPER(@ColumnToSort)
						-- orden asc
						WHEN 'created_at ASC' THEN CONVERT(VARCHAR(20), H.created_at, 121)
					END) ASC,	
					(CASE 
						-- orden desc
				WHEN UPPER(@ColumnToSort) = 'created_at DESC' THEN CONVERT(VARCHAR(20), H.created_at, 121)
				WHEN @ColumnToSort IS NULL THEN CONVERT(VARCHAR(20), H.created_at, 121)
					END) DESC),
			TotalRows = COUNT_BIG(*) OVER()

	
	FROM hero.heroes H
		
	WHERE    @TextToSearch IS NULL 
			 OR H.[name] LIKE '%'+ @TextToSearch + '%'

	ORDER BY RowNumber 
	OFFSET @FirstRow ROWS
	FETCH NEXT @PageSize ROWS Only

END

/*
--------------------------------------------------------------------------------
-- TEST
--------------------------------------------------------------------------------

EXEC [hero].[heroes_search]
	@TextToSearch = NULL,
	@ColumnToSort  = 'created_at desc',
	@PageIndex = 1,	
	@PageSize = 20

--------------------------------------------------------------------------------
*/