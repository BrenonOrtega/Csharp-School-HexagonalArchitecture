using Serilog;
using System;
using System.Linq;
using SchoolApp.Application.Services;
using SchoolApp.Application.Dtos.CreateDtos;
using System.Threading.Tasks;

namespace SchoolApp.Application.Demo
{
    public static class StudentServiceDemo
    {
        ///<Summary> Testing out directly retrieving and saving a student with the dependency injection container.</Summary>    
        internal async static Task Run(IStudentService service)
        {
            var allstudents = await service.RetrieveMultiple(0, 100);
            allstudents.ToList().ForEach(x => Log.Logger.Information("{student}", x));

            var newStudent = new StudentCreateDto { LastName = "Test", FirstName = "Json", BirthDate = DateTime.Now, Email = "bryan.test@hotmail.com" };
            await service.Create(newStudent);

            Log.Logger.Information("Student: {Student}", newStudent);

            var studentToUpdate = allstudents.First();

            studentToUpdate.FirstName = "Updated from Demo!";
            await service.Update(studentToUpdate);
        }
    }
}