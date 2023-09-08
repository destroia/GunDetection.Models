using GunDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Interface
{
    public interface ISubUserData
    {
        Task<object> CreateUserAlarm(UserAlarm user);
        Task<object> UpdateUserAlarm(UserAlarm user);
        Task<object> DaleteUserAlarm(UserAlarm user);
        Task<List<UserAlarm>> GetUserAlarm(Guid id);

        Task<object> CreateUserAccess(User user);
        Task<object> UpdateUserAccess(User user);
        Task<object> DaleteUserAccess(User user);
        Task<List<User>> GetUserAccess(Guid id);


    }
}
