using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace MVC_day2_task1_the_lab_one.Models
{
    public class InstituteContext : IdentityDbContext<ApplicationUser>
    {

        public InstituteContext() : base()
        { }
        public InstituteContext(DbContextOptions<InstituteContext> options) : base(options) { }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course > Courses { get; set; }
        public DbSet<Traniee> Tranies { get; set; }
        public DbSet<TranieeCourse> tranieeCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "DOT NET", ManagerName = "ali" },
                 new Department() { Id = 2, Name = "PHP", ManagerName = "ahmed", },
                  new Department() { Id = 3, Name = "CS", ManagerName = "omar", },
                   new Department() { Id = 4, Name = "SD", ManagerName = "amr", }
                   );
            modelBuilder.Entity<Instructor>().HasData(
               new Instructor() { Id = 1, image_url = "1.jpg", Name = "ahmed", address = "cairo", salary = 12000, CourseID = 1, DepartmentId = 1 },
               new Instructor() { Id = 2, image_url = "2.jpg", Name = "ali", address = "alex", salary = 12500, CourseID = 2, DepartmentId = 2 },
               new Instructor() { Id = 3, image_url = "3.jpg", Name = "amr", address = "monufia", salary = 13000, CourseID = 3, DepartmentId = 3 },
               new Instructor() { Id = 4, image_url = "4.jpg", Name = "omar", address = "tanta", salary = 14000, CourseID = 4, DepartmentId = 4 }
               );
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, Name = "OOP", degree = 100, mindegree = 60, DepartmentId = 1 },
                new Course() { Id = 2, Name = "HTML5", degree = 100, mindegree = 60, DepartmentId = 2 },
                new Course() { Id = 3, Name = "CSS3", degree = 100, mindegree = 60, DepartmentId = 3 },
                new Course() { Id = 4, Name = "EF", degree = 100, mindegree = 60, DepartmentId = 4 }
                );
            modelBuilder.Entity<Traniee>().HasData(
                new Traniee() { Id=1,Name="Ahmed",imageUrl="1.jpg",address="Alex",DepartmentId=1,Grade=98},
                new Traniee() { Id = 2, Name = "Ismael", imageUrl = "2.jpg", address = "Cairo", DepartmentId = 1, Grade = 88 },
                new Traniee() { Id = 3, Name = "mohamed", imageUrl = "3.jpg", address = "Tanta", DepartmentId = 2, Grade = 78 },
                new Traniee() { Id = 4, Name = "Ahmed", imageUrl = "4.jpg", address = "Gia", DepartmentId = 2, Grade = 88 }
                );
            modelBuilder.Entity<TranieeCourse>().HasData(
                new TranieeCourse() {Id=1 ,TranieeId=1,Courseid=2,degree=88,},
                 new TranieeCourse() { Id = 2, TranieeId =1, Courseid = 1, degree = 98, },
                  new TranieeCourse() { Id = 3, TranieeId = 1, Courseid = 3, degree = 66, },
                   new TranieeCourse() { Id = 4, TranieeId = 1, Courseid = 4, degree = 40, },
                    new TranieeCourse() { Id = 5, TranieeId = 2, Courseid = 1, degree = 88, },
                     new TranieeCourse() { Id = 6, TranieeId = 2, Courseid = 4, degree = 12, }


                );



            base.OnModelCreating(modelBuilder);
        }









        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AHMEDSALAHPC\\SQLEXPRESS;Database=InstituteDB;Trusted_Connection=True;Encrypt=False");
        }

    }
    
}
