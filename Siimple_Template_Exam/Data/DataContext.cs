using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Siimple_Template_Exam.Models;

namespace Siimple_Template_Exam.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
