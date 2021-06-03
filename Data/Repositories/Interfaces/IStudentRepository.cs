using System.Collections.Generic;
using FirstDataAccess.Data.Models;

namespace FirstDataAccess.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAll(); 
        Student FindById(int id);
        Student FindByName(string name);
        int Create(Student student);
        void DeleteOne(Student student);

        
    }
}