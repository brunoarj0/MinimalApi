using Microsoft.EntityFrameworkCore;
using Minimal.Domain.Models;

namespace Minimal.Infrastructure
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}
