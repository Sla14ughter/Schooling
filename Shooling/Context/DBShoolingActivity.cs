using Microsoft.EntityFrameworkCore;
using Shooling.Models;

namespace Shooling.Context
{
    public class DbShoolingActivity: DbContext
    {
        public DbSet<SchoolingActivity> ShoolingActivity { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0EVUONT;Database=Shooling;User Id=SchoolingUser;Password=bebra123; Encrypt=false;");
        }
    }
}
