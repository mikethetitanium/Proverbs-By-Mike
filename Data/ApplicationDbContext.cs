using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proverbs_By_Mike.Models;

namespace Proverbs_By_Mike.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Proverbs_By_Mike.Models.proverb> proverb { get; set; } = default!;
    }
}
