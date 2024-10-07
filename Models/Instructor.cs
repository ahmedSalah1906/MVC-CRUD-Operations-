using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string image_url { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
         public decimal salary { get; set; }
        public string address { get; set; }

        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }
        public int? DepartmentId { get; set; }   
         public virtual Department Department { get; set; }




    }
}
