CREATE OR REPLACE FUNCTION public.DeleteStudentById(student_id INTEGER) 
RETURNS BOOLEAN
AS $$
DECLARE successful BOOLEAN;
BEGIN
    DELETE FROM public.aluno WHERE aluno.id=student_id;
    IF ROW_COUNT = 1  THEN
        successful := TRUE;
    ELSE 
        successful := FALSE;
    END IF;
    RETURN successful;
    EXCEPTION WHEN OTHERS THEN RAISE;
END;
$$
LANGUAGE 'plpgsql';