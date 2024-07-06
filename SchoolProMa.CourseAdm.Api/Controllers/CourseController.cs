using Microsoft.AspNetCore.Mvc;
using SchoolProMa.Course.Application.Contracts;
using SchoolProMa.Course.Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolProMa.CourseAdm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }


        
        [HttpGet("GetCourses")]
        public IActionResult Get()
        {
            var result = this.courseService.GetCourses();

            if (!result.Success) 
                return BadRequest(result);
            else
                return Ok(result);
          
        }

      
        [HttpGet("GetCourseById")]
        public IActionResult Get(int id)
        {
            var result = this.courseService.GetCourseById(id);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

      
        [HttpPost("SaveCourse")]
        public IActionResult Post([FromBody] CourseDtoSave dtoSave)
        {
            var result = this.courseService.SaveCourse(dtoSave);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

       
        [HttpPost("UpdateCourse")]
        public IActionResult Put(CourseDtoUpdate dtoUpdate)
        {
            var result = this.courseService.UpdateCourse(dtoUpdate);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

       
        [HttpPost("RemoveCourse")]
        public IActionResult Delete(CourseDtoRemove dtoRemove)
        {
            var result = this.courseService.RemoveCourse(dtoRemove);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
