using Microsoft.Extensions.DependencyInjection;
using SchoolProMa.Course.Application.Contracts;
using SchoolProMa.Course.Application.Services;
using SchoolProMa.Course.Domain.Interfaces;
using SchoolProMa.Course.Persistance.Repositories;

namespace SchoolProMa.Course.IOC.Dependencies
{
    public static class CourseDependency
    {
        public static void AddCourseDependency(this IServiceCollection service) 
        {
            #region"Repositorios"
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            service.AddScoped<ICourseRepository, CourseRepository>();
            #endregion

            #region "Services"
            service.AddTransient<ICourseService, CourseService>();
            #endregion

        }
    }
}
