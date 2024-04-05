using AcmeSchool.Core.Entities;

namespace AcmeSchool.Core.DTOs
{
    public class StudentDTO
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<CourseDTO>? EnrolledCourses { get; set; }
    }
}
