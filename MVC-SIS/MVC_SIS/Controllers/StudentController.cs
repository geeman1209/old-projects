using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            if (string.IsNullOrEmpty(studentVM.Student.FirstName))
            {
                ModelState.AddModelError("Student.FirstName", "Please enter the student's first name");
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

            if (string.IsNullOrEmpty(studentVM.Student.LastName))
            {
                ModelState.AddModelError("Student.LastName", "Please enter the student's last name");
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

            if (studentVM.Student.Major == null)
            {
                ModelState.AddModelError("Student.Major", "Please select a major for the student");
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var model = new StudentVM();
            model.SetCourseItems(CourseRepository.GetAll());
            model.SetMajorItems(MajorRepository.GetAll());
            model.SetStateItems(StateRepository.GetAll());
            model.Student = StudentRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM student)
        {
            student.Student.Courses = new List<Course>();

            foreach (var id in student.SelectedCourseIds)
                student.Student.Courses.Add(CourseRepository.Get(id));

            student.Student.Major = MajorRepository.Get(student.Student.Major.MajorId);

            StudentRepository.SaveAddress(student.Student.StudentId, student.Student.Address);
            StudentRepository.Edit(student.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var model = new StudentVM();
            model.Student = StudentRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}