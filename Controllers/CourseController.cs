using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_day2_task1_the_lab_one.Models;
using MVC_day2_task1_the_lab_one.Repository;
using MVC_day2_task1_the_lab_one.View_Model;

namespace MVC_day2_task1_the_lab_one.Controllers
{
    public class CourseController : Controller
    {
        //public InstituteContext context = new InstituteContext();
        ICourseRepository courseRepository;
        IDepartmentRepository DepartmentRepository;
        public CourseController(ICourseRepository crsRepo, IDepartmentRepository deptRepo)
        {
            courseRepository = crsRepo;
            DepartmentRepository = deptRepo;
        }

            public IActionResult AllCourses()
        {
            var Courses = courseRepository.GetAll();
            return View("AllCourses", Courses);

        }
        public IActionResult Detalis(int id)
        {
            var Course = courseRepository.GetById(id);
            if (Course == null)
            {
                return NotFound();
            }
            return View("courseDetalis", Course);

        }
        public IActionResult Add()
        {
            var courseVm = new CourseWithListOfDepatment();
            courseVm.departments = DepartmentRepository.GetAll();
            return View("Add", courseVm);


        }
        public IActionResult SaveAdd(CourseWithListOfDepatment CrSDept)
        {
            if (ModelState.IsValid)
            {
                var Course = new Course
                {
                    Id = CrSDept.Id,
                    Name = CrSDept.Name,
                    degree = CrSDept.degree,
                    DepartmentId = CrSDept.DepartmentId,
                    mindegree = CrSDept.mindegree,

                };
                courseRepository.Insert(Course);
               courseRepository.Save();
                return RedirectToAction("AllCourses");

            }
            CrSDept.departments = DepartmentRepository.GetAll();
            return View("Add", CrSDept);

        }
        public IActionResult Edit(int id)
        {
            var course = courseRepository.GetById(id);
            var courseVm = new CourseWithListOfDepatment();
            courseVm.Id = course.Id;
            courseVm.degree = course.degree;
            courseVm.mindegree = course.mindegree;
            courseVm.Hours = (int)course.Hours;
            courseVm.Name = course.Name;
            courseVm.DepartmentId = course.DepartmentId;
            courseVm.departments = DepartmentRepository.GetAll();
            return View("Edit", courseVm);


        }
        public IActionResult SaveEdit(CourseWithListOfDepatment courseFromRequest)
        {
           
            if (ModelState.IsValid)
            {
                var course = courseRepository.GetById(courseFromRequest.Id);
                
                if (course != null)
                {
                    

                    course.Name = courseFromRequest.Name;
                    course.degree = courseFromRequest.degree;
                    course.mindegree = courseFromRequest.mindegree;
                    course.Hours = courseFromRequest.Hours;
                    course.DepartmentId = courseFromRequest.DepartmentId;

                    
                   courseRepository.Save();

                    
                    return RedirectToAction("AllCourses");
                }
            }


            courseFromRequest.departments = DepartmentRepository.GetAll();
            return View("Edit", courseFromRequest);
        }

    }
}

