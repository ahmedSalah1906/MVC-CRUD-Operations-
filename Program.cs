using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_day2_task1_the_lab_one.Models;
using MVC_day2_task1_the_lab_one.Repository;

namespace MVC_day2_task1_the_lab_one
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);


            });

            builder.Services.AddDbContext<InstituteContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>().
                AddEntityFrameworkStores<InstituteContext>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseStaticFiles();

                app.UseSession();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();

            }
}
    }



