using CourseAPI.Services.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase {
        private ICourseService _courseService;


        public CourseController(ICourseService courseService) {
            _courseService = courseService;

        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses() {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Course>> GetCourse([FromRoute] int id) {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) {
                return NotFound($"Course with id {id} does not exist!");
            }
            return Ok(course);

        }
        [HttpPost("Teacher/{id:int}")]
        public async Task<ActionResult<Course>> AddCourse([FromBody] Course course, [FromRoute] int id) {



            try {
                var added = await _courseService.AddAsync(course, id);
                return Ok(added);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
