using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_day2_task1_the_lab_one.Models;
using MVC_day2_task1_the_lab_one.View_Model;

namespace MVC_day2_task1_the_lab_one.Controllers
{
    public class TraineeController : Controller
    {
        InstituteContext context= new InstituteContext();
        public IActionResult AllTrainees()
        {
            var Trainees=context.Tranies.ToList();
            var Department =context.Departments.ToList();
            var traineesVm = new List<TraineesWithDeptName>();
            foreach (var trainee in Trainees)
            {
                var department = Department.FirstOrDefault(d => d.Id == trainee.DepartmentId);

                var TraineeVm = new TraineesWithDeptName()
                {
                    Id = trainee.Id,
                    Name = trainee.Name,
                    Address = trainee.address,
                    Image = trainee.imageUrl,
                    DeptId = (int)trainee.DepartmentId,
                    DepartmentName = department.Name
                };
                traineesVm.Add(TraineeVm);
            }
            return View("AllTrainees", traineesVm);
        }
        public IActionResult ShowResult(int id, int crsId)
        {
            var traineeVM = new TraineeWithCourseNameAndDegree();
            var trainee = context.Tranies.FirstOrDefault(t => t.Id == id);
            var course = context.Courses.FirstOrDefault(c => c.Id == crsId);
            var courseResult = context.tranieeCourses.FirstOrDefault(c => c.TranieeId == id&&c.Courseid==crsId);

            if (trainee != null && course != null && courseResult != null)
            {
                traineeVM.Id = id;
                traineeVM.Name = trainee.Name;
                traineeVM.CourseName = course.Name;
                traineeVM.CourseDegree = course.degree;
                traineeVM.CourseMinDegree = course.mindegree;
                traineeVM.TraineeDegree = courseResult.degree;
                traineeVM.SuccOrFail = courseResult.degree >= course.mindegree;
            }
            else
            {
                return NotFound();
            }

            return View("traineeResult", traineeVM);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            
            var trainee = context.Tranies
                .Where(t => t.Id == id)
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.imageUrl,
                    t.address,
                    t.DepartmentId
                })
                .SingleOrDefault();

            if (trainee == null)
            {
                return NotFound(); // Return a 404 if the trainee is not found
            }

            // Retrieve the department from the database
            var department = context.Departments
                .Where(d => d.Id == trainee.DepartmentId)
                .Select(d => new
                {
                    d.Name
                })
                .SingleOrDefault();

            // Map to the view model
            var traineeVM = new TraineeWithCourses
            {
                Id = trainee.Id,
                Name = trainee.Name,
                Image = trainee.imageUrl,
                Address = trainee.address,
                Department = department?.Name,
                Courses = context.tranieeCourses
                    .Where(g => g.TranieeId == id)
                    .Select(g => new CourseWithNameAndIDViewModel
                    {
                        CourseId = (int)g.Courseid,
                        CourseName = g.Course.Name
                    }).ToList()
            };

            return View("TraineeDetails", traineeVM);
        }


        [HttpGet]
        public IActionResult TraineeSearch(string name)
        {
            var trainees = context.Tranies.ToList();

            var departments = context.Departments.ToList();

            var filteredTrainees = trainees.Where(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            List<TraineesWithDeptName> traineesVm = new List<TraineesWithDeptName>();

            foreach (var trainee in filteredTrainees)
            {
                var department = departments.FirstOrDefault(d => d.Id == trainee.DepartmentId);

                var traineeVm = new TraineesWithDeptName
                {
                    Id = trainee.Id,
                    Address = trainee.address,
                    Image = trainee.imageUrl,
                    Name = trainee.Name,
                    DeptId = (int)trainee.DepartmentId,
                    DepartmentName = department?.Name,


                };

                traineesVm.Add(traineeVm);
            }
            return View("AllTrainees", traineesVm);
        }

    }
}
