namespace AcmeSchool.Core.DTOs
{
    public class CourseDTO
    {
        public string? Name { get; set; }
        public float? RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
