using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using Moq;

namespace AcmeSchool.Tests
{
    public class CourseServicesTest
    {
        private readonly ICourseService _courseService;

        public CourseServicesTest()
        {
            // Mock de la interfaz ICourseService
            var courseServiceMock = new Mock<ICourseService>();

            // Configurar métodos de la interfaz ICourseService si es necesario

            _courseService = courseServiceMock.Object;
        }

        [Fact]
        public void GetCourseById_Returns_CourseDTO()
        {
            // Arrange
            int courseId = 1;
            var expectedResponse = new ResponseDTO<CourseDTO>
            {
                DataResponse = new CourseDTO { Id = courseId, Name = "Math", RegistrationFee = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) },
                Status = ResponseMessageEnum.Success
            };

            // Act
            var actualResponse = _courseService.GetCourseById(courseId);

            // Assert
            Assert.Equal(expectedResponse.DataResponse, actualResponse.DataResponse);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }

        [Fact]
        public void UpdateCourse_Returns_SuccessResponse()
        {
            // Arrange
            var courseDTO = new CourseDTO { Id = 1, Name = "Math", RegistrationFee = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) };
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = "Course updated successfully." }
            };

            // Act
            var actualResponse = _courseService.UpdateCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Message, actualResponse.DataResponse?.Message);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }

        [Fact]
        public void AddCourse_Returns_SuccessResponse()
        {
            // Arrange
            var courseDTO = new CourseDTO { Id = 1, Name = "Math", RegistrationFee = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) };
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = "Course added successfully." }
            };

            // Act
            var actualResponse = _courseService.AddCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Message, actualResponse.DataResponse?.Message);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }

        [Fact]
        public void DeleteCourse_Returns_SuccessResponse()
        {
            // Arrange
            var courseDTO = new CourseDTO { Id = 1, Name = "Math", RegistrationFee = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) };
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = "Course deleted successfully." }
            };

            // Act
            var actualResponse = _courseService.DeleteCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Message, actualResponse.DataResponse?.Message);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }

        [Fact]
        public void GetAllCourse_Returns_ListOfCourseDTO()
        {
            // Arrange
            var expectedCourses = new List<CourseDTO>
            {
                new CourseDTO { Id = 1, Name = "Math", RegistrationFee = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) },
                new CourseDTO { Id = 2, Name = "Science", RegistrationFee = 1500, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) }
            };

            var expectedResponse = new ResponseDTO<List<CourseDTO>>
            {
                DataResponse = expectedCourses,
                Status = ResponseMessageEnum.Success
            };

            // Act
            var actualResponse = _courseService.GetAllCourse();

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Count, actualResponse.DataResponse?.Count);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }
    }
}