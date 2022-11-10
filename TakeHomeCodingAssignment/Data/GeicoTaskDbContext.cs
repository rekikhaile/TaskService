using Microsoft.EntityFrameworkCore;
using TakeHomeCodingAssignment.Models;

namespace TakeHomeCodingAssignment.Data
{
    public class GeicoTaskDbContext : DbContext
    {
        public GeicoTaskDbContext(DbContextOptions<GeicoTaskDbContext> options) : base(options) 
        {
        }

        public DbSet<GeicoTask> Tasks => Set<GeicoTask>();

       
    }
}
