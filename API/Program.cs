using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core services
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=TS;Trusted_Connection=True;"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();