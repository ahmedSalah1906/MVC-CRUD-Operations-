using Microsoft.AspNetCore.Mvc;
using MVC_day2_task1_the_lab_one.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_day2_task1_the_lab_one.View_Model
{
    public class CourseWithListOfDepatment
    {
        public int Id { get; set; }
        [MaxLength(length: 25)]
        [MinLength(2, ErrorMessage = "Name Must Be More Than 3 Char")]
        [Required]
        [unique(ErrorMessage="the name is already exisest")]
        public string Name { get; set; }
        [Range(20,100)]
        [Required]
        public int degree { get; set; }
        
        [Required]
        [lessthandegree]
        public int mindegree { get; set; }
        [divededbythree(ErrorMessage ="the hours must be devid by 3")]
        [Required]
        public int Hours { get; set; }

        [NotallowZero(ErrorMessage ="please select department")]
       
        public int? DepartmentId { get; set; }
        public List<Department>? departments { get; set; }
    }
}
