using CourseAPI.Models;

namespace CourseAPI {
    public class Course {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Teacher Lecturer { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
