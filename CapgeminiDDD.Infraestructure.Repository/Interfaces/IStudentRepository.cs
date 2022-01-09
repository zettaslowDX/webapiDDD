using CapgeminiDDD.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infraestructure.Repository
{
    public interface IStudentRepository
    {
       public Task<Student> InsertStudentAsync(Student student);
        public Task<Student> UpdateStudentAsync(Student student);

        public void DeleteStudent(int id);
        public Task<Student> GetStudentByIdAsync(int id);

    }
}
