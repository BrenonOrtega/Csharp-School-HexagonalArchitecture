-- FUNCTION: public.getallstudents(integer, integer)

-- DROP FUNCTION public.getAllstudents(integer, integer);

CREATE OR REPLACE FUNCTION public.GetAllStudents(
	paging_page integer DEFAULT NULL::integer,
	paging_count integer DEFAULT NULL::integer)
    RETURNS TABLE ("Id" integer, "FirstName" character varying, "LastName" character varying, "BirthDate" date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE page_number BIGINT;
BEGIN
	IF (paging_count IS NOT NULL AND paging_page IS NOT NULL) THEN
		page_number := paging_count * (paging_page - 1);
	END IF;	
	RETURN QUERY 
	SELECT 
		a.id ,
		a.primeiro_nome ,
		a.ultimo_nome ,
		a.data_nascimento
	FROM public.aluno a
	ORDER BY Id
	LIMIT paging_count
	OFFSET page_number;
	EXCEPTION WHEN OTHERS THEN RAISE;
		
END;
$BODY$;

ALTER FUNCTION public.getallstudents(integer, integer)
    OWNER TO "Bryan";

-- THIS SHIT RIGHT HERE MAKE THE DAPPER CALL WORKS LOST A WHOLE DAY TO UNDERSTAND THAT I SHOULD QUERY IT LIKE A TABLE
-- SINCE WHAT I DEFINED AS A RETURN IS REALLY A TABLE!!!.
select * from getallstudents(1,10);
