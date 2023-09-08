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
    public class LocationsController : ControllerBase
    {
        readonly ILocationData Repo;
        public LocationsController(ILocationData repo)
        {
            Repo = repo;
        }
        ///// <summary>
        ///// Actualiza una camara  
        ///// </summary>
        ///// <returns>Alert</returns>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    var r = new Location().GetType().Name;
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// Retorna una lista de locaciones por  cuenta 
        /// </summary>
        /// <returns>list Location</returns>
        [HttpGet("{id}")]
        public async Task<List<Location>> Get(Guid id)
        {
            return await Repo.GetLocation(id);
        }
        /// <summary>
        /// Retorna una lista de Sublocaciones por  cuenta 
        /// </summary>
        /// <returns>list SubLocation</returns>
        [HttpGet("{id}")]
        public async Task<List<SubLocation>> GetSub(Guid id)
        {
            return await Repo.GetSubLocation(id);
        }

        /// <summary>
        /// Crea una locacion nueva 
        /// </summary>
        /// <returns>Location</returns>
        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation(Location location)
        {
            var resp = await Repo.CreateLocation(location);
            if (resp.GetType().Name == "Location")
            {
                return Ok(new { res = resp, StatusCode = 200 });
            }
            else
            {
                return Ok(new { res = resp, StatusCode = 202 });
            }
        }
        /// <summary>
        /// Crea una Sublocacion nueva 
        /// </summary>
        /// <returns>SubLocation</returns>
        [HttpPost]
        public async Task<ActionResult<SubLocation>> CreateSubLocation(SubLocation subLocation)
        {
            var resp = await Repo.CreateSubLocation(subLocation);
            if (resp.GetType().Name == "SubLocation")
            {
                return Ok(new { res = resp, StatusCode = 200 });
            }
            else
            {
                return Ok(new { res = resp, StatusCode = 202 });
            }
        }
        /// <summary>
        /// Actuaiza una locacion 
        /// </summary>
        /// <returns>Location</returns>
        [HttpPost]
        public async Task<ActionResult<Location>> UpdateLocation(Location Location)
        {
            var resp = await Repo.UpdateLocation(Location);
            if (resp.GetType().Name == "Location")
            {
                return Ok(new { res = resp, StatusCode = 200 });
            }
            else
            {
                return Ok(new { res = resp, StatusCode = 202 });
            }
        }
        /// <summary>
        /// Actualizar una Sublocacion  
        /// </summary>
        /// <returns>Location</returns>
        [HttpPost]
        public async Task<ActionResult<SubLocation>> UpdateSubLocation(SubLocation subLocation)
        {
            var resp = await Repo.UpdateSubLocation(subLocation);
            if (resp.GetType().Name == "SubLocation")
            {
                return Ok(new { res = resp, StatusCode = 200 });
            }
            else
            {
                return Ok(new { res = resp, StatusCode = 202 });
            }
        }
        /// <summary>
        ///  Elimina una Locacion
        /// </summary>
        /// <returns>Location</returns>
        [HttpPost]
        public async Task<ActionResult<Location>> DeleteLocation(Location location)
        {
            var resp = await Repo.DeleteLocation(location);
            if (resp.GetType().Name == "Boolean")
            {
                return Ok(new { res = resp, StatusCode = 200 });
            }
            else
            {
                return Ok(new { res = resp, StatusCode = 202 });
            }
        }
        /// <summary>
        ///  Elimina una SubLocacion
        /// </summary>
        /// <returns>SubLocation</returns>
        [HttpPost]
        public async Task<ActionResult<SubLocation>> DeleteSubLocation(SubLocation subLocation)
        {
            var resp = await Repo.DeleteSubLocation(subLocation);
            if (resp.GetType().Name == "Boolean")
            {
                return Ok(new { res = resp, StatusCode = 200 });
            }
            else
            {
                return Ok(new { res = resp, StatusCode = 202 });
            }
        }
    }
}
