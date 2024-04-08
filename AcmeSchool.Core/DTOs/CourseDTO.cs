    using System.ComponentModel.DataAnnotations;

    namespace AcmeSchool.Core.DTOs
    {
        public class CourseDTO
        {
            [Required]
            public int Id { get; set; }

            [Required(ErrorMessage = "Course name is required")]
            public string? Name { get; set; }

            [Range(500, 10000, ErrorMessage = "Registration fee must be greater than zero")]
            public float RegistrationFee { get; set; }

            [Range(1000, 6000, ErrorMessage = "The cost of the course should be between 1000 to 6000")]
            [Required(ErrorMessage = "Course Start Date is required")]
            public DateTime StartDate { get; set; }

            [Required(ErrorMessage = "Course End Date is required")]
            public DateTime EndDate { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                CourseDTO other = (CourseDTO)obj;
                return Id == other.Id &&
                       Name == other.Name &&
                       StartDate == other.StartDate 
                       && EndDate == other.EndDate
                       && RegistrationFee == other.RegistrationFee;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name, StartDate, EndDate, RegistrationFee);
            }
        }
    }
