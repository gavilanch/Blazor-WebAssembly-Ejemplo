using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var personas = new List<Persona>();
            for (int i = 5; i < 1000; i++)
            {
                personas.Add(new Persona() { Id = i, Nombre = $"Persona {i}" });    
            }

            builder.Entity<Persona>().HasData(personas);

            base.OnModelCreating(builder);
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
