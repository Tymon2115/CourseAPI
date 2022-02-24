using CourseAPI.Models;
using CourseAPI.Services.Teachers;
using Microsoft.AspNetCore.Mvc;


namespace CourseAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase {
        private ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService) {
            _teacherService = teacherService;

        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> Get() {
            try {
                var teachers = await _teacherService.GetTeachersAsync();
                return Ok(teachers);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> Get([FromRoute] int id) {
            try {
                var teahcer = await _teacherService.GetByIdAsync(id);
                return Ok(teahcer);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> Post([FromBody] Teacher teacher) {
            try {
                var added = await _teacherService.Addteacher(teacher);
                return Ok(added);
            }
            catch (Exception ex) {

                return StatusCode(500, ex.Message);
            }


        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> Put([FromRoute] int id, [FromBody] Teacher teacher) {
            try {
                var edited = await _teacherService.UpdateAsync(id, teacher);
                return Ok(edited);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id) {
            try {
                await _teacherService.DeleteAsync(id);
                return Ok($"Succesfuly deleted teacher with id {id}");
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);

            }
        }
    }
}
