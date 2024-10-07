using System.ComponentModel.DataAnnotations;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class NotallowZeroAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           var id = (int) value;
            if (id == 0 )
            {
                return false;
            }
            return true;
        }
    }
}
