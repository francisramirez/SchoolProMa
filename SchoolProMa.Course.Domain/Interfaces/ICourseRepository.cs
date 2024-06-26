

using SchoolProMa.Common.Data.Repository;
using SchoolProMa.Course.Domain.Entities;

namespace SchoolProMa.Course.Domain.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Domain.Entities.Course,int>
    {
        List<Course.Domain.Entities.Course> GetCoursesByDepartmentId(int departmentId);

        
    }
}
