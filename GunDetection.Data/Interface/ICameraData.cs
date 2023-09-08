using GunDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Interface
{
    public interface ICameraData
    {
        Task<object> Create(Camera camera);
        Task<object> Update(Camera camera);
        Task<object> Delete(Camera camera);
        Task<List<Camera>> Get(Guid id);
    }
}
