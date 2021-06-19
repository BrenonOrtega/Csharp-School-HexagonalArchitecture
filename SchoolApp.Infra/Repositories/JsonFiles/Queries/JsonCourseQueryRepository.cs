using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories.Queries;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Infra.Repositories.JsonFiles.Queries
{
    public class JsonCourseQueryRepository : ICourseQueryRepository
    {
        public Task<IEnumerable<Course>> GetAll(int page, int rowCount)
        {
            throw new System.NotImplementedException();
        }

        public Task<Course> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Course> GetByName(Name name)
        {
            throw new System.NotImplementedException();
        }
    }
}