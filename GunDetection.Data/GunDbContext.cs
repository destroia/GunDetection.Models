using GunDetection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Data
{
    public class GunDbContext : DbContext
    {
        public GunDbContext(DbContextOptions<GunDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
         
             "Server=tcp:fucuan.database.windows.net,1433;Initial Catalog=DB_Gum;Persist Security Info=False;User ID=f_admin;Password=Funcuan2020%;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=3000;"
             );



            base.OnConfiguring(optionsBuilder);
            //Primer Migracion   Add-Migration InitialCreate
            //Despues de la primera migracion se utiliza  Update-Database
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAlarm> UserAlarms { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SubLocation> SubLocations { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Alert> Alerts { get; set; }

    }
}
