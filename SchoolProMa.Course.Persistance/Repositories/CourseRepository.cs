

using SchoolProMa.Course.Domain.Interfaces;
using System.Linq.Expressions;

namespace SchoolProMa.Course.Persistance.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Course, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Course> GetCoursesByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Course GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Course entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Course entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
