using System;
using System.Linq;
using SchoolApp.Domain.Repositories.Commands;
using SchoolApp.Domain.Repositories.Queries;
using Serilog;

namespace SchoolApp.Application.Demo
{
    public class RepositoryDemo
    {
        ///<Summary> Testing out directly retrieving and saving a student with the dependency injection container.</Summary>    
        public async static void Run(IStudentCommandRepository cmder, IStudentQueryRepository querier)     
        {
            var student = await querier.GetById(1);
            Log.Logger.Information("student:{student}", student);

            await cmder.Save(new() { FirstName="Peter", LastName="Parker", BirthDate=DateTime.UtcNow });

            var students = await querier.GetAll(1, 100);
            Log.Logger.Information("Created Student {student}",  students.Last());
        }
    }
}