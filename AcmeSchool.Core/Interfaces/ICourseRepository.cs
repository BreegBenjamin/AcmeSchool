using AcmeSchool.Core.DTOs;

namespace AcmeSchool.Core.Interfaces
{
    public interface ICourseRepository
    {
        public ResponseDTO<CourseDTO> GetCourseById();

        public ResponseDTO<CourseDTO> CreateCourse(CourseDTO course);

        public void UpdateCourse(CourseDTO student);

        public bool ValidateCoursePayment(CourseDTO student);

        public void AddCourse(CourseDTO course);

        public void DeleteCourse(CourseDTO course);

        public void RemoveStudnetFromCourse(StudentDTO student);

        public ResponseDTO<List<CourseDTO>> GetAllCourse();
    }
}
