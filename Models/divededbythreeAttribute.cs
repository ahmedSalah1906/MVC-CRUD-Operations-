using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class divededbythreeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
          var num =(int) value; 
            if (num % 3 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
