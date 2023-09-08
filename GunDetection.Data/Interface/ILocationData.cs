using GunDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Interface
{
    public interface ILocationData
    {
        Task<object> CreateLocation(Location location);
        Task<object> CreateSubLocation(SubLocation subLocation);
        Task<object> DeleteLocation(Location location);
        Task<object> DeleteSubLocation(SubLocation subLocation);
        Task<object> UpdateLocation(Location location);
        Task<object> UpdateSubLocation(SubLocation subLocation);
        Task<List<Location>> GetLocation(Guid idUser);
        Task<List<SubLocation>> GetSubLocation(Guid idLocation);

    }
}
