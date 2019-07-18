using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void inserData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 1,
                   Name = "Kailash",
                   Email = "mkailashnadh@gmail.com",
                   Department = dept.CSE
               },
               new Student
               {
                   Id = 2,
                   Name = "Mounica",
                   Email = "mounicayelchuri@gmail.com",
                   Department = dept.MECH
               });
        }
    }
}
