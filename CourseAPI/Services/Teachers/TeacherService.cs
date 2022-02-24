using CourseAPI.Models;

namespace CourseAPI.Services.Teachers {
    public class TeacherService : ITeacherService {

        private DataContext _dataContext;

        public TeacherService(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public Task<Teacher> Addteacher(Teacher teacher) {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<Teacher> GetByIdAsync(int id) {
            var teacher = await _dataContext.Teacher.FirstOrDefaultAsync(t => t.Id == id);
            Console.WriteLine(teacher.FirstName, teacher.LastName);
            if (teacher == null) {
                throw new Exception($"Teacher not found for id {id}");
            }

            return teacher;
        }

        public Task<List<Teacher>> GetTeachersAsync() {
            throw new NotImplementedException();
        }

        public Task<Teacher> UpdateAsync(Teacher teacher) {
            throw new NotImplementedException();
        }
    }
}
