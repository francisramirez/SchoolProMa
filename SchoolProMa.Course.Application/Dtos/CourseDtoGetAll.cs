

namespace SchoolProMa.Course.Application.Dtos
{
    public class CourseDtoGetAll
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public decimal Credit { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
