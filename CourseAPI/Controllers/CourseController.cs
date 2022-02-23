using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase {
        private DataContext _context;

        public CourseController(DataContext context) {
            _context = context;

        }


        [HttpGet]
        public async Task<IActionResult> GetCourses() {

            return Ok(await _context.Courses.ToListAsync());
        }

    }
}
