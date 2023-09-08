using GunDetection.Data.Interface;
using GunDetection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GunDetection.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        readonly ICameraData Repo;
        public CamerasController(ICameraData repo)
        {
            Repo = repo;
        }


        /// <summary>
        /// Retorna una lista de camaras por id de la cuenta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Alert</returns>
        [HttpGet("{id}")]
        public async Task<IEnumerable<Camera>> Get(Guid id)
        {
            return await Repo.Get(id);
        }

        /// <summary>
        /// Crea una camara 
        /// </summary>
        /// <returns>Alert</returns>
        [HttpPost]
        public async Task<ActionResult> Create(Camera camera)
        {
            var res = await Repo.Create(camera);
            if (res.GetType().Name == "Camera")
            {
                return Ok(new { StatusCode = 200, res = res });
            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        /// Actualiza una camara  
        /// </summary>
        /// <returns>Alert</returns>
        [HttpPost]
        public async Task<ActionResult> Update(Camera camera)
        {
            var res = await Repo.Update(camera);
            if (res.GetType().Name == "Camera")
            {
                return Ok(new { StatusCode = 200, res = res });
            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        /// Elimina una camara 
        /// </summary>
        /// <returns>Alert</returns>
        [HttpPost]
        public async Task<ActionResult> Delete(Camera camera)
        {
            var res = await Repo.Delete(camera);
            if (res.GetType().Name == "Boolean")
            {
                return Ok(new { StatusCode = 200, res = res });
            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
    }
}
