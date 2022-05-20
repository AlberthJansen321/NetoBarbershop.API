using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IServiceDoneRepository
    {
        //SERVICEDONE
        Task<ServiceDone[]> GetAllServicesDonesAsync();
        Task<ServiceDone> GetServiceDoneByIdAsync(int id);
    }
}
