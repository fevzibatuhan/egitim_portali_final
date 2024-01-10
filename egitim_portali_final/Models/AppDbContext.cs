using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace egitim_portali_final.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Education> Educations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<EgitimAndTeachers> egitimAndTeachers { get; set; }

    }
}