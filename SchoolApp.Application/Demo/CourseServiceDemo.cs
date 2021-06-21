using Serilog;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SchoolApp.Application.Services;
using SchoolApp.Application.Dtos.CreateDtos;

namespace SchoolApp.Application.Demo
{
    public class CourseServiceDemo
    {
        internal static async Task Run(ICourseService service)
        {
             var randomId = RandomNumberGenerator.GetInt32(5,50);
            var newCourse = new CourseCreateDto { Id = randomId, Name="Some course im using to test " + randomId };
            await service.Create(newCourse);

            var queriedCourse = await service.Retrieve(id: 1);
            Log.Logger.Information("{queriedCourse}", queriedCourse);
 
            var courses = await service.RetrieveMultiple(3, 2);
            courses.ToList().ForEach(course => Log.Logger.Information("{courses}", course));

            var courseToUpdate = courses.First(x => x.Id >= RandomNumberGenerator.GetInt32(100) );
            Log.Logger.Information("{CourseToUpdate}", courseToUpdate);
            courseToUpdate.Name = "Updated from demo, wow.";
            await service.Update(courseToUpdate); 
        }
    }
}