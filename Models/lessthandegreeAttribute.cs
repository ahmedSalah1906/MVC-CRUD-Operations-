using MVC_day2_task1_the_lab_one.View_Model;
using System.ComponentModel.DataAnnotations;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class lessthandegreeAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
             var mine=(int)value;
            var deg=(CourseWithListOfDepatment)validationContext.ObjectInstance;
            if (deg.degree > mine)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("please the degree must greater than minidagree");
        }
    }
}
