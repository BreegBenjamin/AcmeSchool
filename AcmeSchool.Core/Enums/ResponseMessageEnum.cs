namespace AcmeSchool.Core.Enums
{
    public enum ResponseMessageEnum
    {
        Success = 0,
        Error = 1,
        NoData = 2,
    }

    public class StatusDescriptionMessage 
    {
        public const string OK = "OK";

        public const string ERROR = "Error";

        public const string NO_DATA = "No data to show";

        public const string COURSE_COST = "The cost of the course is higher than what was paid";

        public const string STUDENT_IS_NULL = "Student is null";

        public const string ERROR_TO_INSERT_COURSE = "Error to insert course to student list"; 

        public const string ELIMINATED_STUDENT = "Student eliminated";

        public const string STUDENT_ERROR = "Error to insert student: ";

        public const string LIST_COURSE_ERROR = "Error to get list of course in date range: ";

        public const string LIST_STUDENT_ERROR = "Error to get list of student in date range: ";

        public const string COURSE_DETETED = "Deleted course: OK";

        public const string NO_DATA_IN_LIST_COURSE = "There is no data in the course list";

        public const string NO_DATA_IN_LIST_STUDENT = "There is no data in the student list";

        public const string ERROR_MS_FILE_NOT_FOUND = "The file was not found in the specified location";

        public const string DESERIALIZE_ERROR = "Error deserializing JSON file";

        public const string ERROR_MS_EXCEPTION = "An error occurred";

        public const string COURSE_ELIMINATED = "The course was eliminated";

        public const string COURSE_UPDATE_SUCCESS = "Successfully updated course";

        public const string STUDENT_UPDATE_SUCCESS = "Successfully updated student info";

        public const string STUDENT_ID_NOT_FOUND = "A student with the provided ID was not found";

        public const string COURSE_ID_NOT_FOUND = "A course with the provided ID was not found";

        public const string STUDENT_UPDATE_ERROR = "An error occurred while updating the student info";

        public const string COURSE_UPDATE_ERROR = "An error occurred while updating the course";
    }
}
