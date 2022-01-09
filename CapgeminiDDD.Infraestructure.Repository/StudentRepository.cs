using CapgeminiDDD.Common.Model;
using CapgeminiEF.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CapgeminiDDD.Infraestructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public readonly CapgeminiContext _context;

        public void DeleteStudent(int id)
        {
            var student = _context.Student.FirstOrDefault(d => d.Id == id); 
            _context.Student.Remove(student);
            _context.SaveChanges();
        }

        public async Task<Student> InsertStudentAsync(Student student)
        {
            using (CapgeminiContext context = new CapgeminiContext())
            {

                   _context.Add(student);
                   await _context.SaveChangesAsync();
                   return student;
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var dbStudent = await _context.Student
                            .FirstOrDefaultAsync(d => d.Id == student.Id);

            dbStudent.Name = student.Name;
            dbStudent.Surname = student.Surname;

            await _context.SaveChangesAsync();

            return dbStudent;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context
                .Student
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}