using System.ComponentModel.DataAnnotations;

namespace RecruitingApp.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Url]
        [Display(Name = "LinkedIn URL")]
        public string? LinkedInUrl { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Salary Expectation")]
        public decimal? SalaryExpectation { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Applied")]
        public DateTime? DateApplied { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public int JobTitleId { get; set; }
        public JobTitle? JobTitle { get; set; }

        [Display(Name = "Industry")]
        public int? IndustryId { get; set; }
        public Industry? Industry { get; set; }

        [Display(Name = "Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}

