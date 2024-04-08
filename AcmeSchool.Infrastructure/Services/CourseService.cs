using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                if (course.Id != 0)
                {
                    coursesData.Add(course);
                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.COURSE_ADD_SUCCESS);

                }
                else if (course.Equals(new CourseDTO()))
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA);
                }
                else
                {
                    throw new  Exception();
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
                if (course.Id != 0)
                {
                    coursesData.Remove(course);
                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.COURSE_ELIMINATED);
                }
                else if (course.Equals(new CourseDTO())) 
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ERROR_MS_EXCEPTION, ex.Message);
            }
        }

        public ResponseDTO<List<CourseDTO>> GetAllCourse(int proccess)
        {
            try
            {
                if (coursesData.Any() && proccess == 1)
                {
                    return new ResponseDTO<List<CourseDTO>>()
                    {
                        DataResponse = coursesData,
                        Status = ResponseMessageEnum.Success,
                        ResponseMessage = StatusDescriptionMessage.OK
                    };
                }
                else if (proccess == 2)
                {
                    throw new Exception();
                }
                else 
                {
                    return new ResponseDTO<List<CourseDTO>>()
                    {
                        DataResponse = new List<CourseDTO>(),
                        Status = ResponseMessageEnum.NoData,
                        ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_COURSE
                    };
                }
            }
            catch (Exception)
            {
                return new ResponseDTO<List<CourseDTO>>()
                {
                    DataResponse = new List<CourseDTO>(),
                    Status = ResponseMessageEnum.Error,
                    ResponseMessage = StatusDescriptionMessage.LIST_COURSE_ERROR 
                };
            }
        }

        public ResponseDTO<CourseDTO> GetCourseById(int courseId)
        {
            try
            {
                CourseDTO course = coursesData.FirstOrDefault(x => x.Id == courseId) ?? new CourseDTO() {Id = courseId };

                if (course?.Id != 0 && course.RegistrationFee != 0)
                {
                    return GetCourseResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK, course);
                }
                else if (course.Equals(new CourseDTO())) 
                {
                    return GetCourseResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA, new CourseDTO());

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return GetCourseResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ERROR_MS_EXCEPTION,  new CourseDTO());
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
                else if (courseDTO.Equals(new CourseDTO())) 
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.STUDENT_ID_NOT_FOUND);
                }
                else
                {
                    throw new Exception();
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
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string file = Path.Combine(currentDirectory, @"..\..\..\Data\courseData.json");
                string filePath = Path.GetFullPath(file);


                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new DateTimeConverter() }
                    };

                    List<CourseDTO>? students = JsonSerializer.Deserialize<List<CourseDTO>>(jsonData, options: options);

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

    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd/MM/yyyy"));
        }
    }
}


