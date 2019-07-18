using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> students;
        public MockStudentRepository()
        {
            students = new List<Student>()
            {
                new Student(){Id=1,Name="Kailash",Email="mkailashnadh@gmail.com",Department=dept.CSE},
                new Student() { Id = 2, Name = "Mounica", Email = "mounicayelchuri@gmail.com", Department = dept.ECE },
                new Student(){Id=3,Name="Sawan",Email="sawanmamidi@gmail.com",Department=dept.IT    }
        };
        }

        public Student addStudent(Student s)
        {
            s.Id = students.Max(e => e.Id)+1;
            students.Add(s);
            return s;
        }

        public Student deleteStudent(int id)
        {
          Student s=  students.FirstOrDefault(e => e.Id == id);
            if(s!=null)
            {
                students.Remove(s);
            }
            return s;
        }

        public IEnumerable<Student> getAllStudents()
        {
            return students;
        }

        public Student getStudent(int id)
        {
            return students.FirstOrDefault(s=>s.Id==id);
        }

        public Student update(Student student)
        {
            Student s = students.FirstOrDefault(e => e.Id == student.Id);
            if (s != null)
            {
                s.Name=student.Name;
                s.Email = student.Email;
                s.Department = student.Department;
            }
            return s;
        }
    }
}
