

namespace SchoolProMa.Course.Application.Dtos
{
    public class CourseDtoUpdate
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }
    }
}
