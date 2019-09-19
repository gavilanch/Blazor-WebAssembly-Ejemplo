using BlazorCRUD.Server.Helpers;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Persona>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Personas.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadAMostrar);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "obtenerPersona")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            return await context.Personas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerPersona", new { id = persona.Id }, persona);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            context.Entry(persona).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var persona = new Persona { Id = id };
            context.Remove(persona);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
