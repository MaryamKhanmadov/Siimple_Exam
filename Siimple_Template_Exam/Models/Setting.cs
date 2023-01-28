using System.ComponentModel.DataAnnotations;

namespace Siimple_Template_Exam.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string? Key { get; set; }
        [StringLength(maximumLength: 50)]
        public string? Value { get; set; }
    }
}
