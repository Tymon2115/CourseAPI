using CourseAPI.Models;

namespace CourseAPI.Services.Teachers {
    public interface ITeacherService {
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetTeachersAsync();
        Task<bool> DeleteAsync(int id);
        Task<Teacher> UpdateAsync(int id, Teacher teacher);
        Task<Teacher> Addteacher(Teacher teacher);

    }
}
