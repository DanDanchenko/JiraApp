using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoCosmos.Domain;

namespace ToDoCosmos.Infrastructure
{
    public class JiraContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserStory> Stories { get; set; }
        
          

            public JiraContext(DbContextOptions<JiraContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }
        
    }
}
