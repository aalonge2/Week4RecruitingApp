using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RecruitingApp.Models
{
    public class Industry
    {
        [Key]
        public int IndustryId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Industry Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}

