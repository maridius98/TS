using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<BaseUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseUser>()
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Chef>("Chef");
    }
}