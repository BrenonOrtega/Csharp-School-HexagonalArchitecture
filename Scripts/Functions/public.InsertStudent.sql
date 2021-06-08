-- TO RUN THIS ON WINDOWS IN PSQL TERMINAL YOU SHOULD ADD QUOTES TO THE SCRIPT PATH.
-- EX: psql.exe
-- \i 'c:/my_path/to_script/file_here/file.sql'
-- REMARKS: THE SLASH SHOULD NOT BE THE INVERTED SLASH, IT SHOULD REALLY BE '/'.

-- FUNCTION: public.insertstudent(character varying, character varying, timestamp without time zone)

-- DROP FUNCTION public.insertstudent(character varying, character varying, timestamp without time zone);

CREATE OR REPLACE FUNCTION public.insertstudent(
	first_name character varying,
	last_name character varying,
	birth_date timestamp)
    RETURNS TABLE(id integer, firstname character varying, lastname character varying, birthdate date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE new_student_id INTEGER;
BEGIN
    INSERT INTO public.aluno AS a (primeiro_nome, ultimo_nome, data_nascimento) 
        VALUES  (first_name, last_name, birth_date) 
		RETURNING a.id INTO new_student_id;
    RETURN QUERY SELECT * FROM public.aluno WHERE aluno.id = new_student_id;
END;
$BODY$;

--ALTER FUNCTION public.insertstudent(character varying, character varying, timestamp without time zone) OWNER TO "<YOUR USERNAME HERE>";

-- USE EXAMPLE
-- SELECT * FROM public.insertstudent('Hey, i''m testing', 'this handmade function', current_date);
