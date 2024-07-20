namespace SchoolProMa.Web.Models
{
    public class BaseResult
    {
        public string? message { get; set; }
        public bool success { get; set; }
        
   
    }
    public class CourseGetResult : BaseResult
    {
        public List<CourseModel> result { get; set; }
    }


    public class CourseModel 
    {
        public int courseId { get; set; }
        public string? title { get; set; }
        public int credit { get; set; }
        public int departmentId { get; set; }
        public string? departmentName { get; set; }
        public DateTime creationDate { get; set; }
    }



}
