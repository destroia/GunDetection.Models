using Azure.Storage.Blobs;
using GunDetection.Data.Helpers.Filter;
using GunDetection.Data.Interface;
using GunDetection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GunDetection.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        readonly IBlobStorageAzure Blob;
        readonly IAlertData Repo;
        public AlertsController(IAlertData repo, IBlobStorageAzure blob)
        {
            Repo = repo;
            Blob = blob;
        }
        /// <summary>
        /// Retorna una alerta por el id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Alert</returns>
        [HttpGet("{id}")]
        public async Task<Alert> GetById(Guid id)
        {
            return await Repo.GetById(id);
        }
        /// <summary>
        /// Retorna una lista de alertas 
        /// </summary>
        /// <returns>list Alert</returns>
        [HttpGet]
        public async Task< IEnumerable<Alert>> Get()
        {
            return await Repo.Get();
        }
        /// <summary>
        /// Retorna una lista de alertas con paginacion deacuerdo al filtro 
        /// </summary>
        /// <returns>list Alert</returns>
        [HttpPost]
        public async Task<ActionResult<List<Alert>>> GetListAlerts(FiltroAlert filtro)
        {
            int p = 0;
            var query = Repo.ListaAlerts(filtro);
            if (query.Count() != 0)
            {
                var listafiltrada = await query.Paginar(new Paginacion() { Pagina = filtro.Pag, CantidadMostrar = 20 }).ToListAsync();

                if (query.Count() < 20)
                {
                    p = 1;
                }
                else
                {
                    p = 1 + (int)(query.Count() / 20);
                }

                return Ok(new { StatusCode = 200, res = listafiltrada, TotalRegistros = query.Count(), TotalPaginas = p });

               
            }
            return Ok(new { StatusCode = 202, path = "NingunRegistro" });
        }
        /// <summary>
        /// Retorna una lista de Reportes de alertas  con paginacion deacuerdo al filtro 
        /// </summary>
        /// <returns>list Alert</returns>
        [HttpPost]
        public async Task<ActionResult<List<Alert>>> GetReports(FiltroAlert filtro)
        {
            int p = 0;
            var query = Repo.ListReportes(filtro);

            if (query.Count() != 0)
            {
                await HttpContext.InsertarParametrosPaginacionEnRespuesta<Alert>(query, 20);

                var listafiltrada = await query.Paginar(new Paginacion() { Pagina = filtro.Pag, CantidadMostrar = 20 }).ToListAsync();

                var ListAlert = await Repo.AddToRepirt(listafiltrada , filtro.IdAccount);
                
                if (query.Count() < 20 )
                {
                    p = 1;
                }
                else
                {
                    p = 1 + (int)(query.Count() / 20);
                }
                
                return Ok(new { StatusCode = 200, res = ListAlert, TotalRegistros = query.Count(), TotalPaginas = p });
            }
            else
            {
                return Ok(new { StatusCode = 202, path = "NingunRegistro" });
            }

        }

        /// <summary>
        /// Crea un alerta 
        /// </summary>
        /// <returns>list Alert</returns>
        [HttpPost]
        public async Task<ActionResult<AlerApiEx>> Create(AlerApiEx alert)
        {
            try
            {
                var s = await Blob.UploadBase64BlobAsync("alert", "data:image/jpeg;base64," +alert.Full_photo, alert.Filename + Guid.NewGuid().ToString() + ".jpeg");
                alert.Full_photo = s.ToString();
            }
            catch (Exception ex)
            {

                return Ok(new { res = ex.Message });
            }
            var res = await Repo.Create(alert);
            if (res.GetType().Name == "AlerApiEx")
            {
                return Ok(new { StatusCode = 200, res = res ,});
            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        /// Actualiza una alerta 
        /// </summary>
        /// <returns> Alert</returns>
        [HttpPost]
        public async Task<ActionResult<Alert>> Update(Alert alert)
        {
            var res = await Repo.Update(alert);
            if (res.GetType().Name == "Alert")
            {
                return Ok(new { StatusCode = 200, res = res, });
            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        /// Elimina una alerta 
        /// </summary>
        /// <returns> Bool</returns>
        [HttpPost]
        public async Task<ActionResult<Alert>> Delete(Alert alert)
        {
            var res = await Repo.Update(alert);
            if (res.GetType().Name == "Boolean")
            {
                return Ok(new { StatusCode = 200, res = res, });
            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
    }
}
