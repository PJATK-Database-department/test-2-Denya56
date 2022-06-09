using Microsoft.EntityFrameworkCore;
using Core_Web_API_Template.Models;

namespace Core_Web_API_Template.Context
{
    public class AirportDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AirportDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AirportDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultDbCon"));
        }
        
        public DbSet<Plane> Planes { get; set; }
        public DbSet<CityDict> CityDicts { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight_Passenger> Flight_Passengers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight_Passenger>()
                .HasKey(x => new { x.IdFlight, x.IdPassenger });
            modelBuilder.Entity<Flight_Passenger>()
                .HasOne(f => f.Flight)
                .WithMany(fp => fp.Flight_Passengers)
                .HasForeignKey(f => f.IdFlight);
            modelBuilder.Entity<Flight_Passenger>()
                .HasOne(p => p.Passenger)
                .WithMany(fp => fp.Flight_Passengers)
                .HasForeignKey(p => p.IdPassenger);
        }
    }
}
