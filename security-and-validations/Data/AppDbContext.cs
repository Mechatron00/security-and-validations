using Microsoft.EntityFrameworkCore;
using security_and_validations.Models;

namespace security_and_validations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<VaultItem> VaultItems => Set<VaultItem>();
    }
}
