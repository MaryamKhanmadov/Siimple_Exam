using Siimple_Template_Exam.Bases;
using System.ComponentModel.DataAnnotations;

namespace Siimple_Template_Exam.Models
{
    public class Setting : BaseEntity
    {
        //Basliq hissede logo yox yazi oldugu ucun qeyd etmedim
        [StringLength(maximumLength:50)]
        public string? Key { get; set; }
        [StringLength(maximumLength: 50)]
        public string? Value { get; set; }
    }
}
