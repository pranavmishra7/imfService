﻿using datamodel.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace datamodel
{
    public class imftenant_DbContext:DbContext
    {
        public DbSet<InsuranceCategory> InsuranceCategories { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public imftenant_DbContext(DbContextOptions<imftenant_DbContext> options)
       : base(options)
        { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
