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
    public class UsersController : ControllerBase
    {
        readonly IUserData Repo;
        public UsersController(IUserData repo)
        {
            Repo = repo;
        }
        /// <summary>
        ///  Retorna un usuario por el id  
        /// </summary>
        /// <returns> User</returns>
        [HttpGet("{id}")]
        public async Task<User> GetById(Guid id)
        {
            return await Repo.GetById(id);
           
        }
        /// <summary>
        ///  Envia un email para restablecer la contraseña parametro el email 
        /// </summary>
        /// <returns> Bool</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> LostPasword(string id)
        {
            bool res = await Repo.LostPassword(id);
            if (res)
            {
                return Ok(new { res = res });
            }
            return Ok(new { res = res });
        }
        /// <summary>
        /// Hace la validacion inicial 
        /// </summary>
        /// <returns> Bool</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> Validar(Guid id)
        {
            bool res = await Repo.Validar(id);

            return Ok(new { res = res });
        }


        /// <summary>
        /// Crea un usuario desde el formulario 
        /// </summary>
        /// <returns> Bool</returns>
        [HttpPost]
        public async Task<ActionResult<bool>> SignIn(User user)
        {
            int res =  await Repo.SignIn(user);

            if (res == 1)
            {
                return Ok(new { res = 1 });
            }
            else if (res == 2)
            {
               return Ok(new { res = 2 });
            }
            
            return Ok(new { res = 3 });
        }
        /// <summary>
        /// Crea un nuevo password 
        /// </summary>
        /// <returns> Bool</returns>
        [HttpPost]
        public async Task<ActionResult<bool>> CreatePassword(CreatePassword create)
        {
            bool res = await Repo.CreatePassword(create);

            if (res)
            {
                return Ok(new { res = true });
            }
            return BadRequest(new { res = false });
        }
        /// <summary>
        /// Hace el login para acceder a la app
        /// </summary>
        /// <returns> Bool</returns>
        [HttpPost]
        public async Task<ActionResult<User>> Login(Login login)
        {
            User res = await Repo.Login(login);

            if (res != null)
            {
                return Ok(new { res = true , user = res});
            }
            return BadRequest(new { res = false});
        }


    }
}
