using Microsoft.EntityFrameworkCore;
using Shooling.Models;

namespace Shooling.Context
{
    public class DbShoolingActivity: DbContext
    {
        public DbSet<ShoolingActivity> ShoolingActivity { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0EVUONT;Database=Shooling;Trusted_Connection=true;Encrypt=false");
        }
    }
}
