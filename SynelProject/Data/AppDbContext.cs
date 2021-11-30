using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SynelProject.Models.EntityModels;

namespace SynelProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PersonEntityModel> Persons { get; set; }

    }
}
