using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AquaFreeWeb.Models;

namespace AquaFreeWeb.Context
{
    public class MiContext : DbContext
    {
        public MiContext(DbContextOptions<MiContext> options) : base(options)
        {
        }

        public DbSet<Refresco> Refrescos { get; set; }

    }
}
