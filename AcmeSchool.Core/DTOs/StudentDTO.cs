using System.ComponentModel.DataAnnotations;

namespace AcmeSchool.Core.DTOs
{
    public class StudentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Student lastname is required")]
        [MaxLength(50)]
        public string? lastName { get; set; }

        [Required]
        [Range(18, 99, ErrorMessage = "The age must be between 18 to 99 years")]
        public int Age { get; set; }

        public List<CourseDTO> EnrolledCourses { get; set; } = new List<CourseDTO>();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            StudentDTO other = (StudentDTO)obj;
            return Id == other.Id &&
                   Name == other.Name &&
                   lastName == other.lastName
                   && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, lastName, Age);
        }
    }
}
