namespace MVC_day2_task1_the_lab_one.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int degree { get; set; } 
        public  int mindegree { get; set; }
        public int? Hours { get; set; }  
        public int? DepartmentId { get; set; }
        public virtual Department  Department { get; set; }

    }
}
