using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Helpers.Filter
{
    public static class HttpContextExtensions
    {
        public static async Task<int[]> InsertarParametrosPaginacionEnRespuesta<T>(this HttpContext context,
          IQueryable<T> queryable, int cantidadRegistrosAMostrar)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double conteo = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(conteo / cantidadRegistrosAMostrar);
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
            context.Response.Headers.Add("totalRegistros", totalPaginas.ToString());
            return new int[] { (int)totalPaginas, (int)conteo };
        }
    }
}
