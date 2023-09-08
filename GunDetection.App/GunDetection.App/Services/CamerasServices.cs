using GunDetection.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.App.Services
{
    public static class CamerasServices
    {
        public static async Task<StatusCodeClass> Create(Camera c)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Cameras/Create", c);
        }

        public static async Task<List<Camera>> Get(Guid id)
        {
            return await GetPost.Get<List<Camera>>(UrlServices.Url + "/api/Cameras/Get/" + id);
        }
        public static async Task<StatusCodeClass> Delete(Camera c)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Cameras/Delete", c);
        }
        public static async Task<StatusCodeClass> Update(Camera c)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Cameras/Update", c);
           
        }
    }
}
