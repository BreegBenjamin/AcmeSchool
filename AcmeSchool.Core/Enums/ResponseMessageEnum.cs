namespace AcmeSchool.Core.Enums
{
    public enum ResponseMessageEnum
    {
        Ok = 0,
        Error = 1,
        NoData = 2,
    }

    public class StatusDescriptionMessage 
    {
        public const string OK = "OK";

        public const string ERROR = "Error";

        public const string NO_DATA = "Student is null";

        public const string STUDENT_IS_NULL = "Student is null";

        public const string ERROR_TO_INSERT_COURSE = "Error to insert course to student list";

        public const string ELIMINATED_STUDENT = "Eliminated student";

        public const string STUDENT_ERROR = "Error to insert student: ";

        public const string LIST_COURSE_ERROR = "Error to get list of course in date range: ";

        public const string COURSE_DETETED = "Deleted course: OK";

        public const string NO_DATA_IN_LIST_COURSE = "There is no data in the course list";
    }
}
