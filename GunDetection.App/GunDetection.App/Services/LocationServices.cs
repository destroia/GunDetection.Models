using GunDetection.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.App.Services
{
    public static class LocationServices
    {
        public static async Task<StatusCodeClass> CreateLocation(Location l)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Locations/CreateLocation", l);
        }
        public static async Task<StatusCodeClass> CreateSubLocation(SubLocation l)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Locations/CreateSubLocation", l);
        }
        public static async Task<List<SubLocation>> GetSubLocationsAsync(Guid l)
        {
            return await GetPost.Get<List<SubLocation>>(UrlServices.Url + "/api/Locations/GetSub/" + l);
        }
        public static async Task<List<Location>> GetLocationsAsync(Guid l)
        {
            return await GetPost.Get<List<Location>>(UrlServices.Url + "/api/Locations/Get/"+ l);
        }

        public static async Task<StatusCodeClass> UpdateLocation(Location l)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Locations/UpdateLocation", l);
        }
        public static async Task<StatusCodeClass> UpdateSubLocation(SubLocation l)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Locations/UpdateSubLocation", l);
        }

        public static async Task<StatusCodeClass> DeleteLocation(Location l)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Locations/DeleteLocation", l);
        }
        public static async Task<StatusCodeClass> DeleteSubLocation(SubLocation l)
        {
            return await GetPost.Post<StatusCodeClass>(UrlServices.Url + "/api/Locations/DeleteSubLocation", l);
        }
    }
}
