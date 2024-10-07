﻿namespace MVC_day2_task1_the_lab_one.View_Model
{
    public class TraineeWithCourses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public ICollection<CourseWithNameAndIDViewModel> Courses { get; set; }
    }
}
