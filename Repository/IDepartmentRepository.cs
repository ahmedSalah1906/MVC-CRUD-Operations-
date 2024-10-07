using MVC_day2_task1_the_lab_one.Models;

namespace MVC_day2_task1_the_lab_one.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department obj);
        void Update(Department obj);
        void Delete(int id);
        void Save();
    }
}
