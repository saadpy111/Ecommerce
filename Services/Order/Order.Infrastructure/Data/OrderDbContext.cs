using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using System.Reflection;
namespace Order.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        // Sets
        public DbSet<Order.Core.Entities.Order>  Orders { get; set; }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) { }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string con = "Data Source=DESKTOP-VGEBCK1\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;";
                optionsBuilder.UseSqlServer("con");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var  Entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (Entry.State)
                {
                    case EntityState.Modified:
                        Entry.Entity.LastModifiedDate = DateTime.Now;
                        Entry.Entity.LastModifiedBy = "saad"; // TODO : replace with auth
                        break;

                    case EntityState.Added:
                        Entry.Entity.CreatedDate = DateTime.Now;
                        Entry.Entity.CreatedBy = "saad";
                        break;

                    default:
                        break;
                }
                    
                
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
