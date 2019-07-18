using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
        Student getStudent(int id);
        IEnumerable<Student> getAllStudents();
        Student addStudent(Student s);
        Student update(Student student);
        Student deleteStudent(int id);
    }
}
