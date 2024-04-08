using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.UnitTest.NoDataTestCases
{
    public  class StudentServiceNoDataTest
    {
        private readonly IStudentService? _studentService;

        public StudentServiceNoDataTest()
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            // IStudentService interface configuration
            _studentService = serviceProvider.GetService<IStudentService>();
        }

        [Fact]
        public void GetStudentById_Returns_NoData()
        {
            // Arrange
            int studentId = -1; // Using a non-existent student ID

            var expectedResponse = new ResponseDTO<StudentDTO>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA,
                DataResponse = new StudentDTO() // Empty StudentDTO
            };

            // Act
            var actualResponse = _studentService?.GetStudentById(studentId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
        }

        [Fact]
        public void CreateStudent_Returns_NoData()
        {
            // Arrange
            var studentDTO = new StudentDTO(); // Empty StudentDTO

            var expectedResponse = new ResponseDTO<StudentDTO>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.STUDENT_IS_NULL,
                DataResponse = new StudentDTO() // Empty StudentDTO
            };

            // Act
            var actualResponse = _studentService.CreateStudent(studentDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void UpdateStudent_Returns_NoData()
        {
            // Arrange
            var studentDTO = new StudentDTO(); // Empty StudentDTO

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ID_NOT_FOUND,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService.UpdateStudent(studentDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void RemoveCourse_Returns_NoData()
        {
            // Arrange
            int studentId = -1; // Using a non-existent student ID
            var courseDTO = new CourseDTO(); // Empty CourseDTO

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA,
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
        public void DeleteStudent_Returns_NoData()
        {
            // Arrange
            int studentId = 0;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA,
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
        public void ValidateCoursePayment_Returns_NoData()
        {
            // Arrange
            int courseId = 1;
            double coursePayment = 50;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.COURSE_COST,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService.ValidateCoursePayment(courseId, coursePayment);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void AddCourseToStudent_Returns_NoData()
        {
            // Arrange
            int studentId = -1;
            var courseDTO = new CourseDTO();

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.STUDENT_IS_NULL,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _studentService?.AddCourseToStudent(studentId, courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void GetAllStudents_Returns_NoData()
        {
            // Arrange
            var expectedResponse = new ResponseDTO<List<StudentDTO>>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_STUDENT,
                DataResponse = new List<StudentDTO>()
            };

            // Act
            var actualResponse = _studentService.GetAllStudents();

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
            Assert.Empty(actualResponse.DataResponse); // Ensure the list is empty
        }

        [Fact]
        public void GetAllCourseByDate_Returns_NoData()
        {
            // Arrange
            string initDate = "2025-01-01"; // Using a future date
            string endDate = "2024-12-31"; // Using a past date

            var expectedResponse = new ResponseDTO<List<StudentDTO>>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_COURSE,
                DataResponse = new List<StudentDTO>()
            };

            // Act
            var actualResponse = _studentService.GetAllCourseByDate(initDate, endDate);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
            Assert.Empty(actualResponse.DataResponse); // Ensure the list is empty
        }


    }
}
