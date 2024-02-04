using GloboTickets.Domain.Common;
using GloboTickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTickets.Infrastructure.Data;

public class GloboTicketsDbContext : DbContext
{
    public GloboTicketsDbContext(DbContextOptions<GloboTicketsDbContext> options) : base(options)
    {
        
    }
    public DbSet<Event> Events { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Orders> Orders { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketsDbContext).Assembly);
        var concertGuid = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35");
        var musicalGuid = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96");
        var playGuid = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450");
        var conferenceGuid = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09");
        
        modelBuilder.Entity<Category>().HasData(new Category {CategoryId = concertGuid, Name = "Concerts"});
        modelBuilder.Entity<Category>().HasData(new Category {CategoryId = playGuid, Name = "Plays"});
        modelBuilder.Entity<Category>().HasData(new Category {CategoryId = musicalGuid, Name = "Musicals"});
        modelBuilder.Entity<Category>().HasData(new Category {CategoryId = conferenceGuid, Name = "Conferences"});
        
        modelBuilder.Entity<Event>().HasData(new Event
        {
            EventId = Guid.Parse("f5b761d2-1e82-4e2b-8d2f-4f3ecf0f5f6b"),
            Name = "Jazz Concert",
            Price = 100,
            Artist = "John Coltrane",
            Date = new DateTime(2023, 12, 1),
            CategoryId = concertGuid
        });

        modelBuilder.Entity<Event>().HasData(new Event()
        {
            EventId = Guid.Parse("f5b761d2-1e82-4e2b-8d2f-4f3ecf0f5f6c"),
            Name = "The Phantom of the Opera",
            Price = 150,
            Artist = "Andrew Lloyd Webber",
            Date = new DateTime(2023, 12, 1),
            CategoryId = musicalGuid
        });

        //Additional sample data
        modelBuilder.Entity<Event>().HasData(new Event()
        {
            EventId = Guid.Parse("f5b761d2-1e82-4e2b-8d2f-4f3ecf0f5f6d"),
            Name = "The Wizard of Oz",
            Price = 200,
            Artist = "Lyman Frank Baum",
            Date = new DateTime(2023, 12, 1),
            CategoryId = playGuid
        });
        
        modelBuilder.Entity<Event>().HasData(new Event()
        {
            EventId = Guid.Parse("f5b761d2-1e82-4e2b-8d2f-4f3ecf0f5f6e"),
            Name = "Tech Conference",
            Price = 300,
            Artist = "Innovative Leadership",
            Date = new DateTime(2023, 12, 1),
            CategoryId = conferenceGuid
        });
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                    break;
            }
            
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}