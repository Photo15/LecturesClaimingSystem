using LecturesClaimingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LecturesClaimingSystem.Services
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}