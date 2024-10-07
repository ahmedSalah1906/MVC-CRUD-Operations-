namespace MVC_day2_task1_the_lab_one.Models
{
    public class Traniee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public string address { get; set; }
        public int Grade { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
