

namespace SchoolProMa.Course.Application.Dtos
{
    public abstract class DtoBaseCourse : DtoBase
    {
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

    }
}
