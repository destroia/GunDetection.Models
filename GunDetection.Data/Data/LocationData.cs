using GunDetection.Data.Interface;
using GunDetection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Data
{
    public class LocationData : ILocationData
    {
        readonly GunDbContext DB;
        public LocationData(GunDbContext db)
        {
            DB = db;
        }
        public async Task<object> CreateLocation(Location location)
        {
            try
            {
                await DB.Locations.AddAsync(location);
                await DB.SaveChangesAsync();

                return location;

            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<object> CreateSubLocation(SubLocation subLocation)
        {
            try
            {
                await DB.SubLocations.AddAsync(subLocation);
                await DB.SaveChangesAsync();

                return subLocation;

            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<object> DeleteLocation(Location location)
        {
            try
            {
               // DB.SubLocations.RemoveRange(location.SubLocations);
                DB.Locations.Remove(location);

                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<object> DeleteSubLocation(SubLocation subLocation)
        {
            try
            {
                DB.SubLocations.Remove(subLocation);

                await DB.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<List<Location>> GetLocation(Guid idUser)
        {
            return await DB.Locations.Where(x => x.IdUser == idUser).ToListAsync();
        }

        public async Task<List<SubLocation>> GetSubLocation(Guid idLocation)
        {
            return await DB.SubLocations.Where(x => x.IdLocation == idLocation).ToListAsync();
        }

        public async  Task<object> UpdateLocation(Location location)
        {
            try
            {
                DB.Locations.Update(location);

                await DB.SaveChangesAsync();

                return location; ;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<object> UpdateSubLocation(SubLocation subLocation)
        {
            try
            {
                DB.SubLocations.Update(subLocation);

                await DB.SaveChangesAsync();

                return subLocation; ;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }
    }
}
