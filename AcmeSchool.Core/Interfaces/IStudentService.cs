using AcmeSchool.Core.DTOs;

namespace AcmeSchool.Core.Interfaces
{
    public interface IStudentService
    {
        public ResponseDTO<StudentDTO> GetStudentById(int studentId);
        public ResponseDTO<StudentDTO> CreateStudent(StudentDTO student);
        public ResponseDTO<ResponseMessage> UpdateStudent(StudentDTO student);
        public ResponseDTO<ResponseMessage> DeleteStudent(int studentId);
        public ResponseDTO<ResponseMessage> ValidatePayment(StudentDTO student);
        public ResponseDTO<ResponseMessage> AddCourseToStudent(int studentId, CourseDTO course);
        public ResponseDTO<ResponseMessage> RemoveCourse(int studentId, CourseDTO course);
        public ResponseDTO<List<StudentDTO>> GetAllStudents();
        public ResponseDTO<List<StudentDTO>> GetAllCourseByDate(string initDate, string endDate);
    }
}