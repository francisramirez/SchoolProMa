using Microsoft.Extensions.Logging;
using SchoolProMa.Course.Application.Base;
using SchoolProMa.Course.Application.Contracts;
using SchoolProMa.Course.Application.Dtos;
using SchoolProMa.Course.Domain.Entities;
using SchoolProMa.Course.Domain.Interfaces;

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
                                 select new CourseDtoGetAll()
                                 {
                                     CourseId = course.Id,
                                     CreationDate = course.CreationDate,
                                     Credit = course.Credits,
                                     DepartmentId = depto.Id,
                                     DepartmentName = depto.Name,
                                     Title = course.Title
                                 }).ToList();


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
                if (courseDtoSave is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(courseDtoSave)} es requerido.";
                    return result;
                }

                if (courseRepository.Exists(course => course.Title == courseDtoSave.Title))
                {
                    result.Success = false;
                    result.Message = $"el curso {courseDtoSave.Title} ya encuentra registrado";
                    return result;
                }

                if (string.IsNullOrEmpty(courseDtoSave?.Title))
                {
                    result.Success = false;
                    result.Message = $"El titulo del curso es requerido.";
                    return result;
                }

                if (courseDtoSave?.Credits == 0 || courseDtoSave?.Credits < 0)
                {
                    result.Success = false;
                    result.Message = $"El credito del curso no puede ser cero o negativo.";
                    return result;
                }
                if (courseDtoSave?.DepartmentID == 0)
                {
                    result.Success = false;
                    result.Message = $"Debe seleccionar el departamento al que pertenece el curso.";
                    return result;
                }

                Domain.Entities.Course course = new Domain.Entities.Course()
                {
                    DepartmentID = courseDtoSave.DepartmentID,
                    Title = courseDtoSave.Title,
                    Credits = courseDtoSave.Credits,
                    CreationDate = courseDtoSave.CreationDate,
                    CreationUser = courseDtoSave.CreationUser
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
                if (courseDtoUpdate is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(courseDtoUpdate)} es requerido.";
                    return result;
                }

                if (string.IsNullOrEmpty(courseDtoUpdate?.Title))
                {
                    result.Success = false;
                    result.Message = $"El titulo del curso es requerido.";
                    return result;
                }

                if (courseDtoUpdate?.Credits == 0 || courseDtoUpdate?.Credits < 0)
                {
                    result.Success = false;
                    result.Message = $"El credito del curso no puede ser cero o negativo.";
                    return result;
                }
                if (courseDtoUpdate?.DepartmentID == 0)
                {
                    result.Success = false;
                    result.Message = $"Debe seleccionar el departamento al que pertenece el curso.";
                    return result;
                }

                Domain.Entities.Course course = new Domain.Entities.Course()
                {
                    DepartmentID = courseDtoUpdate.DepartmentID,
                    Title = courseDtoUpdate.Title,
                    Id = courseDtoUpdate.Id,
                    Credits = courseDtoUpdate.Credits,
                    ModifyDate = courseDtoUpdate.ModifyDate,
                    UserMod = courseDtoUpdate.ModifyUser
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
