using Microsoft.AspNetCore.Mvc;
using MVC_day2_task1_the_lab_one.Models;
using MVC_day2_task1_the_lab_one.View_Model;


namespace MVC_day2_task1_the_lab_one.Controllers
{
    public class InstructorController : Controller
    {
        InstituteContext context = new InstituteContext();
        public IActionResult Index()
        {
            var context = new InstituteContext();
            var allInst=context.Instructors.ToList();

            return View("allInstructor",allInst);
            
        }
        public IActionResult Detlise(int id)
        {
            var context =new InstituteContext();
            var inst_byId = context.Instructors.FirstOrDefault(x => x.Id == id);
                
            return View("Detlise", inst_byId);
        }
        [HttpGet]
        public ActionResult Add() 
        {
            var InstructorVM = new InstructorModelViewBylistOfDep_Crs();
            InstructorVM.Departments=context.Departments.ToList();  
            InstructorVM.Courses=context.Courses.ToList();  

            return View("Add",InstructorVM);
        }
        [HttpPost]
        public ActionResult SaveAdd(InstructorModelViewBylistOfDep_Crs InsFromReq) 
        {
            
            if( InsFromReq.Name != null && InsFromReq.salary > 2000 && InsFromReq.address != null )
            {
                var instructor = new Instructor
                {Id = InsFromReq.Id,
                Name = InsFromReq.Name,
                address = InsFromReq.address,
                salary = InsFromReq.salary,
                image_url = InsFromReq.image_url,
                CourseID = InsFromReq.CourseID,
                DepartmentId=InsFromReq.DepartmentId
                

                };
                context.Add( instructor );
                context.SaveChanges();
                return RedirectToAction("Index");


            }
            InsFromReq.Courses = context.Courses.ToList();
            InsFromReq.Departments = context.Departments.ToList();
           
            return View("Add", InsFromReq);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Instructor inst = context.Instructors.FirstOrDefault(i => i.Id == Id);
            var instVM = new InstructorModelViewBylistOfDep_Crs();
            instVM.Id = inst.Id;
            instVM.Name = inst.Name;
            instVM.image_url = inst.image_url;
            instVM.address = inst.address;
            instVM.salary = inst.salary;
            instVM.CourseID = inst.CourseID;
            instVM.DepartmentId = inst.DepartmentId;

            instVM.Departments = context.Departments.ToList();
            instVM.Courses = context.Courses.ToList();

            return View("Edit", instVM);



        }
        public IActionResult SaveEdit(InstructorModelViewBylistOfDep_Crs InsFromReq)
        {
            if (InsFromReq.Name != null && InsFromReq.salary > 2000 && InsFromReq.address != null)
            {

                var instructor = context.Instructors.FirstOrDefault(i => i.Id == InsFromReq.Id);
                if (instructor != null)
                {
                    instructor.Name = InsFromReq.Name;
                    instructor.image_url = InsFromReq.image_url;
                    instructor.address = InsFromReq.address;
                    instructor.salary = InsFromReq.salary;
                    instructor.CourseID = InsFromReq.CourseID;
                    instructor.DepartmentId = InsFromReq.DepartmentId;

                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }


            InsFromReq.Courses = context.Courses.ToList();
            InsFromReq.Departments = context.Departments.ToList();
            return View("Edit", InsFromReq);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetCoursesRelatedToDept(int id)
        {
            var course = context.Courses.Where(x=>x.DepartmentId ==id).ToList();
            return Json(course);
        }



    }
}
