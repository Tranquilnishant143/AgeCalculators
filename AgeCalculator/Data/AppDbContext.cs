using AgeCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace AgeCalculator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AgeCalculation> AgeCalculations { get; set; }
    }
}