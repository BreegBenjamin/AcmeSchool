using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.UnitTest.NoDataTestCases
{
    public class CourseServicesNoDataTest
    {
        private readonly ICourseService? _courseService;

        public CourseServicesNoDataTest()
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            // ICourseService interface configuration
            _courseService = serviceProvider.GetService<ICourseService>();
        }

        [Fact]
        public void GetCourseById_Returns_NoData()
        {
            // Arrange
            int courseId = 0;
            var expectedResponse = new ResponseDTO<CourseDTO>
            {
                DataResponse = new CourseDTO(),
                Status = ResponseMessageEnum.NoData
            };

            // Act
            var actualResponse = _courseService?.GetCourseById(courseId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.DataResponse, actualResponse.DataResponse);
        }

        [Fact]
        public void UpdateCourse_Returns_NoData()
        {
            // Arrange
            var courseDTO = new CourseDTO();

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.STUDENT_ID_NOT_FOUND,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _courseService?.UpdateCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void AddCourse_Returns_NoData()
        {
            // Arrange
            CourseDTO courseDTO = new CourseDTO();
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _courseService.AddCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void DeleteCourse_Returns_NoData()
        {
            // Arrange
            CourseDTO courseDTO = new CourseDTO();
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.NO_DATA }
            };

            // Act
            var actualResponse = _courseService.DeleteCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void GetAllCourse_Returns_NoData()
        {
            // Arrange
            var expectedResponse = new ResponseDTO<List<CourseDTO>>
            {
                DataResponse = new List<CourseDTO>(),
                Status = ResponseMessageEnum.NoData,
                ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_COURSE
            };

            // Act
            var actualResponse = _courseService?.GetAllCourse(0);

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Count, actualResponse.DataResponse?.Count);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

    }
}
