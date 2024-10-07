using Microsoft.AspNetCore.Mvc;

namespace MVC_day2_task1_the_lab_one.Controllers
{
    public class StateController : Controller
    {
        
            public IActionResult SetSession(string name)
            {
                
                
                HttpContext.Session.SetString("Name", name);
                HttpContext.Session.SetInt32("Age", 12);
               
                return Content("Session Data Saved");
            }

            public IActionResult GetSession()
            {
             
                string name = HttpContext.Session.GetString("Name");
                int age = HttpContext.Session.GetInt32("Age").Value;
                
                return Content($"name={name}\t age={age}");

            }


            public IActionResult setCookie()
            {
                
                HttpContext.Response.Cookies.Append("Name", "Ahmed");
               
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1); ;
                HttpContext.Response.Cookies.Append("Age", "12", options);
                return Content("Cookie SAve");

            }
            public IActionResult GetCookie()
            {
               
                string name = HttpContext.Request.Cookies["Name"];
                string age = HttpContext.Request.Cookies["Age"];
                
                return Content($"name={name} \t age={age}");

            }
        }
    }

