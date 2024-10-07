namespace MVC_day2_task1_the_lab_one.View_Model
{
    public class TraineeWithCourseNameAndDegree
    {
         public int Id { get; set; }
        public string Name { get; set; }

        public string CourseName { get; set; }

        public int CourseDegree { get; set; }
        public int CourseMinDegree { get; set; }

        public int TraineeDegree { get; set; }

        public bool SuccOrFail { get; set; }

    }
}
