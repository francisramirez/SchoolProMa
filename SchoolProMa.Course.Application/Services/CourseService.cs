using Microsoft.Extensions.Logging;
using SchoolProMa.Course.Application.Base;
using SchoolProMa.Course.Application.Contracts;
using SchoolProMa.Course.Application.Dtos;
using SchoolProMa.Course.Domain.Interfaces;
using SchoolProMa.Course.Application.Extentions;
namespace SchoolProMa.Course.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILogger<CourseService> logger;

        public CourseService(ICourseRepository courseRepository,
                             IDepartmentRepository departmentRepository,
                             ILogger<CourseService> logger)
        {
            this.courseRepository = courseRepository;
            this.departmentRepository = departmentRepository;
            this.logger = logger;
        }
        public ServiceResult GetCourses()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var courses = this.courseRepository.GetAll();

                result.Result = (from course in courseRepository.GetAll()
                                 join depto in departmentRepository.GetAll() on course.DepartmentID equals depto.Id
                                 where course.Deleted == false
                                 select new CourseDtoGetAll()
                                 {
                                     CourseId = course.Id,
                                     CreationDate = course.CreationDate,
                                     Credit = course.Credits,
                                     DepartmentId = depto.Id,
                                     DepartmentName = depto.Name,
                                     Title = course.Title
                                 }).OrderByDescending(cd => cd.CreationDate).ToList();


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los cursos.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetCourseById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result.Result = (from course in courseRepository.GetAll()
                                 join depto in departmentRepository.GetAll() on course.DepartmentID equals depto.Id
                                 where course.Id == id
                                  && course.Deleted == false

                                 select new CourseDtoGetAll()
                                 {
                                     CourseId = course.Id,
                                     CreationDate = course.CreationDate,
                                     Credit = course.Credits,
                                     DepartmentId = depto.Id,
                                     DepartmentName = depto.Name,
                                     Title = course.Title
                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo el curso.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult RemoveCourse(CourseDtoRemove? courseDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (courseDtoRemove is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(courseDtoRemove)} es requerido.";
                    return result;
                }


                Domain.Entities.Course course = new Domain.Entities.Course()
                {
                    Id = courseDtoRemove.Id,
                    Deleted = courseDtoRemove.Deleted,
                    DeletedDate = courseDtoRemove.DeleteDate,
                    UserDeleted = courseDtoRemove.UserDelete
                };

                this.courseRepository.Remove(course);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error removiendo el curso.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveCourse(CourseDtoSave? courseDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = courseDtoSave.IsValidCourse();

                if (!result.Success)
                    return result;


                Domain.Entities.Course course = new Domain.Entities.Course()
                {
                    DepartmentID = courseDtoSave.DepartmentID,
                    Title = courseDtoSave.Title,
                    Credits = courseDtoSave.Credits,
                    CreationDate = courseDtoSave.ChangeDate,
                    CreationUser = courseDtoSave.ChangeUser
                };

                this.courseRepository.Save(course);


            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el curso.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }


            return result;

        }

        public ServiceResult UpdateCourse(CourseDtoUpdate courseDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = courseDtoUpdate.IsValidCourse();

                if (!result.Success)
                    return result;


                Domain.Entities.Course course = new Domain.Entities.Course()
                {
                    DepartmentID = courseDtoUpdate.DepartmentID,
                    Title = courseDtoUpdate.Title,
                    Id = courseDtoUpdate.Id,
                    Credits = courseDtoUpdate.Credits,
                    ModifyDate = courseDtoUpdate.ChangeDate,
                    UserMod = courseDtoUpdate.ChangeUser
                };

                this.courseRepository.Update(course);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el curso.";
                this.logger.LogError(message: result.Message, ex.ToString());
            }


            return result;
        }
    }
}
