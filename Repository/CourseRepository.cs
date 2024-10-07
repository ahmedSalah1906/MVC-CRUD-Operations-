using MVC_day2_task1_the_lab_one.Models;

namespace MVC_day2_task1_the_lab_one.Repository
{
   
    
        public class CourseRepository : ICourseRepository
        {
           InstituteContext context;

            public CourseRepository(InstituteContext context)
            {
                this.context = context;
            }

            public void Delete(int id)
            {
                Course course = GetById(id);
                context.Remove(course);
            }

            public List<Course> GetAll()
            {
                return context.Courses.ToList();
            }

            public List<Course> GetByDeptID(int deptID)
            {
                return context.Courses.Where(c => c.Id == deptID).ToList();
            }

            public Course GetById(int id)
            {
                return context.Courses.FirstOrDefault(c => c.Id == id);
            }

            public void Insert(Course obj)
            {
                context.Add(obj);
            }

            public void Save()
            {
                context.SaveChanges();
            }

            public void Update(Course obj)
            {
                context.Update(obj);
            }
        }
    }

