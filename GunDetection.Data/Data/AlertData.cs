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
    public class AlertData : IAlertData
    {
        readonly GunDbContext DB;
        public AlertData(GunDbContext db)
        {
            DB = db;
        }

        public Task<object> ActionAlert(Guid id)
        {
            throw new NotImplementedException();
        }

      

        public async Task<object> Create(AlerApiEx alert)
        {
            try
            {
                alert.Category = alert.Category.ToLower();
                var A = new Alert();

                A.Id = Guid.NewGuid();
                A.Date = alert.Date;
                A.Category = alert.Category;
                A.Name_alarm = alert.Name_alarm;
                A.Msg = alert.Msg;
                A.Status = "";
                A.Mimetype = alert.Mimetype;
                A.Filename = alert.Mimetype;
                A.Full_photo = alert.Full_photo;
                A.Clip = alert.Video;

                await DB.Alerts.AddAsync(A);
                await DB.SaveChangesAsync();
               
                //Todo 




                var usuAlarms = await DB.UserAlarms.ToListAsync();
                
                foreach (var item in usuAlarms)
                {
                    string html = Helpers.Mails.Login.AlertAlarm(item.Name + " " + item.LastName,
                        Helpers.Urls.UrlFront + "#/Alert?Id=" + A.Id);

                    await SendEmailService.SendEmail(item.Email, "Alert Detected - Gun Detector", html);

                }
                return alert;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<object> Delete(Alert alert)
        {
            try
            {
               
                 DB.Alerts.Remove(alert);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<List<Alert>> Get()
        {

            return await DB.Alerts.Where(x => x.Status == "").OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<Alert> GetById(Guid id)
        {
            return await DB.Alerts.FindAsync(id);
        }

        public IQueryable<Alert> ListReportes(FiltroAlert filtro)
        {
            return DB.Alerts.AsQueryable()
                .Where(x => x.IdAccount == filtro.IdAccount &&
                                          x.Category.Contains(filtro.TypeAlert) &&
                x.Status.Contains(filtro.Status) &&
                x.Date >= filtro.From && x.Date <= filtro.To.AddDays(1)).OrderByDescending(x => x.Date);
        }
        public async Task<IEnumerable<Alert>> AddToRepirt(IEnumerable<Alert> alerts ,Guid idAcoount)
        {

            var user = await DB.Users.Where(x => x.Account == idAcoount).Select(x => new User()
            {
                Id = x.Id,
                Account = x.Account,
                Email = x.Email,
                Name = x.Name,
                LastName = x.LastName
            }).ToListAsync();

            List<Alert> la = new List<Alert>();

            foreach (var item in alerts)
            {
                var u = user.Where(x => x.Id == item.IdUser).FirstOrDefault();
                item.NameUser = u.Name + " " + u.LastName;
                item.EmailUser = u.Email;
            }

           
            return alerts;
        }
        public async   Task<object> Update(Alert alert)
        {
            try
            {
                
                DB.Alerts.Update(alert);
                await DB.SaveChangesAsync();

                return alert;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public IQueryable<Alert> ListaAlerts(FiltroAlert filtro)
        {
            return DB.Alerts.AsQueryable()
                 .Where(x =>
                 x.IdAccount == Guid.Empty && x.IdUser == Guid.Empty &&
                 x.Category.Contains(filtro.TypeAlert) &&
                 x.Status.Contains(filtro.Status) &&
                 x.Date >= filtro.From && x.Date <= filtro.To.AddDays(1)).OrderByDescending(x => x.Date);
        }
    }                 
}
