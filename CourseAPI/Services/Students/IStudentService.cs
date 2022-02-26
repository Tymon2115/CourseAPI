using CourseAPI.Models;

namespace CourseAPI.Services.Students {
    public interface IStudentService {
        Task<Student> GetByIdAsync(string cpr);
        Task<List<Student>> GetStudentsAsync();
        Task<bool> DeleteAsync(string cpr);
        Task<Student> UpdateAsync(string cpr, Student student);
        Task<Student> CreateAsync(Student student);
    }
}

