namespace MVC_day2_task1_the_lab_one.Models
{
    public class TranieeCourse
    {
        public int Id { get; set; }
       public int degree {  get; set; }
        public int? Courseid { get; set; }
        public int ? TranieeId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Traniee Traniee { get; set; }

    }
}
