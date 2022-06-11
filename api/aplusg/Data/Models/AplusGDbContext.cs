using aplusg.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Models
{
	public class AplusGDbContext : DbContext
	{
		public AplusGDbContext (DbContextOptions<AplusGDbContext> optionsBuilder) : base(optionsBuilder)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<UserRole>().HasKey(table => new {
				table.UserId,
				table.RoleId
			});
		}

		public DbSet<User> Users { get; set; }
		public DbSet<LightSensor> LightSensors { get; set; }
		public DbSet<MoistureSensor> MoistureSensors { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UsersRoles { get; set; }
	}
}