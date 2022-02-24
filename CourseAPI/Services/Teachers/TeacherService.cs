using CourseAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseAPI.Services.Teachers {
    public class TeacherService : ITeacherService {

        private DataContext _context;

        public TeacherService(DataContext dataContext) {
            _context = dataContext;
        }

        public async Task<Teacher> Addteacher(Teacher teacher) {

            EntityEntry<Teacher> added = await _context.Teacher.AddAsync(teacher);
            await _context.SaveChangesAsync();
            if (added != null)
                return added.Entity;
            else
                throw new Exception("failed why adding the teacher");
        }

        public async Task<bool> DeleteAsync(int id) {
            var toDelete = await _context.Teacher.FirstOrDefaultAsync(t => t.Id == id);
            if (toDelete != null) {
                _context.Teacher.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Teacher> GetByIdAsync(int id) {
            var teacher = await _context.Teacher.FirstOrDefaultAsync(t => t.Id == id);

            if (teacher == null) {
                throw new Exception($"Teacher not found for id {id}");
            }

            return teacher;
        }

        public async Task<List<Teacher>> GetTeachersAsync() {
            var teachers = await _context.Teacher.ToListAsync();
            if (teachers.Count != 0) {
                return teachers;
            }
            else {
                throw new Exception("There are no teachers registered in the database");
            }
        }

        public async Task<Teacher> UpdateAsync(int id, Teacher teacher) {
            var toUpdate = await _context.Teacher.FirstOrDefaultAsync(t => t.Id == id);
            toUpdate.FirstName = teacher.FirstName;
            toUpdate.LastName = teacher.LastName;
            _context.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }
    }
}
