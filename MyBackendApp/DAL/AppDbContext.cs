﻿using Microsoft.EntityFrameworkCore;
using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}