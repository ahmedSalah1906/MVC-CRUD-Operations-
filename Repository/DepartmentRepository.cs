using MVC_day2_task1_the_lab_one.Models;

namespace MVC_day2_task1_the_lab_one.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        InstituteContext context;
        public string Id { get; set; }

        public DepartmentRepository(InstituteContext context)
        {
            this.context = context;
        }


        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department obj)
        {
            context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            context.Update(obj);
        }
    }
}