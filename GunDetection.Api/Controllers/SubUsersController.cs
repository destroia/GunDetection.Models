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
    public class SubUsersController : ControllerBase
    {
        readonly ISubUserData Repo;
        public SubUsersController(ISubUserData repo)
        {
            Repo = repo;
        }


        /// <summary>
        ///  Retorna una lista de usuarios que tienen acceso a la app
        /// </summary>
        /// <returns>List User</returns>
        [HttpGet("{id}")]
        public async Task<IEnumerable<User>> GetUsersAccess(Guid id)
        {
            return await Repo.GetUserAccess(id);
        }
        /// <summary>
        ///  Retorna una lista de usuarios a los que le llegan las alertas 
        /// </summary>
        /// <returns>List UserAlarm</returns>
        [HttpGet("{id}")]
        public async Task<IEnumerable<UserAlarm>> GetUsersAlarm(Guid id)
        {
            return await Repo.GetUserAlarm(id);
        }

        /// <summary>
        ///  Crea un usuario que tendra acceso a la app 
        /// </summary>
        /// <returns>List User</returns>
        [HttpPost]
        public async Task<ActionResult<User>> CreateUsersAccess(User user)
        {
            var res = await Repo.CreateUserAccess(user);
            if (res.GetType().Name == "User")
            {
                return Ok(new { StatusCode = 200, res = res });

            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        ///  Actualiza  un usuario que tiene acceso a la app 
        /// </summary>
        /// <returns> User</returns>
        [HttpPost]
        public async Task<ActionResult<User>> UpdateUsersAccess(User user)
        {
            var res = await Repo.UpdateUserAccess(user);
            if (res.GetType().Name == "User")
            {
                return Ok(new { StatusCode = 200, res = res });

            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        ///  Elimina   un usuario que tiene acceso a la app 
        /// </summary>
        /// <returns> User</returns>
        [HttpPost]
        public async Task<ActionResult<bool>> DeleteUsersAccess(User user)
        {
            var res = await Repo.DaleteUserAccess(user);
            if (res.GetType().Name == "Boolean")
            {
                return Ok(new { StatusCode = 200, res = res });

            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        ///  Crea  un usuario el cual le llegaran alertas 
        /// </summary>
        /// <returns> UserAlarm</returns>
        [HttpPost]
        public async Task<ActionResult<UserAlarm>> CreateUsersAlarm(UserAlarm user)
        {
            var res = await Repo.CreateUserAlarm(user);
            if (res.GetType().Name == "UserAlarm")
            {
                return Ok(new { StatusCode = 200, res = res });

            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        ///  Actualiza  un usuario el cual le llegan alertas 
        /// </summary>
        /// <returns> UserAlarm</returns>
        [HttpPost]
        public async Task<ActionResult<UserAlarm>> UpdateUsersAlarm(UserAlarm user)
        {
            var res = await Repo.UpdateUserAlarm(user);
            if (res.GetType().Name == "UserAlarm")
            {
                return Ok(new { StatusCode = 200, res = res });

            }
            else
            {
                return Ok(new { StatusCode = 202, res = res });
            }
        }
        /// <summary>
        ///  Elimina  un usuario el cual le llegan alertas 
        /// </summary>
        /// <returns> UserAlarm</returns>
        [HttpPost]
        public async Task<ActionResult<UserAlarm>> DeleteUsersAlarm(UserAlarm user)
        {
            var res = await Repo.DaleteUserAlarm(user);
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
