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

            var paises = new List<Pais>() {
                new Pais() { Id = 1, Nombre = "Rep Dom"},
            new Pais() { Id = 2, Nombre = "México"}};

            builder.Entity<Pais>().HasData(paises);

            var estados = new List<Estado>() {
                    new Estado() { Id = 1, Nombre = "Santo Domingo", PaisId = 1 },
                    new Estado() { Id = 2, Nombre = "San Cristobal", PaisId = 1 },
                    new Estado() { Id = 3, Nombre = "Ciudad de México", PaisId = 2 },
                    new Estado() { Id = 4, Nombre = "Jalisco", PaisId = 2 },
            };

            builder.Entity<Estado>().HasData(estados);

            var personas = new List<Persona>();
            for (int i = 1; i < 15; i++)
            {
                personas.Add(new Persona() { Id = i, Nombre = $"Persona {i}", EstadoId = 1 });    
            }

            builder.Entity<Persona>().HasData(personas);

            base.OnModelCreating(builder);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
    }
}
