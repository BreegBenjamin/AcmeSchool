using AcmeSchool.Core.DTOs;

namespace AcmeSchool.Core.Interfaces
{
    public interface IStudentService
    {
        public ResponseDTO<StudentDTO> GetStudentById(int studentId);
        public ResponseDTO<StudentDTO> CreateStudent(StudentDTO student);
        public ResponseDTO<ResponseMessage> UpdateStudent(StudentDTO student);
        public ResponseDTO<ResponseMessage> DeleteStudent(int studentId);
        public ResponseDTO<ResponseMessage> ValidateCoursePayment(int courseId, double coursePayment);
        public ResponseDTO<ResponseMessage> AddCourseToStudent(int studentId, CourseDTO course);
        public ResponseDTO<ResponseMessage> RemoveCourse(int studentId, CourseDTO course);
        public ResponseDTO<List<StudentDTO>> GetAllStudents(int proccess = 0);
        public ResponseDTO<List<StudentDTO>> GetAllCourseByDate(string initDate, string endDate);
    }
}