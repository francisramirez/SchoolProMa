

using Microsoft.Extensions.Logging;
using SchoolProMa.Course.Domain.Entities;
using SchoolProMa.Course.Domain.Interfaces;
using SchoolProMa.Course.Persistance.Context;
using SchoolProMa.Course.Persistance.Exceptions;
using System.Linq.Expressions;

namespace SchoolProMa.Course.Persistance.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _schoolContext;

        private readonly ILogger<CourseRepository> _logger;
        public CourseRepository(SchoolContext context, ILogger<CourseRepository> logger)
        {
            _schoolContext = context;
            _logger = logger;
        }
        public bool Exists(Expression<Func<Domain.Entities.Course, bool>> filter)
        {
            return this._schoolContext.Courses.Any(filter);
        }

        public List<Domain.Entities.Course> GetAll()
        {
            return this._schoolContext.Courses.ToList();
        }

        public Domain.Entities.Course GetEntityBy(int Id)
        {
            Domain.Entities.Course? course = null;
            try
            {
                course = this._schoolContext.Courses.Find(Id);

                if (course is null)
                    throw new CourseException("El curso no se encuentra registrado.");


                return course;

            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo el curso.", ex.ToString());

            }
            return course;
        }

        public void Remove(Domain.Entities.Course entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad curso no puede nulo.");


                Domain.Entities.Course? courseToRemove = this._schoolContext.Courses.Find(entity.Id);

                if (courseToRemove is null)
                    throw new CourseException("El curso que desea eliminar no se encuentra registrado.");

                courseToRemove.UserDeleted = entity.UserDeleted;
                courseToRemove.Deleted = entity.Deleted;
                courseToRemove.DeletedDate = entity.DeletedDate;

                _schoolContext.Courses.Update(courseToRemove);
                this._schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error removiendo el curso", ex.ToString());
            }
        }

        public void Save(Domain.Entities.Course entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad curso no puede nulo.");


                if (Exists(co => co.Title.Equals(entity.Title)))
                    throw new CourseException("El curso se encuentra registrado.");


                _schoolContext.Courses.Add(entity);
                _schoolContext.SaveChanges();
            }
            catch (Exception ex)
            {

                this._logger.LogError("Error agregando el curso", ex.ToString());
            }
        }

        public void Update(Domain.Entities.Course entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad curso no puede nulo.");


                Domain.Entities.Course? courseToUpdate = this._schoolContext.Courses.Find(entity.Id);

                if (courseToUpdate is null)
                    throw new CourseException("El curso que desea actualizar no se encuentra registrado.");

                courseToUpdate.Title = entity.Title;
                courseToUpdate.Credits = entity.Credits;
                courseToUpdate.DepartmentID = entity.DepartmentID;
                courseToUpdate.ModifyDate = entity.ModifyDate;
                courseToUpdate.UserMod = entity.UserMod;

                _schoolContext.Courses.Update(courseToUpdate);
                _schoolContext.SaveChanges();

            }
            catch (Exception ex)
            {

                this._logger.LogError("Error actualizando el curso.", ex.ToString());
            }
        }
    }
}
