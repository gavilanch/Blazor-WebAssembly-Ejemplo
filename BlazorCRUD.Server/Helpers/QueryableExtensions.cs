using BlazorCRUD.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginacion paginacion)
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.CantidadAMostrar)
                .Take(paginacion.CantidadAMostrar);
        }
    }
}
