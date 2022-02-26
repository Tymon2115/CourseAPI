using CourseAPI.Models;
using CourseAPI.Services.Students;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService) {
            _studentService = studentService;

        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get() {
            try {
                var students = await _studentService.GetStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{cpr}")]
        public async Task<ActionResult<Student>> Get(string cpr) {
            try {
                var student = await _studentService.GetByIdAsync(cpr);
                return Ok(student);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student student) {

            try {
                var added = await _studentService.CreateAsync(student);
                return Ok(added);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }



        [HttpPut("{cpr}")]
        public async Task<ActionResult<Student>> Put(string cpr, [FromBody] Student student) {
            try {
                var eddited = await _studentService.UpdateAsync(cpr, student);
                return Ok(eddited);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }


        [HttpDelete("{cpr}")]
        public async Task<ActionResult> Delete(string cpr) {
            try {
                var deleted = await _studentService.DeleteAsync(cpr);
                return Ok();
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
