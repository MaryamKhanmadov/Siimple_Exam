using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siimple_Template_Exam.Models
{
    public class Card
    {
        public int Id { get; set; }
        [StringLength(maximumLength:20)]
        public string Title { get; set; }
        [StringLength(maximumLength: 300)]
        public string Descreption { get; set; }
        [StringLength(maximumLength: 100)]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
