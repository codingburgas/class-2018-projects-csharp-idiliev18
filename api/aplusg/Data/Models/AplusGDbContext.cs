﻿using aplusg.Data.Models;
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
		public DbSet<User> Users { get; set; }
		public DbSet<LightSensor> lightSensors { get; set; }
		public DbSet<MoistureSensor> moistureSensors { get; set; }
	}
}