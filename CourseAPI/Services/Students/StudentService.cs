using CourseAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CourseAPI.Services.Students {
    public class StudentService : IStudentService {
        private DataContext _context;

        public StudentService(DataContext dataContext) {
            _context = dataContext;
        }

        public async Task<Student> CreateAsync(Student student) {
            EntityEntry<Student> added = await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            if (added != null)
                return added.Entity;
            else
                throw new Exception("failed why adding the student");
        }

        public async Task<bool> DeleteAsync(string cpr) {
            var toDelete = await _context.Student.FirstOrDefaultAsync(s => s.Cpr.Equals(cpr));
            if (toDelete != null) {
                _context.Student.Remove(toDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                throw new Exception($"No student with cpr {cpr} found");
        }

        public async Task<Student> GetByIdAsync(string cpr) {
            var student = await _context.Student.FirstOrDefaultAsync(s => s.Cpr.Equals(cpr));
            if (student == null) {
                throw new Exception($"No student with cpr {cpr} found");
            }

            return student;
        }

        public async Task<List<Student>> GetStudentsAsync() {
            var students = await _context.Student.ToListAsync();
            if (students == null) {
                throw new Exception($"No students found");
            }
            return students;
        }

        public async Task<Student> UpdateAsync(string cpr, Student student) {
            var toUpdate = await _context.Student.FirstOrDefaultAsync(s => s.Cpr.Equals(cpr));
            if (toUpdate == null) {
                throw new Exception($"No student with cpr {cpr} found");

            }
            else {
                toUpdate.FirstName = student.FirstName;
                toUpdate.LastName = student.LastName;
                _context.Student.Update(toUpdate);
                await _context.SaveChangesAsync();
                return toUpdate;
            }

        }
    }
}
