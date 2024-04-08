using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.UnitTest.SuccessTestCases
{
    public class StudentServiceSuccessTest
    {
        private readonly IStudentService? _studentService;

        public StudentServiceSuccessTest()
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            // IStudentService interface configuration
            _studentService = serviceProvider.GetService<IStudentService>();
        } 

        [Fact]
        public void GetStudentById_Returns_StudentDTO_Success()
        {
            // Arrange
            int studentId = 1;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.OK,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService?.GetStudentById(studentId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.True(actualResponse?.DataResponse?.Id > 0);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void CreateStudent_Returns_SuccessResponse()
        {
            // Arrange
            var studentDTO = new StudentDTO
            {
                Id = 51,
                Name = "Clara",
                lastName = "Marss",
                EnrolledCourses = new List<CourseDTO>(),
                Age = 25
            };

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.OK,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService.CreateStudent(studentDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void UpdateStudent_Returns_SuccessResponse()
        {
            // Arrange
            var studentDTO = new StudentDTO
            {
                Id = 8,
                Name = "Mario",
                lastName = "Castaño",
                EnrolledCourses = new List<CourseDTO>(),
                Age = 33
            };

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.STUDENT_UPDATE_SUCCESS,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService.UpdateStudent(studentDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void DeleteStudent_Returns_SuccessResponse()
        {
            // Arrange
            int studentId = 1;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.ELIMINATED_STUDENT,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService.DeleteStudent(studentId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void ValidateCoursePayment_Returns_SuccessResponse()
        {
            // Arrange
            int courseId = 1;
            double coursePayment = 1500;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {   
                ResponseMessage = StatusDescriptionMessage.OK,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService.ValidateCoursePayment(courseId, coursePayment);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void AddCourseToStudent_Returns_SuccessResponse()
        {
            // Arrange
            int studentId = 1;
            var courseDTO = new CourseDTO
            {
                Id = 52,
                Name = "Advance Programming Python Course",
                RegistrationFee = 3000,
                EndDate = DateTime.Now.AddMonths(1),
                StartDate = DateTime.Now.AddMonths(7)
            };

            // Act

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.OK,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            var actualResponse = _studentService.AddCourseToStudent(studentId, courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void RemoveCourse_Returns_SuccessResponse()
        {
            // Arrange
            int studentId = 1;
            var courseDTO = new CourseDTO
            {
                Id = 2,
                Name = "Programming in Python Course",
                RegistrationFee = 3000,
                EndDate = DateTime.Now.AddMonths(1),
                StartDate = DateTime.Now.AddMonths(7)
            };

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.COURSE_DETETED,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService.RemoveCourse(studentId, courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
        }

        [Fact]
        public void GetAllStudents_Returns_ListOfStudentDTO_Success()
        {
            // Arrange
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.OK,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService.GetAllStudents(1);


            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.NotNull(actualResponse.DataResponse);
            Assert.NotEmpty(actualResponse.DataResponse);
        }

        [Fact]
        public void GetAllCourseByDate_Returns_ListOfStudentDTO_Success()
        {
            // Arrange
            string initDate = "2023-01-01";
            string endDate = "2024-12-31";

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.OK,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _studentService?.GetAllCourseByDate(initDate, endDate);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
            Assert.NotNull(actualResponse?.DataResponse);
            Assert.NotEmpty(actualResponse.DataResponse);
        }
    } 

}
