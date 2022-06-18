using aplusg.Data.Models;
using BilliardClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardClub.Data.Models
{
    class AplusGDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LightSensor> LightSensors { get; set; }
        public DbSet<MoistureSensor> MoistureSensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BilliardClubDb;Integrated Security=True;");
            }
        }
    }
}
