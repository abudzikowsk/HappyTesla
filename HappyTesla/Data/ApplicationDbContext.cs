using HappyTesla.Data.Entities;
using HappyTesla.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HappyTesla.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Car>()
            .HasData(
                new Car
                {
                    Id = 1,
                    Color = "Black",
                    Model = "Model S Plaid",
                    Name = "Tesla",
                    Price = 89.99m
                },
                new Car
                {
                    Id = 2,
                    Color = "Black",
                    Model = "Model S",
                    Name = "Tesla",
                    Price = 74.99m
                },
                new Car
                {
                    Id = 3,
                    Color = "Red",
                    Model = "Model 3 Performance",
                    Name = "Tesla",
                    Price = 50.99m
                },
                new Car
                {
                    Id = 4,
                    Color = "Red",
                    Model = "Model 3 Long Range",
                    Name = "Tesla",
                    Price = 45.99m
                },
                new Car
                {
                    Id = 5,
                    Color = "Red",
                    Model = "Model 3 Rear-Wheel Drive",
                    Name = "Tesla",
                    Price = 38.99m
                },
                new Car
                {
                    Id = 6,
                    Color = "White",
                    Model = "Model X Plaid",
                    Name = "Tesla",
                    Price = 89.99m
                },
                new Car
                {
                    Id = 7,
                    Color = "White",
                    Model = "Model X",
                    Name = "Tesla",
                    Price = 79.99m
                },
                new Car
                {
                    Id = 8,
                    Color = "Blue",
                    Model = "Model Y Performance",
                    Name = "Tesla",
                    Price = 52.49m
                },
                new Car
                {
                    Id = 9,
                    Color = "Blue",
                    Model = "Model Y Long Range",
                    Name = "Tesla",
                    Price = 48.49m
                },
                new Car
                {
                    Id = 10,
                    Color = "Blue",
                    Model = "Model Y Rear-Wheel Drive",
                    Name = "Tesla",
                    Price = 43.99m
                }
                );
        builder.Entity<Location>()
            .HasData(
                new Location
                {
                    Id = 1,
                    Country = "Spain",
                    City = "Palma de Mallorca",
                    Address = "Palma Airport"
                },
                new Location
                {
                    Id = 2,
                    Country = "Spain",
                    City = "Palma de Mallorca",
                    Address = "Palma City Center"
                },
                new Location
                {
                    Id = 3,
                    Country = "Spain",
                    City = "Alcúdia",
                    Address = "Alcúdia"
                },
                new Location
                {
                    Id = 4,
                    Country = "Spain",
                    City = "Manacor",
                    Address = "Manacor"
                }
                );
        var adminRoleGuid = "cbf3e9c9-40bc-451a-86e2-9fde61e88627";
        var adminUserGuid = "d05ff009-f6ae-4355-8d55-823c0f43c635";
        var adminUserName = "admin@admin.com";

        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = adminRoleGuid,
                    Name = UserRole.Admin.ToString(),
                    NormalizedName = UserRole.Admin.ToString().ToUpper()
                });

        builder.Entity<IdentityUser>()
            .HasData(
                new IdentityUser
                {
                    Id = adminUserGuid,
                    UserName = adminUserName,
                    NormalizedUserName = adminUserName.ToUpper(),
                    Email = adminUserName,
                    NormalizedEmail = adminUserName.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEB1yf/WTsSmemU2ASov5Cc473nf4bLzpc2JnwAGG4SD7tf0PImrv4ULyOYKDA96RYg==" //Qwerty!2345
                });

        builder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleGuid,
                    UserId = adminUserGuid
                });
        
        base.OnModelCreating(builder);
    }
}

