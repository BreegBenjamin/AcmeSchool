using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using System.Text.Json;

namespace AcmeSchool.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly List<CourseDTO> coursesData;
        public CourseService()
        {
            coursesData = ReadJsonData();
        }

        public ResponseDTO<ResponseMessage> AddCourse(CourseDTO course)
        {
            try
            {
                if (course != null)
                {
                    coursesData.Add(course);
                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK);

                }
                else 
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.STUDENT_IS_NULL);

                }
            }
            catch (Exception ex)
            {
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ERROR_TO_INSERT_COURSE, ex.Message);
            }
        } 

        public ResponseDTO<ResponseMessage> DeleteCourse(CourseDTO course)
        {
            try
            {
                if (course != null)
                {
                    coursesData.Remove(course);
                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.COURSE_ELIMINATED);
                }
                else
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA);

                }
            }
            catch (Exception ex)
            {
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ERROR_TO_INSERT_COURSE, ex.Message);
            }
        }

        public ResponseDTO<List<CourseDTO>> GetAllCourse()
        {
            try
            {
                if (coursesData.Any())
                {
                    return new ResponseDTO<List<CourseDTO>>()
                    {
                        DataResponse = coursesData,
                        Status = ResponseMessageEnum.Success,
                        ResponseMessage = StatusDescriptionMessage.OK
                    };
                }
                else
                {
                    return new ResponseDTO<List<CourseDTO>>()
                    {
                        DataResponse = coursesData,
                        Status = ResponseMessageEnum.NoData,
                        ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_COURSE
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<CourseDTO>>()
                {
                    DataResponse = new List<CourseDTO>(),
                    Status = ResponseMessageEnum.Error,
                    ResponseMessage = $"{StatusDescriptionMessage.LIST_COURSE_ERROR} : {ex.Message}"
                };
            }
        }

        public ResponseDTO<CourseDTO> GetCourseById(int courseId)
        {
            try
            {
                CourseDTO? course = coursesData.Where(x => x.Id == courseId).FirstOrDefault();

                if (course != null)
                {
                    return GetCourseResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK, course);
                }
                else
                {
                    return GetCourseResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA, new CourseDTO());
                }
            }
            catch (Exception ex)
            {
                return GetCourseResponseMessage(ResponseMessageEnum.Error, $"{StatusDescriptionMessage.STUDENT_ERROR} : {ex.Message}", new CourseDTO());
            }
        }

        public ResponseDTO<ResponseMessage> UpdateCourse(CourseDTO courseDTO)
        {
            try
            {
                CourseDTO? newCourseDTO = coursesData.Where(x=> x.Id == courseDTO.Id).FirstOrDefault();
                if (newCourseDTO != null)
                {
                    newCourseDTO.StartDate = courseDTO.StartDate;
                    newCourseDTO.EndDate = courseDTO.EndDate;
                    newCourseDTO.RegistrationFee = courseDTO.RegistrationFee;
                    newCourseDTO.Name = courseDTO.Name;

                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.COURSE_UPDATE_SUCCESS);

                }
                else 
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.STUDENT_ID_NOT_FOUND);

                }
            }
            catch (Exception ex)
            {
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.COURSE_UPDATE_ERROR,ex.Message);
            }
        }

        private List<CourseDTO> ReadJsonData()
        {
            try
            {
                string path = @"\\Data\courseData.json";

                if (File.Exists(path))
                {
                    string jsonData = File.ReadAllText(path);
                    List<CourseDTO>? students = JsonSerializer.Deserialize<List<CourseDTO>>(jsonData);

                    if (students != null) return students;

                    return new List<CourseDTO>();
                }
                else
                {
                    return new List<CourseDTO>();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(StatusDescriptionMessage.ERROR_MS_FILE_NOT_FOUND);
                return new List<CourseDTO>();
            }
            catch (JsonException)
            {
                Console.WriteLine(StatusDescriptionMessage.DESERIALIZE_ERROR);
                return new List<CourseDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{StatusDescriptionMessage.ERROR_MS_EXCEPTION}: {ex.Message}");
                return new List<CourseDTO>();
            }

        }

        private ResponseDTO<ResponseMessage> GetResponseMessage(ResponseMessageEnum status, string message, string messageEx = "")
        {
            return new ResponseDTO<ResponseMessage>
            {
                Status = status,
                ResponseMessage = message,
                DataResponse = (status == ResponseMessageEnum.Error) ? new ResponseMessage
                {
                    Message = messageEx
                } : new ResponseMessage()
            };
        }

        private ResponseDTO<CourseDTO> GetCourseResponseMessage(ResponseMessageEnum status, string message, CourseDTO courseDTO)
        {
            return new ResponseDTO<CourseDTO>
            {
                Status = status,
                ResponseMessage = message,
                DataResponse = courseDTO
            };
        }
    }
}
