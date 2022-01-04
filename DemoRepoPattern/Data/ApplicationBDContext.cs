using DemoRepoPattern.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoRepoPattern.Data
{
    public class ApplicationBDContext : DbContext
    {
        public ApplicationBDContext(DbContextOptions<ApplicationBDContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Division> Divisions { get; set; }
    }
}
