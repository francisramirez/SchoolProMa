

using Microsoft.Extensions.Logging;
using SchoolProMa.Course.Domain.Entities;
using SchoolProMa.Course.Domain.Interfaces;
using SchoolProMa.Course.Persistance.Context;
using System.Linq.Expressions;

namespace SchoolProMa.Course.Persistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SchoolContext context;
        private readonly ILogger<CourseRepository> logger;

        public DepartmentRepository(SchoolContext context, ILogger<CourseRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(Expression<Func<Department, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
           return this.context.Departments.ToList();
        }

        public Department GetEntityBy(int Id)
        {
            return this.context.Departments.Find(Id);  
        }

        public void Remove(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
