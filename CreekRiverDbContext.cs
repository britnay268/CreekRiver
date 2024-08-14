using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

// DbContext is a bridge between the code and the database or interacts with the databas
// It further reprsent the database as objects
// CreekRiverDbContect is inheriting all the capabilities of managing a database from DbContext
public class CreekRiverDbContext : DbContext
{
    // Creating a table in the database for Reservations, userProfiles, Campsites, and campsiteTypes
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    // This constructor is used to connect to the database and send it to the parent class (DbContext) to handle the connection setup
    // context is the variable name that holds the configuration information for setting up the database
    // DbOptions has the connection string, the databse being used and the configuration seetings
    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }

    // This method will only be called in the method inside the class itself or by any class that inherits it
    // This is replacing a method of the same that is inherited from the DbContect class
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Send data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType
            {
                Id = 1,
                CampsiteTypeName = "Tent",
                FeePerNight = 15.99M,
                MaxReservationDays = 7
            },
            new CampsiteType
            {
                Id = 2,
                CampsiteTypeName = "RV",
                FeePerNight = 26.50M,
                MaxReservationDays = 14
            },
            new CampsiteType
            {
                Id = 3,
                CampsiteTypeName = "Primitive",
                FeePerNight = 10.00M,
                MaxReservationDays = 3
            },
            new CampsiteType
            {
                Id = 4,
                CampsiteTypeName = "Hammock",
                FeePerNight = 12M,
                MaxReservationDays = 7
            }
        });

        // Send data with campsite
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite
            {
                Id = 1,
                CampsiteTypeId = 1,
                Nickname = "Barred Owl",
                ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"
            },
            new Campsite
            {
                Id = 2,
                CampsiteTypeId = 3,
                Nickname = "Shadow Woods",
                ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTAIFIKpUCDpEyB2vt7AJwYfRmooPM427XeVTz5hkawhL7qZcwca6BcieZQq5s6qSHhuk&usqp=CAU"
            },
            new Campsite
            {
                Id = 3,
                CampsiteTypeId = 2,
                Nickname = "Night Vibes",
                ImageUrl="https://cdnb.artstation.com/p/assets/images/images/024/924/901/large/korhan-alp-maden-sokakta-yalniz2-1.jpg?1583972930"
            },
            new Campsite
            {
                Id = 4,
                CampsiteTypeId = 1,
                Nickname = "Meet Greet",
                ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKRTjoE6NmCDX99Ruk713K9p16mu517TlYEQ&s"
            },
            new Campsite
            {
                Id = 5,
                CampsiteTypeId = 4,
                Nickname = "Solitude Fall",
                ImageUrl="https://res.cloudinary.com/simpleview/image/upload/v1459362023/clients/boston/header_aboutboston_seasons_fall_publicgarden_c6fb1674-26d0-41c0-a160-e2bf87b92f10.jpg"
            },
        });
    }
}

