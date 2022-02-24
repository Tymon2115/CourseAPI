using CourseAPI.Models;

namespace CourseAPI.Services.Students {
    public interface IStudentService {
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetStudentsAsync();
        Task<Student> DeleteAsync(int id);
        Task<Student> UpdateAsync(Student student);
    }
}

