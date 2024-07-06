

using SchoolProMa.Course.Application.Base;
using SchoolProMa.Course.Application.Dtos;

namespace SchoolProMa.Course.Application.Extentions
{
    public static class ValidCourse
    {
        public static ServiceResult IsValidCourse(this DtoBaseCourse baseCourse)
        {
            ServiceResult result = new ServiceResult();

            if (baseCourse is null)
            {
                result.Success = false;
                result.Message = $"El objeto{nameof(baseCourse)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseCourse?.Title))
            {
                result.Success = false;
                result.Message = $"El titulo del curso es requerido.";
                return result;
            }

            if (baseCourse?.Credits == 0 || baseCourse?.Credits < 0)
            {
                result.Success = false;
                result.Message = $"El credito del curso no puede ser cero o negativo.";
                return result;
            }
            if (baseCourse?.DepartmentID == 0)
            {
                result.Success = false;
                result.Message = $"Debe seleccionar el departamento al que pertenece el curso.";
                return result;
            }




            return result;
        }
    }
}
