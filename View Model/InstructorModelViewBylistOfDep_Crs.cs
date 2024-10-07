using MVC_day2_task1_the_lab_one.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_day2_task1_the_lab_one.View_Model
{
    public class InstructorModelViewBylistOfDep_Crs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string image_url { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal salary { get; set; }
        public string address { get; set; }
        public int? DepartmentId { get; set; }
        public int? CourseID { get; set; }

       public  List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }    
    }
}
