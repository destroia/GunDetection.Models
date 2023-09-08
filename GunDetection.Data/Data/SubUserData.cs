using GunDetection.Data.Interface;
using GunDetection.Data.Services;
using GunDetection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Data
{
    public class SubUserData : ISubUserData
    {
        readonly GunDbContext DB;
        public SubUserData(GunDbContext db)
        {
            DB = db;
        }
        public async Task<object> CreateUserAccess(User user)
        {
            try
            {
                var ids = await DB.Users.Where(x => x.Email == user.Email).Select(x => x.Id).ToListAsync();
                if (ids.Count() != 0)
                {
                    return 1;
                }
                await DB.Users.AddAsync(user);
                await DB.SaveChangesAsync();
                string html = Helpers.Mails.Login.ValidarAcuenta(user.Name + " " + user.LastName,
                    Helpers.Urls.UrlFront + "#/Validate?Id=" + user.Id);

                await SendEmailService.SendEmail(user.Email, "Validate Account - Gun Detector", html);

                return user;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<object> CreateUserAlarm(UserAlarm user)
        {
            try
            {
                await DB.UserAlarms.AddAsync(user);
                await DB.SaveChangesAsync();

                string html = Helpers.Mails.Login.SuscripcionAlarm(user.Name + " " + user.LastName);
                await SendEmailService.SendEmail(user.Email, "Welcome to Gun Detector", html);

                return user;
            }
            catch (Exception ex)
            {
                
                return ex;
            }
        }

        public async Task<object> DaleteUserAccess(User user)
        {
            try
            {
                DB.Users.Remove(user);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<object> DaleteUserAlarm(UserAlarm user)
        {
            try
            {
                DB.Remove(user);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<List<User>> GetUserAccess(Guid id)
        {
            try
            {
                var li = await DB.Users.Where(x => x.Account == id).ToListAsync();

                var c = li.Where(x => x.Id == x.Account).FirstOrDefault();

                if (c != null)
                {
                    li.Remove(c);

                }
                return li;
            }
            catch (Exception)
            {

                return null;
            }
           
        }

        public async Task<List<UserAlarm>> GetUserAlarm(Guid id)
        {
            return await DB.UserAlarms.Where(x => x.IdAccount == id).ToListAsync();
        }

        public async Task<object> UpdateUserAccess(User user)
        {
            try
            {
                DB.Users.Update(user);
                await DB.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<object> UpdateUserAlarm(UserAlarm user)
        {
            try
            {
                DB.UserAlarms.Update(user);
                await DB.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
