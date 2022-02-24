using CourseAPI.Models;
using CourseAPI.Services.Teachers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseAPI.Services.Courses {
    public class CourseService : ICourseService {

        private readonly DataContext _context;
        private readonly ITeacherService _teacherService;
        public CourseService(DataContext dataContext, ITeacherService teacherService) {
            _context = dataContext;
            _teacherService = teacherService;
        }

        public async Task<bool> DeleteAsync(int id) {
            var toDelete = await _context.Course.FirstOrDefaultAsync(c => c.Id == id);
            if (toDelete != null) {
                _context.Course.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                throw new Exception($"Course with id {id} not found");
        }

        public async Task<Course> GetByIdAsync(int id) {
            var course = await _context.Course.Include(course => course.Lecturer).Include(course => course.Students).FirstOrDefaultAsync(c => c.Id == id);
            //find out what is the best way to ensure no exceptions and it should happen here
            return course;

        }

        public async Task<List<Course>> GetCoursesAsync() {
            return await _context.Course.Include(course => course.Lecturer).Include(course => course.Students).ToListAsync();
        }

        public async Task<Course> UpdateAsync(Course course) {
            var toUpdate = await _context.Course.FirstOrDefaultAsync(c => c.Id == course.Id);
            var lecturer = await _teacherService.GetByIdAsync(course.Lecturer.Id);
            toUpdate.Name = course.Name;
            toUpdate.Description = course.Description;
            toUpdate.Lecturer = lecturer;
            _context.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }

        async Task<Course> ICourseService.AddAsync(Course course, int id) {
            var exists = await _context.Course.AnyAsync(c => c.Name.Equals(course.Name) || c.Description.Equals(course.Description));
            var teacher = await _teacherService.GetByIdAsync(id);

            if (exists) {
                //display name and id of course that already exists but has different name or description than the one that was ment to be added
                throw new Exception($"This course is already added to the databse");
            }

            course.Lecturer = teacher;
            EntityEntry<Course> added = await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();
            return added.Entity;
        }



    }
}
