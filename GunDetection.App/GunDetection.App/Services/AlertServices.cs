using GunDetection.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.App.Services
{
    public static class AlertServices
    {
        public static async Task<List<Alert>> GetAler()
        {
            return await GetPost.Get<List<Alert>>(UrlServices.Url + "/api/Alerts/Get");
        }

        public static async Task<StatusCodeClass> UpdateAler(Alert a)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Alerts/Update/ ",a);
        }
    }
}
