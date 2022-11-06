using ChatTP.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatTP.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Messagge> Messagges { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomType> RoomsType { get; set; }

    }
}
