using Siimple_Template_Exam.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siimple_Template_Exam.Models
{
    public class Card : BaseEntity
    {
        [StringLength(maximumLength:20)]
        public string Title { get; set; }
        [StringLength(maximumLength: 100)]
        public string TitleRedirectUrl { get; set; }
        [StringLength(maximumLength: 300)]
        public string Descreption { get; set; }
        [StringLength(maximumLength: 100)]
        public string? ImageUrl { get; set; }
        [StringLength(maximumLength: 100)]
        public string IconUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
