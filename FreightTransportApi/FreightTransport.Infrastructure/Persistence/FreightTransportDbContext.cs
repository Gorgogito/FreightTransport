using FreightTransport.Domain;
using FreightTransport.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace FreightTransport.Infrastructure.Persistence
{

  public class FreightTransportDbContext : DbContext
  {
    public FreightTransportDbContext(DbContextOptions<FreightTransportDbContext> options) : base(options)
    { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=FreightTransport;User Id=sa;Password=G0rg0g170$")
    //  .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
    //  .EnableSensitiveDataLogging();
    //}

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedDate = DateTime.Now;
            entry.Entity.CreatedBy = 0;
            break;

          case EntityState.Modified:
            entry.Entity.LastModifiedDate = DateTime.Now;
            entry.Entity.LastModifiedBy = 0;
            break;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Company>()
          .HasMany(m => m.Users)
          .WithOne(m => m.Company)
          .HasForeignKey(m => m.CompanyId)
          .HasPrincipalKey(e => e.Id);
    }

    public DbSet<Company>? Companies { get; set; }

    public DbSet<User>? Users { get; set; }

  }

}
