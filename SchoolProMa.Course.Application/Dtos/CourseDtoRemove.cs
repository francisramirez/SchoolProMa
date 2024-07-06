
namespace SchoolProMa.Course.Application.Dtos
{
    public class CourseDtoRemove
    {
        public int Id { get; set; }
        public int UserDelete { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool Deleted { get; set; }
    }
}
