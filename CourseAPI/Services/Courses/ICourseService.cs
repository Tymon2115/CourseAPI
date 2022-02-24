namespace CourseAPI.Services.Courses {
    public interface ICourseService {

        Task<Course> AddAsync(Course course, int id);
        Task<Course> GetByIdAsync(int id);
        Task<List<Course>> GetCoursesAsync();
        Task<bool> DeleteAsync(int id);
        Task<Course> UpdateAsync(int id, Course course);
    }
}
