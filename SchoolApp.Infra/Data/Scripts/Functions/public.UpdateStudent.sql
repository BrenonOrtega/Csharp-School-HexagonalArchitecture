-- FUNCTION: public.updatestudent(character varying, character varying, timestamp without time zone, character varying)

-- DROP FUNCTION public.updatestudent(character varying, character varying, timestamp without time zone, character varying);

CREATE OR REPLACE FUNCTION public.updatestudent(
	first_name character varying,
	last_name character varying,
	birth_date timestamp without time zone,
	e_mail character varying)
    RETURNS TABLE(id integer, firstname character varying, lastname character varying, birthdate date, email character varying) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
DECLARE updated_student INTEGER;
BEGIN
    UPDATE public.aluno AS a 
	SET primeiro_nome = first_name,
		ultimo_nome = last_name,
		data_nascimento = birth_date,
		email = e_mail
		RETURNING a.id INTO updated_student;
    RETURN QUERY SELECT * FROM public.aluno WHERE aluno.id = updated_student;
END;
$BODY$;

ALTER FUNCTION public.updatestudent(character varying, character varying, timestamp without time zone, character varying)
    OWNER TO "Bryan";

SELECT * FROM public.updatestudent(first_name:=@FirstName, last_name:=@LastName, birth_date:=@BirthDate, e_mail:= @Email);
