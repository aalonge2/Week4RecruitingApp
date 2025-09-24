using System.ComponentModel.DataAnnotations;

namespace RecruitingApp.Models
{
    public class JobTitle
    {
        [Key]
        public int JobTitleId { get; set; }

        [Required, StringLength(120)]
        [Display(Name = "Job Title")]
        public string Title { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        [Display(Name = "Minimum Salary")]
        public decimal? SalaryMin { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Maximum Salary")]
        public decimal? SalaryMax { get; set; }

        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}

