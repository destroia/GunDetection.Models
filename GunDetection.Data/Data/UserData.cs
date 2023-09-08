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
    public class UserData :IUserData
    {
        readonly GunDbContext DB;
        public UserData(GunDbContext db)
        {
            DB = db;
        }

        public async Task<bool> CreatePassword(CreatePassword create)
        {
            try
            {
                var user = await DB.Users.FindAsync(create.IdUser);

                if (user != null)
                {
                    create.Password = Encrypt.GetSHA256(create.Password);
                    user.Password = create.Password;

                    DB.Users.Update(user);
                    await DB.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<User> GetById(Guid id)
        {
            return await DB.Users.FindAsync(id);
        }

        public async Task<User> Login(Login login)
        {
            try
            {
                login.Password = Encrypt.GetSHA256(login.Password);
                login.Mail = login.Mail.ToLower();
                return await DB.Users.Where(x => x.Email == login.Mail && x.Password == login.Password).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public async Task<bool> LostPassword(string email)
        {
            
            email = email.ToLower();
            var user = await DB.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user != null)
            {
                string msg = Helpers.Mails.Login.RestorePassword(
                  user.Name + " " + user.LastName,
                  Helpers.Urls.UrlFront + "#/CreatePassword?Id=" + user.Id);

                await SendEmailService.SendEmail(email, "Reset Password - Gun Detector", msg);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> SignIn(User user)
        {
            try
            { user.Id = Guid.NewGuid();
                user.Password = Encrypt.GetSHA256(user.Password);
                user.Email = user.Email.ToLower();

                var userlastCreate = await DB.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync();

                if (userlastCreate != null)
                {
                    return 2;
                }
                user.Account = user.Id;
                await DB.Users.AddAsync(user);
                await DB.SaveChangesAsync();
                string msg = Helpers.Mails.Login.ValidarAcuenta(
                   user.Name + " " + user.LastName,
                   Helpers.Urls.UrlFront + "#/Validate?Id=" + user.Id);

                await SendEmailService.SendEmail(user.Email, "Validate Account - Gun Detector", msg);

                return 1;
            }
            catch (Exception)
            {
                return 3;
            }
        }

        public async Task<bool> Validar(Guid id)
        {
            var user = await DB.Users.FindAsync(id);
            try
            {
                if (user != null )
                {
                    user.Activate = true;
                    DB.Users.Update(user);
                    await DB.SaveChangesAsync();

                    if (user.Password.Length == 0 || user.Password == null)
                    {
                        string html = Helpers.Mails.Login.RestorePassword(user.Name + " " + user.LastName ,
                           Helpers.Urls.UrlFront + "#/CreatePassword?Id=" + user.Id);

                        await SendEmailService.SendEmail(user.Email, "Create Password - Gun Detector", html);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
