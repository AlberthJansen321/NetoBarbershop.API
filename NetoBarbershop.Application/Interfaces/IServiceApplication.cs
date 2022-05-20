using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.Interfaces
{
    public interface IServiceApplication
    {
        Task<Service> AddService(Service model);
        Task<Service> UpdateService(int serviceid, Service model);
        Task<bool> DeleteService(int serviceid);

        Task<Service[]> GetServiceByNomeAsync(string nome, bool includeServiceDone = false);
        Task<Service[]> GetAllServicesAsync(bool includeServiceDone = false);
        Task<Service> GetServiceByIdAsync(int id, bool includeServiceDone = false);
    }
}
