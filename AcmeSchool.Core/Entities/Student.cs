using System.ComponentModel.DataAnnotations;

namespace AcmeSchool.Core.Entities
{
    internal class Student
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Student lastname is required")]
        [MaxLength(50)]
        public string lastName { get; set; }

        [Required]
        [Range(18, 99, ErrorMessage = "The age must be between 18 to 99 years")]
        public int Age { get; set; }

        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
    }
}