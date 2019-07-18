using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository StudentRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IStudentRepository studentRepository,IHostingEnvironment hostingEnvironment)
        {
            StudentRepository = studentRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var result= StudentRepository.getAllStudents();
            return View(result);
        }

        public ViewResult Details(int? id)
        {
            throw new Exception("errorr");
            Student student = StudentRepository.getStudent(id.Value);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("Studentnotfound", id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                  Student = student,
                title = "Student Details"
            };
           
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(StudentCreateViewModel s)
        {
            if(ModelState.IsValid)
            {
                string filename = getimagepath(s);
                Student student1 = new Student
                {
                    Name=s.Name,
                    Department=s.Department,
                    Email=s.Email,
                    photopath=filename
                };
                Student student = StudentRepository.addStudent(student1);
                return RedirectToAction("details", new { id = student.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult edit(int id)
        {
            Student student = StudentRepository.getStudent(id);
            StudentEditViewModel s = new StudentEditViewModel { 
                Id = student.Id,
                Name=student.Name,
                Email=student.Email,
                Department=student.Department,
                existingphotopath=student.photopath
                };
            return View(s);
        }
        [HttpPost]
        public IActionResult edit(StudentEditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                Student student = StudentRepository.getStudent(editViewModel.Id);
                student.Name = editViewModel.Name;
                student.Email = editViewModel.Email;
                student.Department = editViewModel.Department;
                if(editViewModel.photo!=null)
                {
                    if (editViewModel.existingphotopath != null)
                    {
                        string photopath = Path.Combine(hostingEnvironment.WebRootPath, "images", editViewModel.existingphotopath);
                        System.IO.File.Delete(photopath);
                    }
                    student.photopath= getimagepath(editViewModel);
                }
                Student updatedStudent = StudentRepository.update(student);
                return RedirectToAction("details", new  { Id = updatedStudent.Id });
            }
            return View(editViewModel);
        }

        private string getimagepath(StudentCreateViewModel editViewModel)
        {
            string filename = null;
            if (editViewModel.photo != null)
            {
                string foldername = Path.Combine(hostingEnvironment.WebRootPath, "images");
                filename = Guid.NewGuid() + "_" + editViewModel.photo.FileName;
                string filepath = Path.Combine(foldername, filename);
                using (var filname = new FileStream(filepath, FileMode.Create))
                {
                    editViewModel.photo.CopyTo(filname);
                }
                
            }
            return filename;
        }
                
           
        
    }
}