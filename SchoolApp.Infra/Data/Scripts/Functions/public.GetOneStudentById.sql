CREATE OR REPLACE FUNCTION public.GetOneStudentById(student_id INTEGER)
RETURNS TABLE("Id" INTEGER, "FirstName" VARCHAR, "LastName" VARCHAR, "BirthDate" DATE)
AS $$
BEGIN
    RETURN QUERY SELECT * FROM aluno WHERE aluno.id = student_id;
END;
$$
LANGUAGE 'plpgsql';

