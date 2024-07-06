

namespace SchoolProMa.Course.Application.Dtos
{
    public class CourseDtoSave
    {
        public string? Title { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
    }
}
