using GunDetection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Interface
{
    public interface IAlertData
    {
        Task<object> Create(AlerApiEx alert);
        Task<object> Update(Alert alert);
        Task<object> Delete(Alert alert);
        Task<List<Alert>> Get();
        Task<Alert> GetById(Guid id);
        Task<object> ActionAlert(Guid id);

        IQueryable<Alert> ListReportes(FiltroAlert filtro);
        Task<IEnumerable<Alert>> AddToRepirt(IEnumerable<Alert> alerts, Guid idAcoount);

        IQueryable<Alert> ListaAlerts(FiltroAlert filtro);

    }
}
