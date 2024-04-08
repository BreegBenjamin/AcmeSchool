using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.UnitTest.ErrorTestCases
{
    public class CourseServicesErrorTest
    {
        private readonly ICourseService? _courseService;

        public CourseServicesErrorTest()
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            // ICourseService interface configuration
            _courseService = serviceProvider.GetService<ICourseService>();
        }

        [Fact]
        public void GetCourseById_Throws_Exception()
        {
            // Arrange
            int courseId = -1; 

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.ERROR_MS_EXCEPTION
            };

            //Act
            var actualResponse = _courseService?.GetCourseById(courseId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void UpdateCourse_Throws_Exception()
        {
            // Arrange
            var courseDTO = new CourseDTO
            {
                Id = 100,
                Name = "Invalid Course",
                RegistrationFee = 2000,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            }; 

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.COURSE_UPDATE_ERROR
            };

            //Act
            var actualResponse = _courseService?.UpdateCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse?.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse?.ResponseMessage);
        }

        [Fact]
        public void AddCourse_Throws_Exception()
        {
            // Arrange
            CourseDTO courseDTO = null;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.ERROR_TO_INSERT_COURSE
            };

            //Act
            var actualResponse = _courseService?.AddCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void DeleteCourse_Throws_Exception()
        {
            // Arrange
            CourseDTO courseDTO = null;

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.ERROR_MS_EXCEPTION
            };

            //Act
            var actualResponse = _courseService.DeleteCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void GetAllCourse_Throws_Exception()
        {
            // Arrange
            var expectedResponse = new ResponseDTO<List<CourseDTO>>
            {
                DataResponse = new List<CourseDTO>(),
                Status = ResponseMessageEnum.Error,
                ResponseMessage = StatusDescriptionMessage.LIST_COURSE_ERROR
            };

            // Act
            var actualResponse = _courseService?.GetAllCourse(2);

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Count, actualResponse.DataResponse?.Count);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

    }
}
