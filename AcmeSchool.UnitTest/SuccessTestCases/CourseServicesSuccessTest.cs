using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using AcmeSchool.UnitTest;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeSchool.SuccessTestCases
{
    public class CourseServicesSuccessTest
    {
        private readonly ICourseService? _courseService;

        public CourseServicesSuccessTest()
        {
            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            // ICourseService interface configuration
            _courseService = serviceProvider.GetService<ICourseService>();
        }

        [Fact]
        public void GetCourseById_Returns_CourseDTO()
        {
            // Arrange
            int courseId = 1;
            var expectedResponse = new ResponseDTO<CourseDTO>
            {
                DataResponse = new CourseDTO 
                { 
                    Id = courseId, 
                    Name = "English Basic Course", 
                    RegistrationFee = 1500, 
                    StartDate = DateTime.Parse("2023/10/25"), 
                    EndDate = DateTime.Parse("2024/04/24")
                },
                Status = ResponseMessageEnum.Success
            };

            // Act
            var actualResponse = _courseService.GetCourseById(courseId);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.DataResponse, actualResponse.DataResponse);
        }

        [Fact]
        public void UpdateCourse_Returns_SuccessResponse()
        {
            // Arrange
            var courseDTO = new CourseDTO 
            { 
                Id = 3, 
                Name = "Franch course", 
                RegistrationFee = 3500, 
                StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(6) 
            };
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.COURSE_UPDATE_SUCCESS,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _courseService?.UpdateCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }

        [Fact]
        public void AddCourse_Returns_SuccessResponse()
        {
            // Arrange
            var courseDTO = new CourseDTO 
            { 
                Id = 1, 
                Name = "Math", 
                RegistrationFee = 1200, 
                StartDate = DateTime.Now, 
                EndDate = DateTime.Now.AddMonths(6) 
            };

            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                Status = ResponseMessageEnum.Success,
                ResponseMessage = StatusDescriptionMessage.COURSE_ADD_SUCCESS,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _courseService.AddCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
        }

        [Fact]
        public void DeleteCourse_Returns_SuccessResponse()
        {
            // Arrange
            var courseDTO = new CourseDTO 
            {
                Id = 1,
                Name = "English Basic Course",
                RegistrationFee = 1500,
                StartDate = DateTime.Parse("2023/10/25"),
                EndDate = DateTime.Parse("2024/04/24")
            };
            var expectedResponse = new ResponseDTO<ResponseMessage>
            {
                ResponseMessage = StatusDescriptionMessage.COURSE_ELIMINATED,
                Status = ResponseMessageEnum.Success,
                DataResponse = new ResponseMessage { Message = StatusDescriptionMessage.OK }
            };

            // Act
            var actualResponse = _courseService.DeleteCourse(courseDTO);

            // Assert
            Assert.Equal(expectedResponse.ResponseMessage, actualResponse.ResponseMessage);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }

        [Fact]
        public void GetAllCourse_Returns_ListOfCourseDTO()
        {
            // Arrange
            var expectedCourses = Enumerable.Range(1, 50).Select(i => new CourseDTO 
            {
                Id = i,
                Name = $"Course {i}"
            }).ToList();

            var expectedResponse = new ResponseDTO<List<CourseDTO>>
            {
                DataResponse = expectedCourses,
                Status = ResponseMessageEnum.Success
            };

            // Act
            var actualResponse = _courseService?.GetAllCourse(1);

            // Assert
            Assert.Equal(expectedResponse.DataResponse.Count, actualResponse.DataResponse?.Count);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
        }
    }
}