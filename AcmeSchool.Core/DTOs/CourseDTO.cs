using AcmeSchool.Core.Entities;
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

        [Required(ErrorMessage = "Course Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Course End Date is required")]
        public DateTime EndDate { get; set; }
    }
}
