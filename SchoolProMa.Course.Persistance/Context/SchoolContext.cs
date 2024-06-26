using Microsoft.EntityFrameworkCore;
using SchoolProMa.Course.Domain.Entities;

namespace SchoolProMa.Course.Persistance.Context
{
    public class SchoolContext : DbContext
    {

        #region"Constructor"
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        #endregion

        #region"Db Sets"
        public DbSet<Department> Departments { get; set; }
        public DbSet<Domain.Entities.Course> Courses { get; set; }
        #endregion
    }
}
