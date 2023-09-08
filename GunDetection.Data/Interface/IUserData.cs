using GunDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Interface
{
    public interface IUserData
    {
        Task<User> Login(Login login);
        Task<int> SignIn(User user);
        Task<bool> CreatePassword(CreatePassword create);
        Task<bool> LostPassword(string email);
        Task<bool> Validar(Guid id);
        Task<User> GetById(Guid id);

    }
}
