using Data.Guest;
using Data.Mapping;
using Data.Room;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> option) : base(option)
        {

        }

        public virtual DbSet<Domain.Entities.Guest> Guests { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Domain.Entities.Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}
