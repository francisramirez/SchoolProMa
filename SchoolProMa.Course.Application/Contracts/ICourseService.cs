
using SchoolProMa.Course.Application.Base;
using SchoolProMa.Course.Application.Dtos;

namespace SchoolProMa.Course.Application.Contracts
{
    public interface ICourseService
    {
        ServiceResult GetCourses();
        ServiceResult GetCourseById(int id);
        ServiceResult UpdateCourse(CourseDtoUpdate courseDtoUpdate);
        ServiceResult RemoveCourse(CourseDtoRemove courseDtoRemove);
        ServiceResult SaveCourse(CourseDtoSave courseDtoSave);
    }
}
