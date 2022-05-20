using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IServiceRepository
    {
        //SERVICE
        Task<Service[]> GetServiceByNomeAsync(string nome, bool includeServiceDone = false);
        Task<Service[]> GetAllServicesAsync(bool includeServiceDone = false);
        Task<Service> GetServiceByIdAsync(int id, bool includeServiceDone = false);
    }
}
