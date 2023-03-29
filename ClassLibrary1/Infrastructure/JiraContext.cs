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
      //  public DbSet <Subtask> Subtasks { get; set; } Думаю, що не потрібно, оскільки у кожного сторі свій набір сабтасків. Поправте будь - ласка, якщо не правий
        
          

            public JiraContext(DbContextOptions<JiraContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }
        
    }
}
