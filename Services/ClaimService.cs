using Microsoft.EntityFrameworkCore;
using LecturesClaimingSystem.Models;

namespace LecturesClaimingSystem.Services
{
    public class ClaimContext : DbContext
    {
        public ClaimContext(DbContextOptions<ClaimContext> options) : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }
    }
}
