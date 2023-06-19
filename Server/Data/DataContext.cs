using DotNetBlazorEFCSQLExperimental.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetBlazorEFCSQLExperimental.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id=1, Title="Todo Example", Priority=5, Created=DateTime.Now, Duration=60 },
                new Todo { Id = 2, Title = "Todo Example 2", Priority = 2, Created = DateTime.Now, Duration = 2400 }
            ); 
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
