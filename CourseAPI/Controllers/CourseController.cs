using CourseAPI.Services.Teachers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        [HttpGet("{id}")]
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCourse([FromRoute] int id) {
            try {
                await _courseService.DeleteAsync(id);
                return Ok($"Course succesfully deleted for id {id}");
            }
            catch (Exception ex) {
                return StatusCode(404, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> EditCourse([FromRoute] int id, [FromBody] Course course) {
            try {
                var edited = await _courseService.UpdateAsync(id, course);
                return Ok(edited);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }


        }

    }
}
