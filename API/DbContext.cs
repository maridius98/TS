using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<BaseUser> Users { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseUser>()
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Chef>("Chef");
    }

    public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
    {
        
    }

}