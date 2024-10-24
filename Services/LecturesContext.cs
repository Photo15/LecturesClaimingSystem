using LecturesClaimingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LecturesClaimingSystem.Services
{
    public class LecturesContext : DbContext
    {
        public LecturesContext(DbContextOptions<LecturesContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}