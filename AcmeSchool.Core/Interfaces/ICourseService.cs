using AcmeSchool.Core.DTOs;

namespace AcmeSchool.Core.Interfaces
{
    public interface ICourseService
    {
        public ResponseDTO<CourseDTO> GetCourseById(int courseId);

        public ResponseDTO<ResponseMessage> UpdateCourse(CourseDTO courseDTO);

        public ResponseDTO<ResponseMessage> AddCourse(CourseDTO course);

        public ResponseDTO<ResponseMessage> DeleteCourse(CourseDTO course);

        public ResponseDTO<List<CourseDTO>> GetAllCourse();
    }
}
