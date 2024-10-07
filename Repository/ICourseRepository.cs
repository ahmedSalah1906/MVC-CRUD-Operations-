using MVC_day2_task1_the_lab_one.Models;

namespace MVC_day2_task1_the_lab_one.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetByDeptID(int deptID);
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course obj);
        void Update(Course obj);
        void Delete(int id);
        void Save();
    }
}
