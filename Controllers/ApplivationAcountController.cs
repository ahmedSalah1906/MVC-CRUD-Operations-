using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_day2_task1_the_lab_one.Models;
using MVC_day2_task1_the_lab_one.View_Model;

namespace MVC_day2_task1_the_lab_one.Controllers;

public class ApplivationAcount : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;

    public ApplivationAcount(UserManager<ApplicationUser >userManager,
        SignInManager<ApplicationUser> signInManager )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
 

    public IActionResult Registertion()
    {
        return View("Registertion");
    }
    [HttpPost]
    public async Task< IActionResult> Registertion(RegisterViewModel userVm)
    {
        if(ModelState.IsValid)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userVm.UserName,
                PasswordHash = userVm.Password,
                Address = userVm.Address,
            };
         IdentityResult result= await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
              await signInManager.SignInAsync(user, isPersistent: false);
                RedirectToAction("Index", "Instructor");
            }
            else
            {
                foreach(var eror  in result.Errors)
                {
                    ModelState.AddModelError("", eror.Description);
                        
                }
            }
          
        }
        return View("Registertion", userVm);
    }
}
