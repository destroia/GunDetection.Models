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
    public class CameraData : ICameraData
    {
        readonly GunDbContext DB;
        public CameraData(GunDbContext db)
        {
            DB = db;
        }
        public async  Task<object> Create(Camera camera)
        {
            try
            {
                await DB.Cameras.AddAsync(camera);
                await DB.SaveChangesAsync();

                return camera;
            }
            catch (Exception ex)
            {
                return ex;
            }
           
        }

        public async Task<object> Delete(Camera camera)
        {
            try
            {
                DB.Cameras.Remove(camera);
                await DB.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<List<Camera>> Get(Guid id)
        {
            return await DB.Cameras.Join(DB.Locations, C => C.IdLocation, L => L.Id, (C, L) => new { C, L })
                .Join(DB.SubLocations, C => C.C.IdSubLocation, Sub => Sub.Id, (C, Sub) => new { C, Sub })
                .Where(x => x.C.C.IdUser == id).Select(x => new Camera
                {
                    Id = x.C.C.Id,
                    IdUser = x.C.C.IdUser,
                    IdLocation = x.C.C.IdLocation,
                    IdSubLocation = x.C.C.IdSubLocation,
                    Name = x.C.C.Name,
                    Location = x.C.L.Name,
                    SubLocation = x.Sub.Name
                })
                .ToListAsync();
        }

        public async Task<object> Update(Camera camera)
        {
            try
            {
                DB.Cameras.Update(camera);
                await DB.SaveChangesAsync();

                return camera;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
