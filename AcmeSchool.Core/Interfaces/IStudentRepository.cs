using AcmeSchool.Core.DTOs;

namespace AcmeSchool.Core.Interfaces
{
    public interface IStudentRepository
    {
        public ResponseDTO<StudentDTO> GetStudentById();

        public ResponseDTO<ResponseMessage> CreateStudent(StudentDTO student);

        public ResponseDTO<ResponseMessage> UpdateStudent(StudentDTO student);

        public ResponseDTO<ResponseMessage> DeleteStudent(int studentId);

        public ResponseDTO<ResponseMessage> ValidatePayment(StudentDTO student);

        public ResponseDTO<ResponseMessage> AddCourse(StudentDTO student, CourseDTO course);

        public ResponseDTO<ResponseMessage> RemoveCourse(StudentDTO student, CourseDTO course);

        public ResponseDTO<List<StudentDTO>> GetAllStudents();
        public ResponseDTO<List<CourseDTO>> GetAllCourseByStudent(int studentId);
    }
}