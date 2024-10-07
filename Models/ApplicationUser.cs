using Microsoft.AspNetCore.Identity;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class ApplicationUser:IdentityUser
    {
        public  string Address { get; set; }
    }
}
