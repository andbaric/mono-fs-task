﻿using System;
using Microsoft.EntityFrameworkCore;
using Project.Service.Models;

namespace Project.Service.DataAccess
{
    public class VehicleDbContext: DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseMySql(
                "User=root;Password=aiq&m5%SJk;Server=localhost;Port=3306;Database=vehicle_db;"
            );
    }
}