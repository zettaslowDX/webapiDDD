using System;

namespace CapgeminiDDD.Common.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Student student = obj as Student;
            return Name.Equals(student.Name) && Surname.Equals(student.Surname);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}