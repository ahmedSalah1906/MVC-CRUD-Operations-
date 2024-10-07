using Microsoft.AspNetCore.Http.HttpResults;
using MVC_day2_task1_the_lab_one.View_Model;
using System.ComponentModel.DataAnnotations;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class uniqueAttribute : ValidationAttribute
    {
        private readonly InstituteContext context = new InstituteContext();

        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var courseIsThere = context.Courses.SingleOrDefault(s => s.Name == value.ToString());
                if (courseIsThere == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
                
            return true;
           
        }


    }
}