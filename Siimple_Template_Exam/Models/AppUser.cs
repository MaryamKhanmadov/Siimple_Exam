using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Siimple_Template_Exam.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(maximumLength: 50)]
        public string Fullname { get; set; }
    }
}
