using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class sqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public sqlStudentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Student addStudent(Student s)
        {
            context.Student.Add(s);
            context.SaveChanges();
            return s;
        }

        public Student deleteStudent(int id)
        {
            Student s=context.Student.Find(id);
            if(s!=null)
            {
                context.Student.Remove(s);
                context.SaveChanges();
            }
            return s;
        }

        public IEnumerable<Student> getAllStudents()
        {
            return context.Student;
        }

        public Student getStudent(int id)
        {
            return context.Student.Find(id);
        }

        public Student update(Student student)
        {
            var s = context.Student.Attach(student);
            s.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return student;
        }
    }
}
