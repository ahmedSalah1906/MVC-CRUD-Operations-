namespace MVC_day2_task1_the_lab_one.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

       public ICollection<Instructor>? Instructors { get; set; } 
    }
}
