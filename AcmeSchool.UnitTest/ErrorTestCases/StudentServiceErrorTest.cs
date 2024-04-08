using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.UnitTest.ErrorTestCases
{
    public class StudentServiceErrorTest
    {
        private readonly IStudentService? _studentService;

        public StudentServiceErrorTest()
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            // IStudentService interface configuration
            _studentService = serviceProvider.GetService<IStudentService>();
        }

        [Fact]
        public void GetStudentById_Returns_Error()
        {
            // Arrange
            int studentId = -1;

            var expectedResponse = new ResponseDTO<StudentDTO>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ERROR,
                DataResponse = new StudentDTO()
            };

            // Act
            var actualResponse = _studentService?.GetStudentById(studentId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
        }

        [Fact]
        public void GetAllStudents_Returns_Error()
        {
            // Arrange
            var expectedResponse = new ResponseDTO<List<StudentDTO>>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.LIST_STUDENT_ERROR,
                DataResponse = new List<StudentDTO>()
            };

            // Act
            var actualResponse = _studentService?.GetAllStudents();

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
            Assert.Empty(actualResponse.DataResponse);
        }

        [Fact]
        public void CreateStudent_Returns_Error()
        {
            // Arrange
            var studentDTO = new StudentDTO();

            var expectedResponse = new ResponseDTO<StudentDTO>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ERROR,
                DataResponse = new StudentDTO()
            };

            // Act
            var actualResponse = _studentService?.CreateStudent(studentDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
        }

        [Fact]
        public void DeleteStudent_Returns_Error()
        {
            // Arrange
            int studentId = -1;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.ELIMINATED_STUDENT_ERROR,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService?.DeleteStudent(studentId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
        }

        [Fact]
        public void ValidateCoursePayment_Returns_Error()
        {
            // Arrange
            int courseId = -1;
            double coursePayment = -1850;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.ERROR,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService?.ValidateCoursePayment(courseId, coursePayment);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
        }

        [Fact]
        public void AddCourseToStudent_Returns_Error()
        {
            // Arrange
            int studentId = -1;
            var studentDTO = new CourseDTO() { Id = 52 };


            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ERROR,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService.AddCourseToStudent(studentId, studentDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void UpdateStudent_Returns_Error()
        {
            // Arrange
            var studentDTO = new StudentDTO() { Id = 52};

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ERROR,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService.UpdateStudent(null);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void RemoveCourse_Returns_Error()
        {
            // Arrange
            int studentId = -1;
            var courseDTO = new CourseDTO() { Id = 53};

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ERROR,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService.RemoveCourse(studentId, courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void GetAllCourseByDate_Returns_Error()
        {
            // Arrange
            string initDate = "2025-01-01";
            string endDate = "2024-12-31";

            var expectedResponse = new ResponseDTO<List<StudentDTO>>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.LIST_COURSE_ERROR,
                DataResponse = new List<StudentDTO>()
            };

            // Act
            var actualResponse = _studentService.GetAllCourseByDate(initDate, endDate);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
            Assert.Empty(actualResponse.DataResponse);
        }
    }
}
