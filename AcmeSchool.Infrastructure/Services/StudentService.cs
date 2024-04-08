using AcmeSchool.Core.DTOs;
using AcmeSchool.Core.Enums;
using AcmeSchool.Core.Interfaces;
using System.Text.Json;

namespace AcmeSchool.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<StudentDTO> studentsData;
        private readonly ICourseService courseService;
        public StudentService(ICourseService courseService) 
        {
            studentsData = ReadJsonData();
            this.courseService =  courseService;
        }

        public ResponseDTO<ResponseMessage> AddCourseToStudent(int studentId, CourseDTO course)
        {
            try
            {
                var student = studentsData.FirstOrDefault(x => x.Id == studentId);

                if (student != null)
                {
                    student.EnrolledCourses.Add(course);
                    studentsData.Add(student);

                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK);
                }
                else if (course.Equals(new CourseDTO())) 
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.STUDENT_IS_NULL);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ERROR_TO_INSERT_COURSE, ex.Message);
            }
        }

        public ResponseDTO<StudentDTO> CreateStudent(StudentDTO student)
        {
            try
            {
                if (student != null && student.Id > 0)
                {

                    studentsData.Add(student);

                    return GetStudentResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK, student);
                }
                else if (student.Equals(new StudentDTO()))
                {
                    return GetStudentResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.STUDENT_IS_NULL, new StudentDTO());
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return GetStudentResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.STUDENT_ERROR, new StudentDTO());
            }
        }

        public ResponseDTO<ResponseMessage> DeleteStudent(int studentId)
        {
            try
            {
                var student = studentsData.FirstOrDefault(x => x.Id == studentId) ?? new StudentDTO() { Id = studentId} ;

                if (student.Id > 0)
                {
                    studentsData.Remove(student);
                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.ELIMINATED_STUDENT);
                }
                else if (student.Equals(new StudentDTO())) 
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
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ELIMINATED_STUDENT_ERROR, ex.Message);
            }
        }

        public ResponseDTO<List<StudentDTO>> GetAllCourseByDate(string initDate, string endDate)
        {
            try
            {
                DateTime initDateCourse = DateTime.Parse(initDate);
                DateTime endDateCourse = DateTime.Parse(endDate);

                var listStudent = studentsData
                    .Select(student =>
                        new StudentDTO
                        {
                            Id = student.Id,
                            Name = student.Name,
                            lastName = student.lastName,
                            Age = student.Age,
                            EnrolledCourses = student.EnrolledCourses
                                .Where(course => course.StartDate >= initDateCourse && course.EndDate <= endDateCourse)
                                .ToList()
                        })
                    .Where(student => student.EnrolledCourses.Any()).ToList();

                if (listStudent.Any())
                {
                    return new ResponseDTO<List<StudentDTO>>()
                    {
                        DataResponse = listStudent,
                        Status = ResponseMessageEnum.Success,
                        ResponseMessage = StatusDescriptionMessage.OK
                    };
                }
                else 
                {
                    return new ResponseDTO<List<StudentDTO>>()
                    {
                        DataResponse = new List<StudentDTO>(),
                        Status = ResponseMessageEnum.NoData,
                        ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_COURSE
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<StudentDTO>>()
                {
                    DataResponse = new List<StudentDTO>(),
                    Status = ResponseMessageEnum.Error,
                    ResponseMessage = StatusDescriptionMessage.LIST_COURSE_ERROR
                };
            }


        } 

        public ResponseDTO<List<StudentDTO>> GetAllStudents(int proccess)
        {
            try
            {
                if (studentsData.Any() && proccess == 1)
                {
                    return new ResponseDTO<List<StudentDTO>>()
                    {
                        DataResponse = studentsData,
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
                    return new ResponseDTO<List<StudentDTO>>()
                    {
                        DataResponse = new List<StudentDTO>(),
                        Status = ResponseMessageEnum.NoData,
                        ResponseMessage = StatusDescriptionMessage.NO_DATA_IN_LIST_STUDENT
                    };
                }
            }
            catch (Exception)
            {
                return new ResponseDTO<List<StudentDTO>>()
                {
                    DataResponse = new List<StudentDTO>(),
                    Status = ResponseMessageEnum.Error,
                    ResponseMessage = StatusDescriptionMessage.LIST_STUDENT_ERROR
                };
            }
        }

        public ResponseDTO<StudentDTO> GetStudentById(int studentId)
        {
            try
            {
                StudentDTO? student = studentsData.Where(x => x.Id == studentId).FirstOrDefault() ?? new StudentDTO() { Id = studentId};

                if (student.Id > 0)
                {
                    return GetStudentResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK, student);
                }
                else if (student.Equals(new StudentDTO())) 
                {
                    return GetStudentResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA, new StudentDTO());
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return GetStudentResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.STUDENT_ERROR, new StudentDTO());
            }
        }

        public ResponseDTO<ResponseMessage> RemoveCourse(int studentId, CourseDTO courseDto)
        {
            try
            {
                StudentDTO? student = studentsData.Where(x => x.Id == studentId).FirstOrDefault();

                if (student != null)
                {
                    CourseDTO? course = student.EnrolledCourses.Where(x => x.Id == courseDto.Id).FirstOrDefault();
                    if (course != null)
                    {
                        student.EnrolledCourses.Remove(course);
                        return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.COURSE_DETETED);
                    }
                    else
                    {
                        return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA);
                    }
                }
                else if (courseDto.Equals(new CourseDTO())) 
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
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.STUDENT_ERROR);
            }
        }

        public ResponseDTO<ResponseMessage> UpdateStudent(StudentDTO student)
        {
            try
            {
                StudentDTO? newStudentDTO = studentsData.Where(x => x.Id == student.Id).FirstOrDefault();
                if (newStudentDTO != null)
                {
                    newStudentDTO.Name = student.Name;
                    newStudentDTO.lastName = student.lastName;
                    newStudentDTO.Age = student.Age;

                    return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.STUDENT_UPDATE_SUCCESS);

                }
                else if (student.Equals(new StudentDTO())) 
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
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.STUDENT_UPDATE_ERROR, ex.Message);
            }
        }

        public ResponseDTO<ResponseMessage> ValidateCoursePayment(int courseId, double coursePayment)
        {
            try
            {
                var courseResponse = courseService.GetCourseById(courseId);
                if (courseResponse.Status == ResponseMessageEnum.Success)
                {
                    if (coursePayment >= courseResponse.DataResponse?.RegistrationFee)
                    {
                        return GetResponseMessage(ResponseMessageEnum.Success, StatusDescriptionMessage.OK);
                    }
                    else
                    {
                        return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.COURSE_COST);
                    }
                }
                else if (courseResponse.Status == ResponseMessageEnum.Error) 
                {
                    throw new Exception();
                }
                else
                {
                    return GetResponseMessage(ResponseMessageEnum.NoData, StatusDescriptionMessage.NO_DATA);
                }
            }
            catch (Exception ex)
            {
                return GetResponseMessage(ResponseMessageEnum.Error, StatusDescriptionMessage.ERROR, ex.Message);

            }
        }

        private List<StudentDTO> ReadJsonData() 
        {
            try
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string file = Path.Combine(currentDirectory, @"..\..\..\Data\studentData.json");
                string filePath = Path.GetFullPath(file);

                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new DateTimeConverter() }
                    };

                    List<StudentDTO>? students = JsonSerializer.Deserialize<List<StudentDTO>>(jsonData, options: options);

                    if (students != null) return students;

                    return new List<StudentDTO>();
                }
                else {
                    return new List<StudentDTO>();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(StatusDescriptionMessage.ERROR_MS_FILE_NOT_FOUND);
                return new List<StudentDTO>();
            }
            catch (JsonException)
            {
                Console.WriteLine(StatusDescriptionMessage.DESERIALIZE_ERROR);
                return new List<StudentDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{StatusDescriptionMessage.ERROR_MS_EXCEPTION}: {ex.Message}");
                return new List<StudentDTO>();
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
                }  : new ResponseMessage()
            };
        }

        private ResponseDTO<StudentDTO> GetStudentResponseMessage(ResponseMessageEnum status, string message, StudentDTO studentDTO)
        {
            return new ResponseDTO<StudentDTO>
            {
                Status = status,
                ResponseMessage = message,
                DataResponse =  studentDTO
            };
        }
        

    }
}
