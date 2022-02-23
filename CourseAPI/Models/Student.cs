global using System.ComponentModel.DataAnnotations;

namespace CourseAPI.Models {
    public class Student {
        [Key]
        public string Cpr { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
