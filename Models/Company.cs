using System.ComponentModel.DataAnnotations;

namespace RecruitingApp.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Company Name")]
        public string Name { get; set; } = string.Empty;

        [Url]
        [Display(Name = "Website")]
        public string? Website { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Display(Name = "Location")]
        [DataType(DataType.MultilineText)]
        [StringLength(2000)]
        public string? Location { get; set; }

        [Display(Name = "Industry")]
        public int? IndustryId { get; set; }
        public Industry? Industry { get; set; }

        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}

