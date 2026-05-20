using Microsoft.EntityFrameworkCore;
using Practise.Models;

namespace Practise.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
